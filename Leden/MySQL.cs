using System;
using System.Threading.Tasks;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Util.MySQL;

namespace Leden.Net
{
    public class JWTToken
    {
        public string Token { get; set; }
    }

    public class MySqlDB  
    {
        string databaseString;
        string phpLocatie;


        static HttpClient client = new HttpClient();

        private static MemoryStream SerializeJsonIntoStream(string value)
        {
            var stream = new MemoryStream();
            var writer = new StreamWriter(stream);
            writer.Write(value);
            writer.Flush();
            stream.Position = 0;
            return stream;
        }

        public static async Task<string> Login(string jsonString)
        {
            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;

            HttpContent content = new StreamContent(SerializeJsonIntoStream(jsonString));
            content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://www.ttvn.nl/api/login"));
            request.Content = content;

            HttpResponseMessage response = await client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsStringAsync();
        }

        public static async void Update2(object obj, string db)
        {
            try
            {
                string credentials = @"{""userid"":""3198048"", ""password"":""TTVN4all"", ""database"":""" + db + @""", ""keepsignedin"":""false""}";

                string jsonToken = await Login(credentials);
                JWTToken token = JsonConvert.DeserializeObject<JWTToken>(jsonToken);

                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12 | SecurityProtocolType.Tls11 | SecurityProtocolType.Tls;
                foreach (tblLid lid in (from lid in (LedenLijst)obj where lid.Dirty == true select lid))
                {
                    string jsonString = JsonConvert.SerializeObject(new Lid(lid));
                    HttpContent content = new StreamContent(SerializeJsonIntoStream(jsonString));
                    content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                    HttpRequestMessage request = new HttpRequestMessage(new HttpMethod("PATCH"), new Uri("https://www.ttvn.nl/api/lid/update"));
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.Token);
                    request.Content = content;

                    HttpResponseMessage response = await client.SendAsync(request);

                    if (response.StatusCode == HttpStatusCode.NotFound)
                    {
                        content = new StreamContent(SerializeJsonIntoStream(jsonString));
                        content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
                        request = new HttpRequestMessage(HttpMethod.Post, new Uri("https://www.ttvn.nl/api/lid/insert"));
                        request.Content = content;
                        response = await client.SendAsync(request);

                        if (response.StatusCode != HttpStatusCode.OK)
                        {
                            response.EnsureSuccessStatusCode();

                        }


                    }



                    string tmp = await response.Content.ReadAsStringAsync();
                }
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }




        public MySqlDB(string db, string user, string pw)
        {
            databaseString = "user=" + user + "&pw=" + pw + "&db=" + db;
            phpLocatie = "http://android.ttvn.nl/webservice/";
        }

        public MySQLGeneralResponse Update(object obj)
        {
            string createPHPUrlString = string.Empty;

            if (obj is tblLid)
                return WebRequestUpdate("lid", ((tblLid)obj).CreatePHPUrlString());

            if (obj is LedenLijst)
            {
                foreach (tblLid lid in (from lid in (LedenLijst)obj where lid.Dirty == true select lid))
                   WebRequestUpdate("lid", lid.CreatePHPUrlString());
            }

            if (obj is tblRekening)
                return WebRequestUpdate("inc", ((tblRekening)obj).CreatePHPUrlString());

            if (obj is RekeningenLijst)
            {
                foreach (tblRekening rekening in (from rekening in (RekeningenLijst)obj where rekening.Dirty == true select rekening))
                    WebRequestUpdate("inc", rekening.CreatePHPUrlString());
            }

            //if (obj is tblCompResult)
            //    return WebRequestUpdate("cor", ((tblCompResult)obj).CreatePHPUrlString());

            //if (obj is ResultatenLijst)
            //{
            //    foreach (tblCompResult compResult in (from compResult in (ResultatenLijst)obj where compResult.Dirty == true select compResult))
            //        WebRequestUpdate("cor", compResult.CreatePHPUrlString());
            //}
            
            //if (obj is tblBetaling)
            //    return WebRequestUpdate("bet", ((tblBetaling)obj).CreatePHPUrlString());

            //if (obj is BetalingenLijst)
            //{
            //    foreach (tblBetaling betaling in (from betaling in (BetalingenLijst)obj where betaling.Dirty == true select betaling))
            //        WebRequestUpdate("bet", betaling.CreatePHPUrlString());
            //}
            
            //if (obj is tblCrediteur)
            //    return WebRequestUpdate("cre", ((tblCrediteur)obj).CreatePHPUrlString());

            //if (obj is CrediteurenLijst)
            //{
            //    foreach (tblCrediteur crediteur in (from crediteur in (CrediteurenLijst)obj where crediteur.Dirty == true select crediteur))
            //        WebRequestUpdate("cre", crediteur.CreatePHPUrlString());
            //}
            
            return null;
        }

        public List<object> SelectAll()
        {
            MyWebRequest myRequest = new MyWebRequest(phpLocatie + "agenda.php", "POST", databaseString);
            string s = myRequest.GetStringResponse();
            
            List<object> resultList = new List<object>();

        //    MyWebRequest 
                myRequest = new MyWebRequest(phpLocatie + "lidselectall.php", "POST", databaseString);
            MySQLLidResponse myResponse = JsonConvert.DeserializeObject<MySQLLidResponse>(myRequest.GetStringResponse());
            resultList.Add(myResponse.posts);

            myRequest = new MyWebRequest(phpLocatie + "incselectall.php", "POST", databaseString);
            MySQLIncassoResponse myResponse2 = JsonConvert.DeserializeObject<MySQLIncassoResponse>(myRequest.GetStringResponse());
            resultList.Add(myResponse2.posts);

            myRequest = new MyWebRequest(phpLocatie + "corselectall.php", "POST", databaseString);
            MySQLCompResultResponse myResponse3 = JsonConvert.DeserializeObject<MySQLCompResultResponse>(myRequest.GetStringResponse());
            resultList.Add(myResponse3.posts);

            myRequest = new MyWebRequest(phpLocatie + "betselectall.php", "POST", databaseString);
            MySQLBetalingResponse myResponse4 = JsonConvert.DeserializeObject<MySQLBetalingResponse>(myRequest.GetStringResponse());
            resultList.Add(myResponse4.posts);


            myRequest = new MyWebRequest(phpLocatie + "creselectall.php", "POST", databaseString);
            MySQLCrediteurResponse myResponse5 = JsonConvert.DeserializeObject<MySQLCrediteurResponse>(myRequest.GetStringResponse());
            resultList.Add(myResponse5.posts);
            return resultList;
        }


        private MySQLGeneralResponse WebRequestUpdate(string tabel, string urlString)
        {
            try
            {
                Console.WriteLine(databaseString);
                MyWebRequest myRequest = new MyWebRequest(phpLocatie + tabel + "update.php", "POST", databaseString + urlString);
                MySQLGeneralResponse obj = JsonConvert.DeserializeObject<MySQLGeneralResponse>(myRequest.GetStringResponse());
                if (obj.success == 4)
                {
                    myRequest = new MyWebRequest(phpLocatie + tabel + "insert.php", "POST", databaseString + urlString);
                    obj = JsonConvert.DeserializeObject<MySQLGeneralResponse>(myRequest.GetStringResponse());
                }
                Console.WriteLine(obj.message);
                
                

                    
                return obj;
            }
            catch (Exception ex)
            {
                MySQLGeneralResponse obj = new MySQLGeneralResponse();
                obj.message = ex.Message;
                obj.success = 0;
                return obj;
            }
        }




    }
}

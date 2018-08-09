using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Newtonsoft.Json;
using Util.Extensions;

namespace Util.MySQL
{
    public class MyWebRequest
    {
        private WebRequest request;
        private Stream dataStream;

        private string status;

        public String Status
        {
            get
            {
                return status;
            }
            set
            {
                status = value;
            }
        }

        public MyWebRequest(string url)
        {
            // Create a request using a URL that can receive a post.

            request = WebRequest.Create(url);
        }

        public MyWebRequest(string url, string method)
            : this(url)
        {

            if (method.Equals("GET") || method.Equals("POST"))
            {
                // Set the Method property of the request to POST.
                request.Method = method;
            }
            else
            {
                throw new Exception("Invalid Method Type");
            }
        }

        public MyWebRequest(string url, string method, string data)
            : this(url, method)
        {

            // Create POST data and convert it to a byte array.
            string postData = data;
            byte[] byteArray = Encoding.UTF8.GetBytes(postData);

            // Set the ContentType property of the WebRequest.
            request.ContentType = "application/x-www-form-urlencoded";

            // Set the ContentLength property of the WebRequest.
            request.ContentLength = byteArray.Length;

            // Get the request stream.
            dataStream = request.GetRequestStream();

            // Write the data to the request stream.
            dataStream.Write(byteArray, 0, byteArray.Length);

            // Close the Stream object.
            dataStream.Close();

        }

        public Stream GetStreamResponse()
        {
            // Get the original response.
            WebResponse response = request.GetResponse();
            this.Status = ((HttpWebResponse)response).StatusDescription;
            Stream stream = response.GetResponseStream();
            StreamReader mr = new StreamReader(stream);
            string a = mr.ReadToEnd();
            return stream;
        }


        public string GetStringResponse()
        {
            // Get the original response.
            WebResponse response = request.GetResponse();
            
            this.Status = ((HttpWebResponse)response).StatusDescription;

            // Get the stream containing all content returned by the requested server.
            dataStream = response.GetResponseStream();

            // Open the stream using a StreamReader for easy access.
            StreamReader reader = new StreamReader(dataStream, System.Text.Encoding.ASCII);
            
            // Read the content fully up to the end.
            // Ik heb werkelijk geen idee waarom ik soms een extra char krijg voorafgaand aan de json response
            // Het schijnnt een byteorder indicatie te zijn. Waarom soms wel en soms niet. Verkeerde encoding?
            string responseFromServer = reader.ReadToEnd();//.RemoveBom();


            // Clean up the streams.
            reader.Close();
            dataStream.Close();
            response.Close();

            return responseFromServer;
        }

    }



    public class MySQLGeneralResponse
    {
        public int success { get; set; }
        public string message { get; set; }
    }

    #region BoolConverter
    public class BoolConverter : JsonConverter
    {
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            writer.WriteValue(((bool)value) ? 1 : 0);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return reader.Value.ToString() == "1";
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(bool);
        }
    }
    #endregion  

}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Util.Email
{
    class PrependFile
    {
        private static readonly Encoding _defaultEncoding = new UTF8Encoding(false, true); // encoding used in File.ReadAll*()
        private static object _bufferSizeLock = new Object();
        private static int _bufferSize = 1024 * 1024; // 1mb
        public static int BufferSize
        {
            get
            {
                lock (_bufferSizeLock)
                {
                    return _bufferSize;
                }
            }
            set
            {
                lock (_bufferSizeLock)
                {
                    _bufferSize = value;
                }
            }
        }

        public static void PrependAllLines(string originalFile, IEnumerable<string> contents)
        {
            PrependAllLines(originalFile, contents, _defaultEncoding);
        }

        public static void PrependAllLines(string originalFile, IEnumerable<string> contents, Encoding encoding)
        {
            string path = Path.GetDirectoryName(originalFile);
            var temp = Path.Combine(path, "tmp", Guid.NewGuid().ToString(), ".tmp");
            File.WriteAllLines(temp, contents, encoding);
            AppendToTemp(originalFile, temp, encoding);
            File.Replace(temp, originalFile, null);
        }

        public static void PrependAllText(string originalFile, string contents)
        {
            PrependAllText(originalFile, contents, _defaultEncoding);
        }

        public static void PrependAllText(string originalFile, string contents, Encoding encoding)
        {
            string path = Path.GetDirectoryName(originalFile);
            var temp = Path.Combine(path, string.Format("zz{0}.tmp",  Guid.NewGuid().ToString()));
            File.WriteAllText(temp, contents, encoding);
            AppendToTemp(originalFile, temp, encoding);
            File.Replace(temp, originalFile, null);
        }

        private static void AppendToTemp(string path, string temp, Encoding encoding)
        {
            var bufferSize = BufferSize;
            char[] buffer = new char[bufferSize];

            using (var writer = new StreamWriter(temp, true, encoding))
            {
                using (var reader = new StreamReader(path, encoding))
                {
                    int bytesRead;
                    while ((bytesRead = reader.ReadBlock(buffer, 0, bufferSize)) != 0)
                    {
                        writer.Write(buffer, 0, bytesRead);
                    }
                }
            }
        }
    }
}

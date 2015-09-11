using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace TSMsg
{
    class Program
    {
        static void Main(string[] args)
        {
            try {
                string URI = "http://127.0.0.1/"+args[0];
                string myParameters = "username=" + args[1] + "&password=" + Base64Decode(args[2]) + "&message=" + args[3];

                using (WebClient wc = new WebClient())
                {
                    wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
                    string HtmlResult = wc.UploadString(URI, myParameters);
                    Console.WriteLine(HtmlResult);
                }
            } catch(Exception e) { Console.WriteLine(e.GetType().ToString()); }
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }
        public static string Base64Decode(string base64EncodedData)
        {
            var base64EncodedBytes = System.Convert.FromBase64String(base64EncodedData);
            return System.Text.Encoding.UTF8.GetString(base64EncodedBytes);
        }
    }
}

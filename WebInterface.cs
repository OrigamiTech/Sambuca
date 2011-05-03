using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Net;

namespace Sambuca
{
    static class WebInterface
    {
        public static string SendPOST(Dictionary<string, string> parameters, string queryurl)
        {
            HttpWebRequest wr = (HttpWebRequest)System.Net.HttpWebRequest.Create(queryurl);
            wr.Method = "POST";
            wr.ContentType = "application/x-www-form-urlencoded";
            wr.KeepAlive = false;
            using(Stream requestStream = wr.GetRequestStream())
            {
                string requestString = "";
                bool first = true;
                foreach(KeyValuePair<string, string> kvp in parameters)
                {
                    requestString += (first ? "" : "&") + Uri.EscapeDataString(kvp.Key) + "=" + Uri.EscapeDataString(kvp.Value);
                    first = false;
                }
                byte[] requestData = Encoding.Default.GetBytes(requestString);
                requestStream.Write(requestData, 0, requestData.Length);
            }
            wr.ProtocolVersion = System.Net.HttpVersion.Version10;
            HttpWebResponse WebResp = (HttpWebResponse)wr.GetResponse();
            using(Stream Answer = WebResp.GetResponseStream())
            using(StreamReader _Answer = new StreamReader(Answer))
                return _Answer.ReadToEnd();
        }
        public static string SendGET(Dictionary<string, string> parameters, string queryurl)
        {
            string requestString = parameters.Count > 0 ? "?" : "";
            if(parameters.Count > 0)
            {
                bool first = true;
                foreach(KeyValuePair<string, string> kvp in parameters)
                {
                    requestString += (first ? "" : "&") + Uri.EscapeDataString(kvp.Key) + "=" + Uri.EscapeDataString(kvp.Value);
                    first = false;
                }
            }
            using(WebClient wc = new WebClient())
                return wc.DownloadString(queryurl + requestString);
        }
    }
}

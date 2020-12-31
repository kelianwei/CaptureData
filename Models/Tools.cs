using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CaptureData.Models
{
    public static class Tools
    {
        public static string ReadHttpStream(string url)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(new Uri(url));
            HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
            Stream respStream = resp.GetResponseStream();
            StreamReader respStreamReader = new StreamReader(respStream, Encoding.UTF8);
            char[] cbuffer = new char[256];
            int byteRead = respStreamReader.Read(cbuffer, 0, 256);
            StringBuilder strBuff = new StringBuilder();
            while (byteRead != 0)
            {
                string strResp = new string(cbuffer, 0, byteRead);
                strBuff.Append(strResp);
                byteRead = respStreamReader.Read(cbuffer, 0, 256);
            }
            respStreamReader.Close();
            respStream.Close();
            resp.Dispose();
            return strBuff.ToString();
        }

    }
}

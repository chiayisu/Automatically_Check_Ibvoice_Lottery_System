using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using System.IO;
using CY.Core.Const;

namespace CY.Core.Service
{
    public class WebService
    {
        #region Variable
        private HttpWebRequest _request;
        private HttpWebResponse _response;
        #endregion
        public WebService()
        {
            _request = null;
            _response = null;
        }

        public string getHTML(string url, Encoding encoding)
        {
            string html = "";
            if (IsWebOK(Request(url)))
            {
                if (checkStatus(_response))
                {
                    html = ReadHTML(_response, encoding);
                }
            }
            return html;
        }

        private int Request(string url)
        {
            try
            {
                _request = (HttpWebRequest)WebRequest.Create(url);
                _response = (HttpWebResponse)_request.GetResponse();
                return ReturnValue.WEBOK;
            }
            catch (WebException ex)
            {
                return ReturnValue.WEBERROR;
            }
        }

        private bool IsWebOK(int code)
        {
            if (code == ReturnValue.WEBOK)
                return true;
            return false;
        }

        private static bool checkStatus(HttpWebResponse webResponse)
        {
            if (webResponse.StatusCode == HttpStatusCode.OK)
                return true;
            return false;
        }

        private string ReadHTML(HttpWebResponse webResponse, Encoding encoding)
        {
            Stream receiveStream = webResponse.GetResponseStream();
            StreamReader readStream = null;
            string htmlData;
            readStream = new StreamReader(receiveStream, encoding);
            htmlData = readStream.ReadToEnd();
            receiveStream.Close();
            readStream.Close();
            return htmlData;
        }
    }
}

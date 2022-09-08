using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebApplicationVenta.Utilities
{
    public class ConsumeService
    {
        public static string ConsumirAPIConToken(Enums.Method method, string request, string BaseURL, string servicePrefix, string controller, string Token = "")
        {
            try
            {
                System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                string response;
                var ruta = string.Format("{0}{1}{2}", BaseURL, servicePrefix, controller);
                using (var client = new WebClient())
                {
                    client.Encoding = System.Text.Encoding.UTF8;

                    client.Headers[HttpRequestHeader.ContentType] = "application/json; charset=utf-8";

                    if (Token != "")
                    {
                        client.Headers[HttpRequestHeader.Authorization] = "Bearer " + Token;
                    }
                    if (method == Enums.Method.POST)
                    {
                        response = client.UploadString(ruta, method.ToString(), request);
                    }
                    else
                    {
                        response = client.DownloadString(ruta);
                    }

                    /// Y LA 'RETORNAMOS'
                    return response;
                }

            }
            catch (WebException ex)
            {
                var excepcion = (HttpWebResponse)ex.Response;
                
                return null;
            }
            catch
            {
                return null;
            }
        }

    }
}
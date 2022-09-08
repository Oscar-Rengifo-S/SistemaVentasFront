using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationVenta.Utilities
{
    public class ObtenerDatosService
    {
        string _UrlService = "https://dniruc.apisperu.com/";
        string _ServicePrefix = "api/v1/";
        string TokenAPI = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzI1NiJ9.eyJlbWFpbCI6Im9zY2FycmVuZ2lmb3NhbmNoZXpAZ21haWwuY29tIn0.sG0WTpFPhiWenbIkREHqqJDgcQyF5HvEjBYFZdJmyfM";

        public ResponseConsultaDNI ConsultaDNI(string dni)
        {
            ResponseConsultaDNI responseConsultaDNI = new ResponseConsultaDNI();

            try
            {
                var _response = ConsumeService.ConsumirAPIConToken(
                    Enums.Method.GET,
                    string.Empty,
                    _UrlService,
                    _ServicePrefix,
                    string.Format("dni/{0}?token={1}", dni, TokenAPI),
                    TokenAPI);
                if (_response != null)
                {
                    responseConsultaDNI = JsonConvert.DeserializeObject<ResponseConsultaDNI>(_response);
                }

            }
            catch
            {

            }
            return responseConsultaDNI;
        }

        public ResponseConsultaRuc ConsultaRuc(string ruc)
        {
            ResponseConsultaRuc response = new ResponseConsultaRuc();

            try
            {
                var _response = ConsumeService.ConsumirAPIConToken(
                    Enums.Method.GET,
                    string.Empty,
                    _UrlService,
                    _ServicePrefix,
                    string.Format("ruc/{0}?token={1}", ruc, TokenAPI),
                    TokenAPI);
                if (_response != null)
                {
                    response = JsonConvert.DeserializeObject<ResponseConsultaRuc>(_response);
                }

            }
            catch
            {

            }
            return response;
        }

    }
    public class ResponseConsultaDNI
    {
        public string dni { get; set; }
        public string nombres { get; set; }
        public string apellidoPaterno { get; set; }
        public string apellidoMaterno { get; set; }
        public string codVerifica { get; set; }
    }

    public class ResponseConsultaRuc
    {
        public string ruc { get; set; }
        public string razonSocial { get; set; }
        public string nombreComercial { get; set; }
        public string direccion { get; set; }
        public string departamento { get; set; }
        public string provincia { get; set; }
        public string distrito { get; set; }
    }
}
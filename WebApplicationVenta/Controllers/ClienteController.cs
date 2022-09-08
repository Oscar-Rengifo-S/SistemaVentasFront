using Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplicationVenta.Models.FLT;
using WebApplicationVenta.Utilities;

namespace WebApplicationVenta.Controllers
{
    public class ClienteController : Controller
    {
        private readonly static string _ServicePrefix = "api/";
        private readonly static string _UrlService = System.Configuration.ConfigurationManager.AppSettings["Service"].ToString();

        // GET: Cliente
        public ActionResult ClienteEmpresa()
        {
            return View();
        }

        public JsonResult GetListEmpresa()
        {
            List<ClienteFactura> apiResponse = new List<ClienteFactura>();

            try
            {
                var _response = ConsumeService.ConsumirAPIConToken(
                    Enums.Method.POST,
                    string.Empty,
                    _UrlService,
                    _ServicePrefix,
                    string.Format("Cliente/GetListClientesFactura"),
                    "");

                apiResponse = JsonConvert.DeserializeObject<List<ClienteFactura>>(
                               _response.ToString(),
                               new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            }
            catch (Exception ex)
            {
                apiResponse = null;
            }
            return Json(new
            {
                apiResponse
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult ObtenerDatosRuc(ObtenerDatosRucFlt request)
        {
            ResponseConsultaRuc apiResponse;

            try
            {
                ObtenerDatosService oObtenerDatosService = new ObtenerDatosService();

                apiResponse = oObtenerDatosService.ConsultaRuc(request.ruc);
            }
            catch (Exception ex)
            {
                apiResponse = null;
            }
            return Json(new
            {
                apiResponse
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult SaveClienteEmpresa(ClienteFactura saveEntity)
        {
            var apiResponse = "Ok";
            try
            {
                var request = JsonConvert.SerializeObject(saveEntity);

                var _response = ConsumeService.ConsumirAPIConToken(
                    Enums.Method.POST,
                    request,
                    _UrlService,
                    _ServicePrefix,
                    string.Format("Cliente/SaveClienteFactura"),
                    "");


            }
            catch (Exception ex)
            {
                apiResponse = "Error";
            }
            return Json(new
            {
                apiResponse
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteClienteFactura(ClienteFactura saveEntity)
        {
            var apiResponse = "Ok";
            try
            {
                var request = JsonConvert.SerializeObject(saveEntity);

                var _response = ConsumeService.ConsumirAPIConToken(
                    Enums.Method.POST,
                    request,
                    _UrlService,
                    _ServicePrefix,
                    string.Format("Cliente/DeleteClienteFactura"),
                    "");


            }
            catch (Exception ex)
            {
                apiResponse = "Error";
            }
            return Json(new
            {
                apiResponse
            }, JsonRequestBehavior.AllowGet);
        }


    }
}
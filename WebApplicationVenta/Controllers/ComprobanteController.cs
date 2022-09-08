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
    public class ComprobanteController : Controller
    {
        private readonly static string _ServicePrefix = "api/";
        private readonly static string _UrlService = System.Configuration.ConfigurationManager.AppSettings["Service"].ToString();

        // GET: Comprobante
        public ActionResult EmitirFactura()
        {
            return View();
        }

        public JsonResult SaveFactura(SaveFacturaFlt saveEntity)
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
                    string.Format("Comprobante/SaveFactura"),
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
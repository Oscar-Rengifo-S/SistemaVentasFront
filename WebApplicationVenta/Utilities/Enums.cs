using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplicationVenta.Utilities
{
    public class Enums
    {
        public enum Status
        {
            active = 1,
            inactive = 0
        }

        public enum Method
        {
            POST = 1,
            GET = 0
        }
        public enum Response
        {
            Ok = 1,
            Fail = 0

        }
    }
}
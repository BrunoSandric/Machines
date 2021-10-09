using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Machines.BL.Models
{
    public class ApiResponseModel
    {
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;

        public List<string> Errors { get; set; } = new List<string>();

        public object Payload { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Poizon.Domain.Enums;

namespace Poizon.Domain.Response
{
    public class ErrorResponse : IBaseResponse<string>
    {
        public string? Description { get; set; }
        public StatusCode StatusCode { get; set; }
        public string? Message { get; set; }
        public string Data { get; set; }
    }
}

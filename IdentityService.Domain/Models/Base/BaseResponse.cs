using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdentityService.Domain.Models.Base
{
    public class BaseResponse
    {
        public string Time { get; set; }
        public string Message { get; set; }
        public bool Status { get; set; }

        public BaseResponse()
        {
            Time = "01-01-1999";
            Message = "default";
            Status = false;
        }
    }
}

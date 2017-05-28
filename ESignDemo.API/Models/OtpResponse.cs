using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESignDemo.API.Models
{
    public class OtpResponse
    {
        public string REQUEST_NUMBER { get; set; }

        public string AADHAR_NUMBER { get; set; }

        public bool OTP_SENT { get; set; }

    }
}
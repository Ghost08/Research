using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESignDemo.API.Models
{
    public class ESignRequest
    {
        public string REQUEST_NUMBER { get; set; }

        public string AADHAR_NUMBER { get; set; }

        public string CLIENT_NAME { get; set; }     

        public string OTP { get; set; }

        public string DOCUMENT_ID { get; set; }



    }
}
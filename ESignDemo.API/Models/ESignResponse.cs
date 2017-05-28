using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESignDemo.API.Models
{
    public class ESignResponse
    {
        public string REQUEST_NUMBER { get; set; }

        public string AADHAR_NUMBER { get; set; }

        public string DOCUMENT_URL { get; set; }
    }
}
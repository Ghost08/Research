using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ESignDemo.API.Models
{
    public class DocumentResponse
    {
        public string DOCUMENT_ID { get; set; }
        public string DOCUMENT_NAME { get; set; }
        public bool IS_ACTIVE { get; set; }


    }
}
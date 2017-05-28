using ESignDemo.API.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Cryptography;
using System.Web;
using System.Web.Http;

namespace ESignDemo.API.Controllers
{
    public class DocumentController : ApiController
    {
        private string strFileDirectory = "~/FinalDocuments";

        [HttpPost]
        public HttpResponseMessage Upload()
        {
            Hashtable htApiResponse = new Hashtable();
            htApiResponse.Add("REQUEST_DATE", DateTime.Now);
            //Return Document response
            var files = HttpContext.Current.Request.Files;
            List<DocumentResponse> lstDocuments = new List<DocumentResponse>();
            if (files != null && files.Count > 0)
            {
                foreach (string sFile in files)
                {
                    HttpPostedFile rawfile = files[sFile];
                    byte[] pFile = null;
                    if (rawfile != null && rawfile.ContentLength > 0)
                    {
                        string strDocumentId = Guid.NewGuid().ToString();
                        string strFileName = string.Format("{0}.{1}", strDocumentId, Path.GetExtension(rawfile.FileName));
                        DocumentResponse objDocumentResponse = new DocumentResponse();
                        objDocumentResponse.DOCUMENT_ID = strDocumentId;
                        objDocumentResponse.DOCUMENT_NAME = Path.GetFileName(rawfile.FileName);

                        using (BinaryReader reader = new BinaryReader(rawfile.InputStream))
                        {
                            pFile = reader.ReadBytes(rawfile.ContentLength);
                        }

                        if (pFile != null && pFile.Length > 0)
                        {
                            string strRootDirectory = HttpContext.Current.Server.MapPath(strFileDirectory);
                            string strCurrentDirectory = Path.Combine(strRootDirectory, Guid.NewGuid().ToString());

                            if (!Directory.Exists(strCurrentDirectory))
                                Directory.CreateDirectory(strCurrentDirectory);

                            File.WriteAllBytes(Path.Combine(strCurrentDirectory, strFileName), pFile);
                            objDocumentResponse.IS_ACTIVE = true;

                            lstDocuments.Add(objDocumentResponse);
                        }
                    }
                }
            }


            if (lstDocuments != null && lstDocuments.Count > 0)
            {
                htApiResponse.Add("STATUS", "SUCCESS");
                htApiResponse.Add("DATA", lstDocuments);
            }
            else
            {
                htApiResponse.Add("STATUS", "ERROR");
                htApiResponse.Add("DATA", null);
            }


            return Request.CreateResponse(HttpStatusCode.OK, htApiResponse);
        }

        [HttpPost]
        public HttpResponseMessage IssueOtp(ESignRequest objEsignRequest)
        {
            //Return OTP response           
            Hashtable htApiResponse = new Hashtable();
            htApiResponse.Add("REQUEST_DATE", DateTime.Now);

            if (objEsignRequest != null)
            {
                RandomNumberGenerator rng = RandomNumberGenerator.Create();
                // define a byte array to fill with random data
                byte[] randomData = new byte[10];
                // generate random data
                rng.GetBytes(randomData);

                OtpResponse objOtpResponse = new OtpResponse();
                objOtpResponse.AADHAR_NUMBER = objEsignRequest.AADHAR_NUMBER;
                objOtpResponse.OTP_SENT = true;
                objOtpResponse.REQUEST_NUMBER = BitConverter.ToString(randomData);

                htApiResponse.Add("STATUS", "SUCCESS");
                htApiResponse.Add("DATA", objOtpResponse);

            }
            else
            {
                htApiResponse.Add("STATUS", "ERROR");
                htApiResponse.Add("DATA", null); 
            }


            return Request.CreateResponse(HttpStatusCode.OK, htApiResponse);

        }

        [HttpPost]
        public HttpResponseMessage Esign(ESignRequest objEsignRequest)
        {
            //Return ESIGN response
            Hashtable htApiResponse = new Hashtable();
            htApiResponse.Add("REQUEST_DATE", DateTime.Now);




            return Request.CreateResponse(HttpStatusCode.OK, htApiResponse);
        }
    }
}

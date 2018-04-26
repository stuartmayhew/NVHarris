using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Data.SqlClient;
using System.Configuration;
using System.Net.Mime;
using System.Net;
using System.Text;
using System.IO;
using NVHarris.Models;

namespace NVHarris
{
    public class MailHelper
    {
        const String HOST = "email-smtp.us-west-2.amazonaws.com";
        //clsDataGetter dg = new clsDataGetter(ConfigurationManager.ConnectionStrings["AutoDataContext"].ConnectionString);

        // Port we will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
        // STARTTLS to encrypt the connection.
        const int PORT = 587;

        private SmtpClient client = new SmtpClient(HOST, PORT);


        public bool SendContactEmail(Contact contact)
        {
            string toAddress = "vince@nvharris.com";
            string BCCAddress = "stumay111@gmail.com";
            client.Credentials = GetCredentials();
            client.EnableSsl = true;
            MailMessage mail = new MailMessage("noreply@nvharris.com", toAddress);
            mail.CC.Add(new MailAddress(contact.Email));
            mail.Bcc.Add(new MailAddress(BCCAddress));
            mail.Subject = "Contact from Website";
            mail.IsBodyHtml = true;
            mail.Body = BuildContactBody(contact);
            try
            {
                client.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private ICredentialsByHost GetCredentials()
        {
            string line;
            string path = HttpContext.Current.Server.MapPath("~/Upload/SES.txt");
            string username = "";
            string password = "";
            StringBuilder sb = new StringBuilder();

            using (StreamReader file = new StreamReader(path))
            {
                while ((line = file.ReadLine()) != null)
                {
                    string[] parts = line.Split(':');
                    if (parts[0] == "SMTP Username")
                        username = parts[1];
                    else if (parts[0] == "SMTP Password")
                        password = parts[1];

                }
            }
            return new System.Net.NetworkCredential(username, password);
        }

        public string BuildContactBody(Contact contact)
        {
            string fileURL = "http://nvharris.com/images/EmailBanner.jpg";
            string htmlBody = String.Format(@"<img src=""{0}"" />", fileURL);
            htmlBody += "<br/><h1>Thank you for contacting NVHarris and Associates<h1/>";
            htmlBody += "<br/>";
            htmlBody += "<h4>" + contact.ContactName + " requested information:<h4/>";
            htmlBody += "<pre><span style='font-family:Arial;font-size: 12pt;'>";
            htmlBody += contact.Message;
            htmlBody += "<span/><pre>";
            htmlBody += "<br/><br/><br/>";
            htmlBody += "Contact Email:" + contact.Email + "<br/>";
            htmlBody += "Contact Phone:" + contact.ContactPhone + "<br/>";
            return htmlBody;
        }
    }
}


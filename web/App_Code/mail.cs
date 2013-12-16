using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using docsoft.entities;
using linh.common;
using linh.core.dal;

public class BcyMail
{
    public delegate void SendEmailSingleDelegate(string email, string title, string body);
    void SendMailSingle(string email, string title, string body)
    {
        omail.Send(email, "NhatKyCon", title, body, "gigawebhome@gmail.com", "NhatKyCon", "25111987");
    }

    

    
}
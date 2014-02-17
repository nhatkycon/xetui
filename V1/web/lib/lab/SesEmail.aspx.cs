using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using linh.common;

public partial class lib_lab_SesEmail : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //SesSend("danhbaspa@gmail.com","Chào baby","Nhận được nhớ reply cho bố nhé", "xetui.vn@gmail.com");
        Send("danhbaspa@gmail.com", "Bố", "Chào bố già", "Nhận được thì khóc mẹ cho xong nhé", "xetui.vn@gmail.com",
             "Con giai");
    }

    public static void SesSend(string email, string title, string body, string fromEmail)
    {
        // Supply your SMTP credentials below. Note that your SMTP credentials are different from your AWS credentials.
        const String smtpUsername = "AKIAINTSEWVCFL5UA2MQ";  // Replace with your SMTP username. 
        const String smtpPassword = "AuwQb9Mbo72AaPuJMGi0ZBw7ozgxGPtwUei60NuueMWB";  // Replace with your SMTP password.

        // Amazon SES SMTP host name. This example uses the us-east-1 region.
        const String host = "email-smtp.eu-west-1.amazonaws.com";

        // Port we will connect to on the Amazon SES SMTP endpoint. We are choosing port 587 because we will use
        // STARTTLS to encrypt the connection.
        const int port = 587;

        // Create an SMTP client with the specified host name and port.
        using (var client = new System.Net.Mail.SmtpClient(host, port))
        {
            // Create a network credential with your SMTP user name and password.
            client.Credentials = new System.Net.NetworkCredential(smtpUsername, smtpPassword);

            // Use SSL when accessing Amazon SES. The SMTP session will begin on an unencrypted connection, and then 
            // the client will issue a STARTTLS command to upgrade to an encrypted connection using SSL.
            client.EnableSsl = true;

            // Send the email. 
            client.Send(fromEmail, email, title, body);

            try
            {
            }
            catch (Exception ex)
            {
                //Console.WriteLine("Error message: " + ex.Message);
            }
        }

    }
    public static void Send(string toEmail, string toTen, string subject, string body, string fromEmail, string fromName)
    {
        var fromAddress = new MailAddress(fromEmail, fromName);
        var toAddress = new MailAddress(toEmail, toTen);

        var smtp = new SmtpClient
        {
            Host = "email-smtp.eu-west-1.amazonaws.com",
            Port = 587,
            EnableSsl = true,
            DeliveryMethod = SmtpDeliveryMethod.Network,
            Credentials = new NetworkCredential("AKIAINTSEWVCFL5UA2MQ", "AuwQb9Mbo72AaPuJMGi0ZBw7ozgxGPtwUei60NuueMWB"),
            Timeout = 20000
        };
        using (var message = new MailMessage(fromAddress, toAddress)
        {
            Subject = subject,
            Body = body,
            BodyEncoding = System.Text.Encoding.UTF8,
            SubjectEncoding = System.Text.Encoding.UTF8,
            IsBodyHtml = true

        })
        {
            try
            {
                smtp.Send(message);
            }
            catch (SmtpException ex)
            {

            }
        }

    }
}
using System.Net;
using System.Net.Mail;

namespace BMS;

public class MailSender
{
    protected string _mailAddress;
    protected string _passwordMail;
    protected string _mailHostAddress;
    protected int _mailPort;

    private SmtpClient smtpClient;


    public MailSender(string mailAddress, string mailPassword, string mailHostAddress, int smtpPort = 587)
    {
        _mailAddress = mailAddress;
        _passwordMail = mailPassword;
        _mailHostAddress = mailHostAddress;
        _mailPort = smtpPort;
        smtpClient = new SmtpClient();
        smtpClient.Port = _mailPort;
        smtpClient.Host = _mailHostAddress;
        smtpClient.EnableSsl = false;
        smtpClient.Credentials = new NetworkCredential(_mailAddress, _passwordMail);
        smtpClient.UseDefaultCredentials = false;
        // smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;
    }

    public bool SendMail(string subject, string htmlMailTemplate, string destinationMailAddress)
    {
        try
        {
            MailMessage message = new MailMessage();
            message.From = new MailAddress(_mailAddress);
            message.To.Add(new MailAddress(destinationMailAddress));
            message.Subject = subject;
            message.IsBodyHtml = true;
            message.Body = htmlMailTemplate;
            smtpClient.Send(message);
            return true;
        }
        catch (Exception e)
        {
            Console.WriteLine("Mail send error: {0}", e);
            return false;
        }
    }
}


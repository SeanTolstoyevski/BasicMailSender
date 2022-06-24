# Basic Mail Sender For SMTP With C#

## Usage

```c#
// using drectives and add lib to your project;

class program
{
    static void Main()
    {

        var mailSender = new MailSender(senderMailAddress, senderMailPassword, senderSMTPHostAddress, SMTPPort = 587);
        // Port is default parameted.

        var sendSuccess = SendMail(string subject, string htmlMailTemplate, string destinationMailAddress);
        if(!sendSuccess)
        {
            Console.WriteLine("Mail sending is successfuly");
        }
        else
        {
            Console.WriteLine("Mail sending error");
        }

    } // Main block
    
} // class block
```
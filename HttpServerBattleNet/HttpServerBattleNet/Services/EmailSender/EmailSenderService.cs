using HttpServerBattleNet.Configuration;
using MailKit.Net.Smtp;
using MimeKit;
using Org.BouncyCastle.Ocsp;

namespace HttpServerBattleNet.Services;

public class EmailSenderService : IEmailSenderService
{
    private readonly AppSettingsConfig _config = ServerConfiguration.Config;

    public void SendEmail(string emailFromUser, string passwordFromUser, string subject)
    {
        try
        {
            using var emailSender = new MimeMessage();
            var builder = new BodyBuilder();

            emailSender.From.Add(new MailboxAddress(_config.FromName, _config.EmailSender));
            emailSender.To.Add(new MailboxAddress("",emailFromUser));
            emailSender.Subject = subject;
            
            var attachments = new List<MimeEntity>()
            {
                new MimePart()
                {
                    Content = new MimeContent(File.OpenRead("MyHttpProjectWithEmailSend.zip")),
                    ContentDisposition = new ContentDisposition(ContentDisposition.Attachment),
                    ContentTransferEncoding = ContentEncoding.Base64,
                    FileName = "MyHttpProjectWithEmailSend.zip"
                },
            };

            foreach (var mimeEntity in attachments)
                builder.Attachments.Add(mimeEntity);
            
            builder.HtmlBody =
                $"<h4>This your password and email | Email: {emailFromUser} | Password: {passwordFromUser}</h4>";
            emailSender.Body = builder.ToMessageBody();
            
            using var client = new SmtpClient(); 
            client.Connect(_config.SmtpServerHost, _config.SmtpServerPort, true);
            client.Authenticate(_config.EmailSender, _config.PasswordSender);
            client.Send(emailSender);
            client.Disconnect(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}
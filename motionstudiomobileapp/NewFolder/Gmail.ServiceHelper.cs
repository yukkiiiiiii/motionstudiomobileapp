using System;
using System.IO;
using System.Threading;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using MimeKit;

namespace motionstudiomobileapp.NewFolder
{
    public class GmailServiceHelper
    {
        private static readonly string[] Scopes = { GmailService.Scope.GmailSend };
        private static readonly string ApplicationName = "Motion Studio";
        private static readonly string CredentialsFilePath = "credentials.json"; // Path to your Google Cloud credentials file

        public static void SendMessage(string to, string subject, string body)
        {
            try
            {
                UserCredential credential;

                using (var stream = new FileStream(CredentialsFilePath, FileMode.Open, FileAccess.Read))
                {
                    string credPath = "token.json"; // Path to store the user's credentials after authorization

                    credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                        GoogleClientSecrets.Load(stream).Secrets,
                        Scopes,
                        "user",
                        CancellationToken.None,
                        new FileDataStore(credPath, true)).Result;
                }

                var service = new GmailService(new BaseClientService.Initializer()
                {
                    HttpClientInitializer = credential,
                    ApplicationName = ApplicationName,
                });

                var message = new MimeMessage();
                message.From.Add(new MailboxAddress("Your Name", "tristanmesina27@gmail.com")); // Change to your email address
                message.To.Add(new MailboxAddress("", to));
                message.Subject = subject;
                message.Body = new TextPart("plain")
                {
                    Text = body
                };

                var rawMessage = Convert.ToBase64String(System.Text.Encoding.UTF8.GetBytes(message.ToString()));
                var gmailMessage = new Message { Raw = rawMessage };

                service.Users.Messages.Send(gmailMessage, "me").Execute();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending email: {ex.Message}");
                // Handle the exception as needed (e.g., log, display error message)
            }
        }

        internal static void SendMessage(string senderEmail, string senderPassword, string toEmail, string subject, string body)
        {
            throw new NotImplementedException();
        }
    }
}

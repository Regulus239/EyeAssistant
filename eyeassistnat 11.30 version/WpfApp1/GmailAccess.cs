using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WpfApp1
{
    public class GmailAccess
    {
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "Gmail API .NET Quickstart";
        GmailService service;

        public GmailAccess()
        {
            UserCredential credential;

            using (var stream =
                new FileStream("C:\\Users\\jsnea\\Desktop\\ec601code\\credentials.json", FileMode.Open, FileAccess.Read))
            {
                // The file token.json stores the user's access and refresh tokens, and is created
                // automatically when the authorization flow completes for the first time.
                string credPath = "token.json";
                credential = GoogleWebAuthorizationBroker.AuthorizeAsync(
                    GoogleClientSecrets.Load(stream).Secrets,
                    Scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)).Result;
            }

            // Create Gmail API service.
            var service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            List<string> GetMessageList()
            {
                List<string> encodedMessages;
                List<Message> messageList = ListMessages(service, "me");

                foreach (var message in messageList)
                {
                    try
                    {
                        Console.WriteLine(message.Id);
                        string encodedString = service.Users.Messages.Get("me", message.Id);
                        encodedMessages.Add(encodedString);
                    }
                    catch { }

                }
            }

            List<Dictonary<string, string>> GetAndStoreMessageData(List<string> messageList)
            {// Function Needs more work
                foreach (var message in messageList)
                {
                    try
                    {
                        string encodedString = service.Users.Messages.Get("me", message.Id).Execute().Payload.Body.Data;
                        byte[] data = Convert.FromBase64String(encodedString);
                        string decodedString = Encoding.UTF8.GetString(data);
                        Console.WriteLine(decodedString);
                    }
                    catch { }
                }
            }



        }
    }
}


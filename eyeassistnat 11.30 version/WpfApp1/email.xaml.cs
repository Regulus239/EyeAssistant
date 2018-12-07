using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System.Diagnostics;
using System.IO;
using System.Threading;
using Tobii.Interaction;
using Tobii.Interaction.Wpf;


namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for email.xaml
    /// </summary>
    public partial class email : Window
    {
        int emailIndex;
        WpfApp1.GmailAccess gmail;
        bool HasGaze_Exit;
        List<Dictionary<string, string>> emailDictList;
        public email()
        {
            InitializeComponent();
            emailIndex = 0;
            gmail = new GmailAccess();
            emailDictList = gmail.emailDictList;
            Console.WriteLine(gmail.emailDictList.Count);
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            if (HasGaze_Exit)
            {
                HasGaze_Exit = false; // You're leaving the button.
            }
            else
            {
                HasGaze_Exit = true;        // You're entering the button.
                this.Close();
            }
        }

        private void Next_Email(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            if (HasGaze_Exit)
            {
                HasGaze_Exit = false; // You're leaving the button.
            }
            else
            {
                HasGaze_Exit = true;        // You're entering the button.
                emailIndex++;
                if (emailIndex > gmail.emailDictList.Count - 1) emailIndex = 0;
                subjectBox.Text = gmail.emailDictList[emailIndex]["Subject"];
                fromBox.Text = gmail.emailDictList[emailIndex]["From"];
                dateBox.Text = gmail.emailDictList[emailIndex]["Date"];
            }
        }

        private void Prev_Email(object sender, RoutedEventArgs e)
        {
            var grid = e.Source as Grid;
            if (null == grid) { return; } // if the named "EventSetter" Event from MainWindow.xaml is not called.
            if (HasGaze_Exit)
            {
                HasGaze_Exit = false; // You're leaving the button.
            }
            else
            {
                HasGaze_Exit = true;        // You're entering the button.
                emailIndex--;
                if (emailIndex < 0) emailIndex = gmail.emailDictList.Count - 1;
                subjectBox.Text = gmail.emailDictList[emailIndex]["Subject"];
                fromBox.Text = gmail.emailDictList[emailIndex]["From"];
                dateBox.Text = gmail.emailDictList[emailIndex]["Date"];
            }
        }
    }

    public partial class GmailAccess
    {
        static string[] Scopes = { GmailService.Scope.GmailReadonly };
        static string ApplicationName = "Gmail API .NET Quickstart";
        private GmailService service;
        public List<Dictionary<string, string>> emailDictList;
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
            service = new GmailService(new BaseClientService.Initializer()
            {
                HttpClientInitializer = credential,
                ApplicationName = ApplicationName,
            });

            
            List<Message> messageList = ListMessages(service, "me", "");

            Console.WriteLine(messageList.Count); // remove
            emailDictList = new List<Dictionary<string, string>>();

            foreach (var message in messageList)
            {
                
                try
                {
                    Console.WriteLine("In");
                    Dictionary<string, string> emailDict = new Dictionary<string, string>();
                    string encodedString = service.Users.Messages.Get("me", message.Id).Execute().Payload.Body.Data;
                    Console.WriteLine("Got Body");
                    byte[] data = Convert.FromBase64String(encodedString);
                    string decodedString = Encoding.UTF8.GetString(data);
                    emailDict.Add("Body", decodedString);
                    IList<MessagePartHeader> headers = service.Users.Messages.Get("me", message.Id).Execute().Payload.Headers;
                    Console.WriteLine("Got Headers");
                    Console.WriteLine(headers.Count);
                    foreach (var header in headers)
                    {
                        if (header.Name == "Date" || header.Name == "Subject" || header.Name == "From" || header.Name == "To")
                        {
                            Console.WriteLine("header.Name");
                            Console.WriteLine(header.Name);
                            Console.WriteLine("header.Value");
                            Console.WriteLine(header.Value);
                            emailDict.Add(header.Name, header.Value);
                        }
                    }
                    emailDictList.Add(emailDict);
                    Console.WriteLine("emailDictList count: ");
                    Console.WriteLine(emailDictList.Count);
                }
                catch
                {
                    Console.WriteLine("Error getting Email!"); // remove
                }
            }
        }

        public static List<Message> ListMessages(GmailService service, String userId, String query)
        {
            List<Message> result = new List<Message>();
            UsersResource.MessagesResource.ListRequest request = service.Users.Messages.List(userId);
            request.Q = query;

            do
            {
                try
                {
                    ListMessagesResponse response = request.Execute();
                    result.AddRange(response.Messages);
                    request.PageToken = response.NextPageToken;
                }
                catch (Exception e)
                {
                    Console.WriteLine("An error occurred: " + e.Message);
                }
            } while (!String.IsNullOrEmpty(request.PageToken));

            return result;
        }
    }
}


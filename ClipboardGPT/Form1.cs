using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Configuration;
using Org.BouncyCastle.Tls;  // To read from app.config or web.config for API keys

namespace ClipboardGPT
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); // This will call the auto-generated InitializeComponent from Form1.Designer.cs
        }

        // Event handler for the "Send to ChatGPT" context menu item
        private async void SendToChatGptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Get the clicked menu item
            var menuItem = sender as ToolStripMenuItem;

            // Get the clipboard content
            string clipboardContent = Clipboard.GetText();

            if (!string.IsNullOrEmpty(clipboardContent))
            {
                // Default prompt to send to ChatGPT
                string prompt = clipboardContent;

                // Modify the prompt based on which menu item was clicked
                if (menuItem == improveTextItem)
                {
                    prompt = "Improve this text: " + clipboardContent;
                }
                else if (menuItem == makeItFunnyItem)
                {
                    prompt = "Make this text funny: " + clipboardContent;
                }
                else if (menuItem == summarizeTextItem)
                {
                    prompt = "Summarize this text: " + clipboardContent;
                }
                else if (menuItem == translateTextItem)
                {
                    prompt = "Translate this text to Danish: " + clipboardContent;
                }
                else if (menuItem == formalizeToneItem)
                {
                    prompt = "Formalize this text: " + clipboardContent;
                }
                else if (menuItem == casualizeToneItem)
                {
                    prompt = "Casualize this text: " + clipboardContent;
                }

                // Show message about sending text to ChatGPT
                MessageBox.Show("Sending text to ChatGPT: " + clipboardContent);

                // Get the response from ChatGPT
                string response = await GetChatGptResponseAsync(prompt);

                // Replace clipboard content with the response
                Clipboard.SetText(response);

                // Show the response in a message box
                MessageBox.Show("ChatGPT Response: " + response);
            }
            else
            {
                MessageBox.Show("Clipboard is empty!");
            }
        }
        //hello
    

    // Async method to call the ChatGPT API using HttpClient
    private async Task<string> GetChatGptResponseAsync(string inputText)
        {
            string apiKey = "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";//GetApiKey();  // Secure API Key retrieval

            // Initialize HttpClient
            using (HttpClient client = new HttpClient())
            {
                // Set the Authorization header with your OpenAI API key
                client.DefaultRequestHeaders.Add("Authorization", "Bearer " + apiKey);

                // Create the data to send in the POST request
                var requestData = new
                {
                    model = "gpt-4o-mini",  // Using GPT-4 model, you can change it to gpt-3.5 if necessary
                    messages = new[] {
                        new { role = "user", content = inputText }  // Send user input as a message
                    }
                };

                // Convert requestData to JSON string//hello
                var content = new StringContent(JsonConvert.SerializeObject(requestData), Encoding.UTF8, "application/json");

                try
                {
                    // Send the POST request to the OpenAI API for chat completions
                    HttpResponseMessage response = await client.PostAsync("https://api.openai.com/v1/chat/completions", content);

                    // Check if the response is successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read the response content as a string
                        string responseContent = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response into a C# object
                        var result = JsonConvert.DeserializeObject<OpenAIResponse>(responseContent);

                        // Return the generated text from the AI response
                        return result.choices[0].message.content;
                    }
                    else
                    {
                        // Handle API error (non-successful status code)
                        return $"Error: {response.ReasonPhrase}";
                    }
                }
                catch (Exception ex)
                {
                    // Handle exception, log it, and return error message
                    return $"Exception: {ex.Message}";
                }
            }
        }

        // Method to get the API key securely from environment or app config
        private string GetApiKey()
        {
            // Optionally, you can store your API key in an environment variable or in a config file for security reasons
            string apiKey = Environment.GetEnvironmentVariable("OPENAI_API_KEY");

            if (string.IsNullOrEmpty(apiKey))
            {
                // If the environment variable is not set, try fetching it from the app.config
                apiKey = ConfigurationManager.AppSettings["OpenAIApiKey"];
            }

            if (string.IsNullOrEmpty(apiKey))
            {
                MessageBox.Show("API Key not found!");
            }

            return apiKey;
        }
    }// hello

    // Define a class to map the response data from OpenAI
    public class OpenAIResponse
    {
        public Choice[] choices { get; set; }
    }

    // Define a class to represent each choice in the response
    public class Choice
    {
        public Message message { get; set; }
    }

    // Define a class to represent the message object in the response
    public class Message
    {
        public string content { get; set; }
    }
}

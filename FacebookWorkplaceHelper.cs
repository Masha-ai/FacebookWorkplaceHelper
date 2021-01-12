using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
namespace Masha.AI.Helpers
{
    /// <summary>
    /// Create by the Masha.ai team (eCommerce Tools)
    /// </summary>
    static public class FacebookWorkplaceHelper
    {
        private static readonly HttpClient client = new HttpClient();
        /// <summary>
        /// Send a message to a group inside Facebook Workplace
        /// </summary>
        /// <param name="group">a group name</param>
        /// <param name="message">the messsage to send</param>
        /// <param name="link">[Optional] the link to add to the message (will create a preview inside Facebook Workplace</param>
        /// <param name="formatting">[Optional] plaintext or markdown</param>
        /// <returns>Return the responsestring from Facebook Workplace</returns>
        public static async Task<string> SendMessage(string group, string message, string link ="", string formatting = "plaintext")
        {
            string _accessToken = "";
            switch (group.ToLower())
            {
                //--- Add the the diffrent group wit a link to the accesstoken
                //--- Don't place the access token as parameter of the SendMessage => For maintenance raisons
                //--- Group Name is a name you give to distingues where to post the message
                case "general":
                    _accessToken = "DQVJ1b2...";
                    break;
                case "customerservice":
                    _accessToken = "DQVJ0b2...";
                    break;
                case "sales":
                    _accessToken = "DQVJ0...";
                    break;
            }
            var responseString = "";
            if (!string.IsNullOrEmpty(_accessToken))
            {

                var values = new Dictionary<string, string>
                {
                    { "message", message },
                    { "link", link },
                    { "formatting", formatting.ToUpper() },
                };

                var content = new FormUrlEncodedContent(values);

                var response = await client.PostAsync("https://graph.workplace.com/v3.0/group/feed?access_token=" + _accessToken, content);

                responseString = await response.Content.ReadAsStringAsync();
            }
            return responseString;
        }
    }
}

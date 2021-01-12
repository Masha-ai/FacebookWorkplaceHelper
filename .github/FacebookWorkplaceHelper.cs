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
                    _accessToken = "DQVJ1b2p4LTFSMEx3S282dzZAncFB6UUlTYVowRUJ0NnFrcGdjZAkc0R3R4UVNXWFc3UkFGaDNfRWNseU82aXZAkX3EwSkx6bXpycjhTSC0xeG9CbTBfR2VodVpZAT1I4NldETnZAQa0g2N0ZAqSWJHNG01OHl2MzdsS3lOS0tuUWJRS3J4eTF3cDJ0LXplSzRSSUdBQi1TVmlWN2dVRzZAYTkpuYkt6d2tvNE90eFl4STlzSkkwbUNHVUFZAd1BsaE1UYjcxaU1EZAVZA0ZAy16b1NYRzM4UQZDZD";
                    break;
                case "customerservice":
                    _accessToken = "DQVJ0b2JScVlNa3FzazZAhU1FJYTR3ZA1lxdzZApend1ODRYc3R4ODMxMTN4a2ZA2SG9tOWJRbGVqUnBuNzZAHWEVLQ3hMSmtlaXhvdHdWV2dVRUwwYUFicTlRVTR4aHRuUGV3Q3A4Qkd1UFpHT3NFREFVTnBoMUM1UG1DNTIwNmpGMWR2cGtuZAldHaXoya25MeHhLLU1uOXp6SnJVbEpkcThmY3RIdjVSbHZAxYlB3RXloTWxlbER0YXhPUU5hY3ZAYNHNTUEx5S29B";
                    break;
                case "sales":
                    _accessToken = "DQVJ0X1Rlc29xVHQ3SFR6MmNIYlh1ZAV90cVpYYlNlWVdPR3JmUU5BSk9LSE1LQXpybmgwVEVJX2VBdDBGTml3V09RZAE5IS1NwLXduOXk0a1pVRDE0TG01YXRGd01ZASGN0MURxVmRYc2d4eWZAhOGxBS2NFTnhValJwSHNIMUVUbjEyMVUxV3RzWURhZAUp6aWhzM3hOekxhRjYxRU1zdzRsdVBTclF4bkZAjZAUxXNHFxSUdkVDlfYy1GcHVRbVZAwSWJIZAFlZAdFF3";
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

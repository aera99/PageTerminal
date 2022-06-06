using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PageTerminal.Models
{
    public class ConnectionToVendista
    {
        private string login;
        private string password;
        private string token;

        public ConnectionToVendista(string login , string password)
        {
            this.login = login;
            this.password = password;
            GetNewToken();
        }

        private void GetNewToken()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://178.57.218.210:198/token?login={login}&password={password}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
                var json = JObject.Parse(result);

                var tokenJS = json["token"];
                token = tokenJS.ToString();
            }
        }

        public CommandType GetCommandsTypes()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://178.57.218.210:198/commands/types?PageNumber=1&OrderDesc=true&token={token}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                if (!string.IsNullOrEmpty(result))
                {
                    var commands = JsonConvert.DeserializeObject<CommandType>(result);
                    return commands;
                }
                return null;
            }
        }

        public HistoryCommands GetHistoryCommands(int idTerminal)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://178.57.218.210:198/terminals/{idTerminal}/commands?ShowQrCommands=false&PageNumber=1&OrderByColumn=1&OrderDesc=true&token={token}");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (var streamReader = new StreamReader(response.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();

                if (!string.IsNullOrEmpty(result))
                {
                    var commands = JsonConvert.DeserializeObject<HistoryCommands>(result);
                    return commands;
                }
                return null;
            }
        }

        public void SendCommand(int idTerminal , Command command)
        {
            try
            {
                string json = JsonConvert.SerializeObject(command);
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"http://178.57.218.210:198/terminals/{idTerminal}/commands?token={token}");
                request.Method = "POST";
                request.ContentType = "application/json";

                using (var requestStream = request.GetRequestStream())
                using (var writer = new StreamWriter(requestStream))
                {
                    writer.Write(json);
                }

                using (var httpResponse = request.GetResponse())
                using (var responseStream = httpResponse.GetResponseStream())
                using (var reader = new StreamReader(responseStream))
                {
                    string response = reader.ReadToEnd();
                }
            }
            catch (Exception)
            {
                return;
            }
        }
    }
}

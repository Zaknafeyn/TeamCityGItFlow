using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RabbitMQMngmt.DTO;

namespace RabbitMQMngmt
{
    public class RabbitMqAccess
    {
        private const string ApiPort = "15672";

        private List<string> SystemExchanges = new List<string>
        {
            "amq.direct",
            "amq.fanout",
            "amq.headers",
            "amq.match",
            "amq.rabbitmq.trace",
            "amq.topic"
        };

        private string _username, _password, _host;
        public RabbitMqAccess()
        {
            _username = ConfigurationManager.AppSettings["RabbitMQ:UserName"];
            _password = ConfigurationManager.AppSettings["RabbitMQ:Password"];
            _host = ConfigurationManager.AppSettings["RabbitMQ:DefaultHost"];

        }

        public List<string> GetVHosts()
        {
            var uri = string.Format("{0}/vhosts", GetBaseUriString());

            var hosts = GetRmqItems<HostItem>(uri);

            return hosts.Select(x => x.Name).ToList();
        }

        public List<QueueItem> GetQueues(string vhost)
        {
            var normalyzedVHost = NormalyzeVHost(vhost);
            var uri = string.Format("{0}/queues/{1}", GetBaseUriString(), normalyzedVHost);
            var queues = GetRmqItems<QueueItem>(uri);
            return queues.ToList();
        }

        public List<ExchangeItem> GetExchanges(string vhost)
        {
            var normalyzedVHost = NormalyzeVHost(vhost);
            var uri = string.Format("{0}/exchanges/{1}", GetBaseUriString(), normalyzedVHost);
            var exchanges = GetRmqItems<ExchangeItem>(uri);
            var resultExchanges = new List<ExchangeItem>();
            foreach (var exchangeItem in exchanges)
            {
                if (!SystemExchanges.Contains(exchangeItem.Name) && !string.IsNullOrEmpty(exchangeItem.Name))
                {
                    resultExchanges.Add(exchangeItem);
                }
            }

            return resultExchanges.ToList();
            
        }

        public string GetNodeHost()
        {
            return string.Format("http://{0}:{1}@{2}:{3}/api", _username, _password, _host, ApiPort);
        }

        public void DeleteQueue(string vhost, string queueName)
        {
            var normalyzedVHost = NormalyzeVHost(vhost);
            var uri = string.Format("{0}/queues/{1}/{2}", GetBaseUriString(), normalyzedVHost, queueName);
            DeleteRmqResponse(uri);
        }

        public void DeleteExchange(string vhost, string exchageName)
        {
            var normalyzedVHost = NormalyzeVHost(vhost);
            var uri = string.Format("{0}/exchanges/{1}/{2}", GetBaseUriString(), normalyzedVHost, exchageName);
            DeleteRmqResponse(uri);
        }

        public void DeleteVhost(string vhost)
        {
            var normalyzedVHost = NormalyzeVHost(vhost);
            var uri = string.Format("{0}/vhosts/{1}", GetBaseUriString(), normalyzedVHost);
            DeleteRmqResponse(uri);
        }

        private string GetBaseUriString()
        {
            return string.Format("http://{0}:{1}@{2}:{3}/api", _username, _password, _host, ApiPort);
        }

        private List<T> GetRmqItems<T>(string uri) where T : class
        {
            var response = GetRmqResponse(uri);
            var items = JsonConvert.DeserializeObject<List<T>>(response);
            return items;
        }

        private string GetRmqResponse(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Credentials = new NetworkCredential(_username, _password);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream stream = response.GetResponseStream();
            StreamReader streamreader = new StreamReader(stream);

            string s = streamreader.ReadToEnd();
            return s;
        }

        private void DeleteRmqResponse(string uri)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "DELETE";
            request.Credentials = new NetworkCredential(_username, _password);

            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
        }

        private string NormalyzeVHost(string vhost)
        {
            return (vhost == "/") ? "%2f" : vhost;
        }
    }
}

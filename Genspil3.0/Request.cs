using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Genspil3._0
{
    public class Request
    {
        private string nameRequest;
        private string emailRequest;
        private string phoneRequest;
        private string titleRequest;
        private string versionRequest;
        private char conditionRequest;

        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Title { get; set; }
        public string Version { get; set; }
        public char Condition { get; set; }
        public string V1 { get; }
        public string V2 { get; }
        public string V3 { get; }
        public string V4 { get; }
        public string V5 { get; }
        public char V6 { get; }

        public static List<Request> requests = new List<Request>();

        private const string filePath = "requests.txt";

        public Request(string v1, string v2, string v3, string v4, string v5, char v6)
        {
            V1 = v1;
            V2 = v2;
            V3 = v3;
            V4 = v4;
            V5 = v5;
            V6 = v6;
        }

        public Request()
        {
        }

        public static void InitializedPredefinedRequests()
        {
            // Example initialization logic    
            requests.Add(new Request { Name = "John Doe", Email = "john@example.com", Title = "Request 1", Version = "1.0", Condition = 'A' });
            requests.Add(new Request { Name = "Jane Smith", Email = "jane@example.com", Title = "Request 2", Version = "2.0", Condition = 'B' });
        }

        public bool AddRequest(List<Request> listRequests)
        {
            listRequests.Add(this);
            return true;
        }

        public static List<Request> GetRequests()
        {
            return requests;
        }

        public static List<Request> GetAllRequests()
        {
            return GetRequests();
        }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Title} - {Version} - {Condition}";
        }

        public static void SaveRequestsToFile()
        {
            // File saving logic    
        }

        public static void LoadRequestsFromFile()
        {
            // File loading logic    
        }

        public bool MatchesCriteria(string criteria)
        {
            return Name.Contains(criteria) || Email.Contains(criteria) || Title.Contains(criteria);
        }

        public static List<Request> SearchRequest(string name, string phone)
        {
            throw new NotImplementedException();
        }

        public static List<Request> SearchRequest()
        {
            throw new NotImplementedException();
        }
    }
}
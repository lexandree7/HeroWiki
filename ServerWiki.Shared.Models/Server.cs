using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerWiki_Console
{
    public class Server
    {
        public Server() { }

        public Server(string name, string teste)
        {
            Name = name;
            OS = "";
        }

        public string Name { get; set; }
        public string OS { get; set; }
        public int Id { get; set; }

        public List<Application> applications = new List<Application>();

        public void AddApplications(Application application)
        {
            applications.Add(application);
        }

        public void ShowApplications()
        {
            Console.WriteLine($"Aplicações de {Name}:");
            foreach (var application in applications)
            {
                Console.WriteLine(application);
            }
        }

        public override string ToString()
        {
            return $@"Nome: {Name}";
        }

    }
}
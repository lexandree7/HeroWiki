using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerWiki_Console
{
    public class Server
    {
        public Server(string name, string os)
        {
            Name = name;
            Os = os;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Os { get; set; }

        public virtual ICollection<Application> Applications { get; set; } = new List<Application>();

        public void AddApplications(Application application)
        {
            Applications.Add(application);
        }

        public void ShowApplications()
        {
            Console.WriteLine($"Aplicacoes de {Name}:");
            foreach (var application in Applications)
            {
                Console.WriteLine(application);
            }
        }

        public override string ToString()
        {
            return $@"Id: {Id} - Nome: {Name}";
        }

    }
}
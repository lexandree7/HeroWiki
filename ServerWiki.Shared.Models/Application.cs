using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerWiki_Console
{
    public class Application
    {
        public Application(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public string Protocol { get; set; }
        public int Port { get; set; }

        public override string ToString()
        {
            return $@"Application: {Name}";
        }
    }
}
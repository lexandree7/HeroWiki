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
            //Description = "";
        }

        public int Id { get; set; }
        public string Name { get; set; }
        //Processo de alteração de tabelas por Migrations 
        //public string Description { get; set; }
        public int Port { get; set; }

        public virtual Server? Server { get; set; }

        public override string ToString()
        {
            return $@"Aplicacao: {Name}";
        }
    }
}
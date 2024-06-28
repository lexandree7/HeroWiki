using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using ServerWiki_Console;


namespace ServerWiki.Shared.Data.DB
{
    public class ServerWikiContext : DbContext
    {
        public DbSet<Server> Server { get; set; }

        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ServerWiki_DB;Integrated Security=True;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);
        }

        public SqlConnection Connect()
        {
            return new SqlConnection(connectionString);
        }

        
    }
}

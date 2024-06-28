using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using ServerWiki_Console;

namespace ServerWiki.Shared.Data.DB
{
    public class ServerDAL
    {
        private readonly ServerWikiContext context;

        public ServerDAL(ServerWikiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Server> Read()
        {
            return context.Server.ToList();
        }

        public void create(Server server)
        {
            context.Server.Add(server);
            context.SaveChanges();
        }

        public void update(Server server)
        {
            context.Server.Update(server);
            context.SaveChanges();
        }
        public void delete(Server server)
        {
            context.Server.Remove(server);
            context.SaveChanges();
        }

        public Server? ReadByName(string name)
        {
            return context.Server.FirstOrDefault(x => x.Name == name);
        }

        ////public void Create(Server server)
        ////{
        ////    using var connection = new ServerWikiContext().Connect();
        ////    connection.Open();

        ////    string sql = "INSERT INTO Server (Name, OS) VALUES (@name, @os)";
        ////    SqlCommand cmd = new SqlCommand(sql, connection);
        ////    cmd.Parameters.AddWithValue("@name", server.Name);
        ////    cmd.Parameters.AddWithValue("@os", server.OS);
        ////    int retorno = cmd.ExecuteNonQuery();
        ////    Console.WriteLine($"Linhas afetadas:  {retorno}");
        ////}

        ////public void Update(Server server, int id)
        ////{
        ////    using var connection = new ServerWikiContext().Connect();
        ////    connection.Open();

        ////    string sql = $"UPDATE Server SET Name = @name, OS = @os WHERE Id = @id";
        ////    SqlCommand cmd = new SqlCommand(sql, connection);
        ////    cmd.Parameters.AddWithValue("@name", server.Name);
        ////    cmd.Parameters.AddWithValue("@os", server.OS);
        ////    cmd.Parameters.AddWithValue("@id", id);
        ////    int retorno = cmd.ExecuteNonQuery();
        ////    Console.WriteLine($"Linhas afetadas:  {retorno}");

        ////}

        ////public void Delete(int id)
        ////{
        ////    using var connection = new ServerWikiContext().Connect();
        ////    connection.Open();

        ////    string sql = $"DELETE FROM Server WHERE Id = @id";
        ////    SqlCommand cmd = new SqlCommand(sql, connection);
        ////    cmd.Parameters.AddWithValue("@id", id);
        ////    int retorno = cmd.ExecuteNonQuery();
        ////    Console.WriteLine($"Linhas afetadas:  {retorno}");

        ////}

    

    }
}

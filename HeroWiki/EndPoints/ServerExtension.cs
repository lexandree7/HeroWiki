using ServerWiki.Requests;
using ServerWiki.Responses;
using ServerWiki.Shared.Data.DB;
using ServerWiki_Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ServerWiki.Shared.Data.DB;

namespace ServerWiki.EndPoints
{
    public static class ServerExtension
    {
        public static void AddEndPointsServer(this WebApplication app)
        {
            app.MapGet("/Servers", ([FromServices] DAL<Server> dal) =>
            {
                var serverList = dal.Read();
                if (serverList is null) return Results.NotFound();
                var serverResponseList = EntityListToResponseList(serverList);
                return Results.Ok(serverResponseList);
            });

            app.MapPost("/Servers", ([FromServices] DAL<Server> dal, [FromBody] ServerRequest serverRequest) =>
            {
                dal.create(new Server(serverRequest.name, serverRequest.os));
                return Results.Ok();
            });

            app.MapDelete("/Servers/{id}", ([FromServices] DAL<Server> dal, int id) =>
            {
                var server = dal.ReadBy(a => a.Id == id);
                if (server is null) return Results.NotFound();
                dal.delete(server);
                return Results.NoContent();
            });

            app.MapPut("/Servers", ([FromServices] DAL<Server> dal, [FromBody] ServerEditRequest serverRequest) =>
            {
                var serverToEdit = dal.ReadBy(a => a.Id == serverRequest.id);
                if (serverToEdit is null) return Results.NotFound();
                serverToEdit.Name = serverRequest.name;
                serverToEdit.Os = serverRequest.os;
                dal.update(serverToEdit);
                return Results.Ok();
            });

            app.MapGet("/Servers{id}", ([FromServices] DAL<Server> dal, int id) =>
            {
                var server = dal.ReadBy(a => a.Id == id);
                if (server is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(server));
            });

        }
        private static ICollection<ServerResponse> EntityListToResponseList(IEnumerable<Server> serverList)
        {
            return serverList.Select(a => EntityToResponse(a)).ToList();
        }

        private static ServerResponse EntityToResponse(Server server)
        {
            return new ServerResponse(server.Id, server.Name, server.Os);
        }

    }
}
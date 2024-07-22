using ServerWiki.Requests;
using ServerWiki.Responses;
using ServerWiki.Shared.Data.DB;
using ServerWiki_Console;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.SqlServer.Query.Internal;
using ServerWiki.Shared.Data.DB;

namespace ServerWiki.EndPoints
{
    public static class PowerExtension
    {
        public static void AddEndPointsApplication(this WebApplication app)
        {

            app.MapGet("/Application", ([FromServices] DAL<Application> dal) =>
            {
                var applicationList = dal.Read();
                if (applicationList is null) return Results.NotFound();
                var applicationResponseList = EntityListToResponseList(applicationList);
                return Results.Ok(applicationResponseList);
            });

            app.MapPost("/Application", ([FromServices] DAL<Application> dal, [FromBody] ApplicationRequest applicationRequest) =>
            {
                dal.create(new Application(applicationRequest.name));
                return Results.Ok();
            });

            app.MapDelete("/Application/{id}", ([FromServices] DAL<Application> dal, int id) =>
            {
                var application = dal.ReadBy(a => a.Id == id);
                if (application is null) return Results.NotFound();
                dal.delete(application);
                return Results.NoContent();
            });

            app.MapPut("/Application", ([FromServices] DAL<Application> dal, [FromBody] ApplicationEditRequest applicationRequest) =>
            {
                var applicationToEdit = dal.ReadBy(a => a.Id == applicationRequest.id);
                if (applicationToEdit is null) return Results.NotFound();
                applicationToEdit.Name = applicationRequest.name;
                dal.update(applicationToEdit);
                return Results.Ok();
            });

            app.MapGet("/Application{id}", ([FromServices] DAL<Application> dal, int id) =>
            {
                var application = dal.ReadBy(a => a.Id == id);
                if (application is null) return Results.NotFound();
                return Results.Ok(EntityToResponse(application));
            });

        }

        private static ICollection<ApplicationResponse> EntityListToResponseList(IEnumerable<Application> applicationList)
        {
            return applicationList.Select(a => EntityToResponse(a)).ToList();
        }
        private static ApplicationResponse EntityToResponse(Application application)
        {
            return new ApplicationResponse(
                application.Id,
                application.Name ?? string.Empty,
                application.Server?.Id ?? 0,
                application.Server?.Name ?? "No linked server");
        }
    }
}
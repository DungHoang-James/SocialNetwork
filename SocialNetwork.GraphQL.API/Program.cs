using GraphQL;
using GraphQL.DataLoader;
using Microsoft.EntityFrameworkCore;
using SocialNetwork.GraphQL.API.DatabaseContext;
using SocialNetwork.GraphQL.API.GraphQL.Schemas;
using SocialNetwork.GraphQL.API.Repositories;

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("sqlsv");

builder.Services.AddDbContext<SocialNetworkDbContext>(
    option => option.UseSqlServer(connectionString)
);

builder.Services.AddScoped<IMemberRepository, MemberRepository>();
builder.Services.AddScoped<IPostRepository, PostRepository>();

builder.Services.AddGraphQL(option =>
{
    option.AddSelfActivatingSchema<MemberSchema>(GraphQL.DI.ServiceLifetime.Scoped);
    option.AddSystemTextJson();
    option.AddDataLoader();
});

var app = builder.Build();

app.UseGraphQL();
app.UseGraphQLPlayground(path: "/");

app.Run();

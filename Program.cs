using HotChocolate.AspNetCore;
using HotChocolateSocketRepro;

var builder = WebApplication.CreateBuilder(args);

// Comment out this line to reproduce CPU hang.
builder.Services.AddHostedService<Publisher>();

builder.Services.AddGraphQLServer()
    .AddQueryType<PlaceholderQuery>()
    .AddSubscriptionType<Subscription>()
    .AddInMemorySubscriptions()
    .InitializeOnStartup();

var app = builder.Build();

app.UseWebSockets();
app.MapGraphQL().WithOptions(new GraphQLServerOptions
{
    Sockets = {KeepAliveInterval = TimeSpan.FromSeconds(5)}
});

app.Run();
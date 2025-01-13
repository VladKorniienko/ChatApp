var builder = DistributedApplication.CreateBuilder(args);

var cache = builder.AddRedis("cache");

var sql = builder.AddSqlServer("chatApp")
                 .WithDataVolume();

var db = sql.AddDatabase("chatDatabase");

var apiService = builder.AddProject<Projects.ChatAppAspire_ApiService>("apiservice")
    .WithReference(db)
    .WaitFor(db);

builder.AddProject<Projects.ChatAppAspire_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WaitFor(cache)
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

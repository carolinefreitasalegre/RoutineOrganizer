var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.OrganizadorRotinaMae_Client_ApiService>("apiservice")
    .WithHttpHealthCheck("/health");

builder.AddProject<Projects.OrganizadorRotinaMae_Client_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithHttpHealthCheck("/health")
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();

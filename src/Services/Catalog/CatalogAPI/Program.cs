var builder = WebApplication.CreateBuilder(args);

//Add the services to the container

var app = builder.Build();

//Configure the HTTP request pipeline

app.Run();

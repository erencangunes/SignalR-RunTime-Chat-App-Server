using Microsoft.AspNetCore.SignalR;
using SignalRChatServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Cors politikatý
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
                                                                policy.AllowAnyMethod()
                                                                .AllowAnyHeader()
                                                                .AllowCredentials()
                                                                .SetIsOriginAllowed(origin => true)
));

// SignalR kütüphanesini yükledik
builder.Services.AddSignalR();


var app = builder.Build();

app.UseCors();

// chathub endpoint'imizi ekledim
app.MapHub<ChatHub>("/chathub");

app.Run();

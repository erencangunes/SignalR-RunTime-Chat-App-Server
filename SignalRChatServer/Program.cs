using Microsoft.AspNetCore.SignalR;
using SignalRChatServer.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Cors politikat�
builder.Services.AddCors(options => options.AddDefaultPolicy(policy =>
                                                                policy.AllowAnyMethod()
                                                                .AllowAnyHeader()
                                                                .AllowCredentials()
                                                                .SetIsOriginAllowed(origin => true)
));

// SignalR k�t�phanesini y�kledik
builder.Services.AddSignalR();


var app = builder.Build();

app.UseCors();

// chathub endpoint'imizi ekledim
app.MapHub<ChatHub>("/chathub");

app.Run();

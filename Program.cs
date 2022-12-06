// Application Setup
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Developer debug
if (app.Environment.IsDevelopment())
{
    // Debug WS:    ws://localhost:5034/realtime
    // Debug WSS:   wss://localhost:7078/realtime
}

// Web Socket Configuration
var webSocketOptions = new WebSocketOptions
{
    KeepAliveInterval = TimeSpan.FromMinutes(2)
};
app.UseWebSockets(webSocketOptions);

// Configuration
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// Initialization
app.Run();

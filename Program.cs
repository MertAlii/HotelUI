builder.Services.AddHttpClient("Api", client =>
{
    client.BaseAddress = new Uri("https://localhost:7020/api/");
    client.Timeout = TimeSpan.FromSeconds(30);
});
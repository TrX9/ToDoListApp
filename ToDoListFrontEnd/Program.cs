var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

// Configure HttpClient for API calls
builder.Services.AddHttpClient("ToDoApi", client =>
{
    client.BaseAddress = new Uri("https://localhost:7257/api/"); // Update Web API URL
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapGet("/", context =>
{
    context.Response.Redirect("/ToDoItems");
    return Task.CompletedTask;
});

app.Run();

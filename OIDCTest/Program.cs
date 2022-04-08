var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient();
builder.Services.AddControllersWithViews();

/********Connect to Line Login API*********/
builder.Services
    .AddAuthentication(options =>
    {
        options.DefaultScheme = "Cookies";
        options.DefaultChallengeScheme = "Line";
    })
    .AddCookie("Cookies")
    .AddOpenIdConnect("Line", options =>
    {
        options.Authority = "https://access.line.me";
        options.ClientId = "{ClientId}";
        options.ClientSecret = "{ClientSecret}";
        options.CallbackPath = new PathString("/logincallback");
        options.SaveTokens = true;
        options.ResponseType = "code";
        options.GetClaimsFromUserInfoEndpoint = true;
    });
/******************************************/


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();
app.UseAuthorization();

app.MapRazorPages();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


app.Run();

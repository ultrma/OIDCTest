# OIDCTest
以下就是利用OpenIdConnect套件來連接Line Login API

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

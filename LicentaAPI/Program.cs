using Licenta.BLL.BussinesLogic.Implementation;
using Licenta.BLL.BussinesLogic.Interfaces;
using Licenta.BLL.Utils.EmailSender;
using Licenta.BLL.Utils.EmailSender.Interface;
using Licenta.BLL.Utils.EmailSender.Settings;
using Licenta.BLL.Utils.EmailSender.Template;
using Licenta.BLL.Utils.Middlewares;
using Licenta.BLL.Utils.StorePhotoLogic;
using Licenta.BLL.Utils.StorePhotoLogic.Settings;
using Licenta.BLL.Utils.Token;
using Licenta.BLL.Utils.Token.Interface;
using Licenta.DAL.Interfaces;
using Licenta.DAL.Stores;
using Licenta.DAL.Utils.ConnectionSettings;
using Licenta.DAL.Utils.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using System.Text;

var builder = WebApplication.CreateBuilder(args);
var jwtSettings = builder.Configuration.GetSection("JWTSettings");
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();


builder.Services.Configure<ContextSettings>(options =>
{
    options.ConnectionString = builder.Configuration["MongoDB:ConnectionString"];
    options.DatabaseName = builder.Configuration["MongoDB:DatabaseName"];
});
builder.Services.Configure<EmailSettings>(options =>
{
    options.Token = builder.Configuration["EmailToken:token"];
});
builder.Services.Configure<from>(options =>
{
    options.Email = builder.Configuration["from:email"];
    options.Name = builder.Configuration["from:name"];
});
builder.Services.Configure<PhotoRoutingSettings>(options =>
{
    options.SavePathOwner = builder.Configuration["Path:savePageOwner"];
    options.RetrievePathOwner = builder.Configuration["Path:retrievePageOwner"];
    options.SavePathTrainer = builder.Configuration["Path:savePageTrainer"];
    options.RetrievePathTrainer = builder.Configuration["Path:retrievePageTrainer"];
    options.SaveUserProfileImage = builder.Configuration["Path:saveUserProfileImage"];
    options.RetrieveUserProfileImage = builder.Configuration["Path:retrieveUserProfileImage"];
    options.URL = builder.Configuration["Path:URL"];
});
builder.Services.AddSingleton<Context>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IOwnerService, OwnerService>();
builder.Services.AddScoped<IAdminService, AdminService>();
builder.Services.AddScoped<ITrainerService, TrainerService>();
builder.Services.AddScoped<IGeoService, GeoService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddScoped<IJwtHandler, JwtHandler>();
builder.Services.AddScoped<IEmailSender, EmailSender>();
builder.Services.AddScoped<IPhotoService, PhotoService>();

builder.Services.AddScoped<IContactStore, ContactStore>();
builder.Services.AddScoped<IUserStore, UserStore>();
builder.Services.AddScoped<IPageStore, PageStore>();
builder.Services.AddScoped<ITrainerPageStore, TrainerPageStore>();

builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;

}).AddJwtBearer(options =>
{
    options.RequireHttpsMetadata = false;
    options.SaveToken = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ClockSkew = TimeSpan.Zero,
        ValidateIssuer = false,
        ValidateAudience = false,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = jwtSettings["validIssuer"],
        ValidAudience = jwtSettings["validAudience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
            .GetBytes(jwtSettings.GetSection("securityKey").Value))
    };
});

var app = builder.Build();
//I need this command to acces the files storen in the server
app.UseStaticFiles(
new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
       Path.Combine(builder.Environment.ContentRootPath, "Photos")),
    RequestPath = "/Photos"
}
);
//I use this command to help me acces the folders in browser
app.UseDirectoryBrowser();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(options =>
    options.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
);
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseMyAuthMiddleware();
app.UseAuthorization();

app.MapControllers();

app.Run();

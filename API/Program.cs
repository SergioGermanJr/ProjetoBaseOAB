using System.Reflection;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Infra.Questoes.mapeamentos;
using Infra.Utils.UnityOfWork;
using Infra.Utils.UnityOfWork.Interface;
using NHibernate;
using Scrutor;
using ISession = NHibernate.ISession;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped(factory => SessionFactory.AbrirSessao());
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var assemblies = Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory, "*.dll")
    .Select(Assembly.LoadFrom)
    .ToArray();

builder.Services.Scan(scan => scan
    .FromAssemblies(assemblies)
    .AddClasses(classes => classes.Where(type =>
        type.Name.EndsWith("AppService") ||
        type.Name.EndsWith("Service") ||
        type.Name.EndsWith("Repositorio")))
    .AsImplementedInterfaces()
    .WithScopedLifetime()
);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISessionFactory>(factory =>
{

    string connectionString = builder.Configuration.GetConnectionString("MySql");


    return Fluently.Configure()

        .Database(MySQLConfiguration.Standard.ConnectionString(connectionString)
            .FormatSql()
            .ShowSql())

        .Mappings(m =>
        {

            m.FluentMappings.AddFromAssemblyOf<QuestaoMap>();
        })

        .BuildSessionFactory();
});


builder.Services.AddScoped<ISession>(factory =>
{

    return factory.GetService<ISessionFactory>()!.OpenSession();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFront",
        policy => policy
            .WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("ngrok",
        policy =>
        {
            policy.WithOrigins("https://f629e98add98.ngrok-free.app")
                  .AllowAnyHeader()
                  .AllowAnyMethod()
                  .AllowCredentials();
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("ngrok");




app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

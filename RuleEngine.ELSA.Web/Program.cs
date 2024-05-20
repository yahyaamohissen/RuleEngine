using Elsa;
using Elsa.Persistence.EntityFramework.Core;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
using RuleEngine.ELSA.Web.Activities;
using RuleEngine.ELSA.Web.Activities.DepotFilters;
using RuleEngine.ELSA.Web.Workflows;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var elsaConfig = builder.Configuration.GetSection("Elsa");

builder.Services.AddRazorPages();

builder.Services.AddElsa(elsa => elsa
                    .UseEntityFrameworkPersistence(ef => ef.UseSqlServer(builder.Configuration.GetConnectionString("ElsaConnectionString")))
                    .AddConsoleActivities()
                    .AddHttpActivities()
                    .AddQuartzTemporalActivities()
                    .AddJavaScriptActivities()
                    .AddWorkflowsFrom<Startup>()

                    //.AddWorkflow<HeartbeatWorkflow>()
                    .AddWorkflow<MyFirstHttpFlow>()

                    .AddActivity<MyFirstCustomActivity>()
                    .AddActivity<TrimAndOrderActivity>()
                    .AddActivity<GetDepotsFromWHActivity>()
                    .AddActivity<FilterBAndQDpotsActivity>()
                    .AddActivity<CollectionRestictionsFilterActivity>()
                    .AddActivity<ClosedDepotsFilterActivity>()
                );


builder.Services.AddElsaApiEndpoints();

builder.Services.AddCors(cors => cors.AddDefaultPolicy(policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .WithExposedHeaders("Content-Disposition"))
            );

builder.Services.AddDbContext<ElsaContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("ElsaConnectionString"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapFallbackToPage("/_Host"); });

app.UseHttpsRedirection();

app.UseHttpActivities();

app.MapControllers();

app.Run();

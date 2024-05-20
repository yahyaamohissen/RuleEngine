using Elsa;
using Elsa.Persistence.EntityFramework.Core.Extensions;
using Elsa.Persistence.EntityFramework.SqlServer;
using RuleEngine.ELSA.web.V2.Activities;
using RuleEngine.ELSA.web.V2.Workflows;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRazorPages();

var elsaSection = builder.Configuration.GetSection("Elsa");


builder.Services.AddElsa(options => options
                    .UseEntityFrameworkPersistence(ef => ef.UseSqlServer(builder.Configuration.GetConnectionString("ElsaConnectionString")))
                    .AddConsoleActivities()
                    .AddHttpActivities(elsaSection.GetSection("Server").Bind)
                    .AddQuartzTemporalActivities()
                    .AddJavaScriptActivities()
                    .AddWorkflowsFrom<Startup>()

                    .AddWorkflow<MyFirstHttpFlow>()
                    .AddWorkflow<DepotAllocationFlow>()

                    .AddActivity<CapabilityCheck>()
                    .AddActivity<FilterClosedDepots>()
                    .AddActivity<GetDepots>()
                    .AddActivity<NonClickAndCollectExclusion>()
                    .AddActivity<NonDeliveryDeptsExclusion>()
                    .AddActivity<SortDepots>()
                    .AddActivity<StockCheck>()
                    );

builder.Services.AddElsaApiEndpoints();


builder.Services.AddCors(cors => cors.AddDefaultPolicy(policy => policy
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin()
                .WithExposedHeaders("Content-Disposition"))
            );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseHttpActivities();

app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseEndpoints(endpoints => { endpoints.MapFallbackToPage("/_Host"); });

app.Run();

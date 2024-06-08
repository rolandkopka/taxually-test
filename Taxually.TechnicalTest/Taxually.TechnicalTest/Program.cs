using Taxually.TechnicalTest.Clients;
using Taxually.TechnicalTest.Services.VatRegistration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.AllowInputFormatterExceptionMessages = false;
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.UseInlineDefinitionsForEnums();
});

builder.Services.AddScoped<VatRegistrationServiceGb>();
builder.Services.AddScoped<VatRegistrationServiceFr>();
builder.Services.AddScoped<VatRegistrationServiceDe>();
builder.Services.AddScoped<IVatRegistrationServiceFactory, VatRegistrationServiceFactory>();

builder.Services.AddScoped<IHttpClient, TaxuallyHttpClient>();
builder.Services.AddScoped<IQueueClient, TaxuallyQueueClient>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

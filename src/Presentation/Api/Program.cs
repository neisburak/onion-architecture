var builder = WebApplication.CreateBuilder(args);
{
    builder.Services.AddControllers();
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddApplication()
        .AddInfrastructure()
        .AddEntityFrameworkCore()
            .AddDbContext(options =>
            {
                options.ConnectionString = builder.Configuration.GetConnectionString("SqlServer") ?? throw new ArgumentNullException("Connection string can not be empty.");
            });
}

var app = builder.Build();
{
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    app.UseAuthorization();
    app.MapControllers();

    app.Run();
}

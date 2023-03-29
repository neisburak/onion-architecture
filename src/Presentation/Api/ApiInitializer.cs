public static class ApiInitializer
{
    public static void AddApi(this WebApplicationBuilder builder)
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

    public static void UseApi(this WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
    }
}

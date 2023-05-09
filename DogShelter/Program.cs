using DogShelter.Settings;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();
Dependencies.Inject(builder);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapControllers();

app.Run();

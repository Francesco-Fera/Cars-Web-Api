using Microsoft.EntityFrameworkCore;
using WebApiTest.Models;

namespace WebApiTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<CarContext>(opt => opt.UseInMemoryDatabase("TodoList"));
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
/*Creare una web api con un controller che mi permetta ad un client di popolare una lista di oggetti OKK

Prelevare tutti gli elementi della lista OK

Prelevare un determinato elemento della lista OK

Prelevare solamente determinati elementi della lista 

Eliminare un elemento della lista OK

*E se come ritorno volessi avere uno status code personalizzato? Quali sono le convenzioni per i verbi Get/Post/Delete.OK */
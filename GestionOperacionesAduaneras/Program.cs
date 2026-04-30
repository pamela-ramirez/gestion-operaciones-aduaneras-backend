
using GestionOperacionesAduaneras.Servicios;
using LogicaAccesoDatos.Contexto;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Cliente;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Rol;
using LogicaAplicacion.CasosDeUso.ImplementacionCasosDeUso.Usuarios;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Cliente;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Rol;
using LogicaAplicacion.CasosDeUso.InterfacesCasosDeUso.Usuarios;
using LogicaNegocio.InterfacesRepositorios;
using LogicaNegocio.InterfacesServicios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GestionOperacionesAduaneras
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Base de datos
            builder.Services.AddDbContext<GestionOperacionesDbContext>(options =>
                options.UseSqlServer(
                    builder.Configuration.GetConnectionString("DefaultConnection")
                ));

            // Agregar DbContext
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
            //builder.Services.AddDbContext<GestionOperacionesDbContext>(options =>
             //   options.UseSqlServer(connectionString));

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            // Repositorios
            //builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuarioMock>();
            builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
            builder.Services.AddScoped<IRepositorioCliente, RepositorioCliente>();
            builder.Services.AddScoped<IRepositorioRol, RepositorioRol>();

            // Servicios
            builder.Services.AddScoped<IJwtService, JwtService>();
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();
            builder.Services.AddScoped<IClienteService, ClienteService>();
           

            // Casos de uso usuario
            builder.Services.AddScoped<IObtenerUsuarios, ObtenerUsuarios>();
            builder.Services.AddScoped<IObtenerUsuarioPorId, ObtenerUsuarioPorId>();
            builder.Services.AddScoped<IModificarUsuario, ModificarUsuario>();
            builder.Services.AddScoped<IEliminarUsuario, EliminarUsuario>();

            // Casos de uso cliente 
            builder.Services.AddScoped<ILogin, Login>();
            builder.Services.AddScoped<ICrearCliente, CrearCliente>();
            builder.Services.AddScoped<IObtenerClientes, ObtenerClientes>();
            builder.Services.AddScoped<IObtenerClientePorId, ObtenerClientePorId>();
            builder.Services.AddScoped<IModificarCliente, ModificarCliente>();
            builder.Services.AddScoped<IEliminarCliente, EliminarCliente>();

            // Casos de uso rol
            builder.Services.AddScoped<ICrearRol, CrearRol>();
            builder.Services.AddScoped<IObtenerRoles, ObtenerRoles>();
            

            // Autenticación JWT
            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = builder.Configuration["Jwt:Emisor"],
                        ValidAudience = builder.Configuration["Jwt:Audiencia"],
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Clave"]!))
                    };
                });

            // Add services to the container
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            //builder.Services.AddSwaggerGen();
            builder.Services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Description = "Ingrese: Bearer {token}"
                });

                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}
                    }
                });
            });

            //activar cors para permitir peticiones desde el frontend (React/Vite)
            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowFrontend", policy =>
                {
                    policy.WithOrigins("http://localhost:5173") // tu React (Vite)
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseCors("AllowFrontend"); // <-- habilitar CORS
            app.UseAuthentication(); // <-- primero autenticación
            app.UseAuthorization();  // <-- después autorización


            app.MapControllers();

            app.Run();
        }
    }
}

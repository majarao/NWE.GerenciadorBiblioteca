using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NWE.GerenciadorBiblioteca.Application.Abstractions;
using NWE.GerenciadorBiblioteca.Application.LivroActions.LivroAddUpdateModel;
using NWE.GerenciadorBiblioteca.Application.Services;
using NWE.GerenciadorBiblioteca.Domain.Repositories;
using NWE.GerenciadorBiblioteca.Infra.Data;
using NWE.GerenciadorBiblioteca.Infra.Repositories;

namespace NWE.GerenciadorBiblioteca.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddContext(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<BibliotecaContext>(option => option
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        return services;
    }

    public static IServiceCollection AddInfra(this IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        services.AddScoped<ILivroRepository, LivroRepository>();
        services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        services.AddScoped<IEmprestimoRepository, EmprestimoRepository>();

        return services;
    }

    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddScoped<ILivroService, LivroService>();
        services.AddScoped<IUsuarioService, UsuarioService>();
        services.AddScoped<IEmprestimoService, EmprestimoService>();

        return services;
    }

    public static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddFluentValidationAutoValidation()
            .AddValidatorsFromAssemblyContaining<LivroAddUpdateValidator>();

        return services;
    }
}

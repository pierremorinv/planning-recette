using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace planningRecette.Infrastructure
{
    public static class DependencyInjection
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            Assembly assembly = Assembly.GetExecutingAssembly();

            assembly.GetTypes().Where(t => $"{assembly.GetName().Name}.Repository" == t.Namespace
                                        && !t.IsAbstract
                                        && !t.IsInterface
                                        && t.Name.EndsWith("Repository"))
            .Select(a => new { assignedType = a, serviceTypes = a.GetInterfaces().ToList() })
            .ToList()
            .ForEach(typesToRegister =>
            {
                typesToRegister.serviceTypes.ForEach(typeToRegister => services.AddScoped(typeToRegister, typesToRegister.assignedType));
            });
        }
    }
}
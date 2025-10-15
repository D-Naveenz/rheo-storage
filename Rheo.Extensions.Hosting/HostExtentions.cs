using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Rheo.Extensions.Hosting.Argument;
using Rheo.Extensions.Hosting.Commandline;
using System.Diagnostics.CodeAnalysis;

namespace Rheo.Extensions.Hosting
{
    public static class HostExtentions
    {
        private const string TrimmingWarningMessage = "In case the type is non-primitive, the trimmer cannot statically analyze the object's type so its members may be trimmed.";
        public const string ArgHandlersListKey = "CommandlineArgHandlers";

        /// <summary>
        /// Adds a specified implementation of <see cref="IConsoleBuilder"/> to the application's dependency injection
        /// container.
        /// </summary>
        /// <remarks>This method registers the specified console builder type as a transient service in
        /// the dependency injection container.</remarks>
        /// <typeparam name="T">The type of the console builder to add. Must implement <see cref="IConsoleBuilder"/> and have a public
        /// parameterless constructor.</typeparam>
        /// <param name="hostApplicationBuilder">The <see cref="IHostApplicationBuilder"/> to which the console builder will be added.</param>
        /// <returns>The same <see cref="IHostApplicationBuilder"/> instance, allowing for method chaining.</returns>
        public static IHostApplicationBuilder AddConsoleBuilder<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.PublicConstructors)] T>(this IHostApplicationBuilder hostApplicationBuilder)
            where T : class, IConsoleBuilder
        {
            // Add the arguments builder to the DI container. Doesn't need to hold state, so transient is fine.
            hostApplicationBuilder.Services.AddTransient<IConsoleBuilder, T>();

            return hostApplicationBuilder;
        }

        [RequiresUnreferencedCode(TrimmingWarningMessage)]
        public static bool TryGetValueFromConfiguration<[DynamicallyAccessedMembers(DynamicallyAccessedMemberTypes.All)] T>(this IConfiguration configuration, ArgumentKeys keys, out T? value)
        {
            var result = configuration.GetValue<T>(keys.Key);
            if (result is null && !string.IsNullOrWhiteSpace(keys.LongKey))
            {
                result = configuration.GetValue<T>(keys.LongKey);
            }
            if (result is not null)
            {
                value = result;
                return true;
            }

            value = default;
            return false;
        }

        public static ArgumentHandlerCollection UseArgumentHandlerCollection(this IHostApplicationBuilder hostApplicationBuilder)
        {
            // Add the ArgumentHandlerCollection for DI if not already done
            if (!hostApplicationBuilder.Services.Any(sd => sd.ServiceType == typeof(ArgumentHandlerCollection)))
            {
                hostApplicationBuilder.Services.AddSingleton<ArgumentHandlerCollection>();
            }

            // Create or get the existing CommandlineArgCollection from properties
            ArgumentHandlerCollection collection;
            if (hostApplicationBuilder.Properties.TryGetValue(ArgHandlersListKey, out var handlersObj) && handlersObj is ArgumentHandlerCollection handlers)
            {
                collection = handlers;
            }
            else
            {
                collection = hostApplicationBuilder.Services.BuildServiceProvider().GetRequiredService<ArgumentHandlerCollection>();
                hostApplicationBuilder.Properties[ArgHandlersListKey] = collection;
            }

            return collection;
        }
    }
}

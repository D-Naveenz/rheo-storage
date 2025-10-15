using Microsoft.Extensions.Configuration;

namespace Rheo.Extensions.Hosting.Activation
{
    public interface IActivationHandler
    {
        /// <summary>
        /// Specifies whether the ActivationHandler can handle the activation.
        /// </summary>
        /// <param name="configuration">Informations of the Application.OnLunced event</param>
        /// <returns></returns>
        bool CanHandle(IConfiguration configuration);

        /// <summary>
        /// The logic to handle the arguments of the current activation.
        /// </summary>
        /// <param name="configuration">Informations of the Application.OnLunced event</param>
        /// <returns></returns>
        Task HandleAsync(IConfiguration configuration, CancellationToken cancellationToken);
    }
}

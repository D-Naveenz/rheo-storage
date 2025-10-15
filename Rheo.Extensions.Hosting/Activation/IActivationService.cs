namespace Rheo.Extensions.Hosting.Activation
{
    public interface IActivationService
    {
        /// <summary>
        /// Activates the application with the specified activation arguments.
        /// </summary>
        /// <param name="activationArgs">An array of strings representing the arguments used to activate the application. This may include
        /// command-line arguments or other activation-specific data.</param>
        /// <returns>A task that represents the asynchronous activation operation.</returns>
        Task ActivateAsync(string[] activationArgs);
    }
}

using Rheo.Extensions.Hosting.Argument;
using System.Diagnostics.CodeAnalysis;

namespace Rheo.Extensions.Hosting.Commandline
{
    /// <summary>
    /// Defines a contract for building and managing console-related functionality, such as constructing command-line
    /// arguments and displaying headers.
    /// </summary>
    /// <remarks>Implementations of this interface are responsible for providing the logic to construct
    /// command-line arguments and display console headers.</remarks>
    public interface IConsoleBuilder
    {
        /// <summary>
        /// Constructs and adds command-line arguments to the specified collection.
        /// </summary>
        /// <param name="args">The collection to which the constructed command-line arguments will be added.  This parameter cannot be <see
        /// langword="null"/>.</param>
        [RequiresUnreferencedCode("Calls IconTeX.Host.Argument.ArgumentHandlerCollection.Add(IArgumentHandler)")]
        void BuildArguments(ArgumentHandlerCollection args);

        /// <summary>
        /// Displays the application header to the console or user interface.
        /// </summary>
        /// <remarks>This method is typically used to display branding or introductory information at the
        /// start of the application.</remarks>
        void DisplayHeader();
    }
}

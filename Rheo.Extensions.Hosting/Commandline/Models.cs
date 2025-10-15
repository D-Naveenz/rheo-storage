namespace Rheo.Extensions.Hosting.Commandline
{
    /// <summary>
    /// Provides data for the event that is raised when the console size changes.
    /// </summary>
    /// <remarks>This event argument contains the new and previous sizes of the console, allowing event
    /// handlers to respond to changes in the console's dimensions.</remarks>
    /// <param name="newSize">The new size of the console after the change.</param>
    /// <param name="oldSize">The previous size of the console before the change.</param>
    public class ConsoleSizeChangedEventArgs(ConsoleSize newSize, ConsoleSize oldSize) : EventArgs
    {
        public ConsoleSize NewSize { get; } = newSize;
        public ConsoleSize OldSize { get; } = oldSize;
    }

    /// <summary>
    /// Represents the dimensions of a console window, including its width and height.
    /// </summary>
    /// <remarks>This structure provides a convenient way to encapsulate the width and height of a console
    /// window. It can be used to store or manipulate console dimensions in a single object.</remarks>
    /// <param name="width"></param>
    /// <param name="height"></param>
    public struct ConsoleSize(int width, int height)
    {
        /// <inheritdoc cref="Console.WindowWidth"/>
        public int Width { get; set; } = width;

        /// <inheritdoc cref="Console.WindowHeight"/>
        public int Height { get; set; } = height;
    }
}

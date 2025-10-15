using Microsoft.Extensions.Hosting;
using Rheo.Extensions.Hosting.Activation;

namespace Rheo.Extensions.Hosting.Commandline
{
    public sealed class ConsoleAppHostService : BackgroundService
    {
        private bool _monitoring;
        private readonly IActivationService _activationService;
        private readonly IConsoleBuilder _consoleBuilder;

        /// <summary>
        /// Occurs when the size of the console window changes.
        /// </summary>
        /// <remarks>This event is triggered whenever the dimensions of the console window are modified, 
        /// such as when the user resizes the console window or the size is programmatically adjusted. Subscribers can
        /// use the event arguments to retrieve the new console size.</remarks>
        public static event EventHandler<ConsoleSizeChangedEventArgs>? ConsoleSizeChanged;

        public ConsoleAppHostService(IActivationService activationService, IConsoleBuilder consoleBuilder)
        {
            _activationService = activationService;
            _consoleBuilder = consoleBuilder;

            // Initialize current size
            try
            {
                CurrentSize = new ConsoleSize(Console.WindowWidth, Console.WindowHeight);
            }
            catch
            {
                // Handle cases where the console might not be available
                CurrentSize = new ConsoleSize(0, 0);
            }

            // Invoke the event initially to notify subscribers of the starting size
            ConsoleSizeChanged?.Invoke(this, new ConsoleSizeChangedEventArgs(CurrentSize, new ConsoleSize(0, 0)));
        }

        /// <summary>
        /// Gets the current size of the console, including its width and height.
        /// </summary>
        public ConsoleSize CurrentSize { get; private set; }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            // Start the application and handle the closing event
            return Task.Run(() => OnStartedAsync(stoppingToken), stoppingToken)
                .ContinueWith(t => OnClosed(), stoppingToken);
        }

        private async Task OnStartedAsync(CancellationToken stoppingToken)
        {
            // Configure monitoring flag 
            _monitoring = true;

            // Trigger the application activation
            await _activationService.ActivateAsync([]);

            // Start monitoring thread
            var monitoringThread = new Thread(MonitorConsoleSize)
            {
                Name = "Console Size Monitoring Thread",
                IsBackground = true
            };
            monitoringThread.Start();

            // Handle the application header display
            _consoleBuilder.DisplayHeader();

            Console.WriteLine("Resize the console window to see the event trigger.");
            Console.WriteLine("Press Ctrl+C to exit.");

            // Ensure the monitoring thread stops when the application exits
            Console.CancelKeyPress += (sender, e) =>
            {
                _monitoring = false;    // Stop monitoring when the application is exiting
                monitoringThread.Join(); // Wait for the monitoring thread to finish
            };

            monitoringThread.Join(); // Wait for the monitoring thread to finish
        }

        private void OnClosed()
        {
            _monitoring = false; // Stop monitoring when the application is exiting
        }

        private void MonitorConsoleSize()
        {
            while (_monitoring)
            {
                // Snapshots of the current size
                var oldSize = CurrentSize;

                try
                {
                    int width = Console.WindowWidth;
                    int height = Console.WindowHeight;

                    if (width != oldSize.Width || height != oldSize.Height)
                    {
                        CurrentSize = new ConsoleSize(width, height);
                        ConsoleSizeChanged?.Invoke(this, new ConsoleSizeChangedEventArgs(CurrentSize, oldSize));
                    }
                }
                catch
                {
                    // Handle cases where the console might not be available
                    // For example, when running in a non-interactive environment
                    CurrentSize = new ConsoleSize(0, 0);
                }
                Thread.Sleep(500); // Check every 500 milliseconds
            }
        }
    }
}

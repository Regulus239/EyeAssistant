using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using Tobii.Interaction;

namespace ConsoleApp1
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var handle = Process.GetCurrentProcess().MainWindowHandle;
            var windowBounds = GetWindowBounds(handle);

            var greeter = new Greeter(
                handle.ToString(),
                windowBounds,
                () => Console.WriteLine("Welcome!"),
                () => Console.WriteLine("Goodbye!"));

            Console.ReadKey();
        }

        #region Helpers 
        private static Rectangle GetWindowBounds(IntPtr windowHandle)
        {
            NativeRect nativeNativeRect;
            if (GetWindowRect(windowHandle, out nativeNativeRect))
                return new Rectangle
                {
                    X = nativeNativeRect.Left,
                    Y = nativeNativeRect.Top,
                    Width = nativeNativeRect.Right,
                    Height = nativeNativeRect.Bottom
                };

            return new Rectangle(0d, 0d, 1000d, 1000d);
        }

        [DllImport("user32.dll", SetLastError = true)]
        static extern bool GetWindowRect(IntPtr hWnd, out NativeRect nativeRect);

        [StructLayout(LayoutKind.Sequential)]
        public struct NativeRect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        #endregion
    }

    public class Greeter : IDisposable
    {
        private readonly Host _host;
        private readonly VirtualInteractorAgent _interactorAgent;
        private readonly VirtualInteractor _greetingInteractor;

        public Greeter(
            string defaultWindowId,
            Rectangle defaultWindowBounds,
            Action onGazeEnters,
            Action onGazeLeaves)
        {
            _host = new Host();
            _interactorAgent = _host.InitializeVirtualInteractorAgent(defaultWindowId);
            _greetingInteractor = _interactorAgent.AddInteractorFor(defaultWindowBounds);
            _greetingInteractor
                .WithGazeAware()
                .HasGaze(onGazeEnters)
                .LostGaze(onGazeLeaves);
        }

        public void Dispose()
        {
            _host.Dispose();
        }
    }
}

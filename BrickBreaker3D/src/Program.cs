using OpenTK.Windowing.Desktop;

namespace BrickBreaker3D;

/// <summary>Точка входа: создаёт окно OpenTK и запускает игровой цикл.</summary>
internal static class Program
{
    [STAThread]
    private static void Main()
    {
        // Логируем любые необработанные исключения в error.log рядом с EXE,
        // чтобы при вылете было видно причину (WinExe не имеет консоли).
        AppDomain.CurrentDomain.UnhandledException += (_, e) => LogFatal(e.ExceptionObject as Exception);
        TaskScheduler.UnobservedTaskException += (_, e) => { LogFatal(e.Exception); e.SetObserved(); };

        try
        {
            using var game = new Game();
            game.Run();
        }
        catch (Exception ex)
        {
            LogFatal(ex);
            throw;
        }
    }

    private static void LogFatal(Exception? ex)
    {
        if (ex == null) return;
        try
        {
            string path = Path.Combine(AppContext.BaseDirectory, "error.log");
            File.AppendAllText(path, "[" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "] " + ex + Environment.NewLine + Environment.NewLine);
        }
        catch { /* ignore */ }
    }
}

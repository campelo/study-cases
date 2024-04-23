using System.Diagnostics;

namespace SampleGenerator;

public static class UnixDebugger

{
  public static bool WaitForDebugger(TimeSpan? limit = null)
  {
    return WaitForDebuggerAsync(limit).Result;
  }

  public static async Task<bool> WaitForDebuggerAsync(TimeSpan? limit = null)
  {
    limit ??= TimeSpan.FromSeconds(60);
    var source = new CancellationTokenSource(limit.Value);

    // Console.WriteLine($"◉ Waiting {limit.Value.TotalSeconds} secs for debugger {Process.GetCurrentProcess().Id}...");

    try
    {
      await Task.Run(async () =>
      {
        while (!Debugger.IsAttached)
        {
          await Task.Delay(TimeSpan.FromMilliseconds(100), source.Token);
        }
      }, source.Token);
    }
    catch (OperationCanceledException)
    {
      // it's ok
    }

    Console.WriteLine(Debugger.IsAttached
        ? "✔ Debugger attached"
        : "✕ Continuing without debugger");

    return Debugger.IsAttached;
  }

}
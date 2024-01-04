using System.Diagnostics;

int count = 0;
Stopwatch stopwatch = new();
stopwatch.Start();
for (int i = 0; i<1000000000;i++)
  count += 1;
stopwatch.Stop();
TimeSpan elapsedTime = stopwatch.Elapsed;
Console.WriteLine($"Count is {count}");
Console.WriteLine($"Execution time {elapsedTime.TotalSeconds} seconds");

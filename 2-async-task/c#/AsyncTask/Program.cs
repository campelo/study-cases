// See https://aka.ms/new-console-template for more information

int min = 3000;
int max = 4000;

async Task ConfigureAwaitFalse(){
  await DoFalseAction1().ConfigureAwait(false);
  await DoFalseAction2().ConfigureAwait(false);
    Console.WriteLine($"Done {nameof(ConfigureAwaitFalse)}");
}

async Task DoFalseAction1()
{
    await Task.Delay(max).ConfigureAwait(false);
    Console.WriteLine($"{nameof(DoFalseAction1)} ready");
}

async Task DoFalseAction2()
{
    await Task.Delay(min).ConfigureAwait(false);
    Console.WriteLine($"{nameof(DoFalseAction2)} ready");
}

async Task ConfigureAwaitTrue(){
  await DoFalseAction1().ConfigureAwait(true);
  await DoFalseAction2().ConfigureAwait(true);
  Console.WriteLine($"Done {nameof(ConfigureAwaitTrue)}");
}

async Task DoTrueAction1()
{
    await Task.Delay(max).ConfigureAwait(true);
    Console.WriteLine($"{nameof(DoTrueAction1)} ready");
}

async Task DoTrueAction2()
{
    await Task.Delay(min).ConfigureAwait(true);
    Console.WriteLine($"{nameof(DoTrueAction2)} ready");
}

async Task WhenAll(){
  Task[] tasks = [DoAction1(), DoAction2()];
  await Task.WhenAll(tasks);
  Console.WriteLine($"Done {nameof(WhenAll)}");
}

async Task WhenAny(){
  Task[] tasks = [DoAction1(), DoAction2()];
  await Task.WhenAny(tasks);
  Console.WriteLine($"Done {nameof(WhenAny)}");
}

async Task DoAction1()
{
    await Task.Delay(max);
    Console.WriteLine($"{nameof(DoAction1)} ready");
}

async Task DoAction2()
{
    await Task.Delay(min);
    Console.WriteLine($"{nameof(DoAction2)} ready");
}

Task WithoutAwait(){
  DoFalseAction1();
  DoFalseAction2();
  Console.WriteLine($"Done {nameof(WithoutAwait)}");
  return Task.CompletedTask;
}

await ConfigureAwaitFalse();
await ConfigureAwaitTrue();
await WhenAll();
await WhenAny();
await WithoutAwait();
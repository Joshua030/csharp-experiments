using System.Threading.Tasks;

//SECTION - Handle Threads

/* Console.WriteLine("Hello world! 1");
Thread.Sleep(1000);
Console.WriteLine("Hello world! 2");
Thread.Sleep(1000);
Console.WriteLine("Hello world! 3");
Thread.Sleep(1000);
Console.WriteLine("Hello world! 4");

new Thread(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 1");
}).Start();
new Thread(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 2");
}).Start();
new Thread(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 3");
}).Start();
new Thread(() =>
{
    Thread.Sleep(1000);
    Console.WriteLine("Thread 4");
}).Start(); */


//SECTION - How to use TaskCompletionSource and threads

var taskCompletionSource = new TaskCompletionSource<bool>();

var thread = new Thread(() =>
{
    Thread.Sleep(1000);
    taskCompletionSource.TrySetResult(true);
});
Console.WriteLine($"Thread number: {thread.ManagedThreadId}");
thread.Start();

var test = taskCompletionSource.Task.Result;

//SECTION - How to use multi thread

Enumerable.Range(0, 1000).ToList().ForEach(f =>
{
    ThreadPool.QueueUserWorkItem((o) =>
    {
        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} started");
        Thread.Sleep(1000);

        Console.WriteLine($"Thread number: {Thread.CurrentThread.ManagedThreadId} ended");
    });
});

Console.ReadLine();
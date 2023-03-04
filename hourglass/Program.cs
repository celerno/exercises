public class Hourglass{
    public int Minutes { get; }
    public int Seconds { get; }    
    public long Ticks { get; }
    
    public delegate void OnStartEventHandler(object sender, int Seconds);
    public event OnStartEventHandler OnStart;
}

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

namespace DomeTrainSingleton;

sealed class Singleton
{
    // With the Lazy keyword, basically we are creating a Thread-safe
    private static readonly Lazy<Singleton> _lazyInstance = new(() => new Singleton());
    
    public static Singleton Instance => _lazyInstance.Value;

    private Singleton()
    {
        Console.WriteLine("Instance initialized");
    }

}
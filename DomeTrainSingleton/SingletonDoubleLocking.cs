namespace DomeTrainSingleton;

/// <summary>
/// Double locking / Thread Safe to create a Singleton Class
/// Example with some manual checks.
/// </summary>
sealed class SingletonDoubleLocking
{
    private static SingletonDoubleLocking _instance = default!;
    private static object _lock = new();
    private static int times = 0;
    
    public static SingletonDoubleLocking Instance {
        get
        {
            // Double check locking
            if (_instance is null)
            {
                Console.WriteLine($"Locking Singleton - Thread {++times}");
                
                // Lock could be expensive in a real-life scenario
                // Not the best option
                lock (_lock)
                {
                    if (_instance is null)
                    {
                        _instance = new SingletonDoubleLocking();
                    }
                }
            }


            return _instance;
        }
    }
    
    private SingletonDoubleLocking()
    {
        Console.WriteLine("Instance initialized");
    }

}
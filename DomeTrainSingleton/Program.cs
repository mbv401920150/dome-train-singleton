using DomeTrainSingleton;
using Microsoft.Extensions.DependencyInjection;

// DOUBLE CHECK LOCKING
ParallelEnumerable
    .Range(0, 1000)
    .ForAll(_ =>
    {
        var singleton = SingletonDoubleLocking.Instance;
    });
    
ParallelEnumerable
    .Range(0, 1000)
    .ForAll(_ =>
    {
        var singleton = SingletonDoubleLocking.Instance;
    });

// SINGLETON LAZY / THREAD SAFE
ParallelEnumerable
    .Range(0, 1000)
    .ForAll(_ =>
    {
        var singleton = Singleton.Instance;
    });
    
ParallelEnumerable
    .Range(0, 1000)
    .ForAll(_ =>
    {
        var singleton = Singleton.Instance;
    });

// Dependency Injection IoC (Inversion of Control)
// Microsoft.Extensions.DependencyInjection

IServiceCollection services = new ServiceCollection();
// Still the `AddSingleton` method creates any class as a Singleton,
// but is not necessary that the class has the Singleton Design Pattern. 
services.AddSingleton<Singleton>();

var serviceProvider = services.BuildServiceProvider();
var singleton1 = serviceProvider.GetRequiredService<Singleton>();
var singleton2 = serviceProvider.GetRequiredService<Singleton>();
var singleton3 = serviceProvider.GetRequiredService<Singleton>();
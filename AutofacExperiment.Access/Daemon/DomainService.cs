using System;

namespace AutofacExperiment.Access.Daemon;

public class DomainService(IDaemonResourceRepository resourceRepository) : IDomainService
{
    private IDaemonResourceRepository _daemonResourceRepository = resourceRepository;

    private Guid _name = Guid.NewGuid();
    
    public string GetServiceName()
    {
        Console.WriteLine($"Service:{_name}, Repository:{_daemonResourceRepository.ResourceMonster()}");
        return _name.ToString();
    }
    
    public void Dispose()
    {
        Console.WriteLine($"{_name} dispose!");
    }
}
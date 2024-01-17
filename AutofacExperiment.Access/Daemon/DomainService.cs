using System;

namespace AutofacExperiment.Access.Daemon;

public class DomainService : IDomainService
{
    private Guid _name = Guid.NewGuid();
    
    public string GetServiceName()
    {
        return _name.ToString();
    }
}
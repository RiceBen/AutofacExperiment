using System;

namespace AutofacExperiment.Access.Daemon;

public interface IDomainService : IDisposable
{
    string GetServiceName();
}
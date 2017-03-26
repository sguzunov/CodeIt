using System;

namespace CodeIt.Services.Logic.Contracts
{
    public interface ITimeProvider
    {
        DateTime UtcNow { get; }
    }
}

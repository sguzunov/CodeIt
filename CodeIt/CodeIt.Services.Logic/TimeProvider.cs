using CodeIt.Services.Logic.Contracts;
using System;

namespace CodeIt.Services.Logic
{
    public class TimeProvider : ITimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

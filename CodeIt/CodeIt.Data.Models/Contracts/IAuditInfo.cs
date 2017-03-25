using System;

namespace CodeIt.Data.Models.Contracts
{
    public interface IAuditInfo
    {
        DateTime CreatedOn { get; set; }
    }
}

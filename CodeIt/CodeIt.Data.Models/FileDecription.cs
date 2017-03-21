using System;

namespace CodeIt.Data.Models
{
    public class FileDecription : FileInfo
    {
        public Guid ChallengeId { get; set; }

        public Challenge Challenge { get; set; }
    }
}

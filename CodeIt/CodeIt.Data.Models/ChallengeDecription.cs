using System;

namespace CodeIt.Data.Models
{
    public class ChallengeDecription : FileInfo
    {
        public Guid ChallengeId { get; set; }

        public Challenge Challenge { get; set; }
    }
}

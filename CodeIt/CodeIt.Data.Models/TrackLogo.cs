using System;

namespace CodeIt.Data.Models
{
    public class TrackLogo : FileInfo
    {
        public Guid TrackId { get; set; }

        public Track Track { get; set; }
    }
}

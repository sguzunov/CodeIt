using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;

using CodeIt.Data.Models;

namespace CodeIt.Data.Migrations
{
    public sealed class Configuration : DbMigrationsConfiguration<CodeItDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = false;
            this.AutomaticMigrationDataLossAllowed = false;
        }

        protected override void Seed(CodeItDbContext context)
        {
            //var algorithmsTrack = new Track()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Algorithms",
            //    Categories = new List<Category>
            //        {
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Strings"
            //            },
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Sorting"
            //            },
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Searching"
            //            },
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Grapth"
            //            },
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Greedy"
            //            },
            //        }
            //};
            //var dataStructuresTrack = new Track()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Data Structures",
            //    Categories = new List<Category>
            //        {
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Hashtables"
            //            },
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Trees"
            //            }
            //        }
            //};
            //var javaTrack = new Track()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "Java",
            //    Categories = new List<Category>
            //        {
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Strings"
            //            },
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Big numbers"
            //            }
            //        }
            //};
            //var csharpTrack = new Track()
            //{
            //    Id = Guid.NewGuid(),
            //    Name = "CSharp",
            //    Categories = new List<Category>
            //        {
            //            new Category()
            //            {
            //                Id = Guid.NewGuid(),
            //                Name = "Console"
            //            }
            //        }
            //};

            //context.Tracks.AddOrUpdate(algorithmsTrack);
            //context.Tracks.AddOrUpdate(dataStructuresTrack);
            //context.Tracks.AddOrUpdate(javaTrack);
            //context.Tracks.AddOrUpdate(csharpTrack);

            //Save tracks
            //context.SaveChanges();

            //var algorithmsLogo = new TrackLogo
            //{
            //    Id = Guid.NewGuid(),
            //    FileName = "algorithms",
            //    FileExtension = "png",
            //    FileSystemPath = "/Content/Assets/TrackLogos/",
            //    TrackId = algorithmsTrack.Id,
            //    Track = algorithmsTrack
            //};

            //var dataStructuresLogo = new TrackLogo
            //{
            //    Id = Guid.NewGuid(),
            //    FileName = "data-structures",
            //    FileExtension = "png",
            //    FileSystemPath = "/Content/Assets/TrackLogos/",
            //    TrackId = dataStructuresTrack.Id,
            //    Track = dataStructuresTrack
            //};

            //var javaLogo = new TrackLogo
            //{
            //    Id = Guid.NewGuid(),
            //    FileName = "java",
            //    FileExtension = "png",
            //    FileSystemPath = "/Content/Assets/TrackLogos/",
            //    TrackId = javaTrack.Id,
            //    Track = javaTrack
            //};

            //var csharpLogo = new TrackLogo
            //{
            //    Id = Guid.NewGuid(),
            //    FileName = "csharp",
            //    FileExtension = "png",
            //    FileSystemPath = "/Content/Assets/TrackLogos/",
            //    TrackId = csharpTrack.Id,
            //    Track = csharpTrack
            //};

            //context.TrackLogos.AddOrUpdate(algorithmsLogo);
            //context.TrackLogos.AddOrUpdate(dataStructuresLogo);
            //context.TrackLogos.AddOrUpdate(javaLogo);
            //context.TrackLogos.AddOrUpdate(csharpLogo);

            //context.SaveChanges();
        }
    }
}

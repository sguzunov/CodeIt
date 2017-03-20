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
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(CodeItDbContext context)
        {
            context.Tracks.AddOrUpdate(new Track[]
            {
                new Track()
                {
                    Id = Guid.NewGuid(),
                    Name = "Algorithms",
                    Categories = new List<Category>
                    {
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Strings"
                        },
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Sorting"
                        },
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Searching"
                        },
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Grapth"
                        },
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Greedy"
                        },
                    }
                },
                new Track()
                {
                    Id = Guid.NewGuid(),
                    Name = "Data Structures",
                    Categories = new List<Category>
                    {
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Hashtables"
                        },
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Trees"
                        }
                    }
                },
                new Track()
                {
                    Id = Guid.NewGuid(),
                    Name = "Java",
                    Categories = new List<Category>
                    {
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Strings"
                        },
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Big numbers"
                        }
                    }
                },
                new Track()
                {
                    Id = Guid.NewGuid(),
                    Name = "CSharp",
                    Categories = new List<Category>
                    {
                        new Category()
                        {
                            Id = Guid.NewGuid(),
                            Name = "Console"
                        }
                    }
                }
             });
        }
    }
}

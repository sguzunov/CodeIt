using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using CodeIt.Common.Constants;
using CodeIt.Data.Models.Contracts;

namespace CodeIt.Data.Models
{
    public class Track : IEntity
    {
        private ICollection<Category> categories;

        public Track()
        {
            this.categories = new HashSet<Category>();
        }

        public Guid Id { get; set; }

        [Required]
        [Index(IsUnique = true)]
        [MaxLength(ValidationConstants.TrackNameMaxLength)]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories
        {
            get { return this.categories; }
            set { this.categories = value; }
        }
    }
}

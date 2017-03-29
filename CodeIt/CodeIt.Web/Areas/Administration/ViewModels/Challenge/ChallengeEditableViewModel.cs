using System;
using System.ComponentModel.DataAnnotations;
using AutoMapper;
using CodeIt.Common.Attributes;
using CodeIt.Common.Constants;
using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;

using ChallengeDb = CodeIt.Data.Models.Challenge;

namespace CodeIt.Web.Areas.Administration.ViewModels.Challenge
{
    public class ChallengeEditableViewModel : IMapFrom<ChallengeDb>, IHaveCustomMappings
    {
        public Guid Id { get; set; }

        [Required]
        [MinLength(ValidationConstants.ChallengeTitleMinLength)]
        [MaxLength(ValidationConstants.ChallengeTitleMaxLength)]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Track")]
        public string TrackName { get; set; }

        [Required]
        [Display(Name = "Category")]
        public string CategoryName { get; set; }

        [Required]
        public Language Language { get; set; }

        [Required]
        [Display(Name = "Time limit in ms")]
        [MinValue(ValidationConstants.MinimumMemoryInKb)]
        public double TimeInMs { get; set; }

        [Required]
        [Display(Name = "Memory (KB)")]
        [MinValue(ValidationConstants.MinimumMemoryInKb)]
        public int MemoryInKb { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<ChallengeDb, ChallengeEditableViewModel>()
                .ForMember(x => x.TrackName, opt => opt.MapFrom(x => x.Category.Track.Name));
        }
    }
}
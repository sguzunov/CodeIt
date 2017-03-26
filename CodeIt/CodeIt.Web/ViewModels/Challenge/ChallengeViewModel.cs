using System;

using CodeIt.Web.Infrastructure.Mapping;

using ChallengeModel = CodeIt.Data.Models.Challenge;

namespace CodeIt.Web.ViewModels.Challenge
{
    public class ChallengeViewModel : IMapFrom<ChallengeModel>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }
    }
}
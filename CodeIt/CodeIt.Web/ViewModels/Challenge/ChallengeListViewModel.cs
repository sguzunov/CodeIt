using CodeIt.Web.Infrastructure.Mapping;
using System;

using ChallengeModel = CodeIt.Data.Models.Challenge;

namespace CodeIt.Web.ViewModels.Challenge
{
    public class ChallengeListViewModel : IMapFrom<ChallengeModel>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}
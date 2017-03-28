using AutoMapper;
using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;

namespace CodeIt.Web.ViewModels.Challenge
{
    public class TestResultViewModel : IMapFrom<TestResult>, IHaveCustomMappings
    {
        public bool IsEvaluated { get; set; }

        public bool IsPassed { get; set; }

        public bool TimeLimited { get; set; }

        public bool HasRuntimeException { get; set; }

        public bool HasCompileError { get; set; }

        public void CreateMappings(IMapperConfigurationExpression configuration)
        {
            configuration.CreateMap<TestResult, TestResultViewModel>()
                .ForMember(x => x.HasCompileError, opt => opt.MapFrom(p => !string.IsNullOrEmpty(p.CompileError)))
                .ForMember(x => x.HasRuntimeException, opt => opt.MapFrom(p => !string.IsNullOrEmpty(p.RuntimeException)));
        }
    }
}
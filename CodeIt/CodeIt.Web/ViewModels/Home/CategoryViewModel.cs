using CodeIt.Data.Models;
using CodeIt.Web.Infrastructure.Mapping;
using System;

namespace CodeIt.Web.ViewModels.Home
{
    public class CategoryViewModel : IMapFrom<Category>
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
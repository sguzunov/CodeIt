using System.ComponentModel.DataAnnotations;

namespace CodeIt.Data.Models
{
    public enum Language
    {
        [Display(Name = "C#")]
        CSharp,
        [Display(Name = "Java")]
        Java,
        [Display(Name = "C")]
        C,
        [Display(Name = "C++")]
        CPlusPlus,
        [Display(Name = "Haskell")]
        Haskell,
        [Display(Name = "Python")]
        Python
    }
}

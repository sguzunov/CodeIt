using System.ComponentModel.DataAnnotations;

namespace CodeIt.Data.Models
{
    public enum Language
    {
        [Display(Name = "C#")]
        CSharp = 27,
        [Display(Name = "Java")]
        Java = 55,
        [Display(Name = "C")]
        C = 11,
        [Display(Name = "C++")]
        CPlusPlus = 44,
        [Display(Name = "Haskell")]
        Haskell = 21,
        [Display(Name = "Python")]
        Python = 116
    }
}

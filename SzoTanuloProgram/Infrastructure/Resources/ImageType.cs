using System.ComponentModel.DataAnnotations;

namespace SzoTanuloProgram.Infrastructure.Utilities.Enums
{
    public enum ImageType
    {
        None = 0,

        [Display(Name = "Loader")]
        LoaderBackground = 1,

        [Display(Name = "Flags")]
        Flag = 2,

        [Display(Name = "Misc")]
        Misc = 99,
    }
}

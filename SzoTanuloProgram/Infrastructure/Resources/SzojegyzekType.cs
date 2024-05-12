using System.ComponentModel.DataAnnotations;

namespace SzoTanuloProgram.Infrastructure.Utilities.Enums
{
    public enum SzojegyzekType
    {
        None = 0,

        [Display(Name = "Elementary")]
        Elementary = 1,

        [Display(Name = "Intermediate")]
        Intermediate = 2,

        [Display(Name = "PreIntermediate")]
        PreIntermediate = 3,

        [Display(Name = "Proficiency")]
        Proficiency = 4,

        Misc = 99
    }
}

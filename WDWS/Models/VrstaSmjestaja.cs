using System.ComponentModel.DataAnnotations;

namespace wdws.Models;

public enum VrstaSmjestaja
{
    [Display(Name = "Hotel")] 
    Hotel, 
    [Display(Name = "Apartman")] 
    Apartman, 
    [Display(Name = "Resort")] 
    Resort
}
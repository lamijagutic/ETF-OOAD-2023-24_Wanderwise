using System.ComponentModel.DataAnnotations;

namespace wdws.Models;

public enum PrijevoznoSredstvo
{
    [Display(Name = "Avion")]
    Avion, 
    
    [Display(Name = "Autobus")]
    Autobus, 
    
    [Display(Name = "Voz")] 
    Voz
}
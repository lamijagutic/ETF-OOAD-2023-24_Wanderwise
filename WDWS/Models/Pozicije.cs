using System.ComponentModel.DataAnnotations;

namespace wdws.Models;

public enum Pozicije
{
    [Display(Name = "Administrator")]
    Administrator,
    [Display(Name = "Turisticki vodic")]
    TuristickiVodic, 
    [Display(Name = "Klijent")]
    Klijent
}
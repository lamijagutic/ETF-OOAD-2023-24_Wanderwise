using System.ComponentModel.DataAnnotations;

namespace wdws.Models;

public enum StatusRezervacije
{
    [Display(Name = "Gost odustao")] 
    GostOdustao, 
    
    [Display(Name = "Odbijeno")] 
    Odbijena, 
    
    [Display(Name = "Prihvaćena")] 
    Prihvacena, 
    
    [Display(Name = "Završeno")] 
    Placena, 
    
    [Display(Name = "Nije plaćeno")] 
    NijePlacena
}
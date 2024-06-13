using System.ComponentModel.DataAnnotations;

namespace wdws.Models;

public enum TipSobe
{
    [Display(Name = "Single")]
    Single, 
    [Display(Name = "Double")]
    Double, 
    [Display(Name = "Triple")]
    Triple, 
    [Display(Name = "Family")]
    Family, 
    [Display(Name = "Suite")]
    Suite
}
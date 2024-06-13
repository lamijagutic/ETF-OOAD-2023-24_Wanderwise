using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace wdws.Models;

public abstract class Korisnik : IdentityUser
{
    [Required]
    [Display(Name = "Ime")]
    public String ime { get; set; }
    
    [Required]
    [Display(Name = "Prezime")]
    public String prezime { get; set; }
    
    [Required]
    [Display(Name = "Adresa")]
    public String adresa { get; set; }
    
    [Required]
    [Display(Name = "Spol")]
    public char spol { get; set; }
    
    [Required]
    [Display(Name = "Datum rođenja")]
    public DateTime datumRodjenja { get; set; }

    public Pozicije pozicija { get; set; }
    
    public Korisnik() 
    {
        
    }
    
    
}
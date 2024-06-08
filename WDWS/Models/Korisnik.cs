using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace wdws.Models;

public class Korisnik : IdentityUser
{
    [Required]
    [Display(Name = "Ime")]
    public String ime { get; set; }
    
    [Required]
    [Display(Name = "Prezime")]
    public String prezime { get; set; }
    
    [Required]
    [Display(Name = "Korisničko ime")]
    public String username { get; set; }
    
    [Required]
    [Display(Name = "Email adresa")]
    public String email { get; set; }
    
    [Required]
    [Display(Name = "Broj telefona")]
    public String telefon { get; set; }
    
    [Required]
    [Display(Name = "Adresa")]
    public String adresa { get; set; }
    
    [Required]
    [Display(Name = "Spol")]
    public char spol { get; set; }
    
    [Required]
    [Display(Name = "Datum rođenja")]
    public DateOnly datumRodjenja { get; set; }

    public Pozicije pozicija { get; set; }
    
    public Korisnik() 
    {
        
    }
    
    
}
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace wdws.Models;

public abstract class  Korisnik : IdentityUser
{

    [Key]
    override public String Id { get; set; }
    
    [Display(Name = "Ime")]
    public String ime { get; set; }
    

    [Display(Name = "Prezime")]
    public String prezime { get; set; }
    

    [Display(Name = "Adresa")]
    public String adresa { get; set; }
    

    [Display(Name = "Spol")]
    public char spol { get; set; }
    


    [Display(Name = "Datum rođenja")]
    public DateTime datumRodjenja { get; set; }

    override public String UserName { get; set; }
    
    override public String Email { get; set; }
    public Korisnik() 
    {
        
    }
    
    
}
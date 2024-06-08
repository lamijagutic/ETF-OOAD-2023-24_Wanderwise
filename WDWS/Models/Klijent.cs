using System.ComponentModel.DataAnnotations;
using System.Net.Mime;

namespace wdws.Models;

public class Klijent : Korisnik
{
    public String kontaktZaHitneSlucajeve { get; set; }
    public String napomene { get; set; }
    public int nagradniBodovi { get; set; } = 0;

    public Klijent()
    {
        
    }
    
}
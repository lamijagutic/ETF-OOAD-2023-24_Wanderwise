using System.ComponentModel.DataAnnotations;

namespace wdws.Models;

public class TuristickiVodic : Korisnik
{
    public List<String> jezici { get; set; }
    public bool dostupnost { get; set; }

    public TuristickiVodic()
    {
        pozicija = Pozicije.TuristickiVodic; 
    }
}
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Putovanje
{
    [Key]
    public int putID { get; set; }
    
    [ForeignKey("Lokacija")] 
    public int mjestoPolaskaID { get; set; }
    //public Lokacija mjestoPolaska { get; set; }
    
    [ForeignKey("Lokacija")] 
    public int mjestoDolaskaID { get; set; }
    //public Lokacija mjestoDolaska { get; set; }
    
    public int duzinaPutovanja { get; set; }
    
    public DateTime datumPolaska { get; set; }
    public DateTime datumDolaska { get; set; }
    
    public double cijenaPoOsobi { get; set; }

    public List<PrijevoznoSredstvo>? prijevoznaSredstva { get; set; }
    
    public List<Recenzija>? recenzije { get; set; }
    
    [ForeignKey("Smjestaj")] 
    public int smjestajID { get; set; }
    public Smjestaj smjestaj;
    
    [ForeignKey("TuristickiVodic")] 
    public int? guideID { get; set; }
    public TuristickiVodic? vodic { get; set; }
    
    
    public Putovanje()
    {

    }


}
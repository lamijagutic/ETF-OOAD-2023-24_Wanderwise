using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Authorization;

namespace wdws.Models;

[Authorize]
public class Putovanje
{
    [Key]
    public int travelId { get; set; }
    
    [ForeignKey("Lokacija")] 
    public int mjestoPolaskaID { get; set; }
    //public Lokacija mjestoPolaska { get; set; }
    
    [ForeignKey("Lokacija")] 
    public int mjestoDolaskaID { get; set; }
    //public Lokacija mjestoDolaska { get; set; }
    
    [Range(0, double.MaxValue, ErrorMessage = "Unesite ispravan broj dana.")]
    public int duzinaPutovanja { get; set; }
    
    public DateTime datumPolaska { get; set; }
    public DateTime datumDolaska { get; set; }
    
    [Range(0, double.MaxValue, ErrorMessage = "Cijena mora biti veća ili jednaka 0.")]
    public double cijenaPoOsobi { get; set; }

    [EnumDataType(typeof(PrijevoznoSredstvo))] public PrijevoznoSredstvo prijevoz { get; set; }
    
    public List<Recenzija>? recenzije { get; set; }
    
    [ForeignKey("Smjestaj")] 
    public int? smjestajID { get; set; }
    public Smjestaj? Smjestaj { get; set; }
    
    [ForeignKey("TuristickiVodic")] 
    public String? guideID { get; set; }
    public TuristickiVodic? TuristickiVodic { get; set; }
    
    public String ImageURL { get; set; }
    [StringLength(maximumLength: 300, MinimumLength = 20, ErrorMessage = "Opis putovanja smije imati između 20 i 300 karaktera!")] 
    public String OpisPutovanja { get; set; }
    public Putovanje()
    {

    }


}
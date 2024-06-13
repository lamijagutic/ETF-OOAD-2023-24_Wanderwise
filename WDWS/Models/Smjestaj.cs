using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Smjestaj  {
    [Key]
    public int lodgingID {get; set;}

    public String naziv {get; set; }

    [EnumDataType(typeof(VrstaSmjestaja))]  public VrstaSmjestaja VrstaSmjestaja { get; set; }

    [ForeignKey("Lokacija")] public int lokacijaID { get; set; }
    public Lokacija? lokacija { get; set; }
    
    public String KontaktTelefon { get; set; }
    [EmailAddress(ErrorMessage = "Unesite validnu email adresu!")]
    public String KontaktEmail { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Unesite validan kapacitet smještaja!")]
    public int MaxKapacitet { get; set; }
    
    public List<Soba>? SobeUPonudi;
    
    [Range(0, double.MaxValue, ErrorMessage = "Unesite validnu cijenu smještaja!")]
    public double CijenaSmjestaja { get; set; }
    public Smjestaj()
    {
       
    }

}
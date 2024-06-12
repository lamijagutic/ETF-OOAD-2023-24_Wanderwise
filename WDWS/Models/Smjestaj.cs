using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Smjestaj  {
    [Key]
    public int lodgingID {get; set;}

    public String naziv {get; set; }

    public VrstaSmjestaja VrstaSmjestaja { get; set; }

    [ForeignKey("Lokacija")] public int lokacijaID { get; set; }
    public Lokacija lokacija { get; set; }
    
    public String KontaktTelefon { get; set; }
    public String KontaktEmail { get; set; }
    public int MaxKapacitet { get; set; }
    
    public List<Soba>? SobeUPonudi;
    
    public double CijenaSmjestaja { get; set; }
    /*
     ovaj atribut je sada u klasi Rezervacija.
    [ForeignKey("Soba")] public int? rezervisanaSobaID { get; set; }
    public Soba? rezervisanaSoba { get; set; }
    */

    public Smjestaj()
    {
       
    }

}
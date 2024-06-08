using System.ComponentModel.DataAnnotations;

namespace wdws.Models;

public class Smjestaj  {
    [Key]
    public int ID {get; set;}

    public String naziv {get; set; }

    public VrstaSmjestaja VrstaSmjestaja { get; set; }

    public Lokacija lokacija { get; set; }
    public String KontaktTelefon { get; set; }
    public String KontaktEmail { get; set; }
    public int MaxKapacitet { get; set; }
    public List<Soba> SobeUPonudi;
    public double CijenaSmjestaja { get; set; }
    public Soba rezervisanaSoba { get; set; }

    public Smjestaj()
    {
       
    }
    public Smjestaj vratiInformacijeOSmjestaju()
    {
        return this;
    }
}
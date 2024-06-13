using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Rezervacija
{
    [Key] public int reservationID { get; set; } = 0;
    
    [ForeignKey("Putovanje")]
    public int putovanjeID { get; set; }
    public Putovanje Putovanje { get; set; }
    
    public int brojPutnika { get; set; }
    public double ukupnaCijena { get; set; }
    public int MilesBodovi { get; set; }
    
    /*[ForeignKey("Smjestaj")]
    public int smjestajID { get; set; }
    public Smjestaj Smjestaj { get; set; }*/ //<- ovo vec imamo u putovanju
    
    [ForeignKey("Soba")] 
    public int rezervisanaSobaID { get; set; }
    //public Soba Soba { get; set; }
    
    [EnumDataType(typeof(StatusRezervacije))] public StatusRezervacije status { get; set; }
    
    [ForeignKey("Klijent")] 
    public String klijentID { get; set; }
    public Klijent Klijent { get; set; }
    public Boolean VodicUkljucen { get; set; }
    public Rezervacija()
    {
        status = StatusRezervacije.NijePlacena;
    }
    public void dodajNagradneBodove()
    {
        Klijent.nagradniBodovi += MilesBodovi;
    }

}
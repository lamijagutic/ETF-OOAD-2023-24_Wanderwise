using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Rezervacija
{
    [Key]
    public int rezervacijaID { get; set; }
    
    [ForeignKey("Putovanje")]
    public int putovanjeID { get; set; }
    public Putovanje put { get; set; }
    
    public int brojPutnika { get; set; }
    public double ukupnaCijena { get; set; }
    public int MilesBodovi { get; set; }
    
    [ForeignKey("Smjestaj")]
    public int smjestajID { get; set; }
    public Smjestaj smjestaj { get; set; }
    
    public StatusRezervacije status { get; set; }
    
    [ForeignKey("Klijent")] public Klijent klijent { get; set; }
    public Rezervacija()
    {
        
    }
    public void dodajNagradneBodove()
    {
        klijent.nagradniBodovi += MilesBodovi;
    }
}
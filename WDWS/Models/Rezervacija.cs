using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Rezervacija
{
    [Key] public int reservationID { get; set; } = 0;
    
    [ForeignKey("Putovanje")]
    public int putovanjeID { get; set; }
    public Putovanje put { get; set; }
    
    public int brojPutnika { get; set; }
    public double ukupnaCijena { get; set; }
    public int MilesBodovi { get; set; }
    
    /*[ForeignKey("Smjestaj")]
    public int smjestajID { get; set; }
    public Smjestaj Smjestaj { get; set; }*/ //<- ovo vec imamo u putovanju
    
    [ForeignKey("Soba")] public int rezervisanaSobaID { get; set; }
    //public Soba soba { get; set; }
    
    [EnumDataType(typeof(StatusRezervacije))] public StatusRezervacije status { get; set; }
    
    [ForeignKey("Klijent")] 
    public String clientID { get; set; }
    public Klijent? klijent { get; set; }
    public Rezervacija()
    {
        status = StatusRezervacije.NijePlacena;
    }
    public void dodajNagradneBodove()
    {
        klijent.nagradniBodovi += MilesBodovi;
    }
    public void GenerišiID()
    {
        Random generator = new Random();
        for (int i = 0; i < 10; i++)
        {
            reservationID += (int)Math.Pow(10, i) * generator.Next(0, 9);
        }
    }

}
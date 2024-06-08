using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Pasos
{
    [Key]
    public int pasosID { get; set; }
    
    [ForeignKey("Klijent")]
    public int KlijentID { get; set; }
    public Klijent klijent { get; set; }
    
    public String drzavaKojaIzdaje { get; set; }
    public String nacionalnost { get; set; }
    public DateOnly datumIsteka { get; set; }
    public String napomene { get; set; }

    public Pasos()
    {
        
    }
}
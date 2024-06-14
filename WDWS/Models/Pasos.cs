using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Pasos
{
    [Key]
    public int ID { get; set; }
    [ForeignKey("Klijent")] public String clientID { get; set; }
    public Klijent Klijent { get; set; }

    public String? drzavaKojaIzdaje { get; set; }
    public String? nacionalnost { get; set; }
    public DateOnly datumIsteka { get; set; }
    public String? napomene { get; set; }
    
    
    public Pasos()
    {
        
    }
}
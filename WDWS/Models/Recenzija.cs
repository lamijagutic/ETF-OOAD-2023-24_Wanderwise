using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Recenzija
{
    [Key]
    public int RecenzijaID { get; set; }
    public String tekstRecenzije { get; set; }
    
    [ForeignKey("Putovanje")]
    public int putovanjeID { get; set; }
    public Putovanje putovanje { get; set; }
    
    [ForeignKey("Klijent")]
    public int KlijentID { get; set; }
    public Klijent klijent { get; set; }
    
}
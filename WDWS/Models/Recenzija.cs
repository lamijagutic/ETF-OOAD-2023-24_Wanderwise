using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;
public class Recenzija
{
    [Key]
    public int reviewID { get; set; }
    
    public String tekstRecenzije { get; set; }
    
    [ForeignKey("Putovanje")] 
    public int putID { get; set; }
    public Putovanje Putovanje { get; set; }
    
    [ForeignKey("Klijent")] 
    public String clientID { get; set; }
    public Klijent klijent { get; set; }

    public Recenzija()
    {
        
    }
}
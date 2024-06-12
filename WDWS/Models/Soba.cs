using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Soba
{
    [Key]
    public int roomID { get; set; }
    public TipSobe tipSobe { get; set; }
    public int kapacitetSobe { get; set; }
    public double cijena { get; set; }
    
    [ForeignKey("Smjestaj")] public int smjestajID { get; set; }
    public Smjestaj Smjestaj { get; set; }

    
    
}
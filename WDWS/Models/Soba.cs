using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Soba
{
    [Key]
    public int roomID { get; set; }
    [EnumDataType(typeof(TipSobe))] public TipSobe tipSobe { get; set; }
    public int kapacitetSobe { get; set; }
    [Range(15, double.MaxValue, ErrorMessage = "Cijena mora biti veća od 15 KM.")]
    public double cijena { get; set; }
    
    [ForeignKey("Smjestaj")] public int smjestajID { get; set; }
    public Smjestaj Smjestaj { get; set; }

    
    
}
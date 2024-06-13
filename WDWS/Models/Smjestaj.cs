using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace wdws.Models;

public class Smjestaj  {
    [Key]
    public int lodgingID {get; set;}

    [Required]
    [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "Naziv predmeta smije imati između 3 i 50 karaktera!")] 
    public String naziv {get; set; }

    [Required]
    [EnumDataType(typeof(VrstaSmjestaja))]  
    public VrstaSmjestaja VrstaSmjestaja { get; set; }

    [Required]
    [ForeignKey("Lokacija")] public int lokacijaID { get; set; }
    public Lokacija? lokacija { get; set; }
    
    [Required]
    public String KontaktTelefon { get; set; }
    [EmailAddress(ErrorMessage = "Unesite validnu email adresu!")]
    
    [Required]
    public String KontaktEmail { get; set; }
    [Range(0, double.MaxValue, ErrorMessage = "Unesite validan kapacitet smještaja!")]
    
    [Required]
    public int MaxKapacitet { get; set; }
    
    [Required]
    public List<Soba>? SobeUPonudi;
    
    [Required]
    [Range(0, double.MaxValue, ErrorMessage = "Unesite validnu cijenu smještaja!")]
    public double CijenaSmjestaja { get; set; }
    public Smjestaj()
    {
       
    }

}
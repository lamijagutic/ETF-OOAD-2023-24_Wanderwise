using System.ComponentModel.DataAnnotations;

namespace wdws.Models;

public class Lokacija
{
    public String nazivMjesta { get; set; }
    public String? drzava { get; set; }
    
    [Key]
    public String postanskiBroj { get; set; }

    public Lokacija()
    {
        
    }
    
    
}
using wdws.Models;

namespace WDWS.Models;

public interface IBuilder
{
    void DodajPutovanjeID(int putID);
    void DodajBrojPutnika(int brPutnika);
    void DodajStatusRezervacije(StatusRezervacije status);
    void DodajUkupnuCijenu(double UkupnaCijena);
    void DodajMilesBodove(int MilesBodovi);
    //void DodajKlijenta(Klijent lijentID);
    Rezervacija Build();
    
}
using wdws.Models;

namespace WDWS.Models;

public class RezervacijaBuilder : IBuilder
{
    private Rezervacija r = new Rezervacija();

    public void DodajPutovanjeID(int putID)
    {
        r.putovanjeID = putID;
    }

    public void DodajBrojPutnika(int brPutnika)
    {
        r.brojPutnika = brPutnika;
    }

    public void DodajStatusRezervacije(StatusRezervacije status)
    {
        r.status = status;
    }

    public void DodajUkupnuCijenu(double UkupnaCijena)
    {
        r.ukupnaCijena = UkupnaCijena;
    }

    public void DodajMilesBodove(int MilesBodovi)
    {
        r.MilesBodovi = MilesBodovi;
    }

    /*public void DodajKlijenta(Klijent klijentID)
    {
        r.Klijent = klijentID;
    }*/
    
    public Rezervacija Build()
    {
        return r;
    }
}
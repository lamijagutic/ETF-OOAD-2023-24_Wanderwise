using wdws.Models;

namespace WDWS.Models;

public class PutovanjeInfoDecorator : IPutovanje
{
    protected IPutovanje dekorisanoPutovanje;

    public PutovanjeInfoDecorator(IPutovanje put)
    {
        dekorisanoPutovanje = put;
    }
    public Putovanje PrikaziPutovanje(Putovanje p)
    {
        return p;
    }
}
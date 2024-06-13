using wdws.Models;

namespace WDWS.Models;

public class PutovanjeLokacije : PutovanjeInfoDecorator
{
    public PutovanjeLokacije(IPutovanje put) : base(put)
    {
        
    }

    public IPutovanje PrikaziPutovanje(IPutovanje p)
    {
        return dekorisanoPutovanje;
    }
}
using Microsoft.EntityFrameworkCore;

namespace LoginMicroService.Ports
{
    public interface IPersistance
    {
        public void InitializeContext();
    }
}

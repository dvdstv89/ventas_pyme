using NucleoEV.Model;

namespace NucleoEV.Service
{
    internal class MainUIService
    {
        public Session session { get; set; }

        public MainUIService(Session session)
        {
            this.session = session;               
        }
    }
}

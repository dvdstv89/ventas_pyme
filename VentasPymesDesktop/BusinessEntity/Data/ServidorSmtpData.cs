using ModelData.Repository;
using ModelData.Service.RemotoDatabaseClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.Model
{
    public static class ServidorSmtpData
    {
        static List<ServidorSMTP> servidoresSmtp { get; set; } = new List<ServidorSMTP>();
        static void inicializar()
        {
            if (servidoresSmtp.Count == 0)
            {
                servidoresSmtp = RepositoryFactory.ServidorSmtp_Local().inicializar();
            }
        }
        public static ServidorSMTP getServidorSmtpById(string id)
        {
            inicializar();
            return servidoresSmtp.Find(x => x.getId() == id);
        }
        public static List<ServidorSMTP> getAllServidorSmtp()
        {
            inicializar();
            return servidoresSmtp;
        }        
    }
}

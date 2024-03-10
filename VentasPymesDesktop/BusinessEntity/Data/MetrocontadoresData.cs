using ModelData.Repository;
using ModelData.Service.LocalDatabaseClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.Model
{
    public static class MetrocontadoresData
    {
        static List<Metrocontador> metrocontadores { get; set; } = new List<Metrocontador>();
        static void inicializar()
        {
            if (metrocontadores.Count == 0)
            {
                metrocontadores = new MetrocontadorLDB().getMetrocontadores(VariablesEntorno.annoAbierto.Value, VariablesEntorno.securityToken.token.Value);
            }
        }
        public static Metrocontador getMetroContadorById(string id)
        {
            inicializar();
            return metrocontadores.Find(x => x.getId() == id);
        }
        public static List<Metrocontador> getAllMetroContadores()
        {
            inicializar();
            return metrocontadores;
        }        
    }
}

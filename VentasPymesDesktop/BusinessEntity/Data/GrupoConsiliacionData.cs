using ModelData.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelData.Model
{
    public static class GrupoConsiliacionData
    {
        static List<GrupoConciliacion> gruposConsiliaciones { get; set; } = new List<GrupoConciliacion>();
        static void inicializar()
        {
            if (gruposConsiliaciones.Count == 0)
            {
                gruposConsiliaciones = RepositoryFactory.GrupoConciliacion_Local().inicializar();
            }
        }
        public static GrupoConciliacion getGrupoConsiliacionById(string id)
        {
            inicializar();
            return gruposConsiliaciones.Find(x => x.getId() == id);
        }
        public static List<GrupoConciliacion> getAllGrupoConsiliaciones()
        {
            inicializar();
            return gruposConsiliaciones;
        }
        public static List<GrupoConciliacion> getGrupoConsiliacionAutorizadosInSessionToken()
        {
            List<string> idGruposAutorizados = VariablesEntorno.securityToken.getIdGrupoConsiliaciones();
            inicializar();
            List<GrupoConciliacion> gruposAutorizados = new List<GrupoConciliacion>();
            for (int i = 0; i < idGruposAutorizados.Count; i++)
            {
                GrupoConciliacion aux = gruposConsiliaciones.Find(c => c.getId() == idGruposAutorizados[i] && c.isActivo.Value == true);
                if(aux != null )gruposAutorizados.Add(aux);
            }
            return gruposAutorizados;
        }
    }
}

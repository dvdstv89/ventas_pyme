using Database.Class;
using ModelData.Repository;
using ModelData.Service.LocalDatabaseClient;
using System.Collections.Generic;

namespace ModelData.Model
{
    public static class TiendaData
    {
        static List<Tienda> tiendas { get; set; } = new List<Tienda>();
        static void inicializar()
        {
            if (tiendas.Count == 0)
            {
                tiendas = new TiendaLDB().getTiendas(VariablesEntorno.annoAbierto.Value, VariablesEntorno.securityToken.token.Value);
            }
        }
        public static Tienda getTiendasById(Atributo_PK<int> id)
        {
            inicializar();
            return tiendas.Find(t => t.getId() == id.getValueAsString());
        }
        public static Tienda getTiendasByIdGrupoTienda(Atributo_PK<int> id)
        {
            inicializar();
            return tiendas.Find(t => t.grupoTienda.getValueAsInt() == id.Value);
        }
        public static List<Tienda> getByIdComplejo(Atributo_PK<int> idComplejo)
        {           
            inicializar();
            List<Tienda> tiendasComplejo = tiendas.FindAll(t => t.idComplejo.getValueAsString() == idComplejo.getValueAsString());           
            return tiendasComplejo;
        }       
    }
}

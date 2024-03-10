using Database.Class;
using ModelData.Model;
using System.Data.Common;

namespace ModelData.Atributo
{
    public class Atributo_GrupoConciliacion : Atributo_Objeto_FK<GrupoConciliacion, int>
    {     
        public Atributo_GrupoConciliacion(string columnName) :base(columnName)
        {
           
        }
        public Atributo_GrupoConciliacion(GrupoConciliacion value, string columnName): base(value, columnName)
        {
          
        }
        public new void setValue(DbDataReader reader)
        {
            base.setValue(reader);
            this.Objeto = GrupoConsiliacionData.getGrupoConsiliacionById(getValueAsString());
        }
    }
}

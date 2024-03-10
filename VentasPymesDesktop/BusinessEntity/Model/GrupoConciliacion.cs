using Database;
using Database.Class;
using ModelData.Atributo;
using System.Data.Common;
using System.Runtime.Remoting.Messaging;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace ModelData.Model
{    
    public class GrupoConciliacion : BaseModelPro<GrupoConciliacion, int>, ISincronizable<GrupoConciliacion, int>
    {      
        public Atributo<string> denominacion { get; set; } = new Atributo<string>("denominacion");
        public Atributo_Money comision { get; set; } = new Atributo_Money("comision");
        public Atributo_Moneda moneda { get; set; } = new Atributo_Moneda("id_moneda");
        public GrupoConciliacion()
        {
            setTabla();           
        }    
        public GrupoConciliacion(string tokenId) : base(tokenId)
        {
            
        }
        public GrupoConciliacion(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {         
            this.id.setValue(sqlReader);
            this.denominacion.setValue(sqlReader);
            this.comision.setValue(sqlReader);
            this.moneda.setValue(sqlReader);           
        }       
        public override string ToString()
        {
            return denominacion.Value;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("grupo_conciliacion", "gc");
        }
    }    
}

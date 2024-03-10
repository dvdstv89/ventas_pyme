using Database;
using Database.Class;
using System.Data.Common;
using System.Windows.Forms;

namespace ModelData.Model
{  
    public class Moneda : BaseModelPro<Moneda, int>, ISincronizable<Moneda, int>
    {       
        public Atributo<string> denominacion { get; set; } = new Atributo<string>("denominacion");
        public Atributo_Money tazaCambioRespectoDefecto { get; set; } = new Atributo_Money("taza_cambio_respecto_default");
        public Atributo<bool> isByDefault { get; set; } = new Atributo<bool>("is_by_default");
        public Atributo<bool> isOnline { get; set; } = new Atributo<bool>("is_online");
        public Moneda(string tokenId) : base(tokenId)
        {            
            isByDefault.Value = false;           
        }
        public Moneda()
        {
            setTabla();
        }
        public Moneda(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {
            this.id.setValue(sqlReader);
            this.denominacion.setValue(sqlReader);
            this.tazaCambioRespectoDefecto.setValue(sqlReader);
            this.isByDefault.setValue(sqlReader);
            this.isOnline.setValue(sqlReader);
        }
        public bool getIsOnline()
        {
            return isOnline.Value;
        }       
        public override string ToString()
        {
            return denominacion.Value;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("moneda", "m");
        }
    }   
}

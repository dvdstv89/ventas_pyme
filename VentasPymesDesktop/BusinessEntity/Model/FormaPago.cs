using Database;
using Database.Class;
using ModelData.Atributo;
using System.Data.Common;

namespace ModelData.Model
{
    
    public class FormaPago : BaseModelPro<FormaPago, int>, ISincronizable<FormaPago, int>
    {      
        public Atributo<string> denominacion { get; set; } = new Atributo<string>("denominacion");
        public Atributo_GrupoConciliacion grupoConciliacion { get; set; } = new Atributo_GrupoConciliacion("id_grupo_conciliacion");
        public Atributo<bool> isResumen { get; set; } = new Atributo<bool>("is_resumen");
        public Atributo_Moneda moneda { get; set; } = new Atributo_Moneda("id_moneda");
        public FormaPago()
        {
            setTabla();
        }
        public FormaPago(string tokenId) : base(tokenId)
        { 
            isResumen.Value = false; 
        }
        public FormaPago(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {
            this.id.setValue(sqlReader);
            this.denominacion.setValue(sqlReader);
            this.moneda.setValue(sqlReader);            
            this.isResumen.setValue(sqlReader);
            this.grupoConciliacion.setValue(sqlReader);            
        }
        public bool getIsResumen()
        {
            return isResumen.Value;
        }      
        public override string ToString()
        {
            return denominacion.Value;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("forma_pago", "fp");
        }
        public Atributo_Porciento getComision()
        {
            return grupoConciliacion.Objeto.comision.getValueVisualPorciento();
        }

    }   
}

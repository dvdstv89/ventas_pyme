using Database;
using Database.Class;
using LocalData.Atributo;
using System.Data.Common;
using System.Windows.Forms;
using System.Windows.Media.TextFormatting;

namespace ModelData.Model
{  
    public class ParteServicioDiario : BaseModelPro<ParteServicioDiario, string>, ISincronizable<ParteServicioDiario, string>
    {       
        public Atributo_PK<int> idMetro { get; set; } = new Atributo_PK<int>("id_metro");
        public Atributo_Servicio tipoServicio { get; set; } = new Atributo_Servicio("id_servicio");
        public Atributo_Datetime fecha { get; set; } = new Atributo_Datetime("fecha");
        public Atributo_Consumo lectura { get; set; } = new Atributo_Consumo("lectura");
        public Atributo_Consumo consumo { get; set; } = new Atributo_Consumo("consumo");
        public ParteServicioDiario(string tokenId) : base(tokenId)
        {            
              
        }
        public ParteServicioDiario()
        {
            setTabla();
        }
        public ParteServicioDiario(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {
            this.id.setValue(sqlReader);
            this.idMetro.setValue(sqlReader);
            this.fecha.setValue(sqlReader);
            this.lectura.setValue(sqlReader);
            this.consumo.setValue(sqlReader);
            this.tipoServicio.setValue(sqlReader);
        }
        public void setId()
        {
            //25:1:2023-01-01
            this.id.Value = idMetro.Value + ":" + tipoServicio.Value + ":" + fecha.getAsString();
        }      
        public override string ToString()
        {
            return fecha.Value+" "+idMetro.Value;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("parte_servicio_diario", "psd");
        }
    }   
}

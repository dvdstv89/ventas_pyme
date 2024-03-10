using Database;
using Database.Class;
using LocalData.Atributo;
using ModelData.Repository;
using System.Collections.Generic;
using System.Data.Common;
using System.Windows.Forms;

namespace ModelData.Model
{  
    public class Metrocontador : BaseModelPro<Metrocontador, int>, ISincronizable<Metrocontador, int>
    {       
        public Atributo_Servicio tipoServicio { get; set; } = new Atributo_Servicio("id_servicio");
        public Atributo<string> denominacion { get; set; } = new Atributo<string>("denominacion");
        public Atributo<string> descripcion { get; set; } = new Atributo<string>("descripcion");
        public Atributo_PK<int> idComplejo { get; set; } = new Atributo_PK<int>("id_complejo");      
        public List<PlanServicioMensual> planesConsumo { get; set; }
        public List<ParteServicioDiario> partesConsumo { get; set; }     
        public Metrocontador()
        {
            setTabla();
        }
        public Metrocontador(string tokenId) : base(tokenId)
        {
            idComplejo.Value = 0;
            partesConsumo = new List<ParteServicioDiario>();
            planesConsumo = new List<PlanServicioMensual>();
        }
        public Metrocontador(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {
            this.id.setValue(sqlReader);
            this.tipoServicio.setValue(sqlReader);
            this.denominacion.setValue(sqlReader);
            this.descripcion.setValue(sqlReader);
            this.idComplejo.setValue(sqlReader);          
            this.planesConsumo = RepositoryFactory.PlanServicioMensual_Local().getByMetrocontador(this.id.Value);
            this.partesConsumo = RepositoryFactory.ParteServicioDiario_Local().getByMetrocontador(this.id.Value);
        }   
        public override string ToString()
        {
            return denominacion.Value;
        }
        protected new void setTabla()
        {
            tabla = new Tabla("metrocontador", "me");
        }
    }   
}

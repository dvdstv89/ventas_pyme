using Database;
using Database.Class;
using System.Data.Common;

namespace ModelData.Model
{    
    public class PlanServicioMetrocontador : BaseModel<PlanServicioMetrocontador, int>, ISincronizable<PlanServicioMetrocontador, int>
    {         
        public Atributo_PK<int> idMetrocontador { get; set; } = new Atributo_PK<int>("id_metrocontador");
        public Atributo_PK<string> idPlanServicio { get; set; } = new Atributo_PK<string>("id_plan_servicio");
        public Atributo_Anno anno { get; set; } = new Atributo_Anno("anno");       
      
        public PlanServicioMetrocontador()
        {
            setTabla();
        }
        public PlanServicioMetrocontador(int idMetrocontador, string idPlanServicio, int anno)
        {
            setTabla();
            this.idMetrocontador.Value = idMetrocontador;
            this.idPlanServicio.Value = idPlanServicio;
            this.anno.Value = anno;
        }
        public PlanServicioMetrocontador(DbDataReader sqlReader)
        {          
            this.idMetrocontador.setValue(sqlReader);
            this.idPlanServicio.setValue(sqlReader);
            this.anno.setValue(sqlReader);
        }
        protected new void setTabla()
        {
            tabla = new Tabla("plan_servicio_metrocontador", "psmtr");
        }
    }
}

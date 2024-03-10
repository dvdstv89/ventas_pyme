using Database;
using Database.Class;
using System.Data.Common;

namespace ModelData.Model
{    
    public class PlanServicioComplejo : BaseModel<PlanServicioComplejo, int>, ISincronizable<PlanServicioComplejo, int>
    {         
        public Atributo_PK<int> idComplejo { get; set; } = new Atributo_PK<int>("id_complejo");
        public Atributo_PK<string> idPlanServicio { get; set; } = new Atributo_PK<string>("id_plan_servicio");
        public Atributo_Anno anno { get; set; } = new Atributo_Anno("anno");
        public PlanServicioComplejo()
        {
            setTabla();
        }
        public PlanServicioComplejo(int idComplejo, string idPlanServicio, int anno)
        {
            setTabla();
            this.idComplejo.Value = idComplejo;
            this.idPlanServicio.Value = idPlanServicio;
            this.anno.Value = anno;
        }
        public PlanServicioComplejo(DbDataReader sqlReader)
        {          
            this.idComplejo.setValue(sqlReader);
            this.idPlanServicio.setValue(sqlReader);
            this.anno.setValue(sqlReader);
        }
        protected new void setTabla()
        {
            tabla = new Tabla("plan_servicio_complejo", "pscomp");
        }
    }
}

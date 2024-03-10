using Database;
using Database.Class;
using System.Data.Common;

namespace ModelData.Model
{    
    public class PlanVentaComplejo : BaseModel<PlanVentaComplejo, int>, ISincronizable<PlanVentaComplejo, int>
    {         
        public Atributo_PK<int> idComplejo { get; set; } = new Atributo_PK<int>("id_complejo");
        public Atributo_PK<string> idPlanVenta { get; set; } = new Atributo_PK<string>("id_plan_venta");
        public Atributo_Anno anno { get; set; } = new Atributo_Anno("anno");
        public PlanVentaComplejo()
        {
            setTabla();
        }
        public PlanVentaComplejo(int idComplejo, string idPlanVenta, int anno)
        {
            setTabla();
            this.idComplejo.Value = idComplejo;
            this.idPlanVenta.Value = idPlanVenta;
            this.anno.Value = anno;
        }
        public PlanVentaComplejo(DbDataReader sqlReader)
        {          
            this.idComplejo.setValue(sqlReader);
            this.idPlanVenta.setValue(sqlReader);
            this.anno.setValue(sqlReader);
        }
        protected new void setTabla()
        {
            tabla = new Tabla("plan_venta_complejo", "pvcomp");
        }
    }
}

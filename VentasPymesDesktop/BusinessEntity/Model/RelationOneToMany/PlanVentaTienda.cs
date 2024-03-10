using Database;
using Database.Class;
using System.Data.Common;

namespace ModelData.Model
{    
    public class PlanVentaTienda : BaseModel<PlanVentaTienda, int>, ISincronizable<PlanVentaTienda, int>
    {         
        public Atributo_PK<int> idTienda { get; set; } = new Atributo_PK<int>("id_tienda");
        public Atributo_PK<string> idPlanVenta { get; set; } = new Atributo_PK<string>("id_plan_venta");
        public Atributo_Anno anno { get; set; } = new Atributo_Anno("anno");  
        public PlanVentaTienda()
        {
            setTabla();
        }
        public PlanVentaTienda(int idTienda, string idPlanVenta, int anno)
        {
            setTabla();
            this.idTienda.Value= idTienda;
            this.idPlanVenta.Value= idPlanVenta;
            this.anno.Value= anno;
        }

        public PlanVentaTienda(DbDataReader sqlReader)
        {          
            this.idTienda.setValue(sqlReader);
            this.idPlanVenta.setValue(sqlReader);
            this.anno.setValue(sqlReader);
        }
        protected new void setTabla()
        {
            tabla = new Tabla("plan_venta_tienda", "pvtda");
        }
    }
}

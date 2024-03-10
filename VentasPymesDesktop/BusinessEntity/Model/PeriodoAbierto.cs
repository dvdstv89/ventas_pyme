using Database;
using Database.Class;
using System;
using System.Data.Common;

namespace ModelData.Model
{  
    public class PeriodoAbierto : BaseModelPro<PeriodoAbierto, int>, ISincronizable<PeriodoAbierto, int>
    {              
        public Atributo_Anno annoAbierto { get; set; } = new Atributo_Anno("anno_abierto");
        public Atributo_Mes mesAbierto { get; set; } = new Atributo_Mes("mes_abierto");
        public PeriodoAbierto()
        {
            setTabla();
        }
        public PeriodoAbierto(string tokenId) : base(tokenId)
        {           
            annoAbierto.Value = DateTime.Now.Year;                 
        }
        public PeriodoAbierto(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {            
            this.id.setValue(sqlReader);
            this.annoAbierto.setValue(sqlReader);
            this.mesAbierto.setValue(sqlReader);
        }       
        public DateTime minDateOfMount()
        {
            return mesAbierto.minDate(annoAbierto.Value);            
        }
        public DateTime maxDateOfMount()
        {
            DateTime fechaActual = DateTime.Now;
            if(fechaActual.Month == mesAbierto.Value)
            {
                return fechaActual;
            }
            return mesAbierto.maxDate(annoAbierto.Value);        }
        protected new void setTabla()
        {
            tabla = new Tabla("periodo_abierto", "pa");
        }
    }
}

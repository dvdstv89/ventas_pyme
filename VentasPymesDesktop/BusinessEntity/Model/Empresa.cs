using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using Database;
using Database.Class;
using ModelData.Atributo;
using ModelData.Repository;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace ModelData.Model
{  
    public class Empresa : BaseModelPro<Empresa, int>, ISincronizable<Empresa, int>
    {           
        public Atributo<string> denominacion { get; set; } = new Atributo<string>("denominacion");
        public Atributo_Email email { get; set; } = new Atributo_Email("email");
        public List<Complejo> complejos { get; set; }
        public Atributo_ServidorSMTP servidorSMTP { get; set; } = new Atributo_ServidorSMTP("id_servidor_smtp");      
        public Atributo_Money planVentaAnno { get; set; } = new Atributo_Money("plan_venta_anno");
        public Atributo_Consumo planElectricoAnno { get; set; } = new Atributo_Consumo("plan_electrico_anno");
        public Atributo_Consumo planAguaAnno { get; set; } = new Atributo_Consumo("plan_agua_anno");
        public Atributo_Money salarioJefesBrigada { get; set; } = new Atributo_Money("salario_jefe_brigada");
        public Atributo_Money salarioDependienteComercial { get; set; } = new Atributo_Money("salario_dependiente_comercial");
        public Empresa()
        {
            setTabla();
        }
        public Empresa(string tokenId) : base(tokenId)
        {          
            complejos= new List<Complejo>();          
        }
        public Empresa(DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) : base(sqlReader, tipoBaseDatos)
        {          
            this.id.setValue(sqlReader);
            this.denominacion.setValue(sqlReader);
            this.email.setValue(sqlReader);
            this.servidorSMTP.setValue(sqlReader);
            this.planVentaAnno.setValue(sqlReader);
            this.planElectricoAnno.setValue(sqlReader);
            this.planAguaAnno.setValue(sqlReader);
            this.salarioJefesBrigada.setValue(sqlReader);
            this.salarioDependienteComercial.setValue(sqlReader);
            this.complejos = new List<Complejo>();
        }
        public Atributo_Money getPlanVentasMes(int mes)
        {
            decimal saldo = complejos.Sum(p => p.getPlanVentasMes(mes).MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getPlanVentasAnno()
        {
            decimal saldo = complejos.Sum(p => p.planVentaAnno.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentasRealesResumidasMesActual()
        {
            decimal saldo = complejos.Sum(p => p.ventasRealesResumidasMesActual.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentasRealesDetalladasMesActual()
        {
            decimal saldo = complejos.Sum(p => p.ventasRealesDetalladasMesActual.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentaRealesResumidasAnno()
        {
            decimal saldo = complejos.Sum(p => p.ventasRealesResumidasAnnoActual.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }
        public Atributo_Money getVentaRealesDetalladasAnno()
        {
            decimal saldo = complejos.Sum(p => p.ventasRealesDetalladasAnnoActual.MoneyAccount);
            return AtributoFactory.buildMoney(saldo);
        }     
        protected new void setTabla()
        {
            tabla = new Tabla("empresa", "em");
        }
    }    
}

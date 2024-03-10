using ModelData.Model;
using NucleoEV.Model;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using ModelData;
using ModelData.Atributo;

namespace NucleoEV.UIController
{
    internal class ConciliacionUIController
    {
        public Conciliacion conciliacion { get; set; }
        protected ConciliacionUI forma = new ConciliacionUI();
        protected bool dialogResultOk;
        protected bool formularioModoModificar;  
        protected Session session;
        protected Complejo complejo;
        protected GrupoConciliacion grupoConciliacion;      

        public ConciliacionUIController(Session session, Complejo complejo, GrupoConciliacion grupoConciliacion, Conciliacion conciliacion)
        {
            try
            {
                this.session = session;
                this.conciliacion = conciliacion;
                this.dialogResultOk = false;
                this.grupoConciliacion = grupoConciliacion;
                this.complejo = complejo;                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }      
        public virtual ConciliacionUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.dtFechaInicio.ValueChanged += new EventHandler(dtFechaInicio_ValueChanged);
            forma.dtFechaFin.ValueChanged += new EventHandler(dtFechaFin_ValueChanged);
            forma.tbSaldo.Enter+= new EventHandler(tbSaldo_Enter);
            forma.tbSaldo.Leave += new EventHandler(tbSaldo_Leave);
            forma.tbComision.Enter += new EventHandler(tbComision_Enter);
            forma.tbComision.Leave += new EventHandler(tbComision_Leave);           
            forma.btnCancelar.Click += new EventHandler(btnCancelar_Click);           
            return forma;
        }        
        void forma_Load(object sender, EventArgs e)
        {         
            aplicarTema();          
            restablecerFormulario();            
        }
        protected virtual void aplicarTema()
        {
            session.temaAplication.inicializarBoton(ref forma.btnCancelar, TipoBoton.Normal); 
            session.temaAplication.inicializarFormDialog(ref forma);
        }
        protected virtual void restablecerFormulario()
        {
            forma.tbComplejo.Enabled = false;
            forma.tbGrupo.Enabled = false;
            forma.tbDocumento.Text = conciliacion.documento.Value;
            forma.tbComplejo.Text = complejo.denominacion.Value;
            forma.tbGrupo.Text = grupoConciliacion.denominacion.Value;
            forma.lbMoneda.Text = grupoConciliacion.moneda.Objeto.denominacion.Value;
            forma.tbSaldo.Text = conciliacion.saldoVenta.getValueAccount();
            forma.tbComision.Text = conciliacion.saldoComision.getValueAccount();           

            if(conciliacion.fechaInicio.Fecha> VariablesEntorno.ultimaFechaValida)
            {
                conciliacion.fechaInicio.setFecha(VariablesEntorno.ultimaFechaValida);
                conciliacion.fechaFin.setFecha(VariablesEntorno.ultimaFechaValida);
            }

            session.temaAplication.inicializarDateTimePicker(ref forma.dtFechaInicio, session.cultureInfo, conciliacion.fechaInicio.Fecha, conciliacion.fechaInicio.Fecha, conciliacion.fechaInicio.Fecha);
            session.temaAplication.inicializarDateTimePicker(ref forma.dtFechaFin, session.cultureInfo, conciliacion.fechaFin.Fecha, VariablesEntorno.ultimaFechaValida, conciliacion.fechaFin.Fecha);
        }        
        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                forma.DialogResult = (dialogResultOk && formularioModoModificar) ? DialogResult.OK : DialogResult.Cancel;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
        protected bool actualizarConciliacionDesdeFormulario()
        {
            try
            {   
                conciliacion.complejo.setObjeto(complejo);
                conciliacion.grupoConciliacion.setObjeto(grupoConciliacion);
                conciliacion.moneda = grupoConciliacion.moneda;                      
                conciliacion.saldoVenta.setStringMoney(forma.tbSaldo.Text);
                conciliacion.saldoComision.setStringMoney(forma.tbComision.Text);
                conciliacion.fechaInicio.setFecha(forma.dtFechaInicio.Value);
                conciliacion.fechaFin.setFecha(forma.dtFechaFin.Value);
                conciliacion.documento.Value = forma.tbDocumento.Text;
                conciliacion.setId();
                dialogResultOk= true;
                return conciliacion.validar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }
        protected void cerrarFormulario()
        {           
            forma.DialogResult= DialogResult.OK;
            forma.Close();
        }
        private void dtFechaFin_ValueChanged(object sender, EventArgs e)
        {
            forma.dtFechaInicio.MaxDate = forma.dtFechaFin.Value;
        }
        private void dtFechaInicio_ValueChanged(object sender, EventArgs e)
        {
            forma.dtFechaFin.MinDate = forma.dtFechaInicio.Value;
        }

        private string saldoAnterior = "";
        private string comisionAnterior = "";
        private void tbSaldo_Enter(object sender, EventArgs e)
        {            
            saldoAnterior = forma.tbSaldo.Text;
        }
        private void tbSaldo_Leave(object sender, EventArgs e)
        {
            Atributo_Money atributo_Money = AtributoFactory.buildMoney(forma.tbSaldo.Text);
            forma.tbSaldo.Text = (atributo_Money.isValido) ? atributo_Money.getValueAccount() : saldoAnterior;
        }
        private void tbComision_Enter(object sender, EventArgs e)
        {
            comisionAnterior = forma.tbComision.Text;
        }
        private void tbComision_Leave(object sender, EventArgs e)
        {
            Atributo_Money atributo_Comision = AtributoFactory.buildMoney(forma.tbComision.Text);
            forma.tbComision.Text = (atributo_Comision.isValido) ? atributo_Comision.getValueAccount() : comisionAnterior;
        }
    }
}

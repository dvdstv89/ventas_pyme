using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using System.Linq;

namespace NucleoEV.UIController
{
    internal class TiendaDepartamentoComercialUIController
    {
       
        public Tienda tienda { get; set; }
        protected TiendaUI forma = new TiendaUI();
        protected bool dialogResultOk;
        protected bool formularioModoModificar;              
        protected List<FormaPago> formasPagos;
      //  protected List<Complejo> complejos;
        protected List<Moneda> monedas;
        protected Session session;
        protected Complejo complejo;

        //public TiendaDepartamentoComercialUIController(Session session, Complejo complejo, Tienda tienda, GrupoTienda grupoTienda)
        //{
        //    try
        //    {
        //        this.grupoTienda= grupoTienda;
        //        this.session = session;
        //        this.tienda = tienda;
        //        this.dialogResultOk = false;
        //        this.formasPagos= FormaPagoData.getFormasPagos(tienda.grupoTienda.Objeto.isOnline.Value);
        //        this.complejo = complejo;
        //        this.monedas = MonedaData.getAllMonedas(tienda.grupoTienda.Objeto.isOnline.Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}      
        public virtual TiendaUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
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
            //session.temaAplication.inicializarBoton(ref forma.btnCancelar, TipoBoton.Normal);
            //session.temaAplication.inicializarFormDialog(ref forma);           
            //session.temaAplication.inicializarListView(ref forma.lwFormaPago);           
        }
        protected virtual void restablecerFormulario()
        {
            //forma.tbComplejo.Enabled = false;
            //forma.tbComplejo.Text = complejo.denominacion.Value;          
            LlenarComboMonedas();            
            LlenarListadoFormasPago();
        }
        protected void LlenarListadoFormasPago(Moneda moneda = null)
        {
            //if (moneda == null) this.formasPagos = FormaPagoData.getFormasPagos(tienda.grupoTienda.Objeto.isOnline.Value);
            //else this.formasPagos = FormaPagoData.getByMoneda(moneda);
            //forma.lwFormaPago.Items.Clear();            
            //for (int i = 0; i < formasPagos.Count; i++)
            //{
            //    ListViewItem item = new ListViewItem();   
            //    item.Text = formasPagos[i].getId().ToString();
            //    item.SubItems.Add(formasPagos[i].denominacion.Value);    
            //    item.Checked= true;
            //    forma.lwFormaPago.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
            //}
            //forma.lwFormaPago.Enabled = false;
        }
        private void LlenarComboMonedas()
        {
            //forma.cbMonedas.Items.Clear();
            //for (int i = 0; i < monedas.Count; i++)
            //{
            //    forma.cbMonedas.Items.Add(monedas[i].denominacion);
            //}
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
        protected bool actualizarTiendaDesdeFormulario()
        {
            try
            {
                //tienda.denominacion.Value = forma.tbTienda.Text;
                //tienda.idComplejo.Value = complejo.id.getValueAsInt();
                //tienda.moneda.setObjeto(monedas.FirstOrDefault(m => m.denominacion.Value == forma.cbMonedas.Text) ?? null);                             
                //tienda.ordenComercial.Value = (int)forma.tbOrden.Value;

                //List<string> emailList = new List<string>();
                //foreach (string item in forma.tbEmail.Lines)
                //{
                //    emailList.Add(item);
                //}
                //tienda.email.setEmail(emailList);

                //dialogResultOk = true;
                //return tienda.validar();
                return true;
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
    }
}

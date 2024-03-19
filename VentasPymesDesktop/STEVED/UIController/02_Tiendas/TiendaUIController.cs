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
    internal class TiendaUIController
    {
        protected Session session;
        public Tienda tienda { get; set; }
        protected TiendaUI forma = new TiendaUI();
        protected bool dialogResultOk;
        protected bool formularioModoModificar;

        protected Complejo complejoSeleccionado;
        //protected GrupoTienda grupoTiendaSeleccionado;
        protected Moneda monedaSeleccionado;

        protected List<FormaPago> listaFormasPagos;    
        protected List<Moneda> listaMonedas;
        //protected List<GrupoTienda> listaGrupoTiendas;
        protected List<Complejo> listaComplejos;

        public TiendaUIController(Session session, List<Complejo> listaComplejos, Tienda tienda)
        {
            try
            {
                this.session = session;
                this.tienda = tienda;
                this.dialogResultOk = false;   
                
                this.listaComplejos = listaComplejos;

                this.complejoSeleccionado = listaComplejos[0];
                UpdateListGrupoTiendas(listaComplejos[0]);
                //UpdateListMonedas(listaGrupoTiendas[0]);
                //UpdateListFormasPagos(listaGrupoTiendas[0]);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }  

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
            //session.temaAplication.inicializarBoton(ref forma.btnAbrir, TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref forma.btnCerrar, TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref forma.btnEliminar, TipoBoton.Normal);
            session.temaAplication.inicializarFormDialog(ref forma);           
            //session.temaAplication.inicializarListView(ref forma.lwFormaPago);     
        }
        protected virtual void restablecerFormulario()
        {
            LlenarComboComplejos();
            LlenarComboMonedas();            
            LlenarListadoFormasPago();
            LlenarComboGruposTienda();
            //forma.cbComplejo.Text = complejoSeleccionado.denominacion.Value;
            //forma.cbGrupoTienda.Text = grupoTiendaSeleccionado.denominacion.Value;
            //forma.cbMonedas.Text = monedaSeleccionado.denominacion.Value;           
        }
        protected void LlenarComboComplejos()
        {
            //forma.cbComplejo.Items.Clear();
            //for (int i = 0; i < listaComplejos.Count; i++)
            //{
            //    forma.cbComplejo.Items.Add(listaComplejos[i].ToString());
            //}
        }
        protected void LlenarListadoFormasPago(Moneda moneda = null)
        {
            //if (moneda == null) this.listaFormasPagos = FormaPagoData.getFormasPagos(grupoTiendaSeleccionado.isOnline.Value);
            //else this.listaFormasPagos = FormaPagoData.getByMoneda(moneda);
            //forma.lwFormaPago.Items.Clear();            
            //for (int i = 0; i < listaFormasPagos.Count; i++)
            //{
            //    ListViewItem item = new ListViewItem();   
            //    item.Text = listaFormasPagos[i].getId().ToString();
            //    item.SubItems.Add(listaFormasPagos[i].denominacion.Value);    
            //    item.Checked= true;
            //    forma.lwFormaPago.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
            //}
            //forma.lwFormaPago.Enabled = false;
        }
        protected void LlenarComboMonedas()
        {
            //forma.cbMonedas.Items.Clear();
            //for (int i = 0; i < listaMonedas.Count; i++)
            //{
            //    forma.cbMonedas.Items.Add(listaMonedas[i].denominacion);
            //}
        }
        protected void LlenarComboGruposTienda()
        {
            //forma.cbGrupoTienda.Items.Clear();
            //for (int i = 0; i < listaGrupoTiendas.Count; i++)
            //{
            //    forma.cbGrupoTienda.Items.Add(listaGrupoTiendas[i].ToString());
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
                //tienda.idComplejo.Value = complejoSeleccionado.id.getValueAsInt();
                //tienda.moneda.setObjeto(listaMonedas.FirstOrDefault(m => m.denominacion.Value == forma.cbMonedas.Text) ?? null);                  
                //tienda.ordenComercial.Value = (int)forma.tbOrden.Value;
                //tienda.cantidadMaximaTrabajadores.Value = (int)forma.tbMaximoTrabajadores.Value;
                //tienda.cantidadRealTrabajadores.Value = (int)forma.tbCantidadDependientes.Value;
                //tienda.cantidadJefeBrigada.Value = (int)forma.tbCantdadJefesBrigadas.Value;
                //tienda.grupoTienda.setObjeto(grupoTiendaSeleccionado);

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
        private void UpdateListGrupoTiendas(Complejo complejo)
        {
            //this.listaGrupoTiendas = GrupoTiendaData.getGrupoTiendasByIdComplejo(complejo.id.Value);
            //this.grupoTiendaSeleccionado = listaGrupoTiendas[0];
        }       
    }
}

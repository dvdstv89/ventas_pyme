using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using NucleoEV.UIController.Component;

namespace NucleoEV.UIController
{
    internal class DetallesParteVentaAmpliadoUIController
    {   
        DateTime fecha;
        Tienda tienda;
        Moneda monedaByDefault;
        DataGridDetallesVentas dataGridDetallesVentas;
        Session session;
        DetallesVentaUI forma;
        public DetallesParteVentaAmpliadoUIController(Session session, List<ParteVentaDiario> partesVentasDiarios, DateTime fecha, Tienda tienda)
        {
            this.session = session;
            this.tienda = tienda;
            this.fecha = fecha;
            monedaByDefault = MonedaData.getMonedaByDefaul(tienda.moneda.Objeto.getIsOnline());                       
            forma = new DetallesVentaUI();
            dataGridDetallesVentas = new DataGridDetallesVentas(forma.lwParteVenta, partesVentasDiarios, monedaByDefault);
            forma.panelContainerDataGrid.Controls.Add(dataGridDetallesVentas.panel);
        }      
        public DetallesVentaUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.btnCancelar.Click += new EventHandler(btnCancelar_Click);                   
            return forma;
        }
        void forma_Load(object sender, EventArgs e)
        {            
            forma.dtFecha.Enabled = false;
            forma.tbTienda.Enabled = false;
            forma.tbMonedaDeLaTienda.Enabled = false;
            forma.tbComplejo.Enabled = false;

            forma.dtFecha.Value = fecha;
            forma.tbTienda.Text = tienda.denominacion.Value;
            forma.tbMonedaDeLaTienda.Text = tienda.moneda.Objeto.denominacion.Value;
            forma.tbComplejo.Text = ComplejoData.getComplejoById(tienda.idComplejo.Value).denominacion.Value;
            aplicarTema();
        }        
        protected void aplicarTema()
        {
            forma.Text = "Detalles de la venta del dia "+ fecha.ToShortDateString();           
            session.temaAplication.inicializarBoton(ref forma.btnCancelar, TipoBoton.Normal);                        
            forma.BackColor = session.temaAplication.subFormularioBgColor();
                                 
        }     
       
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                forma.DialogResult = DialogResult.Cancel;
                return;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }       
    }
}

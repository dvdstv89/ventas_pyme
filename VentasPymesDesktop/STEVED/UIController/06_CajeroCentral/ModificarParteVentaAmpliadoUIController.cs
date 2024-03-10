using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using NucleoEV.UIController.Component;
using ModelData.Service.LocalDatabaseClient;

namespace NucleoEV.UIController
{
    internal class ModificarParteVentaAmpliadoUIController
    {        
        List<FormaPago> formasPago;
        DateTime fecha;
        Tienda tienda;
        Moneda monedaByDefault;
        DataGridModificarVentasComision dataGridModificarVentas;
        Session session;
        ModificarParteVentaAmpliadoUI forma;
        public ModificarParteVentaAmpliadoUIController(Session session, List<ParteVentaDiario> partesVentasDiarios, DateTime fecha, Tienda tienda)
        {
            this.session = session;
            this.tienda = tienda;
            this.fecha = fecha;
            monedaByDefault = MonedaData.getMonedaByDefaul(tienda.moneda.Objeto.getIsOnline());
            formasPago = FormaPagoData.getByMoneda(tienda.moneda.Objeto);            
            forma = new ModificarParteVentaAmpliadoUI();
            dataGridModificarVentas = new DataGridModificarVentasComision(forma.lwParteVenta, formasPago, partesVentasDiarios, fecha, tienda);
            forma.panelContainerDataGrid.Controls.Add(dataGridModificarVentas.panel);
        }      
        public ModificarParteVentaAmpliadoUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            forma.btnGuardar.Click += new EventHandler(btnGuardar_Click);         
            return forma;
        }
        void forma_Load(object sender, EventArgs e)
        {            
            forma.dtFecha.Enabled = false;
            forma.dtFecha.Value = fecha;
            forma.lbMonedaDeLaTienda.Text = monedaByDefault.denominacion.Value;           
            aplicarTema();
        }        
        protected void aplicarTema()
        {
            forma.Text = "Parte de venta de la tienda: " + tienda.denominacion + " del dia "+ fecha.ToShortDateString();           
            session.temaAplication.inicializarBoton(ref forma.btnCancelar, TipoBoton.Normal);
            session.temaAplication.inicializarBoton(ref forma.btnGuardar, TipoBoton.Normal);            
            forma.BackColor = session.temaAplication.subFormularioBgColor();
            forma.lbComplejo.Text = tienda.denominacion.Value;                      
        }      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {    
                List<ParteVentaDiario> partesVentas = dataGridModificarVentas.getPartesVentas(session.getTokenId());
                HashSet<Conciliacion> conciliacions = new HashSet<Conciliacion>();
                foreach (ParteVentaDiario parte in partesVentas)
                {                    
                    //buscar conciliacion
                    Conciliacion conciliacion = new ConciliacionLDB().findByParteVenta(parte);
                    //calcular comision
                    parte.setComision();
                    //asignar conciliacion
                    if (conciliacion != null)
                    {
                        parte.idConsiliacion.Value = conciliacion.id.Value;
                        conciliacions.Add(conciliacion);
                    }
                }

                new ParteVentaDiarioLDB().guardarList(partesVentas);
                foreach (Conciliacion conciliacion in conciliacions)
                {
                    conciliacion.partesVentas = new ParteVentaDiarioLDB().revisarConciliacion(conciliacion);
                    new ConciliacionLDB().update(conciliacion);
                }
                session.sincronizarParteVenta();
                session.sincronizarConciliacion();

                if (partesVentas.Count > 0)
                {
                    new MensajeBox().modificacionOk();
                    forma.DialogResult = DialogResult.OK;
                }
                else
                {
                    forma.DialogResult = DialogResult.Cancel;
                }
                forma.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
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

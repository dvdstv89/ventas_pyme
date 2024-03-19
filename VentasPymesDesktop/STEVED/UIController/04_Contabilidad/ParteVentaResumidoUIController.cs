using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using NucleoEV.UIController.Component;
using ModelData.Service.LocalDatabaseClient;
using ModelData;


namespace NucleoEV.UIController
{
    internal class ParteVentaResumidoUIController
    {      
        Complejo complejo;
        List<Tienda> tiendas;
        List<FormaPago> formasPago;
        ParteVentaResumidoUI forma;
        Moneda monedaByDefault;
        Moneda monedaDeLaTienda;
        DateTime fecha;       
        DataGridPartesVentas dataGridPartesVentas;
        Session session;      
        //public ParteVentaResumidoUIController(Session session, Complejo complejo, GrupoTienda grupoTienda, Moneda moneda)
        //{           
        //    this.session = session;
        //    this.complejo= complejo;
        //    monedaByDefault = MonedaData.getMonedaByDefaul(grupoTienda.isOnline.Value);
        //    monedaDeLaTienda = MonedaData.getMoneda(moneda, grupoTienda.isOnline.Value);            
        //    tiendas = complejo.tiendas.FindAll(t=>t.moneda.getId() == monedaDeLaTienda.getId());
        //    formasPago = FormaPagoData.getByMoneda(monedaDeLaTienda, true);         
        //    forma = new ParteVentaResumidoUI();
        //    dataGridPartesVentas = new DataGridPartesVentas(forma.lwParteVenta, formasPago, tiendas);
        //    forma.panelContainerDataGrid.Controls.Add(dataGridPartesVentas.panel);
        //}      
        public ParteVentaResumidoUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            forma.btnGuardar.Click += new EventHandler(btnGuardar_Click);
            forma.cbPonerFechaManual.CheckedChanged += new EventHandler(cbPonerFechaManual_CheckedChanged);
            forma.cbIntroducirDatosEnMonedaByDefault.CheckedChanged += new EventHandler(cbIntroducirDatosEnMonedaByDefault_CheckedChanged);
            return forma;
        }
        void forma_Load(object sender, EventArgs e)
        {
            try
            {
                inicializarFecha();
                //forma.lbMonedaDeLaTienda.Text = monedaDeLaTienda.denominacion.Value;
                forma.lbNotaInformativa.Visible = false;
                forma.cbIntroducirDatosEnMonedaByDefault.Visible = false;
                forma.cbIntroducirDatosEnMonedaByDefault.Checked = true;
                //if (monedaDeLaTienda != monedaByDefault)
                //{
                //    cbIntroducirDatosEnMonedaByDefault_CheckedChanged(sender, e);
                //    forma.cbIntroducirDatosEnMonedaByDefault.Visible = true;
                //    forma.cbIntroducirDatosEnMonedaByDefault.Checked = false;
                //    forma.cbIntroducirDatosEnMonedaByDefault.Text = "Introducir ventas en " + monedaByDefault.denominacion;

                //}
                aplicarTema();
            }
            catch
            {            
                btnCancelar_Click(sender, e);
            } 
        }  
        private void inicializarFecha()
        {
            try
            {
                //fecha = complejo.getFechaUltimoParteVenta(monedaDeLaTienda,true).Fecha;
                fecha = (fecha < VariablesEntorno.primeraFechaValida) ? VariablesEntorno.primeraFechaValida : fecha.AddDays(1);
                forma.dtFecha.Enabled = false;
                //if (fecha.Month > VariablesEntorno.mesAbierto.Value)
                //    fecha = VariablesEntorno.ultimaFechaValida;
                forma.dtFecha.MinDate = fecha;
                forma.dtFecha.MaxDate = VariablesEntorno.ultimaFechaValida;
                forma.dtFecha.Value = fecha;
            }
            catch
            {
                new MensajeBox().parteDeVentaFail();
                throw;
            } 
        }
        private void cbPonerFechaManual_CheckedChanged(object sender, EventArgs e)
        {
            forma.dtFecha.Enabled = forma.cbPonerFechaManual.Checked;
            if(!forma.cbPonerFechaManual.Checked)
            {
                forma.dtFecha.Value = fecha;                
            }            
        }
        private void cbIntroducirDatosEnMonedaByDefault_CheckedChanged(object sender, EventArgs e)
        {
            //forma.lbNotaInformativa.Text = "Los valores se introducirán en "+ monedaDeLaTienda.denominacion+ " pero se convertirán autamaticamente a "+ monedaByDefault.denominacion+ " al cambio de 1 X "+ monedaDeLaTienda.tazaCambioRespectoDefecto;
            forma.lbNotaInformativa.Visible = !forma.cbIntroducirDatosEnMonedaByDefault.Checked;
        }
        protected void aplicarTema()
        {
            //forma.Text = "Parte de venta del complejo: " + complejo.denominacion;           
            //session.temaAplication.inicializarBoton(ref forma.btnCancelar, TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref forma.btnGuardar, TipoBoton.Normal);
            //session.temaAplication.inicializarFormDialog(ref forma);
            //forma.lbComplejo.Text = complejo.denominacion.Value;                      
        }      
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {               
                DateTime fechaPartesVentas = (forma.cbPonerFechaManual.Checked) ? forma.dtFecha.Value : fecha;
                //decimal multiplicarSaldoX = (forma.cbIntroducirDatosEnMonedaByDefault.Checked) ? 1 : monedaDeLaTienda.tazaCambioRespectoDefecto.MoneyAccount;
                //List<ParteVentaDiario> partesVentas = dataGridPartesVentas.getPartesVentas(fechaPartesVentas,session.getTokenId(), multiplicarSaldoX);                
                //new ParteVentaDiarioLDB().guardarList(partesVentas);
                //session.sincronizarParteVenta();
                //if (partesVentas.Count > 0)
                //{
                //    new MensajeBox().modificacionOk();
                //    forma.DialogResult = DialogResult.OK;
                //}
                //else
                //{
                //    forma.DialogResult = DialogResult.Cancel;
                //}
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

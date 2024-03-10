using ModelData.Model;
using NucleoEV.Model;
using System.Collections.Generic;
using System.Windows.Forms;
using System;
using NucleoEV.Tema;
using NucleoEV.UI;
using NucleoEV.UIController.Component;
using ModelData.Service.LocalDatabaseClient;
using System.Linq;
using ModelData;

namespace NucleoEV.UIController
{
    internal class PlanVentaUIController
    {
        Tienda tienda;
        PlanVentaUI forma;              
        Session session;
        DataGridPlanVentas dataGridPlanVentas;
        List<PlanVentaMensual> planesOriginales;
        List<PlanVentaMensual> planesCopia;
        public PlanVentaUIController(Session session, Tienda tienda)
        {
            this.session = session;          
            this.tienda = tienda;
            forma = new PlanVentaUI();
            planesOriginales = tienda.planesVentas;
            planesCopia = planesOriginales.Select(plan => (PlanVentaMensual)plan.Clone()).ToList();            
            dataGridPlanVentas = new DataGridPlanVentas(forma.lwPlanVenta, planesCopia, MonedaData.getMonedaByDefaul(tienda.grupoTienda.Objeto.isOnline.Value));
        }      
        public PlanVentaUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.btnCancelar.Click += new EventHandler(btnCancelar_Click);
            forma.btnGuardar.Click += new EventHandler(btnGuardar_Click);           
            return forma;
        }
        void forma_Load(object sender, EventArgs e)
        {
            aplicarTema();           
        }
        protected void aplicarTema()
        {
            forma.Text = "Planes de venta de la tienda: " + tienda.denominacion;
            session.temaAplication.inicializarBoton(ref forma.btnCancelar, TipoBoton.Normal);
            session.temaAplication.inicializarBoton(ref forma.btnGuardar, TipoBoton.Normal);            
            session.temaAplication.inicializarFormDialog(ref forma);
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                List<PlanVentaMensual> planesParaActualizar = new List<PlanVentaMensual>();
                planesCopia = dataGridPlanVentas.getPlanesVentas();                
                foreach (PlanVentaMensual copia in planesCopia)
                {
                    PlanVentaMensual planParaActualizar = planesOriginales.Find(original => original.fecha.Mes.Value == copia.fecha.Mes.Value && original.saldo.Value != copia.saldo.Value);
                    if(planParaActualizar!= null)
                    {
                        copia.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                        planesParaActualizar.Add(copia);
                    }
                }
                new PlanVentaMensualLDB().updateList(planesParaActualizar);              
                session.sincronizarPlanVentaDelAnnoAbierto();
                if (planesParaActualizar.Count > 0)
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

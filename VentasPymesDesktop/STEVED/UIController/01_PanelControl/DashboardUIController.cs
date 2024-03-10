using ModelData;
using ModelData.Model;
using NucleoEV.Model;
using NucleoEV.UI;
using System;

using System.Windows.Forms;

namespace NucleoEV.UIController
{
    internal class DashboardUIController : BaseUIController, IController<DashboardUI>
    {       
        public DashboardUIController(Session session) : base(session, new DashboardUI())
        {
            try
            {
                      
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public DashboardUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);                     
            return getForma();
        }
        void forma_Load(object sender, EventArgs e)
        {
            aplicarTema();
            restablecerFormulario();
        }
        void aplicarTema()
        {           
            forma.BackColor = session.temaAplication.formularioBgColor();
        }
        void restablecerFormulario()
        {

            getForma().lbTitlePlanMes.Text = "Plan del mes de " + session.periodoAbierto.mesAbierto.ToString();
            getForma().lbPlanMesActual.Text = session.empresa.getPlanVentasMes(VariablesEntorno.mesAbierto.Value).getMoneyFormated();

            getForma().lbTitlePlanAnno.Text = "Plan del " + session.periodoAbierto.annoAbierto.ToString();
            getForma().lbPlanAnno.Text = session.empresa.getPlanVentasAnno().getMoneyFormated();

            getForma().lbTitleVentasMesResumidas.Text = "Ventas Resumidas del mes de " + session.periodoAbierto.mesAbierto.ToString();
            getForma().lbVentasRealesMesResumidas.Text = session.empresa.getVentasRealesResumidasMesActual().getMoneyFormated();

            getForma().lbTitleVentasAnnoResumidas.Text = "Ventas Resumidas del " + session.periodoAbierto.annoAbierto.ToString();
            getForma().lbVentasRealesAnnoResumidas.Text = session.empresa.getVentaRealesResumidasAnno().getMoneyFormated();

            getForma().lbTitleVentasMesDetalladas.Text = "Ventas Detalladas del mes de " + session.periodoAbierto.mesAbierto.ToString();
            getForma().lbVentasRealesMesDetalladas.Text = session.empresa.getVentasRealesDetalladasMesActual().getMoneyFormated();

            getForma().lbTitleVentasAnnoDetalladas.Text = "Ventas Detalladas del " + session.periodoAbierto.annoAbierto.ToString();
            getForma().lbVentasRealesAnnoDetalladas.Text = session.empresa.getVentaRealesDetalladasAnno().getMoneyFormated();
        }
           
       
       public DashboardUI getForma()
        {
            return forma as DashboardUI;
        }
    }
}

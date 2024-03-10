using ModelData.Model;
using NucleoEV.UI;
using NucleoEV.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NucleoEV.Service;

namespace NucleoEV.UIController
{
    internal class ReporteUIController : BaseUIController, IController<ReporteUI>
    {    
        MainUIController mainUI;
        public ReporteUIController(Session session, MainUIController mainUI) :base(session, new ReporteUI())
        {
            try
            {    
                this.mainUI = mainUI;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }
        public ReporteUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);                   
            return getForma();
        }

        void forma_Load(object sender, EventArgs e)
        {
            aplicarTema(); 
        }

        void aplicarTema()
        {
            forma.BackColor = session.temaAplication.formularioBgColor();
                  
        } 
        public ReporteUI getForma()
        {
            return forma as ReporteUI;
        }
    }   
}

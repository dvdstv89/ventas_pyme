using ModelData.Model;
using NucleoEV.UI;
using NucleoEV.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NucleoEV.Service;

namespace NucleoEV.UIController
{
    internal class ElectricidadUIController : BaseUIController, IController<ElectricidadUI>
    {    
        MainUIController mainUI;
        public ElectricidadUIController(Session session, MainUIController mainUI) :base(session, new ElectricidadUI())
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
        public ElectricidadUI Ejecutar()
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
        public ElectricidadUI getForma()
        {
            return forma as ElectricidadUI;
        }
    }   
}

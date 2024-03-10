using ModelData.Model;
using NucleoEV.UI;
using NucleoEV.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using NucleoEV.Service;

namespace NucleoEV.UIController
{
    internal class InformacionUIController: BaseUIController, IController<InformacionUI>
    {      
        List<InformacionModulos> informacionModulos;
        MainUIController mainUI;
        public InformacionUIController(Session session, MainUIController mainUI) :base(session, new InformacionUI())
        {
            try
            {               
                informacionModulos = new InformacionModulosService().getInformacionModulos();        
                this.mainUI = mainUI;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }           
        }

        public InformacionUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);                   
            return getForma();
        }

        void forma_Load(object sender, EventArgs e)
        {
            aplicarTema(); 
            LlenarListadoModulos();
        }

        void aplicarTema()
        {
            forma.BackColor = session.temaAplication.formularioBgColor();
            session.temaAplication.inicializarListView(ref getForma().lwModulos);          
        }      
      
        private void LlenarListadoModulos()
        {
            getForma().lwModulos.Items.Clear();  
            for (int i = 0; i < informacionModulos.Count; i++)
            {
                ListViewItem item = new ListViewItem(informacionModulos[i].nombre);                                  
                item.SubItems.Add(informacionModulos[i].version.ToString());
                item.SubItems.Add(informacionModulos[i].fecha.ToShortDateString());
                getForma().lwModulos.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
            }
        }     

        public InformacionUI getForma()
        {
            return forma as InformacionUI;
        }
    }   
}

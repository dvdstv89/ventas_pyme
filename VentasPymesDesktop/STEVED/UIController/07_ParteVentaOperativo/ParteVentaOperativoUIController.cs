﻿using ModelData.Model;
using NucleoEV.UI;
using NucleoEV.Model;
using System;
using System.Collections.Generic;
using System.Windows.Forms;


namespace NucleoEV.UIController
{
    internal class ParteVentaOperativoUIController : BaseUIController, IController<ParteVentaOperativoUI>
    {    
        MainUIController mainUI;
        public ParteVentaOperativoUIController(Session session, MainUIController mainUI) :base(session, new ParteVentaOperativoUI())
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
        public ParteVentaOperativoUI Ejecutar()
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
        public ParteVentaOperativoUI getForma()
        {
            return forma as ParteVentaOperativoUI;
        }
    }   
}

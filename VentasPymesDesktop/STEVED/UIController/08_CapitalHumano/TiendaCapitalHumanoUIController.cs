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
    internal class TiendaCapitalHumanoUIController
    {
      
        public Tienda tienda { get; set; }
        protected TiendaUI forma = new TiendaUI();
        protected bool dialogResultOk;
        protected bool formularioModoModificar;              
        protected List<FormaPago> formasPagos;
      //  protected List<Complejo> complejos;
        protected List<Moneda> monedas;
        protected Session session;
        protected Complejo complejo;

       
      
       
       
    }
}

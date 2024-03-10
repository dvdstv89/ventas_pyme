using NucleoEV.UI;
using NucleoEV.Model;
using System.Collections.Generic;
using System;

namespace NucleoEV.UIController
{
    public interface IController<Tipo>
    {
        Tipo getForma();
        Tipo Ejecutar();       
    }
}

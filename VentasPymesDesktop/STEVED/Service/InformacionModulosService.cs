using NucleoEV.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NucleoEV.Service
{
    internal class InformacionModulosService
    {
        public List<InformacionModulos> getInformacionModulos()
        {
            List<InformacionModulos> informacionModulos = new List<InformacionModulos>();
            InformacionModulos informacion = new InformacionModulos();
            informacion.version = Database.InfoDll.version;
            informacion.nombre = Database.InfoDll.nombre;
            informacion.fecha = Database.InfoDll.fecha;
            informacion.autor = Database.InfoDll.autor;
            informacionModulos.Add(informacion);

            informacion = new InformacionModulos();
            informacion.version = NucleoEV.InfoDll.version;
            informacion.nombre = NucleoEV.InfoDll.nombre;
            informacion.fecha = NucleoEV.InfoDll.fecha;
            informacion.autor = NucleoEV.InfoDll.autor;
            informacionModulos.Add(informacion);

            informacion = new InformacionModulos();
            informacion.version = ModelData.InfoDll.version;
            informacion.nombre = ModelData.InfoDll.nombre;
            informacion.fecha = ModelData.InfoDll.fecha;
            informacion.autor = ModelData.InfoDll.autor;
            informacionModulos.Add(informacion);

            informacion = new InformacionModulos();
            informacion.version = LocalData.InfoDll.version;
            informacion.nombre = LocalData.InfoDll.nombre;
            informacion.fecha = LocalData.InfoDll.fecha;
            informacion.autor = LocalData.InfoDll.autor;
            informacionModulos.Add(informacion);
            return informacionModulos;
        }
    }
}

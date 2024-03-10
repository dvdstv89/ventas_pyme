using ModelData.Model;
using NucleoEV.Model;
using System;
using System.Collections.Generic;

namespace NucleoEV.Controller
{
    public  class CerrarPeriodoController
    {   
        public void cerrarMes(int mes)
        {
            try
            {
              // incrementar mes en la configuracion
              //indicar cambio en el versionado
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
           
        }
        public void cerrarAnno(int anno)
        {
            try
            {
                //desabilitar todos los planes de ventas del anno parametro
                //incrementar anno en configuracion
                //incrementar mes en la configuracion
                //indicar cambio en el versionado
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
    }
}

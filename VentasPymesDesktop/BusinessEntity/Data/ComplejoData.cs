using LocalData.Model;
using ModelData.Repository;
using ModelData.Service.LocalDatabaseClient;
using System.Collections.Generic;

namespace ModelData.Model
{
    public static class ComplejoData
    {
        static List<Complejo> complejos { get; set; } = new List<Complejo>();
        static void inicializar()
        {
            if (complejos.Count == 0)
            {
                complejos = new ComplejoLDB().getComplejos(VariablesEntorno.annoAbierto.Value, VariablesEntorno.securityToken.token.Value);
            }
        }
        public static Complejo getComplejoById(int id)
        {
            inicializar();
            return complejos.Find(x => x.id.getValueAsInt() == id);
        }
        public static List<Complejo> getByComplejosAutorizadosInSessionToken()
        {
            List<string> idComplejos = VariablesEntorno.securityToken.getIdComplejos();
            inicializar();
            List<Complejo> complejosAutorizados = new List<Complejo>();
            for (int i = 0; i < idComplejos.Count; i++)
            {
                Complejo aux = complejos.Find(c => c.getId() == idComplejos[i]);
                if (aux != null) complejosAutorizados.Add(aux);
            }
            return complejosAutorizados;
        }
        public static List<Complejo> getByComplejosTiendasAutorizadosInSessionToken()
        {
            List<string> idComplejos = VariablesEntorno.securityToken.getIdComplejos();
            inicializar();
            List<Complejo> complejosAutorizados = new List<Complejo>();
            for (int i = 0; i < idComplejos.Count; i++)
            {
                Complejo aux = complejos.Find(c => c.getId() == idComplejos[i] && c.tipoDepartamento.Objeto.isAlmacen.Value == false);
                if (aux != null) complejosAutorizados.Add(aux);
            }
            return complejosAutorizados;
        }
        public static List<Complejo> getAllComplejos()
        {
            inicializar();
            return complejos;
        }
    }
}

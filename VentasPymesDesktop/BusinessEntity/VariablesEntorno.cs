using Database.Class;
using ModelData.Model;
using System;

namespace ModelData
{
    public static class VariablesEntorno
    {
        public static readonly int idEmpresaPorDefecto = 1;
       
        public static readonly Atributo_PK<int> idConfiguracionSistema = new Atributo_PK<int>(1, "id");
        public static readonly Atributo_PK<int> idPeriodoAbierto = new Atributo_PK<int>(1, "id");

      
        public static readonly int idMonedaCUP = 1;
        public static readonly int idMonedaMLC = 2;
        public static readonly int idMonedaMLC_ONLINE = 3;
        public static readonly int idMonedaCUP_ONLINE = 4;
        public static readonly string dataGridMoneyString = "N8";
        public static DateTime primeraFechaValida;
        public static DateTime ultimaFechaValida;       
        public static Atributo_Anno annoAbierto;
        public static Atributo_Mes mesAbierto;
        public static string conectionStringPostgres;
        public static readonly string conectionStringLocal = string.Empty;
        public static SecurityToken securityToken;
        public static readonly bool sendMail = false;
    }
}

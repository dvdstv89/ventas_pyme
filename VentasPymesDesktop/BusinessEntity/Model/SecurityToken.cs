using Database;
using Database.Class;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;

namespace ModelData.Model
{   
    public class SecurityToken : BaseModelPro<SecurityToken,string>, ISincronizable<SecurityToken,string>
    {             
        public Atributo_PK<int> empresa { get; set; } = new Atributo_PK<int>("empresa");
        public Atributo<string> complejos { get; set; } = new Atributo<string>("complejos");
        public Atributo<string> permisos { get; set; } = new Atributo<string>("permisos");
        public Atributo<string> grupoTiendas { get; set; } = new Atributo<string>("grupos_tiendas");
        public Atributo<string> gruposConciliacion { get; set; } = new Atributo<string>("grupos_conciliaciones");
        public Atributo<string> token { get; set; } = new Atributo<string>("token");
        public Atributo<string> denominacion { get; set; } = new Atributo<string>("denominacion");
        public Atributo<string> mac { get; set; } = new Atributo<string>("mac");
        public Atributo<string> namePC { get; set; } = new Atributo<string>("pc_name");
        public Atributo<bool> superadmin { get; set; } = new Atributo<bool>("super");
        public SecurityToken()
        {
            setTabla();
        }
        public SecurityToken(string tokenId) : base(tokenId)
        {           
            token.Value = generarTokenSeguridad();
            empresa.Value = VariablesEntorno.idEmpresaPorDefecto;
            complejos.Value = "";
            grupoTiendas.Value = "";
            permisos.Value = "";
            gruposConciliacion.Value = "";
            namePC.Value = Environment.MachineName;
            mac.Value = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces().Select(nic => nic.GetPhysicalAddress().ToString()).FirstOrDefault();
            token.Value = generarTokenSeguridad();
            superadmin.Value = false;
        }
        public SecurityToken (DbDataReader sqlReader, TipoBaseDatos tipoBaseDatos) :base(sqlReader, tipoBaseDatos)
        {           
            this.token.setValue(sqlReader);
            this.empresa.setValue(sqlReader);
            this.complejos.setValue(sqlReader);
            this.grupoTiendas.setValue(sqlReader);
            this.gruposConciliacion.setValue(sqlReader);
            this.permisos.setValue(sqlReader);
            this.denominacion.setValue(sqlReader);
            this.mac.setValue(sqlReader);
            this.namePC.setValue(sqlReader);
            this.superadmin.setValue(sqlReader);
        }      
        private string generarTokenSeguridad()
        {
            string respuesta = string.Empty;
            Random random= new Random();
            string caracteres = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            int longitudToken = 16;
            for (int i = 0; i < longitudToken; i++)
            {
                char letra = caracteres[random.Next(caracteres.Length)];
                respuesta += letra;
            }
            return respuesta;
        }
        public override string ToString()
        {
            return token.Value;
        }
        public List<string> getIdComplejos()
        {
            List<string> result = new List<string>();
            string[] complejoList = complejos.Value.Split(',');
            foreach (var item in complejoList)
            {
                result.Add(item);
            }
            return result;
        }
        public List<string> getIdGrupoConsiliaciones()
        {
            List<string> result = new List<string>();
            if(gruposConciliacion == null) return result;
            string[] grupoList = gruposConciliacion.Value.Split(',');
            foreach (var item in grupoList)
            {
                result.Add(item);
            }
            return result;
        }
        public List<string> getIdPermisos()
        {
            List<string> result = new List<string>();
            string[] permisoList = permisos.Value.Split(',');
            foreach (var item in permisoList)
            {
                result.Add(item);
            }
            return result;
        }
        public List<string> getIdGrupoTienda()
        {
            List<string> result = new List<string>();
            string[] grupoTiendasList = grupoTiendas.Value.Split(',');
            foreach (var item in grupoTiendasList)
            {
                result.Add(item);
            }
            return result;
        }
        public bool validar()
        {
            if (denominacion.Value == "") return false;
            if(permisos.Value =="") return false;
            if (complejos.Value == "") return false;
            return true;           
        }
        protected new void setTabla()
        {
            tabla = new Tabla("security_token", "st");
        }
    }
}

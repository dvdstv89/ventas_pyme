using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExternalSystem.Fichero
{
    internal class File
    {      
        public Stream file { get; set; }
        public string path { get; set; }
        public File(string fileName = "config")
        {
            this.path = Environment.CurrentDirectory + "\\"+ fileName;
        }

        public void CrearFichero()
        {
            Stream file = System.IO.File.Create(path);
            file.Close();
        }

        public bool ExisteFichero()
        {
            return (System.IO.File.Exists(path)) ? true : false;
        }

        public void EliminarFichero()
        {
            System.IO.File.Delete(path);
        }

        public Object LeerFichero()
        {
            file = System.IO.File.Open(path, FileMode.OpenOrCreate);
            var binfor = new BinaryFormatter();
            Object objeto = binfor.Deserialize(file);
            CerrarFile();
            return objeto;
        }

        public void CerrarFile()
        {
            file.Close();
        }

        public void GuardarFichero(Object datos)
        {
            if (!ExisteFichero()) CrearFichero();
            var binfor = new BinaryFormatter();
            file = System.IO.File.Open(path, FileMode.Open);
            binfor.Serialize(file, datos);
            CerrarFile();
        }
    }
}

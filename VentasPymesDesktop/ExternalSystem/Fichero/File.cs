using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace ExternalSystem.Fichero
{
    internal class File
    {  
        public string path { get; set; }
        public File(string fileName = "config")
        {
            this.path = Environment.CurrentDirectory + "\\"+ fileName;
        }
         
        public bool ExisteFichero()
        {
            try
            {
                return (System.IO.File.Exists(path)) ? true : false;
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public void EliminarFichero()
        {
            try
            {
                System.IO.File.Delete(path);
            }
            catch (Exception)
            {
                throw;
            }            
        }

        public object LeerFichero()
        {
            try
            {
                using (var file = System.IO.File.Open(path, FileMode.OpenOrCreate))
                {
                    var binfor = new BinaryFormatter();
                    object objeto = binfor.Deserialize(file);
                    return objeto;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public FileSaveResult GuardarFichero(Object datos)
        {           
            try
            {               
                var binfor = new BinaryFormatter();
                bool archivoExistente = ExisteFichero();
                var file = System.IO.File.Open(path, archivoExistente ? FileMode.Append : FileMode.Create);
                binfor.Serialize(file, datos);
                file.Close();
                return archivoExistente ? FileSaveResult.OVERRIDED : FileSaveResult.CREATED;
            }
            catch (Exception)
            {
                throw;
            }                  
        }       
    }
}

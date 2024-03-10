using System;

namespace GlobalContracts.Model
{
    [Serializable]
    public class BaseDTO
    {        
        protected string EncritptarTexto(string texto)
        {           
            byte[] encrypted = System.Text.Encoding.Unicode.GetBytes(texto);
            return Convert.ToBase64String(encrypted);
        }

        protected string DesencriptarTexto(string texto)
        {         
            byte[] decrypted = Convert.FromBase64String(texto);
            return System.Text.Encoding.Unicode.GetString(decrypted);
        }
    }
}

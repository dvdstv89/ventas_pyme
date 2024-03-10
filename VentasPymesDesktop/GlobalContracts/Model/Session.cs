using System;
using System.Globalization;

namespace GlobalContracts.Model
{
    public class Session
    {      
        public int dominio { get; set; }
        public CultureInfo cultureInfo { get; set; } 
        public Session(CultureInfo cultureInfo)
        {              
            this.cultureInfo = cultureInfo;           
        }  
    }
}

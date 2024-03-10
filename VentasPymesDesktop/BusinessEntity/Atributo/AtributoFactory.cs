using Database.Class;
using System;

namespace ModelData.Atributo
{
    public static class AtributoFactory
    {
        public static Atributo_Money buildMoney(decimal saldo)
        {
            return new Atributo_Money(saldo);           
        }
        public static Atributo_Money buildMoney(string saldo)
        {
            return new Atributo_Money(saldo, "");           
        }
        public static Atributo_Porciento builPorciento(decimal saldo)
        {
           return new Atributo_Porciento(saldo);          
        }
        public static Atributo_Datetime builDateTime(DateTime fecha)
        {
            return new Atributo_Datetime(fecha);
        }
    }
}

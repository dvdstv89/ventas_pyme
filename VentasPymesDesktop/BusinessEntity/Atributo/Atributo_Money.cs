using Database;
using Database.Class;
using ModelData.Model;
using System;
using System.Data.Common;
using System.Globalization;
using System.Text.RegularExpressions;

namespace ModelData.Atributo
{
    public class Atributo_Money : Database.Class.Atributo_Money
    {
        Atributo_Moneda moneda;
        public bool isValido { get; set; }
        public Atributo_Money(string value, string columnName = "") : base(columnName)
        {
            this.isValido = tryMoney(value,out decimal saldo);
            if (isValido)
            {
                setMoney(saldo);
                moneda = new Atributo_Moneda(MonedaData.getMonedaByDefaul(), "");
            }
        }
        public Atributo_Money(string columnName) : base(columnName)
        {
            setMoney(0);
            moneda = new Atributo_Moneda(MonedaData.getMonedaByDefaul(), "");
        }
        public Atributo_Money(decimal value, string columnName = "") : base(columnName)
        {
            setMoney(value);
            moneda = new Atributo_Moneda(MonedaData.getMonedaByDefaul(), "");
        }       
        public new string getMoneyFormated()
        {
            return this.ValueVisual + " " + moneda.Objeto.denominacion;
        }
        public string getValueVisual()
        {
            return this.ValueVisual;
        }
        public string getValueAccount()
        {
            return String.Format(StringFormat.moneyString8, this.MoneyAccount, culture);         
        }        
        public Atributo_Porciento getValueVisualPorciento()
        {
            return new Database.Class.Atributo_Porciento(MoneyVisual);
        }
        public Atributo_Money getDiferencia(Atributo_Money minuendo)
        {
            return new Atributo_Money(MoneyAccount - minuendo.MoneyAccount);
        }
        public void SumarValue(decimal value)
        {
            value += MoneyAccount;
            setMoney(value);
        }
        public void setMoney(decimal value, Atributo_Moneda moneda)
        {
            base.setMoney(value);
            this.moneda = moneda;
        }
        public void setValue(DbDataReader sqlReader, Atributo_Moneda moneda)
        {
            base.setValue(sqlReader);
            this.moneda = moneda;
        }
        public decimal getSaldoMonedaByDefault()
        {    
            return MoneyAccount * moneda.Objeto.tazaCambioRespectoDefecto.MoneyAccount;
        }
        public Atributo_Money getMoneySinComision(Atributo_Money porcientoComision)
        {
            decimal valor = MoneyAccount * porcientoComision.MoneyAccount / 100;
            return new Atributo_Money(MoneyAccount - valor);
        }
        public Atributo_Money getComisionAplicada(Atributo_Money porcientoComision)
        {
            decimal valor = MoneyAccount * porcientoComision.MoneyAccount / 100;
            return new Atributo_Money(valor);
        }
        public string getMoneyFormatText()
        {               
            return StringFormat.moneyStringForExcel+" "+" [$" + moneda.Objeto.denominacion.Value + "]";
        }
    }
}

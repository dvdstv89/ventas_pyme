using ModelData;
using ModelData.Atributo;
using ModelData.Model;
using NucleoEV.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace NucleoEV.UIController.Component
{
    internal class DataGridPartesVentas: DataGridBaseComponent
    {       
        List<Tienda> tiendas;
        List<FormaPago> formasPago;
        public DataGridPartesVentas(DataGridView dataGrid, List<FormaPago> formasPago, List<Tienda> tiendas): base(dataGrid, "Tiendas", formasPago.Count)
        {
            this.tiendas = tiendas;
            this.formasPago = formasPago; 
            llenarDataTableByDefault();
            aplicarTema();
        } 
        private void llenarDataTableByDefault()
        {
            dibujarColumnas();
            llenarAreaDatosEditables();          
            llenarAreaTotales();
            dataGrid.DataSource = dataTable;                           
        }
        private void dibujarColumnas()
        {
            DataColumn column = new DataColumn(nombreColumnaPrincipal, typeof(string));
            column.ReadOnly = true;            
            dataTable.Columns.Add(column);

            foreach (FormaPago formaPago in formasPago)
            {
                DataColumn columnAux = new DataColumn(formaPago.denominacion.Value + " (" + formaPago.getComision().Value +")", typeof(decimal));
                dataTable.Columns.Add(columnAux);
            }
            if (!tieneUnaSolaColumnaDatos)
            {
                column = new DataColumn("Comisión", typeof(decimal));
                dataTable.Columns.Add(column);
                column = new DataColumn("Total", typeof(decimal));
                dataTable.Columns.Add(column);                             
            }
        }
        private void llenarAreaDatosEditables()
        {
            ModelData.Atributo.Atributo_Money atributo_Money = AtributoFactory.buildMoney(0);         
            foreach (Tienda tienda in tiendas)
            {
                int apuntador = 0;
                int cantidadColumnas = (!tieneUnaSolaColumnaDatos) ? cantidadColumnasEditables + 3 : cantidadColumnasEditables + 1;
                object[] objectsTotal = new object[cantidadColumnas];
                objectsTotal[apuntador++] = tienda.denominacion;                
                for (int j = 0; j < cantidadColumnas - 1; j++)
                {
                    objectsTotal[apuntador++] = atributo_Money.Value;                   
                }
                dataTable.Rows.Add(objectsTotal);
            }
        }
        private void llenarAreaTotales()
        {
            ModelData.Atributo.Atributo_Money atributo_Money = AtributoFactory.buildMoney(0);         
            int apuntador = 0;
            int cantidadColumnas = (!tieneUnaSolaColumnaDatos) ? cantidadColumnasEditables + 3 : cantidadColumnasEditables + 1;
            object[] objectsTotal = new object[cantidadColumnas];
            objectsTotal[apuntador++] = "Total";
            for (int j = 0; j < cantidadColumnas - 1; j++)
            {
                objectsTotal[apuntador++] = atributo_Money.Value;              
            }
            dataTable.Rows.Add(objectsTotal);
        }      
        public List<ParteVentaDiario> getPartesVentas(DateTime fecha, string tokenId, decimal multiplicarSaldoX = 1)
        {
            List<ParteVentaDiario> partes = new List<ParteVentaDiario>();
            for (int i = 0; i < tiendas.Count; i++)            
            {
                for (int j = 0; j < formasPago.Count; j++)
                {
                    ParteVentaDiario parte = new ParteVentaDiario(tokenId);
                    parte.fecha.setFecha(fecha);
                    parte.formaPago.setObjeto(formasPago[j]);
                    parte.idTienda.Value = tiendas[i].id.getValueAsInt();
                    parte.moneda.setObjeto(MonedaData.getMonedaByDefaul());
                    parte.saldo.setMoney((decimal)dataGrid[j + 1, i].Value * multiplicarSaldoX);
                    parte.setId();
                    if (parte.saldo.MoneyAccount > 0)
                        partes.Add(parte);
                }
            }   
            return partes;
        }       
        protected override void totalizarFila()
        {
            if (filaSeleccionada > -2 && !tieneUnaSolaColumnaDatos)
            {
                int indexColumnaTotal = dataGrid.Columns.Count - 1;
                decimal total = 0;
                for (int c = 1; c < indexColumnaTotal-1; c++)
                {
                    total += (decimal)dataGrid[c, filaSeleccionada].Value;
                }
                Atributo_Money atributo_Money = AtributoFactory.buildMoney(total);
                dataGrid[indexColumnaTotal-1, filaSeleccionada].Value = getComisionFila(filaSeleccionada).MoneyAccount;
                dataGrid[indexColumnaTotal, filaSeleccionada].Value = atributo_Money.getDiferencia(getComisionFila(filaSeleccionada)).MoneyAccount;
            }
        }
        protected override void totalizarGeneral()
        {
            if (columnaSeleccionada > -2 && !tieneUnaSolaColumnaDatos)
            {
                int indexFilaTotal = dataGrid.Rows.Count - 1;
                int indexColumnaTotal = dataGrid.Columns.Count - 1;
                decimal total = 0;
                for (int c = 1; c < indexColumnaTotal-1; c++)
                {
                    total += (decimal)dataGrid[c, indexFilaTotal].Value;
                }
                dataGrid[indexColumnaTotal - 1, indexFilaTotal].Value = getComisionFila(indexFilaTotal).MoneyAccount;
                Atributo_Money atributo_Money = AtributoFactory.buildMoney(total);
                dataGrid[indexColumnaTotal, indexFilaTotal].Value = atributo_Money.getDiferencia(getComisionFila(indexFilaTotal)).MoneyAccount;
            }
        }
        public Atributo_Money getComisionFila(int fila)
        {
            Atributo_Money comisionTotal = new Atributo_Money(0);
            for (int i = 0; i < formasPago.Count; i++)
            {
                decimal comision = formasPago[i].getComision().Porciento * (decimal)dataGrid[i + 1, fila].Value / 100;
                comisionTotal.SumarValue(comision);
            }
            return comisionTotal;
        }
    }
}

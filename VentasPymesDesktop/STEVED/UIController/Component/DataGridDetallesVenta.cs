using ModelData;
using ModelData.Atributo;
using ModelData.Model;
using NucleoEV.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NucleoEV.UIController.Component
{
    internal class DataGridDetallesVentas : DataGridBaseComponent
    {        
        List<ParteVentaDiario> partesVentasDiarios;
        Moneda monedaByDefault;
        public DataGridDetallesVentas(DataGridView dataGrid, List<ParteVentaDiario> partesVentasDiarios, Moneda monedaByDefault) : base(dataGrid, "Formas de pago", 1)
        {
            this.partesVentasDiarios = partesVentasDiarios;
            this.monedaByDefault = monedaByDefault;
            llenarDataTableByDefault();
            aplicarTema();
            dataGrid.CellValidating += new DataGridViewCellValidatingEventHandler(dataGrid_CellValidatingMoney);
            dataGrid.SelectionChanged += new EventHandler(dataGrid_SelectedIndexChanged);
        }
        private void llenarDataTableByDefault()
        {
            dibujarColumnas();
            llenarAreaDatosEditables();
            llenarAreaTotales();
            dataGrid.DataSource = dataTable;           
        }

        protected new void aplicarTema()
        {
            dataGrid.DefaultCellStyle.Format = dataGridMoneyString;
            dataGrid.AllowUserToOrderColumns = false;
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {
                dataGrid.Columns[i].HeaderCell.Style.Font = APP.fontHeader;
                dataGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGrid.Columns[i].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                dataGrid.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
            dataGrid.Rows[dataGrid.Rows.Count - 1].ReadOnly = true;
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGrid.Font = new Font("Arial", 11, FontStyle.Regular);
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.AutoSize = true;
        }
        private void dibujarColumnas()
        {
            DataColumn column = new DataColumn(nombreColumnaPrincipal, typeof(string));
            column.ReadOnly = true;
            dataTable.Columns.Add(column);
            column = new DataColumn("Vendido", typeof(string));
            column.ReadOnly = true;
            dataTable.Columns.Add(column);
        }
        private void llenarAreaDatosEditables()
        {
            foreach (ParteVentaDiario parte in partesVentasDiarios)
            {               
                object[] objectsTotal = new object[2];
                objectsTotal[0] = parte.formaPago.Objeto.denominacion.Value;
                objectsTotal[1] = parte.saldo.getMoneyFormated();
                dataTable.Rows.Add(objectsTotal);
            }           
        }
        private void llenarAreaTotales()
        {           
            object[] objectsTotal = new object[2];
            objectsTotal[0] = "Total";
            decimal total = partesVentasDiarios.Sum(p => p.saldo.MoneyAccount);
            ModelData.Atributo.Atributo_Money atributo_Money = AtributoFactory.buildMoney(total);
            objectsTotal[1] = atributo_Money.getMoneyFormated();
            dataTable.Rows.Add(objectsTotal);            
        }       
    }
}

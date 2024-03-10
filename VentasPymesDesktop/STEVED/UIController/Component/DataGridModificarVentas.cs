using Database.Class;
using ModelData;
using ModelData.Atributo;
using ModelData.Model;
using NucleoEV.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NucleoEV.UIController.Component
{
    internal class DataGridModificarVentas : DataGridBaseComponent
    {        
        List<ParteVentaDiario> partesVentasDiarios;
        List<FormaPago> formasPago;
        DateTime fecha;
        Tienda tienda;      
        public DataGridModificarVentas(DataGridView dataGrid, List<FormaPago> formasPago, List<ParteVentaDiario> partesVentasDiarios, DateTime fecha, Tienda tienda) : base(dataGrid, "Formas de pago", 1)
        {            
            this.partesVentasDiarios = partesVentasDiarios;
            this.formasPago = formasPago;
            this.fecha = fecha;
            this.tienda = tienda;
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
            TotalizarColumna(1);
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
            column = new DataColumn("Vendido", typeof(decimal));
            dataTable.Columns.Add(column);         
        }
        private void llenarAreaDatosEditables()
        {
            foreach (FormaPago formaPago in formasPago)
            {
                int apuntador = 0;
                object[] objectsTotal = new object[cantidadColumnasEditables + 1];
                objectsTotal[apuntador++] = formaPago.denominacion;
                ParteVentaDiario parteVentaDiario = partesVentasDiarios.Find(t => t.formaPago.getId() == formaPago.getId());
                ModelData.Atributo.Atributo_Money atributo_Money = AtributoFactory.buildMoney(0);
                objectsTotal[apuntador++] = (parteVentaDiario == null) ? atributo_Money.getValueVisual() : parteVentaDiario.saldoMasComision.getValueVisual();               
                dataTable.Rows.Add(objectsTotal);
            }            
        }
        private void llenarAreaTotales()
        {
            ModelData.Atributo.Atributo_Money atributo_Money = AtributoFactory.buildMoney(0);
            object[] objectsTotal = new object[2];
            objectsTotal[0] = "Total";
            objectsTotal[1] = atributo_Money.Value;           
            dataTable.Rows.Add(objectsTotal);            
        }

        public List<ParteVentaDiario> getPartesVentas(string tokenId)
        {
            List<ParteVentaDiario> partes = new List<ParteVentaDiario>();           
            for (int i = 0; i < formasPago.Count; i++)
            {
                ParteVentaDiario parteVentaDiario = partesVentasDiarios.Find(t => t.formaPago.getId() == formasPago[i].getId());
                if(parteVentaDiario!=null)
                {
                    parteVentaDiario.saldo.setMoney((decimal)dataGrid[1, i].Value);                  
                    parteVentaDiario.isEliminada.Value = (parteVentaDiario.saldo.MoneyAccount == 0) ? true : false;
                    partes.Add(parteVentaDiario);
                }
                else
                {
                    parteVentaDiario = new ParteVentaDiario(tokenId);
                    parteVentaDiario.fecha.setFecha(fecha);
                    parteVentaDiario.formaPago.setObjeto(formasPago[i]);
                    parteVentaDiario.idTienda.Value = tienda.id.getValueAsInt();
                    parteVentaDiario.moneda.setObjeto(MonedaData.getMonedaByDefaul());
                    parteVentaDiario.saldo.setMoney((decimal)dataGrid[1, i].Value);
                    parteVentaDiario.setId();
                    if (parteVentaDiario.saldo.MoneyAccount > 0)
                        partes.Add(parteVentaDiario);
                }              
            }
            return partes;
        }
    }
}

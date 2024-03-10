
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
    internal class DataGridModificarVentasComision : DataGridBaseComponent
    {        
        List<ParteVentaDiario> partesVentasDiarios;
        List<FormaPago> formasPago;
        DateTime fecha;
        Tienda tienda;       
        public DataGridModificarVentasComision(DataGridView dataGrid, List<FormaPago> formasPago, List<ParteVentaDiario> partesVentasDiarios, DateTime fecha, Tienda tienda) : base(dataGrid, "Formas de pago", 1)
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
            totalizarGeneral();
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
            column = new DataColumn("Saldo", typeof(decimal));
            dataTable.Columns.Add(column);
            column = new DataColumn("Comisión", typeof(decimal));
            dataTable.Columns.Add(column);
        }
        private void llenarAreaDatosEditables()
        {
            foreach (FormaPago formaPago in formasPago)
            {
                int apuntador = 0;
                object[] objectsTotal = new object[cantidadColumnasEditables + 3];
                objectsTotal[apuntador++] = formaPago.denominacion + " (" + formaPago.getComision().Value + ")";
                ParteVentaDiario parteVentaDiario = partesVentasDiarios.Find(t => t.formaPago.getId() == formaPago.getId());
                ModelData.Atributo.Atributo_Money atributo_Money = AtributoFactory.buildMoney(0);
                objectsTotal[apuntador++] = (parteVentaDiario == null) ? atributo_Money.getValueAccount() : parteVentaDiario.saldoMasComision.getValueAccount();
                objectsTotal[apuntador++] = (parteVentaDiario == null) ? atributo_Money.getValueAccount() : parteVentaDiario.saldo.getValueAccount();
                objectsTotal[apuntador++] = (parteVentaDiario == null) ? atributo_Money.getValueAccount() : parteVentaDiario.comision.getValueAccount();
                dataTable.Rows.Add(objectsTotal);
            }            
        }
        private void llenarAreaTotales()
        {
            ModelData.Atributo.Atributo_Money atributo_Money = AtributoFactory.buildMoney(0);
            object[] objectsTotal = new object[4];
            objectsTotal[0] = "Total";
            objectsTotal[1] = atributo_Money.Value;
            objectsTotal[2] = atributo_Money.getValueAccount();
            objectsTotal[3] = atributo_Money.getValueAccount();
            dataTable.Rows.Add(objectsTotal);            
        }
        public override void dataGrid_CellValidatingMoney(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                string valorAnterior = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                if (e.ColumnIndex > 1 && e.RowIndex != dataGrid.Rows.Count - 1)
                {
                    dataGrid[e.ColumnIndex, e.RowIndex].Value = valorAnterior;
                    valorEditadoCorrectamente = true;
                    columnaSeleccionada = e.ColumnIndex;
                    filaSeleccionada = e.RowIndex;
                    SendKeys.Send("{ESC}");
                }
               else if(e.ColumnIndex == 1 && e.RowIndex != dataGrid.Rows.Count - 1)
                {
                    valorAnterior = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
                    valorAnterior = (valorAnterior == "") ? "0.00" : valorAnterior;
                    Atributo_Money atributo_Money = buildMoney(e.FormattedValue.ToString());
                    dataGrid[e.ColumnIndex, e.RowIndex].Value = (atributo_Money.isValido) ? atributo_Money.MoneyAccount.ToString() : valorAnterior;
                    if (!atributo_Money.isValido)
                    {
                        e.Cancel = true;
                        valorEditadoCorrectamente = false;
                        columnaSeleccionada = -1;
                        filaSeleccionada = -1;
                        SendKeys.Send("{ESC}");
                    }
                    else
                    {
                        valorEditadoCorrectamente = true;
                        columnaSeleccionada = e.ColumnIndex;
                        filaSeleccionada = e.RowIndex;
                    }
                }
                else
                {
                    valorEditadoCorrectamente = false;
                    columnaSeleccionada = -1;
                    filaSeleccionada = -1;
                }
            }
            catch (Exception ex)
            {
                valorEditadoCorrectamente = false;
                columnaSeleccionada = -1;
                filaSeleccionada = -1;
                e.Cancel = true;
                MessageBox.Show(ex.Message);
                SendKeys.Send("{ESC}");
            }
        }
        protected override void totalizarFila()
        {
            decimal total = (decimal)dataGrid[1, filaSeleccionada].Value;
            Atributo_Money atributo_Money = AtributoFactory.buildMoney(total);
            Atributo_Money porcientoComision = formasPago[filaSeleccionada].grupoConciliacion.Objeto.comision;
            dataGrid[2, filaSeleccionada].Value = atributo_Money.getMoneySinComision(porcientoComision).getValueAccount();
            dataGrid[3, filaSeleccionada].Value = atributo_Money.getComisionAplicada(porcientoComision).getValueAccount();
        }
        protected override void TotalizarColumna(int columna = 1)
        {
            return;
        }
        protected override void totalizarGeneral()
        {
            int indexFilaTotal = dataGrid.Rows.Count - 1;
            Atributo_Money atributo_Money = AtributoFactory.buildMoney(0);
            Atributo_Money atributo_Comision = AtributoFactory.buildMoney(0);
            Atributo_Money total = AtributoFactory.buildMoney(0);
            for (int i = 0; i < formasPago.Count; i++)
            {
                Atributo_Money totalAux = AtributoFactory.buildMoney((decimal)dataGrid[1, i].Value);
                Atributo_Money porcientoComision = formasPago[i].grupoConciliacion.Objeto.comision;
                atributo_Money.SumarValue(totalAux.getMoneySinComision(porcientoComision).MoneyAccount);
                atributo_Comision.SumarValue(totalAux.getComisionAplicada(porcientoComision).MoneyAccount);
                total.SumarValue(totalAux.MoneyAccount);
            }
            dataGrid[1, indexFilaTotal].Value = total.MoneyAccount;
            dataGrid[2, indexFilaTotal].Value = atributo_Money.MoneyAccount;
            dataGrid[3, indexFilaTotal].Value = atributo_Comision.MoneyAccount;
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

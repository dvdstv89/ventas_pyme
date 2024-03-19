using ModelData;
using ModelData.Atributo;
using ModelData.Model;
using NucleoEV.Model;
using NucleoEV.UI;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace NucleoEV.UIController.Component
{
    internal class DataGridPlanVentas : DataGridBaseComponent
    {
        List<PlanVentaMensual> planVentaMensual;
        Moneda monedaByDefault;
       
        public DataGridPlanVentas(DataGridView dataGrid, List<PlanVentaMensual> planVentaMensual, Moneda monedaByDefault) : base(dataGrid, "Mes", 2)
        {            
            this.planVentaMensual = planVentaMensual;   
            this.monedaByDefault= monedaByDefault;
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
            dataGrid.Columns[0].ReadOnly = true;
            dataGrid.Columns[1].ReadOnly= true;        
            dataGrid.Rows[12].Cells[2].ReadOnly = true;            
            TotalizarColumna(2);           
        }
        protected new void aplicarTema()
        {
            dataGrid.MultiSelect = false;
            dataGrid.DefaultCellStyle.Format = dataGridMoneyString;
            dataGrid.AllowUserToOrderColumns = false;
            for (int i = 0; i < dataGrid.Columns.Count; i++)
            {               
                dataGrid.Columns[i].HeaderCell.Style.Font = APP.fontHeader;
                dataGrid.Columns[i].SortMode = DataGridViewColumnSortMode.NotSortable;
                dataGrid.Columns[i].HeaderCell.Style.Font = new Font("Arial", 12, FontStyle.Bold);
                dataGrid.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;               
            }         
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGrid.Font = new Font("Arial", 11, FontStyle.Regular);           
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dataGrid.AutoSize = true;
        }
        private void dibujarColumnas()
        {
            DataColumn column = new DataColumn(nombreColumnaPrincipal, typeof(string));           
            dataTable.Columns.Add(column);
            column = new DataColumn("Plan diario", typeof(string));           
            dataTable.Columns.Add(column);
            column = new DataColumn("Plan del mes", typeof(decimal));
            dataTable.Columns.Add(column);
        }
        private void llenarAreaDatosEditables()
        {
            foreach (PlanVentaMensual plan in planVentaMensual)
            {               
                object[] objectsTotal = new object[3];
                //objectsTotal[0] = plan.fecha.Mes.Mes+ " - " + VariablesEntorno.ultimaFechaValida.Year;
                //objectsTotal[1] = plan.planDiario.getMoneyFormated();
                //objectsTotal[2] = plan.saldo.MoneyAccount;
                dataTable.Rows.Add(objectsTotal);
            }            
        }
        private void llenarAreaTotales()
        {           
            object[] objectsTotal = new object[3];
            objectsTotal[0] = "Total Año " + VariablesEntorno.ultimaFechaValida.Year;
            //decimal saldo = planVentaMensual.Sum(p=>p.saldo.MoneyAccount);
            //ModelData.Atributo.Atributo_Money atributo_Saldo = AtributoFactory.buildMoney(saldo);
            //decimal planDiarioPromedio = saldo / VariablesEntorno.annoAbierto.CantidadDias;
            //ModelData.Atributo.Atributo_Money atributo_PlanDiarioPromedio = AtributoFactory.buildMoney(planDiarioPromedio);

            //objectsTotal[1] = atributo_PlanDiarioPromedio.getMoneyFormated();
            //objectsTotal[2] = atributo_Saldo.Value;
            dataTable.Rows.Add(objectsTotal);           
        }
        public List<PlanVentaMensual> getPlanesVentas()
        {                    
            for (int i = 0; i < planVentaMensual.Count; i++)
            {
                decimal saldo = (decimal)dataGrid[2, i].Value;
                //if (saldo != planVentaMensual[i].saldo.MoneyAccount)
                //{
                //    planVentaMensual[i].saldo.setMoney(saldo);                                   
                //}      
            }
            return planVentaMensual;
        }
        public new void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (valorEditadoCorrectamente)
                {
                    TotalizarColumna(2);
                    totalizarFila();
                    decimal saldo = (decimal)dataGrid[2, 12].Value;
                    //decimal planDiarioAnual = saldo / VariablesEntorno.annoAbierto.CantidadDias;
                    //ModelData.Atributo.Atributo_Money atributo_PlanDiarioAnual = AtributoFactory.buildMoney(planDiarioAnual);
                    //dataGrid[1, 12].Value = atributo_PlanDiarioAnual.getMoneyFormated();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected new void totalizarFila()
        {
            if (filaSeleccionada > -1 && filaSeleccionada < 12)
            {               
                int indexColumnaTotal = 1;
                //decimal planDiario = (decimal)dataGrid.Rows[filaSeleccionada].Cells[2].Value / Session.countDaysOfMounth(filaSeleccionada+1);
                //ModelData.Atributo.Atributo_Money atributo_Money = AtributoFactory.buildMoney(planDiario);
                //dataGrid[indexColumnaTotal, filaSeleccionada].Value = atributo_Money.getMoneyFormated();
            }
        }
        public new void dataGrid_CellValidatingMoney(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                string valorAnterior = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

                if (e.ColumnIndex == 2 && e.RowIndex == dataGrid.Rows.Count - 1)
                {
                    dataGrid[e.ColumnIndex, e.RowIndex].Value = valorAnterior;
                    valorEditadoCorrectamente = true;
                    columnaSeleccionada = e.ColumnIndex;
                    filaSeleccionada = e.RowIndex;
                    SendKeys.Send("{ESC}");                   
                }
                else if (e.ColumnIndex == 2 && e.RowIndex < dataGrid.Rows.Count - 1)
                {                  
                    valorAnterior = (valorAnterior == "") ? "0.00" : valorAnterior;                  
                    ModelData.Atributo.Atributo_Money atributo_Money = buildMoney(e.FormattedValue.ToString());                   
                    //dataGrid[e.ColumnIndex, e.RowIndex].Value = (atributo_Money.isValido) ? atributo_Money.MoneyAccount.ToString(): valorAnterior;
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
    }
}

using ModelData;
using ModelData.Atributo;
using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace NucleoEV.UIController.Component
{
    internal class DataGridBaseComponent
    {
        protected string dataGridMoneyString = VariablesEntorno.dataGridMoneyString;
        protected DataTable dataTable;
        protected DataGridView dataGrid;
        protected bool valorEditadoCorrectamente;
        protected int filaSeleccionada;
        protected int columnaSeleccionada;
        protected int cantidadColumnasEditables;
        protected string nombreColumnaPrincipal;
        protected bool tieneUnaSolaColumnaDatos;
        public Panel panel { get; set; }
        public DataGridBaseComponent(DataGridView dataGrid, string nombreColumnaPrincipal, int cantidadColumnasEditables)
        {
            tieneUnaSolaColumnaDatos = (cantidadColumnasEditables > 1) ? false : true;
            this.dataTable = new DataTable();
            this.dataGrid = dataGrid;
            this.dataGrid.Columns.Clear();
            this.valorEditadoCorrectamente = false;
            this.filaSeleccionada = -1;
            this.columnaSeleccionada = -1;
            this.nombreColumnaPrincipal = nombreColumnaPrincipal;
            this.cantidadColumnasEditables = cantidadColumnasEditables;         
        }
        protected void aplicarTema()
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
            dataGrid.Rows[dataGrid.Rows.Count - 1].ReadOnly = true;
            if(!tieneUnaSolaColumnaDatos)
                dataGrid.Columns[dataGrid.Columns.Count - 1].ReadOnly = true;
            dataGrid.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToFirstHeader;
            dataGrid.Font = new Font("Arial", 11, FontStyle.Regular);
            dataGrid.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;        
            dataGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dataGrid.ScrollBars = ScrollBars.Both;
            dataGrid.AutoSize = true;
            dataGrid.CellValidating += new DataGridViewCellValidatingEventHandler(dataGrid_CellValidatingMoney);
            dataGrid.SelectionChanged += new EventHandler(dataGrid_SelectedIndexChanged);

            panel = new Panel();
            panel.AutoScroll = true;
            panel.Controls.Add(dataGrid);

            // Asegúrate de que el Panel tenga suficiente espacio para mostrar las barras de desplazamiento
            panel.Dock = DockStyle.Fill;
        }
        protected Atributo_Money buildMoney(string valor)
        {
            Atributo_Money atributo = AtributoFactory.buildMoney(valor);
            if (!atributo.isValido)
                MessageBox.Show("El valor debe ser numérico");     
            return atributo;
        }
        public virtual void dataGrid_CellValidatingMoney(object sender, DataGridViewCellValidatingEventArgs e)
        {
            try
            {
                string valorAnterior = dataGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();                
                if (e.ColumnIndex > 0 && (e.ColumnIndex != dataGrid.Columns.Count - 1 || tieneUnaSolaColumnaDatos) && e.RowIndex < dataGrid.Rows.Count - 1)
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
        public void dataGrid_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (valorEditadoCorrectamente)
                {
                    totalizarFila();
                    TotalizarColumna();
                    totalizarGeneral();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected virtual void totalizarFila()
        {
            if (filaSeleccionada > -1 && !tieneUnaSolaColumnaDatos)
            {               
                int indexColumnaTotal = dataGrid.Columns.Count - 1;
                decimal total = 0;
                for (int c = 1; c < indexColumnaTotal; c++)
                {
                    total += (decimal)dataGrid[c, filaSeleccionada].Value;
                }
                Atributo_Money atributo_Money = AtributoFactory.buildMoney(total);
                dataGrid[indexColumnaTotal, filaSeleccionada].Value = atributo_Money.MoneyAccount;              
            }
        }
        protected virtual void TotalizarColumna(int columna = -2)
        {
            columna = (columna == -2)? columnaSeleccionada : columna;
            if (columna > -1)
            {
                int indexFilaTotal = dataGrid.Rows.Count - 1;
                decimal total = 0;
                for (int f = 0; f < indexFilaTotal; f++)
                {
                    total += (decimal)dataGrid[columna, f].Value;
                }
                Atributo_Money atributo_Money = AtributoFactory.buildMoney(total);
                dataGrid[columna, indexFilaTotal].Value = atributo_Money.MoneyAccount;
            }
        }
        protected virtual void totalizarGeneral()
        {
            if (columnaSeleccionada > -1 && !tieneUnaSolaColumnaDatos)
            {
                int indexFilaTotal = dataGrid.Rows.Count - 1;
                int indexColumnaTotal = dataGrid.Columns.Count - 1;
                decimal total = 0;
                for (int c = 1; c < indexColumnaTotal; c++)
                {
                    total += (decimal)dataGrid[c, indexFilaTotal].Value;
                }
                Atributo_Money atributo_Money = AtributoFactory.buildMoney(total);
                dataGrid[indexColumnaTotal, indexFilaTotal].Value = atributo_Money.MoneyAccount;
            }
        }       
    }
}

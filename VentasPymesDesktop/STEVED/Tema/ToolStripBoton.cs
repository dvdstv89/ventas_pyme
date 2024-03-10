using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace NucleoEV.Tema
{
    public enum TipoToolStripButton
    {
        Eliminar = 0,
        Aceptar = 1,
        Cancelar = 2,
        Activar = 3,
        Desactivar = 4,
        Modificar = 5,
        Adicionar = 6,
        Abrir = 7,
        Cerrar = 8,
        PlanVenta = 9,
        NuevoParteVentaCUP = 10,
        NuevoParteVentaMLC = 11,
        VerDetalles = 12,
        ModificarParteVenta = 13,
        CrearConciliacionBancaria = 14,
        ModificarConciliacionBancaria = 15
    }
    public class ToolStripBoton
    {        
        string buttonEliminarText;        
        string buttonAceptarText;       
        string buttonCancelarText;       
        string buttonActivarText;       
        string buttonDesactivarText;       
        string buttonModificarText;       
        string buttonAdicionarText;
        string buttonAbrirTiendaText;
        string buttonCerrarTiendaText;
        string buttonPlanVentaTiendaText;
        string buttonNuevoParteVentaMLC;
        string buttonNuevoParteVentaCUP;
        string buttonVerDetalles;
        string buttonModificarParteVenta;
        string buttonCrearConciliacionBancaria;
        string buttonModificarConciliacionBancaria;

        public ToolStripBoton()
        {            
            buttonEliminarText = "Eliminar";
            buttonAceptarText = "Aceptar";
            buttonCancelarText = "Cancelar";
            buttonActivarText = "Activar";
            buttonDesactivarText = "Desactivar";
            buttonModificarText = "Modificar";
            buttonAdicionarText = "Adicionar";
            buttonAbrirTiendaText = "Abrir";
            buttonCerrarTiendaText = "Cerrar";
            buttonPlanVentaTiendaText = "Gestionar plan de venta";
            buttonNuevoParteVentaMLC = "Parte en MLC";
            buttonNuevoParteVentaCUP = "Parte en CUP";
            buttonVerDetalles = "Ver detalles";
            buttonModificarParteVenta = "Modificar parte de venta";
            buttonCrearConciliacionBancaria = "Nueva conciliación";
            buttonModificarConciliacionBancaria = "Modificar conciliación";
        }      

        public void inicializarBoton(ref ToolStripButton button, TipoToolStripButton tipoButton, bool colorParaPanelLateral)
        {
            button.BackColor = (colorParaPanelLateral) ? new TemaAplication().inicializarColor(TipoColor.ToolStripButtonActivo) : new TemaAplication().inicializarColor(TipoColor.ToolStripButton);
            button.Font = new TemaAplication().inicializarTexto(TipoTexto.ButtonText);           
            button.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorLigth);
            switch (tipoButton)
            {
                case TipoToolStripButton.Eliminar:
                    {
                        button.Text = buttonEliminarText;                        
                        return;
                    }
                case TipoToolStripButton.Aceptar:
                    {
                        button.Text = buttonAceptarText;
                        return;
                    }
                case TipoToolStripButton.Cancelar:
                    {
                        button.Text = buttonCancelarText;
                        return;
                    }
                case TipoToolStripButton.Activar:
                    {
                        button.Text = buttonActivarText;
                        return;
                    }
                case TipoToolStripButton.Desactivar:
                    {
                        button.Text = buttonDesactivarText;
                        return;
                    }
                case TipoToolStripButton.Modificar:
                    {
                        button.Text = buttonModificarText;
                        return;
                    }
                case TipoToolStripButton.Adicionar:
                    {
                        button.Text = buttonAdicionarText;
                        return;
                    }
                case TipoToolStripButton.Abrir:
                    {
                        button.Text = buttonAbrirTiendaText;
                        return;
                    }
                case TipoToolStripButton.Cerrar:
                    {
                        button.Text = buttonCerrarTiendaText;
                        return;
                    }
                case TipoToolStripButton.PlanVenta:
                    {
                        button.Text = buttonPlanVentaTiendaText;
                        return;
                    }
                case TipoToolStripButton.NuevoParteVentaCUP:
                    {
                        button.Text = buttonNuevoParteVentaCUP;
                        return;
                    }
                case TipoToolStripButton.NuevoParteVentaMLC:
                    {
                        button.Text = buttonNuevoParteVentaMLC;
                        return;
                    }
                case TipoToolStripButton.VerDetalles:
                    {
                        button.Text = buttonVerDetalles;
                        return;
                    }
                case TipoToolStripButton.ModificarParteVenta:
                    {
                        button.Text = buttonModificarParteVenta;
                        return;
                    }
                case TipoToolStripButton.CrearConciliacionBancaria:
                    {
                        button.Text = buttonCrearConciliacionBancaria;
                        return;
                    }
                case TipoToolStripButton.ModificarConciliacionBancaria:
                    {
                        button.Text = buttonModificarConciliacionBancaria;
                        return;
                    }
                default:
                    break;
            }
        }
    }    
}

using System.Threading;
using System.Windows.Forms;
using NucleoEV.UI;
using System.Runtime.InteropServices;
using System;

namespace NucleoEV.Controller
{
   // internal class ProgressBarManager
    public class ProgressBarUIController
    {
        public ProgressBarUI frm { get; set; }
        public int valor { get; set; }     
        public Thread t2 { get; set; }
        public string title { get; set; }
        public bool ciclo { get; set; }
        public bool tamaño { get; set; }

        private void SetEstiloForm()
        {
            frm.lbEstado.Font = APP.fontTextoListasHeader;
            frm.BackColor = APP.color3;
            frm.panel1.BackColor = APP.colorBG;
            frm.panel2.BackColor = APP.color5;
            frm.panelReloj1.BackColor = APP.color4;
            frm.panelCajeroSuperior.BackColor = APP.color4;
        }
        public ProgressBarUIController(string title)
        {
            valor = 0;
            this.title = title;
            this.ciclo = false;
            this.tamaño = false;
            frm = new ProgressBarUI();
            SetEstiloForm();
            frm.lbEstado.Text = this.title;
        }
        public void MostrarProgresoCircular()
        {
            ciclo = true;
            t2 = new System.Threading.Thread(ProgressCircular);
            t2.Start();
        }


        private void ProgressCircular()
        {   
            //Application.DoEvents();
            if (tamaño)
            {
                frm.Size = new System.Drawing.Size(414, 101);
                frm._progressBarCommand.Location = new System.Drawing.Point(8, 20);
            }
            frm.Show();
            Application.DoEvents();
            frm.lbEstado.Text = this.title;
            frm._progressBarCommand.Style = ProgressBarStyle.Marquee;
            while (ciclo)
            {
                Application.DoEvents();
            }
            frm.Close();
            //Application.DoEvents();
            //frm.Dispose();
            //Application.DoEvents();
        }

        public void Close()
        {
            this.valor = 100;
            this.ciclo = false;
        }

    }
}

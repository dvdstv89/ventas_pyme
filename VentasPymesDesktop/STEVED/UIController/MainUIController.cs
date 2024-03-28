using NucleoEV.Model;
using System.Windows.Forms;
using System;
using NucleoEV.UI;
using System.Drawing;
using MyUI.Factories;
using NucleoEV.Message;
using MyUI.UIControler;
using NucleoEV.Service;

namespace NucleoEV.UIController
{
    internal class MainUIController : BaseUIController<MainUI>
    {
        MainUIService mainUIService;

        private const int imagen_inicio = 6;
        private const int imagen_tienda = 9;
        private const int imagen_registro_venta = 7;
        private const int imagen_conciliaciones = 1;
        private const int imagen_parte_venta = 4;
        private const int imagen_metrocontadores = 0;
        private const int imagen_revisiones_economicas = 5;
        private const int imagen_seguridad= 3;
        private const int imagen_configuracion = 8;
        private const int imagen_informacion = 2;

      
        
        object activeForm = null;        
        Button botonActivo=null;
        bool aplicacionEstaAbierta=false;
        public bool reiniciarAplicacionPorModificacionEnToken { get; set; }


        public MainUIController(MainUIService mainUIService, MainUI mainUI) : base(mainUI)
        {
            this.mainUIService = mainUIService;
            reiniciarAplicacionPorModificacionEnToken = false;
        }  
        
        public MainUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);         
            forma.btnUsuario.Click += new EventHandler(btnUsuario_Click);
            forma.btnInicio.Click += new EventHandler(btnInicio_Click);
            forma.btnTiendas.Click += new EventHandler(btnTiendas_Click);  
            forma.btnRegistroVentas.Click += new EventHandler(btnRegistroVentas_Click);
            forma.btnConciliacionesBancarias.Click += new EventHandler(btnConciliacionesBancarias_Click);
            forma.btnParteVentaOperativo.Click += new EventHandler(btnParteVentaOperativo_Click);
            forma.btnMetrocontadores.Click += new EventHandler(btnMetrocontadores_Click);
            forma.btnReporte.Click += new EventHandler(btnRevisionEconomica_Click);
            forma.btnSeguridad.Click += new EventHandler(btnSeguridad_Click);           
            forma.btnConfiguracion.Click += new EventHandler(btnConfiguracion_Click);
            forma.btnInformacion.Click += new EventHandler(btnInformacion_Click);
            forma.btnMinimizarMenu.Click += new EventHandler(btnMinimizarMenu_Click);
            forma.btnMaximizarMenu.Click += new EventHandler(btnMaximizarMenu_Click);

            return forma;
        }
        protected override void forma_Load(object sender, EventArgs e)
        {
            try
            {
                if (mainUIService.session.tokenEsAutentico)
                {
                    //this.empresa = session.empresa;
                    //this.securityToken = VariablesEntorno.securityToken;
                    //this.configuracion = session.configuracion;
                    //this.periodoAbierto = session.periodoAbierto;
                    //complejos = empresa.complejos;
                    btnMaximizarMenu_Click(sender, e);
                    aplicarTema();
                    llenarFooter();
                    restablecerFormulario();                   
                    //abrir formulario por defecto
                    btnInicio_Click(sender, e);
                    aplicacionEstaAbierta = true;
                }
                else
                {  
                    //solicitar token
                    btnUsuario_Click(sender, e);
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        protected override void aplicarTema()
        {
            FormularioStyleFactory.WINDOWS_FORM(this.forma, TextMensajeNucleo.APP_ABRIENDO);
          
            //forma.panelLogo.BackColor = new TemaAplication().inicializarColor(TipoColor.Logo);
            //forma.panelSideMenu.BackColor = new TemaAplication().inicializarColor(TipoColor.LateralMenu);        
            //session.temaAplication.inicializarBoton(ref forma.btnUsuario, Tema.TipoBoton.Banner);                 
            //session.temaAplication.inicializarBoton(ref forma.btnInicio, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnTiendas, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnContabilidad, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnRegistroVentas, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnConciliacionesBancarias, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnParteVentaOperativo, Tema.TipoBoton.Menu);
          //  session.temaAplication.inicializarBoton(ref forma.btnCapitalHumano, Tema.TipoBoton.Menu);
           // session.temaAplication.inicializarBoton(ref forma.btnAgua, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnMetrocontadores, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnReporte, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnSeguridad, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnConfiguracion, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnInformacion, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnMinimizarMenu, Tema.TipoBoton.Menu);
            //session.temaAplication.inicializarBoton(ref forma.btnMaximizarMenu, Tema.TipoBoton.Menu);
         //   session.temaAplication.inicializarBoton(ref forma.btnDepartamentoComercial, Tema.TipoBoton.Menu);
            //forma.FooterBar.BackColor = new TemaAplication().inicializarColor(TipoColor.FooterBarBC);
            //forma.FooterBar.ForeColor = new TemaAplication().inicializarColor(TipoColor.FooterBarFC);
            //forma.panelBanner.BackColor = new TemaAplication().inicializarColor(TipoColor.PanelBannerBC);

            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(forma.btnInicio, "Inicio");
            toolTip.SetToolTip(forma.btnTiendas, "Tiendas");
           // toolTip.SetToolTip(forma.btnContabilidad, "Contabilidad");
            toolTip.SetToolTip(forma.btnRegistroVentas, "Registro de ventas");
            toolTip.SetToolTip(forma.btnConciliacionesBancarias, "Conciliaciones Bancarias");
            toolTip.SetToolTip(forma.btnParteVentaOperativo, "Parte de venta operativo");
           // toolTip.SetToolTip(forma.btnCapitalHumano, "Capital Humano");
          //  toolTip.SetToolTip(forma.btnAgua, "Agua");
            toolTip.SetToolTip(forma.btnMetrocontadores, "Metrocontadores");
            toolTip.SetToolTip(forma.btnReporte, "Revisión económica");
            toolTip.SetToolTip(forma.btnSeguridad, "Seguridad");
            toolTip.SetToolTip(forma.btnConfiguracion, "Configuración");
            toolTip.SetToolTip(forma.btnInformacion, "Información");
            toolTip.SetToolTip(forma.btnMinimizarMenu, "Ocultar menú");
            toolTip.SetToolTip(forma.btnMaximizarMenu, "Mostrar menú");
            //toolTip.SetToolTip(forma.btnDepartamentoComercial, "Departamento Comercial");
        }
        void restablecerFormulario()
        {          
            forma.lbHeaderTitle.Text = "";
            visualizarFuncionalidadesPorPermisos();            
        }      
        private void OpenChildForm(object baseUIController)
        {
            if (activeForm != null)
            {
                (activeForm as BaseUIController).cerrarFormulario();
            }
            activeForm = baseUIController;
            (baseUIController as BaseUIController).configurarFormulario();
            Form form = ((baseUIController as BaseUIController).forma) as Form;
            forma.panelParent.Controls.Add(form);
            forma.panelParent.Tag = form;
        }
        void visualizarFuncionalidadesPorPermisos()
        {  
            //forma.btnTiendas.Visible = PermisoData.Rol_Comercial.estaPermitido(VariablesEntorno.securityToken.permisos);
           // forma.btnContabilidad.Visible = Permiso.Rol_Contador.estaPermitido();
            //forma.btnRegistroVentas.Visible = PermisoData.Rol_Caja_Central.estaPermitido(VariablesEntorno.securityToken.permisos);
            //forma.btnConciliacionesBancarias.Visible = PermisoData.Rol_Economico.estaPermitido(VariablesEntorno.securityToken.permisos);
            //forma.btnParteVentaOperativo.Visible = PermisoData.Transmitir_Parte_Venta_Operativo.estaPermitido(VariablesEntorno.securityToken.permisos);
           // forma.btnAgua.Visible = Permiso.Rol_Energetico.estaPermitido();
            //forma.btnMetrocontadores.Visible = PermisoData.Rol_Energetico.estaPermitido(VariablesEntorno.securityToken.permisos);           
            //forma.btnSeguridad.Visible = PermisoData.Rol_Informatico.estaPermitido(VariablesEntorno.securityToken.permisos);
            //forma.btnConfiguracion.Visible = PermisoData.Rol_Informatico.estaPermitido(VariablesEntorno.securityToken.permisos);
           // forma.btnDepartamentoComercial.Visible = Permiso.Rol_Departamento_Comercial.estaPermitido();
        }
        private void llenarFooter()
        {
            //forma.lbAnno.Text = periodoAbierto.annoAbierto.ToString();
            //forma.lbMes.Text = periodoAbierto.mesAbierto.ToString();
            //forma.lbTokenUtilizado.Text = VariablesEntorno.securityToken.token.Value;
        }
        private void btnSincronizarConServidor_Click(object sender, EventArgs e)
        {
            try
            {
              
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                //LoginUIController loginUIController = new LoginUIController(session, this);
                //loginUIController.Ejecutar().ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnInicio_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Sucursal Comercial Caracol Este Vedado",imagen_inicio);
                //DashboardUIController formulario = new DashboardUIController(session);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnInicio);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnTiendas_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Tiendas", imagen_tienda);
                //GestionarTiendaUIController formulario = new GestionarTiendaUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnTiendas);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnDepartamentoComercial_Click(object sender, EventArgs e)
        {
            try
            {
              //  setHeaderText("Departamento Comercial");
                //GestionarDepartamentoComercialUIController formulario = new GestionarDepartamentoComercialUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
             //   cambiarBotonActivo(forma.btnDepartamentoComercial);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnCapitalHumano_Click(object sender, EventArgs e)
        {
            try
            {
                //setHeaderText("Departamento de Capital Humano");
                //GestionarCapitalHumanoUIController formulario = new GestionarCapitalHumanoUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
              //  cambiarBotonActivo(forma.btnCapitalHumano);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnContabilidad_Click(object sender, EventArgs e)
        {
            try
            {
               // setHeaderText("Contabilidad");
                //GestionarParteVentaResumidaUIController formulario = new GestionarParteVentaResumidaUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
              //  cambiarBotonActivo(forma.btnContabilidad);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnConciliacionesBancarias_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Conciliaciones Bancarias", imagen_conciliaciones);
                //GestionarConciliacionUIController formulario = new GestionarConciliacionUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnConciliacionesBancarias);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRegistroVentas_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Registro de ventas", imagen_registro_venta);
                //GestionarParteVentaAmpliadoUIController formulario = new GestionarParteVentaAmpliadoUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnRegistroVentas);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnParteVentaOperativo_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Parte de venta operativo", imagen_parte_venta);
                //ParteVentaOperativoUIController formulario = new ParteVentaOperativoUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
                //cambiarBotonActivo(forma.btnParteVentaOperativo);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnAgua_Click(object sender, EventArgs e)
        {
            try
            {
                //setHeaderText("Consumo de agua");
                //AguaUIController formulario = new AguaUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
              //  cambiarBotonActivo(forma.btnAgua);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnMetrocontadores_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Metrocontadores", imagen_metrocontadores);
                //ElectricidadUIController formulario = new ElectricidadUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnMetrocontadores);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnRevisionEconomica_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Revisión económica", imagen_revisiones_economicas);
                //ReporteUIController formulario = new ReporteUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnReporte);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnSeguridad_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Seguridad", imagen_seguridad);
                //GestionarSecurityTokenUIController formulario = new GestionarSecurityTokenUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnSeguridad);
                //formulario.Ejecutar().Show();                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Configuración", imagen_configuracion);
                //SistemaUIController formulario = new SistemaUIController(session);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnConfiguracion);
                //formulario.Ejecutar().Show();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }         
        private void btnInformacion_Click(object sender, EventArgs e)
        {
            try
            {
                setHeaderText("Información", imagen_informacion);
                //InformacionUIController formulario = new InformacionUIController(session, this);
                //OpenChildForm(formulario);
                //ocultarMenu();
                cambiarBotonActivo(forma.btnInformacion);
                //formulario.Ejecutar().Show();                           
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnMinimizarMenu_Click(object sender, EventArgs e)
        {
            try
            {
                forma.panelSideMenu.Width = 45;
                forma.btnMaximizarMenu.Visible = true;
                forma.btnMinimizarMenu.Visible = false;

                forma.btnInicio.Size = new Size(45, 45);
                forma.btnTiendas.Size = new Size(45, 45);
              //  forma.btnDepartamentoComercial.Size = new Size(45, 45);
              //  forma.btnContabilidad.Size = new Size(45, 45);
                forma.btnConciliacionesBancarias.Size = new Size(45, 45);
                forma.btnRegistroVentas.Size = new Size(45, 45);
                forma.btnParteVentaOperativo.Size = new Size(45, 45);
              //  forma.btnCapitalHumano.Size = new Size(45, 45);
                //forma.btnAgua.Size = new Size(45, 45);
                forma.btnMetrocontadores.Size = new Size(45, 45);
                forma.btnReporte.Size = new Size(45, 45);
                forma.btnSeguridad.Size = new Size(45, 45);
                forma.btnConfiguracion.Size = new Size(45, 45);
                forma.btnInformacion.Size = new Size(45, 45);
                forma.btnMinimizarMenu.Size = new Size(45, 45);
                forma.btnMaximizarMenu.Size = new Size(45, 45);

                forma.btnInicio.Text = "";
                forma.btnTiendas.Text = "";
              //  forma.btnDepartamentoComercial.Text = "";
              //  forma.btnContabilidad.Text = "";
                forma.btnRegistroVentas.Text = "";
                forma.btnConciliacionesBancarias.Text = "";
                forma.btnParteVentaOperativo.Text = "";
              //  forma.btnCapitalHumano.Text = "";
              //  forma.btnAgua.Text = "";
                forma.btnMetrocontadores.Text = "";
                forma.btnReporte.Text = "";
                forma.btnSeguridad.Text = "";
                forma.btnConfiguracion.Text = "";
                forma.btnInformacion.Text = "";
                forma.btnMinimizarMenu.Text = "";
                forma.btnMaximizarMenu.Text = "";               

                forma.btnInicio.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnTiendas.ImageAlign = ContentAlignment.MiddleCenter;
              //  forma.btnDepartamentoComercial.ImageAlign = ContentAlignment.MiddleCenter;
              //  forma.btnContabilidad.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnRegistroVentas.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnConciliacionesBancarias.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnParteVentaOperativo.ImageAlign = ContentAlignment.MiddleCenter;
              //  forma.btnCapitalHumano.ImageAlign = ContentAlignment.MiddleCenter;
             //   forma.btnAgua.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnMetrocontadores.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnReporte.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnSeguridad.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnConfiguracion.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnInformacion.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnMinimizarMenu.ImageAlign = ContentAlignment.MiddleCenter;
                forma.btnMaximizarMenu.ImageAlign = ContentAlignment.MiddleCenter;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnMaximizarMenu_Click(object sender, EventArgs e)
        {
            try
            {
                forma.panelSideMenu.Width = 250;
                forma.btnMaximizarMenu.Visible = false;
                forma.btnMinimizarMenu.Visible = true;

                forma.btnInicio.Size = new Size(250, 45);
                forma.btnTiendas.Size = new Size(250, 45);
              //  forma.btnDepartamentoComercial.Size = new Size(250, 45);
              //  forma.btnContabilidad.Size = new Size(250, 45);
                forma.btnRegistroVentas.Size = new Size(250, 45);
                forma.btnConciliacionesBancarias.Size = new Size(250, 45);
                forma.btnParteVentaOperativo.Size = new Size(250, 45);
             //   forma.btnCapitalHumano.Size = new Size(250, 45);
               // forma.btnAgua.Size = new Size(250, 45);
                forma.btnMetrocontadores.Size = new Size(250, 45);
                forma.btnReporte.Size = new Size(250, 45);
                forma.btnSeguridad.Size = new Size(250, 45);
                forma.btnConfiguracion.Size = new Size(250, 45);
                forma.btnInformacion.Size = new Size(250, 45);
                forma.btnMinimizarMenu.Size = new Size(250, 45);
                forma.btnMaximizarMenu.Size = new Size(250, 45);

                forma.btnInicio.Text = "Inicio";
                forma.btnTiendas.Text = "Tiendas";
               // forma.btnDepartamentoComercial.Text = "Departamento Comercial";
               // forma.btnContabilidad.Text = "Contabilidad";
                forma.btnRegistroVentas.Text = "Registro de ventas";
                forma.btnConciliacionesBancarias.Text = "Conciliaciones Bancarias";
                forma.btnParteVentaOperativo.Text = "Parte de venta operativo";
              //  forma.btnCapitalHumano.Text = "Capital Humano";
               // forma.btnAgua.Text = "Agua";
                forma.btnMetrocontadores.Text = "Metrocontadores";
                forma.btnReporte.Text = "Revisión económica";
                forma.btnSeguridad.Text = "Seguridad";
                forma.btnConfiguracion.Text = "Configuración";
                forma.btnInformacion.Text = "Información";
                forma.btnMinimizarMenu.Text = "Ocultar menú";
                forma.btnMaximizarMenu.Text = "";

                forma.btnInicio.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnTiendas.ImageAlign = ContentAlignment.MiddleLeft;
              //  forma.btnDepartamentoComercial.ImageAlign = ContentAlignment.MiddleLeft;
              //  forma.btnContabilidad.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnRegistroVentas.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnConciliacionesBancarias.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnParteVentaOperativo.ImageAlign = ContentAlignment.MiddleLeft;
              //  forma.btnCapitalHumano.ImageAlign = ContentAlignment.MiddleLeft;
               // forma.btnAgua.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnMetrocontadores.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnReporte.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnSeguridad.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnConfiguracion.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnInformacion.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnMinimizarMenu.ImageAlign = ContentAlignment.MiddleLeft;
                forma.btnMaximizarMenu.ImageAlign = ContentAlignment.MiddleLeft;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        void setHeaderText(string text, int idImagen)
        {
            forma.imageTile.Image = forma.iconosList.Images[idImagen];
            //forma.imageTile.Image.
            forma.lbHeaderTitle.Text= text;
            //forma.lbHeaderTitle.Font = new TemaAplication().inicializarTexto(TipoTexto.MigasPanFont);
            //forma.lbHeaderTitle.ForeColor = new TemaAplication().inicializarColor(TipoColor.ButtonFontColorLigth);
        }
        public void reiniciarFormulario()
        {
            reiniciarAplicacionPorModificacionEnToken = true;
            forma.Close();
        }
        public void cerrarAplicacion()
        {
            if (aplicacionEstaAbierta == false)
            {
                reiniciarAplicacionPorModificacionEnToken = false;
                forma.Close();
            }
        }
        public bool estaAbiertaLaAplicacion()
        {
            return aplicacionEstaAbierta;
        }
        void cambiarBotonActivo(Button button)
        {
            //quitar boton activo
            if (botonActivo != null)
                //botonActivo.BackColor = new TemaAplication().inicializarColor(TipoColor.LateralMenu);          
            botonActivo = button;
            //activar nuevo activo
            //if (botonActivo != null)
                //botonActivo.BackColor = new TemaAplication().inicializarColor(TipoColor.ToolStripButtonActivo);          
        }
        public void ocultarVentanaPrincipal()
        {
            forma.Visible = false;
        }
        public void mostrarVentanaPrincipal()
        {
            forma.Visible = true;
        }
    }
}

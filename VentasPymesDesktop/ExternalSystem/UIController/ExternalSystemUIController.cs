using System.Collections.Generic;
using System.Windows.Forms;
using System;
using ExternalSystem.UI;
using MyUI.Component;
using MyUI.Service;
using ExternalSystem.Service;
using MyUI.UIControler;
using GlobalContracts.Interface;
using GlobalContracts.Message;

namespace ExternalSystem.UIController
{
    public class ExternalSystemUIController<Tipo> : BaseUIController<ExternalSystemUI>, IController<ExternalSystemUI> where Tipo : EnviromentObject<Tipo>
    {      
        public Tipo enviromentObject { get; set; }
        private bool isDefaultConection;
        private bool isDomainSpecific;
        List<string> dominios;
        public bool isValidado { get; set; }
        public ExternalSystemUIController(Tipo enviromentObject, List<string> dominios, bool isDefaultConection = false, bool isDomainSpecific = true) : base(new ExternalSystemUI()) 
        {
            this.enviromentObject = enviromentObject;
            this.isDefaultConection = isDefaultConection;
            this.isDomainSpecific = isDomainSpecific;
            this.isValidado = false;
            this.dominios = dominios;
        }
        public ExternalSystemUI ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            forma.btCancelar.Click += new EventHandler(btnCancelar_Click);
            forma.btProbar.Click += new EventHandler(btnProbar_Click);
            forma.btGuardar.Click += new EventHandler(btnGuardar_Click);
            return forma;
        }
        public override void forma_Load(object sender, EventArgs e)
        {
            base.forma_Load(sender, e);
        }
        public override void aplicarTema()
        {
            FormularioStyleFactory.WINDOWS_MODAL(this.forma, enviromentObject.getNameByUI());
            forma.StartPosition = FormStartPosition.CenterScreen;

            ButtonStyleFactory.GUARDAR(forma.btGuardar);
            ButtonStyleFactory.CANCELAR(forma.btCancelar);
            ButtonStyleFactory.PROBAR(forma.btProbar);

            TabControlStyleFactory.TAB_CONTROL(forma.tabControl);
            TabPageStyleFactory.TAB_PAGE(forma.tabPageGeneral, TitleText.COMUN_DATA);           
            LabelStyleFactory.Label_FORM(forma.labelTipo, enviromentObject.type.getText());
            LabelStyleFactory.Label_FORM(forma.labelNombre, enviromentObject.name.getText());
            LabelStyleFactory.Label_FORM(forma.labelDominio, enviromentObject.domain.getText());
            ComboBoxStyleFactory.LIST_READONLY(forma.comboBoxTipoExternalSystem, DataStaticFactory.TipoEnviromentObject_getAll());

            if (typeof(Tipo) == typeof(EnviromentObjectDatasourse))
            {
                TabPageStyleFactory.TAB_PAGE(forma.tabPageDataSourse, TitleText.DATASOURSE);
                LabelStyleFactory.Label_FORM(forma.labelTipoDatasourse, LabelText.TIPO_DATABASE.getMensaje());
                LabelStyleFactory.Label_FORM(forma.labelServidor, LabelText.SERVIDOR.getMensaje());
                LabelStyleFactory.Label_FORM(forma.labelUsuario, LabelText.USUARIO.getMensaje());
                LabelStyleFactory.Label_FORM(forma.labelPass, LabelText.PASSWORD.getMensaje());
                LabelStyleFactory.Label_FORM(forma.labelDatabase, LabelText.DATABASE.getMensaje());
                ComboBoxStyleFactory.LIST(forma.comboBoxTipoDatasourse, DataStaticFactory.TipoDatabase_getAll());
                TextBoxStyleFactory.TEXT(forma.tbServidor);
                TextBoxStyleFactory.TEXT(forma.tbUsuario);
                TextBoxStyleFactory.PASSWORD(forma.tbPass);
                TextBoxStyleFactory.TEXT(forma.tbBD);
            }

            if (isDefaultConection)         
                TextBoxStyleFactory.TEXT_READONLY(forma.textBoxNombre);
            else          
                TextBoxStyleFactory.TEXT(forma.textBoxNombre);  

            if (isDomainSpecific)            
                ComboBoxStyleFactory.LIST_READONLY(forma.comboBoxDominio, dominios);
            else
                ComboBoxStyleFactory.LIST(forma.comboBoxDominio, dominios);
        }
        public override void initDataForm()
        {       
            //preveer que pueden existir datos nulos
            forma.btGuardar.Enabled= false;
            forma.textBoxNombre.Text = enviromentObject.name.Value.ToString();           
            forma.comboBoxDominio.Text = enviromentObject.domain.Value;           
            forma.comboBoxTipoExternalSystem.Text = enviromentObject.type.Value.ToString();

            if (typeof(Tipo) != typeof(EnviromentObjectDatasourse))
            {
                forma.tabControl.TabPages.RemoveByKey("tabPageDataSourse");               
            }
            else
            {              
                forma.comboBoxTipoDatasourse.Text = (enviromentObject as EnviromentObjectDatasourse).value.tipoBaseDatos.ToString();
                forma.tbServidor.Text = (enviromentObject as EnviromentObjectDatasourse).value.server;
                forma.tbUsuario.Text = (enviromentObject as EnviromentObjectDatasourse).value.user;
                forma.tbPass.Text = (enviromentObject as EnviromentObjectDatasourse).value.password;
                forma.tbBD.Text = (enviromentObject as EnviromentObjectDatasourse).value.database;
                forma.tabControl.SelectTab("tabPageDataSourse");
            }
        }
        public void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                enviromentObject.type.setValue(DataStaticFactory.TipoEnviromentObject_getByName(forma.comboBoxTipoExternalSystem.Text));
                enviromentObject.name.setValue(forma.textBoxNombre.Text);
                enviromentObject.domain.setValue(forma.comboBoxDominio.Text);
                if (typeof(Tipo) == typeof(EnviromentObjectDatasourse))
                {
                    (enviromentObject as EnviromentObjectDatasourse).value.setConectionString(forma.tbServidor.Text, forma.tbUsuario.Text, forma.tbPass.Text, forma.tbBD.Text, DataStaticFactory.TipoDatabase_getByName(forma.comboBoxTipoDatasourse.Text));                                
                }
                forma.Close();
               
            }
            catch (Exception ex)
            {
                DialogService.ShowDialog(MensajeFactory.EXCEPTION(ex.Message));
            }
        }
        public void btnProbar_Click(object sender, EventArgs e)
        {
            try
            {
                if (typeof(Tipo) == typeof(EnviromentObjectDatasourse))
                {
                    EnviromentObjectDatasourse prueba = new EnviromentObjectDatasourse (false);
                    prueba.type.setValue(DataStaticFactory.TipoEnviromentObject_getByName(forma.comboBoxTipoExternalSystem.Text));
                    prueba.name.setValue(forma.textBoxNombre.Text);
                    prueba.domain.setValue(forma.comboBoxDominio.Text);
                    prueba.value.setConectionString(forma.tbServidor.Text, forma.tbUsuario.Text, forma.tbPass.Text, forma.tbBD.Text, DataStaticFactory.TipoDatabase_getByName(forma.comboBoxTipoDatasourse.Text));                    
                    isValidado =  EnviromentObjectDatasourseService.ProbarDatasourse(prueba);
                    if (isValidado) forma.btGuardar.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                DialogService.ShowDialog(MensajeFactory.EXCEPTION(ex.Message));
            }
        }
        public new void btnCancelar_Click(object sender, EventArgs e)
        {
            try
            {
                isValidado = false;
                forma.Close(); 
                return;
            }
            catch (Exception ex)
            {
                DialogService.ShowDialog(MensajeFactory.EXCEPTION(ex.Message));
            }
        }
    }
}

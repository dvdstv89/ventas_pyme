using ModelData;
using ModelData.Model;
using ModelData.Service.LocalDatabaseClient;
using ModelData.Service.RemotoDatabaseClient;
using NucleoEV.Model;
using NucleoEV.Tema;
using NucleoEV.UI;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Atributo_Money = ModelData.Atributo.Atributo_Money;

namespace NucleoEV.UIController
{
    internal class SistemaUIController : BaseUIController, IController<SistemaUI>
    {
        Configuracion configuracion;
        Empresa empresa;
        public SistemaUIController(Session session) : base(session, new SistemaUI())
        {
            try
            {
                this.configuracion = session.configuracion;
                this.empresa = session.empresa;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public SistemaUI Ejecutar()
        {
            forma.Load += new EventHandler(forma_Load);
            getForma().btnGuardarBD.Click += new EventHandler(btnGuardarBD_Click);
            getForma().btnGuardarPlanAgua.Click += new EventHandler(btnGuardarPlanAgua_Click);
            getForma().btnGuardarPlanElectrico.Click += new EventHandler(btnGuardarPlanElectrico_Click);
            getForma().btnGuardarPlanVenta.Click += new EventHandler(btnGuardarPlanVenta_Click);
            getForma().btnGuardarEmail.Click += new EventHandler(btnGuardaEmail_Click);
            getForma().btnGuardarSMTP.Click += new EventHandler(btnGuardarSMTP_Click);
            getForma().btnGuardarSalarios.Click += new EventHandler(btnGuardarSalarios_Click);
            getForma().btnProbarEmail.Click += new EventHandler(btnGuardarBD_Click);


            return getForma();
        }
        void forma_Load(object sender, EventArgs e)
        {
            aplicarTema();
            restablecerFormulario();
            getForma().tabControl1.TabPages.RemoveAt(2);
            //LlenarListadoDatos();
        }
        void aplicarTema()
        {
            //session.temaAplication.inicializarBoton(ref getForma().btnGuardarBD, Tema.TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref getForma().btnGuardarPlanAgua, Tema.TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref getForma().btnGuardarPlanElectrico, Tema.TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref getForma().btnGuardarPlanVenta, Tema.TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref getForma().btnGuardarEmail, Tema.TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref getForma().btnGuardarSMTP, Tema.TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref getForma().btnProbarEmail, Tema.TipoBoton.Normal);
            //session.temaAplication.inicializarBoton(ref getForma().btnGuardarSalarios, Tema.TipoBoton.Normal);

            //session.temaAplication.inicializarListView(ref getForma().lwComplejo);
            //session.temaAplication.inicializarListView(ref getForma().lwFormaPago);
            //session.temaAplication.inicializarListView(ref getForma().lwGrupoConciliacion);
            //session.temaAplication.inicializarListView(ref getForma().lwMetrocontador);
            //session.temaAplication.inicializarListView(ref getForma().lwMoneda);
            //session.temaAplication.inicializarListView(ref getForma().lwPermiso);
            forma.BackColor = session.temaAplication.formularioBgColor();
        }
        void restablecerFormulario()
        {
            //getForma().tbUrlApi.Text = configuracion.urlApiRest.Value;
            //getForma().tbServidorBD.Text = configuracion.stringPostgresDb.server;
            //getForma().tbUsuarioBD.Text = configuracion.stringPostgresDb.user;
            //getForma().tbPassBD.Text = configuracion.stringPostgresDb.password;
            //getForma().tbBd.Text = configuracion.stringPostgresDb.database;
            //getForma().tbPlanAgua.Text = empresa.planAguaAnno.Value;
            //getForma().tbPlanElectrico.Text = empresa.planElectricoAnno.Value;
            //getForma().tbPlanVenta.Text = empresa.planVentaAnno.Value;
            //getForma().tbSalarioDependienteComercial.Text = empresa.salarioDependienteComercial.Value;
            //getForma().tbSalarioJefeBrigada.Text = empresa.salarioJefesBrigada.Value;
            //if (empresa.servidorSMTP.Objeto != null)
            //{
            //    getForma().tbServidorSMTP.Text = empresa.servidorSMTP.Objeto.servidor.Value;
            //    getForma().tbUsuarioSMTP.Text = empresa.servidorSMTP.Objeto.usuarioServidor.Value;
            //    getForma().tbPassSMTP.Text = empresa.servidorSMTP.Objeto.password.Value;
            //    getForma().tbPuerto.Text = empresa.servidorSMTP.Objeto.puerto.ToString();
            //}
            //for (int i = 0; i < empresa.email.emails.Count; i++)
            //{
            //    getForma().tbEmail.AppendText(empresa.email.emails[i].Value + Environment.NewLine);
            //}

        }
        private void btnGuardarBD_Click(object sender, EventArgs e)
        {
            try
            {
                //bool todoOk = actualizarBD();
                //if (todoOk)
                //{
                //    //configuracion.preUpdateObjecto(VariablesEntorno.securityToken.token.Value);
                //    new ConfiguracionLDB().update(configuracion);
                //    new MensajeBox().modificacionOk();                                  
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuardarPlanVenta_Click(object sender, EventArgs e)
        {
            try
            {
                if (getForma().tbPlanVenta.Text == "")
                {
                    //empresa.planVentaAnno.setMoney(0);
                    //actualizarEmpresa();
                    return;
                }
                else
                {
                    Atributo_Money saldo = new Atributo_Money("");
                    //bool saldoCorrecto = saldo.setStringMoney(getForma().tbPlanVenta.Text);
                    //if(saldoCorrecto)
                    //{
                    //    empresa.planVentaAnno.setStringMoney(getForma().tbPlanVenta.Text);
                    //    actualizarEmpresa();
                    //    return;
                    //}
                    //else
                    //{
                    //    getForma().tbPlanVenta.Text = empresa.planVentaAnno.Value;
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuardarPlanElectrico_Click(object sender, EventArgs e)
        {
            try
            {
                if (getForma().tbPlanElectrico.Text == "")
                {
                    //    empresa.planElectricoAnno.setConsumo(0);
                    //actualizarEmpresa();
                    return;
                }
                else
                {
                    //Atributo_Consumo saldo = new Atributo_Consumo("");
                    //bool saldoCorrecto = saldo.setStringConsumo(getForma().tbPlanVenta.Text);
                    //if (saldoCorrecto)
                    //{
                    //    empresa.planElectricoAnno.setStringConsumo(getForma().tbPlanVenta.Text);
                    //    actualizarEmpresa();
                    //    return;
                    //}
                    //else
                    //{
                    //    getForma().tbPlanElectrico.Text = empresa.planElectricoAnno.Value;
                    //}

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuardarPlanAgua_Click(object sender, EventArgs e)
        {
            try
            {
                //if (getForma().tbPlanAgua.Text == "")
                //{
                //    empresa.planAguaAnno.setConsumo(0);
                //    actualizarEmpresa();
                //    return;
                //}
                //else
                //{
                //    Atributo_Consumo saldo = new Atributo_Consumo("");
                //    bool saldoCorrecto = saldo.setStringConsumo(getForma().tbPlanAgua.Text);
                //    if (saldoCorrecto)
                //    {
                //        empresa.planAguaAnno.setStringConsumo(getForma().tbPlanAgua.Text);
                //        actualizarEmpresa();
                //        return;
                //    }
                //    else
                //    {
                //        getForma().tbPlanAgua.Text = empresa.planElectricoAnno.Value;
                //    }

                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuardarSMTP_Click(object sender, EventArgs e)
        {
            try
            {
                //if (empresa.servidorSMTP.Objeto == null)
                //    empresa.servidorSMTP.Objeto = new ServidorSMTP(VariablesEntorno.securityToken.token.Value);
                //empresa.servidorSMTP.Objeto.servidor.Value = getForma().tbServidorSMTP.Text;
                //empresa.servidorSMTP.Objeto.password.Value = getForma().tbPassSMTP.Text;
                //empresa.servidorSMTP.Objeto.usuarioServidor.setEmail(getForma().tbUsuarioSMTP.Text);
                //empresa.servidorSMTP.Objeto.puerto.Value = int.Parse(getForma().tbPuerto.Text);
                //bool validarSMTP = empresa.servidorSMTP.Objeto.validar();
                //if (validarSMTP)
                //{
                //    if (empresa.servidorSMTP.Objeto.getId() == "0")
                //    {
                //        empresa.servidorSMTP.Objeto.id.Value = new ServidorSmtpRDB().getNextId();
                //        empresa.servidorSMTP.Value = empresa.servidorSMTP.Objeto.id.Value;                     
                //        new ServidorSmtpRDB().insertarSMTP(empresa.servidorSMTP.Objeto);
                //        session.sincronizarServidorSMTP();
                //        actualizarEmpresa();
                //    }
                //    else
                //    {                       
                //        new ServidorSmtpRDB().updateSMTP(empresa.servidorSMTP.Objeto);
                //        session.sincronizarServidorSMTP();
                //        new MensajeBox().modificacionOk();
                //    }
                //}
                //else
                //{
                //    new MensajeBox().validacionFail();
                //}
            }
            catch
            {
                new MensajeBox().validacionFail();
            }
        }
        private void btnGuardaEmail_Click(object sender, EventArgs e)
        {
            try
            {
                //List<string> emailList = new List<string>();
                //foreach (string item in (getForma().tbEmail.Lines))
                //{
                //    emailList.Add(item);
                //}
                //empresa.email.setEmail(emailList);
                //actualizarEmpresa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void btnGuardarSalarios_Click(object sender, EventArgs e)
        {
            try
            {
                //bool datosValidos = true;
                //Atributo_Money nuevoSalarioDependiente = new Atributo_Money(empresa.salarioDependienteComercial.Value, "");
                //Atributo_Money nuevoSalarioJefe = new Atributo_Money(empresa.salarioJefesBrigada.Value,"");

                //datosValidos &= ActualizarSalario(getForma().tbSalarioDependienteComercial, nuevoSalarioDependiente, empresa.salarioDependienteComercial);
                //datosValidos &= ActualizarSalario(getForma().tbSalarioJefeBrigada, nuevoSalarioJefe, empresa.salarioJefesBrigada);

                //if (datosValidos)
                //{
                //    empresa.salarioDependienteComercial.setMoney(nuevoSalarioDependiente.MoneyAccount);
                //    empresa.salarioJefesBrigada.setMoney(nuevoSalarioJefe.MoneyAccount);
                //    actualizarEmpresa();
                //}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }


        public SistemaUI getForma()
        {
            throw new NotImplementedException();
        }
        //{
        //    if (string.IsNullOrEmpty(textBox.Text))
        //    {
        //        nuevoSalario.setMoney(0);
        //        return true;
        //    }

        //    Atributo_Money saldo = new Atributo_Money("");
        //    bool saldoCorrecto = saldo.setStringMoney(textBox.Text);

        //    if (saldoCorrecto)
        //    {
        //        nuevoSalario.setStringMoney(textBox.Text);
        //        return true;
        //    }

        //    textBox.Text = salarioActual.Value;
        //   return false;
    }

    //protected bool actualizarBD()
    //{
    //    try
    //    {
    //        //if (getForma().tbServidorBD.Text == "") return false;
    //        //if (getForma().tbUsuarioBD.Text == "") return false;
    //        //if (getForma().tbPassBD.Text == "") return false;
    //        //if (getForma().tbBd.Text == "") return false;
    //        //configuracion.stringPostgresDb.setConectionString(getForma().tbServidorBD.Text, getForma().tbUsuarioBD.Text, getForma().tbPassBD.Text, getForma().tbBd.Text, Database.TipoBaseDatos.Postgres);
    //        return true;
    //    }
    //    catch (Exception ex)
    //    {
    //        MessageBox.Show(ex.Message);
    //        return false;
    //    }
    //}       
    //private void actualizarEmpresa()
    //{           
    //    new EmpresaRDB().updateEmpresa(empresa);
    //    session.sincronizarEmpresa();
    //    new MensajeBox().modificacionOk();
    //}
    //public SistemaUI getForma()
    //{
    //    return forma as SistemaUI;
    //}
    //private void LlenarListadoDatos()
    //{
    //    getForma().lwComplejo.Items.Clear();
    //    getForma().lwFormaPago.Items.Clear();
    //    getForma().lwGrupoConciliacion.Items.Clear();
    //    getForma().lwMetrocontador.Items.Clear();
    //    getForma().lwMoneda.Items.Clear();
    //    getForma().lwPermiso.Items.Clear();


    //    List<Moneda> monedas = MonedaData.getAllMonedas();
    //    for (int i = 0; i < monedas.Count; i++)
    //    {
    //        ListViewItem item = new ListViewItem(monedas[i].denominacion.Value);              
    //        getForma().lwMoneda.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
    //    }

    //    List<FormaPago> formasPago = FormaPagoData.getAllFormaPago();
    //    for (int i = 0; i < formasPago.Count; i++)
    //    {
    //        ListViewItem item = new ListViewItem(formasPago[i].denominacion.Value);
    //        getForma().lwFormaPago.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
    //    }

    //    List<Complejo> complejos = ComplejoData.getAllComplejos();
    //    for (int i = 0; i < complejos.Count; i++)
    //    {
    //        ListViewItem item = new ListViewItem(complejos[i].denominacion.Value);
    //        getForma().lwComplejo.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
    //    }

    //    List<Permiso> permisosList = PermisoData.getPermisos();
    //    for (int i = 0; i < permisosList.Count; i++)
    //    {
    //        ListViewItem item = new ListViewItem(permisosList[i].denominacion.Value);
    //        getForma().lwPermiso.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
    //    }

    //    List<GrupoConciliacion> conciliacionesList = GrupoConsiliacionData.getAllGrupoConsiliaciones();
    //    for (int i = 0; i < conciliacionesList.Count; i++)
    //    {
    //        ListViewItem item = new ListViewItem(conciliacionesList[i].denominacion.Value);
    //        getForma().lwGrupoConciliacion.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
    //    }

    //    List<Metrocontador> metrocontadoresList = MetrocontadoresData.getAllMetroContadores();
    //    for (int i = 0; i < metrocontadoresList.Count; i++)
    //    {
    //        ListViewItem item = new ListViewItem(metrocontadoresList[i].denominacion.Value);
    //        getForma().lwMetrocontador.Items.Add(session.temaAplication.inicializarListViewItem(item, i));
    //    }
    //}
}
using System;

namespace GlobalContracts.Interface
{
    public interface IController<Tipo>
    {
        Tipo getForma();
        Tipo ejecutar();      
        void aplicarTema();
        void initDataForm();
        void forma_Load(object sender, EventArgs e);
    }
}

using MyUI.Model;
using MyUI.Service;
using System;
using System.Threading.Tasks;

namespace ExternalSystem.Service
{
    public abstract class BaseService
    {
        protected async Task<T> ejecutarEndpoint<T>(MensajeText mensajeText, Func<Task<T>> task)
        {
            try
            {
                return await new ProgressBarService(mensajeText).run(task);
            }
            catch (Exception) { throw; }
        }
    }    
}

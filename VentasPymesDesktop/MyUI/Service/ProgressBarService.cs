using MyUI.Model;
using MyUI.UIControler;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace MyUI.Service
{
    public class ProgressBarService
    {
        private ProgressBarUIController progressBar;     

        public ProgressBarService(MensajeText mensaje)
        {           
            progressBar = new ProgressBarUIController(mensaje);
        }

        public Task<T> run<T>(Func<Task<T>> action)
        {
            try
            {
                progressBar.Start();

                var tcs = new TaskCompletionSource<T>();

                BackgroundWorker worker = new BackgroundWorker();
                worker.DoWork += (sender, e) =>
                {
                    action.Invoke().ContinueWith(task =>
                    {
                        if (task.IsFaulted)
                        {
                            tcs.SetException(task.Exception.InnerException);                            
                        }
                        else if (task.IsCanceled)
                        {
                            tcs.SetCanceled();
                        }
                        else
                        {
                            tcs.SetResult(task.Result);
                        }
                    }, TaskScheduler.Default);
                };

                worker.RunWorkerCompleted += (sender, e) =>
                {
                    progressBar.cerrarFormulario();
                };

                worker.RunWorkerAsync();

                return tcs.Task;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

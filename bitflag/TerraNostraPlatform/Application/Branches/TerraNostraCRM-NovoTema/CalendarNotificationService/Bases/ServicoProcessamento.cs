using BackgroundServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BackgroundServices.Bases
{
    public abstract class ServicoProcessamento : IServico, IServicoProcessamento
    {
        private Task task { get; set; }
        private CancellationTokenSource cancellationTokenSource { get; set; }
        private CancellationToken cancellationToken { get; set; }
        public int Intervalo { get; set; }
        public Dictionary<string, object> Parametros { get; set; }

        public ServicoProcessamento(int intervalo)
        {
            this.Intervalo = intervalo;
            this.Parametros = new Dictionary<string, object>();
            this.task = null;
        }
        private void _Iniciar()
        {
            this.cancellationTokenSource = new CancellationTokenSource();
            this.cancellationToken = this.cancellationTokenSource.Token;

            this.task = new Task(() =>
            {
                while (true)
                {
                    cancellationToken.ThrowIfCancellationRequested();

                    this.Processar();
                    Thread.Sleep(TimeSpan.FromSeconds(this.Intervalo));
                }
            }, cancellationToken);
        }
        public ServicoProcessamento(int intervalo, Dictionary<string, object> parametros)
            : this(intervalo)
        {
            this.Parametros = parametros;
        }
        public void Iniciar()
        {
            try
            {
                _Iniciar();
                switch (this.task.Status)
                {
                    case TaskStatus.Canceled:
                    case TaskStatus.Created:
                    case TaskStatus.RanToCompletion:
                    case TaskStatus.WaitingForActivation:
                    case TaskStatus.WaitingToRun:
                    case TaskStatus.Faulted:
                        this.task.Start();
                        break;
                }
            }
            catch (Exception ex)
            {
                ex.ToString();
            }
        }
        public void Parar()
        {
            cancellationTokenSource.Cancel();
        }
        public void Reiniciar()
        {
            Parar();
            Iniciar();
        }
        public abstract void Processar();
    }
}

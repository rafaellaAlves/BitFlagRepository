using BackgroundServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AMaisImob_BackgroundServices.Bases
{
    public abstract class ServicoProcessamento : IServico, IServicoProcessamento
    {
        private Task task { get; set; }
        private CancellationTokenSource cancellationTokenSource { get; set; }
        private CancellationToken cancellationToken { get; set; }
        public Dictionary<string, object> Parametros { get; set; }

        public ServicoProcessamento()
        {
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

                    if (DateTime.Now.Hour == 20 && (DateTime.Now.Minute >= 0 || DateTime.Now.Minute <= 59)) {
                        this.Processar();
                    }
                    Thread.Sleep(TimeSpan.FromHours(1));

                    //var nextDay = DateTime.Now.AddDays(1);
                    //Thread.Sleep(TimeSpan.FromTicks((new DateTime(nextDay.Year, nextDay.Month, nextDay.Day, 6, 0, 0) - DateTime.Now).Ticks));
                }
            }, cancellationToken);
        }
        public ServicoProcessamento(Dictionary<string, object> parametros)
            : this()
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

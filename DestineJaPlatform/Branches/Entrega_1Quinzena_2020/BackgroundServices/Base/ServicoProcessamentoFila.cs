using BackgroundServices.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AMaisImob_BackgroundServices.Bases
{
    public abstract class ServicoProcessamentoFila<T> : ServicoProcessamento, IFilaProcessamento<T> where T : class
    {
        private int maxItemsParalelos { get; set; }
        public int MaxItemsParalelos { get { return this.maxItemsParalelos; } }
        private int unidadesTrabalhando { get; set; }
        public int UnidadesTrabalhando { get { return this.unidadesTrabalhando; } }

        public ServicoProcessamentoFila()
            : base()
        {
            this.DefinirMaxItemsParalelos(1);
        }
        public ServicoProcessamentoFila(Dictionary<string, object> parametros)
            : base(parametros)
        {
            this.DefinirMaxItemsParalelos(1);
        }
        public void DefinirMaxItemsParalelos(int quantidade)
        {
            this.maxItemsParalelos = (quantidade <= 0 ? 1 : quantidade);
        }
        public override async Task Processar()
        {
            for (int i = 0; i < this.maxItemsParalelos; i++)
            {
                if (this.unidadesTrabalhando == this.maxItemsParalelos) continue;

                this.unidadesTrabalhando++;
                await Task.Run(async () =>
                {
                    try
                    {
                        var item = await ObterItem();
                        if (item == null)
                        {
                            this.unidadesTrabalhando--;
                            return;
                        }

                        await ProcessarItem(item);
                        await Finalizar(item);
                    }
                    catch { }
                    this.unidadesTrabalhando--;
                });
            }
        }
        public async Task ProcessarAgora(T item)
        {
            await Task.Run(async () =>
            {
                await ProcessarItem(item);
                await Finalizar(item);
            });
        }
        public abstract Task<T> ObterItem();
        public abstract Task ProcessarItem(T item);
        public abstract Task Progresso(T item);
        public abstract Task Finalizar(T item);
    }
}

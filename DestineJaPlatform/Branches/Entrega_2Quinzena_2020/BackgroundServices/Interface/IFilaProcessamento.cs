using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundServices.Interface
{
    public interface IFilaProcessamento<T> where T : class
    {
        int MaxItemsParalelos { get; }
        void DefinirMaxItemsParalelos(int quantidade);
        Task<T> ObterItem();
        Task ProcessarItem(T item);
        Task ProcessarAgora(T item);
        Task Progresso(T item);
        Task Finalizar(T item);
    }
}

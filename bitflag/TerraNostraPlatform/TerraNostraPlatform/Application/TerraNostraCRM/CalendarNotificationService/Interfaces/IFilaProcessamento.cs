using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundServices.Interfaces
{
    public interface IFilaProcessamento<T> where T : class
    {
        int MaxItemsParalelos { get; }
        void DefinirMaxItemsParalelos(int quantidade);
        T ObterItem();
        void ProcessarItem(T item);
        void ProcessarAgora(T item);
        void Progresso(T item);
        void Finalizar(T item);
    }
}

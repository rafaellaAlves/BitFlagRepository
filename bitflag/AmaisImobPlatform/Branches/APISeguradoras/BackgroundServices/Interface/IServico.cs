using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundServices.Interface
{
    public interface IServico
    {
        /// <summary>
        /// Parâmetros de processamento.
        /// </summary>
        Dictionary<string, object> Parametros { get; set; }

        /// <summary>
        /// Inicia o processamento.
        /// </summary>
        void Iniciar();

        /// <summary>
        /// Para o processamento.
        /// </summary>
        void Parar();

        /// <summary>
        /// Reinicia o processamento.
        /// </summary>
        void Reiniciar();
    }
}

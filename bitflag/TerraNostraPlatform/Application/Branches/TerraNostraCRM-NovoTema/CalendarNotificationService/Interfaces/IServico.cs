using System;
using System.Collections.Generic;
using System.Text;

namespace BackgroundServices.Interfaces
{
    public interface IServico
    {
        /// <summary>
        /// Intervaldo de processamento em segundos.
        /// </summary>
        int Intervalo { get; set; }

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

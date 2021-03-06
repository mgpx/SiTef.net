﻿using System.Threading.Tasks;

namespace SiTef.net.Pool
{
    public interface ITerminalPool
    {
        /// <summary>
        /// Pega um terminal configurado do Pool
        /// </summary>
        /// <returns></returns>
        Task<ITerminal> GetTerminalAsync();

        /// <summary>
        /// Devolve o terminal ao Pool
        /// </summary>
        /// <param name="terminal">Terminal a ser devolvido</param>
        /// <returns></returns>
        Task ReleaseTerminalAsync(ITerminal terminal);

        /// <summary>
        /// Lê a persistência e recupera os terminais associados
        /// a esse pool que não estejam no cache.
        /// </summary>
        /// <returns></returns>
        Task ReclaimTerminalsAsync();
    }
}

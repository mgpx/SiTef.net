﻿using System;
using System.Threading.Tasks;

namespace SiTef.net
{
    public interface ITerminal
    {
        void IniciaTransacao();

        void GravaCampo(IntPtr id, string value);

        string LeCampo(int id, int length);

        void Executa(int acao);

        bool ExistemMaisElementos(int campo);

        string DescricaoErro(int erro);

        void FinalizaTerminal();

        void AddDisposeCallback(Action<ITerminal> callback);

        Task ReleaseAsync();

        void Release();

        string Id { get; set; }
        string Servidor { get; set; }
        string Empresa { get; set; }
    }
}

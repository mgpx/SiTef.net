﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SiTef.net.Type;
using SiTef.net.Action.Model;
using SiTef.net.Action;
using SiTef.net.Pool;

namespace SiTef.net.Tests.Integration
{
    [TestClass]
    public class EstornoPreAutorizacaoTest
    {
        static TerminalFactory factory;

        [ClassInitialize]
        static public void Init(TestContext context)
        {
            factory = new TerminalFactory("127.0.0.1", "00000000");
        }

        [TestMethod]
        public void ExecuteEstornoTest()
        {

            var cartao = new NumeroDoCartao("4929208425739710");
            var vencimento = new DataDeVencimento(12, 15);
            var valor = new Valor(100.00);
            var cvv = new CodigoDeSeguranca("123");

            PreAutorizacaoResponse autorizacao;
            var term = factory.NewInstance();
            var preautoriza = new PreAutorizacaoAction(term);
            autorizacao = preautoriza.Execute(new PreAutorizacaoRequest(
                null,
                new DataFiscal(DateTime.Now),
                null,
                cartao,
                vencimento,
                valor,
                null,
                cvv
            ));

            var estorno = new EstornoPreAutorizacaoAction(term);
            var response = estorno.Execute(
                new EstornoRequest(
                    cartao,
                    vencimento,
                    valor,
                    new DataDaTransacao(DateTime.Now),
                    autorizacao.NumeroAutorizacao,
                    autorizacao.NsuHost,
                    cvv
                ));
            foreach (var field in response.GetFields())
                System.Console.WriteLine(field);
        }
    }
}

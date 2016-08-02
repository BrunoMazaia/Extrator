using ExtracaoDados.EstruturaImportacao;
using System;
using System.Collections.Generic;
using System.Configuration;

namespace ExtracaoDados
{
    class Program
    {
        static void Main(string[] args)
        {
            SecaoPadrao secao = (SecaoPadrao)ConfigurationManager.GetSection("PadraoImportacao");
            foreach (ElementoPadrao item in secao.ItensPadrao)
            {
                Type tipo = Type.GetType(item.Saida);

                switch (tipo.ToString())
                {
                    case @"System.Collections.Generic.List`1[System.String]":
                        IImportacao<List<String>> emLista = new ImportacaoExcel<List<String>>();
                        List<string> resultadoLista = emLista.Processar(item);
                        List<string> rejeitados = emLista.Validar(item);
                        break;
                    default:
                        break;
                }
            }

            Console.ReadKey();
        }
    }
}

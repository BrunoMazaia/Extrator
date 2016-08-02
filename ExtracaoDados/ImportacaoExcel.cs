using Excel;
using ExtracaoDados.EstruturaImportacao;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;

namespace ExtracaoDados
{
    public class ImportacaoExcel<T> : IImportacao<T> where T : IList<String>
    {
        private T retorno;
        private Exception erroProcessamento = null;

        public Exception Erro()
        {
            return erroProcessamento;
        }

        public T Processar(ElementoPadrao padraoProcessamento)
        {
            try
            {
                FileStream stream = File.Open(Path.Combine(padraoProcessamento.Path, padraoProcessamento.Nome), FileMode.Open, FileAccess.Read);

                IExcelDataReader excelReader = null;

                if (Regex.Match(padraoProcessamento.Nome, @"\.xls$").Success)
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                else
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);

                excelReader.IsFirstRowAsColumnNames = padraoProcessamento.IgnorarPrimeiraLinha;

                DataSet result = excelReader.AsDataSet();

                retorno = (T)Activator.CreateInstance(typeof(T));

                for (int iPlanilha = 0; iPlanilha < result.Tables.Count; iPlanilha++)
                {
                    for (int iLinha = 0; iLinha < result.Tables[iPlanilha].Rows.Count; iLinha++)
                    {
                        StringBuilder linha = new StringBuilder();

                        for (int iColuna = 0; iColuna < result.Tables[iPlanilha].Rows[iLinha].ItemArray.Length; iColuna++)
                        {
                            linha.Append(result.Tables[iPlanilha].Rows[iLinha].ItemArray.GetValue(iColuna).ToString());
                            linha.Append(padraoProcessamento.Separador);
                        }

                        retorno.Add(linha.ToString());
                    }
                }

            }
            catch (Exception erro)
            {
                erroProcessamento = new Exception("Erro durante importação.", erro);
                retorno = default(T);
            }

            return retorno;
        }

        public T Validar(ElementoPadrao padraoProcessamento)
        {
            T rejeitados = (T)Activator.CreateInstance(typeof(T));
            try
            {
                if (!padraoProcessamento.PadraoLinha.Equals(string.Empty))
                {
                    for (int i = 0; i < retorno.Count; i++)
                    {
                        if (!Regex.Match(retorno[i], padraoProcessamento.PadraoLinha).Success)
                            rejeitados.Add(retorno[i]);
                    }
                }
            }
            catch (Exception erro)
            {
                erroProcessamento = new Exception("Erro durante validação.", erro);
                rejeitados = default(T);
            }
            return rejeitados;
        }

        public T Transformar(ElementoPadrao padraoProcessamento)
        {
            T transformados = (T)Activator.CreateInstance(typeof(T));
            try
            {
                if (!padraoProcessamento.FormatoSaida.Equals(string.Empty) &&
                    !padraoProcessamento.PadraoLinha.Equals(string.Empty))
                {
                    for (int i = 0; i < retorno.Count; i++)
                    {
                        if (Regex.Match(retorno[i], padraoProcessamento.PadraoLinha).Success)
                            transformados.Add(Regex.Replace(retorno[i].ToString(),
                                padraoProcessamento.PadraoLinha, padraoProcessamento.FormatoSaida));
                    }
                }
            }
            catch (Exception erro)
            {
                erroProcessamento = new Exception("Erro durante validação.", erro);
                transformados = default(T);
            }
            return transformados;
        }

    }
}

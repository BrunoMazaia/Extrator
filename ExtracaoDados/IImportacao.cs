using ExtracaoDados.EstruturaImportacao;
using System;
using System.Collections.Generic;

namespace ExtracaoDados
{
    public interface IImportacao<T>
    {
        Exception Erro();
        T Processar(ElementoPadrao padraoProcessamento);
        T Validar(ElementoPadrao padraoProcessamento);
        T Transformar(ElementoPadrao padraoProcessamento);
    }
}

using System.Configuration;

namespace ExtracaoDados.EstruturaImportacao
{    /// <summary>
    /// Classe que contém os dados de cada elemento do arquivo de configuração fornecido.
    /// </summary>
    public class ElementoPadrao : ConfigurationElement
    {
        /// <summary>
        /// Id sequencial dos arquivos do .config
        /// </summary>
        [ConfigurationProperty("Id", IsKey = true, IsRequired = true)]
        public int Id
        {
            get
            {
                return ((int)(base["Id"]));
            }

            set
            {
                base["Id"] = value;
            }
        }
        /// <summary>
        /// Nome do arquivo
        /// </summary>
        [ConfigurationProperty("Nome", IsKey = false, IsRequired = true)]
        public string Nome
        {
            get
            {
                return ((string)(base["Nome"]));
            }

            set
            {
                base["Nome"] = value;
            }
        }
        /// <summary>
        /// Path do arquivo
        /// </summary>
        [ConfigurationProperty("Path", IsKey = false, IsRequired = true)]
        public string Path
        {
            get
            {
                return ((string)(base["Path"]));
            }

            set
            {
                base["Path"] = value;
            }
        }
        /// <summary>
        /// Tipo do arquivo de entrada { Excel | Texto }
        /// </summary>
        [ConfigurationProperty("TipoEntrada", IsKey = false, IsRequired = true)]
        public string TipoEntrada
        {
            get
            {
                return ((string)(base["TipoEntrada"]));
            }

            set
            {
                base["TipoEntrada"] = value;
            }
        }
        /// <summary>
        /// Expressão Regex para validação de cada linha do arquivo fornecido.
        /// </summary>
        [ConfigurationProperty("PadraoLinha", IsKey = false, IsRequired = false)]
        public string PadraoLinha
        {
            get
            {
                return ((string)(base["PadraoLinha"]));
            }

            set
            {
                base["PadraoLinha"] = value;
            }
        }
        /// <summary>
        /// Expressão Regex para validação do nome do arquivo.
        /// </summary>
        [ConfigurationProperty("PadraoArquivo", IsKey = false, IsRequired = false)]
        public string PadraoArquivo
        {
            get
            {
                return ((string)(base["PadraoArquivo"]));
            }

            set
            {
                base["PadraoArquivo"] = value;
            }
        }
        /// <summary>
        /// Tipo de saída: { String | Array }
        /// </summary>
        [ConfigurationProperty("Saida", IsKey = false, IsRequired = true)]
        public string Saida
        {
            get
            {
                return ((string)(base["Saida"]));
            }

            set
            {
                base["Saida"] = value;
            }
        }
        /// <summary>
        /// Formato de saída (regex)
        /// </summary>
        [ConfigurationProperty("FormatoSaida", IsKey = false, IsRequired = false)]
        public string FormatoSaida
        {
            get
            {
                return ((string)(base["FormatoSaida"]));
            }

            set
            {
                base["FormatoSaida"] = value;
            }
        }
        /// <summary>
        /// Informa se deseja ignorar a primeira linha, padrão é False.
        /// </summary>
        [ConfigurationProperty("IgnorarPrimeiraLinha", IsKey = false, IsRequired = false, DefaultValue = false)]
        public bool IgnorarPrimeiraLinha
        {
            get
            {
                return ((bool)(base["IgnorarPrimeiraLinha"]));
            }

            set
            {
                base["IgnorarPrimeiraLinha"] = value;
            }
        }
        /// <summary>
        /// Informa o separador para os dados de saída.
        /// </summary>
        [ConfigurationProperty("Separador", IsKey = false, IsRequired = true)]
        public string Separador
        {
            get
            {
                return ((string)(base["Separador"]));
            }

            set
            {
                base["Separador"] = value;
            }
        }
    }
}


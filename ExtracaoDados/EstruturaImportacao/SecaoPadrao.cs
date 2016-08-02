using System.Configuration;

namespace ExtracaoDados.EstruturaImportacao
{
    /// <summary>
    /// Classe que será carregada com os dados XML do App.config via Configuration Manager.
    /// </summary>
    public class SecaoPadrao : ConfigurationSection
    {
        /// <summary>
        /// Coleção de dados que serão carregados da tag Padroes.
        /// </summary>
        [ConfigurationProperty("Arquivo")]
        public Padroes ItensPadrao
        {
            get { return ((Padroes)(base["Arquivo"])); }
        }
    }
}


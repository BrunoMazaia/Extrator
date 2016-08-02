using System.Configuration;

namespace ExtracaoDados.EstruturaImportacao
{
    /// <summary>
    /// Classe com a coleção de dados retornados pelo Configuration Manager.
    /// </summary>
    [ConfigurationCollection(typeof(ElementoPadrao))]
    public class Padroes : ConfigurationElementCollection
    {
        protected override ConfigurationElement CreateNewElement()
        {
            return new ElementoPadrao();
        }

        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ElementoPadrao)(element)).Id;
        }

        public ElementoPadrao this[int indice]
        {
            get
            {
                return (ElementoPadrao)BaseGet(indice);
            }
        }
    }
}
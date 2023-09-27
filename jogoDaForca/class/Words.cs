namespace Words
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Newtonsoft.Json;

    public partial class WordsJson
    {
        [JsonProperty("words")]
        public Word[] Words { get; set; }
    }

    public partial class Word
    {
        // o campo word sera referenciado como escrita porque fodase
        [JsonProperty("word")]
        public string escrita { get; set; }

        // o Hint como dica pelo mesmo motivo
        [JsonProperty("hint")]
        public string dica { get; set; }
        public object Words { get; internal set; }
    }
}

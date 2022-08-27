using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Innovea.ConsumirAPI.Dtos
{
    
    
    public class ArtigoDto
    {
        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
    }

    public class Recurso
    {
        [JsonProperty("articles")]
        public IEnumerable<ArtigoDto> ArtigoDto { get; set; }      
    }


}

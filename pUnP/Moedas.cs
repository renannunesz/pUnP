using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;
using Newtonsoft.Json;

namespace pUnP
{
    [JsonObject(MemberSerialization = MemberSerialization.OptIn)]
    public class Moedas
    {        
        
        public class MoedasList : List<Moedas>
        {
            [JsonProperty(PropertyName = "id")]
            public string id { get; set; }

            [JsonProperty(PropertyName = "currency")]
            public string Currency { get; set; }
        }
    }
}
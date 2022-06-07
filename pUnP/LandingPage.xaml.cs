using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;

namespace pUnP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();
            //mudaMoeda();
            dadosMoedas();
        }

        public void mudaMoeda()
        {

            string TextoTeste = "Esse texto é um teste";

            lblMoeda1.Text = TextoTeste;

        }

        async void dadosMoedas()
        {

            
            string enderecoUrl = "https://api.nomics.com/v1/currencies/ticker?key=880b3ff2d79ab3b10e72d99097082ed9da6d7d47&ids=BTC,ETH,XRP&interval=1d,30d&convert=EUR&platform-currency=ETH&per-page=100&page=1";
            HttpClient client = new HttpClient();
            var json = await client.GetStringAsync(enderecoUrl);
            //var dados = JsonConvert.DeserializeObject<List<string>>(json);

            var Moedas = JsonConvert.DeserializeObject<List<Moedas>>(json);

            //lblMoeda1.Text = Moedas.''
        }

    }
}
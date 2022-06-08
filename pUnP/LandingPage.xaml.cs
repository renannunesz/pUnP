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

        public async void dadosMoedas()
        {
            string dadosUrl = "https://economia.awesomeapi.com.br/last/USD-BRL,EUR-BRL,BTC-BRL";
            HttpClient client = new HttpClient();
            var jsonDados = await client.GetStringAsync(dadosUrl);
            var Moedas = JsonConvert.DeserializeObject<Rootobject>(jsonDados);

            lblMoeda.Text = Moedas.BTCBRL.name;
            lblSiglaOrigem.Text = Moedas.BTCBRL.code;
            lblSiglaDestino.Text = Moedas.BTCBRL.codein;
            lblCompra.Text = Moedas.BTCBRL.bid;
            lblVenda.Text = Moedas.BTCBRL.ask;            

        }



    }
}
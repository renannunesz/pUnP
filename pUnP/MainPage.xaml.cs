using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Net.Http;

namespace pUnP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        void btnEnviar_Clicked(System.Object sender, System.EventArgs e)
        {
            //validaUser(entUser.Text);
            //validaPass(entPass.Text);
            validaDados(entUser.Text, entPass.Text);
            //moedasDados();
        }

        public async void validaDados(string user, string pass)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user))
            {
                entUser.BackgroundColor = Color.Red;
                await DisplayAlert("Confirmacao!", "Campo Usuario Invalido!", "OK");
            }

            if (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass))
            {
                entPass.BackgroundColor = Color.Red;
                await DisplayAlert("Confirmacao!", "Campo Senha Invalido!", "OK");
            }

            else
            {
                entUser.BackgroundColor = Color.Default;
                entPass.BackgroundColor = Color.Default;
                await DisplayAlert("Confirmaçao", "Campos Validados com Sucesso!", "OK");
                await Navigation.PushAsync(new LandingPage());
            }
        }

        public async void validaUser(string user)
        {
            if (string.IsNullOrEmpty(user) || string.IsNullOrWhiteSpace(user))
            {
                entUser.BackgroundColor = Color.Red;
                await DisplayAlert("Confirmacao!", "Campo Usuario Invalido!", "OK");
            }
        }

        public async void validaPass(string pass)
        {
            if (string.IsNullOrEmpty(pass) || string.IsNullOrWhiteSpace(pass))
            {
                entPass.BackgroundColor = Color.Red;
                await DisplayAlert("Confirmacao!", "Campo Senha Invalido!", "OK");
            }
        }

        public async void moedasDados()
        {
            string dadosUrl = "https://economia.awesomeapi.com.br/last/USD-BRL,EUR-BRL,BTC-BRL";
            HttpClient client = new HttpClient();
            var jsonDados = await client.GetStringAsync(dadosUrl);
            var Moedas = JsonConvert.DeserializeObject<Rootobject>(jsonDados);

            //lblTelaAuth.Text = Moedas.BTCBRL.codein;

        }

        public class Rootobject
        {
            public USDBRL USDBRL { get; set; }
            public EURBRL EURBRL { get; set; }
            public BTCBRL BTCBRL { get; set; }
        }

        public class USDBRL
        {
            public string code { get; set; }
            public string codein { get; set; }
            public string name { get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string varBid { get; set; }
            public string pctChange { get; set; }
            public string bid { get; set; }
            public string ask { get; set; }
            public string timestamp { get; set; }
            public string create_date { get; set; }
        }

        public class EURBRL
        {
            public string code { get; set; }
            public string codein { get; set; }
            public string name { get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string varBid { get; set; }
            public string pctChange { get; set; }
            public string bid { get; set; }
            public string ask { get; set; }
            public string timestamp { get; set; }
            public string create_date { get; set; }
        }

        public class BTCBRL
        {
            public string code { get; set; }
            public string codein { get; set; }
            public string name { get; set; }
            public string high { get; set; }
            public string low { get; set; }
            public string varBid { get; set; }
            public string pctChange { get; set; }
            public string bid { get; set; }
            public string ask { get; set; }
            public string timestamp { get; set; }
            public string create_date { get; set; }
        }

    }
}

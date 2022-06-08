using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

namespace pUnP
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LandingPage : ContentPage
    {
        public LandingPage()
        {
            InitializeComponent();            
            dadosMoedas();
            lblTitMoeda.Text = "Valores de moedas atualizados em: " + DateTime.Now.ToString("dd/MM/yyyy");
        }

        public async void dadosMoedas()
        {
            string dadosUrl = "https://economia.awesomeapi.com.br/last/USD-BRL,EUR-BRL,BTC-BRL";
            HttpClient client = new HttpClient();
            var jsonDados = await client.GetStringAsync(dadosUrl);
            var Moedas = JsonConvert.DeserializeObject<Rootobject>(jsonDados);     

            lblRowGrid_1.Text = "Conversão: " + Moedas.BTCBRL.name + "\n" 
                + "Sigla Origem: " + Moedas.BTCBRL.code + "\n"
                + "Sigla Destino: " + Moedas.BTCBRL.codein + "\n"                
                + "Valor Compra: " + string.Format("{0:C}", Moedas.BTCBRL.bid) + "\n"
                + "Valor Venda: " + string.Format("{0:C}", Moedas.BTCBRL.ask) ;

            lblRowGrid_2.Text = "Conversão: " + Moedas.EURBRL.name + "\n"
                + "Sigla Origem: " + Moedas.EURBRL.code + "\n"
                + "Sigla Destino: " + Moedas.EURBRL.codein + "\n"
                + "Valor Compra: " + string.Format("{0:C}", Moedas.EURBRL.bid) + "\n"
                + "Valor Venda: " + string.Format("{0:C}", Moedas.EURBRL.ask) ;

            lblRowGrid_3.Text = "Conversão: " + Moedas.USDBRL.name + "\n"
                + "Sigla Origem: " + Moedas.USDBRL.code + "\n"
                + "Sigla Destino: " + Moedas.USDBRL.codein + "\n"
                + "Valor Compra: " + string.Format("{0:c}", Moedas.USDBRL.bid) + "\n"
                + "Valor Venda: " + string.Format("{0:C}", Moedas.USDBRL.ask) ;
        }


        private void btnEnviarEmail_Clicked(object sender, EventArgs e)
        {
            _ = enviarEmail();
        }

        public void enviarEmail()
        {

            //var emailTo = DisplayPromptAsync("Email", "Informe o email desejado:");

            /*
            string dadosUrl = "https://economia.awesomeapi.com.br/last/USD-BRL,EUR-BRL,BTC-BRL";
            HttpClient client = new HttpClient();
            var jsonDados = await client.GetStringAsync(dadosUrl);
            var Moedas = JsonConvert.DeserializeObject<Rootobject>(jsonDados);
            */
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp-mail.outlook.com");

            mail.From = new MailAddress("punp@outlook.com.br");
            mail.To.Add("ti@metodos-rnc.com.br"); //emailTo.ToString()
            mail.Subject = "Cotação de moedas em " + DateTime.Now.ToString("dd/MM/yyyy");
            /*
             * mail.Body = "Conversão: " + Moedas.BTCBRL.name + " Sigla Origem: " + Moedas.BTCBRL.code + " Sigla Destino: " + Moedas.BTCBRL.codein + " Valor Compra: " + string.Format("{0:C}", Moedas.BTCBRL.bid) + " Valor Venda: " + string.Format("{0:C}", Moedas.BTCBRL.ask) + "\n" +
                        "Conversão: " + Moedas.EURBRL.name + " Sigla Origem: " + Moedas.EURBRL.code + " Sigla Destino: " + Moedas.EURBRL.codein + " Valor Compra: " + string.Format("{0:C}", Moedas.EURBRL.bid) + " Valor Venda: " + string.Format("{0:C}", Moedas.EURBRL.ask) + "\n" +
                        "Conversão: " + Moedas.USDBRL.name + " Sigla Origem: " + Moedas.USDBRL.code + " Sigla Destino: " + Moedas.USDBRL.codein + " Valor Compra: " + string.Format("{0:C}", Moedas.USDBRL.bid) + " Valor Venda: " + string.Format("{0:C}", Moedas.USDBRL.ask) + "\n";
            */
            SmtpServer.Port = 587;
            SmtpServer.Host = "smtp-mail.outlook.com";
            SmtpServer.EnableSsl = true;
            SmtpServer.UseDefaultCredentials = false;
            SmtpServer.Credentials = new System.Net.NetworkCredential("punp@outlook.com.br", "123Renan");

            SmtpServer.Send(mail);

        }

    }
}
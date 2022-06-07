using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

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

    }
}

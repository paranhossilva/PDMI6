using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TP02
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnPadrao_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Padrao());
        }

        private async void btnDinamico_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Dinamico());
        }

        private async void btnTriggers_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Page1());
        }

        private void btnGlobal_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnHome_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Home());
        }

        private void btnCenter_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnSimples_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Simples());
        }

        private void btnComplexa_Clicked(object sender, EventArgs e)
        {

        }

        private async void btnProduto_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ListView());
        }

        private void btnCreditos_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Créditos", "Bruno Paranhos Silva      CB3005437", "Ok");
        }
    }
}

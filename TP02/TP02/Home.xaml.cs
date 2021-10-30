using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TP02
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Home : ContentPage
    {
        public Home()
        {
            InitializeComponent();
        }

        private async void btnOk_Clicked(object sender, EventArgs e)
        {
            var contrato = new Contrato
            {
                Nome = txtNome.Text,
                Idade = int.Parse(txtIdade.Text),
                Profissao = txtProfissao.Text,
                Pais = txtPais.Text
            };

            var detalhe = new Detalhe();

            detalhe.BindingContext = contrato;

            await Navigation.PushAsync(detalhe);
        }

        private async void btnVoltar_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}
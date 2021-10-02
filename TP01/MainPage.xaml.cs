using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TP01
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private String id, senha;

        private void btnOk_Clicked(object sender, EventArgs e)
        {
            id = txtId.Text;
            senha = txtSenha.Text;

            if (id.Equals("admin") && senha.Equals("senha@dmin"))
                DisplayAlert("Login efetuado com sucesso", "Bem Vindo!", "Ok");
            else
                DisplayAlert("Erro!", "Id e/ou senha incorretos", "Ok");

            limpar();
        }

        private void btnLimpar_Clicked(object sender, EventArgs e)
        {
            limpar();
        }

        private void btnCreditos_Clicked(object sender, EventArgs e)
        {
            DisplayAlert("Créditos", "Bruno Paranhos Silva      CB3005437", "Ok");
        }

        private void limpar()
        {
            txtId.Text = null;
            txtSenha.Text = null;
        }
    }
}

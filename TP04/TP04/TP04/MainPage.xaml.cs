using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP04.Model;
using TP04.AlunoViewModel;
using Xamarin.Forms;

namespace TP04
{
    public partial class MainPage : ContentPage
    {
        TP04.AlunoViewModel.AlunoViewModel vmAluno;

        public MainPage()
        {
            vmAluno = new TP04.AlunoViewModel.AlunoViewModel();
            BindingContext = vmAluno;

            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            vmAluno = new TP04.AlunoViewModel.AlunoViewModel();
            BindingContext = vmAluno;
            base.OnAppearing();
        }

        private void btnNovo_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new NovoAlunoView());
        }

        private void lstAlunos_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            var selecionado = e.Item as Aluno;
            DisplayAlert("Aluno Selecionado", "Aluno: " + selecionado.Id, "OK");
        }
    }
}

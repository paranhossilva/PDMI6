using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TPFinal.Models;
using Xamarin.Forms;

namespace TPFinal
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAdd_Clicked(object sender, EventArgs e)
        {
            if (Verifica())
            {
                Produto produto = new Produto()
                {
                    Id = 0,
                    Nome = txtNome.Text,
                    Peso = float.Parse(txtPeso.Text),
                    Produtor = txtProdutor.Text,
                    Email = txtEmail.Text,
                    NCM = int.Parse(txtNCM.Text)
                };

                //Add New Produto  
                await App.SQLiteDb.SaveItemAsync(produto);

                Limpa();

                await DisplayAlert("Sucesso!", "Produto Salvo Com Sucesso!", "OK");

                //Get All Produtos  
                var lista = await App.SQLiteDb.GetItemsAsync();

                if (lista != null)
                {
                    lstProdutos.ItemsSource = lista;
                }
            }
            else
            {
                await DisplayAlert("Atenção!", "Prencha todos os campos", "OK");
            }        
        }

        private async void btnSelect_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtId.Text))
            {
                //Get Produto  
                var produto = await App.SQLiteDb.GetItemAsync(int.Parse(txtId.Text));

                if (produto != null)
                {
                    txtId.Text = produto.Id.ToString();
                    txtNome.Text = produto.Nome;
                    txtPeso.Text = produto.Peso.ToString();
                    txtProdutor.Text = produto.Produtor;
                    txtEmail.Text = produto.Email;
                    txtNCM.Text = produto.NCM.ToString();
                }
            }
            else
            {
                await DisplayAlert("Atenção!", "Informe o ID do Produto", "OK");
            }
        }

        private async void btnUpdate_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtId.Text) && Verifica())
            {
                Produto produto = new Produto()
                {
                    Id = int.Parse(txtId.Text),
                    Nome = txtNome.Text,
                    Peso = float.Parse(txtPeso.Text),
                    Produtor = txtProdutor.Text,
                    Email = txtEmail.Text,
                    NCM = int.Parse(txtNCM.Text)
                };

                //Update Produto  
                await App.SQLiteDb.SaveItemAsync(produto);

                Limpa();

                await DisplayAlert("Sucesso!", "Produto Alterado Com Sucesso!", "OK");
                //Get All Produtos  
                var lista = await App.SQLiteDb.GetItemsAsync();
                if (lista != null)
                {
                    lstProdutos.ItemsSource = lista;
                }

            }
            else
            {
                await DisplayAlert("Atenção!", "Prencha todos os campos", "OK");
            }
        }

        private async void btnDelete_Clicked(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(txtId.Text))
            {
                //Get Produto  
                var produto = await App.SQLiteDb.GetItemAsync(Convert.ToInt32(txtId.Text));
                if (produto != null)
                {
                    //Delete Produto  
                    await App.SQLiteDb.DeleteItemAsync(produto);

                    Limpa();

                    await DisplayAlert("Sucesso!", "Produto Excluido Com Sucesso!", "OK");

                    //Get All Produtos  
                    var lista = await App.SQLiteDb.GetItemsAsync();
                    if (lista != null)
                    {
                        lstProdutos.ItemsSource = lista;
                    }
                }
            }
            else
            {
                await DisplayAlert("Atenção!", "Informe o ID do Produto", "OK");
            }
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            //Get All Produtos  
            var lista = await App.SQLiteDb.GetItemsAsync();
            if (lista != null)
            {
                lstProdutos.ItemsSource = lista;
            }
        }

        private bool Verifica()
        {
            return !(String.IsNullOrEmpty(txtNome.Text) || String.IsNullOrEmpty(txtPeso.Text) || String.IsNullOrEmpty(txtProdutor.Text) || String.IsNullOrEmpty(txtEmail.Text) || String.IsNullOrEmpty(txtNCM.Text));
        }    
        
        private void Limpa()
        {
            txtId.Text = String.Empty;
            txtNome.Text = String.Empty;
            txtPeso.Text = String.Empty;
            txtProdutor.Text = String.Empty;
            txtEmail.Text = String.Empty;
            txtNCM.Text = String.Empty;
        }
    }
}

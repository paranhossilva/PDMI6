using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Newtonsoft.Json;

namespace TP03
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnOk_Clicked(object sender, EventArgs e)
        {
            var cliente = new HttpClient();
            var response = await cliente.GetAsync($"https://pokeapi.co/api/v2/pokemon/{txtTexto.Text.ToLower()}");

            if (response.IsSuccessStatusCode)
            {
                Pokemon pokemon = JsonConvert.DeserializeObject<Pokemon>(await response.Content.ReadAsStringAsync());

                var page = new Page();

                page.BindingContext = ContextoPokemon(pokemon);

                await Navigation.PushAsync(page);
            }
            else{
                await DisplayAlert("Erro!", "Pokémon não encontrado", "Ok");
            }
        }

        private object ContextoPokemon(Pokemon pokemon)
        {
            String tipos = "Tipos: ";

            root root = JsonConvert.DeserializeObject<root>(pokemon.types[0].ToString());

            tipos += char.ToUpper(root.type.name[0]) + root.type.name.Substring(1);

            if (pokemon.types.Count > 1)
            {
                root = JsonConvert.DeserializeObject<root>(pokemon.types[1].ToString());

                tipos += ", " + char.ToUpper(root.type.name[0]) + root.type.name.Substring(1);
            }

            var contexto = new Contexto
            {
                id = $"ID: {pokemon.id}",
                nome = $"{char.ToUpper(pokemon.name[0]) + pokemon.name.Substring(1)}",
                peso = $"Peso: {pokemon.weight / 10} Kg",
                altura = $"Altura: {pokemon.height / 10} m",
                url = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/other/official-artwork/{pokemon.id}.png",
                tipo = tipos
            };

            return contexto;
        }
    }
}

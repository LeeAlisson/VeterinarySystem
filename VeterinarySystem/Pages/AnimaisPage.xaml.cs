using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace VeterinarySystem.Pages
{
    public partial class AnimaisPage : ContentPage
    {
        private ObservableCollection<object> _animais;

        public AnimaisPage()
        {
            InitializeComponent();

            // Dados fictícios
            _animais = new ObservableCollection<object>
            {
                new { animalid = 1, nome = "Rex", especie = "Canino", raca = "Labrador", datanascimento = new DateTime(2020, 5, 15) },
                new { animalid = 2, nome = "Miau", especie = "Felino", raca = "Siamês", datanascimento = new DateTime(2021, 3, 10) },
                new { animalid = 3, nome = "Pingo", especie = "Canino", raca = "Poodle", datanascimento = new DateTime(2019, 8, 22) },
                new { animalid = 4, nome = "Luna", especie = "Felino", raca = "Persa", datanascimento = new DateTime(2022, 1, 5) },
                new { animalid = 5, nome = "Thor", especie = "Canino", raca = "Pastor Alemão", datanascimento = new DateTime(2018, 11, 30) }
            };

            AnimaisCollection.ItemsSource = _animais;
        }

        private async void OnNovoAnimalClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NovoAnimalPage");
        }

        private async void OnEditarAnimalClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var animal = button.BindingContext;

            var navigationParameter = new Dictionary<string, object>
            {
                { "Animal", animal }
            };

            await Shell.Current.GoToAsync("EditarAnimalPage", navigationParameter);
        }

        private async void OnExcluirAnimalClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var animal = button.BindingContext;

            bool resposta = await DisplayAlert("Confirmação", "Deseja realmente excluir este animal?", "Sim", "Não");
            if (resposta)
            {
                _animais.Remove(animal);
                await DisplayAlert("Sucesso", "Animal excluído com sucesso!", "OK");
            }
        }
    }
}
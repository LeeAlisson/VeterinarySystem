using Microsoft.Maui.Controls;

namespace VeterinarySystem.Pages
{
    public partial class NovoAnimalPage : ContentPage
    {
        public NovoAnimalPage()
        {
            InitializeComponent();

            DataNascimentoDatePicker.Date = DateTime.Today;

            // Dados fict�cios
            EspeciePicker.ItemsSource = new List<string> { "Canino", "Felino", "Ave", "R�ptil", "Roedor" };
            ProprietarioPicker.ItemsSource = new List<string> { "Jo�o Silva", "Maria Oliveira", "Carlos Santos" };
        }

        private async void OnCancelarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSalvarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeEntry.Text))
            {
                await DisplayAlert("Erro", "O nome do animal � obrigat�rio.", "OK");
                return;
            }

            await DisplayAlert("Sucesso", "Animal cadastrado com sucesso!", "OK");
            await Shell.Current.GoToAsync("..");
        }

        private async void OnNovoProprietarioClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NovoClientePage");
        }
    }
}
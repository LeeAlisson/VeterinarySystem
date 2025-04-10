using Microsoft.Maui.Controls;

namespace VeterinarySystem.Pages
{
    public partial class NovoClientePage : ContentPage
    {
        public NovoClientePage()
        {
            InitializeComponent();

            DataCadastroDatePicker.Date = DateTime.Today;
        }

        private async void OnCancelarClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("..");
        }

        private async void OnSalvarClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeEntry.Text))
            {
                await DisplayAlert("Erro", "O nome do cliente é obrigatório.", "OK");
                return;
            }

            await DisplayAlert("Sucesso", "Cliente cadastrado com sucesso!", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
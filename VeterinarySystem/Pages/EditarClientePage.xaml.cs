using Microsoft.Maui.Controls;

namespace VeterinarySystem.Pages
{
    [QueryProperty(nameof(Cliente), "Cliente")]
    public partial class EditarClientePage : ContentPage
    {
        private object? _cliente;

        public object Cliente
        {
            get => _cliente;
            set
            {
                _cliente = value;
                CarregarDadosCliente();
            }
        }

        public EditarClientePage()
        {
            InitializeComponent();
        }

        private void CarregarDadosCliente()
        {
            if (_cliente != null)
            {
                var type = _cliente.GetType();

                NomeEntry.Text = GetPropertyValue<string>("nome");
                CpfEntry.Text = GetPropertyValue<string>("cpf");
                TelefoneEntry.Text = GetPropertyValue<string>("telefone");
                EmailEntry.Text = GetPropertyValue<string>("email");

                DataCadastroDatePicker.Date = DateTime.Today;
            }
        }

        private T? GetPropertyValue<T>(string propertyName)
        {
            try
            {
                var property = _cliente?.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    return (T)property.GetValue(_cliente);
                }
                return default;
            }
            catch
            {
                return default;
            }
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

            await DisplayAlert("Sucesso", "Cliente atualizado com sucesso!", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace VeterinarySystem.Pages
{
    public partial class ClientesPage : ContentPage
    {
        private ObservableCollection<object> _clientes;

        public ClientesPage()
        {
            InitializeComponent();

            // Dados fictícios
            _clientes = new ObservableCollection<object>
            {
                new { cliid = 1, nome = "João Silva", cpf = "123.456.789-00", telefone = "(11) 98765-4321", email = "joao@email.com" },
                new { cliid = 2, nome = "Maria Oliveira", cpf = "987.654.321-00", telefone = "(11) 91234-5678", email = "maria@email.com" },
                new { cliid = 3, nome = "Carlos Santos", cpf = "456.789.123-00", telefone = "(11) 99876-5432", email = "carlos@email.com" }
            };

            ClientesCollection.ItemsSource = _clientes;
        }

        private async void OnNovoClienteClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NovoClientePage");
        }

        private async void OnEditarClienteClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var cliente = button.BindingContext;

            var navigationParameter = new Dictionary<string, object>
            {
                { "Cliente", cliente }
            };

            await Shell.Current.GoToAsync("EditarClientePage", navigationParameter);
        }

        private async void OnExcluirClienteClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var cliente = button.BindingContext;

            bool resposta = await DisplayAlert("Confirmação", "Deseja realmente excluir este cliente?", "Sim", "Não");
            if (resposta)
            {
                _clientes.Remove(cliente);
                await DisplayAlert("Sucesso", "Cliente excluído com sucesso!", "OK");
            }
        }
    }
}
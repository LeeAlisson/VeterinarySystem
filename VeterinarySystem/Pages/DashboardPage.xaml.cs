using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace VeterinarySystem.Pages
{
    public partial class DashboardPage : ContentPage
    {
        private ObservableCollection<object> _ultimosClientes;

        public DashboardPage()
        {
            InitializeComponent();

            // Dados fictícios
            _ultimosClientes = new ObservableCollection<object>
            {
                new { nome = "João Silva", telefone = "(11) 98765-4321" },
                new { nome = "Maria Oliveira", telefone = "(11) 91234-5678" },
                new { nome = "Carlos Santos", telefone = "(11) 99876-5432" }
            };

            TotalClientesLabel.Text = "3";
            TotalAnimaisLabel.Text = "5";

            UltimosClientesCollection.ItemsSource = _ultimosClientes;
        }

        private async void OnNovoClienteClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NovoClientePage");
        }

        private async void OnNovoAnimalClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("NovoAnimalPage");
        }

        private async void OnBuscarClienteClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//ClientesPage");
        }

        private async void OnBuscarAnimalClicked(object sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//AnimaisPage");
        }
    }
}
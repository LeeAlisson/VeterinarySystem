using Microsoft.Maui.Controls;

namespace VeterinarySystem.Pages
{
    [QueryProperty(nameof(Animal), "Animal")]
    public partial class EditarAnimalPage : ContentPage
    {
        private object? _animal;

        public object Animal
        {
            get => _animal;
            set
            {
                _animal = value;
                CarregarDadosAnimal();
            }
        }

        public EditarAnimalPage()
        {
            InitializeComponent();

            // Dados fictícios
            EspeciePicker.ItemsSource = new List<string> { "Canino", "Felino", "Ave", "Réptil", "Roedor" };
            ProprietarioPicker.ItemsSource = new List<string> { "João Silva", "Maria Oliveira", "Carlos Santos" };
        }

        private void CarregarDadosAnimal()
        {
            if (_animal != null)
            {
                NomeEntry.Text = GetPropertyValue<string>("nome");
                RacaEntry.Text = GetPropertyValue<string>("raca");

                string especie = GetPropertyValue<string>("especie");
                if (!string.IsNullOrEmpty(especie) && EspeciePicker.ItemsSource is List<string> especies)
                {
                    int index = especies.IndexOf(especie);
                    if (index >= 0)
                    {
                        EspeciePicker.SelectedIndex = index;
                    }
                }

                DateTime dataNascimento = GetPropertyValue<DateTime>("datanascimento");
                if (dataNascimento != default)
                {
                    DataNascimentoDatePicker.Date = dataNascimento;
                }
                else
                {
                    DataNascimentoDatePicker.Date = DateTime.Today;
                }
            }
        }

        private T? GetPropertyValue<T>(string propertyName)
        {
            try
            {
                var property = _animal?.GetType().GetProperty(propertyName);
                if (property != null)
                {
                    return (T)property.GetValue(_animal);
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
                await DisplayAlert("Erro", "O nome do animal é obrigatório.", "OK");
                return;
            }

            await DisplayAlert("Sucesso", "Animal atualizado com sucesso!", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}
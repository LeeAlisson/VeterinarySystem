using Microsoft.Maui.Controls;
using System.Collections.ObjectModel;

namespace VeterinarySystem.Pages
{
    public partial class EspeciesPage : ContentPage
    {
        private ObservableCollection<object> _especies;

        public EspeciesPage()
        {
            InitializeComponent();

            // Dados fict�cios
            _especies = new ObservableCollection<object>
            {
                new { espid = 1, nomeespecie = "Canino" },
                new { espid = 2, nomeespecie = "Felino" },
                new { espid = 3, nomeespecie = "Ave" },
                new { espid = 4, nomeespecie = "R�ptil" },
                new { espid = 5, nomeespecie = "Roedor" }
            };

            EspeciesCollection.ItemsSource = _especies;
        }

        private async void OnAdicionarEspecieClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NomeEspecieEntry.Text))
            {
                await DisplayAlert("Erro", "O nome da esp�cie � obrigat�rio.", "OK");
                return;
            }

            var novaEspecie = new { espid = _especies.Count + 1, nomeespecie = NomeEspecieEntry.Text };
            _especies.Add(novaEspecie);

            NomeEspecieEntry.Text = string.Empty;

            await DisplayAlert("Sucesso", "Esp�cie adicionada com sucesso!", "OK");
        }

        private async void OnEditarEspecieClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var especie = button.BindingContext;

            string nomeEspecie = string.Empty;
            try
            {
                var property = especie.GetType().GetProperty("nomeespecie");
                if (property != null)
                {
                    nomeEspecie = (string)property.GetValue(especie);
                }
            }
            catch { }

            string novoNome = await DisplayPromptAsync("Editar Esp�cie", "Digite o novo nome da esp�cie:", initialValue: nomeEspecie);

            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                int index = _especies.IndexOf(especie);
                if (index >= 0)
                {
                    _especies.RemoveAt(index);

                    int espid = 0;
                    try
                    {
                        var property = especie.GetType().GetProperty("espid");
                        if (property != null)
                        {
                            espid = (int)property.GetValue(especie);
                        }
                    }
                    catch { }

                    var especieAtualizada = new { espid, nomeespecie = novoNome };
                    _especies.Insert(index, especieAtualizada);

                    await DisplayAlert("Sucesso", "Esp�cie atualizada com sucesso!", "OK");
                }
            }
        }

        private async void OnExcluirEspecieClicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var especie = button.BindingContext;

            bool resposta = await DisplayAlert("Confirma��o", "Deseja realmente excluir esta esp�cie?", "Sim", "N�o");
            if (resposta)
            {
                _especies.Remove(especie);
                await DisplayAlert("Sucesso", "Esp�cie exclu�da com sucesso!", "OK");
            }
        }
    }
}
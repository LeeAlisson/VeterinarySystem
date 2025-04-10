using Microsoft.Maui.Controls;

namespace VeterinarySystem.Pages
{
    public partial class SobreAlunoPage : ContentPage
    {
        public SobreAlunoPage()
        {
            InitializeComponent();
        }

        private async void OnSelecionarFotoClicked(object sender, EventArgs e)
        {
            try
            {
                var result = await FilePicker.PickAsync(new PickOptions
                {
                    FileTypes = FilePickerFileType.Images,
                    PickerTitle = "Selecione uma foto"
                });

                if (result != null)
                {
                    if (result.FileName.EndsWith("jpg", StringComparison.OrdinalIgnoreCase) ||
                        result.FileName.EndsWith("png", StringComparison.OrdinalIgnoreCase))
                    {
                        var stream = await result.OpenReadAsync();
                        FotoAluno.Source = ImageSource.FromStream(() => stream);
                    }
                }
            }
            catch (Exception ex)
            {
                await DisplayAlert("Erro", $"Não foi possível selecionar a foto: {ex.Message}", "OK");
            }
        }
    }
}
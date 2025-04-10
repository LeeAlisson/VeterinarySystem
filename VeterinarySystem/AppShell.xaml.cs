namespace VeterinarySystem
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            // Registro de rotas para navegação
            Routing.RegisterRoute("NovoClientePage", typeof(Pages.NovoClientePage));
            Routing.RegisterRoute("EditarClientePage", typeof(Pages.EditarClientePage));
            Routing.RegisterRoute("NovoAnimalPage", typeof(Pages.NovoAnimalPage));
            Routing.RegisterRoute("EditarAnimalPage", typeof(Pages.EditarAnimalPage));
        }

        private async void OnSairClicked(object sender, EventArgs e)
        {
            bool resposta = await DisplayAlert("Confirmação", "Deseja realmente sair do aplicativo?", "Sim", "Não");
            if (resposta)
            {
                // Tente usar Application.Current?.Quit() para evitar erros de nulo
                Application.Current?.Quit();
            }
        }
    }
}
using System;
using Xamarin.Forms;

namespace CurriculumAppD
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnEditCVClicked(object sender, EventArgs e)
        {
            // Navega a la página del formulario para editar el CV
            await Navigation.PushAsync(new EditCVPage(this));
        }

        // Método para actualizar el CV con los datos editados
        public void UpdateCV(string perfil, string trabajoActual, string trabajoActualDesc, string trabajoAnterior, string trabajoAnteriorDesc,
                             string telefono, string correo, string ubicacion, string linkedin, string espanol, string ingles, string frances)
        {
            PerfilLabel.Text = perfil;
            TrabajoActualLabel.Text = trabajoActual;
            TrabajoActualDescLabel.Text = trabajoActualDesc;
            TrabajoAnteriorLabel.Text = trabajoAnterior;
            TrabajoAnteriorDescLabel.Text = trabajoAnteriorDesc;
            TelefonoLabel.Text = $"Teléfono: {telefono}";
            CorreoLabel.Text = $"Correo: {correo}";
            UbicacionLabel.Text = $"Ubicación: {ubicacion}";
            LinkedInLabel.Text = $"LinkedIn: {linkedin}";
            EspanolLabel.Text = espanol;
            InglesLabel.Text = ingles;
            FrancesLabel.Text = frances;
        }
    }
}

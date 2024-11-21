using CurriculumAppD;
using System;
using Xamarin.Forms;

namespace CurriculumAppD
{
    public partial class EditCVPage : ContentPage
    {
        private MainPage _mainPage;

        public EditCVPage(MainPage mainPage)
        {
            InitializeComponent();
            _mainPage = mainPage;
        }

        private async void OnSaveClicked(object sender, EventArgs e)
        {
            // Envía los datos modificados a la página principal
            _mainPage.UpdateCV(PerfilEditor.Text, TrabajoActualTitulo.Text, TrabajoActualDescripcion.Text,
                               TrabajoAnteriorTitulo.Text, TrabajoAnteriorDescripcion.Text,
                               TelefonoEntry.Text, CorreoEntry.Text, UbicacionEntry.Text, LinkedInEntry.Text,
                               EspanolEntry.Text, InglesEntry.Text, FrancesEntry.Text);

            // Regresa automáticamente al CV estático
            await Navigation.PopAsync();
        }
    }
}

using System.ComponentModel;
using TabelaFipe.ServicoFipe;
using TabelaFipe.ServicoFipe.Model;
using Xamarin.Forms;

namespace TabelaFipe
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            buscarMarcas();
        }

        private void buscarMarcas()
        {
            lstMarcas.ItemsSource = FipeAPI.buscarMarcas();
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null)
            {
                return;
            }
            FipeModel fm = e.SelectedItem as FipeModel;
            var lista = FipeAPI.buscarModelos(fm.id);
            var modelos = new Modelos();
            modelos.BindingContext = lista;
            Navigation.PushModalAsync(modelos);
        }

    }
}

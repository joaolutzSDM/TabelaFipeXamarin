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
        public static FipeModel selecao = new FipeModel();

        public MainPage()
        {
            InitializeComponent();
            buscarMarcas();
        }

        private void buscarMarcas()
        {
            var lista = FipeAPI.buscarMarcas();
            if (lista != null)
                lstMarcas.ItemsSource = lista;
            else            
                lblMsg.Text = @"Serviço indisponível";
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null || e.SelectedItem == null)
            {
                return;
            }
            var modelos = new Modelos(e.SelectedItem as FipeModel);
            lstMarcas.SelectedItem = null;
            Navigation.PushModalAsync(modelos);
        }

    }
}

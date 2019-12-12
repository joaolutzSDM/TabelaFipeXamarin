using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabelaFipe.ServicoFipe;
using TabelaFipe.ServicoFipe.Model;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TabelaFipe
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AnosModelo : ContentPage
    {
        public AnosModelo(FipeModel fipeModel)
        {
            InitializeComponent();
            buscarAnosModelo(fipeModel);
        }

        private void buscarAnosModelo(FipeModel fipeModel)
        {
            MainPage.selecao.modeloSelec = fipeModel.id;
            var lista = FipeAPI.buscarAnoModelo(MainPage.selecao.marcaSelec, fipeModel.id);
            if (lista != null)
                lstAnosModelo.ItemsSource = lista;
            else
                lblMsg.Text = @"Serviço indisponível";
        }

        private void OnSelection(object sender, SelectedItemChangedEventArgs e)
        {
            if (e == null || e.SelectedItem == null)
            {
                return;
            }
            var veiculo = new Veiculo(e.SelectedItem as FipeModel);
            lstAnosModelo.SelectedItem = null;
            Navigation.PushModalAsync(veiculo);
        }
    }
}
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
            
            FipeModel fm = FipeAPI.buscarVeiculo(MainPage.selecao.marcaSelec, MainPage.selecao.modeloSelec, (e.SelectedItem as FipeModel).id);
            if(fm == null)
            {
                lblMsg.Text = @"Serviço indisponível";
                lstAnosModelo.ItemsSource = null;
                return;
            }
            var veiculo = new Veiculo();
            veiculo.BindingContext = fm;
            lstAnosModelo.SelectedItem = null;
            Navigation.PushModalAsync(veiculo);
        }
    }
}
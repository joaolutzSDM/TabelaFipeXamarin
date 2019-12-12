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
    public partial class Veiculo : ContentPage
    {
        public Veiculo(FipeModel fipeModel)
        {
            InitializeComponent();
            buscarVeiculo(fipeModel);
        }

        private void buscarVeiculo(FipeModel fipeModel)
        {
            MainPage.selecao.anoModeloSelec = fipeModel.id;
            var veiculo = FipeAPI.buscarVeiculo(MainPage.selecao.marcaSelec, MainPage.selecao.modeloSelec, fipeModel.id);
            if (veiculo != null)
                BindingContext = veiculo;
            else
                lblMsg.Text = @"Serviço indisponível";
        }
    }
}
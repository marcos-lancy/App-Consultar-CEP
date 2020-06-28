using ConsultarCEP.Servico;
using ConsultarCEP.Servico.Modelo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            Botao.Clicked += BuscarCEP;
        }

        private void BuscarCEP(object sender, EventArgs args)
        {
            string cep = Cep.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCepServico.BuscarEnderecoViaCep(cep);
                    if (end != null)
                    {
                        Resultado.Text = string.Format(@"Endereço: {0}, {3} {1}-{2}",
                        end.Logradouro, end.Localidade, end.Uf, end.Bairro);
                    }
                    else
                    {
                        DisplayAlert("Alerta!","cep não encontrado", "OK");
                    }
                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO crítipo - Verifique sua rede", e.Message, "OK");
                }

            }
        }

        private bool isValidCEP(string cep)
        {
            bool _valido = true;
            int _novoCep = 0;


            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP inválido! O CEP deve conter 8 caracteres.", "OK");
                _valido = false;
            }

            if (!int.TryParse(cep, out _novoCep))
            {
                DisplayAlert("ERRO", "CEP inválido!", "OK");
                Cep.Text = "";
                return _valido = false;
            }

            return _valido;
        }
    }
}

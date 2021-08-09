using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Cotador.Core.Constants;
namespace Cotador.Inicio
{
    /// <summary>
    /// Interaction logic for Tela_Inicial.xaml
    /// </summary>
    public partial class Tela_Inicial : Window
    {
        public Tela_Inicial()
        {
            //Core.NetworkTest.test();
            InitializeComponent();
            this.Transportador.IsEnabled = Core.Constants.Transportador();
            this.Nacional.IsEnabled = Core.Constants.Nacional();
            this.Internacional.IsEnabled = Core.Constants.Internacional();
            this.Avulsas.IsEnabled = Core.Constants.Avulsas();
                
        }
        protected override void OnClosed(EventArgs e)
        {
            base.OnClosed(e);

            Application.Current.Shutdown();
            
        }
        private void Nacional_Click(object sender, RoutedEventArgs e)
        {
            if (Core.Constants.Nacional()){
                Nacional.Nacional nacional = new Nacional.Nacional(ConfigNacional);
                nacional.Show();
			}
			else
			{
                Caixa_de_Mensagem.mensagem men = new Caixa_de_Mensagem.mensagem("Erro", "Nacional não permitido");
                men.Show();
            }
            
        }

		private void Trasporte_Click(object sender, RoutedEventArgs e)
		{
            if (Core.Constants.Nacional())
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
            }
            else
            {
                Caixa_de_Mensagem.mensagem men = new Caixa_de_Mensagem.mensagem("Erro", "Transportador não permitido");
                men.Show();
            }
            
		}

		private void Internacional_Click(object sender, RoutedEventArgs e)
		{
            Caixa_de_Mensagem.mensagem men = new Caixa_de_Mensagem.mensagem("Erro","Intenacional ainda não implementado");
            men.Show();
		}

		private void Avulsas_Click(object sender, RoutedEventArgs e)
		{
            Caixa_de_Mensagem.mensagem men = new Caixa_de_Mensagem.mensagem("Erro", "Avulsas ainda não implementado");
            men.Show();
        }

	}
}

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
	/// Interaction logic for Nome.xaml
	/// </summary>
	public partial class Nome : Window
	{
		public Nome()
		{
			InitializeComponent();
			if (Properties.Settings.Default.Nome != "")
			{
				Cotador.Core.Constants.NomeSubscritor = Properties.Settings.Default.Nome;
				Tela_Inicial tela = new Tela_Inicial();
				tela.Show();
				this.Close();
			}
		}

		private void AplicarNome(object sender, RoutedEventArgs e)
		{
			Cotador.Core.Constants.NomeSubscritor = nome.Text;
			Properties.Settings.Default.Nome = nome.Text;
			Properties.Settings.Default.Save();
			Tela_Inicial tela = new Tela_Inicial();
			tela.Show();
			this.Close();
		}
	}
}

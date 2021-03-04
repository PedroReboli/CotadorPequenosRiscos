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

namespace Cotador.Tela_Senha
{
	/// <summary>
	/// Interaction logic for Senha.xaml
	/// </summary>
	public partial class Senha : Window
	{
		public Senha()
		{
			string senha = Properties.Settings.Default.Senha;
			if ( senha != "")
			{
				if (conectar(senha))
				{
					MainWindow w = new MainWindow();
					w.Show();
					this.Close();
				}
			}

			InitializeComponent();
			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			if (conectar(TXT_Senha.Text))
			{
				Properties.Settings.Default.Senha = TXT_Senha.Text;
				Properties.Settings.Default.Save();
				MainWindow w = new MainWindow();
				w.Show();
				this.Close();
			}

		}
		private bool conectar(string senha)
		{
			Core.Net Socket = new Core.Net();
			if (!Socket.Connect("servidordetestes.bounceme.net", 9090))
			{
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro", "Erro ao se conectar ao servidor");
				messa.Show();
				return false;
			}
			Socket.Send("ff3f8941ebc34d9b01dfd24ea10efcde99fa151a397216a40b335f11f59e47627f1dc5bb45e0ecccf3c64d2f7957a11042b82b57f447c2bdbd155eebd59b65a2");
			string resultado = Socket.Recv().ToString();
			if (resultado == "OK")
			{
				Socket.Send(senha);
				resultado = Socket.Recv().ToString();
				if (resultado == "OK")
				{
					//Criar outra janela e fechar a atual
					return true;
				}
				else
				{
					//Erro.Visibility = Visibility.Visible;
					Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro", "A senha é invalida");
					messa.Show();
					return false;
				}

			}
			else
			{
				//Erro.Visibility = Visibility.Visible;
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro", "Houve um erro no servidor");
				messa.Show();
				return false;
			}
			
		}

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{
			DragMove();
		}
	}
}

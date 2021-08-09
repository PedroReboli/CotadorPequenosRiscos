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
					Inicio.Tela_Inicial w = new Inicio.Tela_Inicial();
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
				Inicio.Tela_Inicial w = new Inicio.Tela_Inicial();
				w.Show();
				this.Close();
			}

		}
		private bool conectar(string senha)
		{
			Core.Net Socket = new Core.Net();
			if (!Socket.Connect(ServerIP, ServerPort))
			{
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro", "Erro ao se conectar ao servidor");
				messa.Show();
				return false;
			}
			Socket.Send("28cf0c53674223efb014fa74952e66827fe00f931da1aa03bcc46f6593241c98db95fec94bd656f4398638f057dc3852f2af49a999051798a40173ed3e8e8000");
			string resultado = Socket.Recv().ToString();
			if (resultado == "OK")
			{
				Socket.Send(senha);
				resultado = Socket.Recv().ToString();
				if (resultado == "OK")
				{
					//Recebe Configuraçoes
					Configuracoes = BitConverter.ToUInt64((byte[])(Socket.Recv()), 0);
					ConfigNacional = BitConverter.ToUInt64((byte[])(Socket.Recv()), 0);
					ConfigInternacional = BitConverter.ToUInt64((byte[])(Socket.Recv()), 0);
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

		private void PackIcon_MouseDown(object sender, MouseButtonEventArgs e)
		{
			Application.Current.Shutdown();
		}
	}
}

using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
using System.Diagnostics;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using Application = System.Windows.Application;
namespace Cotador.Trasnportador.Servidor
{
	/// <summary>
	/// Interaction logic for Procurar.xaml
	/// </summary>
	public partial class Procurar : Window
	{
		private Core.Net Socket = new Core.Net();
		public Procurar()
		{
			InitializeComponent();
			if (!Socket.Connect("192.168.0.88", 9090))
			{
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro", "Erro ao se conectar no servidor");
				//Servidor.Foreground = new SolidColorBrush(Color.FromRgb(255, 43, 43));
				return;
			}
			Socket.Send("!Modo Subscritor!");
			if (((string)Socket.Recv()).Contains("OK"))
			{
				Servidor.Foreground = new SolidColorBrush(Color.FromRgb(80, 170, 28));
			}
		}

		private void Procurar_Server(object sender, MouseButtonEventArgs e)
		{
			int bits = 0;
			if (Segurado.Text.Replace(" ","") != "")
			{
				bits += 1;
			}
			if (CNPJ.Text.Replace(" ","") != "")
			{
				bits += 2;
			}
			if (Corretora.Text.Replace(" ","") != "")
			{
				bits += 4;
			}
			if (N_Cotacao.Text.Replace(" ", "") != "")
			{
				bits += 8;
			}
			if (bits == 0)
			{
				Cotacoes.Items.Clear();
				return;
			}
			Socket.Send((byte)1);
			Socket.Send((byte)bits);
			Socket.Send(Segurado.Text);
			Socket.Send(CNPJ.Text);
			Socket.Send(Corretora.Text);
			Socket.Send(N_Cotacao.Text);
			List<Cotacao> items = new List<Cotacao>();
			byte cot = (byte)Socket.Recv();
			if (cot == 0)
			{
				Cotacoes.Items.Clear();
				Caixa_de_Mensagem.mensagem mess = new Caixa_de_Mensagem.mensagem("Erro", "Não foram encontrada nenhuma cotaçao com os dados informados");
				mess.Show();
				return;
			}
			for (byte x = 1;x < cot; x++)
			{
				string Cota = (string)Socket.Recv();
				string Segurado = (string)Socket.Recv();
				string CNPJ = (string)Socket.Recv();
				string Corretora = (string)Socket.Recv();
				items.Add(new Cotacao { Cota = Cota, Segurado = Segurado, CNPJ = CNPJ, Corretora = Corretora });
			}
			Cotacoes.ItemsSource = items;
		}
		public class Cotacao
		{
			public string Cota { get; set; }
			public string Segurado { get; set; }
			public string CNPJ { get; set; }
			public string Corretora { get; set; }
		}


		private void Baixar(object sender, MouseButtonEventArgs e)
		{
			string N = ((Cotacao)Cotacoes.SelectedItem).Cota;

			Socket.Send((byte)2);
			Socket.Send(N);
			byte[] modo = (byte[])Socket.Recv();
			string Corretor = (string)Socket.Recv();
			if ( modo[0] == (byte)01) //RCTR-C
			{
				
				byte[] RCTR_C = (byte[])Socket.Recv();
				Salvar("Salvar RCTR-C", RCTR_C, Corretor, "RCTR-C");
				
			}
			if (modo[0] == (byte)02) //RCTR-C + RCTF-DC
			{
				byte[] RCTR_C = (byte[])Socket.Recv();
				byte[] RCF_DC = (byte[])Socket.Recv();
				Salvar("Salvar RCTR-C", RCTR_C, Corretor, "RCTR-C");
				Salvar("Salvar RCF-DC", RCF_DC, Corretor, "RCF-DC");
			}


		}
		private static void Salvar(string Titulo, byte[] Arquivo, string Corretor, string modo)
		{
			Microsoft.Win32.SaveFileDialog Salvar_Dialogo = new Microsoft.Win32.SaveFileDialog();

			Salvar_Dialogo.Filter = "Arquivo Word (*.docx)|*.docx|All files (*.*)|*.*";
			Salvar_Dialogo.RestoreDirectory = true;
			Salvar_Dialogo.FileName = Corretor + "_" + modo;
			Salvar_Dialogo.Title = Titulo;
			Stream myStream;
			if (Salvar_Dialogo.ShowDialog() == true)
			{
				if ((myStream = Salvar_Dialogo.OpenFile()) != null)
				{
					myStream.Write(Arquivo, 0, Arquivo.Length);
					myStream.Close();
				}
			}

		}
	}
}

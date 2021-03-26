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
using static Cotador.Core.Constants;
using MessageBox = System.Windows.MessageBox;
using Application = System.Windows.Application;
namespace Cotador.Transportador.Servidor
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
			if (!Socket.Connect(ServerIP, ServerPort))//servidordetestes.bounceme.net
			{
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro", "Erro ao se conectar no servidor");
				messa.Show();
				//Servidor.Foreground = new SolidColorBrush(Color.FromRgb(255, 43, 43));
				return;
			}
			//MessageBox.Show("Connectado");
			Socket.Send("210be131038c715e5712717621a3d8e9a9ff5ca4858a386c469975fe8da89fecb38b46e9dbe8f433d5d67be89807df952dc964ece5b70805f7e437411910d40d");
			//MessageBox.Show("Esperando OK");
			if (((string)Socket.Recv()).Contains("OK"))
			{
				Servidor.Foreground = new SolidColorBrush(Color.FromRgb(80, 170, 28));
			}
			else
			{
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro", "Erro do comando para servidor");
				messa.Show();
			}
			
		}
		public static void UpdateColumnWidths(GridView gridView)
		{
			// For each column...
			foreach (var column in gridView.Columns)
			{
				// If this is an "auto width" column...
				if (double.IsNaN(column.Width))
				{
					// Set its Width back to NaN to auto-size again
					column.Width = 0;
					column.Width = double.NaN;
				}
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
			List<Cotacao> items = new List<Cotacao>();
			
			if (bits == 0)
			{
				Cotacoes.ItemsSource = items;
				Caixa_de_Mensagem.mensagem mess = new Caixa_de_Mensagem.mensagem("Erro", "Nenhum filtro foi preenchido");
				mess.Show();
				return;
			}
			
			Socket.Send((byte)1);
			Socket.Send((byte)bits);
			Socket.Send(Segurado.Text);
			Socket.Send(CNPJ.Text);
			Socket.Send(Corretora.Text);
			Socket.Send(N_Cotacao.Text);
			
			byte[] cot = (byte[])Socket.Recv();
			if (cot[0] == 0)
			{
				Cotacoes.ItemsSource = items;
				Caixa_de_Mensagem.mensagem mess = new Caixa_de_Mensagem.mensagem("Erro", "Não foram encontrada nenhuma cotaçao com os dados informados");
				mess.Show();
				return;
			}
			for (byte x = 0;x < cot[0]; x++)
			{
				string Cota = (string)Socket.Recv();
				string Segurado = (string)Socket.Recv();
				string CNPJ = (string)Socket.Recv();
				string Corretora = (string)Socket.Recv();
				items.Add(new Cotacao { Cota = Cota, Segurado = Segurado, CNPJ = CNPJ, Corretora = Corretora });
			}
			Cotacoes.ItemsSource = items;
			var cota = Cotacoes.View as GridView;
			UpdateColumnWidths(cota);
			Cotacoes.SelectedIndex = -1;
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
			if(Cotacoes.SelectedIndex == -1)
			{
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro","Nenhum item foi selecionado");
				messa.Show();
				return;
			}
				

			string N = ((Cotacao)Cotacoes.SelectedItem).Cota;
			if (N == "")
			{
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Erro", "Nenhum item foi selecionado");
				messa.Show();
				return;
			}
			Socket.Send((byte)2);
			Socket.Send(N);
			byte[] modo = (byte[])Socket.Recv();
			string Segurado = (string)Socket.Recv();
			if ( modo[0] == (byte)01) //RCTR-C
			{
				
				byte[] RCTR_C = (byte[])Socket.Recv();
				Salvar("Salvar RCTR-C", RCTR_C, Segurado, "RCTR-C");
				
			}
			if (modo[0] == (byte)02) //RCTR-C + RCTF-DC
			{
				byte[] RCTR_C = (byte[])Socket.Recv();
				byte[] RCF_DC = (byte[])Socket.Recv();
				Salvar("Salvar RCTR-C", RCTR_C, Segurado, "RCTR-C");
				Salvar("Salvar RCF-DC", RCF_DC, Segurado, "RCF-DC");
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

		private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			try
			{
				Socket.Send((byte)00);
			}
			catch
			{

			}
				
			
			
		}
	}
}

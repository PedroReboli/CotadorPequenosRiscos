using System;
using System.IO;
using System.Windows;
using System.Windows.Forms;
using static Cotador.Core.Constants;
using Clipboard = System.Windows.Forms.Clipboard;
using TextDataFormat = System.Windows.Forms.TextDataFormat;

namespace Cotador.Relatorio
{
	/// <summary>
	/// Interaction logic for Relatorio_Janela.xaml
	/// </summary>
	public partial class Relatorio_Janela : Window
	{
		public Relatorio_Janela()
		{
			InitializeComponent();
			
		}
		private void GerarExcel(object sender, RoutedEventArgs e)
		{
			Core.Net Socket = Setup();
			Socket.Send((byte)0);
			Salvar("Salvar Relatorio", (Byte[])Socket.Recv());
		}
		private void Copiar(object sender, RoutedEventArgs e)
		{
			Core.Net Socket = Setup();
			Socket.Send((byte)1);
			string Data = (string)Socket.Recv();
			Clipboard.SetText(Data, TextDataFormat.UnicodeText);
		}
		private Core.Net Setup()
		{
			Core.Net Socket = new Core.Net();
			if (!Socket.Connect(ServerIP, ServerPort))
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Não foi possivel se conectar ao servidor");
			}
			Socket.Send("2ddb03e4e01ea00e3f0c49a5a880985d314c631acba420db3bea8cc91a27083ffd6e2b9e289bb3e862b29a6953ca60febffef816cbc1b8f5cbe7141041c53284");
			if (Socket.Recv() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao se comunicar com o servidor [3824]");
			}
			Socket.Send((byte)1); // Vai para o modo de relatorio
			if (Socket.Recv() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao se conversar com o servidor [3835]");
			}
			Socket.Send((byte)0); // Vai para o modo de relatorio de cotacao
			if (Socket.Recv() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao se conversar com o servidor [3835]");
			}
			byte Bits = 0;
			if (Cancelada.IsChecked == true)
				Bits += 1;
			if (Emitida.IsChecked == true)
				Bits += 1 << 1;
			if (Corretor.IsChecked == true)
				Bits += 1 << 2;
			Socket.Send(Inicio.SelectedDate.Value.Day.ToString());
			Socket.Send(Inicio.SelectedDate.Value.Month.ToString());
			Socket.Send(Inicio.SelectedDate.Value.Year.ToString());
			Socket.Send(Fim.SelectedDate.Value.Day.ToString());
			Socket.Send(Fim.SelectedDate.Value.Month.ToString());
			Socket.Send(Fim.SelectedDate.Value.Year.ToString());
			Socket.Send(Bits);
			return Socket;
		}

		private void Salvar(string Titulo, byte[] Arquivo)
		{
			SaveFileDialog Salvar_Dialogo = new SaveFileDialog();

			//Salvar_Dialogo.Filter = "Arquivo PDF (*.pdf)|*.pdf|All files (*.*)|*.*";
			Salvar_Dialogo.Filter = "Arquivo Excel (*.xlsx)|*.xlsx|All files (*.*)|*.*";
			Salvar_Dialogo.RestoreDirectory = true;
			DateTime data = DateTime.Now;
			Salvar_Dialogo.FileName = "Relatorio_"+data.Day+"_"+data.Month+"_"+data.Year;
			Salvar_Dialogo.Title = Titulo;
			Stream myStream;
			if (Salvar_Dialogo.ShowDialog() == System.Windows.Forms.DialogResult.OK)
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

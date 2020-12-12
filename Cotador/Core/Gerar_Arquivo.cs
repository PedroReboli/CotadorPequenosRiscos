using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;
using Application = System.Windows.Application;

namespace Cotador
{
	class Gerar_Arquivo
	{
		static public bool visivel = true;
		static public Word.Application oWord;
		static public Word.Document oDoc;
		static public Word.Document objdoc;
		//static MainWindow Main = new MainWindow();
		//static Avaria avaria = new Avaria();
		//static roubo roubo = new roubo();
		//static padrao padrao = new padrao();

		static public void gerar(object isso)
		{


			/*MainWindow Main = new MainWindow();
			Nacional.Nacional nacional = new Nacional.Nacional();
			*/

			StackTrace trace = new StackTrace();
			int caller = 1;
			StackFrame frame = trace.GetFrame(caller);
			string NomeFuncao = frame.GetMethod().DeclaringType.ToString();

			switch (NomeFuncao)
			{
				case "Cotador.Nacional.Nacional":
					Gerar_Nacional();
					break;
				case "Cotador.MainWindow":
					Gerar_Transporte((MainWindow)isso);
					break;

			}


		}
		static void Gerar_Nacional()
		{
			
			oWord = new Word.Application();
			oWord.Visible = true;
			Word.Document nacional;
			Nacional.Nacional Main = new Nacional.Nacional();
			foreach (var janela in Application.Current.Windows)
			{
				if (janela.GetType() == Main.GetType())
				{
					Main = (Nacional.Nacional)janela;
					break;
				}
			}
			//objdoc = oWord.Documents.Open(Main.path + "Modelos\\Nacional\\" + "Nacional.doc");
			//Nacional.Gerar_Nacional.Gerar();

		}
		static void Gerar_Transporte(MainWindow isso)
		{
			//oWord = new Word.Application();
			//oWord.Visible = true;
			//Word.Document Acidente;
			/*MainWindow Main = new MainWindow();
			foreach (var janela in Application.Current.Windows)
			{
				if (janela.GetType() == Main.GetType())
				{
					Main.Close();
					Main = (MainWindow)janela;
					break;
				}
			}*/
			string senha = Properties.Settings.Default.Senha; 
			MainWindow Main = isso;
			Core.Net Socket = new Core.Net();
			//if (!Socket.Connect("servidordetestes.bounceme.net", 9090))
			if (!Socket.Connect("servidordetestes.bounceme.net", 9090))
			{
				MessageBox.Show("Erro ao se conectar ao servidor");
				
				return;
			}
			Socket.Send("9b0c338545fbfc5f97cb573b13830a90df6eaf63ec50fb144431a3a50d1833df8fc8952d6f19057f1c255491bd73f3ba6a969084174a4e5426679c8a9cbe6403");
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao mandar comando para o servidor");
			}
			Socket.Send(senha);
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao mandar senha para o servidor");
			}
			byte[] Avaria;
			byte[] Roubo;
			int R = 2;
			int A = 1;
			int bits = 0;
			if (Main.Chk_Avaraia.IsChecked.Value == true)
				bits += 1;
			if (Main.Chk_limpeza.IsChecked.Value == true)
				bits += 2;
			if (Main.Main_Taxa.IsChecked == true)
				bits += 4;
			if (Main.Chk_Container.IsChecked.Value == true)
				bits += 8;
			if (Main.Chk_Roubo.IsChecked.Value == true)
			{
				Socket.Send((byte)R);
				Socket.Send(Main.Segurado.Text);
				Socket.Send(Main.CNPJ.Text);
				Socket.Send(Main.Corretor.Text);
				Socket.Send(Main.Sinistros.Text);
				Socket.Send(Main.Desconto.Text);
				Socket.Send(Main.Taxa_Unica.Text);
				Socket.Send(Main.Premio_Minimo.Text);
				Socket.Send(Main.Avaria_LMG.Text);
				Socket.Send(Main.Avaria_Fraquia.Text);
				Socket.Send(Main.Avaria_franquia_RS.Text);
				Socket.Send(Main.Avaria_Taxa.Text);
				Socket.Send(Main.Limpeza_LMG.Text);
				Socket.Send(Main.Limpeza_Franquia.Text);
				Socket.Send(Main.Limpeza_FranquiaRS.Text);
				Socket.Send(Main.Limpeza_Taxa.Text);
				Socket.Send(Main.Taxa_Roubo.Text);
				Socket.Send(Main.POS_1.Text);
				Socket.Send(Main.POS_2.Text);
				Socket.Send(Main.POS_3.Text);
				Socket.Send(Main.Lmg_Container.Text);
				Socket.Send(Main.RCTRC.Text);
				Socket.Send(Main.LMG.Text);
				Socket.Send((byte)bits);

				Socket.Send(Main.RCFDC.Text);
				if (Socket.Recv().ToString() == "Fail")
				{
					Caixa_de_Mensagem.Mensagem.Mostar("Erro", "O numero de cotação esta sendo usado por outro corretor");
					return;
				}
				Avaria = (byte[])Socket.Recv();
				Roubo = (byte[])Socket.Recv();

				Salvar("Salvar RCTR-C", Avaria, Main.Segurado.Text,"RCTR-C");
				Salvar("Salvar RCF-DC", Roubo , Main.Segurado.Text, "RCF-DC");
				Caixa_de_Mensagem.Mensagem.Mostar("Arquivo gerado", "Arquivo foi gerado com sucesso");
			}
			else
			{
				Socket.Send((byte)A);
				Socket.Send(Main.Segurado.Text);
				Socket.Send(Main.CNPJ.Text);
				Socket.Send(Main.Corretor.Text);
				Socket.Send(Main.Sinistros.Text);
				Socket.Send(Main.Desconto.Text);
				Socket.Send(Main.Taxa_Unica.Text);
				Socket.Send(Main.Premio_Minimo.Text);
				Socket.Send(Main.Avaria_LMG.Text);
				Socket.Send(Main.Avaria_Fraquia.Text);
				Socket.Send(Main.Avaria_franquia_RS.Text);
				Socket.Send(Main.Avaria_Taxa.Text);
				Socket.Send(Main.Limpeza_LMG.Text);
				Socket.Send(Main.Limpeza_Franquia.Text);
				Socket.Send(Main.Limpeza_FranquiaRS.Text);
				Socket.Send(Main.Limpeza_Taxa.Text);
				Socket.Send(Main.Taxa_Roubo.Text);
				Socket.Send(Main.POS_1.Text);
				Socket.Send(Main.POS_2.Text);
				Socket.Send(Main.POS_3.Text);
				Socket.Send(Main.Lmg_Container.Text);
				Socket.Send(Main.RCTRC.Text);
				Socket.Send(Main.LMG.Text);
				Socket.Send((byte)bits);
				Socket.Send(Main.RCFDC.Text);
				/*Socket.Send();
				Socket.Send();
				Socket.Send();*/
				if (Socket.Recv().ToString() == "Fail")
				{
					Caixa_de_Mensagem.Mensagem.Mostar("Erro", "O numero de cotação esta sendo usado por outro corretor");
					return;
				}

				Avaria = (byte[])Socket.Recv();
				Salvar("Salvar RCTR-C", Avaria, Main.Segurado.Text, "RCTR-C");
				Caixa_de_Mensagem.Mensagem.Mostar("Arquivo gerado", "Arquivo foi gerado com sucesso");
			}

		}
		private static void Salvar (string Titulo,byte[] Arquivo, string Corretor,string modo)
		{
			SaveFileDialog Salvar_Dialogo = new SaveFileDialog();

			//Salvar_Dialogo.Filter = "Arquivo PDF (*.pdf)|*.pdf|All files (*.*)|*.*";
			Salvar_Dialogo.Filter = "Arquivo Word (*.docx)|*.docx|All files (*.*)|*.*";
			Salvar_Dialogo.RestoreDirectory = true;
			Salvar_Dialogo.FileName = Corretor+"_"+modo ;
			Salvar_Dialogo.Title = Titulo;
			Stream myStream;
			if (Salvar_Dialogo.ShowDialog() == DialogResult.OK)
			{
				if ((myStream = Salvar_Dialogo.OpenFile()) != null)
				{
					myStream.Write(Arquivo,0,Arquivo.Length);
					myStream.Close();
				}
			}
			
		}
		private static bool Verificar(MainWindow Main)
		{
			
			return true;
		}
	}
}

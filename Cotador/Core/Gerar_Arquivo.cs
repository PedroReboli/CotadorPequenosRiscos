using System;
using Word = Microsoft.Office.Interop.Word;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using SaveFileDialog = System.Windows.Forms.SaveFileDialog;
using static Cotador.Core.Constants;

namespace Cotador
{
	class Gerar_Arquivo
	{
		static public bool visivel = true;
		static public Word.Application oWord;
		static public Word.Document oDoc;
		static public Word.Document objdoc;
		//static MainWindow Main = new MainWindow();
		static Avaria avaria = new Avaria();
		//static roubo roubo = new roubo();
		//static padrao padrao = new padrao();

		static public void gerar(object isso)
		{


			//MainWindow Main = new MainWindow();
			//Nacional.Nacional nacional = new Nacional.Nacional();


			StackTrace trace = new StackTrace();
			int caller = 1;
			StackFrame frame = trace.GetFrame(caller);
			string NomeFuncao = frame.GetMethod().DeclaringType.ToString();

			switch (NomeFuncao)
			{
				case "Cotador.Nacional.Nacional":
					Gerar_Nacional(isso);
					break;
				case "Cotador.MainWindow":
					Gerar_Transporte((MainWindow)isso);
					break;
				case "Cotador.Internacional.janela_Internacional":
					Gerar_Internacio((Internacional.janela_Internacional)isso);
					break;
			}


		}
		static void Gerar_Nacional(object isso)
		{
			
			//Word.Document nacional;
			Nacional.Nacional Main = (Nacional.Nacional)isso;

			Core.Net Socket = new Core.Net();
			if (!Socket.Connect(ServerIP, ServerPort))
			{
				System.Windows.MessageBox.Show("Erro ao se conectar ao servidor");

				return;
			}
			Socket.Send("2ddb03e4e01ea00e3f0c49a5a880985d314c631acba420db3bea8cc91a27083ffd6e2b9e289bb3e862b29a6953ca60febffef816cbc1b8f5cbe7141041c53284");
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao mandar comando para o servidor");
			}
			Socket.Send((byte)00); // Diz que o modo é cotaçao
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação nao disponivel");
			}
			Socket.Send((byte)01); // Diz que o tipo da cotaçao é nacional
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação nacional nao disponivel");
			}
			Nacional.Gerar_Nacional.Main = Main;
			string Coberturas = Nacional.Gerar_Nacional.Coberturas();
			UInt16 Bits = 0; // magica usando bits
			if (Main.Averbavel.IsChecked == true)
				Bits += 1 << 0;
			if (Main.Ajustavel.IsChecked == true)
				Bits += 1 << 1;
			if (Main._80.IsChecked == true)
				Bits += 1 << 2;
			if (Main._90.IsChecked == true)
				Bits += 1 << 3;
			if (Main._100.IsChecked == true)
				Bits += 1 << 4;
			if (Main.CHK_Fixa.IsChecked == true)
				Bits += 1 << 5;
			if (Main.Escalonda.IsChecked == true)
				Bits += 1 << 6;
			if (Main.Chk_DDR.IsChecked == true)
				Bits += 1 << 7;
			if (Main.Com_Sublimite.IsChecked == true)
				Bits += 1 << 8;

			Socket.Send(BitConverter.GetBytes(Bits));
			Socket.Send(Main.Segurado.Text);
			Socket.Send(Main.Ncotacao.Text);
			Socket.Send(Main.CNPJ.Text);
			Socket.Send(Main.Corretor.Text);
			Socket.Send(Main.LMG.Text);
			Socket.Send(Main.Taxa.Text);
			Socket.Send(Main.Importancia_Segurada.Text);
			Socket.Send(Main.Sinistros.Text);
			Socket.Send(Main.Premio_Minimo.Text);
			Socket.Send(Main.Ajustavel_Quantidade_Parcela.Text);
			Socket.Send(Main.Fixa_Percentual.Text);
			Socket.Send(Main.Fixa_Valor.Text);
			Socket.Send(Main.POS1.Text);
			Socket.Send(Main.POS2.Text);
			Socket.Send(Main.POS3.Text);
			Socket.Send(Main.Sub_Limite.Text);
			Socket.Send(Coberturas);
			Socket.Send(Main.Mercadoria.Text);
			Socket.Send(Main.Expectativa.Text);
			Socket.Send(Main.Assessoria.Text);
			Socket.Send(Main.Premio_Anual.Text);
			Socket.Send(Core.Constants.NomeSubscritor);
			byte[] Nacio = (byte[])Socket.Recv();
			Salvar("Salvar Nacional", Nacio, Main.Segurado.Text, "Nacional");
		}
		static void Gerar_Transporte(MainWindow isso)
		{
			//oWord = new Word.Application();
			//oWord.Visible = true;
			//Word.Document Acidente;
			MainWindow Main = isso;
			Core.Net Socket = new Core.Net();
			if (!Socket.Connect(ServerIP, ServerPort))
			{
				System.Windows.MessageBox.Show("Erro ao se conectar ao servidor");

				return;
			}
			Socket.Send("2ddb03e4e01ea00e3f0c49a5a880985d314c631acba420db3bea8cc91a27083ffd6e2b9e289bb3e862b29a6953ca60febffef816cbc1b8f5cbe7141041c53284");
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao mandar comando para o servidor");
			}
			Socket.Send((byte)00); // Diz que o modo é cotaçao
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação nao disponivel");
			}
			Socket.Send((byte)00); // Diz que o tipo da cotaçao é transportador
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação trasportador nao disponivel");
			}
			byte[] Avaria;
			byte[] Roubo;
			int R = 2;
			int A = 1;
			int bits = 0; // Fazendo magica com os bits
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
				Socket.Send(Main.Expectativa_Fechamento.Text);
				Socket.Send(Main.Premio_Anual.Text);
				Socket.Send(Main.Assessoria.Text);
				Socket.Send(Core.Constants.NomeSubscritor);

				if (Socket.Recv().ToString() == "Fail")
				{
					Caixa_de_Mensagem.Mensagem.Mostar("Erro", "O numero de cotação esta sendo usado por outro corretor");
					return;
				}
				Avaria = (byte[])Socket.Recv();
				Roubo = (byte[])Socket.Recv();

				Salvar("Salvar RCTR-C", Avaria, Main.Segurado.Text, "RCTR-C");
				Salvar("Salvar RCF-DC", Roubo, Main.Segurado.Text, "RCF-DC");
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
				Socket.Send(Main.Expectativa_Fechamento.Text);
				Socket.Send(Main.Premio_Anual.Text);
				Socket.Send(Main.Assessoria.Text);
				Socket.Send(Core.Constants.NomeSubscritor);
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

		static void Gerar_Internacio(Internacional.janela_Internacional Main)
		{
			Core.Net Socket = new Core.Net();
			if (!Socket.Connect(ServerIP, ServerPort))
			{
				System.Windows.MessageBox.Show("Erro ao se conectar ao servidor");

				return;
			}
			Socket.Send("2ddb03e4e01ea00e3f0c49a5a880985d314c631acba420db3bea8cc91a27083ffd6e2b9e289bb3e862b29a6953ca60febffef816cbc1b8f5cbe7141041c53284");
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao mandar comando para o servidor");
			}
			Socket.Send((byte)00); // Diz que o modo é cotaçao
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação nao disponivel");
			}
			Socket.Send((byte)02); // Diz que o tipo da cotaçao é Internacional
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação internacional nao disponivel");
			}
			UInt16 Bits = 0;
			if (Main.CHK_Assessoria.IsChecked == true)
				Bits += 1 << 0;
			if (Main.Com_Pre.IsChecked == true)
				Bits += 1 << 1;
			if (Main.Averbavel.IsChecked == true)
				Bits += 1 << 2;
			if (Main._80.IsChecked == true)
				Bits += 1 << 3;
			if (Main._90.IsChecked == true)
				Bits += 1 << 4;
			if (Main._100.IsChecked == true)
				Bits += 1 << 5;
			if (Main.Expor.IsChecked == true)
				Bits += 1 << 6;
			if (Main.Impor.IsChecked == true)
				Bits += 1 << 7;
			if (Main.Chk_DDR.IsChecked == true)
				Bits += 1 << 8;
			if (Main.Exclusivamente.IsChecked == true)
				Bits += 1 << 9;
			
			Socket.Send(BitConverter.GetBytes(Bits));
			Socket.Send(Main.Segurado.Text);
			Socket.Send(Main.Ncotacao.Text);
			Socket.Send(Main.CNPJ.Text);
			Socket.Send(Main.Corretor.Text);
			Socket.Send(Main.Assessoria.Text);
			Socket.Send(Main.LMG.Text);
			Socket.Send(Main.complementar_preliminar.Text);
			Socket.Send(Main.Sub_Limite.Text);
			Socket.Send(Main.Taxa.Text);
			Socket.Send(Main.Importancia_Segurada.Text);
			Socket.Send(Main.Sinistros.Text);
			Socket.Send(Main.Mercadoria.Text);
			Socket.Send(Main.Premio_Anual.Text);
			Socket.Send(Main.Expectativa.Text);
			Socket.Send(Main.Premio_Minimo.Text);
			Socket.Send(Main.Ajustavel_Quantidade_Parcela.Text);
			Socket.Send(Main.Franquia.Text);
			Socket.Send(Internacional.Gerar_Tabela.Gerar(Main));
			Socket.Send(Main.Expectativa.Text);
			Socket.Send("");
			Socket.Send(Core.Constants.NomeSubscritor);
			Salvar("Salvar Internacional", (Byte[])Socket.Recv(), Main.Segurado.Text, "Internacional");
		}
		private static void Salvar(string Titulo, byte[] Arquivo, string Corretor, string modo)
		{
			SaveFileDialog Salvar_Dialogo = new SaveFileDialog();

			//Salvar_Dialogo.Filter = "Arquivo PDF (*.pdf)|*.pdf|All files (*.*)|*.*";
			Salvar_Dialogo.Filter = "Arquivo Word (*.docx)|*.docx|All files (*.*)|*.*";
			Salvar_Dialogo.RestoreDirectory = true;
			Salvar_Dialogo.FileName = Corretor + "_" + modo;
			Salvar_Dialogo.Title = Titulo;
			Stream myStream;
			if (Salvar_Dialogo.ShowDialog() == DialogResult.OK)
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

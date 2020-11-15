using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Controls;
using System.Windows;
using System.Diagnostics;

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

		static public void gerar()
		{


			MainWindow Main = new MainWindow();
			Nacional.Nacional nacional = new Nacional.Nacional();


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
					Gerar_Transporte();
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
			objdoc = oWord.Documents.Open(Main.path + "Modelos\\Nacional\\" + "Nacional.doc");
			Nacional.Gerar_Nacional.Gerar();

		}
		static void Gerar_Transporte()
		{
			oWord = new Word.Application();
			oWord.Visible = true;
			Word.Document Acidente;
			MainWindow Main = new MainWindow();
			foreach (var janela in Application.Current.Windows)
			{
				if (janela.GetType() == Main.GetType())
				{
					Main = (MainWindow)janela;
					break;
				}
			}
			if (Main.Web.IsChecked.Value == true)
			{
				objdoc = oWord.Documents.Open(Main.path + "Web\\" + "Acidente.docx");
				avaria.avaria();
				Acidente = objdoc;
				if (Main.Chk_Roubo.IsChecked.Value == true)
				{
					oDoc = oWord.Documents.Open(Main.path + "Web\\" + "Roubo.docx");
					objdoc = oDoc;
					roubo.Roubo();
				}
			}
			else
			{
				objdoc = oWord.Documents.Open(Main.path + "Acidente.docx");
				avaria.avaria();
				if (Main.Chk_Roubo.IsChecked.Value == true)
				{
					oDoc = oWord.Documents.Open(Main.path + "Roubo.docx");
					objdoc = oDoc;
					roubo.Roubo();
				}
			}
		}
	}
}

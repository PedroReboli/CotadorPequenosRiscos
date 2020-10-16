using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;
namespace Cotador.Nacional
{
    class Gerar_Nacional
    {
        static public Word.Application oWord;
        static public Word.Document oDoc;
        static public Word.Document objdoc;
        public static void Gerar()
        {
            oWord = new Word.Application();
            oWord.Visible = true;
            Nacional Main = new Nacional();
            foreach (var janela in Application.Current.Windows)
            {
                if (janela.GetType() == Main.GetType())
                {
                    Main = (Nacional)janela;
                    break;
                }
            }

            //MainWindow Main = Application.Current.Windows[0] as MainWindow;

            Word.Document Nacional;
            objdoc = oWord.Documents.Open(Main.path + @"Modelos\Nacional\Nacional.doc");
            Nacional = objdoc;
            Nacional_gerar.Gerar();
            
        }
    }
}

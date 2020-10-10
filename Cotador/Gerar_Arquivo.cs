using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Word = Microsoft.Office.Interop.Word;
using System.Windows.Controls;
using System.Windows;

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
            oWord = new Word.Application();
            oWord.Visible = visivel;
            MainWindow Main = Application.Current.Windows[0] as MainWindow;

            Word.Document Acidente;

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
            if (Main.Chk_Roubo.IsChecked.Value == true)
            {

            }
        }
    }
}

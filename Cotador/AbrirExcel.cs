using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO.Compression;
using System.IO;
using System.Xml;
using System.Windows;
using System.Xml.Linq;
using System.Windows.Forms;
using OfficeOpenXml;
using System.Windows.Forms;
using System.Globalization;
using MessageBox = System.Windows.Forms.MessageBox;

namespace Cotador
{
    class AbrirExcel
    {
        //static XLWorkbook workbook;
        //static IXLWorksheet worksheet;
        //static ExcelWorksheet worksheet;
        static public void Abrir(string path)
        {
            //path = "C:\\Users\\pedro\\Desktop\\pricing.xlsm";
            //path = "C:\\Users\\pedro\\Desktop\\Trabalho\\Cotador\\hehehe.xlsx";
            //string temp = Path.GetTempPath();
            //ZipFile.ExtractToDirectory(path, temp + "ExcelTemp\\");
            //System.IO.Directory.CreateDirectory(temp + "ExcelTemp\\");
            /*using (ZipArchive archive = ZipFile.OpenRead(path))
            {
                var result = from currEntry in archive.Entries
                             //where Path.GetDirectoryName(currEntry.FullName) == ""
                             where !String.IsNullOrEmpty(currEntry.Name)
                             select currEntry;


                foreach (ZipArchiveEntry entry in result)
                {
                    entry.ExtractToFile(Path.Combine(temp + "ExcelTemp\\", entry.Name));
                }
            }
            XmlDocument Documento = new XmlDocument();
            XmlNode node;
            
            string str = string.Empty;
            //FileStream fs = new FileStream(temp + "ExcelTemp\\"+"sheet1.xml",FileMode.Open,FileAccess.Read);
            //Documento.Load(temp + "ExcelTemp\\" + "sheet1.xml");
            //XmlElement doc = Documento.DocumentElement;

            //node = Documento.ChildNodes;


            XElement xml = XElement.Load(temp + "ExcelTemp\\" + "sheet1.xml");

            var myNodes = xml.Descendants()
                 .Where(x => x.Attribute("r").Value == "L12").Where(x => x.Value == "v");

            var nude = xml.Descendants()
                    .Where(x => (string)x.Attribute("r") == "C12").Descendants().Where(x => x.Name.LocalName == "v").FirstOrDefault();/*.Where(x => x.Name == "v")
              */  
            //var coco = nude.Value;

            

            /*workbook = new XLWorkbook(path);
            worksheet = workbook.Worksheet(1);*/
            MainWindow Main = new MainWindow();
            foreach (var janela in System.Windows.Application.Current.Windows)
            {
                if (janela.GetType() == Main.GetType())
                {
                    Main = (MainWindow)janela;
                    break;
                }
            }
            int i = 0;
            ExcelPackage excel = new ExcelPackage(new FileInfo(path));
            ExcelWorkbook workbook = excel.Workbook;
            ExcelWorksheet worksheet = workbook.Worksheets[1];

            //i++;
            Main.Segurado.Text = look("C2");
            Main.CNPJ.Text = look("C4");
            Main.Corretor.Text = look("C5");
            char[] g = Main.Segurado.Text.ToCharArray();
            Main.LMG.Text = double.Parse(look("C6")).ToString("N", new CultureInfo("pt-br",false));
            Main.Premio_Minimo.Text = double.Parse(look("C7")).ToString("N", new CultureInfo("pt-br", false));
            Main.Taxa_Unica.Text = lookk("F12").ToString();
            //MessageBox.Show("eae Man");
            double Roubo = lookk("G12");
            //MessageBox.Show("Roubo ");
            double Avaria = lookk("F13");
            //MessageBox.Show("Avaria ");
            double Limpeza = lookk("F14");
            //MessageBox.Show("Limpeza ");
            //double Taxa_Unica = lookk("F12");
            //MessageBox.Show("Taxa Unica ");
            //Main.Taxa_Unica.Text = Taxa_Unica.ToString();
            //MessageBox.Show("Roubo " + look("G12"));
            //MessageBox.Show("Avaria "+look("F13"));
            //MessageBox.Show("Limpeza" + look("F15"));
            //MessageBox.Show("Taxa Unica " + look("F12"));
            //i ++;
            //Main.Taxa_Roubo.Text = Roubo.ToString();
            //Main.Avaria_Taxa.Text = Avaria.ToString();
            //Main.Limpeza_Taxa.Text = Limpeza.ToString();
            Main.Avaria_LMG.Text = double.Parse(look("D13")).ToString("N", new CultureInfo("pt-br", false));
            Main.Limpeza_LMG.Text = double.Parse(look("D14")).ToString("N", new CultureInfo("pt-br", false));
            if (Roubo > 0)
            {
                Main.Chk_Roubo.IsChecked = true;
                Main.Taxa_Roubo.Text = Roubo.ToString();
            }
            if (Avaria > 0)
            {
                Main.Chk_Avaraia.IsChecked = true;
                Main.Avaria_Taxa.Text = Avaria.ToString();
            }
            if(Limpeza > 0)
            {
                Main.Chk_limpeza.IsChecked = true;
                Main.Limpeza_Taxa.Text = Limpeza.ToString();
            }
			if (int.TryParse(look("D24"), out int sinistro) == false)
			{
				sinistro = 0;
			}
			if (sinistro > 0)
            {
                Main.Sinistros.Text = look("D24");
            }
            else
            {
                Main.Sinistros.Text = "Nenhum Sinistro";
            }
            Main.Desconto.Text = lookk("N20").ToString();

            string look(string posicao)
            {
                var x = worksheet.Cells[posicao].Value;
                if (x == null)
                {
                    return "";
                }
                return worksheet.Cells[posicao].Value.ToString();
            }
            double lookk(string posicao)
            {
				var x = worksheet.Cells[posicao].Value;
				if (x == null)
                {
                    return 0;
                }
                if(double.TryParse(worksheet.Cells[posicao].Value.ToString(), out double h))
                {
                    return Math.Round( h * 100,4);
                }
                else
                {
                    return 0;
                }
            }

        }
        
        
    }
}

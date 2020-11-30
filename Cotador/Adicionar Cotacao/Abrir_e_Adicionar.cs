using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Windows;
using System.IO;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
namespace Cotador.Adicionar_Cotacao
{
    class Abrir_e_Adicionar
    {
        static ExcelWorkbook workbook;
        static ExcelWorksheet calcworksheet;
        static ExcelWorksheet worksheet;
        static string Proposta;
        static string Envio;
        static string Lider;
        static string Proponente;
        static string inicio_vigencia;
        static string fim_vigencia;
        static string Situacao;
        static string congenere;
        static string Corretor;
        static string Tipo_Apolice;
        static string Expctativa;
        static Controle_de_Cotacao Main = new Controle_de_Cotacao();
        //static string Envio;
        public static void Adicionar (string calculo , string Controle)
        {
            //MessageBox.Show("to aqui");
            ExcelPackage excelcalc = new ExcelPackage(new FileInfo(calculo));
            //MessageBox.Show("Ja passei");
            //excel.Load(File.Open(calculo,FileMode.Open,FileAccess.Read));
            
            foreach ( var lugar in Application.Current.Windows)
            {
                if (lugar.GetType() == Main.GetType())
                {
                    Main.Close();
                    Main = (Controle_de_Cotacao)lugar;
                    break;
                }
            }
            //Controle_de_Cotacao Main = System.Windows.Application.Current.Windows[2] as Controle_de_Cotacao;
            //MessageBox.Show("vish");
            workbook =  excelcalc.Workbook;
            calcworksheet = workbook.Worksheets["Planilha1"];
            //MessageBox.Show("ue");
            int linha = 1;
            /*while (true)
            {
                if (L("F"+linha.ToString()).Length == 0)
                {
                    break;
                }
                else
                {
                    linha++;
                }
            }*/
            Proponente = C("C2");
            Corretor = C("C5");
            Lider = Main.Lider_Coss.Text;
            //MessageBox.Show("to ficando maluco");
            inicio_vigencia = Main.Data_Inicial.Text.ToString();
            fim_vigencia = Main.Data_Final.Text.ToString();
            //MessageBox.Show("eu estou maluco");
            Situacao = Main.Situacao.Text;
            congenere = Main.Congenere.Text;
            Tipo_Apolice = Main.Tipo_Apolice.Text;
            Expctativa = Main.Expctativa.Text;
            //MessageBox.Show("agora babou");
            string saida = "";
            saida = adicionar(false, saida);
            linha++;
            /*if (double.Parse(calcworksheet.Cells["G12"].Value.ToString()) > 0)
            {
                saida += (char)13 + (char)10;
                adicionar(true, saida);
            }*/
            Clipboard.SetData(DataFormats.Text,saida);
            //MessageBox.Show("To salvando");
            linha++;
            Clipboard.SetData(DataFormats.Text, saida);
            /*string temp = Path.GetTempPath();
             * Clipboard.SetData(DataFormats.Text,saida);
            excel.SaveAs(new FileInfo(temp +"temp.xlsx"));
            FileStream filecontrole = new FileStream(Controle, (FileMode)FileAccess.ReadWrite);
            FileStream filenovo = new FileStream(temp + "temp.xlsx", (FileMode)FileAccess.ReadWrite);
            byte[] novo = new byte[filenovo.Length];
            filenovo.Read(novo, 0, novo.Length);
            filecontrole.Write(novo, 0, novo.Length);
            filecontrole.SetLength(novo.Length);
            filecontrole.Close();
            filenovo.Close();*/
            //MessageBox.Show("Savei");
        }
        private static void Add(bool Modo,int l)
        {
            string linha = l.ToString();
            string saida = string.Empty;
            if (Modo == true)
            {
                saida += 
                saida += DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString(); // Envio
                saida += "\t";
                saida += Lider; // Liderenca / Cosseguro
                saida += "\t";
                saida += Proponente; // Proponente
                saida += "\t";
                saida += inicio_vigencia; // inicio vigencia
                saida += "\t";
                saida += fim_vigencia; // fim vigencia
                saida += "\t";
                saida += "RCTR-C"; // Produto
                saida += "\t";
                saida += Situacao; // Situacao
                saida += "\t";
                saida += congenere; // congenere
                saida += "\t";
                saida += Corretor; // Corretor
                saida += "\t";
                saida += Tipo_Apolice; // Tipo de Apolice Transporte
                saida += "\t";
                saida += Expctativa;
                saida += "\t";
                saida += Math.Round(double.Parse(C("I12"))).ToString(); ; // Estimativa Premio

            }
            else
            {
                worksheet.Cells["C" + linha].Value = DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString(); // Envio
                worksheet.Cells["D" + linha].Value = Lider; // Liderenca / Cosseguro
                worksheet.Cells["F" + linha].Value = Proponente; // Proponente
                worksheet.Cells["G" + linha].Value = inicio_vigencia; // inicio vigencia
                worksheet.Cells["H" + linha].Value = fim_vigencia; // fim vigencia
                worksheet.Cells["I" + linha].Value = "RCF-DC"; // Produto
                worksheet.Cells["J" + linha].Value = Situacao; // Situacao
                worksheet.Cells["K" + linha].Value = congenere; // congenere
                worksheet.Cells["L" + linha].Value = Corretor; // Corretor
                worksheet.Cells["M" + linha].Value = Tipo_Apolice; // Tipo de Apolice Transporte
                worksheet.Cells["N" + linha].Value = Expctativa; // Expctativa
                worksheet.Cells["O" + linha].Value = Math.Round(double.Parse(C("J12"))); // Estimativa Premio
            }
        }

        private static string adicionar (bool Modo,string saida)
        {
            if (Modo == true)
            {
                saida += Main.RCTR_numero.Text + (char)09 + (char)09;
                saida += DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + (char)09; // Envio
                saida += Lider + (char)09; // Liderenca / Cosseguro
                saida += Proponente + (char)09; // Proponente
                saida += inicio_vigencia + (char)09; // inicio vigencia
                saida += fim_vigencia + (char)09; // fim vigencia
                saida += "RCTR-C" + (char)09; // Produto
                saida += Situacao + (char)09; // Situacao
                saida += congenere + (char)09; // congenere
                saida += Corretor + (char)09; // Corretor
                saida += Tipo_Apolice + (char)09; // Tipo de Apolice Transporte
                saida += Expctativa + "%" + (char)09;
                saida += C("I12") +(char)09; // Estimativa Premio
                //var h; // Estimativa Premio
                var p = C("I12");
                
            }
            else
            {
                saida += Main.RCF_DC.Text+(char)09;
                saida += DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() + (char)09; // Envio
                saida += Lider + (char)09; // Liderenca / Cosseguro
                saida += Proponente + (char)09; // Proponente
                saida += inicio_vigencia + (char)09; // inicio vigencia
                saida += fim_vigencia + (char)09; // fim vigencia
                saida += "RCF-DC" + (char)09; // Produto
                saida += Situacao + (char)09; // Situacao
                saida += congenere + (char)09; // congenere
                saida += Corretor + (char)09; // Corretor
                saida += Tipo_Apolice + (char)09; // Tipo de Apolice Transporte
                saida += Expctativa+"%" + (char)09;
                //var p = Math.Round(double.Parse(C("J12")));
                //saida += p.ToString() + (char)09; // Estimativa Premio
            }
            return saida;
        }
        static string L(string posicao)
        {
            try
            {
                var F = worksheet.Cells[posicao].Value;
                if (F == null)
                {
                    return "";
                }
                return worksheet.Cells[posicao].Value.ToString();
            }
            catch
            {
                return "";
            }
        }
        static string C(string posicao)
        {
            /*char[] az = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();

            var row = worksheet.Column(Array.IndexOf(az, letra.ToLower().ToCharArray()[0]) + 1);
            double h = (double)row.Cell(int.Parse(valor)).Value;*/
            return posicao;
            try
            {
                var F = calcworksheet.Cells[posicao].Value;
                if (F == null)
                {
                    return "";
                }
                return calcworksheet.Cells[posicao].Value.ToString();
            }
            catch
            {
                return "";
            }
            
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using System.Windows;
using System.IO;
namespace Cotador
{
    class padrao
    {
        static ExcelWorkbook workbook;
        static ExcelWorksheet calcworksheet;
        static ExcelWorksheet worksheet;
        static public void Padrao()
        {
            /*ExcelPackage excel = new ExcelPackage(new FileInfo(@"C:\Users\pedro\Desktop\Trabalho\Cotador\hehehe.xlsx"));
            Dictionary<string,int> coluna = new Dictionary<string, int>(); 
            Dictionary<string, int> linha = new Dictionary<string, int>();
            string[,] array = new string[27, 27];
            worksheet = excel.Workbook.Worksheets["Tabela RCTR-C"];
            for (int x = 3;x != 30;x++) {
                var valor = worksheet.Cells[3, x].Value;
                if (valor == null)
                {
                    break;
                }
                coluna.Add(worksheet.Cells[2, x].Value.ToString(),x);
                
            }
            for (int x = 4; x != 31; x++)
            {
                var valor = worksheet.Cells[x,2].Value;
                if (valor == null)
                {
                    break;
                }
                linha.Add(worksheet.Cells[x, 2].Value.ToString(), x);

            }
            /*string saida = "{ ";
            for (int x = 4;x != 31; x++)
            {
                saida += "{ ";
                for (int y = 3; y != 31; y++)
                {
                    var valor = worksheet.Cells[x, y].Value;
                    if (valor == null)
                    {
                        break;
                    }
                    
                    array[x - 4, y - 3] = valor.ToString();
                    saida += " , '"+ valor.ToString()+"'";
                }
                saida += " } ,";
            }
            saida += "}";*/
            
            int i = 0;

            i++;

        }
    }
}

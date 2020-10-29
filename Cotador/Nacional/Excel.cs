﻿using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Cotador.Nacional
{
	class Excel
	{
		static ExcelPackage excel ;
		static ExcelWorkbook workbook ;
		static ExcelWorksheet worksheet ;
		static public void Abrir(string path)
		{
			Nacional Main = new Nacional();
			foreach (var janela in Application.Current.Windows)
			{
				if (janela.GetType() == Main.GetType())
				{
					Main = (Nacional)janela;
					break;
				}
			}
			Main.Sinistros.Text = strlook("L19").ToString();
			Main.Ajustavel_Quantidade_Parcela.Text = strlook("E17");
			Main.Taxa.Text = perlook("E10").ToString();
			if (perlook("E10") > 0)
			{
				Main.Ajustavel.IsChecked = true;
			}
			Main.Segurado.Text = strlook("B2");
			Main.CNPJ.Text = strlook("B3");
			Main.Corretor.Text = strlook("B4");
			Main.LMG.Text = strlook("B5");
			Main.Premio_Minimo.Text = strlook("B6");
			Main.Importancia_Segurada.Text = strlook("C12");

		}
		static string strlook(string posicao)
		{
			var x = worksheet.Cells[posicao].Value;
			if (x == null)
			{
				return "";
			}
			return worksheet.Cells[posicao].Value.ToString();
		}
		static double perlook(string posicao)
		{
			var x = worksheet.Cells[posicao].Value;
			if (x == null)
			{
				return 0;
			}
			if (double.TryParse(worksheet.Cells[posicao].Value.ToString(), out double h))
			{
				return h * 100;
			}
			else
			{
				return 0;
			}
		}
	}
}
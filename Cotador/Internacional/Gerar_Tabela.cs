using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Cotador.Internacional
{
	class Gerar_Tabela
	{
		public static string Gerar(janela_Internacional Main)
		{

			CheckBox[] Basica = new CheckBox[] { Main.B1, Main.B2, Main.B3, Main.B4, Main.B5, Main.B6, Main.B7, Main.B8, Main.B9, Main.B10, Main.B11, Main.B12, Main.B13, Main.B14, Main.B15, Main.B16, Main.B17, Main.B18, Main.B19, Main.B20, Main.B21, Main.B22, Main.B23 };
			CheckBox[] Adicionais = new CheckBox[] { Main.A1, Main.A2, Main.A3, Main.A4, Main.A5, Main.A6, Main.A7, Main.A8, Main.A9, Main.A10, Main.A11, Main.A12, Main.A13, Main.A14, Main.A15, Main.A16, Main.A17, Main.A18, Main.A19, Main.A20, Main.A21, Main.A22, Main.A23 };
			CheckBox[] Especificas = new CheckBox[] { Main.E1, Main.E2, Main.E3, Main.E4, Main.E5, Main.E6, Main.E7, Main.E8, Main.E9, Main.E10, Main.E11 };
			bool Adicionado = false; 
			string saida = string.Empty;
			foreach (CheckBox check in Basica)
			{
				if (check.IsChecked == true)
				{
					if (Adicionado == false)
						saida += "\rCoberturas Básica:\r\r";
					Adicionado = true;
					saida += check.Content.ToString().Replace("  ", " ") + "\r";
				}
			}
			Adicionado = false;
			foreach (CheckBox check in Adicionais)
			{
				if (check.IsChecked == true)
				{
					if (Adicionado == false)
						saida += "\rCoberturas Adicionais:\r\r";
					Adicionado = true;
					saida += check.Content.ToString().Replace("  ", " ") + "\r";
				}
			}
			Adicionado = false;
			foreach (CheckBox check in Especificas)
			{
				if (check.IsChecked == true)
				{
					if (Adicionado == false)
						saida += "\rCoberturas Específicas:\r\r";
					Adicionado = true;
					saida += check.Content.ToString().Replace("  ", " ") + "\r";
				}
			}
			return saida;
		}
	}
}

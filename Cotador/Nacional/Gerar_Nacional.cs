using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Word = Microsoft.Office.Interop.Word;
namespace Cotador.Nacional
{
	class Gerar_Nacional
	{
		static Nacional Main = new Nacional();
		public static void Gerar()
		{
			consertar_numeros c = new consertar_numeros();
			foreach (var janela in Application.Current.Windows)
			{
				if (janela.GetType() == Main.GetType())
				{
					Main = (Nacional)janela;
					break;
				}
			}
			if (c.F(Main.Sinistros.Text))
			{
				Acesso.Remover("(<Sinistros Extenso>)");
				Acesso.Modi("R$ <Sinistros>", c.C(Main.Sinistros.Text));
			}
			else
			{
				if (int.Parse(Main.Sinistros.Text.Replace(",","").Replace(".","")) == 0)
				{
					Acesso.Remover("(<Sinistros Extenso>)");
					Acesso.Modi("R$ <Sinistros>", "Sem Sinistro");
				}
				else
				{
					Acesso.Modi("<Sinistros Extenso>", Extenso.EscreverExtenso(c.E(Main.Sinistros.Text)));
					Acesso.Modi("<Sinistros>", c.C(Main.Sinistros.Text));
				}
				
			}
			if (Main.Averbavel.IsChecked == true)
			{
				Acesso.ARemover(Arquivos.Ajustavel);
				Acesso.Modi("<Taxa>", Main.Taxa.Text);
			}
			else
			{
				Acesso.ARemover(Arquivos.Averbavel);
				Acesso.Modi("<Taxa>", Main.Taxa.Text);
				double importancia_segurada = double.Parse(c.E(Main.Importancia_Segurada.Text));
				double taxa = double.Parse(c.P(Main.Taxa.Text));
				double premio_liquido;
				double IOF;
				double premio_total;
				double parcelas = double.Parse(Main.Ajustavel_Quantidade_Parcela.Text);
				premio_liquido = importancia_segurada * (taxa / 100);
				IOF = premio_liquido * (7.38 / 100);
				premio_total = premio_liquido + IOF;
				//.ToString("N", new CultureInfo("pt-br", false)
				Acesso.Modi("<importancia segurada>", importancia_segurada.ToString("N", new CultureInfo("pt-br", false)));
				Acesso.Modi("<Taxa>", taxa.ToString().Replace(".", ","));
				Acesso.Modi("<Premio liquido>", premio_liquido.ToString("N", new CultureInfo("pt-br", false)));
				Acesso.Modi("<Premio Liquido * 7,38%>", IOF.ToString("N", new CultureInfo("pt-br", false)));
				Acesso.Modi("<Premio liquido + IOF>", premio_total.ToString("N", new CultureInfo("pt-br", false)));
				Acesso.Modi("<Premio liquido + IOF Extenso>", Extenso.EscreverExtenso(importancia_segurada.ToString("N", new CultureInfo("en-us", false)).Replace(",",""))); // Provavelment erro
				Acesso.Modi("<Quantidades de parcelas>", Main.Ajustavel_Quantidade_Parcela.Text);
				Acesso.Modi("<Premio liquido Extenso>", Extenso.EscreverExtenso((premio_liquido / parcelas).ToString("N", new CultureInfo("en-us", false)).Replace(",", "")));
				Acesso.Modi("<Premio liquido / quantidades de parcelas>", (premio_liquido / parcelas).ToString("N", new CultureInfo("pt-br", false)));
				if (Main._80.IsChecked == true)
				{
					Acesso.Modi("<PMM Ajustavel>", "80");
				}
				else if (Main._90.IsChecked == true)
				{
					Acesso.Modi("<PMM Ajustavel>", "90");
				}
				else if (Main._100.IsChecked == true)
				{
					Acesso.Modi("<PMM Ajustavel>", "100");
				}
				else
				{
					Acesso.Remover("Fica Estabelecido um Prêmio Mínimo de <PMM Ajustavel>% do projetado.");
				}
			}
			if (Main.Chk_DDR.IsChecked == true)
			{
				Acesso.Remover("<DRR NAO Aplicavel>");
			}
			else
			{
				Acesso.Remover(Arquivos.DDR);
				Acesso.Modi("<DRR NAO Aplicavel>", "Não Aplicável");
			}
			Acesso.Modi("<Data>", DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
			Acesso.Modi("<Segurado>", Main.Segurado.Text.ToUpper());
			Acesso.Modi("<Corretor>", Main.Corretor.Text.ToUpper());
			Acesso.Modi("<CNPJ>", Main.CNPJ.Text);
			Acesso.Modi("<Ncotacao>",Main.Ncotacao.Text);

			Acesso.Modi("<Mercadoria>",Main.Mercadoria.Text);
			Acesso.Modi("<Importancia segurada>", c.C(Main.Importancia_Segurada.Text));
			Acesso.Modi("<Importancia seguradaExtenso>", Extenso.EscreverExtenso(c.E(Main.Importancia_Segurada.Text)));
			string cober = Coberturas();
			Acesso.Modi("<Coberturas>", cober);

			Acesso.Modi("<LMG>", c.C(Main.LMG.Text));
			Acesso.Modi("<LMG Extenso>", Extenso.EscreverExtenso(c.E(Main.LMG.Text)));
			
			Acesso.Modi("<Premio Minimo>", c.C(Main.Premio_Minimo.Text));
			Acesso.Modi("<Premio Minimo Extenso>", Extenso.EscreverExtenso(c.E(Main.Premio_Minimo.Text)));

			if (Main.CHK_Fixa.IsChecked == true)
			{
				
				Acesso.Remover(Arquivos.Escalonada);
				Acesso.Modi("<Percentual>", Main.Fixa_Percentual.Text);
				Acesso.Modi("<percentual Extenso>", Extenso.EscreverExtenso(Main.Fixa_Percentual.Text).Replace("REAIS", ""));
				Acesso.Modi("<Valor>", Main.Fixa_Valor.Text);
				Acesso.Modi("<Valor Extenso>reais", Extenso.EscreverExtenso(c.E(Main.Fixa_Valor.Text)));
			}
			else
			{
				Acesso.Remover(Arquivos.Fixa);
				if(Main.POS1.Text == "0") {
					Acesso.Modi("<POS1>", "Isento");
				}
				else
				{
					Acesso.Modi("<POS1>", Main.POS1.Text + "% do prejuízo indenizável");
				}
				if (Main.POS2.Text == "0")
				{
					Acesso.Modi("<POS2>", "Isento");
				}
				else
				{
					Acesso.Modi("<POS2>", Main.POS2.Text + "% do prejuízo indenizável");
				}
				if (Main.POS3.Text == "0")
				{
					Acesso.Modi("<POS3>", "Isento");
				}
				else
				{
					Acesso.Modi("<POS3>", Main.POS3.Text + "% do prejuízo indenizável");
				}
			}
			
			if (Main.Com_Sublimite.IsChecked == true)
			{
				Acesso.Remover(Arquivos.SemSublimite);
				Acesso.Modi("<SubLimite>", Main.Sub_Limite.Text);
				Acesso.Modi("<SubLimite Extenso>", Extenso.EscreverExtenso(c.E(Main.Sub_Limite.Text)));
			}
			else
			{
				Acesso.Remover(Arquivos.ComSublimite);
			}
			
		}
		public static string Coberturas()
		{

			bool Adicionado = false;
			foreach (var janela in Application.Current.Windows)
			{
				if (janela.GetType() == Main.GetType())
				{
					Main = (Nacional)janela;
					break;
				}
			}
			CheckBox[] Basica = new CheckBox[] { Main.B1, Main.B2, Main.B3, Main.B4, Main.B5, Main.B6, Main.B7, Main.B8, Main.B9, Main.B10, Main.B11, Main.B12, Main.B13, Main.B14, Main.B15, Main.B16, Main.B17, Main.B18, Main.B19, Main.B20, Main.B21, Main.B22, Main.B23 };
			CheckBox[] Adicionais = new CheckBox[] { Main.A1, Main.A2, Main.A3, Main.A4, Main.A5, Main.A6, Main.A7, Main.A8, Main.A9, Main.A10, Main.A11, Main.A12, Main.A13, Main.A14 };
			CheckBox[] Especificas = new CheckBox[] { Main.E1, Main.E2, Main.E3, Main.E4, Main.E5, Main.E6, Main.E7, Main.E8, Main.E9, Main.E10, Main.E11, Main.E12, Main.E13, Main.E14 };

			string saida = string.Empty;
			foreach (CheckBox check in Basica)
			{
				if (check.IsChecked == true)
				{
					if (Adicionado == false)
						saida += "\rCoberturas Básica:\r\r";
					Adicionado = true;
					saida += check.Content.ToString().Replace("  "," ") + "\r";
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

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Word = Microsoft.Office.Interop.Word;
namespace Cotador.Nacional
{
	class Gerar_Nacional
	{
		public static void Gerar()
		{
			consertar_numeros c = new consertar_numeros();
			Nacional Main = new Nacional();
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
				acesso.Remover("(<Sinistros Extenso>)");
				acesso.Modi("R$ <Sinistros>", c.C(Main.Sinistros.Text));
			}
			else
			{
				acesso.Modi("<Sinistros Extenso>", Extenso.EscreverExtenso(c.E(Main.Sinistros.Text)));
				acesso.Modi("<Sinistros>", c.C(Main.Sinistros.Text));
			}
			acesso.Modi("<Mercadoria>",Main.Mercadoria.Text);
			acesso.Modi("<Importancia segurada>", c.C(Main.Importancia_Segurada.Text));
			acesso.Modi("<Importancia seguradaExtenso>", Extenso.EscreverExtenso(c.E(Main.Importancia_Segurada.Text)));
			acesso.Modi("<LMG>", c.C(Main.LMG.Text));
			acesso.Modi("<LMG Extenso>", Extenso.EscreverExtenso(c.E(Main.LMG.Text)));
			if(Main.Averbavel.IsChecked == true)
			{
				acesso.ARemover(Arquivos.Ajustavel);
				
			}
			else
			{
				acesso.ARemover(Arquivos.Averbavel);
				acesso.Modi("<Taxa>", Main.Taxa.Text);
				double importancia_segurada = double.Parse(c.E(Main.Importancia_Segurada.Text));
				double taxa = double.Parse(c.E(Main.Taxa.Text));
				double premio_liquido;
				double IOF;
				double premio_total;
				double parcelas = double.Parse(Main.Ajustavel_Quantidade_Parcela.Text);
				premio_liquido = importancia_segurada * (taxa / 100);
				IOF = premio_liquido * (7.38 / 100);
				premio_total = premio_liquido + IOF;
				//.ToString("N", new CultureInfo("pt-br", false)
				acesso.Modi("<importancia segurada>", importancia_segurada.ToString("N", new CultureInfo("pt-br", false)));
				acesso.Modi("<Taxa>", taxa.ToString().Replace(".", ","));
				acesso.Modi("<Premio liquido>", premio_liquido.ToString("N", new CultureInfo("pt-br", false)));
				acesso.Modi("<Premio Liquido * 7,38%>", IOF.ToString("N", new CultureInfo("pt-br", false)));
				acesso.Modi("<Premio liquido + IOF>", premio_total.ToString("N", new CultureInfo("pt-br", false)));
				acesso.Modi("<Quantidades de parcelas>",Main.Ajustavel_Quantidade_Parcela.Text);
				acesso.Modi("<Premio liquido Extenso>", Extenso.EscreverExtenso(c.M(premio_liquido.ToString())));
				acesso.Modi("<Premio liquido / quantidades de parcelas>",(premio_liquido / parcelas).ToString("N", new CultureInfo("pt-br", false)))
			}



		}
	}
}

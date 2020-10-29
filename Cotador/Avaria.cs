using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Cotador
{
	class Avaria
	{        
		string[] numeros = new string[] { "5.1.1","5.1.2","5.1.3","5.1.4"};
		public void avaria()
		{
			consertar_numeros c = new consertar_numeros();
			MainWindow Main = new MainWindow();
			foreach (var janela in Application.Current.Windows)
			{
				if (janela.GetType() == Main.GetType())
				{
					Main = (MainWindow)janela;
					break;
				}
			}
			int qual = 0;
			if (Main.Chk_Avaraia.IsChecked == false)
			{
				Acesso.Remover(Carregar_Arquivos.Roubo.Avaria_Taxa);
				Acesso.Remover(Carregar_Arquivos.Roubo.Avaria_Cobertura);
			}
			else
			{
				Acesso.Modi("<AVLR>", numeros[qual]);
				qual++;
			}
			if(Main.Chk_limpeza.IsChecked == false && Main.Chk_Avaraia.IsChecked == false)
			{
				Acesso.Remover("<Taxas Adicionais:>");
			}
			else
			{
				Acesso.Modi("<Taxas Adicionais:>", "Taxas Adicionais:");
			}
			if (Main.Main_Desconto.IsChecked == true)
			{
				Acesso.Modi("<TaxaDesconto>", Main.Desconto.Text);
				
			}
			else
			{
				Acesso.Modi("De acordo com a tabela de taxas, por percurso, aplicado ao seguro de RCTR-C, com desconto de <TaxaDesconto>% ", $"Para as coberturas estabelecidas na presente apólice será aplicada a taxa única de {Main.Taxa_Unica.Text}%");
				//acesso.Modi("<TaxaUnica>", Main.Taxa_Unica.Text);
			}
			if (Main.Chk_limpeza.IsChecked == true)
			{
				Acesso.Modi("<LDPVLR>", numeros[qual]);
				Acesso.Modi("<Limpeza de Pista>", c.C(Main.Limpeza_LMG.Text));
				Acesso.Modi("<limpezaEXTLMG>", Extenso.EscreverExtenso(c.E(Main.Limpeza_LMG.Text)));
				Acesso.Modi("<Limpeza de Pista Franquia%>",Main.Limpeza_Franquia.Text);
				Acesso.Modi("<Limpeza de Pista Franquia R$>", c.C(Main.Limpeza_FranquiaRS.Text));
				Acesso.Modi("<Limpeza de Pista Franquia R$ Extenso>", Extenso.EscreverExtenso(c.E(Main.Limpeza_FranquiaRS.Text)));
				Acesso.Modi("<Limpeza de Pista %>", Main.Limpeza_Taxa.Text);
				qual++;
			}
			else
			{
				Acesso.Remover(Carregar_Arquivos.Roubo.Limpeza_de_pista);
				Acesso.Remover(Carregar_Arquivos.Roubo.Limpeza_de_pista_franquia);
				Acesso.Remover(Carregar_Arquivos.Roubo.Limpeza_de_pista_cobertura);
			}
			if (Main.Chk_Container.IsChecked == true)
			{
				Acesso.Modi("<CVLR>", numeros[qual]);
				Acesso.Modi("<Container LMG>", c.C(Main.Lmg_Container.Text));
				Acesso.Modi("<Container LMG Extenso>", Extenso.EscreverExtenso(c.E(Main.Lmg_Container.Text)));
				qual++;
			}
			else
			{
				Acesso.Remover(Carregar_Arquivos.Roubo.Container);
			}
			
			Acesso.header("<Segurado>", Main.Segurado.Text);
			Acesso.header("<CNPJ>", Main.CNPJ.Text);
			Acesso.Modi("<Segurado>", Main.Segurado.Text);
			Acesso.Modi("<CNPJ>", Main.CNPJ.Text); ;
			Acesso.Modi("<Corretor>", Main.Corretor.Text);
			Acesso.Modi("<NCotacao>", Main.RCTRC.Text);
			if (c.F(Main.Sinistros.Text)){
				Acesso.Remover("(<Sinistros Extenso>)");
				Acesso.Modi("R$ <Sinistros>", c.C(Main.Sinistros.Text));
			}
			else
			{
				Acesso.Modi("<Sinistros Extenso>", Extenso.EscreverExtenso(c.E(Main.Sinistros.Text)));
				Acesso.Modi("<Sinistros>", c.C(Main.Sinistros.Text));
			}
			

			//acesso.modi("ssmercadorias", Main.Mercadoria.Text);

			Acesso.Modi("<LMG>", c.C(Main.LMG.Text));
			Acesso.Modi("<LMG_Extenso>", Extenso.EscreverExtenso(c.E(Main.LMG.Text)));

			Acesso.Modi("<Avaria LMG>", c.C(Main.Avaria_LMG.Text));
			Acesso.Modi("<Avaria LMG Extenso>", Extenso.EscreverExtenso(c.E(Main.Avaria_LMG.Text)));

			Acesso.Modi("<Avaria Franquia>", Main.Avaria_Fraquia.Text);
			Acesso.Modi("<Avaria Franquia R$>", c.C(Main.Avaria_franquia_RS.Text));
			Acesso.Modi("<Avaria Franquia R$ Extenso>", Extenso.EscreverExtenso(c.E(Main.Avaria_franquia_RS.Text)));
			Acesso.Modi("<Avaria Taxa>", Main.Avaria_Taxa.Text);

			Acesso.Modi("<Premio Minimo>", c.C(Main.Premio_Minimo.Text));
			Acesso.Modi("<Premio Minimo Extenso>", Extenso.EscreverExtenso(c.E(Main.Premio_Minimo.Text)));
			Acesso.header("<Data>", DateTime.Today.Day.ToString() + "/"+DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() );
			Acesso.Modi("<Data>", DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
		}
	}
}

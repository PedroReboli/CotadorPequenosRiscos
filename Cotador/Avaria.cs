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
                acesso.Remover(Carregar_Arquivos.Roubo.Avaria_Taxa);
                acesso.Remover(Carregar_Arquivos.Roubo.Avaria_Cobertura);
            }
            else
            {
                acesso.Modi("<AVLR>", numeros[qual]);
                qual++;
            }
            if(Main.Chk_limpeza.IsChecked == false && Main.Chk_Avaraia.IsChecked == false)
            {
                acesso.Remover("<Taxas Adicionais:>");
            }
            else
            {
                acesso.Modi("<Taxas Adicionais:>", "Taxas Adicionais:");
            }
            if (Main.Main_Desconto.IsChecked == true)
            {
                acesso.Modi("<TaxaDesconto>", Main.Desconto.Text);
                
            }
            else
            {
                acesso.Modi("De acordo com a tabela de taxas, por percurso, aplicado ao seguro de RCTR-C, com desconto de <TaxaDesconto>% ", $"Para as coberturas estabelecidas na presente apólice será aplicada a taxa única de {Main.Taxa_Unica.Text}%");
                //acesso.Modi("<TaxaUnica>", Main.Taxa_Unica.Text);
            }
            if (Main.Chk_limpeza.IsChecked == true)
            {
                acesso.Modi("<LDPVLR>", numeros[qual]);
                acesso.Modi("<Limpeza de Pista>", c.C(Main.Limpeza_LMG.Text));
                acesso.Modi("<limpezaEXTLMG>", Extenso.EscreverExtenso(c.E(Main.Limpeza_LMG.Text)));
                acesso.Modi("<Limpeza de Pista Franquia%>",Main.Limpeza_Franquia.Text);
                acesso.Modi("<Limpeza de Pista Franquia R$>", c.C(Main.Limpeza_FranquiaRS.Text));
                acesso.Modi("<Limpeza de Pista Franquia R$ Extenso>", Extenso.EscreverExtenso(c.E(Main.Limpeza_FranquiaRS.Text)));
                acesso.Modi("<Limpeza de Pista %>", Main.Limpeza_Taxa.Text);
                qual++;
            }
            else
            {
                acesso.Remover(Carregar_Arquivos.Roubo.Limpeza_de_pista);
                acesso.Remover(Carregar_Arquivos.Roubo.Limpeza_de_pista_franquia);
                acesso.Remover(Carregar_Arquivos.Roubo.Limpeza_de_pista_cobertura);
            }
            if (Main.Chk_Container.IsChecked == true)
            {
                acesso.Modi("<CVLR>", numeros[qual]);
                acesso.Modi("<Container LMG>", c.C(Main.Lmg_Container.Text));
                acesso.Modi("<Container LMG Extenso>", Extenso.EscreverExtenso(c.E(Main.Lmg_Container.Text)));
                qual++;
            }
            else
            {
                acesso.Remover(Carregar_Arquivos.Roubo.Container);
                
            }
            
            acesso.header("<Segurado>", Main.Segurado.Text);
            acesso.header("<CNPJ>", Main.CNPJ.Text);
            acesso.Modi("<Segurado>", Main.Segurado.Text);
            acesso.Modi("<CNPJ>", Main.CNPJ.Text); ;
            acesso.Modi("<Corretor>", Main.Corretor.Text);
            acesso.Modi("<NCotacao>", Main.RCTRC.Text);
            if (c.F(Main.Sinistros.Text)){
                acesso.Remover("(<Sinistros Extenso>)");
                acesso.Modi("R$ <Sinistros>", c.C(Main.Sinistros.Text));
            }
            else
            {
                acesso.Modi("<Sinistros Extenso>", Extenso.EscreverExtenso(c.E(Main.Sinistros.Text)));
                acesso.Modi("<Sinistros>", c.C(Main.Sinistros.Text));
            }
            

            //acesso.modi("ssmercadorias", Main.Mercadoria.Text);

            acesso.Modi("<LMG>", c.C(Main.LMG.Text));
            acesso.Modi("<LMG_Extenso>", Extenso.EscreverExtenso(c.E(Main.LMG.Text)));

            acesso.Modi("<Avaria LMG>", c.C(Main.Avaria_LMG.Text));
            acesso.Modi("<Avaria LMG Extenso>", Extenso.EscreverExtenso(c.E(Main.Avaria_LMG.Text)));

            acesso.Modi("<Avaria Franquia>", Main.Avaria_Fraquia.Text);
            acesso.Modi("<Avaria Franquia R$>", c.C(Main.Avaria_franquia_RS.Text));
            acesso.Modi("<Avaria Franquia R$ Extenso>", Extenso.EscreverExtenso(c.E(Main.Avaria_franquia_RS.Text)));
            acesso.Modi("<Avaria Taxa>", Main.Avaria_Taxa.Text);

            acesso.Modi("<Premio Minimo>", c.C(Main.Premio_Minimo.Text));
            acesso.Modi("<Premio Minimo Extenso>", Extenso.EscreverExtenso(c.E(Main.Premio_Minimo.Text)));
            acesso.header("<Data>", DateTime.Today.Day.ToString() + "/"+DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString() );
            acesso.Modi("<Data>", DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
        }
    }
}

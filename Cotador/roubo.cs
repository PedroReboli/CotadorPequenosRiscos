using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Cotador
{
    class roubo
    {
        static public void Roubo()
        {
            consertar_numeros c = new consertar_numeros();
            MainWindow Main = Application.Current.Windows[0] as MainWindow;


            acesso.header("<Segurado>", Main.Segurado.Text);
            acesso.header("<CNPJ>", Main.CNPJ.Text);
            acesso.Modi("<Corretor>", Main.Corretor.Text);
            acesso.Modi("<Segurado>", Main.Segurado.Text);
            acesso.Modi("<Corretor>", Main.Corretor.Text);
            acesso.Modi("<NCotacao>", Main.RCFDC.Text);
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
            acesso.Modi("<LMG>", c.C(Main.LMG.Text));
            acesso.Modi("<LMG_Extenso>", Extenso.EscreverExtenso(c.E(Main.LMG.Text)));

            

            acesso.Modi("<TaxaUnica>", Main.Taxa_Roubo.Text);
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
            int pos;
            if (int.TryParse(Main.POS_1.Text,out pos) == false)
            {
                pos = 0;
            }
            if (pos == 0)
            {
                acesso.Modi("<POS1>", "Isento;");
            }
            else
            {
                acesso.Modi("<POS1>", $"{Main.POS_1.Text}% do prejuízo indenizável;");
            }

            if (int.TryParse(Main.POS_2.Text, out pos) == false)
            {
                pos = 0;
            }
            if (pos == 0)
            {
                acesso.Modi("<POS2>", "Isento;");
            }
            else
            {
                acesso.Modi("<POS2>", $"{Main.POS_2.Text}% do prejuízo indenizável;");
            }

            if (int.TryParse(Main.POS_3.Text, out pos) == false)
            {
                pos = 0;
            }
            if (pos == 0)
            {
                acesso.Modi("<POS3>", "Isento;");
            }
            else
            {
                acesso.Modi("<POS3>", $"{Main.POS_3.Text}% do prejuízo indenizável;");
            }
            

            acesso.Modi("<Premio Minimo>", c.C(Main.Premio_Minimo.Text));
            acesso.Modi("<Premio Minimo Extenso>", Extenso.EscreverExtenso(c.E(Main.Premio_Minimo.Text)));
            acesso.header("<Data>", DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
            acesso.Modi("<Data>", DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
        }
    }
}

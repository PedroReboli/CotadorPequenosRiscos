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
            MainWindow Main = new MainWindow();
            foreach (var janela in Application.Current.Windows)
            {
                if (janela.GetType() == Main.GetType())
                {
                    Main = (MainWindow)janela;
                    break;
                }
            }


            Acesso.header("<Segurado>", Main.Segurado.Text);
            Acesso.header("<CNPJ>", Main.CNPJ.Text);
            Acesso.Modi("<Corretor>", Main.Corretor.Text);
            Acesso.Modi("<Segurado>", Main.Segurado.Text);
            Acesso.Modi("<Corretor>", Main.Corretor.Text);
            Acesso.Modi("<NCotacao>", Main.RCFDC.Text);
            if (c.F(Main.Sinistros.Text))
            {
                Acesso.Remover("(<Sinistros Extenso>)");
                Acesso.Modi("R$ <Sinistros>", c.C(Main.Sinistros.Text));
            }
            else
            {
                Acesso.Modi("<Sinistros Extenso>", Extenso.EscreverExtenso(c.E(Main.Sinistros.Text)));
                Acesso.Modi("<Sinistros>", c.C(Main.Sinistros.Text));
            }
            Acesso.Modi("<LMG>", c.C(Main.LMG.Text));
            Acesso.Modi("<LMG_Extenso>", Extenso.EscreverExtenso(c.E(Main.LMG.Text)));

            

            Acesso.Modi("<TaxaUnica>", Main.Taxa_Roubo.Text);
            if (c.F(Main.Sinistros.Text))
            {
                Acesso.Remover("(<Sinistros Extenso>)");
                Acesso.Modi("R$ <Sinistros>", c.C(Main.Sinistros.Text));
            }
            else
            {
                Acesso.Modi("<Sinistros Extenso>", Extenso.EscreverExtenso(c.E(Main.Sinistros.Text)));
                Acesso.Modi("<Sinistros>", c.C(Main.Sinistros.Text));
            }
            int pos;
            if (int.TryParse(Main.POS_1.Text,out pos) == false)
            {
                pos = 0;
            }
            if (pos == 0)
            {
                Acesso.Modi("<POS1>", "Isento;");
            }
            else
            {
                Acesso.Modi("<POS1>", $"{Main.POS_1.Text}% do prejuízo indenizável;");
            }

            if (int.TryParse(Main.POS_2.Text, out pos) == false)
            {
                pos = 0;
            }
            if (pos == 0)
            {
                Acesso.Modi("<POS2>", "Isento;");
            }
            else
            {
                Acesso.Modi("<POS2>", $"{Main.POS_2.Text}% do prejuízo indenizável;");
            }

            if (int.TryParse(Main.POS_3.Text, out pos) == false)
            {
                pos = 0;
            }
            if (pos == 0)
            {
                Acesso.Modi("<POS3>", "Isento;");
            }
            else
            {
                Acesso.Modi("<POS3>", $"{Main.POS_3.Text}% do prejuízo indenizável;");
            }
            

            Acesso.Modi("<Premio Minimo>", c.C(Main.Premio_Minimo.Text));
            Acesso.Modi("<Premio Minimo Extenso>", Extenso.EscreverExtenso(c.E(Main.Premio_Minimo.Text)));
            Acesso.header("<Data>", DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
            Acesso.Modi("<Data>", DateTime.Today.Day.ToString() + "/" + DateTime.Today.Month.ToString() + "/" + DateTime.Today.Year.ToString());
        }
    }
}

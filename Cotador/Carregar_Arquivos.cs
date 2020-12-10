using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows;

namespace Cotador
{
    class Carregar_Arquivos
    {
        string Ler(string path)
        {
            MainWindow Main = new MainWindow();
            foreach (var janela in Application.Current.Windows)
            {
                if (janela.GetType() == Main.GetType())
                {
                    Main = (MainWindow)janela;
                    break;
                }
            }
            string str = Main.path + path;
            StreamReader eae = new StreamReader(str);
            string saida = string.Empty;
            string linha;
            while (true)
            {
                linha = eae.ReadLine();
                if (linha == null)
                {
                    eae.Close();
                    return saida;
                }
                saida += linha + "\r";
            }
            
        }
        public class  Roubo:Carregar_Arquivos {
            static Carregar_Arquivos C = new Carregar_Arquivos();
            static MainWindow Main = new MainWindow();
            
            static public string Limpeza_de_pista
            {
                get
                {
                    return C.Ler("/Textos/Limpeza de Pista/Cobertura Adicional.txt");
                }
            }
            static public string Limpeza_de_pista_franquia
            {
                get
                {
                    return C.Ler("/Textos/Limpeza de Pista/Franquia.txt");
                }
            }
            static public string Limpeza_de_pista_cobertura
            {
                get
                {
                    return C.Ler( "/Textos/Limpeza de Pista/Cobertura.txt");
                }
            }
            static public string Avaria_Cobertura
            {
                get
                {
                    return C.Ler("/Textos/Avaria/Cobertura Adicional.txt");
                }
            }
            static public string Avaria_Taxa
            {
                get
                {
                    return C.Ler("/Textos/Avaria/Taxa.txt");
                }
            }
            static public string Container
            {
                get
                {
                    return C.Ler("/Textos/Container/Cobertura Adicional.txt");
                }
            }
        }
    }
}

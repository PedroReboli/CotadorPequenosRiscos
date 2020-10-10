using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
namespace Cotador
{
    class consertar_numeros
    {
        
        public string C (string valor)
        {
            MainWindow Main = Application.Current.Windows[0] as MainWindow;
            char[] az = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();

            foreach (char letra in az)
            {
                if (valor.ToLower().Contains(letra)) 
                    return valor;
            }
            if (valor.Length == 0) return "";
            bool resultado = false;
            try
            {
                resultado = (valor.Substring(valor.Length - 3, 3).Contains(",00") || valor.Substring(valor.Length - 3, 3).Contains(".00"));
            }
            catch
            {
                resultado = false;
            }
            if ( valor.Contains(",00")||valor.Contains(".00") && resultado)
            {
                valor = valor.Substring(0, valor.Length - 3);
            }
            if (Main.ponto_virgula == true)
            {
                valor += ".00";
            }
            else
            {
                valor += ",00";
            }

            return valor;
        }
        public string E (string valor)
        {
            if (valor.Length == 0) return "";
            if (valor.Substring(valor.Length - 3, 3).Contains(",00") | valor.Substring(valor.Length - 3, 3).Contains(".00"))
            {
                valor = valor.Substring(0, valor.Length - 3);
            }
            return valor.Replace(".","").Replace(",","");
        }
        public bool F (string valor)
        {
            char[] az = Enumerable.Range('a', 'z' - 'a' + 1).Select(i => (Char)i).ToArray();

            foreach (char letra in az)
            {
                if (valor.ToLower().Contains(letra))
                    return true;
            }
            return false;
        }
    }
}

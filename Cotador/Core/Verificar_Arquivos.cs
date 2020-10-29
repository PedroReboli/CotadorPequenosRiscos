using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotador.Core
{
	class Verificar_Arquivos
	{
		string[] arquivos = new string[] { }; 
		public static bool Verificar(string str)
		{
			string erro = string.Empty;
			bool saida = true;
			if (File.Exists(str + "Modelos\\Nacional\\" + "Nacional.doc") == false)
			{
				saida = false;
				erro += str + "Modelos\\Nacional\\" + "Nacional.doc\n";
			}
			
			return true;
		}
	}
}

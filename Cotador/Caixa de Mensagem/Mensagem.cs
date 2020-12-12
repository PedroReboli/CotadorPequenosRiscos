using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotador.Caixa_de_Mensagem
{
	class Mensagem
	{
		public static void Mostar(string Titulo,string Mensagem)
		{
			mensagem messa = new mensagem(Titulo, Mensagem);
			messa.Show();
		}
	}
}

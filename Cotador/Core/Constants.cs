using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotador.Core
{
	class Constants
	{
#if (DEBUG)
		public const string ServerIP = "192.168.0.10";
		public const int ServerPort = 9090;
#else
		public const string ServerIP = "servidordetestes.bounceme.net";
		public const int ServerPort = 9090;
#endif
		public static UInt64 Configuracoes = 0;

		public static bool config(UInt64 Valor,int N)
		{	
			// Verifica se o bit do Valor na posiçao N é 1
			return (Valor & (UInt64)(1 << N)) != 0; //Esse processo esta one line para melhorar perfomance
		}
		public static bool Transportador()
		{
			return config(Configuracoes, 0);
		}
		public static bool Nacional()
		{
			return config(Configuracoes, 1);
		}
		public static bool Internacional()
		{
			return config(Configuracoes, 3);
		}
		public static bool Avulsas()
		{
			return config(Configuracoes, 2);
		}
		
	}
}

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
		public const string ServerIP = "127.0.0.1";
		public const int ServerPort = 9090;
#else
		public const string ServerIP = "servidordetestes.bounceme.net";
		public const int ServerPort = 9090;
#endif
		public static string NomeSubscritor = "";
	}
}

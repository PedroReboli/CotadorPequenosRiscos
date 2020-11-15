using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Reflection;
using System.IO;
using System.Diagnostics;
using System.Security.Cryptography;
using static System.Math;
namespace Cotador.Core
{
	class Network
	{

		Socket sock;
		IPHostEntry hostEntry;
		SHA512CryptoServiceProvider KEY = new SHA512CryptoServiceProvider();
		byte[] hekey;
		byte[] mekey;
		byte[] EOC = new byte[] { (byte)00 };
		byte[] STR = new byte[] { (byte)01 };
		byte[] BYT = new byte[] { (byte)02 };
		//byte[] EOC = new byte[] = {(byte)00};
		Network()
		{
			FileInfo fi = new FileInfo(Process.GetCurrentProcess().MainModule.FileName);
			FileStream stream = File.Create(Process.GetCurrentProcess().MainModule.FileName, (int)fi.Length, FileOptions.Asynchronous);
			KEY.ComputeHash(stream);
			stream.Close();
		}
		public bool Connect(string Host, int Port)
		{
			hostEntry = Dns.GetHostEntry(Host);

			foreach (IPAddress address in hostEntry.AddressList)
			{
				IPEndPoint ipe = new IPEndPoint(address, Port);
				Socket tempSocket =
					new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

				tempSocket.Connect(ipe);

				if (tempSocket.Connected)
				{
					sock = tempSocket;
					SetupConnect();
					return true;
				}
				else
				{
					continue;
				}
			}
			return false;
		}
		private void TSend(byte[] valor)
		{
			long tamanho = 0;
			tamanho = (long)valor.Length;
			byte[] Btamanho = BitConverter.GetBytes(tamanho);
			sock.Send(Btamanho, Btamanho.Length, 0); // envia tamanho estring
			sock.Receive(Btamanho);// espera receber confirmaçao
			sock.Send(valor, valor.Length, 0);// envia os dados
			sock.Receive(Btamanho);// espera receber confirmaçao
		}
		private byte[] TRecv()
		{
			long receber;
			byte[] buffer = new byte[8];
			sock.Receive(buffer, buffer.Length, 0); // recebe tamanho a receber
			receber = BitConverter.ToInt64(buffer, 0);
			sock.Send(EOC);                    // envia confirmaçao

			byte[] data = new byte[receber];
			int size = (int)receber;
			var total = 0;
			var dataleft = size;
			while (total <= size)
			{
				var recv = sock.Receive(data, total, dataleft, SocketFlags.None); // recebe os dados
				if (recv == 0)
				{
					data = null;
					break;
				}
				total += recv;
				dataleft -= recv;
			}
			sock.Send(EOC); //envia confirmaçao

			return data;
		}

		private byte[] cript(byte[] Key, byte[] data)
		{
			int KeyLength = Key.Length;
			byte[] dados = data;
			for (int x = 0; x == data.Length; x++)
			{
				dados[x] = (byte)(Key[(int)Abs(Round(Sin(KeyLength + x + Key[x]) * 1000) % KeyLength)] ^ dados[x]);
			}
			return dados;
		}
		public void Send(object valor)
		{
			byte[] enviar;
			if (valor.Equals(string.Empty))
			{
				enviar = Encoding.ASCII.GetBytes((string)valor);
				TSend(STR);
			}
			else if (valor.Equals(EOC))
			{
				enviar = (byte[])valor;
				TSend(BYT);
			}
			else
			{
				throw new System.FormatException("formato é invalido");
			}
			TSend(enviar);
			Buffer.BlockCopy(enviar, 0, mekey, 0, 3);
			KEY.Clear();
			KEY.ComputeHash(mekey);
			mekey = KEY.Hash;
			KEY.Clear();

		}
		public object Recv()
		{
			byte[] tipo = new byte[1];
			sock.Receive(tipo);
			bool Tstr = false;
			bool Tbyt = false;
			switch (tipo[0])
			{
				case (byte)01:
					Tstr = true;
					break;
				case (byte)02:
					Tbyt = true;
					break;
			}
			byte[] data = TRecv();
			data = cript(hekey, data);
			Buffer.BlockCopy(data, 0, hekey, 0, 3);
			KEY.Clear();
			KEY.ComputeHash(hekey);
			hekey = KEY.Hash;
			KEY.Clear();
			if (Tstr == true)
			{
				return Encoding.ASCII.GetString(data);
			}
			if (Tbyt == true)
			{
				return data;
			}
			return null;
		}
		private void SetupConnect()
		{
			mekey = KEY.Hash;
			TSend(mekey);
			hekey = TRecv();
			byte[] code = (byte[])Recv();
			switch (code[0])
			{
				case (byte)00:
					return;
				case (byte)01:
					throw new System.Exception("Programa Corrompido");
				case (byte)02:
					throw new System.Exception("Programa Destaualizado");
				default:
					throw new System.Exception("Codigo Corrompido");
			}
		}
	}
}

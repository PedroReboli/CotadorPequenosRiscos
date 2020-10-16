﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cotador.Nacional
{
	class Arquivos
	{
		static string Ler(string path)
		{

			string str = path;
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
		static public string[] Ajustavel
		{
			get
			{
				Nacional main = new Nacional();
				string[] saida = new string[Directory.GetFiles(main.path + @"Modelos\Nacional\Textos\Ajustavel\").Length];
				int i = 0;
				foreach (string arquivo in Directory.GetFiles(main.path + @"Modelos\Nacional\Textos\Ajustavel\"))
				{
					saida[i] = Ler(arquivo);
					i++;
				}
				return saida;
			}
		}
		static public string[] Averbavel
		{
			get
			{
				Nacional main = new Nacional();
				string[] saida = new string[Directory.GetFiles(main.path + @"Modelos\Nacional\Textos\Averbavel\").Length];
				int i = 0;
				foreach (string arquivo in Directory.GetFiles(main.path + @"Modelos\Nacional\Textos\Averbavel\"))
				{
					saida[i] = Ler(arquivo);
					i++;
				}
				return saida;
			}
		}
		static public string Fixa
		{
			get
			{
				Nacional main = new Nacional();
				string saida = string.Empty;
				saida = Ler(main.path + @"Modelos\Nacional\Textos\FixaEscalonada\Fixa.txt");
				return saida;
			}
		}
		static public string Escalonada
		{
			get
			{
				Nacional main = new Nacional();
				string saida = string.Empty;
				saida = Ler(main.path + @"Modelos\Nacional\Textos\FixaEscalonada\Fixa.txt");
				return saida;
			}
		}
		static public string ComSublimite
		{
			get
			{
				Nacional main = new Nacional();
				string saida = string.Empty;
				saida = Ler(main.path + @"Modelos\Nacional\Textos\Sublimite\Com Sublimite.txt");
				return saida;
			}
		}
		static public string SemSublimite
		{
			get
			{
				Nacional main = new Nacional();
				string saida = string.Empty;
				saida = Ler(main.path + @"Modelos\Nacional\Textos\Sublimite\Sem Sublimite.txt");
				return saida;
			}
		}
	}
}
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cotador.Nacional
{
	/// <summary>
	/// Interaction logic for Nacional.xaml
	/// </summary>
	public partial class Nacional : Window
	{
		public void Iniciar()
		{
			Coberturas.Items.Clear();
			Basicas();
			
			POS1.Visibility = Visibility.Hidden;
			POS2.Visibility = Visibility.Hidden;
			POS3.Visibility = Visibility.Hidden;


			LAB_Percentual.Visibility = Visibility.Hidden;
			LAB_Valor.Visibility = Visibility.Hidden;
			Fixa_Percentual.Visibility = Visibility.Hidden;
			Fixa_Valor.Visibility = Visibility.Hidden;

			LAB_Premio_Minimo.Visibility = Visibility.Hidden;
			Premio_Minimo.Visibility = Visibility.Hidden;

			LAB_Quantidade_De_Parcelas.Visibility = Visibility.Hidden;
			Ajustavel_Quantidade_Parcela.Visibility = Visibility.Hidden;
			LAB_Ajustavel_Premio_MInimo.Visibility = Visibility.Hidden;
			_80.Visibility = Visibility.Hidden;
			_90.Visibility = Visibility.Hidden;
			_100.Visibility = Visibility.Hidden;

			LAB_SubLimite.Visibility = Visibility.Hidden;
			Sub_Limite.Visibility = Visibility.Hidden;
		}
		long tempo = 0;
		public void Basicas()
		{
			Coberturas.Items.Clear();
			B1.Width = Coberturas.Width;
			B1.Content = "N° 1 – Cobertura Básica Restrita C (bens e/ou mercadorias usadas, em devolução ou redespachadas;".Replace('\t',' ');
			Coberturas.Items.Add(B1);
			B2.Width = Coberturas.Width;
			B2.Content = "N° 2 – 	Cobertura Básica Restrita B;".Replace('\t',' ');
			Coberturas.Items.Add(B2);
			B3.Width = Coberturas.Width;
			B3.Content = "N° 3 – Cobertura Básica Ampla A (bens e/ou mercadorias novas);".Replace('\t',' ');
			Coberturas.Items.Add(B3);
			B4.Width = Coberturas.Width;
			B4.Content = "N° 4 – Cobertura Básica Restrita para embarques de mercadorias/bens acondicionados em ambientes refrigerados;".Replace('\t',' ');
			Coberturas.Items.Add(B4);
			B5.Width = Coberturas.Width;
			B5.Content = "N° 5 – Cobertura Básica Ampla para embarques de mercadorias/bens acondicionados em ambientes refrigerados;".Replace('\t',' ');
			Coberturas.Items.Add(B5);
			B6.Width = Coberturas.Width;
			B6.Content = "N° 6 – Cobertura Básica Restrita para mercadorias/bens congeladas;".Replace('\t',' ');
			Coberturas.Items.Add(B6);
			B7.Width = Coberturas.Width;
			B7.Content = "N° 7 – Cobertura Básica Ampla para mercadorias/bens congelados;".Replace('\t',' ');
			Coberturas.Items.Add(B7);
			B8.Width = Coberturas.Width;
			B8.Content = "N° 8 – Cobertura Básica Ampla para bovinos incluindo reprodução;".Replace('\t',' ');
			Coberturas.Items.Add(B8);
			B9.Width = Coberturas.Width;
			B9.Content = "N° 9 – Cobertura Básica Ampla para animais vivos (exceto embarques aéreos de aves vivas);".Replace('\t',' ');
			Coberturas.Items.Add(B9);
			B10.Width = Coberturas.Width;
			B10.Content = "N° 10 – Cobertura Básica Ampla para seguros de transportes aéreos de aves vivas;".Replace('\t',' ');
			Coberturas.Items.Add(B10);
			B11.Width = Coberturas.Width;
			B11.Content = "N° 11 – Cobertura Básica Ampla para batata e outros bulbos-raízes;".Replace('\t',' ');
			Coberturas.Items.Add(B11);
			B12.Width = Coberturas.Width;
			B12.Content = "N° 12 – Cobertura Básica Ampla para embarques a granel (aquaviários e terrestres);".Replace('\t',' ');
			Coberturas.Items.Add(B12);
			B13.Width = Coberturas.Width;
			B13.Content = "N° 13 – Cobertura Básica Restrita para transporte de óleo (petróleo) a granel (embarques aquaviários e terrestres);".Replace('\t',' ');
			Coberturas.Items.Add(B13);
			B14.Width = Coberturas.Width;
			B14.Content = "N° 14 – Cobertura Básica Restrita para Carvão (embarques aquaviários e terrestres);".Replace('\t',' ');
			Coberturas.Items.Add(B14);
			B15.Width = Coberturas.Width;
			B15.Content = "N° 15 – Cobertura Básica Restrita para madeiras (carga no convés)".Replace('\t',' ');
			Coberturas.Items.Add(B15);
			B16.Width = Coberturas.Width;
			B16.Content = "N° 16 – Cobertura Básica Ampla para madeiras (carga não acondicionada no convés);".Replace('\t',' ');
			Coberturas.Items.Add(B16);
			B17.Width = Coberturas.Width;
			B17.Content = "N° 17 – Cobertura Básica Restrita para borracha natural (excluindo látex líquido);".Replace('\t',' ');
			Coberturas.Items.Add(B17);
			B18.Width = Coberturas.Width;
			B18.Content = "N° 18 – Cobertura Básica Restrita para juta;".Replace('\t',' ');
			Coberturas.Items.Add(B18);
			B19.Width = Coberturas.Width;
			B19.Content = "N° 19 – Cobertura Básica para seguros de operações isoladas;".Replace('\t',' ');
			Coberturas.Items.Add(B19);
			B20.Width = Coberturas.Width;
			B20.Content = "N° 20 – Cobertura Básica para seguros de bagagem;".Replace('\t',' ');
			Coberturas.Items.Add(B20);
			B21.Width = Coberturas.Width;
			B21.Content = "N° 21 – Cobertura Básica para seguros de mercadorias conduzidas por portadores;".Replace('\t',' ');
			Coberturas.Items.Add(B21);
			B22.Width = Coberturas.Width;
			B22.Content = "N° 22 – Cobertura Básica para seguros de mostruários sob a responsabilidade de viajantes comerciais;".Replace('\t',' ');
			Coberturas.Items.Add(B22);
			B23.Width = Coberturas.Width;
			B23.Content = "N° 23 – Cobertura Básica para seguros de transportes de títulos em malotes;".Replace('\t',' ');
			Coberturas.Items.Add(B23);
		}
		public void Adicionais()
		{
			Coberturas.Items.Clear();
			A1.Width = Coberturas.Width;
			A1.Content = "N° 201 – 	Cobertura Adicional de despesas;".Replace('\t',' ');
			Coberturas.Items.Add(A1);
			A2.Width = Coberturas.Width;
			A2.Content = "N° 205 –	Cobertura Adicional para mercadorias em devolução ou redespachadas;".Replace('\t',' ');
			Coberturas.Items.Add(A2);
			A3.Width = Coberturas.Width;
			A3.Content = "N° 206 –	Cobertura Adicional para embarques aéreos sem valor declarado;".Replace('\t',' ');
			Coberturas.Items.Add(A3);
			A4.Width = Coberturas.Width;
			A4.Content = "N° 207 – 	Cobertura Adicional para embarques em navios com denominação a avisar em viagens nacionais;".Replace('\t',' ');
			Coberturas.Items.Add(A4);
			A5.Width = Coberturas.Width;
			A5.Content = "N° 209 – 	Cobertura Adicional de transbordo e desvio de rota;".Replace('\t',' ');
			Coberturas.Items.Add(A5);
			A6.Width = Coberturas.Width;
			A6.Content = "N° 210 – 	Cobertura Adicional de riscos de greves;".Replace('\t',' ');
			Coberturas.Items.Add(A6);
			A7.Width = Coberturas.Width;
			A7.Content = "N° 212 – 	Cobertura Adicional de prorrogação de prazo de duração dos riscos;".Replace('\t',' ');
			Coberturas.Items.Add(A7);
			A8.Width = Coberturas.Width;
			A8.Content = "N° 213 – 	Cobertura Adicional de extensão de cobertura e abertura de volumes;".Replace('\t',' ');
			Coberturas.Items.Add(A8);
			A9.Width = Coberturas.Width;
			A9.Content = "N° 214 – 	Cobertura Adicional de benefícios internos;".Replace('\t',' ');
			Coberturas.Items.Add(A9);
			A10.Width = Coberturas.Width;
			A10.Content = "N° 215 – 	Cobertura Adicional de destruição;".Replace('\t',' ');
			Coberturas.Items.Add(A10);
			A11.Width = Coberturas.Width;
			A11.Content = "N° 216 –	Cobertura Adicional para mercadorias transportadas em veículos do segurado;".Replace('\t',' ');
			Coberturas.Items.Add(A11);
			A12.Width = Coberturas.Width;
			A12.Content = "N° 217 – 	Cobertura Adicional de roubo (somente com a cobertura Básica Restrita C);".Replace('\t',' ');
			Coberturas.Items.Add(A12);
			A13.Width = Coberturas.Width;
			A13.Content = "N° 218 – 	Cobertura Adicional de extravio (somente com a cobertura Básica Restrita B);".Replace('\t',' ');
			Coberturas.Items.Add(A13);
			A14.Width = Coberturas.Width;
			A14.Content = "N° 219 – 	Cobertura Adicional para os riscos de quebra (somente com a cobertura Básica Ampla A);".Replace('\t',' ');
			Coberturas.Items.Add(A14);
		}
		public void Especificas()
		{
			Coberturas.Items.Clear();
			E1.Width = Coberturas.Width;
			E1.Content = "N° 301 – 	Cláusula Específica para bens usados (limitado à Básica Restrita C);".Replace('\t',' ');
			Coberturas.Items.Add(E1);
			E2.Width = Coberturas.Width;
			E2.Content = "N° 302 –	Cláusula Específica para embarques aéreos sem valor declarado;".Replace('\t',' ');
			Coberturas.Items.Add(E2);
			E3.Width = Coberturas.Width;
			E3.Content = "N° 303 –	Cláusula Específica para seguros de importação chapas galvanizadas e/ou folhas de ferro zincadas (folha de flandres), (limitado à Básica Restrita C);".Replace('\t',' ');
			Coberturas.Items.Add(E3);
			E4.Width = Coberturas.Width;
			E4.Content = "N° 304 – 	Cláusula Específica para embarques efetuados no convés dos navios (limitado à cobertura Básica Restrita C);".Replace('\t',' ');
			Coberturas.Items.Add(E4);
			E5.Width = Coberturas.Width;
			E5.Content = "N° 308 - 	Cláusula Específica de averbações para os seguros de transportes de exportação e transportes nacionais;".Replace('\t',' ');
			Coberturas.Items.Add(E5);
			E6.Width = Coberturas.Width;
			E6.Content = "N° 309 – 	Cláusula Específica de averbações simplificadas para os seguros de transportes nacionais e para os seguros de exportação;".Replace('\t',' ');
			Coberturas.Items.Add(E6);
			E7.Width = Coberturas.Width;
			E7.Content = "N° 310 –	Cláusula Específica de franquia para os seguros de transportes internacionais e nacionais (exceto operações isoladas e transportes terrestres nacionais);".Replace('\t',' ');
			Coberturas.Items.Add(E7);
			E8.Width = Coberturas.Width;
			E8.Content = "N° 311 – 	Cláusula Específica de participação obrigatória/franquia para os seguros de operações isoladas e transportes terrestres nacionais;".Replace('\t',' ');
			Coberturas.Items.Add(E8);
			E9.Width = Coberturas.Width;
			E9.Content = @"N° 312 – 	Cláusula Específica para aparelhos, máquinas e equipamentos;".Replace('\t',' ');
			Coberturas.Items.Add(E9);
			E10.Width = Coberturas.Width;
			E10.Content = "N° 313 –	Cláusula Específica para quebra (falta) em mercadorias a granel;".Replace('\t',' ');
			Coberturas.Items.Add(E10);
			E11.Width = Coberturas.Width;
			E11.Content = @"N° 314 –	Cláusula Específica para mercadorias transportadas em containers ""Padrão ISO"";".Replace('\t',' ');
			Coberturas.Items.Add(E11);
			E12.Width = Coberturas.Width;
			E12.Content = "N° 315 – 	Cláusula Específica de estipulação de seguro de transportes;".Replace('\t',' ');
			Coberturas.Items.Add(E12);
			E13.Width = Coberturas.Width;
			E13.Content = "N° 316 – 	Cláusula Específica de beneficiário.".Replace('\t',' ');
			Coberturas.Items.Add(E13);
			E14.Width = Coberturas.Width;
			E14.Content = "N° 317 – 	Cláusula Específica de dispensa do direito de regresso.".Replace('\t',' ');
			E14.Checked += DDR;
			E14.Unchecked += DDR;
			Coberturas.Items.Add(E14);
		}
		public string path;
		public Nacional()
		{
			InitializeComponent();
			/*string para = @"N° 301 – 	Cláusula Específica para bens usados (limitado à Básica Restrita C);
N° 302 –	Cláusula Específica para embarques aéreos sem valor declarado;
N° 303 –	Cláusula Específica para seguros de importação chapas galvanizadas e/ou folhas de ferro zincadas (folha de flandres), (limitado à Básica Restrita C);
N° 304 – 	Cláusula Específica para embarques efetuados no convés dos navios (limitado à cobertura Básica Restrita C);
N° 308 - 	Cláusula Específica de averbações para os seguros de transportes de exportação e transportes nacionais;
N° 309 – 	Cláusula Específica de averbações simplificadas para os seguros de transportes nacionais e para os seguros de exportação;
N° 310 –	Cláusula Específica de franquia para os seguros de transportes internacionais e nacionais (exceto operações isoladas e transportes terrestres nacionais);
N° 311 – 	Cláusula Específica de participação obrigatória/franquia para os seguros de operações isoladas e transportes terrestres nacionais;
N° 312 – 	Cláusula Específica para aparelhos, máquinas e equipamentos;
N° 313 –	Cláusula Específica para quebra (falta) em mercadorias a granel;
N° 314 –	Cláusula Específica para mercadorias transportadas em containers ""Padrão ISO"";
N° 315 – 	Cláusula Específica de estipulação de seguro de transportes;
N° 316 – 	Cláusula Específica de beneficiário.
N° 317 – 	Cláusula Específica de dispensa do direito de regresso.";
			string saida = "";
			para = Coberturas_Adicionais;
			int numero = 1;
			int maior = 0;
			foreach (string cobertura in para.Split('\n'))
			{
				if (cobertura.Length > maior) maior = cobertura.Length;
				saida += "public CheckBox E" + numero.ToString() + " = new CheckBox();\n";
				numero++;
			}
			numero = 1;
			foreach (string cobertura in para.Split('\n'))
			{
				
				saida += "A"+numero.ToString()+ ".Width = Coberturas.Width;\n";
				string repeat = cobertura.Replace("\n", "").Replace("\r", "");
				//string espaco = String.Concat(Enumerable.Repeat(" ", Math.Abs(maior - repeat.Length)));
				saida += "A"+numero.ToString()+@".Content = """+cobertura.Replace("\n", "").Replace("\r", "") + @""";"+"\n";
				saida += "Coberturas.Items.Add(A"+numero.ToString()+");\n";
				numero++;
			}
			//System.IO.File.WriteAllText(@"C:\Python\texto.txt", saida);
			*/
			Especificas();
			Basicas();
			Iniciar();
			
		}
		private void Button_Click(object sender, RoutedEventArgs e)
		{
			try
			{
				Gerar_Arquivo.gerar(this);
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Arquivo gerado", "Arquivo foi gerado com sucesso");
				messa.Show();
			}
			catch(Exception f)
			{
				System.IO.File.WriteAllText(Directory.GetCurrentDirectory() + @"\Debug.txt", f.Message);

				MessageBox.Show($"Houve um erro em gerar o arquivo\nUm relatorio de erros foi salvo em\n{Directory.GetCurrentDirectory() + @"\Debug.txt"}");
				//messa.Show();
			}
			
		}
		private void ListBoxItem_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
		{
			
			Coberturas.SelectedItem = null;

		}
		private void RadioButton_Click(object sender, RoutedEventArgs e)
		{
			if (Coberturas_basicas.IsChecked == true)
			{
				Basicas();
			}
			if (Coberturas_adicionais.IsChecked == true)
			{
				Adicionais();
			}
			if (Coberturas_especificas.IsChecked == true)
			{
				Especificas();
			}
		}
		private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			CheckBox a234  = new CheckBox();
			/*cobertura.FlowDirection = FlowDirection.RightToLeft;
			cobertura.Content = "";
			Coberturas.Items.Add()
			*/
			
			/*try
			{
				if (((CheckBox)Coberturas.SelectedItem).IsChecked == true)
				{
					((CheckBox)Coberturas.SelectedItem).IsChecked = false;
				}
				else
				{
					((CheckBox)Coberturas.SelectedItem).IsChecked = true;
				}
			}
			catch{}
			*/
			int i = 0;
			i++;
		}

		//Clausulas Basicas
		public CheckBox B1 = new CheckBox();
		public CheckBox B2 = new CheckBox();
		public CheckBox B3 = new CheckBox();
		public CheckBox B4 = new CheckBox();
		public CheckBox B5 = new CheckBox();
		public CheckBox B6 = new CheckBox();
		public CheckBox B7 = new CheckBox();
		public CheckBox B8 = new CheckBox();
		public CheckBox B9 = new CheckBox();
		public CheckBox B10 = new CheckBox();
		public CheckBox B11 = new CheckBox();
		public CheckBox B12 = new CheckBox();
		public CheckBox B13 = new CheckBox();
		public CheckBox B14 = new CheckBox();
		public CheckBox B15 = new CheckBox();
		public CheckBox B16 = new CheckBox();
		public CheckBox B17 = new CheckBox();
		public CheckBox B18 = new CheckBox();
		public CheckBox B19 = new CheckBox();
		public CheckBox B20 = new CheckBox();
		public CheckBox B21 = new CheckBox();
		public CheckBox B22 = new CheckBox();
		public CheckBox B23 = new CheckBox();
		public CheckBox B24 = new CheckBox();
		//Clausulas Adicionais
		public CheckBox A1 = new CheckBox();
		public CheckBox A2 = new CheckBox();
		public CheckBox A3 = new CheckBox();
		public CheckBox A4 = new CheckBox();
		public CheckBox A5 = new CheckBox();
		public CheckBox A6 = new CheckBox();
		public CheckBox A7 = new CheckBox();
		public CheckBox A8 = new CheckBox();
		public CheckBox A9 = new CheckBox();
		public CheckBox A10 = new CheckBox();
		public CheckBox A11 = new CheckBox();
		public CheckBox A12 = new CheckBox();
		public CheckBox A13 = new CheckBox();
		public CheckBox A14 = new CheckBox();
		public CheckBox A15 = new CheckBox();
		//Clausulas Especificas
		public CheckBox E1 = new CheckBox();
		public CheckBox E2 = new CheckBox();
		public CheckBox E3 = new CheckBox();
		public CheckBox E4 = new CheckBox();
		public CheckBox E5 = new CheckBox();
		public CheckBox E6 = new CheckBox();
		public CheckBox E7 = new CheckBox();
		public CheckBox E8 = new CheckBox();
		public CheckBox E9 = new CheckBox();
		public CheckBox E10 = new CheckBox();
		public CheckBox E11 = new CheckBox();
		public CheckBox E12 = new CheckBox();
		public CheckBox E13 = new CheckBox();
		public CheckBox E14 = new CheckBox();

		private void Test(object sender, RoutedEventArgs e)
		{
			MessageBox.Show(Gerar_Nacional.Coberturas());
		}

		long total = DateTime.Now.Ticks;
		private void DDR(object sender, RoutedEventArgs e)
		{
			if (DateTime.Now.Ticks - total < 10) return;
			if (((CheckBox)sender).Content.ToString() == "DDR")
			{
				if (Chk_DDR.IsChecked == true)
				{
					E14.IsChecked = true;
				}
				else
				{
					E14.IsChecked = false;
				}
			}
			else
			{
				if (E14.IsChecked == true)
				{
					Chk_DDR.IsChecked = true;
				}
				else
				{
					Chk_DDR.IsChecked = false;
				}
			}
			
		}

		private void Averbavel_Checked(object sender, RoutedEventArgs e)
		{
			if (Averbavel.IsChecked == true)
			{
				Ajustavel.IsChecked = false;
				LAB_Premio_Minimo.Visibility = Visibility.Visible;
				Premio_Minimo.Visibility = Visibility.Visible;

				LAB_Ajustavel_Premio_MInimo.Visibility = Visibility.Hidden;
				LAB_Quantidade_De_Parcelas.Visibility = Visibility.Hidden;
				Ajustavel_Quantidade_Parcela.Visibility = Visibility.Hidden;
				_80.Visibility = Visibility.Hidden;
				_90.Visibility = Visibility.Hidden;
				_100.Visibility = Visibility.Hidden;

			}
			else
			{
				Ajustavel.IsChecked = true;
				LAB_Premio_Minimo.Visibility = Visibility.Hidden;
				Premio_Minimo.Visibility = Visibility.Hidden;

				LAB_Ajustavel_Premio_MInimo.Visibility = Visibility.Visible;
				LAB_Quantidade_De_Parcelas.Visibility = Visibility.Visible;
				Ajustavel_Quantidade_Parcela.Visibility = Visibility.Visible;
				_80.Visibility = Visibility.Visible;
				_90.Visibility = Visibility.Visible;
				_100.Visibility = Visibility.Visible;
			}
		}

		private void Ajustavel_Checked(object sender, RoutedEventArgs e)
		{
			if (Ajustavel.IsChecked == false)
			{
				Averbavel.IsChecked = true;
				LAB_Premio_Minimo.Visibility = Visibility.Visible;
				Premio_Minimo.Visibility = Visibility.Visible;

				LAB_Quantidade_De_Parcelas.Visibility = Visibility.Hidden;
				Ajustavel_Quantidade_Parcela.Visibility = Visibility.Hidden;
				LAB_Ajustavel_Premio_MInimo.Visibility = Visibility.Hidden;
				_80.Visibility = Visibility.Hidden;
				_90.Visibility = Visibility.Hidden;
				_100.Visibility = Visibility.Hidden;

			}
			else
			{
				Averbavel.IsChecked = false;
				LAB_Premio_Minimo.Visibility = Visibility.Hidden;
				Premio_Minimo.Visibility = Visibility.Hidden;

				LAB_Ajustavel_Premio_MInimo.Visibility = Visibility.Visible;
				LAB_Quantidade_De_Parcelas.Visibility = Visibility.Visible;
				Ajustavel_Quantidade_Parcela.Visibility = Visibility.Visible;
				_80.Visibility = Visibility.Visible;
				_90.Visibility = Visibility.Visible;
				_100.Visibility = Visibility.Visible;
			}
		}

		private void CHK_Fixa_Checked(object sender, RoutedEventArgs e)
		{
			if (CHK_Fixa.IsChecked == true)
			{
				Escalonda.IsChecked = false;
				LAB_Percentual.Visibility = Visibility.Visible;
				LAB_Valor.Visibility = Visibility.Visible;
				Fixa_Percentual.Visibility = Visibility.Visible;
				Fixa_Valor.Visibility = Visibility.Visible;

				POS1.Visibility = Visibility.Hidden;
				POS2.Visibility = Visibility.Hidden;
				POS3.Visibility = Visibility.Hidden;
			}
			else
			{
				Escalonda.IsChecked = true;
				LAB_Percentual.Visibility = Visibility.Hidden;
				LAB_Valor.Visibility = Visibility.Hidden;
				Fixa_Percentual.Visibility = Visibility.Hidden;
				Fixa_Valor.Visibility = Visibility.Hidden;

				POS1.Visibility = Visibility.Visible;
				POS2.Visibility = Visibility.Visible;
				POS3.Visibility = Visibility.Visible;
			}
			
			
		}

		private void Escalonda_Checked(object sender, RoutedEventArgs e)
		{
			if (Escalonda.IsChecked == false)
			{
				CHK_Fixa.IsChecked = true;
				LAB_Percentual.Visibility = Visibility.Visible;
				LAB_Valor.Visibility = Visibility.Visible;
				Fixa_Percentual.Visibility = Visibility.Visible;
				Fixa_Valor.Visibility = Visibility.Visible;
				
				POS1.Visibility = Visibility.Hidden;
				POS2.Visibility = Visibility.Hidden;
				POS3.Visibility = Visibility.Hidden;
			}
			else
			{
				CHK_Fixa.IsChecked = false;
				LAB_Percentual.Visibility = Visibility.Hidden;
				LAB_Valor.Visibility = Visibility.Hidden;
				Fixa_Percentual.Visibility = Visibility.Hidden;
				Fixa_Valor.Visibility = Visibility.Hidden;

				POS1.Visibility = Visibility.Visible;
				POS2.Visibility = Visibility.Visible;
				POS3.Visibility = Visibility.Visible;
			}
		}

		private void Com_Sublimite_Checked(object sender, RoutedEventArgs e)
		{

			if (Com_Sublimite.IsChecked == true)
			{
				LAB_SubLimite.Visibility = Visibility.Visible;
				Sub_Limite.Visibility = Visibility.Visible;
			}
			else
			{
				LAB_SubLimite.Visibility = Visibility.Hidden;
				Sub_Limite.Visibility = Visibility.Hidden;
			}
		}
		void LoopVisualTree(DependencyObject obj)
		{
			for (int i = 0; i < VisualTreeHelper.GetChildrenCount(obj); i++)
			{
				if (obj is TextBox)
					((TextBox)obj).Text = string.Empty;
				if (obj is CheckBox)
					((CheckBox)obj).IsChecked = false;
				LoopVisualTree(VisualTreeHelper.GetChild(obj, i));
			}

		}
		private void Window_Drop(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileName"))
			{
				string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
				try
				{
					LoopVisualTree(this);
					Excel.Abrir(fileName[0]);
				}
				catch(Exception f)
				{
					MessageBox.Show($"Houve um erro na hora de importar o arquivo Excel\n{f}");
				}
			}
		}
		private void Limpar_Click(object sender, RoutedEventArgs e)
		{
			LoopVisualTree(this);
		}
		private void AbrirRecusar(object sender, RoutedEventArgs e)
		{
			Transportador.RecusarJanela x = new Transportador.RecusarJanela(this);
			x.Show();
		}
	}
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using Microsoft.Win32;
//using OfficeOpenXml;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using DocumentFormat.OpenXml.InkML;

namespace Cotador
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	partial class MainWindow : Window
	{
		public string path;
		public bool ponto_virgula;
		public string[,] valores = new string[27,27] { { "0.04", "0.30" , "0.26" , "0.09" , "0.30" , "0.28" , "0.18" , "0.26" , "0.18" , "0.28" , "0.12" , "0.16" , "0.22" , "0.24" , "0.30" , "0.24" , "0.30" , "0.26" , "0.26" , "0.30" , "0.28" , "0.05" , "0.14" , "0.26" , "0.24" , "0.30" , "0.23" } ,{ "0.30" , "0.04" , "0.16" , "0.30" , "0.06" , "0.07" , "0.14" , "0.11" , "0.14" , "0.10" , "0.20" , "0.22" , "0.11" , "0.14" , "0.05" , "0.18" , "0.05" , "0.08" , "0.14" , "0.05" , "0.22" , "0.26" , "0.32" , "0.20" , "0.16" , "0.05" , "0.12" } ,{ "0.26" , "0.16" , "0.08" , "0.26" , "0.16" , "0.11" , "0.14" , "0.22" , "0.14" , "0.09" , "0.20" , "0.26" , "0.20" , "0.09" , "0.16" , "0.22" , "0.16" , "0.09" , "0.22" , "0.16" , "0.28" , "0.22" , "0.30" , "0.24" , "0.20" , "0.16" , "0.13" } ,{ "0.09" , "0.30" , "0.26" , "0.08" , "0.30" , "0.28" , "0.20" , "0.28" , "0.20" , "0.28" , "0.18" , "0.20" , "0.24" , "0.24" , "0.30" , "0.26" , "0.30" , "0.24" , "0.28" , "0.30" , "0.30" , "0.09" , "0.09" , "0.28" , "0.26" , "0.32" , "0.20" } ,{ "0.30" , "0.06" , "0.16" , "0.30" , "0.05" , "0.08" , "0.14" , "0.08" , "0.14" , "0.10" , "0.16" , "0.18" , "0.09" , "0.12" , "0.07" , "0.14" , "0.06" , "0.08" , "0.10" , "0.08" , "0.18" , "0.26" , "0.32" , "0.16" , "0.12" , "0.06" , "0.11" } ,{ "0.28" , "0.07" , "0.11" , "0.28" , "0.08" , "0.04" , "0.18" , "0.14" , "0.18" , "0.07" , "0.24" , "0.24" , "0.16" , "0.10" , "0.05" , "0.22" , "0.06" , "0.07" , "0.18" , "0.05" , "0.26" , "0.26" , "0.32" , "0.24" , "0.20" , "0.08" , "0.13" } ,{ "0.18" , "0.14" , "0.14" , "0.20" , "0.14" , "0.18" , "0.03" , "0.09" , "0.05" , "0.16" , "0.07" , "0.08" , "0.06" , "0.12" , "0.16" , "0.09" , "0.16" , "0.18" , "0.09" , "0.18" , "0.11" , "0.14" , "0.26" , "0.09" , "0.06" , "0.12" , "0.07" } ,{ "0.26" , "0.11" , "0.22" , "0.28" , "0.08" , "0.14" , "0.09" , "0.03" , "0.09" , "0.16" , "0.14" , "0.12" , "0.05" , "0.20" , "0.12" , "0.09" , "0.12" , "0.14" , "0.04" , "0.14" , "0.12" , "0.22" , "0.32" , "0.10" , "0.07" , "0.09" , "0.14" } ,{ "0.18" , "0.14" , "0.14" , "0.20" , "0.14" , "0.18" , "0.05" , "0.09" , "0.05" , "0.16" , "0.07" , "0.08" , "0.06" , "0.12" , "0.16" , "0.09" , "0.16" , "0.18" , "0.09" , "0.18" , "0.11" , "0.14" , "0.26" , "0.09" , "0.06" , "0.12" , "0.08" } ,{ "0.28" , "0.10" , "0.09" , "0.28" , "0.10" , "0.07" , "0.16" , "0.16" , "0.16" , "0.06" , "0.20" , "0.24" , "0.16" , "0.09" , "0.11" , "0.24" , "0.10" , "0.07" , "0.20" , "0.10" , "0.28" , "0.24" , "0.32" , "0.26" , "0.20" , "0.11" , "0.11" } ,{ "0.12" , "0.20" , "0.20" , "0.18" , "0.16" , "0.24" , "0.07" , "0.14" , "0.07" , "0.20" , "0.06" , "0.07" , "0.10" , "0.14" , "0.22" , "0.11" , "0.22" , "0.18" , "0.14" , "0.24" , "0.16" , "0.09" , "0.24" , "0.12" , "0.11" , "0.18" , "0.10" } ,{ "0.16" , "0.22" , "0.26" , "0.20" , "0.18" , "0.24" , "0.08" , "0.12" , "0.08" , "0.24" , "0.07" , "0.05" , "0.09" , "0.18" , "0.24" , "0.07" , "0.24" , "0.20" , "0.09" , "0.26" , "0.11" , "0.14" , "0.26" , "0.09" , "0.07" , "0.20" , "0.14" } ,{ "0.22" , "0.11" , "0.20" , "0.24" , "0.09" , "0.16" , "0.06" , "0.05" , "0.06" , "0.16" , "0.10" , "0.09" , "0.04" , "0.18" , "0.14" , "0.07" , "0.14" , "0.14" , "0.05" , "0.14" , "0.10" , "0.20" , "0.30" , "0.08" , "0.05" , "0.10" , "0.13" } ,{ "0.24" , "0.14" , "0.09" , "0.24" , "0.12" , "0.10" , "0.12" , "0.20" , "0.12" , "0.09" , "0.14" , "0.18" , "0.18" , "0.08" , "0.14" , "0.20" , "0.12" , "0.09" , "0.20" , "0.12" , "0.26" , "0.20" , "0.28" , "0.22" , "0.18" , "0.14" , "0.12" } ,{ "0.30" , "0.05" , "0.16" , "0.30" , "0.07" , "0.05" , "0.16" , "0.12" , "0.16" , "0.11" , "0.22" , "0.24" , "0.14" , "0.14" , "0.04" , "0.20" , "0.05" , "0.08" , "0.16" , "0.05" , "0.24" , "0.28" , "0.32" , "0.22" , "0.18" , "0.05" , "0.13" } ,{ "0.24" , "0.18" , "0.22" , "0.26" , "0.14" , "0.22" , "0.09" , "0.09" , "0.09" , "0.24" , "0.11" , "0.07" , "0.07" , "0.20" , "0.20" , "0.03" , "0.20" , "0.20" , "0.06" , "0.22" , "0.06" , "0.20" , "0.30" , "0.04" , "0.04" , "0.16" , "0.18" } ,{ "0.30" , "0.05" , "0.16" , "0.30" , "0.06" , "0.06" , "0.16" , "0.12" , "0.16" , "0.10" , "0.22" , "0.24" , "0.14" , "0.12" , "0.05" , "0.20" , "0.04" , "0.08" , "0.16" , "0.05" , "0.24" , "0.26" , "0.32" , "0.24" , "0.16" , "0.05" , "0.12" } ,{ "0.26" , "0.08" , "0.09" , "0.24" , "0.08" , "0.07" , "0.18" , "0.14" , "0.18" , "0.07" , "0.18" , "0.20" , "0.14" , "0.09" , "0.08" , "0.20" , "0.08" , "0.06" , "0.16" , "0.08" , "0.24" , "0.22" , "0.30" , "0.22" , "0.18" , "0.09" , "0.10" } ,{ "0.26" , "0.14" , "0.22" , "0.28" , "0.10" , "0.18" , "0.09" , "0.04" , "0.09" , "0.20" , "0.14" , "0.09" , "0.05" , "0.20" , "0.16" , "0.06" , "0.16" , "0.16" , "0.02" , "0.18" , "0.10" , "0.22" , "0.32" , "0.08" , "0.04" , "0.12" , "0.14" } ,{ "0.30" , "0.05" , "0.16" , "0.30" , "0.08" , "0.05" , "0.18" , "0.14" , "0.18" , "0.10" , "0.24" , "0.26" , "0.14" , "0.12" , "0.05" , "0.22" , "0.05" , "0.08" , "0.18" , "0.04" , "0.26" , "0.28" , "0.32" , "0.24" , "0.18" , "0.06" , "0.13" } ,{ "0.28" , "0.22" , "0.28" , "0.30" , "0.18" , "0.26" , "0.11" , "0.12" , "0.11" , "0.28" , "0.16" , "0.11" , "0.10" , "0.26" , "0.24" , "0.06" , "0.24" , "0.24" , "0.10" , "0.26" , "0.03" , "0.24" , "0.32" , "0.04" , "0.07" , "0.20" , "0.20" } ,{ "0.05" , "0.26" , "0.22" , "0.09" , "0.26" , "0.26" , "0.14" , "0.22" , "0.14" , "0.24" , "0.09" , "0.14" , "0.20" , "0.20" , "0.28" , "0.20" , "0.26" , "0.22" , "0.22" , "0.28" , "0.24" , "0.04" , "0.10" , "0.22" , "0.20" , "0.28" , "0.20" } ,{ "0.14" , "0.32" , "0.30" , "0.09" , "0.32" , "0.32" , "0.26" , "0.32" , "0.26" , "0.32" , "0.24" , "0.26" , "0.30" , "0.28" , "0.32" , "0.30" , "0.32" , "0.30" , "0.32" , "0.32" , "0.32" , "0.10" , "0.08" , "0.32" , "0.30" , "0.32" , "0.24" } ,{ "0.26" , "0.20" , "0.24" , "0.28" , "0.16" , "0.24" , "0.09" , "0.10" , "0.09" , "0.26" , "0.12" , "0.09" , "0.08" , "0.22" , "0.22" , "0.04" , "0.24" , "0.22" , "0.08" , "0.24" , "0.04" , "0.22" , "0.32" , "0.03" , "0.05" , "0.18" , "0.18" } ,{ "0.24" , "0.16" , "0.20" , "0.26" , "0.12" , "0.20" , "0.06" , "0.07" , "0.06" , "0.20" , "0.11" , "0.07" , "0.05" , "0.18" , "0.18" , "0.04" , "0.16" , "0.18" , "0.04" , "0.18" , "0.07" , "0.20" , "0.30" , "0.05" , "0.02" , "0.14" , "0.14" } ,{ "0.30" , "0.05" , "0.16" , "0.32" , "0.06" , "0.08" , "0.12" , "0.09" , "0.12" , "0.11" , "0.18" , "0.20" , "0.10" , "0.14" , "0.05" , "0.16" , "0.05" , "0.09" , "0.12" , "0.06" , "0.20" , "0.28" , "0.32" , "0.18" , "0.14" , "0.04" , "0.11" } ,{ "0.23" , "0.12" , "0.13" , "0.20" , "0.11" , "0.13" , "0.07" , "0.14" , "0.08" , "0.11" , "0.10" , "0.14" , "0.13" , "0.12" , "0.13" , "0.18" , "0.12" , "0.10" , "0.14" , "0.13" , "0.20" , "0.20" , "0.24" , "0.18" , "0.14" , "0.11" , "0.06" } };
		public string[] lista = new string[] { "AC", "AL", "AP", "AM", "BA", "CE", "DF", "ES", "GO", "MA", "MT", "MS", "MG", "PA", "PB", "PR", "PE", "PI", "RJ", "RN", "RS", "RO", "RR", "SC", "SP", "SE", "TO" };
		public MainWindow()
		{
			//MessageBox.Show(Properties.Settings.Default.Senha);
			
			InitializeComponent();
			this.Gerar.IsEnabled = true;
			Desaparecer();
		}
		protected override void OnClosed(EventArgs e)
		{
			base.OnClosed(e);

			Application.Current.Shutdown();
		}
		private void RelacaoArquivos_Drop(Object sender , DragEventArgs e)
		{
			if (e.Data.GetDataPresent("FileName"))
			{
				string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
				try
				{
					Desaparecer();
					LoopVisualTree(this);
					AbrirExcel.Abrir(fileName[0]);
				}
				catch (Exception f)
				{
					MessageBox.Show($"Houve um erro na hora de importar o arquivo Excel\n{f}");
				}
			}
		}
		private void Avaria_Unchecked(object sender, RoutedEventArgs e)
		{
			this.LAB_Avaraia_LMG.Visibility = Visibility.Hidden;
			this.LAB_Franquia.Visibility = Visibility.Hidden;
			this.LAB_FranquiaRS.Visibility = Visibility.Hidden;
			this.LAB_Taxa.Visibility = Visibility.Hidden;
			this.Avaria_LMG.Visibility = Visibility.Hidden;
			this.Avaria_Fraquia.Visibility = Visibility.Hidden;
			this.Avaria_franquia_RS.Visibility = Visibility.Hidden;
			this.Avaria_Taxa.Visibility = Visibility.Hidden;
		}

		private void Avaria_Checked(object sender, RoutedEventArgs e)
		{
			this.LAB_Avaraia_LMG.Visibility = Visibility.Visible;
			this.LAB_Franquia.Visibility = Visibility.Visible;
			this.LAB_FranquiaRS.Visibility = Visibility.Visible;
			this.LAB_Taxa.Visibility = Visibility.Visible;
			this.Avaria_LMG.Visibility = Visibility.Visible;
			this.Avaria_Fraquia.Visibility = Visibility.Visible;
			this.Avaria_franquia_RS.Visibility = Visibility.Visible;
			this.Avaria_Taxa.Visibility = Visibility.Visible;

		}

		private void Limpeza_Checked(object sender, RoutedEventArgs e)
		{
			
			this.LAB_LDP_LMG.Visibility = Visibility.Visible;
			this.Limpeza_LMG.Visibility = Visibility.Visible;
			LAB_LDP_Franquia.Visibility = Visibility.Visible;
			Limpeza_Franquia.Visibility = Visibility.Visible;
			LAB_LDP_FranquiaRS.Visibility = Visibility.Visible;
			Limpeza_FranquiaRS.Visibility = Visibility.Visible;
			LAB_LDP_Taxa.Visibility = Visibility.Visible;
			Limpeza_Taxa.Visibility = Visibility.Visible;
		}

		private void Limpeza_Unchecked(object sender, RoutedEventArgs e)
		{
			this.LAB_LDP_LMG.Visibility = Visibility.Hidden;
			this.Limpeza_LMG.Visibility = Visibility.Hidden;
			LAB_LDP_Franquia.Visibility = Visibility.Hidden;
			Limpeza_Franquia.Visibility = Visibility.Hidden;
			LAB_LDP_FranquiaRS.Visibility = Visibility.Hidden;
			Limpeza_FranquiaRS.Visibility = Visibility.Hidden;
			LAB_LDP_Taxa.Visibility = Visibility.Hidden;
			Limpeza_Taxa.Visibility = Visibility.Hidden;

		}

		private void Roubo_Unchecked(object sender, RoutedEventArgs e)
		{
			this.LAB_Taxa_Roubo.Visibility = Visibility.Hidden;
			//this.LAB_TAQ_RCF_DC.Visibility = Visibility.Hidden;
			//this.TAQ_RCF_DC.Visibility = Visibility.Hidden;
			this.Taxa_Roubo.Visibility = Visibility.Hidden;
			this.Taxa_Roubo.Visibility = Visibility.Hidden;
			this.LAB_LMG_POS.Visibility = Visibility.Hidden;
			this.POS_1.Visibility = Visibility.Hidden;
			this.POS_2.Visibility = Visibility.Hidden;
			this.POS_3.Visibility = Visibility.Hidden;
			LAB_N_RCF_DC.Visibility = Visibility.Hidden;
			RCFDC.Visibility = Visibility.Hidden;
		}
		
		private void Roubo_Checked(object sender, RoutedEventArgs e)
		{
			this.LAB_Taxa_Roubo.Visibility = Visibility.Visible;
			//this.LAB_TAQ_RCF_DC.Visibility = Visibility.Visible;
			//this.TAQ_RCF_DC.Visibility = Visibility.Visible;
			this.Taxa_Roubo.Visibility = Visibility.Visible;
			this.Taxa_Roubo.Visibility = Visibility.Visible;
			/*this.LAB_LMG_POS.Visibility = Visibility.Visible;
			this.POS_1.Visibility = Visibility.Visible;
			this.POS_2.Visibility = Visibility.Visible;
			this.POS_3.Visibility = Visibility.Visible;*/
			RCFDC.Visibility = Visibility.Visible;
			LAB_N_RCF_DC.Visibility = Visibility.Visible;
		}
		private void check_Click(object sender, RoutedEventArgs e)
		{
		}

		private void Limpar_Click(object sender, RoutedEventArgs e)
		{
			LoopVisualTree(this);
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

		private void Gerar_Click(object sender, RoutedEventArgs e)
		{
			//consertar_numeros c = new consertar_numeros();
			//MessageBox.Show(c.C(Sinistros.Text));
			try
			{
				//Core.Debug.Write("entrando em Gerar_Arquivo.gerar()");
				Gerar_Arquivo.gerar(this);
				/*Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("Arquivo gerado","Arquivo foi gerado com sucesso");
				messa.Show();*/
				
			}
			catch (Exception ex)
			{

				//System.IO.File.WriteAllText(Directory.GetCurrentDirectory()+@"\Debug.txt", ex.Message);
				MessageBox.Show($"erro {ex.Message}");
				Caixa_de_Mensagem.mensagem messa = new Caixa_de_Mensagem.mensagem("ERRO", "Houve um erro em gerar o arquivo");
				messa.Show();

			}
		}

		private void Main_Desconto_Checked(object sender, RoutedEventArgs e)
		{
			Taxa_Unica.Visibility = Visibility.Hidden;
			Desconto.Visibility = Visibility.Visible;
			Main_Taxa.IsChecked = false;
		}
	   
		private void Main_Desconto_Unchecked(object sender, RoutedEventArgs e)
		{
			Taxa_Unica.Visibility = Visibility.Visible;
			Desconto.Visibility = Visibility.Hidden;
			Main_Desconto.IsChecked = false;
			Main_Taxa.IsChecked = true;

		}
		private void Main_Taxa_Unchecked(object sender, RoutedEventArgs e)
		{
			Taxa_Unica.Visibility = Visibility.Hidden;
			Desconto.Visibility = Visibility.Visible;
			Main_Desconto.IsChecked = true;
			Main_Taxa.IsChecked = false;
		}

		private void Main_Taxa_Checked(object sender, RoutedEventArgs e)
		{
			Taxa_Unica.Visibility = Visibility.Visible;
			Desconto.Visibility = Visibility.Hidden;
			Main_Desconto.IsChecked = false;
		}
		private void Desaparecer()
		{
			// Taxas | desconto
			Taxa_Unica.Visibility = Visibility.Hidden;
			Desconto.Visibility = Visibility.Hidden;
			
			// Avaria
			this.LAB_Avaraia_LMG.Visibility = Visibility.Hidden;
			this.LAB_Franquia.Visibility = Visibility.Hidden;
			this.LAB_FranquiaRS.Visibility = Visibility.Hidden;
			this.LAB_Taxa.Visibility = Visibility.Hidden;
			this.Avaria_LMG.Visibility = Visibility.Hidden;
			this.Avaria_Fraquia.Visibility = Visibility.Hidden;
			this.Avaria_franquia_RS.Visibility = Visibility.Hidden;
			this.Avaria_Taxa.Visibility = Visibility.Hidden;
			this.Avaria_franquia_RS.Visibility = Visibility.Hidden;
			// Roubo
			this.LAB_Taxa_Roubo.Visibility = Visibility.Hidden;
			this.Taxa_Roubo.Visibility = Visibility.Hidden;
			this.Taxa_Roubo.Visibility = Visibility.Hidden;
			this.LAB_LMG_POS.Visibility = Visibility.Hidden;
			this.POS_1.Visibility = Visibility.Hidden;
			this.POS_2.Visibility = Visibility.Hidden;
			this.POS_3.Visibility = Visibility.Hidden;
			RCFDC.Visibility = Visibility.Hidden;
			LAB_N_RCF_DC.Visibility = Visibility.Hidden;
			// Limpeza de Pista
			LAB_LDP_LMG.Visibility = Visibility.Hidden;
			Limpeza_LMG.Visibility = Visibility.Hidden;
			LAB_LDP_Franquia.Visibility = Visibility.Hidden;
			Limpeza_Franquia.Visibility = Visibility.Hidden;
			LAB_LDP_FranquiaRS.Visibility = Visibility.Hidden;
			Limpeza_FranquiaRS.Visibility = Visibility.Hidden;
			LAB_LDP_Taxa.Visibility = Visibility.Hidden;
			Limpeza_Taxa.Visibility = Visibility.Hidden;
			// Container
			LAB_Container_LMG.Visibility = Visibility.Hidden;
			Lmg_Container.Visibility = Visibility.Hidden;
		}
		
		private void Ativar_Adicionais_Checked(object sender, RoutedEventArgs e)
		{
			/*BackgroundWorker worker = new BackgroundWorker();
			
			//dispathcer.Invoke(new Action(() => {while ((int)Adicionais_Group.Height < 597){Adicionais_Group.Height = Adicionais_Group.Height + 1;System.Threading.Thread.Sleep(250);}}));
			Adicionais_Group.Dispatcher.Invoke(new Action(() => { 
				while ((int)Adicionais_Group.Height < 597) { Adicionais_Group.Height = Adicionais_Group.Height + 2; System.Threading.Thread.Sleep(2); } }));
			worker.DoWork += delegate (object s, DoWorkEventArgs args)
			{
				MainWindow main = (MainWindow)args.Argument;
				int normal = 597;
				while ((int)main.Adicionais_Group.Height < normal)
				{
					main.Adicionais_Group.Height = Adicionais_Group.Height + 1;
					System.Threading.Thread.Sleep(250);
				}
			};
			//worker.RunWorkerAsync(this);
			*/
		}

		private void Chk_Container_Checked(object sender, RoutedEventArgs e)
		{
			LAB_Container_LMG.Visibility = Visibility.Visible;
			Lmg_Container.Visibility = Visibility.Visible;
		}
		private void Chk_Container_Unchecked(object sender, RoutedEventArgs e)
		{
			LAB_Container_LMG.Visibility = Visibility.Hidden;
			Lmg_Container.Visibility = Visibility.Hidden;
		}

		private void AbrirAdicionar(object sender, RoutedEventArgs e)
		{
			/*Controle_de_Cotacao con = new Controle_de_Cotacao();
			con.Show();*/
		}

		private void Web_Checked(object sender, RoutedEventArgs e)
		{
			LAB_N_RCTR_C.Visibility = Visibility.Visible;
			RCFDC.Visibility = Visibility.Visible;
			RCTRC.Visibility = Visibility.Visible;
		}

		private void Web_Unchecked(object sender, RoutedEventArgs e)
		{
			LAB_N_RCTR_C.Visibility = Visibility.Hidden;
			RCFDC.Visibility = Visibility.Hidden;
			RCTRC.Visibility = Visibility.Hidden;
		}
		string copy = string.Empty;
		private void taxa_Click(object sender, RoutedEventArgs e)
		{
			string clip = Clipboard.GetText();
			char[] crlf = new char[] { (char)10,(char)13 };
			string saida = "";
			foreach(string valor in clip.Split((char)10)){
				if (valor.Length == 0) continue;
				string[] inicio_destino;
				string novo = valor.Replace("\r",string.Empty);
				inicio_destino = novo.Split('\t');
				int de   = -1;
				int para = -1;
				try
				{
					de = Array.IndexOf(lista, inicio_destino[0].ToUpper());
					para = Array.IndexOf(lista, inicio_destino[1].ToUpper());
				}
				catch{}
				if (de == -1 || para == -1)
				{
					saida += "\r\n";
					continue;
				}
				saida += valores[de, para].Replace('.',',') + "00%";
				saida += "\r\n";

			}
			//Clipboard.SetData(DataFormats.Text, saida);
			copy = saida;
			while (Clipboard.GetText().Contains(saida) == false)
			{
				Clipboard.Clear();
				Clipboard.SetText(saida);
				Clipboard.Flush();
			}
			
			
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			while (Clipboard.GetText().Contains(copy) == false)
			{
				Clipboard.Clear();
				Clipboard.SetText(copy);
				Clipboard.Flush();
			}
		}

		private void Border_MouseDown(object sender, MouseButtonEventArgs e)
		{

		}
	}
}

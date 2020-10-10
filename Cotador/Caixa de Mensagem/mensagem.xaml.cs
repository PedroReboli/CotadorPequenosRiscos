using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cotador.Caixa_de_Mensagem
{
    /// <summary>
    /// Interaction logic for mensagem.xaml
    /// </summary>
    public partial class mensagem : Window
    {
        
        public mensagem(string value,string men)
        {
            InitializeComponent();
            titulo.Content = value;
            mem.Content = men;
			/*var x = mem.Height;
			mem.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
			this.Width = mem.DesiredSize.Width;
			x = mem.ActualHeight;*/
        }
		private void Window_ContentRendered(object sender, EventArgs e)
		{
			BackgroundWorker worker = new BackgroundWorker();
			worker.WorkerReportsProgress = true;
			worker.DoWork += worker_DoWork;
			worker.ProgressChanged += worker_ProgressChanged;
			cima.Width = this.Width;
			mem.Width = this.Width;
			worker.RunWorkerCompleted += fechar;
			worker.RunWorkerAsync();
			//await worker_DoWork();
		}

		async void worker_DoWork(object sender, DoWorkEventArgs e)
		{
			for (int i = 0; i < 1000; i++)
			{
				(sender as BackgroundWorker).ReportProgress(i);
				Thread.Sleep(2);
			}
			//this.Close();
			
		}
		void fechar(object sender, RunWorkerCompletedEventArgs e)
        {
			this.Close();
		}
		void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
		{
			Progress.Value = e.ProgressPercentage;
		}
		private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
			this.Close();
        }
    }
}

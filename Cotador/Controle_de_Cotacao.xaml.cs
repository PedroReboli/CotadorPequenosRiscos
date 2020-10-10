using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Cotador
{
    /// <summary>
    /// Interaction logic for Controle_de_Cotacao.xaml
    /// </summary>
    public partial class Controle_de_Cotacao : Window
    {
        string PathControle_Cotacao;
        public Controle_de_Cotacao()
        {
            InitializeComponent();
            PathControle_Cotacao = Properties.Settings.Default.Controle_Cotacao;
            if (PathControle_Cotacao != string.Empty) {
                Calculo.Text = PathControle_Cotacao;
                ControleA_drop.Background = new System.Windows.Media.SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
            }
            else
            {
                ControleA_drop.Background = new System.Windows.Media.SolidColorBrush(Color.FromArgb(127, 255,0, 0));
            }
            
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Adicionar_Cotacao.Abrir_e_Adicionar.Adicionar(Memoria.Text, Calculo.Text);
            Caixa_de_Mensagem.mensagem caixa = new Caixa_de_Mensagem.mensagem("Adicionado", "Calculo foi adicionado na area de copia");
            caixa.Show();
        }

        private void TextBox_Drop(object sender, DragEventArgs e)
        {
            
            if (e.Data.GetDataPresent("FileName"))
            {
                string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
                Memoria.Text = fileName[0];
                Memoria_drop.Background = new System.Windows.Media.SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
            }
            
        }
        private void TextBox_Drop_1(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileName"))
            {
                string[] fileName = (string[])e.Data.GetData(DataFormats.FileDrop);
                Properties.Settings.Default.Controle_Cotacao = fileName[0];
                Properties.Settings.Default.Save();
                Calculo.Text = fileName[0];
                ControleA_drop.Background = new System.Windows.Media.SolidColorBrush(Color.FromArgb(127, 0, 255, 0));
            }
        }


        private void Data_Inicial_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            Data_Final.SelectedDate = Data_Inicial.SelectedDate.Value.AddYears(1);
            //Data_Final.SelectedDate;
        }
    }
}

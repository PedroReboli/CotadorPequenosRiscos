using System;
using System.Collections.Generic;
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
using static Cotador.Core.Constants;
namespace Cotador.Transportador
{
	/// <summary>
	/// Interaction logic for RecusarJanela.xaml
	/// </summary>
	public partial class RecusarJanela : Window
	{
		MainWindow Main;
		Nacional.Nacional nacional;
		Internacional.janela_Internacional Inter;
		int I = 0;
		public RecusarJanela(MainWindow main)
		{
			Main = main;
			InitializeComponent();
			I = 1;
		}
		public RecusarJanela(Nacional.Nacional main)
		{
			nacional = main;
			InitializeComponent();
			I = 2;
		}
		public RecusarJanela(Internacional.janela_Internacional main)
		{
			Inter = main;
			InitializeComponent();
			I = 3;
		}
		void EnviarRecusa(object sender, RoutedEventArgs e)
		{
			Core.Net Socket = new Core.Net();
			if (!Socket.Connect(ServerIP, ServerPort))
			{
				System.Windows.MessageBox.Show("Erro ao se conectar ao servidor");
				return;
			}
			Socket.Send("2ddb03e4e01ea00e3f0c49a5a880985d314c631acba420db3bea8cc91a27083ffd6e2b9e289bb3e862b29a6953ca60febffef816cbc1b8f5cbe7141041c53284");
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Houve um erro ao mandar comando para o servidor");
			}
			Socket.Send((byte)00); // Diz que o modo é cotaçao
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação nao disponivel");
			}
			if (I == 1)
			{
				Transportador(Socket);
			}else if (I == 2)
			{
				Nacional(Socket);
			}
			else if (I == 3)
			{
				Internacional(Socket);
			}
		}
		void Transportador(Core.Net Socket)
		{
			Socket.Send((byte)00); // Diz que o tipo da cotaçao é transportador
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação trasportador nao disponivel");
			}
			if (Main.Chk_Roubo.IsChecked.Value == true)
				Socket.Send((byte)91);
			else
				Socket.Send((byte)90);
			Socket.Send(Main.Segurado.Text);
			Socket.Send(Main.CNPJ.Text);
			Socket.Send(Main.Corretor.Text);
			Socket.Send(Main.Sinistros.Text);
			Socket.Send(Main.Desconto.Text);
			Socket.Send(Main.Taxa_Unica.Text);
			Socket.Send(Main.Premio_Minimo.Text);
			Socket.Send(Main.Avaria_LMG.Text);
			Socket.Send(Main.Avaria_Fraquia.Text);
			Socket.Send(Main.Avaria_franquia_RS.Text);
			Socket.Send(Main.Avaria_Taxa.Text);
			Socket.Send(Main.Limpeza_LMG.Text);
			Socket.Send(Main.Limpeza_Franquia.Text);
			Socket.Send(Main.Limpeza_FranquiaRS.Text);
			Socket.Send(Main.Limpeza_Taxa.Text);
			Socket.Send(Main.Taxa_Roubo.Text);
			Socket.Send(Main.POS_1.Text);
			Socket.Send(Main.POS_2.Text);
			Socket.Send(Main.POS_3.Text);
			Socket.Send(Main.Lmg_Container.Text);
			Socket.Send(Main.RCTRC.Text);
			Socket.Send(Main.LMG.Text);
			Socket.Send((byte)0);
			Socket.Send(Main.RCFDC.Text);
			Socket.Send(Main.Expectativa_Fechamento.Text);
			Socket.Send(Main.Premio_Anual.Text);
			Socket.Send(Main.Assessoria.Text);
			Socket.Send(Motivo.Text);
		}

		void Nacional(Core.Net Socket)
		{
			UInt16 Bits = 0; 
			Socket.Send((byte)01); // Diz que o tipo da cotaçao é Nacional
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação Nacional nao disponivel");
			}
			Bits += 1 << 9;
			if (nacional.Averbavel.IsChecked == true)
				Bits += 1 << 0;
			Socket.Send(BitConverter.GetBytes(Bits));
			Socket.Send(nacional.Segurado.Text);
			Socket.Send(nacional.Ncotacao.Text);
			Socket.Send(nacional.CNPJ.Text);
			Socket.Send(nacional.Corretor.Text);
			Socket.Send(nacional.LMG.Text);
			Socket.Send(nacional.Taxa.Text);
			Socket.Send(nacional.Importancia_Segurada.Text);
			Socket.Send(nacional.Sinistros.Text);
			Socket.Send(nacional.Premio_Minimo.Text);
			Socket.Send(nacional.Ajustavel_Quantidade_Parcela.Text);
			Socket.Send(nacional.Fixa_Percentual.Text);
			Socket.Send(nacional.Fixa_Valor.Text);
			Socket.Send(nacional.POS1.Text);
			Socket.Send(nacional.POS2.Text);
			Socket.Send(nacional.POS3.Text);
			Socket.Send(nacional.Sub_Limite.Text);
			Socket.Send("Nada");
			Socket.Send(nacional.Mercadoria.Text);
			Socket.Send(nacional.Expectativa.Text);
			Socket.Send(nacional.Assessoria.Text);
			Socket.Send(nacional.Premio_Anual.Text);
			Socket.Send(Motivo.Text);
		}
		
		void Internacional(Core.Net Socket)
		{
			UInt16 Bits = 0;
			Socket.Send((byte)02); // Diz que o tipo da cotaçao é Internacional
			if (Socket.Recv().ToString() == "Fail")
			{
				Caixa_de_Mensagem.Mensagem.Mostar("Erro", "Modo cotação Internacional nao disponivel");
			}
			if (Inter.Averbavel.IsChecked == true)
				Bits += 1 << 2;
			Bits += 1 << 10;
			Socket.Send(BitConverter.GetBytes(Bits));
			Socket.Send(Inter.Segurado.Text);
			Socket.Send(Inter.Ncotacao.Text);
			Socket.Send("");
			Socket.Send(Inter.Corretor.Text);
			Socket.Send(Inter.Assessoria.Text);
			Socket.Send("");
			Socket.Send("");
			Socket.Send("");
			Socket.Send("");
			Socket.Send("");
			Socket.Send("");
			Socket.Send("");
			Socket.Send(Inter.Premio_Anual.Text);
			Socket.Send(Inter.Expectativa.Text);
			Socket.Send("");
			Socket.Send("");
			Socket.Send("");
			Socket.Send("");
			Socket.Send(Inter.Expectativa.Text);
			Socket.Send(Motivo.Text);
		}
	}
}

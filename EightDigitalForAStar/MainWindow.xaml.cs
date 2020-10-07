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
using System.Windows.Navigation;
using System.Windows.Shapes;
using EightDigitalForAState;
using MaterialDesignThemes.Wpf;

namespace EightDigitalForAStar
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		DataHandling datahand = new DataHandling();
		public MainWindow()
		{
			InitializeComponent();
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//Wrapping.Opacity = 0.5;
			//Loading.Visibility = Visibility.Visible;
			//Search_Button.IsEnabled = false;
			datahand.Test();
			//do something for Sreach
			//Play_Button.IsEnabled = true;
		}
	}
}

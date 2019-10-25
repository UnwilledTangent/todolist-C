using System;
using System.Drawing;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace todolist
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
		}
		

		private void richTextBox1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void buttonGetText_Click(object sender, RoutedEventArgs e)
		{
			TextRange textRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
			MessageBox.Show(textRange.Text);
		}


		private void richTextBox2_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void buttonSave_Click(object sender, RoutedEventArgs e)
		{

			MessageBox.Show("Saved", "My Title");
		}

		private void richTextBox3_TextChanged(object sender, TextChangedEventArgs e)
		{

		}
	}
}

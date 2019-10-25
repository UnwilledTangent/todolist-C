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
			SaveXamlPackage("toDo.xaml");

			MessageBox.Show("Saved", "My Title");
		}

		void SaveXamlPackage(string _fileName)
		{
			TextRange range;
			FileStream fStream;
			range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
			fStream = new FileStream(_fileName, FileMode.Create);
			range.Save(fStream, DataFormats.XamlPackage);
			fStream.Close();
		}

		private void richTextBox3_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void loadButton_Click(object sender, RoutedEventArgs e)
		{
			LoadXamlPackage("toDo.xaml");
		}

		void LoadXamlPackage(string _fileName)
		{
			TextRange range;
			FileStream fStream;
			if (File.Exists(_fileName))
			{
				range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
				fStream = new FileStream(_fileName, FileMode.OpenOrCreate);
				range.Load(fStream, DataFormats.XamlPackage);
				fStream.Close();
			}
		}
	}
}

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
			saveAllXamlPackages();

			MessageBox.Show("Saved", "Status");
		}

		void saveAllXamlPackages()
		{
			SaveXamlPackage1("toDo.xaml");
			SaveXamlPackage2("doingToday.xaml");
			SaveXamlPackage3("doing.xaml");
		}

		void SaveXamlPackage1(string _fileName)
		{
			TextRange range;
			FileStream fStream;
			range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);

			fStream = new FileStream(_fileName, FileMode.Create);
			range.Save(fStream, DataFormats.XamlPackage);
			fStream.Close();
		}

		void SaveXamlPackage2(string _fileName)
		{
			TextRange range;
			FileStream fStream;
			range = new TextRange(richTextBox2.Document.ContentStart, richTextBox2.Document.ContentEnd);
			fStream = new FileStream(_fileName, FileMode.Create);
			range.Save(fStream, DataFormats.XamlPackage);
			fStream.Close();
		}

		void SaveXamlPackage3(string _fileName)
		{
			TextRange range;
			FileStream fStream;
			range = new TextRange(richTextBox3.Document.ContentStart, richTextBox3.Document.ContentEnd);
			fStream = new FileStream(_fileName, FileMode.Create);
			range.Save(fStream, DataFormats.XamlPackage);
			fStream.Close();
		}

		private void richTextBox3_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void loadButton_Click(object sender, RoutedEventArgs e)
		{
			loadAllXamlPackages();
		}

		void loadAllXamlPackages()
		{
			LoadXamlPackage1("toDo.xaml");
			LoadXamlPackage2("doingToday.xaml");
			LoadXamlPackage3("doing.xaml");
		}

		void LoadXamlPackage1(string _fileName)
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

		void LoadXamlPackage2(string _fileName)
		{
			TextRange range;
			FileStream fStream;
			if (File.Exists(_fileName))
			{
				range = new TextRange(richTextBox2.Document.ContentStart, richTextBox2.Document.ContentEnd);
				fStream = new FileStream(_fileName, FileMode.OpenOrCreate);
				range.Load(fStream, DataFormats.XamlPackage);
				fStream.Close();
			}
		}

		void LoadXamlPackage3(string _fileName)
		{
			TextRange range;
			FileStream fStream;
			if (File.Exists(_fileName))
			{
				range = new TextRange(richTextBox3.Document.ContentStart, richTextBox3.Document.ContentEnd);
				fStream = new FileStream(_fileName, FileMode.OpenOrCreate);
				range.Load(fStream, DataFormats.XamlPackage);
				fStream.Close();
			}
		}
	}
}

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
using System.Runtime.InteropServices;
using System.Diagnostics;
using Microsoft.Azure;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.File;
using Microsoft.Azure.Storage.Auth;

namespace todolist
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		// Parse the connection string, and return a reference to the storage account
		// Remember to put static
		//private static CloudStorageAccount storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("7KNDbcUhOndKDKhcLzKOP78Ris7b0e7IUgB9OWzE+u75KL91xMElSl3o0SeLczLwP+juWPGNOSvacQGbkxomRw=="));\

		// Creates storage credentials
		private static StorageCredentials storageCredentials = new StorageCredentials("firstwebappstorage", "7KNDbcUhOndKDKhcLzKOP78Ris7b0e7IUgB9OWzE+u75KL91xMElSl3o0SeLczLwP+juWPGNOSvacQGbkxomRw==");

		private static CloudStorageAccount storageAccount = new CloudStorageAccount(storageCredentials, true);

		// Create a CloudFileClient object for credentialed access to Azure Files.
		private static CloudFileClient fileClient = storageAccount.CreateCloudFileClient();

		// Get a reference to the file share we created previously.
		private static CloudFileShare share = fileClient.GetShareReference("myshare");

		// Get a reference to the root directory for the share
		private static CloudFileDirectory rootDir = share.GetRootDirectoryReference();

		// Get a reference to the directory we created previously
		private static CloudFileDirectory sampleDir = rootDir.GetDirectoryReference("CustomLogs");

		public MainWindow()
		{
			InitializeComponent();
		}
		
		private void richTextBox1_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void buttonGetText_Click(object sender, RoutedEventArgs e)
		{
			// just get the text of toDo.xaml and show in a MessageBox
			TextRange textRange = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
			MessageBox.Show(textRange.Text);
		}


		private void richTextBox2_TextChanged(object sender, TextChangedEventArgs e)
		{

		}

		private void buttonSave_Click(object sender, RoutedEventArgs e)
		{
			// check if toDo.xaml has more than 20 characters, than saveAllXamlPackages();
			TextRange range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
			int textLength = range.Text.Length;
			if (textLength < 20)
			{
				MessageBox.Show("Error: String not more than 20 characters. toDo.xaml, doingToday.xaml and doing.xaml not pushed.", "Push Status");
			}
			else
			{
				saveAllXamlPackages();
				MessageBox.Show("Pushed", "Push Status");
			}
		}

		// Push xaml files to cloud
		void saveAllXamlPackages()
		{
			SaveXamlPackage1("C:\\Test\\toDo.xaml");
			SaveXamlPackage2("C:\\Test\\doingToday.xaml");
			SaveXamlPackage3("C:\\Test\\doing.xaml");
		}

		void SaveXamlPackage1(string _fileName)
		{
			// save toDo.xaml into C:\\Test\\toDo.xaml
			TextRange range;
			FileStream fStream;
			range = new TextRange(richTextBox1.Document.ContentStart, richTextBox1.Document.ContentEnd);
			fStream = new FileStream(_fileName, FileMode.Create);
			range.Save(fStream, DataFormats.XamlPackage);
			fStream.Close();

			CloudFile file = sampleDir.GetFileReference("toDo.xaml");
			Stream fileStream = File.OpenRead(_fileName);

			// Upload file to Azure
			file.UploadFromStream(fileStream);
			fileStream.Dispose();
		}

		void SaveXamlPackage2(string _fileName)
		{
			// save doingToday.xaml into C:\\Test\\doingToday.xaml
			TextRange range;
			FileStream fStream;
			range = new TextRange(richTextBox2.Document.ContentStart, richTextBox2.Document.ContentEnd);
			fStream = new FileStream(_fileName, FileMode.Create);
			range.Save(fStream, DataFormats.XamlPackage);
			fStream.Close();

			CloudFile file = sampleDir.GetFileReference("doingToday.xaml");
			Stream fileStream = File.OpenRead(_fileName);

			// Upload file to Azure
			file.UploadFromStream(fileStream);
			fileStream.Dispose();
		}

		void SaveXamlPackage3(string _fileName)
		{
			// save doing.xaml into C:\\Test\\doing.xaml
			TextRange range;
			FileStream fStream;
			range = new TextRange(richTextBox3.Document.ContentStart, richTextBox3.Document.ContentEnd);
			fStream = new FileStream(_fileName, FileMode.Create);
			range.Save(fStream, DataFormats.XamlPackage);
			fStream.Close();

			CloudFile file = sampleDir.GetFileReference("doing.xaml");
			Stream fileStream = File.OpenRead(_fileName);

			// Upload file to Azure
			file.UploadFromStream(fileStream);
			fileStream.Dispose();
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
			LoadXamlPackage1("C:\\Test\\toDo.xaml");
			LoadXamlPackage2("C:\\Test\\doingToday.xaml");
			LoadXamlPackage3("C:\\Test\\doing.xaml");
		}

		void LoadXamlPackage1(string _fileName)
		{
			// download toDo.xaml file from Azure to C:\\Test\\toDo.xaml
			CloudFile file = sampleDir.GetFileReference("toDo.xaml");
			file.DownloadToFile(_fileName, System.IO.FileMode.OpenOrCreate);

			// load toDo.xaml file from C:\\Test\\toDo.xaml to app
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
			// download doingToday.xaml file from Azure to C:\\Test\\doingToday.xaml
			CloudFile file = sampleDir.GetFileReference("doingToday.xaml");
			file.DownloadToFile(_fileName, System.IO.FileMode.OpenOrCreate);

			// load doingToday.xaml file from C:\\Test\\toDo.xaml to app
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
			// download doing.xaml file from Azure to C:\\Test\\doing.xaml
			CloudFile file = sampleDir.GetFileReference("doing.xaml");
			file.DownloadToFile(_fileName, System.IO.FileMode.OpenOrCreate);

			// load doing.xaml file from C:\\Test\\doing.xaml to app
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

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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace frp_control.pages
{
    /// <summary>
    /// EditorPage.xaml 的交互逻辑
    /// </summary>
    public partial class EditorPage : Page
    {
        public EditorPage()
        {
            InitializeComponent();
            FrpcTomlLoad();
            FrpsTomlLoad();
            FrpcOldTomlLoad();
            FrpsOldTomlLoad();
        }

        public void FrpcTomlLoad()
        {
            string textFile = "frp/frpc.toml";

            FileStream fs;

            if (File.Exists(textFile))

            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new(FrpcTomlTextBox.Document.ContentStart, FrpcTomlTextBox.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }
            }
        }
        public void FrpcTomlSave()
        {
            string textFile = "frp/frpc.toml";

            FileStream fs;
            fs = new FileStream(textFile, FileMode.Create, FileAccess.ReadWrite);
            using (fs)
            {
                TextRange text = new(FrpcTomlTextBox.Document.ContentStart, FrpcTomlTextBox.Document.ContentEnd);
                text.Save(fs, DataFormats.Text);
            }
        }

        public void FrpsTomlLoad()
        {
            string textFile = "frp/frps.toml";

            FileStream fs;

            if (File.Exists(textFile))

            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new(FrpsTomlTextBox.Document.ContentStart, FrpsTomlTextBox.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }
            }
        }
        public void FrpsTomlSave()
        {
            string textFile = "frp/frps.toml";

            FileStream fs;
            fs = new FileStream(textFile, FileMode.Create, FileAccess.ReadWrite);
            using (fs)
            {
                TextRange text = new(FrpsTomlTextBox.Document.ContentStart, FrpsTomlTextBox.Document.ContentEnd);
                text.Save(fs, DataFormats.Text);
            }
        }

        public void FrpcOldTomlLoad()
        {
            string textFile = "frp_old/frpc.ini";

            FileStream fs;

            if (File.Exists(textFile))

            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new(FrpcOldTomlTextBox.Document.ContentStart, FrpcOldTomlTextBox.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }
            }
        }
        public void FrpcOldTomlSave()
        {
            string textFile = "frp_old/frpc.ini";

            FileStream fs;
            fs = new FileStream(textFile, FileMode.Create, FileAccess.ReadWrite);
            using (fs)
            {
                TextRange text = new(FrpcOldTomlTextBox.Document.ContentStart, FrpcOldTomlTextBox.Document.ContentEnd);
                text.Save(fs, DataFormats.Text);
            }
        }

        public void FrpsOldTomlLoad()
        {
            string textFile = "frp_old/frps.ini";

            FileStream fs;

            if (File.Exists(textFile))

            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new(FrpsOldTomlTextBox.Document.ContentStart, FrpsOldTomlTextBox.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }
            }
        }
        public void FrpsOldTomlSave()
        {
            string textFile = "frp_old/frps.ini";

            FileStream fs;
            fs = new FileStream(textFile, FileMode.Create, FileAccess.ReadWrite);
            using (fs)
            {
                TextRange text = new(FrpsOldTomlTextBox.Document.ContentStart, FrpsOldTomlTextBox.Document.ContentEnd);
                text.Save(fs, DataFormats.Text);
            }
        }

        private void FrpcTomlLoadButton2_Click(object sender, RoutedEventArgs e)
        {
            FrpcTomlLoad();
        }

        private void FrpcTomlSaveButton2_Click(object sender, RoutedEventArgs e)
        {
            FrpcTomlSave();
        }

        private void FrpsTomlLoadButton2_Click(object sender, RoutedEventArgs e)
        {
            FrpsTomlLoad();
        }

        private void FrpsTomlSaveButton2_Click(object sender, RoutedEventArgs e)
        {
            FrpsTomlSave();
        }

        private void FrpcOldTomlLoadButton2_Click(object sender, RoutedEventArgs e)
        {
            FrpcOldTomlLoad();
        }

        private void FrpcOldTomlSaveButton2_Click(object sender, RoutedEventArgs e)
        {
            FrpcOldTomlSave();
        }

        private void FrpsOldTomlLoadButton2_Click(object sender, RoutedEventArgs e)
        {
            FrpsOldTomlLoad();
        }

        private void FrpsOldTomlSaveButton2_Click(object sender, RoutedEventArgs e)
        {
            FrpsOldTomlSave();
        }


    }
}

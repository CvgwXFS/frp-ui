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
    /// SamplesPage.xaml 的交互逻辑
    /// </summary>
    public partial class SamplesPage : Page
    {
        //public string[] FrpcSampListItems;
        public SamplesPage()
        {
            InitializeComponent();

            FrpcSampleLoad();
            FrpsSampleLoad();
            FrpcOldSampleLoad();
            FrpsOldSampleLoad();

        }

        public void FrpcSampleLoad()
        {
            string textFile = "frp/frpc-sample.toml";

            FileStream fs;

            if (File.Exists(textFile))

            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new(FrpcSampleTextBox.Document.ContentStart, FrpcSampleTextBox.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }
            }
        }

        public void FrpsSampleLoad()
        {
            string textFile = "frp/frps-sample.toml";

            FileStream fs;

            if (File.Exists(textFile))

            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new(FrpsSampleTextBox.Document.ContentStart, FrpsSampleTextBox.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }
            }
        }

        public void FrpcOldSampleLoad()
        {
            string textFile = "frp_old/frpc_full.ini";

            FileStream fs;

            if (File.Exists(textFile))

            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new(FrpcOldSampleTextBox.Document.ContentStart, FrpcOldSampleTextBox.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }
            }
        }

        public void FrpsOldSampleLoad()
        {
            string textFile = "frp_old/frps_full.ini";

            FileStream fs;

            if (File.Exists(textFile))

            {
                fs = new FileStream(textFile, FileMode.Open, FileAccess.Read);
                using (fs)
                {
                    TextRange text = new(FrpsOldSampleTextBox.Document.ContentStart, FrpsOldSampleTextBox.Document.ContentEnd);
                    text.Load(fs, DataFormats.Text);
                }
            }
        }

        private void FrpcSampleLoadButton1_Click(object sender, RoutedEventArgs e)
        {
            FrpcSampleLoad();
        }
        private void FrpsSampleLoadButton1_Click(object sender, RoutedEventArgs e)
        {
            FrpsSampleLoad();
        }
        private void FrpcOldSampleLoadButton1_Click(object sender, RoutedEventArgs e)
        {
            FrpcOldSampleLoad();
        }
        private void FrpsOldSampleLoadButton1_Click(object sender, RoutedEventArgs e)
        {
            FrpsOldSampleLoad();
        }


        //新功能测试部分

    }
}

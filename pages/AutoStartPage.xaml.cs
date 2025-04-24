using System;
using System.Collections.Generic;
using System.Configuration;
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
    /// AutoStartPage.xaml 的交互逻辑
    /// </summary>
    public partial class AutoStartPage : Page
    {
        Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
        public AutoStartPage()
        {
            InitializeComponent();
        }

        private void FrpcYesButton_Click(object sender, RoutedEventArgs e)
        {
            cfg.AppSettings.Settings["frpc"].Value = "1";
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("配置已保存");
        }

        private void FrpcNoButton_Click(object sender, RoutedEventArgs e)
        {
            cfg.AppSettings.Settings["frpc"].Value = "0";
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("配置已保存");
        }

        private void FrpsYesButton_Click(object sender, RoutedEventArgs e)
        {
            cfg.AppSettings.Settings["frps"].Value = "1";
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("配置已保存");
        }

        private void FrpsNoButton_Click(object sender, RoutedEventArgs e)
        {
            cfg.AppSettings.Settings["frps"].Value = "0";
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("配置已保存");
        }

        private void FrpcOldYesButton_Click(object sender, RoutedEventArgs e)
        {
            cfg.AppSettings.Settings["frpc32"].Value = "1";
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("配置已保存");
        }

        private void FrpcOldNoButton_Click(object sender, RoutedEventArgs e)
        {
            cfg.AppSettings.Settings["frpc32"].Value = "0";
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("配置已保存");
        }

        private void FrpsOldYesButton_Click(object sender, RoutedEventArgs e)
        {
            cfg.AppSettings.Settings["frps32"].Value = "1";
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("配置已保存");
        }

        private void FrpsOldNoButton_Click(object sender, RoutedEventArgs e)
        {
            cfg.AppSettings.Settings["frps32"].Value = "0";
            cfg.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
            MessageBox.Show("配置已保存");
        }
    }
}

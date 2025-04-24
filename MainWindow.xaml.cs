using System.Configuration;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

using System.Windows.Forms;

using frp_control.Commands;
using frp_control.pages;
using System.Drawing;

using frp_control.libs;




namespace frp_control
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Commands.Command frpc = new Commands.Command();
        Commands.Command frps = new Commands.Command();
        Commands.Command frpc32 = new Commands.Command();
        Commands.Command frps32 = new Commands.Command();
        
        bool frpcautostart = false;
        bool frpsautostart = false;
        bool frpc32autostart = false;
        bool frps32autostart = false;
        int touchxfs = 0;

        System.Windows.Forms.NotifyIcon notifyIcon = new System.Windows.Forms.NotifyIcon();
        public MainWindow()
        {
            InitializeComponent();

            notifyIcon.Text = "小風神可爱捏可爱捏( ^ v ^)◞♡";
            notifyIcon.Icon = new System.Drawing.Icon("images/xfs.ico");
            notifyIcon.Visible = true;

            AutoStartSettings();
            SetDefColor();
            Home_Button.Background = new SolidColorBrush(Colors.White);

            Frpc_Prepare();
            Frps_Prepare();
            FrpcOld_Prepare();
            FrpsOld_Prepare();

            if (frpsautostart)
            {
                FrpsStartButton1.IsEnabled = false;
                ClearTextToFrpsText();
                Frps_Start();

                if (frpcautostart)
                {
                    Thread.Sleep(1000);//等Frps先启动，考虑到服务端和客户端同设备的情况
                    FrpcStartButton1.IsEnabled = false;
                    ClearTextToFrpcText();
                    Frpc_Start();
                }
            }
            else
            {
                if (frpcautostart)
                {
                    FrpcStartButton1.IsEnabled = false;
                    ClearTextToFrpcText();
                    Frpc_Start();
                }
            }

            if (frps32autostart)
            {
                FrpsOldStartButton1.IsEnabled = false;
                ClearTextToFrpsOldText();
                FrpsOld_Start();

                if (frpc32autostart)
                {
                    Thread.Sleep(1000);//等Frps先启动，考虑到服务端和客户端同设备的情况
                    FrpcOldStartButton1.IsEnabled = false;
                    ClearTextToFrpcOldText();
                    FrpcOld_Start();
                }
            }
            else
            {
                if (frpc32autostart)
                {
                    FrpcOldStartButton1.IsEnabled = false;
                    ClearTextToFrpcOldText();
                    FrpcOld_Start();
                }
            }

        }

        public void SetDefColor()
        {
            Home_Button.Background = new SolidColorBrush(Colors.WhiteSmoke);
            Editor_Button.Background = new SolidColorBrush(Colors.WhiteSmoke);
            Samples_Button.Background = new SolidColorBrush(Colors.WhiteSmoke);
            AutoStart_Button.Background = new SolidColorBrush(Colors.WhiteSmoke);
            About_Button.Background = new SolidColorBrush(Colors.WhiteSmoke);
        }

        private void ChangeToHomePage(object sender, MouseButtonEventArgs e)
        {
            this.MainFrame.Visibility = Visibility.Hidden;
            SetDefColor();
            Home_Button.Background = new SolidColorBrush(Colors.White);
        }

        private void ChangeToEditorPage(object sender, MouseButtonEventArgs e)
        {
            this.MainFrame.Source = new Uri("/pages/EditorPage.xaml", UriKind.Relative);
            this.MainFrame.Visibility = Visibility.Visible;
            SetDefColor();
            Editor_Button.Background = new SolidColorBrush(Colors.White);
        }
        private void ChangeToSamplesPage(object sender, MouseButtonEventArgs e)
        {
            this.MainFrame.Source = new Uri("/pages/SamplesPage.xaml", UriKind.Relative);
            this.MainFrame.Visibility = Visibility.Visible;
            SetDefColor();
            Samples_Button.Background = new SolidColorBrush(Colors.White);
        }
        private void ChangeToAutoStartPage(object sender, MouseButtonEventArgs e)
        {
            this.MainFrame.Source = new Uri("/pages/AutoStartPage.xaml", UriKind.Relative);
            this.MainFrame.Visibility = Visibility.Visible;
            SetDefColor();
            AutoStart_Button.Background = new SolidColorBrush(Colors.White);           
        }
        private void ChangeToAboutPage(object sender, MouseButtonEventArgs e)
        {
            this.MainFrame.Source = new Uri("/pages/AboutPage.xaml", UriKind.Relative);
            this.MainFrame.Visibility = Visibility.Visible;
            SetDefColor();
            About_Button.Background = new SolidColorBrush(Colors.White);
        }

        private void close(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.MessageBox.Show("真的要退出？", "点错了？", MessageBoxButton.YesNo,MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                e.Cancel = false;                
            }
            else
            {
                e.Cancel = true;
            }

        }

        private void AddTextToFrpcText(string str)
        {
            this.FrpcText.Dispatcher.Invoke(new Action(() => { this.FrpcText.AppendText(str); }));
        }

        private void ClearTextToFrpcText()
        {
            this.FrpcText.Dispatcher.Invoke(new Action(() => { this.FrpcText.Clear(); }));
        }
        private void AddTextToFrpsText(string str)
        {
            this.FrpsText.Dispatcher.Invoke(new Action(() => { this.FrpsText.AppendText(str); }));
        }

        private void ClearTextToFrpsText()
        {
            this.FrpsText.Dispatcher.Invoke(new Action(() => { this.FrpsText.Clear(); }));
        }

        private void AddTextToFrpcOldText(string str)
        {
            this.FrpcOldText.Dispatcher.Invoke(new Action(() => { this.FrpcOldText.AppendText(str); }));
        }

        private void ClearTextToFrpcOldText()
        {
            this.FrpcOldText.Dispatcher.Invoke(new Action(() => { this.FrpcOldText.Clear(); }));
        }
        private void AddTextToFrpsOldText(string str)
        {
            this.FrpsOldText.Dispatcher.Invoke(new Action(() => { this.FrpsOldText.AppendText(str); }));
        }

        private void ClearTextToFrpsOldText()
        {
            this.FrpsOldText.Dispatcher.Invoke(new Action(() => { this.FrpsOldText.Clear(); }));
        }

        public void Frpc_Prepare()
        {
            string cmd1 = "cd frp";

            frpc.RunCMD(cmd1);
        }

        public void Frpc_Start()
        {
            string cmd2 = "frpc.exe -c frpc.toml";

            frpc.Output += Frpc_Output;

            ClearTextToFrpcText();
            frpc.RunCMD(cmd2);
        }

        public void Frpc_Stop()
        {
            string cmd3 = "taskkill /f /im frpc.exe";

            frpc.Stop();

            //libs.Cmd(cmd3);
            Command command = new Command();
            command.RunCMD(cmd3);
            command.Stop();
        }
        private void Frpc_Output(string msg)
        {
            AddTextToFrpcText(msg);
        }
        public void Frps_Prepare()
        {
            string cmd4 = "cd frp";

            frps.RunCMD(cmd4);
        }

        public void Frps_Start()
        {
            string cmd5 = "frps.exe -c frps.toml";

            frps.Output += Frps_Output;
            
            ClearTextToFrpsText();
            frps.RunCMD(cmd5);
        }

        public void Frps_Stop()
        {
            string cmd6 = "taskkill /f /im frps.exe";

            frps.Stop();
            
            Command command = new Command();
            command.RunCMD(cmd6);
            command.Stop();
        }
        private void Frps_Output(string msg)
        {
            AddTextToFrpsText(msg);
        }

        public void FrpcOld_Prepare()
        {
            string cmd1 = "cd frp_old";

            frpc32.RunCMD(cmd1);
        }

        public void FrpcOld_Start()
        {
            string cmd2 = "frpc.exe -c frpc.ini";

            frpc32.Output += FrpcOld_Output;

            ClearTextToFrpcOldText();
            frpc32.RunCMD(cmd2);
        }

        public void FrpcOld_Stop()
        {
            string cmd3 = "taskkill /f /im frpc.exe";

            frpc32.Stop();

            Command command = new Command();
            command.RunCMD(cmd3);
            command.Stop();
        }
        private void FrpcOld_Output(string msg)
        {
            AddTextToFrpcOldText(msg);
        }
        public void FrpsOld_Prepare()
        {
            string cmd4 = "cd frp_old";

            frps32.RunCMD(cmd4);
        }

        public void FrpsOld_Start()
        {
            string cmd5 = "frps.exe -c frps.ini";

            frps32.Output += FrpsOld_Output;

            ClearTextToFrpsOldText();
            frps32.RunCMD(cmd5);
        }

        public void FrpsOld_Stop()
        {
            string cmd6 = "taskkill /f /im frps.exe";

            frps32.Stop();

            Command command = new Command();
            command.RunCMD(cmd6);
            command.Stop();
        }
        private void FrpsOld_Output(string msg)
        {
            AddTextToFrpsOldText(msg);
        }

        private void FrpcStartButton1_Click(object sender, RoutedEventArgs e)
        {
            FrpcStartButton1.IsEnabled = false;
            Frpc_Start();
        }

        private void FrpcStopButton1_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("此操作会关闭所有frpc进程", "点错了？", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Frpc_Stop();
                ClearTextToFrpcText();
                AddTextToFrpcText("frpc已退出");
                frpc = new Commands.Command();
                Frpc_Prepare();
                FrpcStartButton1.IsEnabled = true;
            }
        }

        private void FrpcClearButton1_Click(object sender, RoutedEventArgs e)
        {
            ClearTextToFrpcText();
        }

        private void FrpsStartButton1_Click(object sender, RoutedEventArgs e)
        {
            FrpsStartButton1.IsEnabled = false;
            Frps_Start();
        }

        private void FrpsStopButton1_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("此操作会关闭所有frps进程", "点错了？", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Frps_Stop();
                ClearTextToFrpsText();
                AddTextToFrpsText("frps已退出");
                frps = new Commands.Command();
                Frps_Prepare();
                FrpsStartButton1.IsEnabled = true;
            }
        }

        private void FrpsClearButton1_Click(object sender, RoutedEventArgs e)
        {
            ClearTextToFrpsText();
        }

        private void FrpcOldStartButton1_Click(object sender, RoutedEventArgs e)
        {
            FrpcOldStartButton1.IsEnabled = false;
            FrpcOld_Start();
        }

        private void FrpcOldStopButton1_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("此操作会关闭所有frpc进程", "点错了？", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                FrpcOld_Stop();
                ClearTextToFrpcOldText();
                AddTextToFrpcOldText("frpc已退出");
                frpc32 = new Commands.Command();
                FrpcOld_Prepare();
                FrpcOldStartButton1.IsEnabled = true;
            }
        }

        private void FrpcOldClearButton1_Click(object sender, RoutedEventArgs e)
        {
            ClearTextToFrpcOldText();
        }

        private void FrpsOldStartButton1_Click(object sender, RoutedEventArgs e)
        {
            FrpsOldStartButton1.IsEnabled = false;
            FrpsOld_Start();
        }

        private void FrpsOldStopButton1_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("此操作会关闭所有frps进程", "点错了？", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                FrpsOld_Stop();
                ClearTextToFrpsOldText();
                AddTextToFrpsOldText("frps已退出");
                frps32 = new Commands.Command();
                FrpsOld_Prepare();
                FrpsOldStartButton1.IsEnabled = true;
            }
        }

        private void FrpsOldClearButton1_Click(object sender, RoutedEventArgs e)
        {
            ClearTextToFrpsOldText();
        }

        private void closed(object sender, EventArgs e)
        {
            frpc.Stop();
            frps.Stop();
            frpc32.Stop();
            frps32.Stop();

            string cmd1 = "taskkill /f /im frpc.exe";
            string cmd2 = "taskkill /f /im frps.exe";

            Command command1 = new Command();
            command1.RunCMD(cmd1);
            command1.Stop();
            Command command2 = new Command();
            command2.RunCMD(cmd2);
            command2.Stop();
        }

        private void AutoStartSettings()
        {
            Configuration cfg = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string frpccfg = cfg.AppSettings.Settings["frpc"].Value;
            string frpscfg = cfg.AppSettings.Settings["frps"].Value;
            string frpc32cfg = cfg.AppSettings.Settings["frpc32"].Value;
            string frps32cfg = cfg.AppSettings.Settings["frps32"].Value;

            if (frpccfg == "1")
            {
                frpcautostart = true;
            }

            if (frpscfg == "1")
            {
                frpsautostart = true;
            }

            if (frpc32cfg == "1")
            {
                frpc32autostart = true;
            }

            if (frps32cfg == "1")
            {
                frps32autostart = true;
            }
        }

        private void FrpcRestartButton1_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("此操作会先关闭所有frpc进程，然后再启动当前的frpc", "点错了？", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Frpc_Stop();
                Thread.Sleep(1000);
                frpc = new Commands.Command();
                Frpc_Prepare();
                FrpcStartButton1.IsEnabled = false;
                Frpc_Start();
            }
        }

        private void FrpsRestartButton1_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("此操作会先关闭所有frps进程，然后再启动当前的frps", "点错了？", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                Frps_Stop();
                Thread.Sleep(1000);
                frps = new Commands.Command();
                Frps_Prepare();
                FrpsStartButton1.IsEnabled = false;
                Frps_Start();
            }
        }

        private void FrpcOldRestartButton1_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("此操作会关闭所有frpc进程，然后再启动当前的frpc", "点错了？", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                FrpcOld_Stop();
                Thread.Sleep(1000);
                frpc32 = new Commands.Command();
                FrpcOld_Prepare();
                FrpcOldStartButton1.IsEnabled = false;
                FrpcOld_Start();
            }
            
        }

        private void FrpsOldRestartButton1_Click(object sender, RoutedEventArgs e)
        {
            if (System.Windows.MessageBox.Show("此操作会先关闭所有frps进程，然后再启动当前的frps", "点错了？", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                FrpsOld_Stop();
                Thread.Sleep(1000);
                frps32 = new Commands.Command();
                FrpsOld_Prepare();
                FrpsOldStartButton1.IsEnabled = false;
                FrpsOld_Start();
            }
        }

        private void ClickXfs(object sender, MouseButtonEventArgs e)
        {           
            string[] str = { "别戳我—︿—", "别戳啦>︿<","要进来了>︿<","好痛啊>︿<", "暖暖的= w =", "要流出来了>︿<", "流出来了T ︿ T", "坏掉了。" };            
          
            if (touchxfs >= 7)
            {
                this.ImageXfs.Source = new BitmapImage(new Uri("images/xfs-no.ico", UriKind.Relative));
                notifyIcon.BalloonTipText = "真的坏掉了。";
                notifyIcon.BalloonTipIcon = ToolTipIcon.None;
                notifyIcon.BalloonTipTitle = str[touchxfs];
                
            }
            else
            {
                if (touchxfs >= 4 & touchxfs <= 7)
                {
                    notifyIcon.BalloonTipText = "拷走拷走！";
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Error;
                }
                else
                {
                    notifyIcon.BalloonTipText = "快住手！";
                    notifyIcon.BalloonTipIcon = ToolTipIcon.Warning;
                }
                notifyIcon.BalloonTipTitle = str[touchxfs % 7];
                touchxfs += 1;
            }
            notifyIcon.ShowBalloonTip(0);

        }

        
    }
}
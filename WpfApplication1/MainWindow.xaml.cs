using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;

namespace WpfApplication1
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public int ballonCount = 0;
        public int premierCount = 0;
        List<Process> _process = new List<Process>(); //Our process list
        public MainWindow()
        {
            System.Console.WriteLine("Init");
            InitializeComponent();
            System.Console.WriteLine("Ready");

            pwdTextBox.Text = System.IO.Directory.GetCurrentDirectory();
            countBallonTextBox.Text = ballonCount.ToString();
            countPremierTextBox.Text = premierCount.ToString();
            this.Closed += MainWindow_Closed;
        }

        private void MainWindow_Closed(object sender, EventArgs e)
        {
            closeAll(null, null);
        }

        private void addToList(string str)
        {
            var l = new ListBoxItem();
            l.Content = str;
            listBox.Items.Add(l);
            countBallonTextBox.Text = ballonCount.ToString();
            countPremierTextBox.Text = premierCount.ToString();
        }
        private void refreshClick(object sender, RoutedEventArgs e)
        {
            List<Process> _processToDel = new List<Process>(); //Our closed process list
            System.Console.WriteLine("Parsing list ...");
            this.Dispatcher.BeginInvoke(DispatcherPriority.Normal,
                 (ThreadStart)delegate ()
                 {
                     listBox.Items.Clear();
                     _process.ForEach(delegate (Process p)
                     {
                         Console.WriteLine("Checking process : " + p.Id + " " + p.StartInfo.FileName + " " + p.HasExited);
                         if (p.HasExited)
                         {
                             Console.WriteLine("Removing process : " + p.Id + " " + p.StartInfo.FileName + " " + p.HasExited);
                             switch (p.StartInfo.FileName)
                             {
                                 case "Ballon.exe":
                                     ballonCount--;
                                     break;
                                 case "Premier.exe":
                                     premierCount--;
                                     break;
                             }
                             _processToDel.Add(p);
                         }
                         else
                         {
                             Console.WriteLine("Keeping process : " + p.Id + " " + p.StartInfo.FileName + " " + p.HasExited);
                             addToList(p.Id + " " + p.StartInfo.FileName);
                         }
                     });

                     System.Console.WriteLine("Clearing list ...");
                     _processToDel.ForEach(delegate (Process p)
                     {
                         _process.Remove(p);
                     });
                     countBallonTextBox.Text = ballonCount.ToString();
                     countPremierTextBox.Text = premierCount.ToString();
                 });
        }

        private void startBallonBtnClick(object sender, RoutedEventArgs e)
        {
            if(ballonCount >= 5)
            {
                MessageBox.Show("Allready 5 Ballon.exe started !", "Warning !");
                return;
            }
            ballonCount++;
            startProcess("Ballon.exe");
        }

        private void startPremierBtnClick(object sender, RoutedEventArgs e)
        {
            if (premierCount >= 5)
            {
                MessageBox.Show("Allready 5 Premier.exe started !", "Warning !");
                return;
            }
            premierCount++;
            startProcess("Premier.exe");
        }

        private void startProcess(string str)
        {
            var p = Process.Start(str); //TODO limit to 5 by str
            p.EnableRaisingEvents = true;
            p.Exited += new EventHandler(P_Exited);
            _process.Add(p);
            addToList(p.Id + " " + p.StartInfo.FileName);
        }
        private void P_Exited(object sender, EventArgs e)
        {
            System.Console.WriteLine("Some child has closed");
            refreshClick(null, null);
        }

        private void closeLast(object sender, RoutedEventArgs e)
        {
            if (_process.Count == 0)
            {
                MessageBox.Show("No process to Kill !", "Warning !");
                return;
            }
            _process.Last().Kill();
            //refreshClick(null, null); //not needed as updt by event
        }

        private void closeLastBallon(object sender, RoutedEventArgs e)
        {
            if (ballonCount == 0)
            {
                MessageBox.Show("No Ballon.exe to Kill !", "Warning !");
                return;
            }
            _process.FindLast(
            delegate (Process p)
            {
                return p.StartInfo.FileName == "Ballon.exe";
            }).Kill();
        }

        private void closeLastPremier(object sender, RoutedEventArgs e)
        {
            if (premierCount == 0)
            {
                MessageBox.Show("No Premier.exe to Kill !", "Warning !");
                return;
            }
            _process.FindLast(
            delegate (Process p)
            {
                return p.StartInfo.FileName == "Premier.exe";
            }).Kill();
        }

        private void closeAll(object sender, RoutedEventArgs e)
        {
            _process.ForEach(
            delegate (Process p)
            {
                p.Kill();
            });

        }
        private void quitClick(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}

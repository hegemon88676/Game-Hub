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

namespace GameHub
{
    /// <summary>
    /// Interaction logic for Hub.xaml
    /// </summary>
    public partial class Hub : UserControl
    {
        public Hub()
        {
            InitializeComponent();
        }

        private void btnChess_Click(object sender, RoutedEventArgs e)
        {
            Chess chess = new Chess();
            Content = chess;
        }

        private void btnExit(object sender, RoutedEventArgs e)
        {
            Window parentwin = Window.GetWindow(this);
            parentwin.Close();
        }

        private void btnTTT_Click(object sender, RoutedEventArgs e)
        {
            TicTacToe ttt = new TicTacToe();
            Content = ttt;
        }
    }
}

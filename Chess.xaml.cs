using System.Windows;
using System.Windows.Controls;
using GameHub.ChessClasses;
namespace GameHub
{
    /// <summary>
    /// Interaction logic for Chess.xaml
    /// </summary>
    public partial class Chess : UserControl
    {
        public Chess()
        {
            InitializeComponent();
            Piece.addPiece(gridTable);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}

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
            DoStuff();
	    Piece.addPiece(gridTable);

        }

        private void DoStuff()
        {
        }
    }
}

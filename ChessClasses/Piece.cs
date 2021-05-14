using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;

namespace GameHub.ChessClasses
{
    public class Piece
    {
        int currentx, currenty;
        private static BitmapFrame changeBtnBckg(string imageName)
        {
            Uri resourceUri = new Uri("Images/" + imageName + ".png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);

            BitmapFrame temp = BitmapFrame.Create(streamInfo.Stream);
            
            
            return temp;
            
        }
        public static void addPiece(Grid grid)
        {
            Button btnRook = new Button();
            ImageBrush brush = new ImageBrush(changeBtnBckg("BlackRook"));
            btnRook.Background = brush;
            Grid.SetColumn(btnRook, 0);
            Grid.SetRow(btnRook, 0);
            grid.Children.Add(btnRook);
        }
    }
}

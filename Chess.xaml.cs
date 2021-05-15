using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
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
	        addPiece(gridTable);
        }
        private static ImageBrush SetButtonImage(string imageName)
        {
            Uri resourceUri = new Uri("Images/" + imageName + ".png", UriKind.Relative);
            StreamResourceInfo streamInfo = Application.GetResourceStream(resourceUri);
            BitmapFrame bitmapFrame = BitmapFrame.Create(streamInfo.Stream);
            System.Windows.Media.ImageBrush imageBrush = new ImageBrush();
            imageBrush.ImageSource = bitmapFrame;
            imageBrush.Stretch = Stretch.Fill;
            return imageBrush;
        }
       

        public static void addPiece(Grid grid)
        {
            Button btnRook = new Button();
            //btnRook.MouseEnter += noHover;
            btnRook.Width = 50;
            btnRook.Height = 50;
            btnRook.Margin = new Thickness(0);
            btnRook.HorizontalAlignment = HorizontalAlignment.Stretch; ;
            //btnRook.Click += btnChooseLine_Click;
            // newBtn.FontSize = 16;
            btnRook.Background = SetButtonImage("BlackRook");
            //btnRook.Style = this.FindResource("btnStyle") as Style;
            Grid.SetColumn(btnRook, 0);
            Grid.SetRow(btnRook, 0);
            grid.Children.Add(btnRook);

        }
        private static void noHover(object sender, MouseEventArgs e)
        {
            Button btn = sender as Button;
            if (btn.IsMouseOver)
                btn.Background = Brushes.Transparent;
        }
    }
}

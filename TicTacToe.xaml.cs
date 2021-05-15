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
    /// Interaction logic for TicTacToe.xaml
    /// </summary>
    public partial class TicTacToe : UserControl
    {
        private int CurrentlyPlaying = 2;
        private bool StartingWithPlayer1 = false;

        public TicTacToe()
        {
            InitializeComponent();

        }

        private void DoStuff()
        {
        }

        private void AddButtons()
        {
            for(int i = 0; i < 3; ++i)
                for(int j = 0; j < 3; ++j)
                {
                    Button btn = new Button();
                    btn.Name = "btn" + i + j;
                    btn.Height = 134;
                    btn.Width = 134;
                    btn.Margin = new Thickness(0);
                    btn.BorderBrush = Brushes.Transparent;
                    btn.BorderThickness = new Thickness(0);
                    btn.Click += new RoutedEventHandler(btnAddXor0);
                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    gridTTT.Children.Add(btn);
                }
        }

        private void btnAddXor0(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            int i = int.Parse(btn.Name[3].ToString());
            int j = int.Parse(btn.Name[4].ToString());

            gridTTT.Children.Remove(btn);

            if(CurrentlyPlaying == 1)
                if(StartingWithPlayer1)
                    AddX(i, j);
                else
                    Add0(i, j);
            else if(StartingWithPlayer1)
                Add0(i, j);
            else
                AddX(i, j);

            if(CurrentlyPlaying == 1)
                CurrentlyPlaying++;
            else
                CurrentlyPlaying--;

            labelCurrentPlayer.Content = "player " + CurrentlyPlaying + ".";

        }
        private void AddX(int i, int j)
        {
            Label labelX = new Label() { Content = "X", Height = 134, Width = 134, FontSize = 75 };
            labelX.HorizontalContentAlignment = HorizontalAlignment.Center;
            labelX.VerticalContentAlignment = VerticalAlignment.Center;
            Grid.SetColumn(labelX, j);
            Grid.SetRow(labelX, i);
            gridTTT.Children.Add(labelX);
        }

        private void Add0(int i, int j)
        {
            Label label0 = new Label() { Content = "0", Height = 134, Width = 134, FontSize = 75 };
            label0.HorizontalContentAlignment = HorizontalAlignment.Center;
            label0.VerticalContentAlignment = VerticalAlignment.Center;
            Grid.SetColumn(label0, j);
            Grid.SetRow(label0, i);
            gridTTT.Children.Add(label0);

        }

        private void AddBorders()
        {
            for(int i = 0; i < 3; ++i)
                for(int j = 0; j < 3; ++j)
                {
                    Border brush = new Border() { BorderBrush = Brushes.Black, BorderThickness = new Thickness(2)};
                    Grid.SetColumn(brush, j);
                    Grid.SetRow(brush, i);
                    gridTTT.Children.Add(brush);
                }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            Hub hub = new Hub();
            Content = hub;
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            if(StartingWithPlayer1)
            {
                StartingWithPlayer1 = false;
                CurrentlyPlaying = 2;
                labelPlayer1PlayingAs.Content = "0";
                labelPlayer2PlayingAs.Content = "X";
            }
            else
            {
                StartingWithPlayer1 = true;
                CurrentlyPlaying = 1;
                labelPlayer1PlayingAs.Content = "X";
                labelPlayer2PlayingAs.Content = "0";
            }

            labelCurrentPlayer.Content = "player " + CurrentlyPlaying + ".";
            gridTTT.Children.Clear();
            AddButtons();
            AddBorders();
        }
    }
}

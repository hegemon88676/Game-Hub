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
                    btn.Name = "Button" + i + j;
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

            int i = int.Parse(btn.Name[6].ToString());
            int j = int.Parse(btn.Name[7].ToString());

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
        }
        private void AddX(int i, int j)
        {
            MessageBox.Show("hey");
        }

        private void Add0(int i, int j)
        {
            MessageBox.Show("buna");

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
            }
            else
            {
                StartingWithPlayer1 = true;
                CurrentlyPlaying = 1;
            }

            gridTTT.Children.Clear();
            AddButtons();
            AddBorders();
        }
    }
}

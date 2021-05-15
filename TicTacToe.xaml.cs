using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Linq;

namespace GameHub
{
    /// <summary>
    /// Interaction logic for TicTacToe.xaml
    /// </summary>
    public partial class TicTacToe : UserControl
    {
        private int CurrentlyPlaying = 2;
        private static int Player1Wins = 0, Player2Wins = 0, NumberOfTies = 0;
        private bool StartingWithPlayer1 = false;
        private int[,] arrayTTT = new int[3, 3];

        public TicTacToe()
        {
            InitializeComponent();
            DoStuff();
        }

        private void DoStuff()
        {
            GetPlayer1Wins();
            GetPlayer2Wins();
            GetTies();
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
            arrayTTT[i, j] = CurrentlyPlaying;
            int check = CheckWinCondition();
            switch(check)
            {
                case -1:
                    break;
                case 0:
                    NumberOfTies++;
                    labelNumberofTies.Content = NumberOfTies;
                    MessageBox.Show("Tie!");
                    break;
                case 1:
                    Player1Wins++;
                    labelScorePlayer1.Content = Player1Wins;
                    MessageBox.Show("Player 1 wins!");
                    break;
                case 2:
                    Player2Wins++;
                    labelScorePlayer2.Content = Player2Wins;
                    MessageBox.Show("Player 2 wins!");
                    break;
            }
            if(check != -1)
            {
            }

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

        private int CheckWinCondition()
        {
            int i, j;

            if(arrayTTT[0, 0] == arrayTTT[0, 1] && arrayTTT[0, 1] == arrayTTT[0, 2])
                return arrayTTT[0, 0];
            if(arrayTTT[1, 0] == arrayTTT[1, 1] && arrayTTT[1, 1] == arrayTTT[1, 2])
                return arrayTTT[1, 0];
            if(arrayTTT[2, 0] == arrayTTT[2, 1] && arrayTTT[2, 1] == arrayTTT[2, 2])
                return arrayTTT[2, 0];
            if(arrayTTT[0, 0] == arrayTTT[1, 1] && arrayTTT[1, 1] == arrayTTT[2, 2])
                return arrayTTT[0, 0];
            if(arrayTTT[0, 2] == arrayTTT[1, 1] && arrayTTT[1, 1] == arrayTTT[2, 0])
                return arrayTTT[0, 2];
            if(arrayTTT[0, 0] == arrayTTT[1, 0] && arrayTTT[1, 0] == arrayTTT[2, 0])
                return arrayTTT[0, 0];
            if(arrayTTT[0, 1] == arrayTTT[1, 1] && arrayTTT[1, 1] == arrayTTT[2, 1])
                return arrayTTT[0, 1];
            if(arrayTTT[0, 2] == arrayTTT[1, 2] && arrayTTT[1, 2] == arrayTTT[2, 2])
                return arrayTTT[0, 2];

            for(i = 0; i < 3; ++i)
                for(j = 0; j < 3; ++j)
                    if(arrayTTT[i, j] == 0)
                        return -1;


            return 0;
        }

        public static void GetPlayer1Wins()
        {
        }

        public static void GetPlayer2Wins()
        {
        
        }

        public static void GetTies()
        {
        
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
            FillArray(arrayTTT);
            AddButtons();
            AddBorders();
        }
        public static void FillArray(int[,] array)
        {
            for(int i = 0; i < array.GetLength(0); i++)
            {
                for(int j = 0; j < array.GetLength(1); j++)
                {
                    array[i, j] = 0;
                }
            }
        }
    }
}

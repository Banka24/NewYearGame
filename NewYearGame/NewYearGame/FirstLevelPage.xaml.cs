﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewYearGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FirstLevelPage : ContentPage
    {
        public FirstLevelPage()
        {
            Random random = new Random();
            InitializeComponent();
            Grid.SetColumn(Enemy, random.Next(4));
            Grid.SetRow(Enemy, random.Next(4));
            
        }        

        private void MoveEnemy(Image enemy, in int colPlayer, in int rowPlayer)
        {
            Random random = new Random();
            int col = random.Next(4);
            int row = random.Next(4);
            Grid.SetColumn(enemy, col);
            Grid.SetRow(enemy, row);
            if(col == colPlayer && row == rowPlayer)
            {
                DisplayAlert("Проигрыш", "Не расстраивайтесь, такое бывает.\nПопробуйте заново", "Restart");
                Navigation.PushAsync(new FirstLevelPage());
            }
        }

        private void SwipeGestureRecognizer_Swiped(object sender, SwipedEventArgs e)
        {
            int col = Grid.GetColumn(this.Player);
            int row = Grid.GetRow(this.Player);

            switch (e.Direction)
            {
                case SwipeDirection.Up:
                    row--;
                    break;
                case SwipeDirection.Left:
                    col--;
                    break; 
                case SwipeDirection.Right:
                    col++;
                    break; 
                case SwipeDirection.Down:
                    row++;
                    break;
            }

            col = Math.Max(0, Math.Min(col, 4));
            row = Math.Max(0, Math.Min(row, 4));

            MoveEnemy(Enemy, col, row);

            Grid.SetColumn(this.Player, col);
            Grid.SetRow(this.Player, row);
        }
    }
}
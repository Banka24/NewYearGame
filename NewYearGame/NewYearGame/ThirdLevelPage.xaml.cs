using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NewYearGame
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ThirdLevelPage : ContentPage
    {
        public ThirdLevelPage()
        {
            Random random = new Random();
            InitializeComponent();
            Grid.SetColumn(Enemy, random.Next(1, 5));
            Grid.SetRow(Enemy, random.Next(1, 5));
            Grid.SetColumn(Enemy1, random.Next(1, 5));
            Grid.SetRow(Enemy1, random.Next(1, 5));
            Grid.SetColumn(Enemy2, random.Next(1, 5));
            Grid.SetRow(Enemy2, random.Next(1, 5));
            Grid.SetColumn(Elka, random.Next(1, 5));
            Grid.SetRow(Elka, random.Next(1, 5));
        }
        private void CheckStatus(Image elka, in int colPlayer, in int rowPlayer)
        {
            int colElka = Grid.GetColumn(elka);
            int rowElka = Grid.GetRow(elka);

            if (colElka == colPlayer && rowElka == rowPlayer)
            {
                DisplayAlert("Победа", "Это ваша ёлка. Новый год спасён", "Победа");
                Navigation.PopToRootAsync();
            }
        }

        private void MoveEnemy(in int colPlayer, in int rowPlayer, params Image[] enemyes)
        {
            Random random = new Random();
            foreach (Image enemy in enemyes)
            {
                int col = random.Next(7);
                int row = random.Next(7);
                col = Math.Max(0, Math.Min(col, 4));
                row = Math.Max(0, Math.Min(row, 4));
                Grid.SetColumn(enemy, col);
                Grid.SetRow(enemy, row);
                if (col == colPlayer && row == rowPlayer)
                {
                    DisplayAlert("Проигрыш", "Не расстраивайтесь, такое бывает.\nПопробуйте заново", "Ok");
                    Navigation.PopToRootAsync();
                }
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

            col = Math.Max(0, Math.Min(col, 7));
            row = Math.Max(0, Math.Min(row, 7));

            MoveEnemy(col, row, Enemy, Enemy1, Enemy2);
            CheckStatus(Elka, col, row);

            Grid.SetColumn(this.Player, col);
            Grid.SetRow(this.Player, row);
        }
    }
}
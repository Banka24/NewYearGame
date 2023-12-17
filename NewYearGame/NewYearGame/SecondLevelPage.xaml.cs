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
    public partial class SecondLevelPage : ContentPage
    {
        public SecondLevelPage()
        {
            Random random = new Random();
            InitializeComponent();
            Grid.SetColumn(Enemy, random.Next(1, 7));
            Grid.SetRow(Enemy, random.Next(1, 7));
            Grid.SetColumn(Elka, random.Next(1, 7));
            Grid.SetRow(Elka, random.Next(1, 7));
        }

        private void CheckStatus(Image elka, in int colPlayer, in int rowPlayer)
        {
            int colElka = Grid.GetColumn(elka);
            int rowElka = Grid.GetRow(elka);

            if (colElka == colPlayer && rowElka == rowPlayer)
            {
                DisplayAlert("Победа", "Ваша ёлка в другом лесу", "Продолжить");
                Navigation.PushAsync(new SecondLevelPage());
            }
        }

        private void MoveEnemy(Image enemy, in int colPlayer, in int rowPlayer)
        {
            Random random = new Random();
            int col = random.Next(7);
            int row = random.Next(7);
            Grid.SetColumn(enemy, col);
            Grid.SetRow(enemy, row);
            if (col == colPlayer && row == rowPlayer)
            {
                DisplayAlert("Проигрыш", "Не расстраивайтесь, такое бывает.\nПопробуйте заново", "Ok");
                Navigation.PopToRootAsync();
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

            MoveEnemy(Enemy, col, row);
            CheckStatus(Elka, col, row);

            Grid.SetColumn(this.Player, col);
            Grid.SetRow(this.Player, row);
        }
    }
}
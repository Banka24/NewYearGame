using System;
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
            Image[] images = { Enemy, Elka };

            foreach (Image image in images)
            {
                Grid.SetColumn(image, random.Next(1, 4));
                Grid.SetRow(image, random.Next(1, 3));
            }
        }        

        private void CheckStatus(in int colPlayer, in int rowPlayer)
        {
            int colElka = Grid.GetColumn(Elka);
            int rowElka = Grid.GetRow(Elka);

            if(colElka == colPlayer && rowElka == rowPlayer)
            {
                DisplayAlert("О нет!", "Ваша ёлка в другом лесу", "Продолжить");
                Navigation.PushAsync(new SecondLevelPage());
            }
        }

        private void MoveEnemy(in int colPlayer, in int rowPlayer)
        {
            Random random = new Random();
            Image enemy = Enemy;
            Image elka = Elka;

            int colElka = Grid.GetColumn(elka);
            int rowElka = Grid.GetRow(elka);

            int col = random.Next(4);
            int row = random.Next(4);

            if(col == colElka && row == rowElka)
            {
                col = random.Next(4);
                row = random.Next(4);
            }

            if (col == colPlayer && row == rowPlayer)
            {
                DisplayAlert("Проигрыш", "Не расстраивайтесь, такое бывает.\nПопробуйте заново", "Ok");
                Navigation.PopToRootAsync();
            }

            Grid.SetColumn(enemy, col);
            Grid.SetRow(enemy, row);
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
                        
            MoveEnemy(col, row);
            CheckStatus(col, row);

            Grid.SetColumn(this.Player, col);
            Grid.SetRow(this.Player, row);
        }
    }
}
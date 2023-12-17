using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace NewYearGame
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();            
        }

        private async void StartGameButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new ThirdLevelPage());
        }

        private void EndGameButton_Clicked(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }

        private async void InfoGameButton_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new InfoPage());
        }
    }
}

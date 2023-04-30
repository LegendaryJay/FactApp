using Xamarin.Forms;
using Rg.Plugins.Popup.Pages;
using Rg.Plugins.Popup.Services;
using System.IO;
using System.Reflection;

namespace FactApp
{
    public partial class FactCard : PopupPage
    {
        public FactCard(FactData fact)
        {
            var stackLayout = new StackLayout
            {
                BackgroundColor = Color.White,
                Padding = new Thickness(20)
            };

            var image = new Image
            {
                Source = fact.Image,
                HeightRequest = 300,
            };

            var titleLabel = new Label
            {
                Text = fact.Title,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                TextColor = Color.Black,
                Margin = new Thickness(0, 10)
            };

            var descriptionLabel = new Label
            {
                Text = fact.Description,
                Margin = new Thickness(0, 10),
                TextColor = Color.Black
            };

            stackLayout.Children.Add(image);
            stackLayout.Children.Add(titleLabel);
            stackLayout.Children.Add(descriptionLabel);

            Content = stackLayout;

            BackgroundColor = new Color(0, 0, 0, 0.5);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            var tapGestureRecognizer = new TapGestureRecognizer();
            tapGestureRecognizer.Tapped += async (s, e) =>
            {
                await PopupNavigation.Instance.PopAsync();
            };
            BackgroundClicked += async (s, e) =>
            {
                await PopupNavigation.Instance.PopAsync();
            };
            Content.GestureRecognizers.Add(tapGestureRecognizer);
        }
    }
}

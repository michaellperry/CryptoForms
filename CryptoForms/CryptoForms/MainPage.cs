using System;
using Xamarin.Forms;

namespace CryptoForms
{
    public class MainPage : ContentPage
    {

        private Label label = null;
        private Button button = null;

        public MainPage()
        {
            button = new Button
            {
                Text = "Click me",
            };

            label = new Label
            {
                XAlign = TextAlignment.Center,
                Text = "Welcome to Xamarin Forms!"
            };
            button.Clicked += async (sender, e) =>
            {
                var data = "Cryptographic example";
                var pass = "MySecretKey";

                var contentPage = new ContentPage();
                var salt = Crypto.CreateSalt(16);
                await contentPage.DisplayAlert("Alert", "Encrypting String " + data + ", with salt " + BitConverter.ToString(salt), "OK");
                var bytes = Crypto.EncryptAes(data, pass, salt);
                await contentPage.DisplayAlert("Alert", "Encrypted, Now Decrypting", "OK");
                var str = Crypto.DecryptAes(bytes, pass, salt);
                await contentPage.DisplayAlert("Alert", "Decryted " + str, "OK");
            };

            this.Title = "Crypto Forms";
            // The root page of your application    
            this.Content = new StackLayout
            {
                VerticalOptions = LayoutOptions.Center,
                Children =    
                {    
                    label,    
                    button    
    
                }
            };


        }
    }
}
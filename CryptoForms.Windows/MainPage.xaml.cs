using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace CryptoForms.Windows
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = "Cryptographic example";
                var pass = "MySecretKey";

                var salt = Crypto.CreateSalt(16);
                await DisplayAlert("Encrypting String " + data + ", with salt " + BitConverter.ToString(salt));
                var bytes = Crypto.EncryptAes(data, pass, salt);
                await DisplayAlert("Encrypted, Now Decrypting");
                var str = Crypto.DecryptAes(bytes, pass, salt);
                await DisplayAlert("Decryted " + str);

                this.Message.Text = "Yay maths!";
            }
            catch (Exception x)
            {
                this.Message.Text = x.Message;
           }
        }

        private async Task DisplayAlert(string message)
        {
            MessageDialog dialog = new MessageDialog(message);
            await dialog.ShowAsync();
        }
    }
}

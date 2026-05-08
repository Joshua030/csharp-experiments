using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;

namespace InvoiceManagement;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private async void OnLoginBtnClicked(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var passwordEntered = PasswordBox.Text;
        string? correctPassword = DotNetEnv.Env.GetString("INVOICEMANAGEMENT");

        if (passwordEntered == correctPassword)
        {
            // Password is correct, proceed to the next view or action

            var box = MessageBoxManager.GetMessageBoxStandard(
         "Login Info",
         "Entered correct password",
         ButtonEnum.Ok);
            await box.ShowAsync();
        }
        else
        {
            // Password is incorrect, show an error message
            var box = MessageBoxManager.GetMessageBoxStandard(
       "Login Info",
       "Entered incorrect password",
       ButtonEnum.Ok);
            await box.ShowAsync();
        }
    }

    private void OnPasswordChanged(object? sender, TextChangedEventArgs e)
    {
        LoginButton.IsEnabled = !string.IsNullOrEmpty(PasswordBox.Text);
    }
}

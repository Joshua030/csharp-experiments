using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace WPFDemo;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }

    private void LoginButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {

        // Navigate to other view k
        var topLevel = TopLevel.GetTopLevel(this);
        if (topLevel is Window window)
        {
            window.Content = new InvoiceView();
        }
    }
}
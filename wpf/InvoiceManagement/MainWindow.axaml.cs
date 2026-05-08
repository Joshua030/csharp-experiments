using Avalonia.Controls;

namespace InvoiceManagement;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        MainContent.Content = new LoginView();
    }
}
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;


namespace MyTutorialApp;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Button myButton = new()
        {
            Content = "Button"
        };

        Grid.SetRow(myButton, 3);
        Grid.SetColumn(myButton, 4);
        var myGrid = this.FindControl<Grid>("myGrid");
        myGrid?.Children.Add(myButton);

    }

    public async void Button_Click(object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        var box = MessageBoxManager.GetMessageBoxStandard("Title", "Button clicked!", ButtonEnum.Ok);
        await box.ShowAsync();
    }
}




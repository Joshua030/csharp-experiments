using System;
using Avalonia.Controls;
using Avalonia.Media;

namespace TodoList;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void AddTodoButton_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        string? todoText = TodoTextBox.Text?.Trim();

        if (!string.IsNullOrEmpty(todoText))
        {
            TextBlock todoItem = new TextBlock
            {
                Text = todoText,
                Margin = new Avalonia.Thickness(10),
                Foreground = new SolidColorBrush(Colors.White)
            };

            TodoList.Children.Add(todoItem);
        }
    }
}
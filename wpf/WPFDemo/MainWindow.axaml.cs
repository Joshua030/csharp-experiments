using System.Collections.Generic;
using Avalonia.Controls;
using MsBox.Avalonia;
using MsBox.Avalonia.Enums;
using WPFDemo.Data;

namespace WPFDemo;

public partial class MainWindow : Window
{

    public List<Person> People { get; set; } = new List<Person>
    {
        new(){Name = "Jammick", Age = 30},
        new(){Name = "Marc", Age = 20},
        new(){Name = "Maria", Age = 40},
        new(){Name = "Scott", Age = 35},
        new(){Name = "Lucas", Age = 27},
    };
    /*   Person person = new()
      {
          Name = "Jammick",
          Age = 30
      }; */
    public MainWindow()
    {
        InitializeComponent();
        // this.DataContext = person;
        /* 
                ListBoxNames.ItemsSource = new List<string>()
                {
                    "Jannick",
                    "Peter",
                    "Maria",
                    "Marc"
                }; */


        ListBoxPeople.ItemsSource = People;

        // MainContent.Content = new LoginView();
    }


    // Example two way biding

    private async void Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        //    string personData = person.Name + " is " + person.Age + " years old.";
        //    // In v3, the factory method is slightly different
        //    var box = MessageBoxManager.GetMessageBoxStandard(
        //        "Person Info",
        //        personData,
        //        ButtonEnum.Ok);

        //    await box.ShowAsync();

        var selectedItems = ListBoxPeople.SelectedItems ?? new List<object>();
        foreach (var item in selectedItems)
        {
            var person = (Person)item;
            var box = MessageBoxManager.GetMessageBoxStandard(
         "Person Info",
         $"Name: {person.Name}, Age: {person.Age}",
         ButtonEnum.Ok);
            await box.ShowAsync();
        }


    }
}
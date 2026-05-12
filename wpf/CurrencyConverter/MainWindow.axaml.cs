using System.Collections.Generic;
using Avalonia.Controls;
using System;
using Avalonia.Input;
using Avalonia.Interactivity;
using types;
using MsBox.Avalonia;
using MsgIcon = MsBox.Avalonia.Enums.Icon;
using MsBox.Avalonia.Enums;

namespace CurrencyConverter;

public partial class MainWindow : Window
{

    public List<Currency> Currencies { get; set; } = new();
    public Currency? SelectedCurrency { get; set; }
    public MainWindow()
    {
        BindCurrency();
        DataContext = this;
        InitializeComponent();
    }


    // ...

    private async void Convert_Click(object? sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtCurrency.Text))
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Information", "Please Enter Currency", ButtonEnum.Ok, MsgIcon.Info);
            await box.ShowAsync();
            txtCurrency.Focus();
            return;
        }

        if (cmbFromCurrency.SelectedIndex <= 0 || cmbFromCurrency.SelectedItem is not Currency fromCurrency)
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Information", "Please Select Currency From", ButtonEnum.Ok, MsgIcon.Info);
            await box.ShowAsync();
            cmbFromCurrency.Focus();
            return;
        }

        if (cmbToCurrency.SelectedIndex <= 0 || cmbToCurrency.SelectedItem is not Currency toCurrency)
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Information", "Please Select Currency To", ButtonEnum.Ok, MsgIcon.Info);
            await box.ShowAsync();
            cmbToCurrency.Focus();
            return;
        }

        if (!double.TryParse(txtCurrency.Text, out double amount))
        {
            var box = MessageBoxManager.GetMessageBoxStandard("Error", "Invalid Amount", ButtonEnum.Ok, MsgIcon.Error);
            await box.ShowAsync();
            return;
        }

        double fromValue = (double)fromCurrency.Value;
        double toValue = (double)toCurrency.Value;

        double convertedValue = cmbFromCurrency.SelectedIndex == cmbToCurrency.SelectedIndex
            ? amount
            : (fromValue * amount) / toValue;

        lblCurrency.Content = $"{toCurrency.Text} {convertedValue:N3}";
    }

    private void BindCurrency()
    {


        /*   // Create a table wpm
          DataTable dtCurrency = new DataTable();
          dtCurrency.Columns.Add("Text");
          dtCurrency.Columns.Add("Value");

          // CReate rows in the database
          dtCurrency.Rows.Add("--SELECT--", 0);
          dtCurrency.Rows.Add("INR", 1);
          dtCurrency.Rows.Add("USD", 75);
          dtCurrency.Rows.Add("EUR", 85);
          dtCurrency.Rows.Add("SAR", 20);
          dtCurrency.Rows.Add("POUND", 5);
          dtCurrency.Rows.Add("DEM", 43);

          // APPEND DATA TO THE TABLE

          cmbFromCurrency.ItemsSource = dtCurrency.DefaultView; */

        Currencies = new List<Currency>
        {
            new() { Text = "--SELECT--", Value = 0 },
            new() { Text = "INR",   Value = 1 },
            new() { Text = "USD",   Value = 75 },
            new() { Text = "EUR",   Value = 85 },
            new() { Text = "SAR",   Value = 20 },
            new() { Text = "POUND", Value = 5 },
            new() { Text = "DEM",   Value = 43 },
        };


    }

    private void Clear_Click(object? sender, RoutedEventArgs e)
    {

    }

    private void NumberValidationTextBox(object? sender, KeyEventArgs e)
    {
    }
}

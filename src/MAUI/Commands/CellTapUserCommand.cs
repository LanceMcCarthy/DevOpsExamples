using CommonHelpers.Models;
using System.Collections;
using System.Diagnostics;
using Telerik.Maui.Controls.DataGrid;
using WinUIEx.Messaging;

namespace MauiDemo.Commands;

public class CellTapUserCommand : DataGridCommand
{
    public CellTapUserCommand()
    {
        Id = DataGridCommandId.CellTap;
    }
    public override bool CanExecute(object parameter)
    {
        return true;
    }
    public override void Execute(object parameter)
    {
        if (parameter is not DataGridCellInfo context)
            return;

        var cellValue = context.Value;
        var cellColumn = context.Column;
        var rowValue = context.Item as Employee;

        var dv = cellColumn.DataGrid.GetDataView();

        var index = 0;

        if (dv.Items is IList list)
        {
            index = list.IndexOf(context.Item);
        }
        else
        {
            // Fallback: convert to list and search, or handle groupings, etc
            var itemsList = dv.Items.ToList();
            index = itemsList.IndexOf(rowValue);



        }

        var message = $"You tapped on {cellValue} inside {context.Column.HeaderText} column, which is index {index}!";

        Debug.WriteLine(message);

        App.Current?.MainPage?.DisplayAlert("CellTap Command: ", message, "OK");

        this.Owner.CommandService.ExecuteDefaultCommand(DataGridCommandId.CellTap, parameter);
    }
}
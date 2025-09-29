using CommonHelpers.Models;
using System.Collections;
using Telerik.Maui.Controls.DataGrid;

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
        if (parameter is not DataGridCellInfo { Item: Employee rowValue } context)
            return;

        var dv = context.Column.DataGrid.GetDataView();

        int index;

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

        Owner.CommandService.ExecuteDefaultCommand(DataGridCommandId.CellTap, parameter);

        Shell.Current.DisplayAlert("CellTap Command: ", $"You tapped on {context.Value} inside {context.Column.HeaderText} column, which is index {index}!", "OK");
    }
}
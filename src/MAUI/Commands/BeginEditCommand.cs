using System.Diagnostics;
using Telerik.Maui.Controls.DataGrid;

namespace MauiDemo.Commands;

public class BeginEditCommand : DataGridCommand
{
    public BeginEditCommand()
    {
        Id = DataGridCommandId.BeginEdit;
    }

    public override void Execute(object parameter)
    {
        if (parameter is not EditContext context) 
            return;

        Owner.CommandService.ExecuteDefaultCommand(DataGridCommandId.BeginEdit, parameter);

        Debug.WriteLine($"BeginEdit on: {context.CellInfo.Value} via {context.TriggerAction}.");
    }
}
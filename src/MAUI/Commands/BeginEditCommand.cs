using System.Diagnostics;
using Telerik.Maui.Controls.DataGrid;

namespace MauiDemo.Commands;

public class BeginEditCommand : DataGridCommand
{
    public BeginEditCommand()
    {
        this.Id = DataGridCommandId.BeginEdit;
    }

    public override void Execute(object parameter)
    {
        if (parameter is EditContext context)
        {
            Debug.WriteLine($"BeginEdit on: {context.CellInfo.Value} via {context.TriggerAction}.");

            this.Owner.CommandService.ExecuteDefaultCommand(DataGridCommandId.BeginEdit, parameter);
        }
    }
}
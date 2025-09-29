using System.Diagnostics;
using Telerik.Maui.Controls.DataGrid;

namespace MauiDemo.Commands;

public class CommitEditCommand : DataGridCommand
{
    public CommitEditCommand()
    {
        Id = DataGridCommandId.CommitEdit;
    }

    public override void Execute(object parameter)
    {
        if (parameter is not EditContext context) 
            return;

        Owner.CommandService.ExecuteDefaultCommand(DataGridCommandId.CommitEdit, parameter);

        Debug.WriteLine($"CommitEdit on: {context.CellInfo.Value} via {context.TriggerAction}.");
    }
}
using System.Diagnostics;
using Telerik.Maui.Controls.DataGrid;

namespace MauiDemo.Commands;

public class CommitEditCommand : DataGridCommand
{
    public CommitEditCommand()
    {
        this.Id = DataGridCommandId.CommitEdit;
    }

    public override void Execute(object parameter)
    {
        if (parameter is EditContext context)
        {
            Debug.WriteLine($"CommitEdit on: {context.CellInfo.Value} via {context.TriggerAction}.");

            this.Owner.CommandService.ExecuteDefaultCommand(DataGridCommandId.CommitEdit, parameter);
        }
    }
}
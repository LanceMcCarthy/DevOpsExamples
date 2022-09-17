using System.IO;
using Telerik.WinForms.Controls.SyntaxEditor.Taggers;
using Telerik.WinForms.SyntaxEditor.Core.Text;

namespace MyWinFormsApp
{
    public partial class RadForm1 : Telerik.WinControls.UI.RadForm
    {
        public RadForm1()
        {
            InitializeComponent();

            using (StreamReader reader = new StreamReader("CS_File.txt"))
            {
                this.radSyntaxEditor1.Document = new TextDocument(reader);
            }
            
            var tagger = new CSharpTagger(this.radSyntaxEditor1.SyntaxEditorElement);
            this.radSyntaxEditor1.TaggersRegistry.RegisterTagger(tagger);
        }
    }
}

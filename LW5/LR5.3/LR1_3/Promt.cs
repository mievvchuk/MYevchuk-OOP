using System.Windows.Forms;

namespace LR1_3
{
    public static class Prompt
    {
        // Повертає введений рядок або null при Cancel
        public static string ShowDialog(string text, string caption)
        {
            Form prompt = new Form()
            {
                Width = 420,
                Height = 150,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                Text = caption,
                StartPosition = FormStartPosition.CenterParent,
                MinimizeBox = false,
                MaximizeBox = false
            };

            Label textLabel = new Label() { Left = 10, Top = 10, Width = 380, Text = text };
            TextBox textBox = new TextBox() { Left = 10, Top = 35, Width = 380 };

            Button confirmation = new Button() { Text = "OK", Left = 220, Width = 80, Top = 70, DialogResult = DialogResult.OK };
            Button cancel = new Button() { Text = "Cancel", Left = 310, Width = 80, Top = 70, DialogResult = DialogResult.Cancel };

            confirmation.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(cancel);
            prompt.Controls.Add(textLabel);
            prompt.AcceptButton = confirmation;
            prompt.CancelButton = cancel;

            var dialogResult = prompt.ShowDialog();
            if (dialogResult == DialogResult.OK)
                return textBox.Text;
            else
                return null;
        }
    }
}

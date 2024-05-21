using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactForm
{
    // ileride herhangi bir  kutucuk içerisine bilgilendirme yapmak istersem kod maliyetinden kurtulmak için burada ayrı bir class oluşturdum.
    
    internal class PlaceHolderManager
    {

        private readonly Control control; // burada tüm kontrollere erişmem gerek yoksa textbox için ayrı combobox için ayrı bir yapı kullanmak zorunda kalırım.
        private readonly Label placeholderLabel;
        
        
        public PlaceHolderManager(Control control, string placeholderText) 
        {
            this.control = control;
            placeholderLabel = new Label();
            placeholderLabel.Text = placeholderText;
            placeholderLabel.ForeColor = Color.Gray;
            placeholderLabel.BackColor = Color.White;
            placeholderLabel.AutoSize = true;
            placeholderLabel.Location = new Point(control.Left + 3, control.Top + 2);
            placeholderLabel.Size = new Size(control.Width - 6, control.Font.Height);
            placeholderLabel.MouseClick += PlaceholderLabel_MouseClick;

            
            control.Parent.Controls.Add(placeholderLabel);
            placeholderLabel.BringToFront();
            

            
            control.TextChanged += TextBox_TextChanged;

            
            CheckPlaceholder();
        }


        private void TextBox_TextChanged(object sender, EventArgs e)
        {
            CheckPlaceholder();
        }


        private void PlaceholderLabel_MouseClick(object sender, MouseEventArgs e)
        {
            control.Focus();
        }

        private void CheckPlaceholder()
        {
            
            placeholderLabel.Visible = string.IsNullOrWhiteSpace(control.Text);
        }
    }
}


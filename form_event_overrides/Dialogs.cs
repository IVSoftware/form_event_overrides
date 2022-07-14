using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace form_event_overrides
{
    public partial class Dialogs : Form
    {
        public Dialogs()
        {
            InitializeComponent();
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e); // <== The `Load` event you were subscribing to is fired here.
            listBox1.Items.Add("Oranges");
            listBox1.Items.Add("Grapes");
            listBox1.Items.Add("Bananas");
            listBox1.Items.Add("Peaches");
            button1.Click += onButton1Clicked;
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e); // <== The `Closing` event you were subscribing to is fired here.
            var msg = "Are you sure you want to close?";

            if (MessageBox.Show(msg, this.Text, MessageBoxButtons.YesNo) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
        private void onButton1Clicked(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                var msg = "Please select an item from the list box";
                MessageBox.Show(msg, this.Text);
                return;
            }
            else
            {
                label1.Text = listBox1.Text;
            }
        }
    }
}

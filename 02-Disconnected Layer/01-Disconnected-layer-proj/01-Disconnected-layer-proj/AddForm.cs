using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj
{
    public partial class AddForm : FullUserInfoForm
    {
        public AddForm()
        {
            InitializeComponent();

            buttonEdit.Enabled = false;
            buttonEdit.Visible = false;
            buttonEditted.Enabled = false;
            buttonEditted.Visible = false;
            buttonDelete.Enabled = false;
            buttonDelete.Visible = false;

        }
    }
}

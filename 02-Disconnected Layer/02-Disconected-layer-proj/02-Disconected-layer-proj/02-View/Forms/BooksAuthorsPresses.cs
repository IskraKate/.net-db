using _02_Disconected_layer_proj._02_View.Interfaces;
using System;
using System.Windows.Forms;

namespace _02_Disconected_layer_proj
{
    public partial class MainForm : Form, IView
    {
        public ComboBox ComboBoxAuthors { get; set; }
        public ComboBox ComboBoxPresses { get; set; }
        public ListBox ListBoxBooks { get; set; }

        public bool CanSearch { get; set; }


        public event EventHandler ViewEvent;
        public event SearchHandler SearchEvent;

        public MainForm()
        {
            InitializeComponent();

            comboBoxAuthors.Enabled = false;
            comboBoxPresses.Enabled = false;
        }

        private void CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;

            ComboBox comboBox = checkBox.Parent.Controls[0] as ComboBox;

            if (checkBox.Checked)
            {
                comboBox.Enabled = true;
            }
            else
            {
                comboBox.Enabled = false;
                comboBox.SelectedItem = null;
            }
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //Вариант когда есть выбранный элемент
            if (comboBoxAuthors.SelectedItem != null)
            {
                CanSearch = true;
            }
            else
            {
                //Вариант когда комбобокс с авторами активен,
                //автор не выбран,
                //комбобокс с издательствами не активен.
                if (comboBoxAuthors.Enabled && !comboBoxPresses.Enabled)
                {
                    MessageBox.Show("Choose author, please", "Author?",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CanSearch = false;
                }

                //Вариант, когда оба комбобса не активны,
                //но кнопка искать нажата
                if (!comboBoxAuthors.Enabled && !comboBoxPresses.Enabled)
                {
                    CanSearch = false;
                }
            }

            //Вариант, когда есть выбранный элемент
            if (comboBoxPresses.SelectedItem != null)
            {

                CanSearch = true;
            }
            else
            {
                //Вариант когда комбобокс с издательствами активен,
                //издательство не выбрано,
                //комбобокс с авторами не активен.
                if (comboBoxPresses.Enabled && !comboBoxAuthors.Enabled)
                {
                    MessageBox.Show("Choose author, please", "Press?",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CanSearch = false;
                }

                //Вариант, когда оба комбобокса активны, но элементы не выбраны
                else if (comboBoxPresses.Enabled && comboBoxAuthors.Enabled)
                {
                    MessageBox.Show("Choose press and author, please", "Press and author?",
                                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    CanSearch = false;
                }
            }

            Search();
        }

        private void Search()
        {
            if (CanSearch)
            {
                SearchEvent?.Invoke();
            }
        }

        private void MainForm_Load(object sender, System.EventArgs e)
        {
            ComboBoxAuthors = comboBoxAuthors;
            ComboBoxPresses = comboBoxPresses;
            ListBoxBooks = listBoxBooks;

            ViewEvent?.Invoke(this, EventArgs.Empty);
        }
    }
}

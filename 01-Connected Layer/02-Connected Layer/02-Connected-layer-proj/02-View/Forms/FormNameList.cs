using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment._03_Presenter;
using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormNameList : Form, IView, IDispose
    {
        public event EventHandler ViewEvent;
        public event DeleteHandler DeleteEvent;
        public event FormClosedEventHandler FormClosedEvent;

        public FormNameList()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addPerson = new FormAddPerson(this);
            var addListPresenter = new AddPersonPresenter(addPerson, Model.GetModel());

            addPerson.ShowDialog();

            ViewEvent?.Invoke(this, EventArgs.Empty);
        }

        private void listViewNames_MouseDoubleClick(object sender, EventArgs e)
        {
            if (listViewNames.SelectedItems.Count > 0)
            {
                var formAllInfo = new FormAllInfo(listViewNames.SelectedIndices[0]);
                formAllInfo.ShowDialog();
            }

            ViewEvent?.Invoke(this, EventArgs.Empty);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewNames.SelectedItems.Count > 0)
            {
                DeleteEvent?.Invoke(listViewNames.SelectedIndices[0]);
            }
        }

        private void FormNameList_Load(object sender, EventArgs e)
        {
            ViewEvent?.Invoke(listViewNames, EventArgs.Empty);
        }

        private void FormNameList_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, e);
        }
    }
}

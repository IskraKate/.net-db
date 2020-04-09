using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment._03_Presenter;
using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormNameList : Form, IView, IDelete, IDispose
    {
        public event EventHandler ViewEvent;
        public event DeleteHandler DeleteEvent;
        public event FormClosedEventHandler FormClosedEvent;

        public List<PersonInfo> PersonInfo { get; set; }


        public FormNameList()
        {
            InitializeComponent();
        }

        public void FillListView()
        {
            listViewNames.Items.Clear();

            foreach (var info in PersonInfo)
            {
                ListViewItem listViewItem = listViewNames.Items.Add(new ListViewItem());
                listViewItem.Text = info.FirstName + ' ' + info.LastName + ' ' + info.Patronymic;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addPerson = new FormAddPerson(this);
            var addListPresenter = new AddPersonPresenter(addPerson, Model.GetModel());

            addPerson.ShowDialog();

            ViewEvent?.Invoke(this, EventArgs.Empty);

            FillListView();
        }

        private void listViewNames_MouseDoubleClick(object sender, EventArgs e)
        {
            if (listViewNames.SelectedItems.Count > 0)
            {
                var formAllInfo = new FormAllInfo(this, PersonInfo, listViewNames.SelectedIndices[0]);
                var editPersonPresenter = new EditPersonPresenter(formAllInfo, Model.GetModel());

                formAllInfo.ShowDialog();
            }

            ViewEvent?.Invoke(this, EventArgs.Empty);

            FillListView();

        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listViewNames.SelectedItems.Count > 0)
            {
                DeleteEvent(PersonInfo[listViewNames.SelectedIndices[0]].Id);
                PersonInfo.RemoveAt(listViewNames.SelectedIndices[0]);
                listViewNames.SelectedItems[0].Remove();
            }
        }

        private void FormNameList_Load(object sender, EventArgs e)
        {
            ViewEvent?.Invoke(this, EventArgs.Empty);
            FillListView();
        }

        private void FormNameList_FormClosed(object sender, FormClosedEventArgs e)
        {
            FormClosedEvent?.Invoke(this, e);
        }
    }
}

using HumanResourcesDepartment.ModelNamespace;
using HumanResourcesDepartment.View;
using System;
using System.Windows.Forms;

namespace HumanResourcesDepartment
{
    public partial class FormNameList : Form, IView
    {
        ListViewItem listViewItem;

        public event AddHandler AddEvent;
        public event EditHandler EditEvent;
        public event GetPersonHandler GetPersonEvent;
        public event DeleteHandler DeleteEvent;
        public event FormClosingEventHandler FormClosingEvent;

        public ListViewItem GetListViewItem
        {
            get
            {
                return listViewItem;
            }
        }

        public ListView GetListView
        {
            get
            {
                return listViewNames;
            }
        }

        public FormNameList()
        {
            InitializeComponent();
            this.FormClosing += FormNameList_FormClosing;
        }

        public void NewListViewItem()
        {
            listViewItem = listViewNames.Items.Add(new ListViewItem());
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            var addPerson = new AddPerson(this);
            addPerson.ShowDialog();
        }

        public void AddPerson(PersonInfo personInfo)
        {
            AddEvent(personInfo);
        }

        public void personInfoEddited_FormAllInfo(PersonInfo personInfoEdited)
        {
            EditEvent(personInfoEdited);
        }

        private void listViewNames_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (listViewNames.SelectedItems.Count > 0)
            {
                var formAllInfo = new FormAllInfo(this, GetPersonEvent(listViewNames.SelectedIndices[0]));
                formAllInfo.ShowDialog();
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if(listViewNames.SelectedItems.Count > 0)
             DeleteEvent(listViewNames.SelectedIndices[0]);
        }

        private void FormNameList_FormClosing(object sender, FormClosingEventArgs e)
        {
            FormClosingEvent(sender, e);
        }
    }
}

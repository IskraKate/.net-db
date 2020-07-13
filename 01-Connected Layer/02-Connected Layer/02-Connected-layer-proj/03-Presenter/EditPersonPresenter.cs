using HumanResourcesDepartment._02_View;
using HumanResourcesDepartment.ModelNamespace;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace HumanResourcesDepartment._03_Presenter
{
    class EditPersonPresenter
    {
       int _index;
       private IViewAllInfo _viewAllInfo;
       private IModel _model;
       private List<PersonInfo> _infos;

        public EditPersonPresenter(IViewAllInfo viewAllInfo, IModel model)
        {
            _viewAllInfo = viewAllInfo;
            _model = model;
            _viewAllInfo.ViewAllInfoEvent += FillTextBoxes;
            _viewAllInfo.EditedEvent += EditedInfo;
            _infos = _model.GetInfo();
        }

        public void FillTextBoxes(TextBox name, TextBox surname, TextBox patronymic,
        TextBox contractNum, TextBox dismissalNum, DateTimePicker birthday, PictureBox photo, int index)
        {
            _index = index;

            name.Text = _infos[_index].FirstName;
            surname.Text = _infos[_index].LastName;
            patronymic.Text = _infos[_index].Patronymic;
            contractNum.Text = _infos[_index].ContractNumber.ToString();
            dismissalNum.Text = _infos[_index].DismissalNumber.ToString();
            birthday.Value = _infos[_index].Birthday;

            if (!String.IsNullOrEmpty(_infos[_index].PhotoPath) && File.Exists(_infos[_index].PhotoPath))
            {
                photo.Image = new Bitmap(_infos[_index].PhotoPath);
            }

            birthday.Format = DateTimePickerFormat.Custom;

            if (!string.IsNullOrEmpty(_infos[_index].PhotoPath))
            {
                if (File.Exists(_infos[_index].PhotoPath))
                    photo.Image = new Bitmap(_infos[_index].PhotoPath);
            }
        }

        public void EditedInfo(string name, string surname, string patronymic,
        int contractNum, int dismissalNum, DateTime birthday, string path)
        {
            _infos[_index].FirstName = name;
            _infos[_index].LastName = surname;
            _infos[_index].Patronymic = patronymic;
            _infos[_index].ContractNumber = contractNum;
            _infos[_index].DismissalNumber = dismissalNum;
            _infos[_index].Birthday = birthday;

            if (!String.IsNullOrEmpty(path))
            _infos[_index].PhotoPath = path;

            _model.EditPerson(_infos, _index);
        }
    }
}

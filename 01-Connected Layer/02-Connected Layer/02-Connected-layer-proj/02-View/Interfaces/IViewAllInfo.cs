using System;
using System.Windows.Forms;

namespace HumanResourcesDepartment._02_View
{
    public delegate void ViewAllInfoHandler(TextBox name, TextBox surname, TextBox patronymic,
        TextBox contractNum, TextBox DismissalNum, DateTimePicker birthday, PictureBox photo, int index);

    public delegate void EditedHandler(string name, string surname, string patronymic,
        int contractNum, int DismissalNum, DateTime birthday, string path);
    public interface IViewAllInfo
    {
        event ViewAllInfoHandler ViewAllInfoEvent;
        event EditedHandler EditedEvent;
    }
}

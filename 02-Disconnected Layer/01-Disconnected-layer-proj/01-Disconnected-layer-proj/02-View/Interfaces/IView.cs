using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace _01_Disconnected_layer_proj._02_View
{
    //public delegate User GetUserHandler(int index);
    //public delegate void CheckChangedHandler();
    //public delegate void AddUserHandler(User user);
    //public delegate void EditUserHandler(User user);
    //public delegate void DeleteUserHandler(User user);
    //public delegate bool CheckUniqueHandler (string login);

    interface IView
    {
        event EventHandler ViewEvent;

        List<User> UserList { get; set; }
        //ListBox ListBoxUser { get; }
        //CheckBox CheckBoxAdmin { get; }
        //event GetUserHandler GetUserEvent;
        //event CheckChangedHandler CheckChangedEvent;
        //event AddUserHandler AddUserEvent;
        //event EditUserHandler EditUserEvent;
        //event DeleteUserHandler DeleteUserEvent;
        //event FormClosedEventHandler FormClosed;
        //event CheckUniqueHandler CheckUniqueEvent;
    }
}

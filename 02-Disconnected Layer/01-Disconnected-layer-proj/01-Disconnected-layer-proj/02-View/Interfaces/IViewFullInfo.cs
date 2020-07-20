namespace _01_Disconnected_layer_proj._02_View.Interfaces
{
    public delegate void ViewHandler(int index);
    public delegate void EditHandler();

    interface IViewFullInfo
    {
        event ViewHandler ViewEvent;
        event EditHandler EditEvent;
        string Login { get; set; }
        string Password { get; set; }
        string Email { get; set; }
        bool IsAdmin { get; set; }
        string  Telephone { get; set; }

        bool LoginChecked { get; set; }
    }
}

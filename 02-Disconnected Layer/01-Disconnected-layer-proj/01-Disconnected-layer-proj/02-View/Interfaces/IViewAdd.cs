namespace _01_Disconnected_layer_proj._02_View.Interfaces
{
    public delegate void AddHandler();
    interface IViewAdd
    {
        event AddHandler AddEvent;
    }
}

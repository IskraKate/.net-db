namespace _03_Disconnected_layer_proj._02_View.Interfaces
{
    public delegate void SaveHandler();
    interface ISave
    {
        event SaveHandler SaveEvent;
    }
}

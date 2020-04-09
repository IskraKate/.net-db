namespace HumanResourcesDepartment._02_View
{
    public delegate void DeleteHandler(int index);

    interface IDelete
    {
        event DeleteHandler DeleteEvent;
    }
}

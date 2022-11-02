namespace Sport.Models.Interfaces
{
    interface IActive
    {
        bool IsActive { get; }

        void Activate();
        void Inactivate();
    }
}

namespace ExampleLifecycleDI.Interfaces
{
    public interface ITransientService
    {
        Guid GetOperationID();
        int GetId();
        void SetId(int id);
    }
}
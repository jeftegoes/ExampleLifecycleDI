namespace ExampleLifecycleDI.Interfaces
{
    public interface ISingletonService
    {
        Guid GetOperationID();
        int GetId();
        void SetId(int id);
    }
}
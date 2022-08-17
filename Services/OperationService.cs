using ExampleLifecycleDI.Interfaces;

namespace ExampleLifecycleDI.Services
{
    public class OperationService : ITransientService, IScopedService, ISingletonService
    {
        private Guid _idGuid;
        private int _id;

        public OperationService()
        {
            _idGuid = Guid.NewGuid();
        }

        public Guid GetOperationID()
        {
            return _idGuid;
        }

        public void SetId(int id)
        {
            _id = id;
        }

        public int GetId()
        {
            return _id;
        }
    }
}
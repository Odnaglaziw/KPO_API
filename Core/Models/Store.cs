namespace Core.Models
{
    public class Store
    {
        private Store(int id, string address)
        {
            Id = id;
            Address = address;
        }
        public int Id { get; }
        public string Address { get; } = string.Empty;
        static public (Store Store, string Error) Create(int id, string address)
        {
            var error = string.Empty;

            //if

            var store = new Store(id, address);

            return (store, error);
        }
    }
}

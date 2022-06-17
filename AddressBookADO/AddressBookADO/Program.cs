namespace AddressBookADO
{
    public class Program
    {
        public static void Main(string[] args)
        {
            AddressBookDetail addressBookDetail = new AddressBookDetail();
            addressBookDetail.EstablishConnection();
            addressBookDetail.CloseConnection();
        }
    }
}
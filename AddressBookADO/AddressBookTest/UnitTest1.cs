using NUnit.Framework;
using AddressBookADO;

namespace AddressBookTest
{
    public class Tests
    {
        AddressBook address;
        AddressBookDetail addressBookDetail;
        [SetUp]
        public void Setup()
        {
            address = new AddressBook();
            addressBookDetail = new AddressBookDetail();
        }
        //<summary>
        //UC2 : Insert Details
        //</summary>
        [Test]
        public void Inserting_AddressBook_Details()
        {
            int expected = 1;
            address.FirstName = "Hailey";
            address.LastName = "bieber";
            address.Address = "street 404";
            address.City = "Binghamton";
            address.State = "Neywork";
            address.Zip = 245673;
            address.PhoneNumber = 8375737394;
            address.Email = "hailey@gmail.com";
            var actual = addressBookDetail.InsertAddressData(address);
            Assert.AreEqual(expected, actual);
        }
        //<summary>
        //TC 3 : Retrieve Details
        //</summary>
        [Test]
        public void Retrive_AddressBook_Details()
        {
            int expected = 4;
            var result = addressBookDetail.RetrieveAddressBookDetails();
            Assert.AreEqual(expected, result.Count);
        }
    }
}
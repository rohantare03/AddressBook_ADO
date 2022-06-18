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
        //TC2 : Insert Details
        //</summary>
        [Test]
        public void Inserting_AddressBook_Details()
        {
            int expected = 1;
            address.FirstName = "Hailes";
            address.LastName = "bieber";
            address.Address = "street 404";
            address.City = "Binghamton";
            address.State = "Neywork";
            address.Zip = 654567;
            address.PhoneNumber = 8375737394;
            address.Email = "hailey123@gmail.com";
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
        //<summary>
        //TC 4 : Update Details
        //</summary>
        [Test]
        public void UpdatingEmployeeDetails()
        {
            bool expected = true;
            address.ID = 4;
            address.FirstName = "Hades";
            address.LastName = "Death";
            address.Address = "Miami";
            address.City = "Havanas";
            address.State = "Florida";
            address.Zip = 340045;
            address.PhoneNumber = 8805320078;
            address.Email = "hades@gmail.com";
            bool result = addressBookDetail.UpdateDetails(address);
            Assert.AreEqual(expected, result);
        }
    }
}
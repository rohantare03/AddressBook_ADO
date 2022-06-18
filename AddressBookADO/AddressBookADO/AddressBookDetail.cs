using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AddressBookADO
{
    public class AddressBookDetail
    {
        static string connectionString = @"Data Source = (localdb)\MSSQLLocalDB; Initial Catalog = AddressBook; Integrated Security = SSPI";
        static SqlConnection connection = new SqlConnection(connectionString);

        public void EstablishConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Closed))
            {
                try
                {
                    connection.Open();
                }
                catch (Exception)
                {
                    throw new AddressException(AddressException.ExceptionType.CONNECTION_FAILED, "Connection not found");
                }
            }
        }
        public void CloseConnection()
        {
            if (connection != null && connection.State.Equals(ConnectionState.Open))
            {
                try
                {
                    connection.Close();
                }
                catch (Exception)
                {
                    throw new AddressException(AddressException.ExceptionType.CONNECTION_FAILED, "Connection not found");
                }
            }
        }
        public int InsertAddressData(AddressBook address)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("Add_Details", connection)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    command.Parameters.AddWithValue("@FirstName", address.FirstName);
                    command.Parameters.AddWithValue("@LastName", address.LastName);
                    command.Parameters.AddWithValue("@Address", address.Address);
                    command.Parameters.AddWithValue("@City", address.City);
                    command.Parameters.AddWithValue("@State", address.State);
                    command.Parameters.AddWithValue("@Zip", address.Zip);
                    command.Parameters.AddWithValue("@PhoneNumber", address.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", address.Email);
                    var returnParameter = command.Parameters.Add("@new_identity", SqlDbType.Int);
                    returnParameter.Direction = ParameterDirection.ReturnValue;
                    Console.WriteLine(address.FirstName + "," + address.LastName + "," + address.Address + "," + address.City + "," + address.State + "," + address.Zip + "," + address.PhoneNumber + "," + address.Email);
                    command.ExecuteNonQuery();
                    connection.Close();
                    var result = returnParameter.Value;
                    return (int)result;
                    Console.WriteLine("Contact is added");
                }
            }
            catch (Exception)
            {
                throw new AddressException(AddressException.ExceptionType.INSERTION_ERROR, "Insertion failed");
            }
            return 0;
        }
        public List<AddressBook> RetrieveAddressBookDetails()
        {
            List<AddressBook> list = new List<AddressBook>();
            AddressBook address = new AddressBook();
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                using (connection)
                {
                    SqlCommand command = new SqlCommand("RetrieveDetails", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    //command.Parameters.AddWithValue("@ID", address.ID);
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    if (reader.HasRows)
                    {
                        while (reader.Read())
                        {
                            address.ID = reader.GetInt32(0);
                            address.FirstName = reader.GetString(1);
                            address.LastName = reader.GetString(2);
                            address.Address = reader.GetString(3);
                            address.City = reader.GetString(4);
                            address.State = reader.GetString(5);
                            address.Zip = reader.GetInt64(6);
                            address.PhoneNumber = reader.GetInt64(7);
                            address.Email = reader.GetString(8);
                            list.Add(address);
                            Console.WriteLine(address.ID + "," + address.FirstName + "," + address.LastName + "," + address.Address + "," + address.City + ","
                                + address.State + "," + address.Zip + "," + address.PhoneNumber + "," + address.Email);
                        }
                    }
                    connection.Close();
                }
            }
            catch (Exception)
            {
                throw new AddressException(AddressException.ExceptionType.CONTACT_NOT_FOUND, "Contact not found");
            }
            return list;
        }
    }
}

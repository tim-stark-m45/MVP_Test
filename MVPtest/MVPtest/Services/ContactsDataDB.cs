using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVPtest.Model;

namespace MVPtest.Services
{
    class ContactsDataDB : IContactsData
    {
        public List<Contact> Contacts { get; set; }
        private  string connectionString = @"Data Source=HPTIMKA;Initial Catalog=ContactApp;Integrated Security=True";

        public void AddContact(Contact contact)
        {
            
        }

        public void DeleteContact(int id)
        {
            
        }

        public void Load()
        {
            //string sql = "SELECT * FROM Contacts";
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    connection.Open();
            //    SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
            //    // Создаем объект Dataset
            //    DataSet ds = new DataSet();
            //    // Заполняем Dataset
            //    adapter.Fill(ds);
            //    // Отображаем данные
            //    dataGridViewContacts.DataSource = ds.Tables[0];
            //}
        }

        public void Save()
        {
            
        }
    }
}



//Sql Injection
//public void AddContact(Contact contact)
//{
//    string sqlExpression = "INSERT INTO Contacts VALUES (@name, @surname, @phone)";
//    using (SqlConnection connection = new SqlConnection(connectionString))
//    {
//        connection.Open();
//        SqlCommand command = new SqlCommand(sqlExpression, connection);

//        SqlParameter nameParam = new SqlParameter("@name", contact.Name);
//        command.Parameters.Add(nameParam);
//        SqlParameter surnameParam = new SqlParameter("@surname", contact.Surname);
//        command.Parameters.Add(surnameParam);
//        SqlParameter phoneParam = new SqlParameter("@phone", contact.Phone);
//        command.Parameters.Add(phoneParam);

//        int number = command.ExecuteNonQuery();
//        Console.WriteLine("Добавлено объектов: {0}", number);
//    }
//}
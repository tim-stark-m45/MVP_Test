using MVPtest.Model;
using MVPtest.Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MVPtest.View
{
    public partial class ContactsForm : Form, IContactsForm
    {
        private Contact newContact;
        private ContactsFormPresenter presenter;
        DataSet ds;
        DataTable dt;

        public ContactsForm()
        {
            InitializeComponent();

            presenter = new ContactsFormPresenter(this);
        }

        public Contact Contact
        {
            get
            {
                newContact = new Contact();
                newContact.Name = textBoxName.Text;
                newContact.Surname = textBoxSurname.Text;
                newContact.Phone = textBoxPhone.Text;
                return newContact;
            }
            set
            {
                newContact = value;
                textBoxName.Text = value.Name;
                textBoxSurname.Text = value.Surname;
                textBoxPhone.Text = value.Phone;
            }
        }

        public void UpdateList()
        {
            //listBoxContacts.DataSource = null;
            //listBoxContacts.DataSource = presenter.GetContacts();
        }

        private void ClearForm()
        {
            newContact = null;
            textBoxName.Text = "";
            textBoxSurname.Text = "";
            textBoxPhone.Text = "";
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    presenter.AddContact(Contact);
            //    ClearForm();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            string connectionString = @"Data Source=HPTIMKA;Initial Catalog=ContactApp;Integrated Security=True";
            string sql = "SELECT * FROM Contacts";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds);

                dt = ds.Tables[0];
                // добавим новую строку
                DataRow newRow = dt.NewRow();
                newRow["Name"] = Contact.Name;
                newRow["Surname"] = Contact.Surname;
                newRow["Phone"] = Contact.Phone;
                dt.Rows.Add(newRow);

                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                adapter.Update(ds);
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            //if (listBoxContacts.SelectedIndex != -1)
            //    presenter.DeleteContact(listBoxContacts.SelectedIndex);

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("About");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //presenter.Save();

            string connectionString = @"Data Source=HPTIMKA;Initial Catalog=ContactApp;Integrated Security=True";
            string sql = "SELECT * FROM Contacts";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                SqlCommandBuilder commandBuilder = new SqlCommandBuilder(adapter);

                adapter.Update(ds);
            }
        }

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //presenter.Load();

            string connectionString = @"Data Source=HPTIMKA;Initial Catalog=ContactApp;Integrated Security=True";
            string sql = "SELECT * FROM Contacts";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, connection);
                // Создаем объект Dataset
                ds = new DataSet();
                // Заполняем Dataset
                adapter.Fill(ds);
                // Отображаем данные
                dataGridViewContacts.DataSource = ds.Tables[0];
            }
        }
    }
}

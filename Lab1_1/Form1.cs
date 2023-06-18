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

namespace Lab1_1
{
    public partial class Form1 : Form
    {
        static string connectionString = @"Data Source=LOCALHOST\LOCALDATABASE;Database=lab2;Persist Security Info=True;User ID=ADMIN;Password=cisco123";


        public Form1()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'lab2DataSet.Book' table. You can move, or remove it, as needed.
            this.bookTableAdapter.Fill(this.lab2DataSet.Book);
            // TODO: This line of code loads data into the 'lab2DataSet.Author' table. You can move, or remove it, as needed.
            this.authorTableAdapter.Fill(this.lab2DataSet.Author);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)//Add Author
        {
            try
            {
                string sqlExpression = "INSERT INTO Author (Name, Description) Values (@Name, @Description)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    string authorName = textBox1.Text;
                    string authorDescription = textBox2.Text;

                    SqlParameter authorNameParameter = new SqlParameter("@Name", authorName);
                    SqlParameter authorDescriptionParameter = new SqlParameter("@Description", authorDescription);

                    command.Parameters.Add(authorNameParameter);
                    command.Parameters.Add(authorDescriptionParameter);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Occurred error: {ex.Message}");
            }
            finally
            {
                this.authorTableAdapter.Fill(this.lab2DataSet.Author);
            }
        }

        private void button2_Click(object sender, EventArgs e)//Add Book
        {
            try
            {
                string sqlExpression = "INSERT INTO Book (Title, Pages) Values (@Title, @Pages)";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(sqlExpression, connection);

                    string bookTitle = textBox3.Text;
                    int bookPages;
                    if (!Int32.TryParse(textBox4.Text, out bookPages)) bookPages = 3;

                    SqlParameter bookTitleParameter = new SqlParameter("@Title", bookTitle);
                    SqlParameter bookPagesParameter = new SqlParameter("@Pages", bookPages);

                    command.Parameters.Add(bookTitleParameter);
                    command.Parameters.Add(bookPagesParameter);

                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Occurred error: {ex.Message}");
            }
            finally
            {
                this.bookTableAdapter.Fill(this.lab2DataSet.Book);
            }
        }

        private void button3_Click(object sender, EventArgs e)//Add Author and Book
        {

        }

        private void button4_Click(object sender, EventArgs e)//Delete all
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string sqlExpression = "DELETE FROM Author";
                SqlCommand command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();

                sqlExpression = "DELETE FROM Book";
                command = new SqlCommand(sqlExpression, connection);
                command.ExecuteNonQuery();
            }

            this.authorTableAdapter.Fill(this.lab2DataSet.Author);
            this.bookTableAdapter.Fill(this.lab2DataSet.Book);
        }
    }
}

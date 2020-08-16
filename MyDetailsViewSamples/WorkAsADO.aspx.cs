using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Drawing;
using System.Configuration;
using System.Data;

namespace MyDetailsViewSamples
{
    public partial class WorkAsADO : System.Web.UI.Page
    {
        SqlConnection _connection;
        protected void Page_Load(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            _connection = new SqlConnection(connectionString);
            _connection.Open();
        }

        protected void Page_Unload(object sender, EventArgs e)
        {
            if (_connection !=null && _connection.State != ConnectionState.Closed)
            {
                _connection.Close();
            }
        }

        protected void ReadOneValueButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("SELECT Login FROM Users WHERE ID=@ID", _connection);
                // Чтение первой строки и первой колонки (одного значения) из результата который возвращает запрос.
                //ExecuteScalar(); отправляет запрос в базу данных и выбирает первую строчку, которую она выдала.
                command.Parameters.AddWithValue("ID", TextBox1.Text);
                object result = command.ExecuteScalar();
                string login = Convert.ToString(result);

                ReadOneValueOutput.Text = login;
            }
            catch (Exception ex)
            {
                ReadOneValueOutput.Text = "Error:<br />" + ex.Message;
                ReadOneValueOutput.ForeColor = Color.Red;
            }
        }

        protected void ReadAllButton_Click(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            try
            {
                SqlCommand command = new SqlCommand("Select * from Users", _connection);
                string result = string.Empty;

                // Создание объекта для построчного считывания данных из базы.
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    // Получение данных из колонок.
                    result += "ID = " + Convert.ToString(reader["ID"]) + "; ";
                    result += "Login = " + Convert.ToString(reader["Login"]) + "; ";
                    result += "Password = " + Convert.ToString(reader["Password"]);
                    result += "<br />";
                }
                ReadAllOutput.Text = result;
            }
            catch (Exception ex)
            {
                ReadAllOutput.Text = "Error:<br />" + ex.Message;
                ReadAllOutput.ForeColor = Color.Red;
            }
            finally
            {
                // Если reader был открыт освобождаем память, закрывая объект.
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        protected void AddNewEntryButton_Click(object sender, EventArgs e)
        {
            try {
                SqlCommand command = new SqlCommand("Insert Into Users (Login, Password, Email) Values(@Login, @Password, @Email)", _connection);

            // Инициализация переменных в запросе.
            command.Parameters.AddWithValue("Login", LoginTextBox.Text);
            command.Parameters.AddWithValue("Password", PasswordTextBox.Text);
            command.Parameters.AddWithValue("Email", EmailTextBox.Text);

            // Выполнение запроса.
            command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                ErrorOutput.Text = "Error:<br />" + ex.Message;
                ErrorOutput.ForeColor = Color.Red;
            }
}

        protected void RemoveByIdButton_Click(object sender, EventArgs e)
        {
            try
            {
                SqlCommand command = new SqlCommand("Delete From Users Where ID= @UserId",_connection);
                command.Parameters.AddWithValue("UserId", IdToRemoveTextBox.Text);
                int affectedRows = command.ExecuteNonQuery();

                // Добавление в ответ пользователю тега скрипт, в котором с помощью javascript функции alert выводиться сообщение.
                string script = string.Format("alert('Удалено {0} строк');", affectedRows);
                ClientScript.RegisterClientScriptBlock(this.GetType(), "MessageBox", script, true);
            }
            catch (Exception ex)
            {
                ErrorOutput2.Text = "Error:<br />" + ex.Message;
                ErrorOutput2.ForeColor = Color.Red;
            }
        }
    }
}
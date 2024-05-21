using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Data.SqlClient;
namespace ContactForm
{
    public partial class Form1 : Form
    {
        
        private PlaceHolderManager placeHolderManager; // PlaceHolderManager class'ını çağırıyorum.
        public Form1()
        {
            InitializeComponent();
            // kullanıcının girdiği karakterleri kontrol etmek için KeyPress' i tetikliyorum.
            textBoxTelefon.KeyPress += new KeyPressEventHandler(textBoxTelefon_KeyPress); 

            // icerisine bilgi girmek istediğim kutucuk için PlaceHolderManager class'ını türetiyorum.
            placeHolderManager = new PlaceHolderManager(textBoxTelefon,"Enter your Telephone Number");
            
            Font eskiFont = labelTelefon.Font;
            labelTelefon.Font = new Font(eskiFont.FontFamily, 9, FontStyle.Regular);

            textBoxName.KeyPress += new KeyPressEventHandler(textBoxName_KeyPress);
            placeHolderManager = new PlaceHolderManager(textBoxName, "Enter your Name");

            textBoxSurname.KeyPress += new KeyPressEventHandler(textBoxSurname_KeyPress);
            placeHolderManager = new PlaceHolderManager(textBoxSurname, "Enter your Surname");

            placeHolderManager = new PlaceHolderManager(textBoxEmail, "Enter a valid Email address");
            placeHolderManager = new PlaceHolderManager(comboBoxDepartment, "Select Input");

            placeHolderManager = new PlaceHolderManager(richTextBoxMessage, "Enter your message");
            
        }

      

        private void labelName_Click(object sender, EventArgs e)
        {

        }
        private void textBoxName_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (char.IsDigit(e.KeyChar)) // girilen karakterin rakam olup olmadığını kontrol eder.
            {
                e.Handled = true; // eğer rakam girildiyse tuş basımını iptal eder.
            }

        }



        private void labelSurname_Click(object sender, EventArgs e)
        {

        }
        private void textBoxSurname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }


        }

        private void labelTelefon_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTelefon_KeyPress(object sender, KeyPressEventArgs e)
        {
            

            if (char.IsControl(e.KeyChar)) // Karakterin kontrol karakteri olup olmadığını kontrol eder
            {
                return;
            }
            if (!char.IsDigit(e.KeyChar)) 
            {
                e.Handled = true; // eğer rakam girilmediyse tuş basımını iptal eder.
            }
          
        }

        private void labelMail_Click(object sender, EventArgs e)
        {

        }
        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelMessage_Click(object sender, EventArgs e)
        {

        }

        private void richTextBoxMessage_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelDepartment_Click(object sender, EventArgs e)
        {

        }
        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // bağlanılacak veritabanı bilgilerini belirtiyorum.
        public string conString = "Data Source=DESKTOP-VVG2JCK\\SQLEXPRESS;Initial Catalog=SupportFormDb;Integrated Security=True;Encrypt=False";


        private void button1_Click(object sender, EventArgs e)
        {
            // zorunlu kutucuklara karakter girilmemesi halinde uyarı verir.
            if (string.IsNullOrWhiteSpace(textBoxName.Text))
            {
                MessageBox.Show("İsim zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxName.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxSurname.Text))
            {
                MessageBox.Show("Soyisim zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxSurname.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(textBoxTelefon.Text))
            {
                MessageBox.Show("Telefon numarası zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxTelefon.Focus();
                return;
            }
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                MessageBox.Show("Email adresi zorunludur.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                textBoxEmail.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(comboBoxDepartment.Text))
            {
                MessageBox.Show("Lütfen bir departman seciniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                comboBoxDepartment.Focus();
                return;
            }


            using (SqlConnection connection = new SqlConnection(conString))
            {
                connection.Open();
            
            
            if(connection.State==ConnectionState.Open) 
            {
                    string query = "INSERT INTO InfoTbl ([First Name], [Last Name], Telephone, [Email Adress], Department, Message) " +
                        "VALUES (@FirstName, @LastName, @Telephone, @EmailAdress, @Department, @Message)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@FirstName", textBoxName.Text);
                        command.Parameters.AddWithValue("@LastName", textBoxSurname.Text);
                        command.Parameters.AddWithValue("@Telephone", textBoxTelefon.Text);
                        command.Parameters.AddWithValue("@EmailAdress", textBoxEmail.Text);
                        command.Parameters.AddWithValue("@Department", comboBoxDepartment.Text);
                        command.Parameters.AddWithValue("@Message", richTextBoxMessage.Text);

                        command.ExecuteNonQuery();
                        MessageBox.Show("Your message has been sent, we will get back to you as soon as possible.");

                    }
            }
        }
    }

      

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

    
    }
}

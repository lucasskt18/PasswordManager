using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace password
{
    public partial class MainForm : Form
    {
        private Dictionary<string, string> passwords = new Dictionary<string, string>();

        public MainForm()
        {
            InitializeComponent();
        }

        private void AddPasswordButton_Click(object sender, EventArgs e)
        {
            string website = WebsiteTextBox.Text.Trim();
            string password = PasswordTextBox.Text;

            if (!string.IsNullOrEmpty(website) && IsValidPassword(password))
            {
                passwords[website] = password;
                WebsiteTextBox.Clear();
                PasswordTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Invalid input. Make sure the website is not empty and the password meets the complexity requirements.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsValidPassword(string password)
        {
            // A senha deve ter pelo menos 8 caracteres, contendo números, letras maiúsculas e minúsculas e caracteres especiais.
            var passwordPolicy = new Regex("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[^\\da-zA-Z]).{8,}$");
            return passwordPolicy.IsMatch(password);
        }

        private void ShowPasswordsButton_Click(object sender, EventArgs e)
        {
            PasswordsListBox.Items.Clear();
            foreach (var password in passwords)
            {
                PasswordsListBox.Items.Add($"{password.Key}: {password.Value}");
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}

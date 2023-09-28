using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace PasswordManager
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
            string website = WebsiteTextBox.Text;
            string password = PasswordTextBox.Text;

            if (!string.IsNullOrEmpty(website) && !string.IsNullOrEmpty(password))
            {
                passwords[website] = password;
                WebsiteTextBox.Clear();
                PasswordTextBox.Clear();
            }
            else
            {
                MessageBox.Show("Please fill in all fields.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

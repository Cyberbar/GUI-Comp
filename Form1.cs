using System.Text.RegularExpressions;

namespace GUI_Comp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
      

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button2.Enabled = checkBox1.Checked;

        }
      
        private void button2_Click(object sender, EventArgs e)
        {
            string userName = textBox1.Text;
            string password = textBox2.Text;
            string pattern = "^[a-zA-Z0-9]+$";

            // Validate username is not empty
            if (string.IsNullOrWhiteSpace(userName))
            {
                MessageBox.Show("Error: Username cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate username
            if (!Regex.IsMatch(userName, pattern))
            {
                MessageBox.Show("Error: Username can only contain letters and numbers.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate gender selection
            if (!radioButton1.Checked && !radioButton2.Checked)
            {
                MessageBox.Show("Error: Please select a gender.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate payment method selection
            if (!radioButton3.Checked && !radioButton4.Checked && !radioButton5.Checked)
            {
                MessageBox.Show("Error: Please select a payment method.", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate password is not empty
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Error: Password cannot be empty.", "Invalid Input", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Validate password strength
            if (!IsPasswordStrong(password))
            {
                MessageBox.Show("Error: Password is not strong enough. It must be at least 8 characters long and include uppercase letters, lowercase letters, digits, and special characters.", "Weak Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // If all validations pass
            MessageBox.Show($"Welcome, {userName}. Your Account has been Created");
            this.Close();
        }

        private bool IsPasswordStrong(string password)
        {
            // Define the criteria for a strong password
            bool hasUpperCase = password.Any(char.IsUpper);
            bool hasLowerCase = password.Any(char.IsLower);
            bool hasDigit = password.Any(char.IsDigit);
            bool hasSpecialChar = password.Any(ch => !char.IsLetterOrDigit(ch));
            bool isAtLeast8Chars = password.Length >= 8;

            return hasUpperCase && hasLowerCase && hasDigit && hasSpecialChar && isAtLeast8Chars;
        }


        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("Do you want to close this window", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.Close();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

using System;
using System.Windows.Forms;
using SwimmingClient;

namespace Client
{
    public partial class LoginForm : Form
    {
        private ClientController controller;
        
        public LoginForm(ClientController controller)
        {
            InitializeComponent();
            this.controller = controller;
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            string stringId = idTB.Text;
            string password = passwordTB.Text;
            try
            {
                controller.LogIn(stringId, password);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
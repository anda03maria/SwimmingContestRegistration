using System;
using System.Collections.Generic;
using System.Windows.Forms;
using SwimmingClient;
using SwimmingModel.dto;
using SwimmingModel.user;

namespace Client
{
    public partial class MainForm : Form
    {
        private ClientController Controller;
        private Admin admin;
        
        public MainForm(ClientController controller, Admin admin)
        {
            this.Controller = controller;
            this.admin = admin;
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            racesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            racesGridView.MultiSelect = false;
            contestantsGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contestantsGridView.MultiSelect = false;
            LoadRaces();
        }

        public void LoadRaces()
        {
            racesGridView.Rows.Clear();
            RaceInfo[] races = Controller.GetRaces();
            for (int i = 0; i < races.Length; i++)
            {
                racesGridView.Rows.Add(races[i].RaceId, races[i].Distance, races[i].Style,
                    races[i].Date.ToString("dd-MM-yyyy"), races[i].NumberOfContestants);
            }
        }

        private void logOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                Controller.LogOut();
                this.Close();
            }
            catch (ClientException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            try
            {
                int selectedRaceId = (int)racesGridView.SelectedRows[0].Cells[0].Value;
                string nameText = searchNameTB.Text;
                ContestantInfo[] contestants = Controller.GetContestants(selectedRaceId, nameText);
                contestantsGridView.Rows.Clear();
                for (int i = 0; i < contestants.Length; i++)
                {
                    contestantsGridView.Rows.Add(contestants[i].Name, DateTime.Now.Year - contestants[i].BirthDate.Year,
                        contestants[i].textRaceIds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string name = nameTB.Text;
            DateTime bithDate = birthDatePicker.Value;
            string email = emailTB.Text;
            string country = countryTB.Text;
            string city = cityTB.Text;
            string street = streetTB.Text;
            string postalCode = postalCodeTB.Text;
            string ids = raceIdsTB.Text;
            IList<int> idList = new List<int>();
            var stringIds = ids.Split(',');
            try
            {
                foreach (var stringId in stringIds)
                {
                    int id = int.Parse(stringId);
                    idList.Add(id);
                }
                Controller.AddContestant(name, bithDate, email, country, city, street, postalCode, idList);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        public delegate void UpdateContent();
    }
}
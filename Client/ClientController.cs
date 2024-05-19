using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Threading;
using System.Windows.Forms;
using Client;
using Services;
using SwimmingModel;
using SwimmingModel.dto;
using SwimmingModel.user;
using SwimmingServices;

namespace SwimmingClient
{
    public class ClientController : IObserver
    {

        public MainForm mainForm { get; set; }
        private readonly IService service;
        public Admin admin { get; set; }

        public ClientController(IService service)
        {
            this.service = service;
        }

        public void LogIn(string id, string password)
        {
            Console.WriteLine(id + " " + password);
            if (id.Length == 0 || password.Length == 0)
                throw new ClientException("Invalid credentials!");
            try
            {
                int intId = int.Parse(id);
                Admin admin = new Admin(intId, password);
                service.Login(admin, this);
                MainForm mainForm = new MainForm(this, admin);
                this.mainForm = mainForm;
                this.admin = admin;
                var t = new Thread(() => Application.Run(mainForm));
                t.Start();
            }
            catch (Exception ex)
            {
                throw new ClientException(ex.Message);
            }
        }

        public void LogOut()
        {
            try
            {
                service.Logout(admin, this);
                admin = null;
            }
            catch (ServiceException ex)
            {
                throw new ClientException(ex.Message);
            }
        }

        public RaceInfo[] GetRaces()
        {
            return service.GetRacesInfo();
        }

        public ContestantInfo[] GetContestants(int id, string nameText)
        {
            return service.GetContestantsFromRace(id, nameText);
        }

        public void AddContestant(string name, DateTime birthDate, string email, string country, string city,
            string street, string postalCode, IList<int> ids)
        {
            Contestant newContestant =
                new Contestant(name, birthDate, email, new Address(country, city, street, postalCode));
            service.RegisterContestant(newContestant, ids);
        }
        
        public void Update()
        {
            mainForm.BeginInvoke(new MainForm.UpdateContent(mainForm.LoadRaces));
        }
        
        
    }
}
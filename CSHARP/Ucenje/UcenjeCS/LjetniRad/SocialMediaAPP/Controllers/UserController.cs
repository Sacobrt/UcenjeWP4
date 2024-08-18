
using Newtonsoft.Json;
using UcenjeCS.LjetniRad.SocialMediaAPP.Model;

namespace UcenjeCS.LjetniRad.SocialMediaAPP.Controllers
{
    internal class UserController
    {
        public List<User> Users { get; set; }
        public UserController()
        {
            Users = new List<User>();
            if (Helpers.DEV)
            {
                LoadTestData();
            }
        }
        private void LoadTestData()
        {
            Users.Add(new() { ID = 1, Username = "Danijel", CreatedAt = DateTime.Now });
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> IZBORNIK ZA RAD S KORISNICIMA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Pregled svih korisnika");
            Console.WriteLine("\t[2] Unos novog korisnika");
            Console.WriteLine("\t[3] Promjena podataka postojećeg korisnika");
            Console.WriteLine("\t[4] Brisanje korisnika");
            Console.WriteLine("\t[5] Povratak na glavni izbornik");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    ShowUser();
                    ShowMenu();
                    break;
                case 2:
                    NewUser();
                    ShowMenu();
                    break;
                case 3:
                    ChangeUser();
                    ShowMenu();
                    break;
                case 4:
                    DeleteUser();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        public void ShowUser()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t> LISTA KORISNIKA");
            Console.ForegroundColor = ConsoleColor.White;

            if (Users.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tLista korisnika je trenutno prazna!");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                int rb = 0;
                foreach (var s in Users)
                {
                    Console.WriteLine("\t[" + ++rb + "]" + " Username: " + s.Username + " | Email: " + s.Email + " | Datum registracije: " + s.CreatedAt);
                }
            }
        }
        private void NewUser()
        {
            ShowUser();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> UNESITE TRAŽENE PODATKE ZA NOVOG KORISNIKA");
            Console.ForegroundColor = ConsoleColor.White;
            var m = new User();

            int id = Helpers.NumberInput("\tŠifra");
            while (Users.Exists(m => m.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ta šifra već postoji za nekog korisnika!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput("\tŠifra");
            }
            m.ID = id;

            m.Username = Helpers.StringInput("\tKorisničko ime");
            m.Password = Helpers.StringInput("\tLozinka");
            m.Email = Helpers.EmailInput("\tEmail", 50, false);
            m.FirstName = Helpers.StringInput("\tIme");
            m.LastName = Helpers.StringInput("\tPrezime");
            m.CreatedAt = Helpers.DateInput("\tDatum kreiranja", false);
            Users.Add(m);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tNOVI KORISNIK JE USPJEŠNO DODAN!\n\tID: {0}\n\tKorisničko ime: {1}\n\tIme: {2}\n\tPrezime: {3}", m.ID, m.Username, m.FirstName, m.LastName);
            Console.ForegroundColor = ConsoleColor.White;

            SaveData();
        }
        private void ChangeUser()
        {
            Console.Clear();
            ShowUser();
            if(Users.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Users[Helpers.NumberInput("\nOdaberite šifru korisnika za promjenu", 1, Users.Count) - 1];
            var originalId = selected.ID;

            int id = Helpers.NumberInput(originalId, "\tPromjeni šifru korisnika", 1, int.MaxValue);
            while (id != originalId && Users.Exists(p => p.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ta šifra već postoji za nekog korisnika!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput(originalId, "\tPromjeni šifru korisnika", 1, int.MaxValue);
            }
            selected.ID = id;

            selected.Username = Helpers.StringInput(selected.Username, "\tPromjeni korisničko ime", 50, false);
            selected.Password = Helpers.PasswordInput(selected.Password, "\tPromjeni lozinku", 6, 65, false);
            selected.Email = Helpers.EmailInput(selected.Email, "\tPromjeni email", 40, false);
            selected.FirstName = Helpers.StringInput(selected.FirstName, "\tPromjeni ime", 20, false);
            selected.LastName = Helpers.StringInput(selected.LastName, "\tPromjeni prezime", 20, false);
            selected.CreatedAt = Helpers.DateInput(selected.CreatedAt, "\tPromjeni datum kreiranja", false);

            SaveData();
        }
        private void DeleteUser()
        {
            Console.Clear();
            ShowUser();
            if(Users.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Users[Helpers.NumberInput("\nOdaberi redni broj korisnika za brisanje", 1, Users.Count) - 1];

            if (selected.ID == 0) return;
            if (Helpers.BoolInput("Sigurno želite obrisati " + selected.Username + "? (DA/NE) (ENTER za prekid)", "da"))
            {
                Users.Remove(selected);
                SaveData();
            }
        }
        private void SaveData()
        {
            if (Helpers.DEV)
            {
                return;
            }

            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "users.json"), FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter outputFile = new StreamWriter(fs)) outputFile.Write(JsonConvert.SerializeObject(Users));
        }
    }
}


using Newtonsoft.Json;
using UcenjeCS.LjetniRad.SocialMediaAPP.Model;

namespace UcenjeCS.LjetniRad.SocialMediaAPP.Controllers
{
    internal class FollowerController
    {
        public List<Follower> Followers { get; set; }
        public List<User> Users { get; set; }
        private Menu Menu;
        public FollowerController()
        {
            Followers = new List<Follower>();
        }
        public FollowerController(Menu menu) : this()
        {
            this.Menu = menu;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> IZBORNIK ZA RAD S PRATIOCIMA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Pregled svih pratioca");
            Console.WriteLine("\t[2] Unos novog pratioca");
            Console.WriteLine("\t[3] Promjena podataka postojećeg pratioca");
            Console.WriteLine("\t[4] Brisanje pratitelja");
            Console.WriteLine("\t[5] Povratak na glavni izbornik");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    ShowFollower();
                    ShowMenu();
                    break;
                case 2:
                    NewFollower();
                    ShowMenu();
                    break;
                case 3:
                    ChangeFollower();
                    ShowMenu();
                    break;
                case 4:
                    DeleteFollower();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        public void ShowFollower()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t> LISTA PRATITELJA");
            Console.ForegroundColor = ConsoleColor.White;

            if (Followers.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tLista pratitelja je trenutno prazna!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var s in Followers)
                {
                    Console.WriteLine("\t[" + ++rb + "] " + s.UserID?.Username + " prati " + s.FollowerUserID?.Username + " | Datum: " + s.FollowedAt);
                }
            }
        }
        private void NewFollower()
        {
            ShowFollower();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> UNESITE TRAŽENE PODATKE ZA PRAĆENJE IZMEĐU KORISNIKA");
            Console.ForegroundColor = ConsoleColor.White;

            Menu.UserController.ShowUser();

            // Odabir korisnika
            User followerUser = Menu.UserController.Users[Helpers.NumberInput("\n\tOdaberite redni broj korisnika koji želi pratiti drugog korisnika", 1, Menu.UserController.Users.Count) - 1];
            User followedUser = Menu.UserController.Users[Helpers.NumberInput("\tOdaberite redni broj korisnika kojeg želite pratiti", 1, Menu.UserController.Users.Count) - 1];

            // Provjera da korisnik ne može pratiti samog sebe
            if (followerUser == followedUser)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tKorisnik ne može pratiti sam sebe!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            while (Followers.Any(f => f.UserID == followerUser && f.FollowerUserID == followedUser))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tKorisnici se već prate!");
                Console.ForegroundColor = ConsoleColor.White;

                followerUser = Menu.UserController.Users[Helpers.NumberInput("\n\tOdaberite redni broj korisnika koji želi pratiti drugog korisnika", 1, Menu.UserController.Users.Count) - 1];
                followedUser = Menu.UserController.Users[Helpers.NumberInput("\tOdaberite redni broj korisnika kojeg želite pratiti", 1, Menu.UserController.Users.Count) - 1];

                if (followerUser == followedUser)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tKorisnik ne može pratiti sam sebe!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }

            var m = new Follower
            {
                UserID = followerUser,
                FollowerUserID = followedUser,
                FollowedAt = DateTime.Now
            };

            Followers.Add(m);
            SaveData();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t{0} od sada prati {1}", m.UserID?.Username, m.FollowerUserID?.Username);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void ChangeFollower()
        {
            Console.Clear();
            ShowFollower();
            if (Followers.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Followers[Helpers.NumberInput("\nOdaberite redni broj za promjenu", 1, Followers.Count) - 1];

            Menu.UserController.ShowUser();

            // Odabir korisnika
            User followerUser = Menu.UserController.Users[Helpers.NumberInput("\n\tOdaberite redni broj korisnika koji želi pratiti drugog korisnika", 1, Menu.UserController.Users.Count) - 1];
            User followedUser = Menu.UserController.Users[Helpers.NumberInput("\tOdaberite redni broj korisnika kojeg želite pratiti", 1, Menu.UserController.Users.Count) - 1];

            // Provjera da korisnik ne može pratiti samog sebe
            if (followerUser == followedUser)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tKorisnik ne može pratiti sam sebe!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }

            // Provjera da li se korisnici već prate
            while (Followers.Any(f => f.UserID == followerUser && f.FollowerUserID == followedUser))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tKorisnici se već prate!");
                Console.ForegroundColor = ConsoleColor.White;

                followerUser = Menu.UserController.Users[Helpers.NumberInput("\n\tOdaberite šifru korisnika koji želi pratiti drugog korisnika", 1, Menu.UserController.Users.Count) - 1];
                followedUser = Menu.UserController.Users[Helpers.NumberInput("\tOdaberite šifru korisnika kojeg želite pratiti", 1, Menu.UserController.Users.Count) - 1];

                if (followerUser == followedUser)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\tKorisnik ne može pratiti sam sebe!");
                    Console.ForegroundColor = ConsoleColor.White;
                    return;
                }
            }

            var m = new Follower
            {
                UserID = followerUser,
                FollowerUserID = followedUser,
                FollowedAt = DateTime.Now
            };

            SaveData();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\t{0} od sada prati {1}", m.UserID?.Username, m.FollowerUserID?.Username);
            Console.ForegroundColor = ConsoleColor.White;
        }
        private void DeleteFollower()
        {
            Console.Clear();
            ShowFollower();
            if (Followers.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Followers[Helpers.NumberInput("\nOdaberi redni broj pratioca za brisanje", 1, Followers.Count) - 1];

            if (selected.UserID == null) return;
            if (Helpers.BoolInput("Sigurno želite obrisati " + selected.UserID?.Username + " prati " + selected.FollowerUserID?.Username + "? (DA/NE) (ENTER za prekid)", "da"))
            {
                Followers.Remove(selected);
                SaveData();
            }
        }
        private void SaveData()
        {
            if (Helpers.DEV)
            {
                return;
            }
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "followers.json"), FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter outputFile = new StreamWriter(fs)) outputFile.Write(JsonConvert.SerializeObject(Followers));
        }
    }
}

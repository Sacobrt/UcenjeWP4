
using Newtonsoft.Json;
using UcenjeCS.LjetniRad.SocialMediaAPP.Model;

namespace UcenjeCS.LjetniRad.SocialMediaAPP.Controllers
{
    internal class PostController
    {
        public List<Post> Posts { get; set; }
        private Menu Menu;
        public PostController()
        {
            Posts = new List<Post>();
        }
        public PostController(Menu menu) : this()
        {
            this.Menu = menu;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> IZBORNIK ZA RAD S POSTOVIMA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Pregled svih postova");
            Console.WriteLine("\t[2] Unos novog posta");
            Console.WriteLine("\t[3] Promjena podataka postojećeg posta");
            Console.WriteLine("\t[4] Brisanje posta");
            Console.WriteLine("\t[5] Povratak na glavni izbornik");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    ShowPost();
                    ShowMenu();
                    break;
                case 2:
                    NewPost();
                    ShowMenu();
                    break;
                case 3:
                    ChangePost();
                    ShowMenu();
                    break;
                case 4:
                    DeletePost();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        public void ShowPost()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t> LISTA POSTOVA");
            Console.ForegroundColor = ConsoleColor.White;

            if (Posts.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tTrenutno nema ni jednog posta!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var s in Posts)
                {
                    Console.WriteLine("\t[" + ++rb + "]" + " Korisnik: " + s.User.Username + " | Post: " + s.Content + " | Datum: " + s.CreatedAt);
                }
            }
        }
        private void NewPost()
        {
            ShowPost();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> UNESITE TRAŽENE PODATKE ZA NOVI POST");
            Console.ForegroundColor = ConsoleColor.White;
            var m = new Post();

            // Unos šifre za post
            int id = Helpers.NumberInput("\tŠifra");
            while (Posts.Exists(p => p.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ta šifra već postoji za neki post!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput("\tŠifra");
            }
            m.ID = id;

            // Odabir korisnika
            Menu.UserController.ShowUser();
            m.User = Menu.UserController.Users[Helpers.NumberInput("\n\tOdaberite šifru korisnika koji postavlja post", 1, Menu.UserController.Users.Count) - 1];

            // Unos sadržaj posta
            m.Content = Helpers.StringInput("\tPost", 50);
            m.CreatedAt = Helpers.DateInput("\tDatum kreiranja", false);

            Posts.Add(m);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tNOVI POST USPJEŠNO DODAN!\n\tID: {0}\n\tSadržaj: {1}\n\tKorisnik: {2}", m.ID, m.Content, m.User?.Username);
            Console.ForegroundColor = ConsoleColor.White;

            SaveData();
        }
        private void ChangePost()
        {
            Console.Clear();
            ShowPost();
            if (Posts.Count < 1)
            {
                ShowMenu();
                return;
            }
            // Odabir posta za promjenu
            var selected = Posts[Helpers.NumberInput("\nOdaberite redni broj posta za promjenu", 1, Posts.Count) - 1];
            var originalId = selected.ID;

            // Promjena šifre za post
            int id = Helpers.NumberInput(originalId, "\tPromjeni šifru posta", 1, int.MaxValue);
            while (id != originalId && Posts.Exists(p => p.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ta šifra već postoji za neki post!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput(originalId, "\tPromjeni šifru posta", 1, int.MaxValue);
            }
            selected.ID = id;

            // Promjena korisnika
            Menu.UserController.ShowUser();
            selected.User = Menu.UserController.Users[Helpers.NumberInput(selected.User.ID, "\n\tOdaberite šifru korisnika koji postavlja post", 1, Menu.UserController.Users.Count) - 1];

            // Promjena sadržaj posta
            selected.Content = Helpers.StringInput(selected.Content, "\tPromjeni post", 50, false);
            selected.CreatedAt = Helpers.DateInput(selected.CreatedAt, "\tPromjeni datum kreiranja", false);

            SaveData();
        }
        private void DeletePost()
        {
            Console.Clear();
            ShowPost();
            if(Posts.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Posts[Helpers.NumberInput("Odaberi redni broj posta za brisanje", 1, Posts.Count) - 1];

            if (selected.ID == 0) return;
            if (Helpers.BoolInput("Sigurno želite obrisati " + selected.Content + "? (DA/NE) (ENTER za prekid)", "da"))
            {
                Posts.Remove(selected);
                SaveData();
            }
        }
        private void SaveData()
        {
            if (Helpers.DEV)
            {
                return;
            }
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "posts.json"), FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter outputFile = new StreamWriter(fs)) outputFile.Write(JsonConvert.SerializeObject(Posts));
        }
    }
}

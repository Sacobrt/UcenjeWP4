
using Newtonsoft.Json;
using UcenjeCS.LjetniRad.SocialMediaAPP.Model;

namespace UcenjeCS.LjetniRad.SocialMediaAPP.Controllers
{
    internal class CommentController
    {
        public List<Comment> Comments { get; set; }
        private Menu Menu;
        public CommentController()
        {
            Comments = new List<Comment>();
        }
        public CommentController(Menu menu) : this()
        {
            this.Menu = menu;
        }
        public void ShowMenu()
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> IZBORNIK ZA RAD S KOMENTARIMA");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Pregled svih komentara");
            Console.WriteLine("\t[2] Unos novog komentara");
            Console.WriteLine("\t[3] Promjena podataka postojećeg komentara");
            Console.WriteLine("\t[4] Brisanje komentara");
            Console.WriteLine("\t[5] Povratak na glavni izbornik");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    ShowComment();
                    ShowMenu();
                    break;
                case 2:
                    NewComment();
                    ShowMenu();
                    break;
                case 3:
                    ChangeComment();
                    ShowMenu();
                    break;
                case 4:
                    DeleteComment();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    break;
            }
        }
        private void ShowComment()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\t> LISTA KOMENTARA");
            Console.ForegroundColor = ConsoleColor.White;

            if (Comments.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\tLista komentara je prazna!");
                Console.ForegroundColor = ConsoleColor.White;
                return;
            }
            else
            {
                int rb = 0;
                foreach (var s in Comments)
                {
                    Console.WriteLine("\t" + "[" + ++rb + "]" + " Kreirao post: " + s.Post?.User?.Username + " | Komentar (" + s.User?.Username + "): " + s.Content + " | Post: " + s.Post?.Content + " | Datum: " + s.CreatedAt);
                }
            }
        }
        private void NewComment()
        {
            ShowComment();
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> UNESITE TRAŽENE PODATKE ZA NOVI KOMENTAR");
            Console.ForegroundColor = ConsoleColor.White;
            var m = new Comment();

            int id = Helpers.NumberInput("\tŠifra");
            while (Comments.Exists(m => m.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ta šifra već postoji za neki komentar!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput("\tŠifra");
            }
            m.ID = id;

            // Odabir korisnika
            Menu.UserController.ShowUser();
            m.User = Menu.UserController.Users[Helpers.NumberInput("Odaberi redni broj korisnika", 1, Menu.UserController.Users.Count) - 1];

            Menu.PostController.ShowPost();
            m.Post = Menu.PostController.Posts[Helpers.NumberInput("Odaberi redni broj posta", 1, Menu.PostController.Posts.Count) - 1];

            m.Content = Helpers.StringInput("\tKomentar", 64);
            m.CreatedAt = Helpers.DateInput("\tDatum kreiranja", false);

            Comments.Add(m);

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n\tNovi komentar je uspješno dodan. (ID: {0} - Komentar: {1})", m.ID, m.Content);
            Console.ForegroundColor = ConsoleColor.White;

            SaveData();
        }
        private void ChangeComment()
        {
            Console.Clear();
            if (Menu.PostController.Posts.Count < 1)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n\tTrenutno nema postova!");
                Console.ForegroundColor = ConsoleColor.White;
                ShowMenu();
                return;
            }
            ShowComment();
            if (Comments.Count < 1)
            {
                ShowMenu();
                return;
            }

            // Odabir komentara za promjenu
            var selected = Comments[Helpers.NumberInput("\nOdaberite redni broj komentara za promjenu", 1, Comments.Count) - 1];
            var originalId = selected.ID;

            // Promjena šifre za komentar
            int id = Helpers.NumberInput(originalId, "\tPromjeni šifru komentara", 1, int.MaxValue);
            while (id != originalId && Comments.Exists(p => p.ID == id))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Ta šifra već postoji za neki komentar!");
                Console.ForegroundColor = ConsoleColor.White;
                id = Helpers.NumberInput(originalId, "\tPromjeni šifru komentara", 1, int.MaxValue);
            }
            selected.ID = id;

            //Promjena posta
            Menu.PostController.ShowPost();
            selected.Post = Menu.PostController.Posts[Helpers.NumberInput(selected.Post.ID, "\n\tOdaberite šifru posta za koji će biti komentar", 1, Menu.PostController.Posts.Count) - 1];

            // Promjena korisnika
            Menu.UserController.ShowUser();
            selected.User = Menu.UserController.Users[Helpers.NumberInput(selected.User.ID, "\n\tOdaberite šifru korisnika koji postavlja post", 1, Menu.UserController.Users.Count) - 1];

            // Promjena sadržaj posta
            selected.Content = Helpers.StringInput(selected.Content, "\tPromjeni post", 50, false);
            selected.CreatedAt = Helpers.DateInput(selected.CreatedAt, "\tPromjeni datum kreiranja", false);

            SaveData();
        }
        private void DeleteComment()
        {
            Console.Clear();
            ShowComment();
            if(Comments.Count < 1)
            {
                ShowMenu();
                return;
            }
            var selected = Comments[Helpers.NumberInput("Odaberi redni broj komentara za brisanje", 1, Comments.Count) - 1];

            if (selected.ID == 0) return;
            if (Helpers.BoolInput("Sigurno obrisati " + selected.Content + "? (DA/NE) (ENTER za prekid)", "da"))
            {
                Comments.Remove(selected);
                SaveData();
            }
        }
        private void SaveData()
        {
            if (Helpers.DEV)
            {
                return;
            }
            using (FileStream fs = new FileStream(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "comments.json"), FileMode.Create, FileAccess.Write, FileShare.None))
            using (StreamWriter outputFile = new StreamWriter(fs)) outputFile.Write(JsonConvert.SerializeObject(Comments));
        }
    }
}

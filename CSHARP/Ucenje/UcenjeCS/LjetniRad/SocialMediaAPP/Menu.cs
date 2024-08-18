
using Newtonsoft.Json;
using UcenjeCS.LjetniRad.SocialMediaAPP.Controllers;
using UcenjeCS.LjetniRad.SocialMediaAPP.Model;

namespace UcenjeCS.LjetniRad.SocialMediaAPP
{
    internal class Menu
    {
        string APP_VERSION = "v0.1";
        public UserController UserController { get; set; }
        public PostController PostController { get; set; }
        public CommentController CommentController { get; set; }
        public FollowerController FollowerController { get; set; }
        public Menu()
        {
            //Helpers.DEV = true;
            UserController = new UserController();
            PostController = new PostController(this);
            CommentController = new CommentController(this);
            FollowerController = new FollowerController(this);

            LoadData();
            WelcomeMessage();
            ShowMenu();
        }
        private void LoadData()
        {
            var files = new Dictionary<string, Action<string>>
            {
                { "users.json", path => UserController.Users = LoadFromFile<List<User>>(path) },
                { "posts.json", path => PostController.Posts = LoadFromFile<List<Post>>(path) },
                { "comments.json", path => CommentController.Comments = LoadFromFile<List<Comment>>(path) },
                { "followers.json", path => FollowerController.Followers = LoadFromFile<List<Follower>>(path) }
            };
            foreach (var file in files)
            {
                if (File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), file.Key)))
                {
                    file.Value(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), file.Key));
                }
            }
        }
        private PATH LoadFromFile<PATH>(string filePath)
        {
            using (var file = new StreamReader(filePath))
            {
                string json = file.ReadToEnd();
                return JsonConvert.DeserializeObject<PATH>(json);
            }
        }
        private void ShowMenu()
        {
            Console.Title = "SOCIAL MEDIA APP " + APP_VERSION + "";
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\n\t> GLAVNI IZBORNIK");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\t[1] Korisnici");
            Console.WriteLine("\t[2] Postovi");
            Console.WriteLine("\t[3] Komentari");
            Console.WriteLine("\t[4] Pratitelji");
            Console.WriteLine("\t[5] Izlaz iz programa");
            SelectMenuOption();
        }
        private void SelectMenuOption()
        {
            switch (Helpers.NumberInput("\nOdaberite stavku izbornika", 1, 5))
            {
                case 1:
                    Console.Clear();
                    UserController.ShowMenu();
                    WelcomeMessage();
                    ShowMenu();
                    break;
                case 2:
                    Console.Clear();
                    PostController.ShowMenu();
                    WelcomeMessage();
                    ShowMenu();
                    break;
                case 3:
                    Console.Clear();
                    CommentController.ShowMenu();
                    WelcomeMessage();
                    ShowMenu();
                    break;
                case 4:
                    Console.Clear();
                    FollowerController.ShowMenu();
                    WelcomeMessage();
                    ShowMenu();
                    break;
                case 5:
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\n\t**********************************************");
                    Console.WriteLine("\t* Hvala na korištenju aplikacije, doviđenja! *");
                    Console.WriteLine("\t**********************************************\n");
                    Console.ForegroundColor = ConsoleColor.White;
                    break;
            }
        }
        private void WelcomeMessage()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t*********************************");
            Console.WriteLine("\t***** SOCIAL MEDIA APP " + APP_VERSION + " *****");
            Console.WriteLine("\t*********************************");
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}

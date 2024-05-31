using Task;
int consoleInput;
UserService userService = new UserService();
MessageService messageService = new MessageService();
string currentUsername;
void MainMenu()
{
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Dasturimizga hush kelibsiz!");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine("Tanlang: ");
    Console.WriteLine("1. Register");
    Console.WriteLine("2. Login");
    Console.Write(">>>");
    consoleInput = int.Parse(Console.ReadLine());
    if (consoleInput == 2)
    {
        Login();
    }
    else
    {
        ShowRegister();
    }

}

MainMenu();


void ShowRegister()
{
    Console.Write("User name kiriting >>>");
    var username = Console.ReadLine();
    Console.Write("Password  kiriting >>>");
    var password = Console.ReadLine();
    var user = new User(username, password);
    userService.Users.Add(user);
    userService.WriteUsers();
    Console.WriteLine("Siz muvaffaqiyattli o'tdingiz!");
    MainMenu();
}

void Login()
{
    Console.Write("User name kiriting >>>");
    var username = Console.ReadLine();
    Console.Write("Password  kiriting >>>");
    var password = Console.ReadLine();
    var user = userService.Users.FirstOrDefault(x => x.Username == username);
    if (user == null)
    {
        Console.WriteLine("Noto'g'ri username kiritdingiz \n Qayta urunib ko'ring:)");
        Login();

    }
    else
    {
        var check = user.Password == password;
        if (check)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{username} xush kelibsiz!");
            Console.ForegroundColor = ConsoleColor.White;
            currentUsername = username;
            Menu();
        }
        else
        {
            Console.WriteLine("Noto'ri password kiritdingiz \n qayta urunib ko'ring:)");
            Login();
        }
    }

}

void LogOut()
{
    currentUsername = "";
    MainMenu();
}


void Menu()
{
    ShowCurrentUser();
    Console.WriteLine("1. Hamma userlarni ko'rish");//1) message junatish
    Console.WriteLine("2. Menga kelgan habarlarni ko'rish");
    Console.WriteLine("3. Men jo'natgan habarlarni ko'rish");
    Console.WriteLine("4. Log out");
    Console.Write(">>>");
    consoleInput = int.Parse(Console.ReadLine());
    switch (consoleInput)
    {
        case 1: ShowUsers();
            break;
        case 2:
            SeeMyMessages(currentUsername);
            break;
        case 4: LogOut(); break;
        default:
            Menu();
            break;
    }
}


void ShowUsers()
{
    int i = 0;
    foreach (var user in userService.Users)
    {
        i++;
        Console.WriteLine($"{i}. {user.Username}");
    }

    Console.WriteLine("1. Habar junatish");
    Console.WriteLine("2. Back");
    Console.WriteLine("3. Log out");
    Console.Write(">>>");
    consoleInput = int.Parse(Console.ReadLine()!);
    switch (consoleInput)
    {
        case 3: LogOut(); break;
        default: ShowUsers(); break;
    }
}

void SeeMyMessages(string username)
{
    List<Message> messages = messageService.Messages.Where(m => m.ToUser == username).ToList();
    if (messages.Count > 0 && messages != null)
    {
        ShowMessage(messages);
    }
    else
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("Hozirda sizda hech qanday habar yoq:)");
        Console.ForegroundColor = ConsoleColor.White;
        Menu();
    }


}


void ShowCurrentUser()
{
    if (!string.IsNullOrEmpty(currentUsername))
    {
        Console.ForegroundColor= ConsoleColor.Red;
        Console.WriteLine($"Current user {currentUsername}");
        Console.ForegroundColor = ConsoleColor.White;
    }
}

void ShowMessage(List<Message> messages)
{
    for (int i = 0; i < messages.Count; i++)
    {
        Console.WriteLine($"{i}. {messages[i].FromUser} dan \" {messages[i].Text}\" ");
    }
}

void SendMessage(string fromUser, string toUser, string text)
{
    var message = new Message(fromUser, toUser, text);
    messageService.Messages.Add(message);
}



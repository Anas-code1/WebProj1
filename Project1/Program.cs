using Project1;



BookDataAccess dataAccess = new BookDataAccess();

while (true)
{
    Console.WriteLine("\n1. Add Book");
    Console.WriteLine("2. View All Books");
    Console.WriteLine("3. Find Book by ID");
    Console.WriteLine("4. Backup Books");
    Console.WriteLine("5. Exit");

    Console.Write("Enter your choice: ");
    int choice = int.Parse(Console.ReadLine());

    if (choice == 1)
    {
        Console.Write("Enter ID: ");
        int id = int.Parse(Console.ReadLine());

        Console.Write("Enter Title: ");
        string title = Console.ReadLine();

        Console.Write("Enter Author: ");
        string author = Console.ReadLine();

        Console.Write("Enter Price: ");
        double price = double.Parse(Console.ReadLine());

        Book book = new Book(id, title, author, price);
        dataAccess.AddBook(book);
    }
    else if (choice == 2)
    {
        dataAccess.ReadBook();
    }
    else if (choice == 3)
    {
        Console.Write("Enter Book ID: ");
        int id = int.Parse(Console.ReadLine());

        dataAccess.FindBook(id);
    }
    else if (choice == 4)
    {
        dataAccess.BackupBooks();
    }
    else if (choice == 5)
    {
        break;
    }
}

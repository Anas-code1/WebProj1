using System;
using System.Collections.Generic;
using System.Text;

namespace Project1
{
    internal class BookDataAccess
    {

        public void AddBook(Book book)
        {
            using (FileStream fs = new FileStream("books.txt", FileMode.Append))
            {
                using (StreamWriter sw = new StreamWriter(fs))
                {
                    sw.WriteLine($"{book.Id}, {book.Title}, {book.Author}, {book.Price}");
                }
            }



        }

        public void ReadBook()
        {
            List<Book> books = new List<Book>();

            using (FileStream fs = new FileStream("books.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        int id = int.Parse(parts[0].Trim());
                        string title = parts[1].Trim();
                        string author = parts[2].Trim();
                        double price = double.Parse(parts[3].Trim());
                        Book book = new Book(id, title, author, price);
                        books.Add(book);

                    }
                    foreach (Book b in books)
                    {
                        b.DisplayInfo();
                    }
                }



            }





        }

        public void FindBook(int Id)
        {

            using (FileStream fs = new FileStream("books.txt", FileMode.Open))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string line;
                    bool found = false;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        int id = int.Parse(parts[0].Trim());
                        string title = parts[1].Trim();
                        string author = parts[2].Trim();
                        double price = double.Parse(parts[3].Trim());
                        Book book = new Book(id, title, author, price);

                        if (book.Id == Id)
                        {
                            found = true;
                            Console.WriteLine("Book found:");

                        }

                    }

                    if (!found)
                    {
                        Console.WriteLine("Book not found.");
                    }



                }



            }




        }

        public void BackupBooks()
        {
            string sourceFile = "books.txt";
            string backupFile = "books_backup.txt";

            using (FileStream fs = new FileStream(sourceFile, FileMode.Open))
            {
                using (FileStream backupFs = new FileStream(backupFile, FileMode.Create)) {

                    byte[] buffer = new byte[1024];

                    int bytesRead;

                    while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        backupFs.Write(buffer, 0, bytesRead);
                    }



                }

            }
        }

               


        }
                    }
            
          
            
      



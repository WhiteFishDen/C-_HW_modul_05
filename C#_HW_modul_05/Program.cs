using System.Data;
using System.Numerics;
using System.Text;
using static System.Console;
internal class Program
{




    class Magazin
    {
        public string Name { get; set; }
        public DateTime DateOfFoundation { get; set; }
        public string Specification { get; set; }
        public long ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        public int NumberOfEmployees { get; set; }

        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return this.ToString() == obj.ToString();
        }
        public static bool operator == (Magazin x, Magazin y)
        {
            return x.NumberOfEmployees == y.NumberOfEmployees;
        }
        public static bool operator !=(Magazin x, Magazin y)
        {
            return x.NumberOfEmployees != y.NumberOfEmployees;
        }
        public static bool operator < (Magazin x, Magazin y)
        {
            return x.NumberOfEmployees < y.NumberOfEmployees;
        }
        public static bool operator >(Magazin x, Magazin y)
        {
            return x.NumberOfEmployees > y.NumberOfEmployees;
        }
        public static Magazin operator + (Magazin x, int value)
        {
            x.NumberOfEmployees += value;
            return x;
        }
        public static Magazin operator -(Magazin x, int value)
        {
            x.NumberOfEmployees -= value;
            return x;
        }

        public override string ToString()
        {
            return $"\tName magazin: {Name}\n" +
                $"\tFoundation: {DateOfFoundation.ToLongDateString}\n \tSpecification: {Specification}\n" +
                $"\tContact Phone number: {ContactPhone}\n\tContact E-mail: {ContactEmail}" +
                $"\n\t Number of employees:{NumberOfEmployees} ";
        }
        public void InputData()
        {
            WriteLine("Fill in the magazin details: ");
            Write("Name: ");
            Name = ReadLine();
            Write("Foundation: ");
            DateOfFoundation = DateTime.Parse(ReadLine());
            Write("Specification: ");
            Specification = ReadLine();
            Write("Contact Phone number: ");
            ContactPhone = long.Parse(ReadLine());
            Write("Contact E-mail: ");
            ContactEmail = ReadLine();


        }

    }


    class Shop
    {
        public string Name { get; set; }
        public string Adress { get; set; }
        public string Specification { get; set; }
        public long ContactPhone { get; set; }
        public string ContactEmail { get; set; }

        public short Area { get; set; }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return this.ToString() == obj.ToString();
        }
        public static bool operator ==(Shop x, Shop y)
        {
            return x.Area == y.Area;
        }
        public static bool operator !=(Shop x, Shop y)
        {
            return x.Area != y.Area;
        }
        public static bool operator <(Shop x, Shop y)
        {
            return x.Area < y.Area;
        }
        public static bool operator >(Shop x, Shop y)
        {
            return x.Area > y.Area;
        }
        public static Shop operator +(Shop x, short value)
        {
            x.Area += value;
            return x;
        }
        public static Shop operator - (Shop x, short value)
        {
            x.Area -= value;
            return x;
        }


        public override string ToString()
        {
            return $"\tName shop: {Name}\n" +
                $"\tAdress: {Adress}\n \tSpecification: {Specification}\n" +
                $"\tContact Phone number: {ContactPhone}\n\tContact E-mail: {ContactEmail}" +
                $"\n\tArea of shop:{Area} ";
        }

        public void InputData()
        {
            WriteLine("Fill in the shop details: ");
            Write("Name: ");
            Name = ReadLine();
            Write("Adress: ");
            Adress = ReadLine();
            Write("Specification: ");
            Specification = ReadLine();
            Write("Contact Phone number: ");
            ContactPhone = long.Parse(ReadLine());
            Write("Contact E-mail: ");
            ContactEmail = ReadLine();
        }

    }

    class Book
    {
        public string NameBook { get; set; }
        public string Autor { get; set; }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override bool Equals(object? obj)
        {
            return this.ToString() == obj.ToString();
        }
        public override string ToString()
        {
            return $"{Autor} - {NameBook}";
        }
        public static Book InputBook()
        {
            Book book = new Book();
            WriteLine("Название книги: ");
            book.NameBook = ReadLine();
            WriteLine("Автор книги: ");
            book.Autor = ReadLine();
            return book;
        }
    }

    class ListBook
    {
        Book[] _bookArr;
        public int Length
        {
            get { return _bookArr.Length; }
        }
        public ListBook(int size)
        { _bookArr = new Book[size]; }

        public Book this[int index]
        {
            get
            {
                if(index>=0&&index<_bookArr.Length)
                    return _bookArr[index];
                throw new IndexOutOfRangeException();
            }
            set { _bookArr[index] = value;}
        }
        public static bool operator ==(ListBook list, Book book)
        {
            for (int i = 0; i < list.Length; i++)
            {
                if (book.Equals(list[i]))
                    return true;
            }
            return false;
        }
        public static bool operator !=(ListBook list, Book book)
        {
            return !(list == book);
        }

        public void DeleteBook(Book book)
        {
            this._bookArr = this._bookArr.Except(new Book[] {book}).ToArray();
        }
        public ListBook AddBook(Book book)
        {
            Array.Resize(ref this._bookArr, this.Length + 1);
            this[this.Length - 1] = book;
            return this;
        }
        public void PrintList()
        {
            WriteLine("Список для чтения:");
            for (int i = 0; i < Length; i++)
            {
                WriteLine("\t"+this[i]);
            }
        }
       public void Save()
        {
            string path = "listBook.txt";
            using (FileStream fs = new FileStream(path,FileMode.Create))
            {
                using(StreamWriter sw = new StreamWriter(fs,Encoding.Unicode))
                {
                    for (int i = 0; i < Length; i++)
                    {
                        sw.WriteLine(this[i]);
                    }
                    WriteLine("\tСписок сохранен в файл 'listBook.txt'!");
                }
            }
        }
        public void Read()
        {
            string path = "listBook.txt";
            int count = File.ReadLines(path).Count();
            using (FileStream fs = new(path,FileMode.Open))
            {
                using(StreamReader sr = new StreamReader(fs,Encoding.Unicode))
                {
                    
                    string? line;
                    string[] arr = new string[count];
                    int i = 0;
                    while ((line = sr.ReadLine()) != null)
                    {
                        arr[i] = line;
                        i++;
                    }
                    for (int j = 0; j < arr.Length; j++)
                    {
                        string[] temp = arr[j].Split('-');
                        Book tempBook = new Book();
                        tempBook.Autor = temp[0];
                        tempBook.NameBook = temp[1];
                        this.AddBook(tempBook);
                    }
                    WriteLine("\tЗагружен список из файла!\n");
                }
            }
        }

    }

    private static void Main(string[] args)
    {
        ListBook list = new(3);
        list[0] = new Book { NameBook = "Война и мир", Autor = "Л.Н.Толстой" };
        list[1] = new Book { NameBook = "Идиот", Autor = "Ф.М.Достоевский" };
        list[2] = new Book { NameBook = "Три мушкетера", Autor = "А.Дюма" };

        list.AddBook(Book.InputBook());
        list.PrintList();
        Book newBook = Book.InputBook();
        if (list == newBook)
            list.DeleteBook(newBook);
        else
            WriteLine("Данной книги нет в списке!");
        list.PrintList();
        list.Save();
        ListBook list2 = new(0);
        list2.Read();
        list2.PrintList();
    }
}
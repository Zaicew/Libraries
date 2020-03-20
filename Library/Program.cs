using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libraries
{
    class Program
    {
        static void Main(string[] args)
        {

            Library l1 = new Library("Birkhøjterrasserne 402E, 3520 Farum, Danmark");

            LibraryWorker lw1 = new LibraryWorker("Daniel", "Zajas", "20.03.2020", 12000);
            LibraryWorker lw2 = new LibraryWorker("Justyna", "Kostka", "15.03.2020", 8000);
            LibraryWorker lw3 = new LibraryWorker("Adrian", "Bujakiewicz", "10.10.2005", 3555.55);
            LibraryWorker lw4 = new LibraryWorker("Dawid", "Baurycza", "20.03.2020", 1223.45);

            Catalog Horror = new Catalog("Horror");
            Catalog Adventure = new Catalog("Adventure");
            Catalog Family = new Catalog("Family");
            Catalog Drama = new Catalog("Drama");

            Book b1 = new Book("harry potter1", 1, "pwk1", 2001, 100);
            Book b2 = new Book("harry potter2", 2, "pwk2", 2002, 200);
            Book b3 = new Book("harry potter3", 3, "pwk3", 2003, 300);
            Book b4 = new Book("harry potter4", 4, "pwk4", 2004, 400);
            Book b5 = new Book("harry potter5", 5, "pwk5", 2005, 500);
            Book b6 = new Book("harry potter6", 6, "pwk6", 2006, 600);

            Magazine m1 = new Magazine("topic1", 1, "new york times1", 2020, 10);
            Magazine m2 = new Magazine("topic2", 2, "new york times2", 2020, 20);
            Magazine m3 = new Magazine("topic3", 3, "new york times3", 2020, 30);
            Magazine m4 = new Magazine("topic4", 4, "new york times4", 2020, 40);
            Magazine m5 = new Magazine("topic5", 5, "new york times5", 2020, 50);

            Author a1 = new Author("Justyna", "Rowling", "Poland");
            Author a2 = new Author("Daniel", "Zajas", "Poland");

            l1.AddCatalog(Horror);
            l1.AddCatalog(Adventure);
            l1.AddCatalog(Family);
            l1.AddCatalog(Drama);

            Horror.AddPosition(b1);
            Horror.AddPosition(b2);
            Horror.AddPosition(b3);
            Horror.AddPosition(b4);
            Horror.AddPosition(b5);
            Horror.AddPosition(b6);

            b1.AddAuthor(a1);
            b1.AddAuthor(a2);
            b2.AddAuthor(a1);
            b3.AddAuthor(a1);
            b4.AddAuthor(a1);
            b5.AddAuthor(a1);
            b5.AddAuthor(a1);
            b6.AddAuthor(a1);

            //l1.ShowAllPositions();

            b1.AddPosition(b1, "cos");
            Adventure.AddPosition(b1);
            Adventure.AddPosition(b2);
            Adventure.AddPosition(b3);
            Adventure.AddPosition(b4);
            Adventure.AddPosition(b5);
            Adventure.AddPosition(b6);

            Drama.AddPosition(m1);
            Drama.AddPosition(m2);
            Drama.AddPosition(m3);
            Drama.AddPosition(m4);
            Drama.AddPosition(m5);

            l1.ShowAllPositions();

            Console.WriteLine("_____________________________________________________________");

            Console.WriteLine(l1.FindPositionByTitle("harry potter1"));

            Console.WriteLine("_____________________________________________________________");

            l1.FindPositionById(1);

            Console.WriteLine("_____________________________________________________________");
            b1.AddPosition(b1, "cos");

            Console.WriteLine("_____________________________________________________________");
            l1.AddLibraryWorker(lw1);
            l1.AddLibraryWorker(lw2);
            l1.AddLibraryWorker(lw3);
            l1.AddLibraryWorker(lw4);
            l1.ShowLibraryWorkers();
            
            Console.ReadKey();


        }
    }
}

interface IManagementOfPositions
{
    string FindPositionByTitle(string title_);
    void FindPositionById(int id_);
    void ShowAllPositions();

}

class Catalog : Library, IManagementOfPositions
{
    public string topicOfCatalog { get; private set; }
    public List<Position> position = new List<Position>();

    public Catalog()
    {
    }

    public Catalog(string topicOfCatalog_)
    {
        this.topicOfCatalog = topicOfCatalog_;
    }

    public void AddPosition(Position b1, string topicOfCatalog_)
    {
        b1.topicOfCatalog = topicOfCatalog_;
        position.Add(b1);
    }
    public void AddPosition(Position b1)
    {
        b1.topicOfCatalog = topicOfCatalog;
        position.Add(b1);
    }
}

abstract class Position : Catalog
{
    public string Topic { get; protected set; }
    public int Id { get; protected set; } = 0;
    protected string publishingHouse;
    protected int yearOfPublication;

    public Position()
    {

    }

    public Position(string topic_, int id_, string publishingHouse_, int yearOfPublication_)
    {
        this.Topic = topic_;
        this.Id = id_;
        this.publishingHouse = publishingHouse_;
        this.yearOfPublication = yearOfPublication_;
    }

    public virtual string ShowInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Topic of catalog: " + topicOfCatalog + ", topic of position: " +
                Topic + ", id: " + Id + ", publishing house: " +
                publishingHouse + ", year of publication: " + yearOfPublication);
        sb.Append("\n");
        return sb.ToString();
    }

}

class Book : Position
{
    public int numberOfPages { get; private set; }
    public List<Author> author = new List<Author>();

    public Book()
    {

    }

    public Book(string topic_, int id_, string publishingHouse_, int yearOfPublication_, int numberOfPages_) :
        base(topic_, id_, publishingHouse_, yearOfPublication_)
    {
        this.numberOfPages = numberOfPages_;
    }

    public override string ShowInfo()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Topic of catalog: " + topicOfCatalog + ", topic of position: " +
                Topic + ", id: " + Id + ", publishing house: " +
                publishingHouse + ", year of publication: " + yearOfPublication + " number of pages: " + numberOfPages + " " + ShowAuthorList());
        sb.Append("\n");
        return sb.ToString();
    }

    public void AddAuthor(Author a1)
    {
        author.Add(a1);
    }
    public StringBuilder ShowAuthorList()
    {
        StringBuilder sb = new StringBuilder();
        sb.Append("Authors: ");
        for (int i = 0; i < author.Count; i++)
            {
                Author o = author[i];
                sb.Append("\n");
                sb.Append(o.Name + " " + o.Surname + ", ");
            }
        return sb;
    }
}

class Magazine : Position
{
    public int numberOfPublication { get; private set; }

    public Magazine()
    {

    }

    public Magazine(string topic_, int id_, string publishingHouse_, int yearOfPublication_, int numberOfPublication_) :
        base(topic_, id_, publishingHouse_, yearOfPublication_)
    {
        this.numberOfPublication = numberOfPublication_;
    }
}

class Author : Person
{
    public string nationality;

    public Author()
    {

    }

    public Author(string name_, string surname_, string nationality_) : base (name_, surname_)
    {
        this.nationality = nationality_;
    }
}

class Library : IManagementOfPositions
{
    private string adres;
    public List<Catalog> catalogs = new List<Catalog>();
    public List<LibraryWorker>  libraryWorkers = new List<LibraryWorker>();

    public Library()
    {

    }

    public Library(string adres_)
    {
        this.adres = adres_;
    }

    public string FindPositionByTitle(string title_)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < catalogs.Count; i++)
        {
            Catalog c = catalogs[i];
            sb.Append(c.topicOfCatalog + "\n");
            for (int j = 0; j < c.position.Count; j++)
            {
                if (c.position[j].Topic == title_)
                {
                    Position o = c.position[j];
                    sb.Append(o.ShowInfo());
                }

            }
        }

        return sb.ToString();
    }


    public void FindPositionById(int id_)
    {
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < catalogs.Count; i++)
            {
                Catalog c = catalogs[i];
                sb.Append(c.topicOfCatalog + "\n");
                for (int j = 0; j < c.position.Count; j++)
                {
                    if (c.position[j].Id == id_)
                    {
                        Position o = c.position[j];
                        sb.Append(o.ShowInfo());
                    }

                }
            }

            Console.Write(sb.ToString());
        }
    }

    public void ShowAllPositions()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i< catalogs.Count; i++)
        {
            Catalog c = catalogs[i];
            sb.Append(c.topicOfCatalog + "\n");
            for (int j = 0; j< c.position.Count; j++)
            {
                Position o = c.position[j];
                sb.Append(o.ShowInfo());
            }
        }
        Console.WriteLine(sb.ToString());
    }

    public void AddLibraryWorker(LibraryWorker l1)
    {
        libraryWorkers.Add(l1);
    }

    public void ShowLibraryWorkers()
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i<libraryWorkers.Count; i++)
        {
            LibraryWorker l = libraryWorkers[i];
            sb.Append("\nName: " + l.Name + " " + ", surname: "+ l.Surname + ", salary: " + l.Salary + ", hire date: " + l.HiringDate);
        }

        Console.WriteLine(sb.ToString());
    }

    public void AddCatalog(Catalog c1)
    {
        catalogs.Add(c1);
    }
}

class Person
{
    public string Name { get; protected set; }
    public string Surname { get; protected set; }

    public Person()
    {

    }

    public Person(string name_, string surname_)
    {
        this.Name = name_;
        this.Surname = surname_;
    }
}

class LibraryWorker : Person
{
    public string HiringDate { get; private set; }
    public double Salary { get; private set; }

    public LibraryWorker()
    {

    }
    public LibraryWorker(string name_, string surname_, string hiringDate_, double salary_) : base (name_, surname_)
    {
        this.HiringDate = hiringDate_;
        this.Salary = salary_;
    }
}
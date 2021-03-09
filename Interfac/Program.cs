using System;

namespace Interfac
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person() { FIO = "Пушкин", Age = 12 };
            Person p2 = new Person() { FIO = "Толстой Л.Н.", Age = 35 };
            Console.WriteLine("{0}>{1}={2}",p1.FIO,p2.FIO,p1>p2);
            Console.WriteLine("{0}<{1}={2}", p1.FIO, p2.FIO, p1 < p2);
            Person p3 = (Person)p1.Clone();
            p3.FIO = "Лермонтов М.Ю.";
            p3.Age = 67;
            Console.WriteLine("{0}<{1}={2}", p1.FIO, p3.FIO, p1 < p3);
            Person[] authors = new Person[3];
            authors[0] = p1;
            authors[1] = p2;
            authors[2] = p3;
            Person person = new Person(authors);
            foreach(Person auth in person)
            {
                Console.WriteLine(auth.FIO+" "+auth.Age);
            }
            foreach(Person auth in person.ReverseIterator())
            {
                Console.WriteLine(auth.FIO + " " + auth.Age);
            }
            People people = new People(authors);
            try 
            {
                Person person1 = new Person() { FIO = "Лужис ужас", Age = 18 };
                people.MoveNext();
                people.Current = person1;
                people.Reset();
                while(true)
                {
                    people.MoveNext();
                    person1 = (Person)people.Current;
                    Console.WriteLine(person1.FIO + " " + person1.Age);
                }
            }
            catch(InvalidOperationException)
            {
                people.Reset();
            }
        }
    }
}

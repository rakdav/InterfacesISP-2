using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Interfac
{
    class Person:IComparable,ICloneable, System.Collections.IComparer,IEnumerable,ISerializable
    {
        protected int size;
        protected Person[] container;

        public Person()
        {
            size = 10;
            container = new Person[size];
        }
        public Person(int n)
        {
            size = n;
            container = new Person[size];
        }
        public Person(Person[] cont)
        {
            this.container = cont;
            size = container.Length;
        }
        public string FIO { get; set; }
        public int Age { get; set; }

        public int CompareTo(object obj)
        {
            const string s = "Is not Person class";
            Person p = obj as Person;
            if (!p.Equals(null))
                return (FIO.CompareTo(p.FIO));
            throw new NotImplementedException();
        }

        public object Clone()
        {
            return new Person() { FIO = this.FIO, Age = this.Age };
        }

        public int Compare(object fio1, object fio2)
        {
            if (fio1.Equals(fio2)) return 0;
            else if (fio1.Equals(fio2)) return -1;
            return 1;
        }

        public IEnumerator GetEnumerator()
        {
            return container.GetEnumerator();
        }

        public IEnumerable ReverseIterator()
        {
            for (int i = container.Length - 1; i >= 0; i--)
                yield return container[i];
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Князев", FIO, typeof(string));
        }

        public static bool operator >(Person p1,Person p2)
        {
            return (p1.CompareTo(p2) > 0);
        }
        public static bool operator <(Person p1, Person p2)
        {
            return (p1.CompareTo(p2) < 0);
        }
        public static bool operator >=(Person p1, Person p2)
        {
            return (p1.CompareTo(p2) >= 0);
        }
        public static bool operator <=(Person p1, Person p2)
        {
            return (p1.CompareTo(p2) <= 0);
        }
        public static bool operator ==(Person p1, Person p2)
        {
            return (p1.CompareTo(p2) == 0);
        }
        public static bool operator !=(Person p1, Person p2)
        {
            return (p1.CompareTo(p2) != 0);
        }
    }
}

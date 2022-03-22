using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Text;

namespace T06.EqualityLogic
{
    public class Person : IComparable<Person>
    {
        private string name;
        private int age;

        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
        }

        public int CompareTo(Person other)
        {
            int result = this.name.CompareTo(other.name);
            if (result == 0)
            {
                result = this.age.CompareTo(other.age);
            }
            return result;
        }

        public override bool Equals(object obj)
        {
            return obj is Person person &&
                   this.name == person.name &&
                   this.age == person.age;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(this.name, this.age);
        }
    }
}

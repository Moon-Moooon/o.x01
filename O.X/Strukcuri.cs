using System;
using System.Collections.Generic;
using System.Text;

namespace O.X
{
    class Strukcuri
    {
        struct User
        {
            public string name;
            public int age;
            public User(string name, int age)
            {
                this.name = name;
                this.age = age;
            }
            public void DisplayInfo()
            {
                Console.WriteLine($"Name: {name}  Age: {age}");
            }
        }
    }
}

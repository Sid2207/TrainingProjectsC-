using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqSubmission
{
    public class Person
    {
        public string fname { get; set; }
        public string lname { get; set; }

        public int id { get; set; }
        public Person(string fname, string lname, int id)
        {
            this.fname = fname;
            this.lname = lname;
            this.id = id;

        }
    }

    public class Customer
    {
        public string Name { get; set; }
        public string Bank { get; set; }
        public double Balance { get; set; }
    }
    public class Linqc

    {
        public void handson1()
        {
            var people = new List<Person>()
        {
            new Person("Bill", "Smith", 41),
            new Person("Sarah", "Jones", 22),
            new Person("Stacy","Baker", 21),
            new Person("Vivianne","Dexter", 19 ),
            new Person("Bob","Smith", 49 ),
            new Person("Brett","Baker", 51 ),
            new Person("Mark","Parker", 19),
            new Person("Alice","Thompson", 18),
            new Person("Evelyn","Thompson", 58 ),
            new Person("Mort","Martin", 58),
            new Person("Eugene","DeLauter", 84 ),
            new Person("Gail","Dawson", 19 ),

        };



            var result = from a in people
                         where a.lname.StartsWith("D")
                         select a;

            foreach (var person in result)
            {
                Console.WriteLine(person.lname);
            }

            var result2 = from a in people
                         group a by a.lname.StartsWith("D") into a2
                         select a2;

            foreach (var per in result2)
            {
                if (per.Key) {
                    Console.WriteLine();
                    Console.WriteLine("Name of people starting with letter D");
                    Console.WriteLine();
                    foreach (var person in per)
                    {
                        Console.WriteLine(person.lname);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Count of people having last name starting with D:"+per.Count());
                }
            }

            Console.WriteLine();

            var result3 = from a in people

                         where a.id > 40
                         select a;

            foreach (var per in result3)
            {
                Console.WriteLine(per.fname);

            }

            Console.WriteLine();

            var result4 = from a in people
                          select a;

            foreach(var per in result4)
            {
                Console.WriteLine(per.fname+" "+per.lname);
            }



        }

        public void handson2()
        {
            Console.WriteLine("Enter the word ");
            string inp = Console.ReadLine();

            var result = (from a in inp

                         group a by a into a
                         orderby a.Count() descending

                         select a).Take(1);
                        

            foreach (var n in result)
            {
                Console.WriteLine("Character " + n.Key + " times: " + n.Count());
            }

        }

        public void handson3()
        {
            List<string> nonDupe = new List<string>() { "abc", "xyz", "klm", "xyz", "abc", "abc", "rst" };

            var result = from a in nonDupe

                         group a by a into a

                         select a;
            
            foreach(var n in result)
            {
                if(n.Count()==1)
                Console.WriteLine(n.Key);
            }
        
        }

        public void handson4()
        {
            Console.WriteLine("Enter number of elements");
            int number =Convert.ToInt32 (Console.ReadLine());
            int[] arr = new int[number];
            Console.WriteLine("Enter Value of elements");
            for (int i = 0; i < number; i++)
            {
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }
            var result = (from a in arr
                         orderby a descending
                         select a).Take(5) ;

            foreach(var n in result)
            {
                Console.WriteLine(n);
            }


         }

        public void handson5()
        {
            List<string> fruits = new List<string>() { "Lemon", "Apple", "Orange", "Lime", "Watermelon", "Loganberry" };

            var result = from a in fruits
                         where a.StartsWith("L")
                         select a;

            foreach (var fruit in result)
            {
                Console.WriteLine(fruit);
            }


        }

        public void handson6()
        {

            List<int> mixedNumbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var result = from a in mixedNumbers
                         where a % 4 == 0 || a % 6 == 0
                         select a;

            foreach (var mixedNumber in result)
            {
                Console.WriteLine(mixedNumber);
            }

        }

        public void handson7()
        {
            List<int> numbers = new List<int>()
            {
                15, 8, 21, 24, 32, 13, 30, 12, 7, 54, 48, 4, 49, 96
            };

            var result = from a in numbers
                         select a;

            Console.WriteLine(result.Count());

        }

        public void handson8()
        {
            List<double> purchases = new List<double>()
          {
                2340.29, 745.31, 21.76, 34.03, 4786.45, 879.45, 9442.85, 2454.63, 45.65
            };

            var result =  (from a in purchases
                          select a).Sum();

            var result2 = (from a in purchases
                          select a).Max();

            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine(result2);

        }   

        public void handson9()
        {
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };

            var result = from a in customers
                         where a.Balance > 1000000
                         group a by a.Bank into a
                         select a;

            foreach(var Cust in result)
            {
                Console.WriteLine("Number of millionare in " +Cust.Key +" : "+ Cust.Count());
                
                foreach (var c in Cust)
                {
                  Console.WriteLine(c.Bank);
                    Console.WriteLine(c.Balance);
                }
            }

            
        }

        public void handson10()
        {
            List<Customer> customers = new List<Customer>() {
                new Customer(){ Name="Bob Lesman", Balance=80345.66, Bank="FTB"},
                new Customer(){ Name="Joe Landy", Balance=9284756.21, Bank="WF"},
                new Customer(){ Name="Meg Ford", Balance=487233.01, Bank="BOA"},
                new Customer(){ Name="Peg Vale", Balance=7001449.92, Bank="BOA"},
                new Customer(){ Name="Mike Johnson", Balance=790872.12, Bank="WF"},
                new Customer(){ Name="Les Paul", Balance=8374892.54, Bank="WF"},
                new Customer(){ Name="Sid Crosby", Balance=957436.39, Bank="FTB"},
                new Customer(){ Name="Sarah Ng", Balance=56562389.85, Bank="FTB"},
                new Customer(){ Name="Tina Fey", Balance=1000000.00, Bank="CITI"},
                new Customer(){ Name="Sid Brown", Balance=49582.68, Bank="CITI"}
            };
            var result = from a in customers
                          
                           group a by a.Bank into a
                                       
                           select a;

            foreach (var Cu in result)
            {
                Console.WriteLine(Cu.Key);

                foreach(var c in Cu)
                {
                    Console.Write("Bank:" + c.Bank + "Balance"+c.Balance);
                    Console.WriteLine();
                    
                        
                    
                }
            }


        }


    }
}


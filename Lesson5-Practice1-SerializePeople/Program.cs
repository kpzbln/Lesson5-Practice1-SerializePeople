﻿using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;


namespace Lesson5_Practice1_SerializePeople
{
    // A simple program that accepts a name, year, month date,
    // creates a Person object from that information, 
    // and then displays that person's age on the console.

    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                // TODO: Deserialize
            }
            else
            {
                try
                {
                    if (args.Length != 4)
                    {
                        throw new ArgumentException("You must provide four arguments: name, year, month, date.");
                    }

                    DateTime dob = new DateTime(Int32.Parse(args[1]), Int32.Parse(args[2]), Int32.Parse(args[3]));
                    Person p = new Person(args[0], dob);
                    Console.WriteLine(p.ToString());

                    Serialize(p);
                }
                catch (Exception ex)
                {
                    DisplayUsageInformation(ex.Message);
                }
            }
        }

        private static void DisplayUsageInformation(string message)
        {
            Console.WriteLine("\nERROR: Invalid parameters. " + message);
            Console.WriteLine("For example: \"Lesson5-Practice1-SerializePeople \"Tony\" 1922 11 22\".");
            Console.WriteLine("Or, run the command with no arguments to display that previous person.");
        }

        private static void Serialize(Person sp)
        {
            // Create file to save the data to
            FileStream fs = new FileStream("Person.Dat", FileMode.Create);

            // Create a BinaryFormatter object to perform the serialization
            BinaryFormatter bf = new BinaryFormatter();

            // Use the BinaryFormatter object to serialize the data to the file
            bf.Serialize(fs, sp);

            // Close the file
            fs.Close();
        }

    }
}

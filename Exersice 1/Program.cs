using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exersice_1
{
    internal class Program
    {
        // Define the dictionary at the class level
        static Dictionary<string, string> contacts = new Dictionary<string, string>();

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Welcome to the Contact Manager App");
                Console.WriteLine("Enter 1 for Displaying Contacts");
                Console.WriteLine("Enter 2 for Adding Contact");
                Console.WriteLine("Enter 3 for Searching");
                Console.WriteLine("Enter 4 for Delete a contact");
                Console.WriteLine("Enter 0 to Exit");
                Console.WriteLine("............................");

                char choice = Console.ReadKey().KeyChar;
                Console.WriteLine();

                if (choice == '0')
                {
                    Console.WriteLine("Exiting...");
                    break; // Exit the loop and program
                }
                else if (choice == '1')
                {
                    Console.Clear();
                    DisplayContacts();
                    Console.Write("Press Enter To Back To the Menu");
                    Console.ReadLine();
                }
                else if (choice == '2')
                {
                    Console.Clear();
                    Console.Write("Enter the Name: ");
                    string name = Console.ReadLine();
                    if (string.IsNullOrWhiteSpace(name))
                    {
                        Console.WriteLine("Name cannot be empty");
                        continue;
                    }
                    Console.Write("Enter the Contact: ");
                    string contact = Console.ReadLine();
                    if (contacts.ContainsKey(name))
                    {
                        Console.WriteLine("This contact already exists!");
                        continue;
                    }
                    AddContact(name, contact);
                    Console.WriteLine("Contact added successfully");
                    Console.Write("Press Enter To Back To the Menu");
                    Console.ReadLine();
                }
                else if (choice == '3')
                {
                    Console.Clear();
                    Console.Write("Enter a name to search: ");
                    string searchName = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(searchName))
                    {
                        SearchContact(searchName);
                    }
                    else
                    {
                        Console.WriteLine("Please enter a valid name");
                    }
                    Console.Write("Press Enter To Back To the Menu");
                    Console.ReadLine();
                }
                else if (choice == '4')
                {
                    Console.Clear();
                    Console.Write("Enter a name to delete: ");
                    string deleteName = Console.ReadLine();
                    DeleteContact(deleteName);
                    Console.Write("Press Enter To Back To the Menu");
                    Console.ReadLine();
                }
                else
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                }
            }
        }

        static void DisplayContacts()
        {
            Console.WriteLine("Contact List:");
            if (contacts.Count == 0)
            {
                Console.WriteLine("No contacts available.");
            }
            else
            {
                foreach (var contact in contacts)
                {
                    Console.WriteLine($"Name: {contact.Key}, Contact: {contact.Value}");
                }
            }
        }

        static void AddContact(string name, string contact)
        {
            try
            {
                contacts.Add(name, contact);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        static void SearchContact(string searchName)
        {
            if (contacts.TryGetValue(searchName, out string contact))
            {
                Console.WriteLine($"Found: {searchName}, Contact: {contact}");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }

        static void DeleteContact(string fullName)
        {
            if (contacts.Remove(fullName))
            {
                Console.WriteLine("Contact deleted successfully.");
            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
        }
    }
}

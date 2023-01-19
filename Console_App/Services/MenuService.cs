
using Console_App.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace Console_App.Services;

internal class MenuService
{
    //StartUp
    private ObservableCollection<Contact> contacts = new ObservableCollection<Contact>();
    private readonly FileService file = new FileService();

    public MenuService()
    {
        populateContactList();
    }

    //Tries to populate contact-list with Json-file
    public void populateContactList()
    {
        try
        {
            var items = JsonConvert.DeserializeObject<ObservableCollection<Contact>>(file.Read());

            if (items != null)
            {
                contacts = items;
            }
        }
        catch { }
    }

    
    // Main menu
    public void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("Address Book");
        Console.WriteLine("Welcome\n");

        Console.WriteLine("1. Add New Contact");
        Console.WriteLine("2. Show All Contacts");
        Console.WriteLine("3. Search For Contact");
        Console.WriteLine("4. Delete Contact");
        Console.Write("Choose Alternative: ");
        int option = Convert.ToInt32(Console.ReadLine());

        switch(option) 
        {
            //Add New contact
            case 1:
                Console.Clear();
                NewContactMenu();
                break;

            // View All Contacts
            case 2:

                Console.Clear();
                Console.WriteLine("Contacts\n");
                
                foreach (Contact contact in contacts)
                {
                    Console.WriteLine($"{contact.FirstName}, {contact.LastName}\n{contact.Email}\n");
                }
                Console.ReadKey();

                break;

            // Search For Specific Contact
            case 3:
                Console.Clear();
                ContactSearch();
                break;

            // Delete Contact
            case 4:
                Console.Clear();
                RemoveContact();
                break;
        }
    }

    //Add contact Menu
    private void NewContactMenu()
    {
        bool cusotmerInputCorrect = false;

        do
        {
            // Get Input
            Console.Clear();
            Contact contact = new Contact();

            Console.WriteLine("Add New Contact\n");
            Console.Write("First Name: ");
            contact.FirstName = Console.ReadLine()!.ToLower() ?? "Unknown";
            Console.Write("Last Name: ");
            contact.LastName = Console.ReadLine()!.ToLower() ?? "Unknown";
            Console.Write("Email: ");
            contact.Email = Console.ReadLine()!.ToLower() ?? "Unknown";
            Console.Write("Phone Number: ");
            contact.Phone = Console.ReadLine()!.ToLower() ?? "Unknown";
            Console.Write("Street Name: ");
            contact.Street = Console.ReadLine()!.ToLower() ?? "Unknown";
            Console.Write("Zip Code: ");
            contact.ZipCode = Console.ReadLine()!.ToLower() ?? "Unknown";
            Console.Write("City: ");
            contact.City = Console.ReadLine()!.ToLower() ?? "Unknown";

            // Check if input is accurate
            Console.Clear();
            Console.WriteLine("Is This Accurate?\n");
            Console.WriteLine($"{contact.FirstName}, {contact.LastName}\n{contact.Email}\n{contact.Phone}\n{contact.Adress}\n");
            Console.WriteLine("y/n:");
            string isInputAccurate = Console.ReadLine()!.ToLower();

            // adds new contact if input is right, tries again if not.
            if (isInputAccurate == "y")
            {
                Console.Clear();
                contacts.Add(contact);
                file.Save(JsonConvert.SerializeObject(contacts));
                Console.WriteLine("Great!\nYour Contact Is Added");
                Console.ReadKey();
                cusotmerInputCorrect = true;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Oops!\nLet's Try Again!");
                Console.ReadKey();
                cusotmerInputCorrect = false;
            }

        } while (cusotmerInputCorrect == false);

    }

    //Find Contact Menu
    private void ContactSearch()
    {
        bool contactFound = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Search For Contact\nPlease Enter ID Of The Person You Whant To Find\n");
            string id = Console.ReadLine() ?? "";

            if (id != "")
            {
                Contact contactFind = contacts.FirstOrDefault(c => c.Id.ToString() == id);

                if (contactFind != null)
                {
                    Console.WriteLine($"\n{contactFind.FirstName}, {contactFind.LastName}\n{contactFind.Email}\n{contactFind.Phone}\n{contactFind.Adress}\n");
                    Console.ReadKey();
                    contactFound = true;
                }
                else
                {
                    Console.WriteLine("\nSorry!\nWe Didn't Find Anyone With That Id.\nWould You Like To Try For Another One?\ny/n");
                    string tryAgain = Console.ReadLine()!.ToLower();

                    if (tryAgain == "y")
                    {
                        contactFound = false;
                    }
                    else
                    {
                        contactFound = true;
                    }
                }
            }
        }while (contactFound == false);
    }

    //Remove Contact Menu
    private void RemoveContact()
    {
        bool contactFound = false;
        do
        {
            Console.Clear();
            Console.WriteLine("Search For Contact\nPlease Enter ID Of The Person You Whant To Remove\n");
            string id = Console.ReadLine() ?? "";

            if (id != "")
            {
                Contact contactFind = contacts.FirstOrDefault(c => c.Id.ToString() == id);

                if (contactFind != null)
                {
                    Console.WriteLine($"\n{contactFind.FirstName}, {contactFind.LastName}\n{contactFind.Email}\n{contactFind.Phone}\n{contactFind.Adress}\n");
                    Console.WriteLine("\nAre You Sure You Whant To Remove This Contact Forever (A Very Long Time)\ny/n");
                    string removeChoice = Console.ReadLine()!.ToLower();

                    if (removeChoice == "y")
                    {

                        contacts.Remove(contactFind);
                        file.Save(JsonConvert.SerializeObject(contacts, Formatting.Indented));
                        contactFound = true;
                    }
                    else
                    {
                        contactFound = true;
                    }
                }
                else
                {
                    Console.WriteLine("\nSorry!\nWe Didn't Find Anyone With That Id.\nWould You Like To Try For Another One?\ny/n");
                    string tryAgain = Console.ReadLine()!.ToLower();

                    if (tryAgain == "y")
                    {
                        contactFound = false;
                    }
                    else
                    {
                        contactFound = true;
                    }
                }
            }
        } while (contactFound == false);
    }
}






using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



public class ProgramUI
{
    //access the database (ContactDictionaryRepository)
    private ContactDictioaryRepository _contactRepo = new ContactDictioaryRepository();
    public void Run()
    {
        Seed();
        RunApplication();
    }

    private void RunApplication()
    {
        bool isRunning = true;
        while (isRunning)
        {
            Console.Clear();
            System.Console.WriteLine("Welcome to AddressBook \n"+
                                    "1. AddContact\n"+
                                    "2. ShowAllContacts\n"+
                                    "3. GetContactByName\n"+
                                    "4. UpdateContactByID\n"+
                                    "5. DeleteContact\n"+
                                    "00. Close Application");
        var userInput = Console.ReadLine();
            switch (userInput)
            {
             case "1":
             AddContact();
             break;
             case "2":
             ShowAllContacts();
             break;
             case "3":
             GetContactByName();
             break;
             case "4":
             UpdateContactByID();
             break;
             case "5":
             DeleteContact();
             break;
             case "00":
             isRunning = Quit();
             break;
             default:
             System.Console.WriteLine("Invalid Selection");
             break;


            }    
        }
    }

    private void Seed()
    {

        var contactA = new Contact
        {
            ID = 1,
            Name = "Alex",
            Address = "California Way",
            Email = "Alex@gmail.com",
            PhoneNumber = "4159665773"
        };

        var contactB = new Contact
        {
            ID = 2,
            Name = "Harper",
            Address = "Berkely Way",
            Email = "Harper@gmail.com",
            PhoneNumber = "4159600073"
        };

        var contactC = new Contact
        {
            ID = 3,
            Name = "Vera",
            Address = "Telegraph street",
            Email = "Vera@gmail.com",
            PhoneNumber = "4159699973"
        };

        var contactD = new Contact
        {
            ID = 4,
            Name = "Sara",
            Address = "San Pablo street",
            Email = "Sara@gmail.com",
            PhoneNumber = "4139973678"
        };

        //we need to add to the database
        _contactRepo.AddContact(contactA);
        _contactRepo.AddContact(contactB);
        _contactRepo.AddContact(contactC);
        _contactRepo.AddContact(contactD);

    }
    private void AddContact()
    {
        Console.Clear();
        Contact contactForm =  new Contact();
       
        System.Console.WriteLine($"Please add a Contact Name:");
        string userInputName = Console.ReadLine()!;
        contactForm.Name = userInputName;

        System.Console.WriteLine($"Please add a Contact Address:");
        string userInputAddress = Console.ReadLine()!;
        contactForm.Address = userInputAddress;

        System.Console.WriteLine($"Please add a Contact Email:");
        string userInputEmail = Console.ReadLine()!;
        contactForm.Email = userInputEmail;

        System.Console.WriteLine($"Please add a Contact PhoneNumber:");
        string userInputPhoneNumber = Console.ReadLine()!;
        contactForm.PhoneNumber = userInputPhoneNumber;
       
    

        if ( _contactRepo.AddContact(contactForm))
        {
            System.Console.WriteLine("Succes!");
        }
        else
        {
            System.Console.WriteLine("Fail!");
        }

        Console.ReadKey();
    }
    private void ShowAllContacts()
    {
        Console.Clear();
        foreach(var contact in _contactRepo.GetContact())
        {
            System.Console.WriteLine(contact);
        }
        Console.ReadKey();
    }
    private void GetContactByName()
    {
        Console.Clear();
        System.Console.WriteLine($"Contact info");
        System.Console.WriteLine("please enter the contact Name.");
        var userInput = Console.ReadLine();

       
        var contact = _contactRepo.GetContactByName(userInput);


        System.Console.WriteLine($"{contact}\n");

        Console.ReadKey();
    }
    private void UpdateContactByID()
    {
         try
        {
            Console.Clear();
            System.Console.WriteLine("Please Enter a Contact ID:");
            int userInputContactID = int.Parse(Console.ReadLine()!);
            Contact selectedContact = _contactRepo.GetContact(userInputContactID);

            if (selectedContact != null)
            {

                Contact updateContactData = new Contact();
                System.Console.WriteLine("Please enter the Contact Name:");
                string userInputName = Console.ReadLine()!;
                updateContactData.Name = userInputName;

                System.Console.WriteLine("What is the Contact Address?");
                string userInputAddress = Console.ReadLine()!;
                updateContactData.Address = userInputAddress;

                System.Console.WriteLine("What is the contact Email ?");
                string userInputEmail = Console.ReadLine()!;
                updateContactData.Email = userInputEmail;

                System.Console.WriteLine("What is the contact PhoneNumber ?");
                string userInputPhoneNumber = Console.ReadLine()!;
                updateContactData.Email = userInputPhoneNumber;

                if (_contactRepo.UpdateContact(selectedContact.ID, updateContactData))
                {
                    System.Console.WriteLine("Success!");
                }
                else
                {
                    System.Console.WriteLine("Fail!");
                }
               
            }
            else
            {
                Console.ReadKey();
            }
        }

        catch (Exception ex)
        {
            System.Console.WriteLine(ex.Message);
        }
  

    }

    private bool Quit()
    {
        System.Console.WriteLine("Thank you see you soon.");
        Console.ReadKey();
        return false;
    }

    private void DeleteContact()
    {
        Console.Clear();

        try
        {
            System.Console.WriteLine("Please select  a contact by ID:");
            int userInputContactID = int.Parse(Console.ReadLine()!);
            var isValidated = ValidateContactInDatabase(userInputContactID);
            if(isValidated)
            {
                System.Console.WriteLine("Do you want to delete this contact? y/n");
                string userInputDeleteContact = Console.ReadLine()!.ToLower()!;
                if(userInputDeleteContact =="y")
                {
                    if(_contactRepo.DeleteContact(userInputContactID))
                    {
                        System.Console.WriteLine("The Contact was Deleted");
                    }
                    else
                    {
                        System.Console.WriteLine("The contact was not Deleted");
                    }
                }
            }
            else
            {
                System.Console.WriteLine($"The contact with the ID; {userInputContactID} does't Exist");
            }
        }
        catch (Exception ex)
        {
            System.Console.WriteLine(ex);
            SomethingWentWrong();
        }
        PressAnyKey();
    }
    
    private void SomethingWentWrong()
    {
        System.Console.WriteLine("Something Went Wrong");
        PressAnyKey();
    
    }
     private bool ValidateContactInDatabase(int userInputContactID)
    {
        Contact contact = GetContactInDatabase(userInputContactID);
        if (contact != null)
        {
            Console.Clear();
            DisplayContactData(contact);
            return true;
        }
        else
        {
            System.Console.WriteLine($"The Contact with the ID: {userInputContactID} dosen't Exist!");

            return false;
        }

        

    }
    private void DisplayContactData(Contact contact)
    {
        System.Console.WriteLine(contact);
    }

    private Contact GetContactInDatabase(int intuserInputContactID)
    {
        return _contactRepo.GetContact(intuserInputContactID);
    }
     private void PressAnyKey()
    {
       System.Console.WriteLine("Press Any Key to continue");
       Console.ReadKey();
    }
}
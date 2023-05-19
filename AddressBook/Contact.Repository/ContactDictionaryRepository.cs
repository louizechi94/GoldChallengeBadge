using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


    public class ContactDictionaryRepository
    {
        private readonly Dictionary<int,Contact> _contactDb = new Dictionary<int, Contact>();
        private int _count = 0;

        //C.R.U.D

        //Create
        public bool AddContact(Contact contact)
        {
            if(contact is null)
            {
                return false;
            }
            else
            {
                _count++;
                contact.ID = _count;
                _contactDb.Add(contact.ID,contact);
                return true;
            }
        }

        //Read All
        public Dictionary<int,Contact> GetContact()
        {
            return _contactDb;
        }

        //Read by ID
        public Contact GetContact(int key)
        {
            foreach (KeyValuePair<int,Contact> contact in _contactDb)
            {
               if(contact.Key == key) 
               {
                return contact.Value;
               }
            }
            return null;
        }
        public Contact GetContactByName(string name)
        {
            return _contactDb.FirstOrDefault(c => c.Value.Name.ToLower()==name.ToLower()).Value;
        }

        //Update
        public bool UpdateContact(int key, Contact newContactData)
        {
            
            Contact oldContactData = GetContact(key);
            if (oldContactData != null)
            {
                oldContactData.Name = newContactData.Name;
                oldContactData.Address = newContactData.Address;
                oldContactData.Email = newContactData.Email;
                oldContactData.PhoneNumber = newContactData.PhoneNumber;
                return true;
            }
            return false;
        }

        //Delete
        public bool DeleteContact(int key)
        {
            return _contactDb.Remove(key);
  
        }

    }

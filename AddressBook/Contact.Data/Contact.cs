using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


   public class Contact
    {
        public Contact()
       
        {
            
        }
        public Contact(string name, string address, string email, string phoneNumber )
        {
          Name = name;
          Address = address;
          Email = email;
          PhoneNumber =  phoneNumber;
        }

        public int ID { get; set;}
        public string Name { get; set;}
        public string Address { get; set; }
        public string Email { get; set; }
        public string  PhoneNumber{ get; set; }

     public override string  ToString()
     {
       var str = $"ID: {ID}\n"+
       $"Name: {Name}\n"+
       $"Address: {Address}\n"+
       $"Email: {Email}\n"+
       $"PhoneNumber: {PhoneNumber}\n"+
       "============================\n";
       return str;
     }   
    }


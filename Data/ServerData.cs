using System;
using System.Collections.Generic;
using System.Linq;
using Assignment_1.Models;
using FileData;

namespace Assignment_1.Data
{
    public class ServerData:IServerData
    {
        private FileContext fileContext;
        private IList<Family> families;

        public ServerData()
        {
            fileContext = new FileContext();
            families = fileContext.Families;
        }
        public IList<Family> getAllFamily()
        {
            return fileContext.Families;
        }

   
        public void AddNewAdult(int fId, Adult adult)
        {
            Console.WriteLine("Trying to write Element ####################");
            Family first = fileContext.Families.First(family => family.Id == fId);
            Console.WriteLine("Family is  "+ first.HouseNumber);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            if (!first.Adults.Any())
            {
                adult.Id = 0;
            }
            else
            {
                adult.Id = first.Adults.Max(d => d.Id) + 1;
            }
            
            Console.WriteLine("Added id "+ adult.Id+" ############################");
            first.Adults.Add(adult);

            Console.WriteLine("Adult addes "+ adult.FirstName);
            fileContext.SaveChanges();

            
        }

        public void AdNewChild(int fId, Child child)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            
            first.Children.Add(child);
            fileContext.SaveChanges();

            
        }

        public void AddNewPet(int fId, Pet pet)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }
            
            first.Pets.Add(pet);
        }

        public void AddNewChildPet(int fId, int childId, Pet pet)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            Child child = first.Children.First(child => child.Id == childId);
            if (child == null)
            {
                throw new Exception("Child not found");
            }
            child.Pets.Add(pet);
            fileContext.SaveChanges();

        }
        

        public void UpdateAdult(int fId, Adult adult)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            Adult adultf = first.Adults.First(d => d.Id == adult.Id);
            adultf.FirstName = adult.FirstName;
            adultf.LastName = adult.LastName;
            adultf.Age = adult.Age;
            adultf.Height = adult.Height;
            adultf.Sex = adult.Sex;
            
            fileContext.SaveChanges();

        }

        public void UpdateChild(int fId, Child child)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            Child fChild = first.Children.First(c => c.Id == child.Id);
            fChild.FirstName = child.FirstName;
            fChild.LastName = child.LastName;
            fChild.Age = child.Age;
            fChild.Sex = child.Sex;
            fChild.Interests = child.Interests;
            fChild.Height = child.Height;
            fChild.Weight = child.Weight;
            
            fileContext.SaveChanges();

        }

        public void UpdatePet(int fId, Pet pet)
        {
            throw new NotImplementedException();
        }

        public void UpdateChildPet(int fId, int childId, Pet pet)
        {
            throw new NotImplementedException();
        }

        public void UpdateAddress(int fId, string StName, int HouseNumebr)
        {
            throw new NotImplementedException();
        }

        public Adult GetAdult(int fId, int id)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            return first.Adults.First(a => a.Id == id);
        }

        public Child GetChild(int fId, int id)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            return first.Children.First(c => c.Id == id);
        }

        public Pet GetPet(int fId, int id)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            return first.Pets.First(p => p.Id == id);
        }

        public Pet GetChildPet(int fId, int childId, int id)
        {
            throw new NotImplementedException();
        }
        

        public void RemoveAdult(int fId, int id)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            Adult toRemove = first.Adults.First(a => a.Id == id);
            first.Adults.Remove(toRemove);
            fileContext.SaveChanges();
        }


        public void RemoveChild(int fId, int id)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            Child toRemove = first.Children.First(c => c.Id == id);
            first.Children.Remove(toRemove);
            fileContext.SaveChanges();

        }

        

        public void RemovePet(int fId, int id)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            Pet toRemove = first.Pets.First(p => p.Id == id);
            first.Pets.Remove(toRemove);
            fileContext.SaveChanges();

        }

      

        public void RemoveChildPet(int fId, int childId, int id)
        {
            Family first = families.First(family => family.Id == fId);
            if (first == null)
            {
                throw  new Exception("Family not found");    
            }

            Child fChild = first.Children.First(c => c.Id == childId);

            Pet toRemove = fChild.Pets.First(p => p.Id == id);
            fChild.Pets.Remove(toRemove);
            fileContext.SaveChanges();


        }

        public User RegisterNewUser(User user)
        {
            if (user.FirstName == null || user.FirstName.Equals(" "))
            {
                throw new Exception("First name required");
            }  if (user.LastNAme == null || user.LastNAme.Equals(" "))
            {
                throw new Exception("First name required");
            }
            fileContext.Users.Add(user);
            fileContext.SaveChanges();
            return user;
            
        }

        public User ValidateUser(string userName, string password)
        {
            User first = fileContext.Users.First(user => user.Username.Equals(userName));
            if (first == null)
            {
                throw new Exception("User not found");
            }

            if (!first.Password.Equals(password))
            {
                throw new Exception("Incorrect password");
            }

            Console.WriteLine("Returnin user " + first.Username + " "+first.Password);

            return first;
        }
    }
}
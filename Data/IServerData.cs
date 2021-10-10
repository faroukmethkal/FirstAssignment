using System.Collections.Generic;
using Assignment_1.Models;

namespace Assignment_1.Data
{
    public interface IServerData
    {
        IList<Family> getAllFamily();
        void AddNewAdult(int fId, Adult adult);
        void AdNewChild(int fId, Child child);
        void AddNewPet(int fId, Pet pet);
        void AddNewChildPet(int fId, int childId, Pet pet);

        void UpdateAdult(int fId, Adult adult);
        void UpdateChild(int fId, Child child);
        void UpdatePet(int fId, Pet pet);
        void UpdateChildPet(int fId, int childId, Pet pet);
        void UpdateAddress(int fId, string StName, int HouseNumebr);

        Adult GetAdult(int fId, int id);
        Child GetChild(int fId, int id);
        Pet GetPet(int fId, int id);
        Pet GetChildPet(int fId, int childId, int id);


        void RemoveAdult(int fId, int id);

        void RemoveChild(int fId, int id);

        void RemovePet(int fId, int id);

        void RemoveChildPet(int fId, int childId, int id);

        User RegisterNewUser(User user);
        User ValidateUser(string userName, string password);
    }
}
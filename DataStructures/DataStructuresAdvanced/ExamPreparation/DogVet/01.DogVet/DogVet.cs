namespace _01.DogVet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class DogVet : IDogVet
    {
        private Dictionary<string, Dog> dogs;
        private Dictionary<string, Owner> owners;
        private Dictionary<string, ISet<string>> dogsByOwner;

        public DogVet()
        {
            this.dogs = new Dictionary<string, Dog>();
            this.owners = new Dictionary<string, Owner>();
            this.dogsByOwner = new Dictionary<string, ISet<string>>();
        }


        public int Size => this.dogs.Count;

        public void AddDog(Dog dog, Owner owner)
        {
            if (this.Contains(dog))
                throw new ArgumentException();

            this.AddOwnerIfDoesntExists(owner);

            bool containsDogWithSameName
                = this.ContainsDogName(dog.Name, this.dogsByOwner[owner.Id]);

            if (containsDogWithSameName)
                throw new ArgumentException();

            this.dogsByOwner[owner.Id].Add(dog.Id);
        }

        public bool Contains(Dog dog)
        {
            return this.dogs.ContainsKey(dog.Id);
        }

        public Dog GetDog(string name, string ownerId)
        {
            if (!this.owners.ContainsKey(ownerId))
                throw new ArgumentException();

            foreach (var dogId in this.dogsByOwner[ownerId])
            {
                if (this.dogs[dogId].Name == name) return this.dogs[dogId];
            }

            throw new ArgumentException();
        }

        public Dog RemoveDog(string name, string ownerId)
        {
            Dog dog = this.GetDog(name, ownerId);

            this.dogs.Remove(dog.Id);
            this.dogsByOwner[ownerId].Remove(dog.Id);

            return dog;
        }

        public IEnumerable<Dog> GetDogsByOwner(string ownerId)
        {
            if (!this.dogsByOwner.ContainsKey(ownerId))
                throw new ArgumentException();

            return this.GetDogs(this.dogsByOwner[ownerId]);
        }

        public IEnumerable<Dog> GetDogsByBreed(Breed breed)
        {
            ICollection<Dog> filteredDogs = new List<Dog>();

            foreach (var dog in this.dogs.Values)
            {
                if (dog.Breed.Equals(breed))
                {
                    filteredDogs.Add(dog);
                }
            }

            if (filteredDogs.Count == 0)
                throw new ArgumentException();

            return filteredDogs;
        }

        public void Vaccinate(string name, string ownerId)
        {
            Dog dog = this.GetDog(name, ownerId);

            dog.Vaccines++;
        }

        public void Rename(string oldName, string newName, string ownerId)
        {
            Dog dog = this.GetDog(oldName, ownerId);

            dog.Name = newName;
        }

        public IEnumerable<Dog> GetAllDogsByAge(int age)
        {
            ICollection<Dog> filteredDogs = new List<Dog>();

            foreach (var dog in this.dogs.Values)
            {
                if (dog.Age == age) filteredDogs.Add(dog);
            }

            if (filteredDogs.Count == 0)
                throw new ArgumentException();

            return filteredDogs;
        }

        public IEnumerable<Dog> GetDogsInAgeRange(int lo, int hi)
        {
            ICollection<Dog> filteredDogs = new List<Dog>();

            foreach (var dog in this.dogs.Values)
            {
                if (dog.Age >= lo && dog.Age <= hi) filteredDogs.Add(dog);
            }

            return filteredDogs;
        }

        public IEnumerable<Dog> GetAllOrderedByAgeThenByNameThenByOwnerNameAscending()
        {
            IEnumerable<string> keys = this.dogsByOwner.SelectMany(x => x.Value);

            var dogs = this.dogs
                .Where(k => keys.Contains(k.Key))
                .Select(v => v.Value)
                .OrderBy(d => d.Age)
                .ThenBy(d => d.Name);

            return dogs;
        }



        private bool Contains(Owner owner)
        {
            return this.owners.ContainsKey(owner.Id);
        }

        private void AddOwnerIfDoesntExists(Owner owner)
        {
            if (this.owners.ContainsKey(owner.Id)) return;

            this.owners.Add(owner.Id, owner);
            this.dogsByOwner.Add(owner.Id, new SortedSet<string>());
        }

        private bool ContainsDogName(string name, IEnumerable<string> dogIds)
        {
            foreach (var dogId in dogIds)
            {
                if (this.dogs[dogId].Name == name) return true;
            }

            return false;
        }


        private IEnumerable<Dog> GetDogs(IEnumerable<string> keys)
        {
            ICollection<Dog> dogs = new List<Dog>();

            foreach (var key in keys)
            {
                dogs.Add(this.dogs[key]);
            }

            return dogs;
        }

    }
}
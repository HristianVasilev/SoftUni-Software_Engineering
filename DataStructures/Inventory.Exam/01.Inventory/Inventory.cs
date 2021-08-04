namespace _01.Inventory
{
    using _01.Inventory.Interfaces;
    using _01.Inventory.Models;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Inventory : IHolder
    {
        private Dictionary<int, IWeapon> weaponCollection;

        public Inventory()
        {
            this.weaponCollection = new Dictionary<int, IWeapon>();
        }

        public int Capacity => this.weaponCollection.Count;

        public void Add(IWeapon weapon)
        {
            if (!this.weaponCollection.ContainsKey(weapon.Id))
            {
                this.weaponCollection.Add(weapon.Id, weapon);
            }
        }

        public void Clear()
        {
            this.weaponCollection.Clear();
        }

        public bool Contains(IWeapon weapon)
        {
            return this.weaponCollection.ContainsKey(weapon.Id);
        }

        public void EmptyArsenal(Category category)
        {
            foreach (var weapon in this.weaponCollection)
            {
                if (weapon.Value.Category.Equals(category))
                {
                    weapon.Value.Ammunition = 0;
                }
            }
        }

        public bool Fire(IWeapon weapon, int ammunition)
        {
            if (!this.weaponCollection.ContainsKey(weapon.Id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            if (this.weaponCollection[weapon.Id].Ammunition - ammunition < 0)
            {
                return false;
            }

            this.weaponCollection[weapon.Id].Ammunition -= ammunition;

            return true;
        }

        public IWeapon GetById(int id)
        {
            if (!this.weaponCollection.ContainsKey(id))
            {
                return null;
            }

            return this.weaponCollection[id];
        }

        public int Refill(IWeapon weapon, int ammunition)
        {
            if (!this.weaponCollection.ContainsKey(weapon.Id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            IWeapon targetWeapon = this.weaponCollection[weapon.Id];
            targetWeapon.Ammunition = Math.Min(targetWeapon.Ammunition += ammunition, targetWeapon.MaxCapacity);
            return targetWeapon.Ammunition;
        }

        public IWeapon RemoveById(int id)
        {
            if (!this.weaponCollection.ContainsKey(id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            IWeapon weapon = this.weaponCollection[id];
            this.weaponCollection.Remove(id);

            return weapon;
        }

        public int RemoveHeavy()
        {
            List<int> heavyWeaponsIds = new List<int>();

            foreach (var weapon in this.weaponCollection)
            {
                if (weapon.Value.Category.Equals(Category.Heavy))
                {
                    heavyWeaponsIds.Add(weapon.Key);
                }
            }

            foreach (var id in heavyWeaponsIds)
            {
                this.weaponCollection.Remove(id);
            }

            return heavyWeaponsIds.Count;
        }

        public List<IWeapon> RetrieveAll()
        {
            if (this.Capacity == 0)
            {
                return new List<IWeapon>();
            }

            return this.weaponCollection.Values.ToList();
        }

        public List<IWeapon> RetriveInRange(Category lower, Category upper)
        {
            List<IWeapon> weapons = new List<IWeapon>();

            foreach (var item in this.weaponCollection)
            {
                IWeapon weapon = item.Value;
                if (weapon.Category >= lower && weapon.Category <= upper)
                {
                    weapons.Add(weapon);
                }
            }

            return weapons;
        }

        public void Swap(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            if (!this.weaponCollection.ContainsKey(firstWeapon.Id) || !this.weaponCollection.ContainsKey(secondWeapon.Id))
            {
                throw new InvalidOperationException("Weapon does not exist in inventory!");
            }

            if (firstWeapon.Category != secondWeapon.Category)
            {
                return;
            }

            SwapTheWeapons(firstWeapon, secondWeapon);
        }

        public IEnumerator GetEnumerator()
        {
            return this.weaponCollection.GetEnumerator();
        }

        private void SwapTheWeapons(IWeapon firstWeapon, IWeapon secondWeapon)
        {
            var temp = this.weaponCollection[firstWeapon.Id];
            this.weaponCollection[firstWeapon.Id] = this.weaponCollection[secondWeapon.Id];
            this.weaponCollection[secondWeapon.Id] = temp;
        }

    }
}

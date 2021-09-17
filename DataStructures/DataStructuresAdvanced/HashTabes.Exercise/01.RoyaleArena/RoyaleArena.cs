namespace _01.RoyaleArena
{
    using Magnum.Collections;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class RoyaleArena : IArena
    {
        private const int capacity = 8;
        private const int fillFactor = 75;

        private LinkedList<BattleCard>[] slots;
        private int count;

        public RoyaleArena() : this(capacity) { }

        public RoyaleArena(int capacity)
        {
            this.slots = new LinkedList<BattleCard>[capacity];
            this.count = 0;
        }

        public int Count => this.count;
        public int Capacity => this.slots.Length;


        public void Add(BattleCard card)
        {
            this.GrowIfNeeded();

            this.Add(card, ref this.slots);
        }

        public bool Contains(BattleCard card)
        {
            int slotNumber = CalculateSlotNumber(card);

            return this.Contains(card, slotNumber);
        }

        public void ChangeCardType(int id, CardType type)
        {
            BattleCard battleCard;
            try
            {
                battleCard = this.GetById(id);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Message.Equals($"There is no battle card with id: {id}"))
                {
                    throw ex;
                }
                throw ex;
            }

            battleCard.Type = type;
        }

        public BattleCard GetById(int id)
        {
            int slotNumber;

            return this.GetById(id, out slotNumber);
        }

        public void RemoveById(int id)
        {
            int slotNumber;

            BattleCard battleCard = this.GetById(id, out slotNumber);
            this.slots[slotNumber].Remove(battleCard);
            this.count--;
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            ICollection<BattleCard> battleCards = new List<BattleCard>();

            Predicate<BattleCard> predicate = x => x.Type.Equals(type);
            this.FilterCollection(ref battleCards, predicate);

            return battleCards.OrderByDescending(x => x.Damage).ThenBy(x => x.Id);
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            ICollection<BattleCard> battleCards = new List<BattleCard>();

            Predicate<BattleCard> predicate
                = x => x.Type.Equals(type) && x.Damage > lo && x.Damage < hi;
            this.FilterCollection(ref battleCards, predicate);

            return battleCards.OrderByDescending(x => x.Damage).ThenBy(x => x.Id);
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            ICollection<BattleCard> battleCards = new List<BattleCard>();

            Predicate<BattleCard> predicate
                = x => x.Type.Equals(type) && x.Damage <= damage;
            this.FilterCollection(ref battleCards, predicate);

            return battleCards.OrderByDescending(x => x.Damage).ThenBy(x => x.Id);
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            ICollection<BattleCard> battleCards = new List<BattleCard>();

            Predicate<BattleCard> predicate = x => x.Name == name;
            this.FilterCollection(ref battleCards, predicate);

            return battleCards.OrderByDescending(x => x.Swag).ThenBy(x => x.Id);
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            ICollection<BattleCard> battleCards = new List<BattleCard>();

            Predicate<BattleCard> predicate
                = x => x.Name == name && x.Swag >= lo && x.Swag < hi;
            this.FilterCollection(ref battleCards, predicate);

            return battleCards.OrderByDescending(x => x.Swag).ThenBy(x => x.Id);
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            ICollection<BattleCard> battleCards = new List<BattleCard>();

            Predicate<BattleCard> predicate = x => { return true; };
            this.FilterCollection(ref battleCards, predicate);

            if (n > battleCards.Count)
            {
                throw new InvalidOperationException($"There are no {n} count of cards in the arena!");
            }

            return battleCards.OrderBy(x => x.Swag).ThenBy(x => x.Id).Take(n);
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            ICollection<BattleCard> battleCards = new List<BattleCard>();

            Predicate<BattleCard> predicate = x => x.Swag >= lo && x.Swag <= hi;
            try
            {
                this.FilterCollection(ref battleCards, predicate);
            }
            catch (InvalidOperationException ex)
            {
                if (ex.Equals("There are no cards with such precondition!"))
                {
                    return battleCards;
                }
                throw;
            }


            return battleCards.OrderBy(x => x.Swag);
        }

        public IEnumerator<BattleCard> GetEnumerator()
        {
            foreach (var slot in this.slots)
            {
                if (slot == null) continue;

                foreach (var card in slot)
                {
                    yield return card;
                }
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        // Private

        // Add
        private void Add(BattleCard card, ref LinkedList<BattleCard>[] slots)
        {
            int slotNumber = CalculateSlotNumber(card);

            if (slots[slotNumber] == null)
            {
                slots[slotNumber] = new LinkedList<BattleCard>();
            }
            else
            {
                if (this.Contains(card, slots[slotNumber]))
                {
                    throw new ArgumentException("This item alredy exists!");
                }
            }

            slots[slotNumber].AddLast(card);
            this.count++;
        }



        // Resize
        private void GrowIfNeeded()
        {
            if (((double)(this.Count + 1) / this.Capacity * 1.0) * 100 < fillFactor) return;

            this.count = 0;
            LinkedList<BattleCard>[] resizedSlots = this.CreateNewSlot(ref this.slots);
            this.slots = resizedSlots;
        }

        private LinkedList<BattleCard>[] CreateNewSlot(ref LinkedList<BattleCard>[] slots)
        {
            LinkedList<BattleCard>[] resizedSlot = new LinkedList<BattleCard>[slots.Length * 2];

            foreach (var slot in slots)
            {
                if (slot == null) continue;

                foreach (var card in slot)
                {
                    this.Add(card, ref resizedSlot);
                }
            }

            return resizedSlot;
        }



        // GetById
        private BattleCard GetById(int id, out int slotNumber)
        {
            slotNumber = CalculateSlotNumber(id);

            if (this.slots[slotNumber] == null) return null;

            foreach (var card in this.slots[slotNumber])
            {
                if (card.Id.Equals(id)) return card;
            }

            throw new InvalidOperationException($"There is no battle card with id: {id}");
        }



        // Contains
        private bool Contains(BattleCard card, int slotNumber)
        {
            if (this.slots[slotNumber] == null) return false;

            foreach (var cardElement in this.slots[slotNumber])
            {
                if (cardElement.Equals(card)) return true;
            }

            return false;
        }

        private bool Contains(BattleCard card, LinkedList<BattleCard> battleCards)
        {
            foreach (var battleCard in battleCards)
            {
                if (battleCard.Equals(card)) return true;
            }

            return false;
        }


        // Check
        private void FilterCollection(ref ICollection<BattleCard> battleCards, Predicate<BattleCard> predicate)
        {
            foreach (var slot in this.slots)
            {
                if (slot == null) continue;

                foreach (var card in slot)
                {
                    if (predicate(card))
                    {
                        battleCards.Add(card);
                    }
                }
            }

            if (battleCards.Count == 0)
            {
                throw new InvalidOperationException("There are no cards with such precondition!");
            }
        }



        // Other
        private int CalculateSlotNumber(BattleCard card)
        {
            return Math.Abs(card.GetHashCode()) / this.Capacity;
        }

        private int CalculateSlotNumber(int id)
        {
            return Math.Abs(id.GetHashCode()) / this.Capacity;
        }
    }
}
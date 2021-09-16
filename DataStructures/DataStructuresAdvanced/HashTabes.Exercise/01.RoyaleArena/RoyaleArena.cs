namespace _01.RoyaleArena
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public class RoyaleArena : IArena
    {
        private const int capacity = 8;

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
            int slotNumber = CalculateSlotNumber(card);

            if (this.slots[slotNumber] == null)
            {
                this.slots[slotNumber] = new LinkedList<BattleCard>();
            }
            else
            {
                if (this.Contains(card, slotNumber))
                {
                    throw new ArgumentException("This item alredy exists!");
                }
            }

            this.slots[slotNumber].AddLast(card);
            this.count++;
        }

        public bool Contains(BattleCard card)
        {
            int slotNumber = CalculateSlotNumber(card);

            return this.Contains(card, slotNumber);
        }

        public void ChangeCardType(int id, CardType type)
        {
            BattleCard battleCard = this.GetById(id);

            if (battleCard == null) return;

            battleCard.Type = type;
        }

        public BattleCard GetById(int id)
        {
            int slotNumber = CalculateSlotNumber(id);

            if (this.slots[slotNumber] == null) return null;

            foreach (var card in this.slots[slotNumber])
            {
                if (card.Id.Equals(id)) return card;
            }

            return null;
        }

        public void RemoveById(int id)
        {
            int slotNumber = this.CalculateSlotNumber(id);

            foreach (var item in this.slots[slotNumber])
            {
                if (item.Id.Equals(id)) this.slots[slotNumber].Remove(item);
            }
        }

        public IEnumerable<BattleCard> GetByCardType(CardType type)
        {
            ICollection<BattleCard> battleCards = new List<BattleCard>();

            foreach (var slot in this.slots)
            {
                if (slot == null) continue;

                foreach (var card in slot)
                {
                    if (card.Type.Equals(type))
                    {
                        battleCards.Add(card);
                    }
                }
            }

            return battleCards;
        }

        public IEnumerable<BattleCard> GetByTypeAndDamageRangeOrderedByDamageThenById(CardType type, int lo, int hi)
        {
            ICollection<BattleCard> battleCards
                = new SortedSet<BattleCard>(new CompareByDamageThenById());

            foreach (var slot in this.slots)
            {
                if (slot == null) continue;

                foreach (var card in slot)
                {
                    if (card.Type.Equals(type) && card.Damage >= lo && card.Damage <= hi)
                    {
                        battleCards.Add(card);
                    }
                }
            }

            return battleCards;
        }

        public IEnumerable<BattleCard> GetByCardTypeAndMaximumDamage(CardType type, double damage)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByNameOrderedBySwagDescending(string name)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetByNameAndSwagRange(string name, double lo, double hi)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> FindFirstLeastSwag(int n)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BattleCard> GetAllInSwagRange(double lo, double hi)
        {
            throw new NotImplementedException();
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
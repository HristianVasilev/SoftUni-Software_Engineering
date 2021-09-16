namespace _01.RoyaleArena
{
    using System.Collections.Generic;

    class CompareByDamageThenById : IComparer<BattleCard>
    {
        public int Compare(BattleCard x, BattleCard y)
        {
            if (x.Damage.Equals(y.Damage))
            {
                return x.Id.CompareTo(y.Id);
            }

            return x.Damage.CompareTo(y.Damage);
        }
    }
}

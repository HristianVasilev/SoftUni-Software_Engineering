namespace _01.RoyaleArena
{
    using System.Collections.Generic;

    class CompareBySwagThenById : IComparer<BattleCard>
    {
        public int Compare(BattleCard x, BattleCard y)
        {
            if (x.Swag.Equals(y.Swag))
            {
                return x.Id.CompareTo(y.Id);
            }

            return x.Swag.CompareTo(y.Swag);
        }
    }
}

namespace Roguelike.Units
{
    public class Stats
    {
        public int @HP;
        public int @Speed;
        public void TakeDamage(int damage)
        {
            @HP -= damage;
        }
    }
}
namespace CPT230InClass05
{
    abstract class Spell
    {
        public int Cost { set; get; }
        public Damage TheDamage { set; get; }
        public abstract void CalculateDamage(int magiStrength);
        public abstract string DisplayName();

    }
}

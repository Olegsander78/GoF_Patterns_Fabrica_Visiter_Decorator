namespace Assets.HW5_Decorator
{
    public class BuffAllStats : StatsDecorator
    {
        private const float BUFF_MULTIPLIER = 2f;
        public BuffAllStats(IStatsProvider wrappedEntity) : base(wrappedEntity)
        {
        }

        protected override CharacterStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() * BUFF_MULTIPLIER;
        }
    }
}
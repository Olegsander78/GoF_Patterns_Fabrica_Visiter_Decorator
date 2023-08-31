using System;

namespace Assets.HW5_Decorator
{
    public class SpecializationStats : StatsDecorator
    {
        private readonly SpecializationTypes _specialization;

        public SpecializationStats(IStatsProvider wrappedEntity,
            SpecializationTypes specialization) : base(wrappedEntity)
        {
            _specialization = specialization;
        }

        protected override CharacterStats GetStatsInternal()
        {
            return _wrappedEntity.GetStats() + GetSpecStats(_specialization);
        }

        private CharacterStats GetSpecStats(SpecializationTypes specialization)
        {
            switch (specialization)
            {
                case SpecializationTypes.THIEF:
                    return new CharacterStats()
                    {
                        Strength = 0,
                        Intelligence = 5,
                        Agility = 8
                    };
                case SpecializationTypes.MAGE:
                    return new CharacterStats()
                    {
                        Strength = -2,
                        Intelligence = 10,
                        Agility = 0
                    };
                case SpecializationTypes.BARBARIAN:
                    return new CharacterStats()
                    {
                        Strength = 10,
                        Intelligence = -5,
                        Agility = 5
                    };
                default:
                    throw new NotImplementedException($"{specialization} not found!");
            }
        }
    }
}
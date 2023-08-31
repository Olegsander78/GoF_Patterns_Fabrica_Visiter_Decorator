using System;

namespace Assets.HW5_Decorator
{
    public class PassiveAbilitiesStats : StatsDecorator
    {
        private const float PASSIVE_ABILITY_MULTIPLIER = 2f;

        private readonly PassiveAbilitiesTypes _passiveAbility;

        public PassiveAbilitiesStats(IStatsProvider wrappedEntity,
            PassiveAbilitiesTypes passiveAbility) : base(wrappedEntity)
        {
            _passiveAbility = passiveAbility;
        }

        protected override CharacterStats GetStatsInternal()
        {
            return GetSpecStats(_passiveAbility,PASSIVE_ABILITY_MULTIPLIER);
        }

        private CharacterStats GetSpecStats(PassiveAbilitiesTypes passiveAbility, float multiplier)
        {
            var result = _wrappedEntity.GetStats();

            switch (passiveAbility)
            {
                case PassiveAbilitiesTypes.TITANs_MIGHT:                    
                    result.Strength = (int)(result.Strength * multiplier);
                    return result;
                case PassiveAbilitiesTypes.QUICK_WIT:
                    result.Intelligence = (int)(result.Intelligence * multiplier);
                    return result;
                case PassiveAbilitiesTypes.EYE_OF_TIGER:
                    result.Agility = (int)(result.Agility * multiplier);
                    return result;
                default:
                    throw new NotImplementedException($"{passiveAbility} not found!");
            }
        }
    }
}
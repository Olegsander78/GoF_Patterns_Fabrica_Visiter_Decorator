using System;

namespace Assets.HW5_Decorator.Scripts
{
    public class RaceStats : IStatsProvider
    {
        private readonly RaceTypes _raceType;

        public RaceStats(RaceTypes raceTypes)
        {
            _raceType = raceTypes;
        }

        public CharacterStats GetStats()
        {
            switch (_raceType)
            {
                case RaceTypes.ORC:
                    return new CharacterStats()
                    {
                        Strength = 20,
                        Intelligence = 8,
                        Agility = 12
                    };
                case RaceTypes.ELF:
                    return new CharacterStats()
                    {
                        Strength = 8,
                        Intelligence = 12,
                        Agility = 20
                    };
                case RaceTypes.HUMAN:
                    return new CharacterStats()
                    {
                        Strength = 14,
                        Intelligence = 12,
                        Agility = 14
                    };
                default:
                    throw new NotImplementedException($"{_raceType} not found!");
            }
        }
    }
}

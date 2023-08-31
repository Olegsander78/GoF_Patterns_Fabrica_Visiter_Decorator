using Assets.HW5_Decorator.Scripts;
using System;
using System.Diagnostics;

namespace Assets.HW5_Decorator
{
    public class Character
    {
        private RaceTypes _race = RaceTypes.ORC;
        private SpecializationTypes _specialization = SpecializationTypes.BARBARIAN;
        private PassiveAbilitiesTypes _ability = PassiveAbilitiesTypes.TITANs_MIGHT;

        private IStatsProvider _provider;

        public Character()
        {
            _provider = new RaceStats(_race);
            _provider = new SpecializationStats(_provider, _specialization);
            _provider = new PassiveAbilitiesStats(_provider, _ability);
            _provider = new BuffAllStats(_provider);
        }

        public override string ToString() => $"Race: {_race}, Specialization: {_specialization}, Ability: {_ability}\n" +
            $"Strength: {_provider.GetStats().Strength},\n" +
            $"Intelligence: {_provider.GetStats().Intelligence},\n" +
            $"Agility: {_provider.GetStats().Agility}";
    }
}
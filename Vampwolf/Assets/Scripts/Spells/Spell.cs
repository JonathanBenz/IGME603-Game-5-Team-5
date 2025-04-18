using UnityEngine;
using Vampwolf.Units;

namespace Vampwolf.Spells
{
    public class Spell
    {
        private readonly SpellsModel model;
        private readonly SpellData data;

        public CharacterType CharacterType => data.characterType;
        public string Name => data.Name;
        public string Description => data.Description;
        public float Cost => data.Cost;
        public int Range => data.Range;
        public Sprite Icon => data.Icon;

        public Spell(SpellsModel model, SpellData data)
        {
            // Set the model and data
            this.model = model;
            this.data = data;
        }

        /// <summary>
        /// Cast the spell
        /// </summary>
        public void Cast(BattleUnit target)
        {
            // Cast the spell
            data.Strategy.Cast(this, target);

            // Remove the cost from the model depending on the character type
            switch (CharacterType)
            {
                case CharacterType.Vampire:
                    model.Blood -= Cost;
                    break;
                case CharacterType.Werewolf:
                    model.Rage -= Cost;
                    break;
            }
        }
    }
}

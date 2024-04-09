using UnityEngine;

namespace TopDownCharacter2D.Attacks
{

    public abstract class AttackConfig : ItemSO
    {
        [Tooltip("The scale of the attack")]
        public float size;

        [Tooltip("The time between two attacks")]
        public float delay;
        
        [Tooltip("The damage dealt by an attack")]
        public float power = 0;
        
        [Tooltip("The speed of the attack")]
        public float speed;
        
        [Tooltip("The possible targets for this attack")]
        public LayerMask target;


        private void OnEnable()
        {
            if (power == 0)
            {
                switch (Rarity)
                {
                    case "Rare":
                        power = Random.Range(1, 5);
                        break;
                    case "Epic":
                        power = Random.Range(6, 10);
                        break;
                    case "Mythic":
                        power = Random.Range(11, 15);
                        break;
                    case "Legendary":
                        power = Random.Range(16, 20);
                        break;
                    default:
                        power = 5;
                        break;
                }
            }
        }
    }
}
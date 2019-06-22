using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    public class UiCharacterCombat : UiListener, IDoAttack
    {
        private const string CantAttack = "CantAttack";
        private const float HeightNotification = 4;
        private const float SpeedNotification = 3;
        [SerializeField] private UiPlayerTeam leftTeam;

        [SerializeField] private UiPlayerTeam rightTeam;

        void IDoAttack.OnCantAttack(IDamager source, IDamageable target, int amount)
        {
            var sourceChar = (IRuntimeCharacter) source;
            var agressor = GetUi(sourceChar);
            var notf = UiNotificationTextPooler.Instance.Get();
            var final = agressor.transform.position + new Vector3(0, HeightNotification, 0);
            notf.Write(agressor.transform.position, final, CantAttack, SpeedNotification, Color.red);
        }

        void IDoAttack.OnDamage(IDamager source, IDamageable target, int amount)
        {
            var targetChar = (IRuntimeCharacter) target;
            var sourceChar = (IRuntimeCharacter) source;

            var agressor = GetUi(sourceChar);
            var defender = GetUi(targetChar);

            if (agressor != null && defender != null)
                agressor.Attack(defender.transform.position);
        }

        private IUiCharacter GetUi(IRuntimeCharacter ch)
        {
            var ui = rightTeam.GetCharacter(ch);
            if (ui == null)
                ui = leftTeam.GetCharacter(ch);

            return ui;
        }
    }
}
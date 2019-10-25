using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    public class UiCharacterDamage : UiListener, IDoAttack, IDoDamage, IDoHeal
    {
        const string Heal = "Heal";
        const string Damage = "Damage";
        const float HeightNotification = 4;
        const float SpeedNotification = 3;

        IUiCharacter MyChar { get; set; }

        void IDoAttack.OnDamage(IDamager source, IDamageable target, int amount) => TryApplyDamage(target, amount);

        void IDoAttack.OnCantAttack(IDamager source, IDamageable target, int amount)
        {
        }

        void IDoDamage.OnDamage(IDamager source, IDamageable target, int amount) => TryApplyDamage(target, amount);

        void IDoHeal.OnHeal(IHealer source, IHealable target, int amount) => TryApplyHeal(target, amount);

        void Awake() => MyChar = GetComponent<IUiCharacter>();

        //-----------------------------------------------------------------------------------------------------------------

        void TryApplyDamage(IDamageable target, int amount)
        {
            var targetChar = (IRuntimeCharacter) target;
            if (MyChar.Data.RuntimeData != targetChar)
                return;

            var notf = UiNotificationTextPooler.Instance.Get();
            var final = transform.position + new Vector3(0, HeightNotification, 0);
            notf.Write(transform.position, final, amount + Damage, SpeedNotification, Color.red);
        }

        void TryApplyHeal(IHealable target, int amount)
        {
            var targetChar = (IRuntimeCharacter) target;
            if (MyChar.Data.RuntimeData != targetChar)
                return;

            var notf = UiNotificationTextPooler.Instance.Get();
            var final = transform.position + new Vector3(0, HeightNotification, 0);
            notf.Write(transform.position, final, amount + Heal, SpeedNotification, Color.green);
        }
    }
}
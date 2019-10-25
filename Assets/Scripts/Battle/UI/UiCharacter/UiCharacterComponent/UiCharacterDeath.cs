using System.Collections;
using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    public class UiCharacterDeath : UiListener, IDoKill
    {
        const float TimeUntilRemoveUnit = 1;
        IUiCharacterData MyData { get; set; }

        void IDoKill.OnKill(IRuntimeCharacter target)
        {
            if (target == MyData.RuntimeData && gameObject.activeSelf)
                StartCoroutine(RemoveEffectively(target));
        }

        void Awake() => MyData = GetComponent<IUiCharacterData>();

        IEnumerator RemoveEffectively(IRuntimeCharacter target)
        {
            yield return new WaitForSeconds(TimeUntilRemoveUnit);
            CharacterFactory.Instance.ReleasePooledObject(gameObject);
        }
    }
}
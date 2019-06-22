using SimpleCardGames.Battle.UI.Card;
using UnityEngine;

namespace SimpleCardGames.Data.Card
{
    public class CardFactory : PrefabPooler<CardFactory, IUiCard>
    {
        public CardDatabase Database => CardDatabase.Instance;

        public IUiCard Get(IRuntimeCard card)
        {
            var obj = Get(modelsPooled[0]);
            obj.Data.SetData(card);
            return obj;
        }

        protected override void OnRelease(GameObject prefabModel)
        {
            var cardUi = prefabModel.GetComponent<IUiCard>();
            cardUi.Restart();
            base.OnRelease(prefabModel);
        }
    }
}
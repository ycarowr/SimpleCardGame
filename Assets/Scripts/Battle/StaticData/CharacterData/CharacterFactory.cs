using System.Collections.Generic;
using System.Linq;
using SimpleCardGames.Battle;
using SimpleCardGames.Battle.UI.Character;
using UnityEngine;

namespace SimpleCardGames.Data.Character
{
    /// <summary>
    ///     Database that manages static character data.
    /// </summary>
    public class CharacterFactory : PrefabPooler<CharacterFactory, IUiCharacter>
    {
        CharacterDatabase Database { get; set; }

        protected override void OnAwake()
        {
            if (Database == null)
                Database = new CharacterDatabase();
        }

        public IUiCharacter Get(IRuntimeCharacter character)
        {
            var obj = Get(modelsPooled[0]);
            obj.Data.SetData(character);
            return obj;
        }

        protected override void OnRelease(GameObject prefabModel)
        {
            var ui = prefabModel.GetComponent<IUiCharacter>();
            ui.Restart();
            base.OnRelease(prefabModel);
        }

        class CharacterDatabase
        {
            const string PathDataBase = "CharacterDatabase";

            public CharacterDatabase() => Characters = Resources.LoadAll<CharacterData>(PathDataBase).ToList();

            List<CharacterData> Characters { get; }

            public CharacterData Get(CharacterId id) => Characters?.Find(character => character.Id == id);
        }
    }
}
using Patterns;
using SimpleCardGames.Battle.Controller;
using SimpleCardGames.Data.Card;
using SimpleCardGames.Data.Character;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     This class initializes all components and kicks the start game.
    /// </summary>
    public class Bootstrapper : SingletonMB<Bootstrapper>
    {
        /// <summary>
        ///     Boots all the game instantiating the necessary prefabs in the correct order.
        /// </summary>
        private void InitializeGame()
        {
            if (IsInitialized)
                return;

            //The order matters. 
            //First. Create game events Singleton. In Scene.
            //Second. Create game UI. In Scene.
            //Third. Create Database. In Scene.

            //Fourth. Create game data Singleton
            //GameData = Instantiate(GameDataPrefab);

            //Fifth. Create game controller Singleton
            GameController = Instantiate(GameControllerPrefab);

            IsInitialized = true;
        }


        #region Fields

        [Header("Prefabs")] [SerializeField] private GameObject UIPrefab;
        [SerializeField] private CardFactory CardFactoryPrefab;
        [SerializeField] private CharacterFactory CharacterFactoryPrefab;
        [SerializeField] private GameData GameDataPrefab;
        [SerializeField] private GameEvents GameEventsPrefab;
        [SerializeField] private GameController GameControllerPrefab;

        #endregion

        #region Properties

        private GameObject Ui { get; set; }
        private CardFactory CardFactory { get; set; }
        private CharacterFactory CharacterFactory { get; set; }
        private GameData GameData { get; set; }
        private GameEvents GameEvents { get; set; }
        private GameController GameController { get; set; }

        public bool IsInitialized { get; private set; }

        #endregion

        #region Unity Callbacks

        /// <summary>
        ///     Main. First Awake that happens in the entire game.
        /// </summary>
        protected override void OnAwake()
        {
            Logger.Instance.Log<Bootstrapper>("Awake");
        }

        /// <summary>
        ///     First Start in the game.
        /// </summary>
        private void Start()
        {
            Logger.Instance.Log<Bootstrapper>("Start");
            InitializeGame();
        }

        #endregion
    }
}
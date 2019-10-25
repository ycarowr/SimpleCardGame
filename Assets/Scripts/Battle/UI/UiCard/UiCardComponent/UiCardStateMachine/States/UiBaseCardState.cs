using Patterns.StateMachine;
using SimpleCardGames.Battle.Controller;

namespace SimpleCardGames.Battle.UI.Card
{
    /// <summary>
    ///     Base UI Card State.
    /// </summary>
    public abstract class UiBaseCardState : IState, IUiPlayer
    {
        const int LayerToRenderNormal = 0;
        const int LayerToRenderTop = 1;

        //--------------------------------------------------------------------------------------------------------------

        #region Constructor

        protected UiBaseCardState(IUiCard handler, BaseStateMachine fsm, UiCardParameters parameters)
        {
            Fsm = fsm;
            Handler = handler;
            Parameters = parameters;
            IsInitialized = true;
        }

        #endregion

        protected IUiCard Handler { get; }
        protected UiCardParameters Parameters { get; }
        protected BaseStateMachine Fsm { get; }
        public bool IsInitialized { get; }

        public PlayerSeat Seat => PlayerSeat.Left;
        public IGameController Controller => GameController.Instance;
        public IPlayerTurn PlayerController => GameController.Instance.GetPlayerController(Seat);

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        /// <summary>
        ///     Renders the textures in the first layer. Each card state is responsible to handle its own layer activity.
        /// </summary>
        protected virtual void MakeRenderFirst()
        {
            for (var i = 0; i < Handler.Renderers.Length; i++)
                if (Handler.Renderers[i])
                    Handler.Renderers[i].sortingOrder = LayerToRenderTop;
            for (var i = 0; i < Handler.MRenderers.Length; i++)
                if (Handler.MRenderers[i])
                    Handler.MRenderers[i].sortingOrder = LayerToRenderTop;
        }


        /// <summary>
        ///     Renders the textures in the regular layer. Each card state is responsible to handle its own layer activity.
        /// </summary>
        protected virtual void MakeRenderNormal()
        {
            for (var i = 0; i < Handler.Renderers.Length; i++)
                if (Handler.Renderers[i])
                    Handler.Renderers[i].sortingOrder = LayerToRenderNormal;
            for (var i = 0; i < Handler.MRenderers.Length; i++)
                if (Handler.MRenderers[i])
                    Handler.MRenderers[i].sortingOrder = LayerToRenderNormal;
        }

        /// <summary>
        ///     Enables the card entirely. Collision, Rigidybody and adds Alpha.
        /// </summary>
        protected void Enable()
        {
            if (Handler.Collider)
                EnableCollision();
            if (Handler.Rigidbody)
                Handler.Rigidbody.Sleep();

            MakeRenderNormal();
            RemoveAllTransparency();
        }

        /// <summary>
        ///     Disables the card entirely. Collision, Rigidybody and adds Alpha.
        /// </summary>
        protected virtual void Disable()
        {
            DisableCollision();
            Handler.Rigidbody.Sleep();
            MakeRenderNormal();
            foreach (var renderer in Handler.Renderers)
            {
                var myColor = renderer.color;
                myColor.a = Parameters.DisabledAlpha;
                renderer.color = myColor;
            }
        }

        /// <summary>
        ///     Disables the collision with this card.
        /// </summary>
        protected void DisableCollision() => Handler.Collider.enabled = false;

        /// <summary>
        ///     Enables the collision with this card.
        /// </summary>
        protected void EnableCollision() => Handler.Collider.enabled = true;

        /// <summary>
        ///     Remove any alpha channel in all renderers.
        /// </summary>
        protected void RemoveAllTransparency()
        {
            foreach (var renderer in Handler.Renderers)
                if (renderer)
                {
                    var myColor = renderer.color;
                    myColor.a = 1;
                    renderer.color = myColor;
                }
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region FSM

        void IState.OnInitialize()
        {
        }

        public virtual void OnEnterState()
        {
        }

        public virtual void OnExitState()
        {
        }

        public virtual void OnUpdate()
        {
        }

        public virtual void OnNextState(IState next)
        {
        }

        public virtual void OnClear()
        {
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}
using SimpleCardGames.Data.Card;
using Tools.UI;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Card
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMouseInput))]
    [RequireComponent(typeof(IUiCardData))]
    public class UiCardComponent : MonoBehaviour, IUiCard
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Initialization and Unity Callbacks

        void Awake()
        {
            //data
            Data = GetComponent<IUiCardData>();

            //components
            MyTransform = transform;
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            MyInput = GetComponent<IMouseInput>();
            MyRenderers = GetComponentsInChildren<SpriteRenderer>();
            MyRenderer = GetComponent<SpriteRenderer>();
            MyMRenderers = GetComponentsInChildren<MeshRenderer>();
            MyMRenderer = GetComponent<MeshRenderer>();

            //transform
            Motion = new UiMotion(this);

            //fsm
            Fsm = new UiCardHandFsm(MainCamera, cardConfigsParameters, this);
        }

        /// <summary>
        ///     Initialize the component.
        /// </summary>
        public void Initialize()
        {
            if (IsInitialized)
                return;

            Hand = transform.parent.GetComponentInChildren<IUiPlayerHand>();
            IsInitialized = true;
        }

        void Update()
        {
            if (!IsInitialized)
                return;

            Fsm?.Update();
            Motion?.Update();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Properties

        public UiMotion Motion { get; private set; }
        SpriteRenderer[] IUiCardComponents.Renderers => MyRenderers;
        SpriteRenderer IUiCardComponents.Renderer => MyRenderer;
        MeshRenderer[] IUiCardComponents.MRenderers => MyMRenderers;
        MeshRenderer IUiCardComponents.MRenderer => MyMRenderer;
        Collider IUiCardComponents.Collider => MyCollider;
        Rigidbody IUiCardComponents.Rigidbody => MyRigidbody;
        IMouseInput IUiCardComponents.Input => MyInput;
        IUiPlayerHand IUiCard.Hand => Hand;
        public string Name => gameObject.name;
        [SerializeField] public UiCardParameters cardConfigsParameters;
        UiCardHandFsm Fsm { get; set; }
        Transform MyTransform { get; set; }
        Collider MyCollider { get; set; }
        SpriteRenderer[] MyRenderers { get; set; }
        SpriteRenderer MyRenderer { get; set; }
        MeshRenderer[] MyMRenderers { get; set; }
        MeshRenderer MyMRenderer { get; set; }
        Rigidbody MyRigidbody { get; set; }
        IMouseInput MyInput { get; set; }
        IUiPlayerHand Hand { get; set; }
        public IUiCardData Data { get; private set; }
        public MonoBehaviour MonoBehavior => this;
        public Camera MainCamera => Camera.main;
        public bool IsDragging => Fsm.IsCurrent<UiCardDrag>();
        public bool IsHovering => Fsm.IsCurrent<UiCardHover>();
        public bool IsDisabled => Fsm.IsCurrent<UiCardDisable>();
        public bool IsInitialized { get; private set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Card Operations

        public void Hover() => Fsm.Hover();

        public void Disable() => Fsm.Disable();

        public void Enable() => Fsm.Enable();

        public void Select()
        {
            Hand.SelectCard(this);
            Fsm.Select();
        }

        public void Unselect() => Fsm.Unselect();

        public void Draw() => Fsm.Draw();

        public void Discard() => Fsm.Discard();

        public void Play() => Fsm.Play();

        public void Restart() => IsInitialized = false;

        public void Target() => Fsm.Target();

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}
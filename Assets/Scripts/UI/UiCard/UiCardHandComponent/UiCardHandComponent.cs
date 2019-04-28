using SimpleCardGames.Data;
using UnityEngine;

namespace Tools.UI.Card
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMouseInput))] 
    [RequireComponent(typeof(ICardHandData))]
    public class UiCardHandComponent : MonoBehaviour, IUiCard
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Components

        SpriteRenderer[] IUiCardComponents.Renderers => MyRenderers;
        SpriteRenderer IUiCardComponents.MyRenderer => MyRenderer;
        Collider IUiCardComponents.Collider => MyCollider;
        Rigidbody IUiCardComponents.Rigidbody => MyRigidbody;
        IMouseInput IUiCardComponents.Input => MyInput;
        IUiCardHand IUiCardComponents.Hand => Hand;

        #endregion

        #region Transform

        public UiMotionBaseCard Movement { get; private set; }
        public UiMotionBaseCard Rotation { get; private set; }
        public UiMotionBaseCard Scale { get; private set; }

        #endregion

        #region Properties

        public string Name => gameObject.name;
        public UiCardParameters CardConfigsParameters => cardConfigsParameters;
        [SerializeField] public UiCardParameters cardConfigsParameters;
        private UiCardHandFsm Fsm { get; set; }
        private Transform MyTransform { get; set; }
        private Collider MyCollider { get; set; }
        private SpriteRenderer[] MyRenderers { get; set; }
        private SpriteRenderer MyRenderer { get; set; }
        private Rigidbody MyRigidbody { get; set; }
        private IMouseInput MyInput { get; set; }
        private IUiCardHand Hand { get; set; }
        public ICardHandData HandData { get; private set; }
        public MonoBehaviour MonoBehavior => this;
        public Camera MainCamera => Camera.main;
        public bool IsDragging => Fsm.IsCurrent<UiCardDrag>();
        public bool IsHovering => Fsm.IsCurrent<UiCardHover>();
        public bool IsDisabled => Fsm.IsCurrent<UiCardDisable>();
        public bool IsInitialized { get; private set; }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Transform

        public void RotateTo(Vector3 rotation, float speed)
        {
            Rotation.Execute(rotation, speed);
        }

        public void MoveTo(Vector3 position, float speed, float delay)
        {
            Movement.Execute(position, speed, delay, false);
        }

        public void MoveToWithZ(Vector3 position, float speed, float delay)
        {
            Movement.Execute(position, speed, delay, true);
        }

        public void ScaleTo(Vector3 scale, float speed, float delay)
        {
            Scale.Execute(scale, speed, delay);
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Operations

        public void Hover()
        {
            Fsm.Hover();
        }

        public void Disable()
        {
            Fsm.Disable();
        }

        public void Enable()
        {
            Fsm.Enable();
        }

        public void Select()
        {
            Hand.SelectCard(this);
            Fsm.Select();
        }

        public void Unselect()
        {
            Fsm.Unselect();
        }

        public void Draw()
        {
            Fsm.Draw();
        }

        public void Discard()
        {
            Fsm.Discard();
        }

        public void Play()
        {
            Fsm.Play();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Unity Callbacks

        public void Initialize()
        {
            if (IsInitialized)
                return;
            HandData = GetComponent<ICardHandData>();
            Hand = transform.parent.GetComponentInChildren<IUiCardHand>();
            //components
            MyTransform = transform;
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            MyInput = GetComponent<IMouseInput>();
            MyRenderers = GetComponentsInChildren<SpriteRenderer>();
            MyRenderer = GetComponent<SpriteRenderer>();

            //transform
            Scale = new UiMotionScaleCard(this);
            Movement = new UiMotionMovementCard(this);
            Rotation = new UiMotionRotationCard(this);

            //fsm
            Fsm = new UiCardHandFsm(MainCamera, CardConfigsParameters, this);

            IsInitialized = true;
        }

        private void Update()
        {
            if (!IsInitialized)
                return;

            Fsm?.Update();
            Movement?.Update();
            Rotation?.Update();
            Scale?.Update();
        }

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}
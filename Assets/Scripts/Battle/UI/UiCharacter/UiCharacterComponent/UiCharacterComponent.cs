using Tools.UI;
using UnityEngine;

namespace SimpleCardGames.Battle.UI.Character
{
    [RequireComponent(typeof(Collider))]
    [RequireComponent(typeof(Rigidbody))]
    [RequireComponent(typeof(IMouseInput))]
    [RequireComponent(typeof(IUiCharacterData))]
    public class UiCharacterComponent : MonoBehaviour, IUiCharacter
    {
        //--------------------------------------------------------------------------------------------------------------

        #region Initialization and Unity Callbacks

        void Awake()
        {
            Data = GetComponent<IUiCharacterData>();

            //components
            MyTransform = transform;
            MyCollider = GetComponent<Collider>();
            MyRigidbody = GetComponent<Rigidbody>();
            MyInput = GetComponent<IMouseInput>();
            MyRenderer = GetComponentInChildren<SpriteRenderer>();

            //transform
            Motion = new UiMotion(this);

            //fsm
            Fsm = new UiCharacterFsm(MainCamera, parameters, this);
        }

        /// <summary>
        ///     Initialize the component.
        /// </summary>
        public void Initialize()
        {
            if (IsInitialized)
                return;

            Team = transform.parent.GetComponentInChildren<IUiPlayerTeam>();
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
        [SerializeField] UiCharacterParameters parameters;
        public SpriteRenderer Renderer => MyRenderer;
        public Collider Collider => MyCollider;
        public Rigidbody Rigidbody => MyRigidbody;
        public IMouseInput Input => MyInput;
        IUiPlayerTeam IUiCharacter.Team => Team;
        public string Name => gameObject.name;
        UiCharacterFsm Fsm { get; set; }
        Transform MyTransform { get; set; }
        Collider MyCollider { get; set; }
        SpriteRenderer MyRenderer { get; set; }
        Rigidbody MyRigidbody { get; set; }
        IMouseInput MyInput { get; set; }
        IUiPlayerTeam Team { get; set; }
        public IUiCharacterData Data { get; private set; }
        public MonoBehaviour MonoBehavior => this;
        public Camera MainCamera => Camera.main;
        public bool IsHovering => Fsm.IsCurrent<UiCharacterHover>();
        public bool IsDisabled => Fsm.IsCurrent<UiCharacterDisable>();
        public bool IsAttacking => Fsm.IsCurrent<UiCharacterAttack>();
        public bool IsInitialized { get; private set; }
        public bool IsUser => Data.RuntimeData.Attributes.Owner.Seat == PlayerSeat.Left;

        #endregion

        //--------------------------------------------------------------------------------------------------------------

        #region Character Operations

        public void Hover() => Fsm.Hover();

        public void Disable() => Fsm.Disable();

        public void Enable() => Fsm.Enable();

        public void Select()
        {
            Team.SelectCharacter(this);
            if (IsUser)
                Fsm.Select();
        }

        public void Unselect()
        {
            if (!IsAttacking)
                Fsm.Unselect();
        }

        public void Attack(Vector3 targetPosition) => Fsm.Attack(targetPosition);

        public void Restart() => IsInitialized = false;

        #endregion

        //--------------------------------------------------------------------------------------------------------------
    }
}
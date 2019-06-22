namespace SimpleCardGames.Battle
{
    /// <summary>
    ///     The base for mechanics that interact with characters.
    /// </summary>
    public abstract class CharMechanic
    {
        protected CharMechanic(IRuntimeCharacter character)
        {
            Character = character;
        }

        protected IRuntimeCharacter Character { get; set; }
        protected CharAttributes Attributes => Character.Attributes;
    }
}
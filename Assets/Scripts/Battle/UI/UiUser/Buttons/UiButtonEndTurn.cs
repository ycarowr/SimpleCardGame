namespace SimpleCardGames
{
    public class UiButtonEndTurn : UiButton
    {
        protected override void OnSetHandler(IButtonHandler handler)
        {
            if (handler is IPressEndTurn pressEndTurn)
                AddListener(pressEndTurn.PressRandomMove);
        }

        public interface IPressEndTurn : IButtonHandler
        {
            void PressRandomMove();
        }
    }
}
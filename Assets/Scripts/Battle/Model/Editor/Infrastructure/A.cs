namespace SimpleCardGames.Infrastructure
{
    public static class A
    {
        public static PlayerBuilder Player() => new PlayerBuilder();

        public static TokenBuilder Token() => new TokenBuilder();
    }
}
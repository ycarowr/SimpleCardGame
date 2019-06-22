namespace SimpleCardGames.Data.Effects
{
    public enum EffectTriggerType
    {
        //Deck
        OnPlay, //Relic Done
        OnDraw, //Relic Done
        OnDiscard, //Relic Done
        OnDeckShuffle, //Relic Done

        //Turn
        OnPlayerStartTurn, //Relic Done
        OnPlayerFinishTurn, //Relic Done

        //Character
        OnPlayerDamageTaken, //Pushed to ticket
        OnPlayerMinionSummon, //Relic Done
        OnPlayerMinionDeath, //Relic Done

        OnEnemyMinionSummon, //Relic Done
        OnEnemyMinionDeath, //Relic Done

        //Draw Cards
        OnDrawMinionCard, //Relic Done
        OnDrawSpellCard, //Relic Done
        OnDrawPowerCard, //Relic Done
        OnDrawCurseCard, //Relic Done

        //Play Cards
        OnPlayMinionCard, //Relic Done
        OnPlaySpellCard, //Relic Done
        OnPlayPowerCard, //Relic Done
        OnPlayCurseCard, //Relic Done

        //Discard Cards
        OnDiscardMinionCard, //Relic Done
        OnDiscardSpellCard, //Relic Done
        OnDiscardPowerCard, //Relic Done
        OnDiscardCurseCard, //Relic Done

        //Adventure
        OnEnterBattle, //Relic Done

        //These conditions can't use the normal game event listeners. Need to code another way
        OnEnterReward,
        OnEnterShop,
        OnEnterTreasure,
        OnEnterChance
    }
}
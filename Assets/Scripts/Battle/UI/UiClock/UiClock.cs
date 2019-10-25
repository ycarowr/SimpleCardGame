using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace SimpleCardGames.Battle
{
    public class UiClock : UiListener, IDoTick, IPreGameStart, IFinishPlayerTurn
    {
        //----------------------------------------------------------------------------------------------------------

        void Awake()
        {
            Text = GetComponent<TMP_Text>();
            TimeText = Localization.Instance.Get(LocalizationIds.Time) + ":";
        }

        void Update()
        {
            if (!IsBlinking)
                return;

            currentBlinkTime += Time.deltaTime;
            if (!(currentBlinkTime >= maxBlinkTime))
                return;

            currentBlinkTime = 0;
            Text.enabled = !Text.enabled;
        }

        void Restart()
        {
            IsBlinking = false;
            Text.enabled = false;
        }
        //----------------------------------------------------------------------------------------------------------

        #region Fields and Properties 

        const float BlinkFactor = 0.1f;
        const int BlinkStart = 3;
        float currentBlinkTime;
        float maxBlinkTime;
        [SerializeField] PlayerSeat seat;
        TMP_Text Text { get; set; }
        string TimeText { get; set; }
        bool IsBlinking { get; set; }

        #endregion

        //----------------------------------------------------------------------------------------------------------

        #region Game Events

        void IDoTick.OnTickTime(int time, IPlayer player)
        {
            if (player.Seat != seat)
                return;

            Text.text = TimeText + time;
            Text.enabled = true;

            if (time > BlinkStart)
                return;

            IsBlinking = true;

            if (time > 0)
                maxBlinkTime = time * BlinkFactor;
        }

        void IFinishPlayerTurn.OnFinishPlayerTurn(IPlayer player) => Restart();

        void IPreGameStart.OnPreGameStart(List<IPlayer> players) => Restart();

        #endregion
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace MirrorMatchSystem
{
    public class UIRoomManager : MonoBehaviour
    {
        public static UIRoomManager instance;

        [Header("Match Game")]
        [SerializeField] GameObject matchGameParent;
        [SerializeField] InputField nicknameInput;
        [SerializeField] InputField roomIDInput;
        [SerializeField] Button playBtn;
        [SerializeField] Button hostBtn;

        [Header("Join Game")]
        [SerializeField] GameObject joinParent;
        [SerializeField] Text roomIDText;

        private void Start()
        {
            instance = this;
            playBtn.onClick.AddListener(() =>
            {
                if (int.TryParse(roomIDInput.text, out int matchID)){
                    Player.localPlayer.MatchGame(matchID);
                }
            });
            hostBtn.onClick.AddListener(() =>
            {
                Player.localPlayer.HostGame();
            });
            matchGameParent.SetActive(true);
            joinParent.SetActive(false);
        }

        public void JoinRoom(ServerMatchManager.Room room){
            matchGameParent.SetActive(false);
            joinParent.SetActive(true);
            roomIDText.text = room.id.ToString("000000");
        }
    }

}

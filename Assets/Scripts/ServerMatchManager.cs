using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace MirrorMatchSystem
{
    public class ServerMatchManager : MonoBehaviour
    {
        public static ServerMatchManager instance;

        public Dictionary<int, Room> roomDatas;

        [System.Serializable]
        public class Room
        {
            public int id;
            public string name;
            public int host;
            public int maxPlayer;
            public List<int> playerList;
        }

        private void Start()
        {
            instance = this;
        }

        private void Update()
        {
            var mode = NetworkManager.singleton.mode;
            if (mode == NetworkManagerMode.Host || mode == NetworkManagerMode.ServerOnly)
            {
                if (roomDatas == null)
                {
                    roomDatas = new Dictionary<int, Room>();
                }
            }
        }

        public int HostGame(int player)
        {
            var rndID = Random.Range(1, 1000000);
            while (roomDatas.TryGetValue(rndID, out _))
            {
                rndID = Random.Range(1, 1000000);
            }
            var room = new Room
            {
                id = rndID,
                host = player,
                maxPlayer = 3,
                playerList = new List<int>()
            };
            roomDatas.Add(rndID, room);
            return rndID;
        }

        public Room MatchGame(int matchID, int playerID)
        {
            if (roomDatas.TryGetValue(matchID, out Room room))
            {
                if (room.playerList.Count < room.maxPlayer)
                {
                    room.playerList.Add(playerID);
                    return room;
                }
                else
                {
                    return null;
                }
            }
            return null;
        }
    }
}

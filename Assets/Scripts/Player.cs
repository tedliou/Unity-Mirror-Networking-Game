using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

namespace MirrorMatchSystem
{

    public class Player : NetworkBehaviour
    {
        public static Player localPlayer;

        [SyncVar]
        public int id;

        void Start()
        {
            if (isLocalPlayer)
            {
                localPlayer = this;
            }
        }

        [Client]
        void Update()
        {

        }

        public void MatchGame(int matchID)
        {
            CmdMatchGame(gameObject, matchID, id);
        }

        public void JoinRoom(ServerMatchManager.Room room){
            UIRoomManager.instance.JoinRoom(room);
        }

        public void HostGame()
        {
            CmdHostGame(gameObject, id);
        }

        [Command]
        private void CmdHostGame(GameObject target, int id)
        {
            var roomID = ServerMatchManager.instance.HostGame(id);
            var identity = target.GetComponent<NetworkIdentity>();
            TargetDoMatchGame(identity.connectionToClient, roomID);
        }

        [TargetRpc]
        private void TargetDoMatchGame(NetworkConnection target, int roomID){
            MatchGame(roomID);
        }

        [Command]
        private void CmdMatchGame(GameObject target, int matchID, int playerID){
            var room = ServerMatchManager.instance.MatchGame(matchID, playerID);
            var identity = target.GetComponent<NetworkIdentity>();
            TargetDoJoinRoom(identity.connectionToClient, room);
        }

        [TargetRpc]
        private void TargetDoJoinRoom(NetworkConnection target, ServerMatchManager.Room room){
            JoinRoom(room);
        }
    }
}
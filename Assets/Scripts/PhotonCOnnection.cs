using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PhotonCOnnection : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();

        
    }
    public override void OnConnectedToMaster() {
        print("Se ha conectado al master");
        PhotonNetwork.JoinLobby();

    }

    public override void OnJoinedLobby() {
        print("Se ha entrado al lobby abstracto");
    
        PhotonNetwork.JoinOrCreateRoom("x", newRoomInfo(),null );
    }

    public override void OnJoinedRoom() {
        print(" Se entro al room");
    }

    public override void OnCreateRoomFailed(short returnCode, string message) {
        base.OnCreateRoomFailed(returnCode, message);
        print("Hubo un error al crear el room");
    }
    RoomOptions newRoomInfo() {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 10;
        roomOptions.IsOpen = true;
        roomOptions.IsVisible = true;

        return roomOptions;

    }

        
}

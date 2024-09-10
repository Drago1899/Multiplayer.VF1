using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;

public class PhotonCOnnection : MonoBehaviourPunCallbacks
{
    [SerializeField] TMP_InputField m_newInputField;
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
        //PhotonNetwork.Instantiate("Player", new Vector2(0, 0), Quaternion.identity);
        
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

    public void joinRoom()
    {
        PhotonNetwork.JoinRoom(m_newInputField.text);
        PhotonNetwork.LoadLevel("SampleScene");



    }

    public void createRoom()
    {
        PhotonNetwork.CreateRoom(m_newInputField.text,newRoomInfo(),null );
        PhotonNetwork.LoadLevel("SampleScene");

    }


}

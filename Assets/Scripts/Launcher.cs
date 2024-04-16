using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class NewBehaviourScript : MonoBehaviourPunCallbacks
{

    public PhotonView playerPrefab; // componente a�adido al player
    public Transform spawnPoint; // para que se instancie el player en el punto de referencia

    // Start is called before the first frame update
    void Start()
    {
        // Inicializa los seteos para ingresar al servidor
        PhotonNetwork.ConnectUsingSettings();
        
    }

    // Metodo para  conectar al master
    public override void OnConnectedToMaster()
    {
        Debug.Log("Conexi�n exitosa al master");

        // M�todo que une a una sala ramdon y en caso de que no hayas salas creada, crea una por defecto.
        PhotonNetwork.JoinRandomOrCreateRoom();
    }


    // M�todo para colocar las instrucciones una vez dentro de la sala.
    public override void OnJoinedRoom()
    {
        // Se intancia un nuevo player, en los parametros se coloca el objeto a instanciar  y la posici�n del mismo en el plano
        PhotonNetwork.Instantiate(playerPrefab.name, spawnPoint.position, spawnPoint.rotation);
    }


}

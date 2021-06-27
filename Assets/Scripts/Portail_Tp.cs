using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon;
using Photon.Realtime;
using Photon.Pun;
using Photon.Utilities;

public class Portail_Tp : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public string level;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            GetComponent<PhotonView>().RPC("ChangeLevel", RpcTarget.MasterClient);
        }
    }

    [PunRPC]
    public void ChangeLevel()
    {
        PhotonNetwork.LoadLevel(level);
    }
}

using Photon.Pun;
using UnityEngine;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab = null;
    public void Start()
    {
        GameObject player = PhotonNetwork.Instantiate(playerPrefab.name, new Vector3(Random.Range(4.3f,7f), 2.05f, Random.Range(2.1f, 0.8f)), Quaternion.identity);
        player.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.AddComponent<Camera>();
        player.transform.GetChild(0).gameObject.transform.GetChild(0).gameObject.AddComponent<MultyUse>();
    }
}

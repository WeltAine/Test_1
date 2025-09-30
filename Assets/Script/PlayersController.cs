using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayersController : MonoBehaviour
{
    public int SoliderNumber { get { return soliderNumber; } set { int add = value - soliderNumber; soliderNumber = value;  spawner?.SpawnerPlayer(add); UpdatePlayers(); } }
    [SerializeField]
    private int soliderNumber = 1;
    public PlayerSpawner spawner;

    public float FireRate { get { return fireRate; } set { fireRate = value; UpdatePlayers(); } }
    [SerializeField]
    private float fireRate;


    public void UpdatePlayers()
    {

        foreach(Transform aim in this.transform)
        {
            Transform gun = aim.transform.Find("GunHolder/Gun");
            gun.GetComponent<Gun>().FireRate = fireRate;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        FireRate = this.transform.GetComponentInChildren<Gun>().FireRate;
        spawner = GetComponent<PlayerSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        foreach (Transform aim in this.transform)
        {
            aim.GetComponent<Rigidbody>().AddForce(-1 * aim.localPosition * 25);
        }
    }

    private void OnValidate()
    {
        //SoliderNumber = soliderNumber;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class secondWave : MonoBehaviour
{
    public Transform[] point;
    private GameObject weapon1;
    private GameObject weapon2;
    //we need to clear when we create
    List<GameObject> weaponsToShow;
    void Start()
    {
        weaponsToShow = new List<GameObject>();

    }
    public void wave(List<GameObject> weapons)
    {
        weaponsToShow = new List<GameObject>();

        Destroy(weapon1, 0.0f);
        if (weapons.Count == 0)
        {
            Destroy(weapon2, 0.0f);

        }
        else if (weapons.Count == 1)
        {
            weaponsToShow.Clear();
            weaponsToShow.Add(weapons[0]);

            weapon1 = Instantiate(weaponsToShow[0], point[0]);


            weapon1.transform.localPosition = Vector3.zero;


        }
        else
        {
            Destroy(weapon2, 0.0f);

            weaponsToShow.Clear();

            weaponsToShow.Add(weapons[0]);
            weaponsToShow.Add(weapons[1]);
            weapon1 = Instantiate(weaponsToShow[0], point[0]);
            weapon2 = Instantiate(weaponsToShow[1], point[1]);


            weapon1.transform.localPosition = Vector3.zero;
            weapon2.transform.localPosition = Vector3.zero;
        }




    }

    // Update is called once per frame
    void Update()
    {

    }
}

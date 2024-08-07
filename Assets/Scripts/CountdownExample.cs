using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountdownExample : MonoBehaviour
{
    public bool waitCheck = false;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Waiter());
        Debug.Log("Corouting started");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.P)) { waitCheck = true; }
    }

    IEnumerator Waiter()
    {
        while (!waitCheck)
        {
            Debug.Log("Waiting!");
            yield return new WaitForSeconds(3.0f);
        }

        Debug.Log("Wait over!");
    }
}

using System.Collections;
using UnityEngine;

public class PoliceEnemy : InteractableObject
{
    [SerializeField]
    private GameObject redLight;
    
    [SerializeField]
    private GameObject blueLight;
    
    public override void Interact()
    {
        Debug.Log("WASTED!!!");
        StartCoroutine(nameof(RunLights));
        FindObjectOfType<Player>().gameObject.SetActive(false);
    }

    private IEnumerator RunLights()
    {
        while (true)
        {
            if (redLight.activeInHierarchy)
            {
                yield return new WaitForSeconds(0.25f);
                redLight.SetActive(false);
                blueLight.SetActive(true);
            }
            else if(blueLight.activeInHierarchy)
            {
                yield return new WaitForSeconds(0.25f);
                blueLight.SetActive(false);
                redLight.SetActive(true);
            }
        }
    }
    
}
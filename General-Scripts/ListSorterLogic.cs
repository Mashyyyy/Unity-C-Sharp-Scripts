using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ListSorterLogic : MonoBehaviour
{
    /*
    [Header("SO List File")]
    public List<Country> countryObj;
    */

    //can be improved
    [Header("String Objects")]
    public string[] countryCode;
    public string[] countryName;

    [Header("PrefabGameObject")]
    public GameObject countryPrefab;

    int counter = 0;

    private void Start()
    {
        //Get all objects in the List
        //Sort objects
        //Debug.Log(countryObj.Count);
        StartCoroutine(sortArray(countryCode.Length));
    }

    IEnumerator sortArray(int count)
    {
        for (int i = 0; i < count; i++)
        {
            for (int y = 0; y < count; y++)
            {
                //It cannot reference itself and will not instantiate a duplicate
                if (y != i)
                {
                    GameObject obj = Instantiate(countryPrefab, this.gameObject.transform);
                    /* Param 1: CountryCode 1
                     * Param 2: CountryCode 2
                     * Param 3: CountryName 1
                     * Param 4: CountryName 2
                     */
                    obj.GetComponent<ObjectPopulateInfo>().GetInfoFromParent(
                        countryCode[i],
                        countryCode[y],
                        countryName[i],
                        countryName[y]);
                    yield return null;
                }
            }
        }
    }
}
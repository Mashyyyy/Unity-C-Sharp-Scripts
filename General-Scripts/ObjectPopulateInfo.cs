using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectPopulateInfo : MonoBehaviour
{
    [Header("Text Values")]
    public Text CountryCode1;
    public Text CountryCode2;
    public Text CountryName1;
    public Text CountryName2;

    public void GetInfoFromParent(string countryCode1, string countryCode2, string countryName1, string countryName2)
    {
        CountryCode1.text = countryCode1;
        CountryCode2.text = countryCode2;
        CountryName1.text = countryName1;
        CountryName2.text = countryName2;
    }
}
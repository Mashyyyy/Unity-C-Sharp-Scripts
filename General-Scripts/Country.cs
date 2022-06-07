using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Country", menuName = "Countries Asset")]
public class Country : ScriptableObject
{
    public string countryName;
    public string countryCode;
}
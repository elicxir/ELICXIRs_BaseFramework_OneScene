using System;
using System.Linq;
using UnityEngine;


public class EnumIndexAttribute : PropertyAttribute
{
    public string[] _names;
    public EnumIndexAttribute(Type enumType) => _names = Enum.GetNames(enumType);
}

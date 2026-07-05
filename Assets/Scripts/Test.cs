using System.Collections;
using System.Reflection;
using Uniject;
using UnityEngine;

public class Test : MonoBehaviour
{
    private IEnumerator Start()
    {
        var container = new Container();
        container.Build();

        yield return new WaitForSeconds(2f);
    }
}
using Uniject.Attributes;
using UnityEngine;

public class Enemy2 : MonoBehaviour
{
    [SerializeField] private string _message;
    [SerializeField] private float _pi;

    [Inject]
    private void Construct(string message, float pi)
    {
        _message = message;
        _pi = pi;
    }  
}
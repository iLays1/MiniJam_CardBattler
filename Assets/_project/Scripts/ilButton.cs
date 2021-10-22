using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ilButton : MonoBehaviour
{
    public UnityEvent OnPress = new UnityEvent();

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
            OnPress.Invoke();
    }
}

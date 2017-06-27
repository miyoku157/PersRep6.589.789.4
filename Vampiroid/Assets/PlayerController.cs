using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public static System.Action OnStealthStateChange;

    public GameObject playerObject;

    bool stealthState;

    void Awake()
    {
        OnStealthStateChange += UglyStealthDebug;

        stealthState = true;
    }

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.S))
        {
            SwitchStealthState();
        }
	}

    void SwitchStealthState()
    {
        if(stealthState)
            stealthState = false;
        else
            stealthState = true;

        if(OnStealthStateChange != null)
            OnStealthStateChange();
    }

    void UglyStealthDebug()
    {
        if (stealthState)
            playerObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.5f);
        else
            playerObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);
    }
}

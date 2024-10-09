using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoServices : MonoBehaviour
{
    public static NoServices Instance;
    public GameObject Panel;

    void Awake()
    {
        Instance = this;
    }
    // Use this for initialization
	void Start () {
		Panel.SetActive (false);
	}

	public void ShowUp(){
		Panel.SetActive (true);
	}

	public void Close(){
		Panel.SetActive (false);
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CarController : MonoBehaviour
{
    private GameObject unitychan;
    private Camera _mainCamera;

    // Use this for initialization
    void Start()
    {
        this.unitychan = GameObject.Find("unitychan");
        GameObject obj = GameObject.Find("Main Camera");
        _mainCamera = obj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //Prefabがカメラより後ろになったらオブジェクトを破棄する
        if (this.transform.position.z - _mainCamera.transform.position.z < 0)
        {
            Destroy(this.gameObject);
        }
    }
}


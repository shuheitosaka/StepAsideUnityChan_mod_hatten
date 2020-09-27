using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoinController : MonoBehaviour
{
    private GameObject unitychan;
    private Camera _mainCamera;

    // Use this for initialization
    void Start()
    {
        //回転を開始する角度を設定
        this.transform.Rotate(0, Random.Range(0, 360), 0);
        this.unitychan = GameObject.Find("unitychan");
        GameObject obj = GameObject.Find("Main Camera");
        _mainCamera = obj.GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        //回転
        this.transform.Rotate(0, 3, 0);
        //Prefabがカメラより後ろになったらオブジェクトを破棄する
        if (this.transform.position.z - _mainCamera.transform.position.z < 0)
        {
            Destroy(this.gameObject);
        }
    }
}

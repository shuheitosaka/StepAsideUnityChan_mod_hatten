using UnityEngine;
using System.Collections;

public class ItemGenerator : MonoBehaviour
{
    //carPrefabを入れる
    public GameObject carPrefab;
    //coinPrefabを入れる
    public GameObject coinPrefab;
    //cornPrefabを入れる
    public GameObject conePrefab;
    //Unitychanオブジェクト
    private GameObject unitychan;
    //スタート地点
    private int startPos = 80;
    //ゴール地点
    private int goalPos = 360;
    //アイテムを出すx方向の範囲
    private float posRange = 3.4f;
    //アイテムが出現する間隔
    private int targetinterval = 15;
    //ターゲットの生成量の箱
    private int targetmount;
    //ターゲットを生成する目標値の箱
    private int[] targetpoints = new int[99];
    //while文用変数
    private int k = 0;

    // Use this for initialization
    void Start()
    {
        //UnitychanObjuectを取得
        this.unitychan = GameObject.Find("unitychan");

        //ターゲットの生成量計算
        targetmount = (goalPos - startPos) / targetinterval;

        //アイテム生成の目標値を決定
        for(int i = 0; i < targetmount; i++)
        {
            targetpoints[i] = startPos + targetinterval * i;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //アイテム生成開始
        while (k < targetmount)
        {
            if (targetpoints[k] - unitychan.transform.position.z <= 50)
            {
                //どのアイテムを出すのかをランダムに設定
                int num = Random.Range(1, 11);
                if (num <= 2)
                {
                    //コーンをx軸方向に一直線に生成
                    for (float j = -1; j <= 1; j += 0.4f)
                    {
                        GameObject cone = Instantiate(conePrefab);
                        cone.transform.position = new Vector3(4 * j, cone.transform.position.y, targetpoints[k]);
                    }
                }
                else
                {
                    //レーンごとにアイテムを生成
                    for (int j = -1; j <= 1; j++)
                    {
                        //アイテムの種類を決める
                        int item = Random.Range(1, 11);
                        //アイテムを置くZ座標のオフセットをランダムに設定
                        int offsetZ = Random.Range(-5, 6);
                        //60%コイン配置:30%車配置:10%何もなし
                        if (1 <= item && item <= 6)
                        {
                            //コインを生成
                            GameObject coin = Instantiate(coinPrefab);
                            coin.transform.position = new Vector3(posRange * j, coin.transform.position.y, targetpoints[k] + offsetZ);
                        }
                        else if (7 <= item && item <= 9)
                        {
                            //車を生成
                            GameObject car = Instantiate(carPrefab);
                            car.transform.position = new Vector3(posRange * j, car.transform.position.y, targetpoints[k] + offsetZ);
                        }
                    }
                }

                k++;//アイテムが生成できたら次の目標値との座標比較に移る
            }
            break;//unity実行が固まらないように都度breakする
        }
    }
}
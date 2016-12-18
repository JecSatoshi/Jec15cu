using UnityEngine;
using System.Collections;

public class SelectJudge : MonoBehaviour {

	public GameObject gamest;		//U&I

	public static bool P1;          //Player1が決定しているか判定用
	public static bool P2;          //Player2が決定しているか判定用
    public static bool P3;          //Player3が決定しているか判定用
    public static bool P4;          //Player4が決定しているか判定用

    public static bool PlayerOver;  //2人以上決定しているか判定用

	void Start()
	{
        PlayerOver = false;     //falseで初期化
		Player = new GameObject[transform.childCount];      //プレイヤー4人分格納する
        //↓各プレイヤーを格納
		for (int i = 0; i < transform.childCount; i++) Player[i] = transform.GetChild(i).gameObject;
	}

    //[SerectAll]にて各プレイヤーが決定した時の処理
	public void UIActive()
	{
		if (!PlayerOver) Overplayer();     /*決定しているプレイヤーが2人未満の時
                                           　なお2人以上のときは処理しない*/
		if(PlayerOver) Selectjudge();      /*UIを表示する処理*/
	}

    //ここでは決定している人数を求めている
	void Overplayer()
	{
		int count = 0;
		if (P1) count++;    //trueだったらcountを+していく
		if (P2) count++;
		if (P3) count++;
		if (P4) count++;
        /*↓countが2以上(決定しているプレイヤーが2人以上)の時はPlayerOverをtrueにする。
        　　この処理を行わないようにするため。*/
		if (2 <= count) PlayerOver = true;  
	}

    //UI表示させるかの処理
	void Selectjudge()
	{
        /*↓ここでは各プレイヤーが表示されているが決定していないときはreturnで処理を終わらせる。
        　各プレイヤーが決定までしている、もしくは非表示だったら次の処理に進む。
        　また1人だけしか決定していない時にここの処理をしないためにPlayerOverで制御している。*/
        if (Player[0].activeSelf && !P1) return;    
        if (Player[1].activeSelf && !P2) return;
        if (Player[2].activeSelf && !P3) return;
        if (Player[3].activeSelf && !P4) return;

        gamest.SetActive(true); //ここでUIを表示させている
    }
}

using UnityEngine;
using System.Collections;
using UnityEngine.UI; // ←※これを忘れずに入れる

public class HpBarCtrl: MonoBehaviour {
public GameObject _slider;
private Slider hpvar;
  
  void Start () {
    // スライダーを取得する
   hpvar = _slider.GetComponentInChildren<Slider>();
  }

 public float _hp = 1;
  void Update () {
    // HP上昇
   
    // HPゲージに値を設定
    hpvar.value = _hp;
  }
}
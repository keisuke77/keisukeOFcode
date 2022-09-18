using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class opening : MonoBehaviour
{

    public Transform tr2;
public Transform tr3;
public bool auto;
    // Start is called before the first frame update
   public void openingchat()
    {  
        keikei.message.tr1=transform;
keikei.message.tr2=tr2;

keikei.message.tr3=tr3;



      
        keikei.SetMessageAtractCamera(transform,"やっほー！今から君にこの世界をプロデュースするエレンだよ。チャットを進むにはアイコンをクリックしてね<>このワールドは吉岡けいすけっていうちょっとプログラミングを極めた感じの人が作ったよ！<>このワールドの操作をまずはせつめいしようか！<>tr2ほらほら、これで操作を覚えてね！<>ちなみにいつでもこのロビーから閲覧できるよ。<>tr1どうでもいいかもしれないけれどこの世界を作るのに一年近くかけているよ<>これであとはそろそろ君も始めたいだろうから一つだけアドバイスしておくよ<>tr3あそこの転送装置をZボタンで殴って起動させてみよう。<>じゃあ！ぐっどらっく！");  
    }

private void Start()
{
    if (auto)
    {
        openingchat();
    }
}

    // Update is called once per frame
    void Update()
    {
        
    }
}

/*[このスクリプト(S_ADXCommands)について]
 * このスクリプトは、サウンド用のスクリプティングを簡略化するためのものです。
 * 
 * ADXのexPlayerを用いてCue(音）の再生を行う場合、単純な再生であっても
 *  1.exPlayerに再生するCueを設定する。
 *  2.exPlayerを再生する
 * という2工程が必要になります。
 * 
 * 今回のプロジェクトでは少なくとも50を超えるCueの再生命令を記述する必要があり、
 * 簡略化する方法をあらかじめ用意しておくことで、単純な再生命令にかける作業量を大幅に削減することができました。
 * 
 * また、個別に記述することで発生し得るミスを減らすこともでき、力を入れたいサウンド表現により一層力を注ぐことができました。
*/

using CriWare;
using SecretOftheStar.SOS_CueSheet;
using UnityEngine;

public class S_ADXCommands : MonoBehaviour
{  
    //単純な再生命令。OneShot系のCueや、ADX側でのアクション制御用Cueなどの再生に使用。
    static public void playCue(CriAtomExPlayer ExPlayer, CriWare.Assets.CriAtomCueReference cueReference, Cue cueName)
    {
        ExPlayer.SetCue(cueReference.AcbAsset.Handle, (int)cueName);
        ExPlayer.Start();
    }

    //Playbackを返す再生命令。再生した後に、パラメータ操作やプログラムからの停止処理を行いたいCueの再生に使用。
    static public  CriAtomExPlayback　playCueB(CriAtomExPlayer ExPlayer, CriWare.Assets.CriAtomCueReference cueReference, Cue cueName, CriAtomExPlayback Playback)
    {
        ExPlayer.SetCue(cueReference.AcbAsset.Handle, (int)cueName);
        Playback = ExPlayer.Start();
        return Playback;
    }
}

/*[このスクリプト(S_Kagee)について]
 * このスクリプトは、このゲーム特有のデバイスである「ダイスデバイス」を用いた、
 * 影絵合わせパズルギミックのサウンド演出を行うためのものです。
 * 
 * プレイヤーが現実世界でデバイスを回転させ、画面に映る物体の影を手掛かりに正解の角度に合わせていくという内容のパズルです。
 * サウンドが付いていない状態へのフィードバックとして「なぜクリアできたかも分からない。納得感がない」や
 * 「正解への手がかりが画面上に見える影だけだと、難しくてなかなかクリアできない」という意見があり、
 * このパズルを遊べるものにすることがサウンドの役割であると考え提案を行いました。
 * 
 * 現在の角度と正解の角度の差を音で示せれば、パズルの手掛かりに出来ると考え、
 * ADXのAISAC機能を用いて、インタラクティブな効果音表現を実現しました。
 * 
 * 音が付いた状態で再びフィードバックを受けた際には、「ちゃんとプレイできるようになっている」
 * 「デバイスの面白味が活かせている」という好評を頂くことができ、ゲームメカニクスに貢献するサウンドの価値を改めて実感しました。
*/


using CriWare;
using SecretOftheStar.SOS_CueSheet
using UnityEngine;

public class S_ADXKagee : MonoBehaviour
{
    //CRI ADX関連
    private CriAtomExPlayer ExPlayer;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;
    CriWare.CriAtomExPlayback kageePlayback;//一度再生したCueを操作するためのオブジェクト。

    //インスペクタで設定するもの
    [SerializeField] Transform rotateTarget;// プレイヤーが回すオブジェクト
    [SerializeField] Vector3 correctEulerAngles;// 正解の回転（オイラー角）

    //音の変化に用いるパラメータ
    Vector3 answer;
    private float diff;
    private float AISACValue;

    void UpdateAISACValue()//正解との角度差を取得する関数。StartとUpdateの両方で同じ処理を用いるため関数化。
    {
        Quaternion current = rotateTarget.rotation;
        Quaternion target = Quaternion.Euler(correctEulerAngles);
        diff = Quaternion.Angle(current, target);
        AISACValue = 1f - diff / 180f;
    }

    void Start()
    {
        ExPlayer = new CriWare.CriAtomExPlayer();
        UpdateAISACValue();
        ExPlayer.SetAisacControl("AisacControl_00", AISACValue);
        S_ADXCommands.playCueB(ExPlayer, cueReference, Cue.Kagee, kageePlayback);//停止処理はクリア時の効果音Cue内に仕込み、プログラムを簡略化している。
    }

    void Update()//毎フレーム、状態に応じて変化を調整
    {
        UpdateAISACValue();
        ExPlayer.SetAisacControl("AisacControl_00", AISACValue);
        ExPlayer.Update(kageePlayback);        
    }    
}

/*[このスクリプト(S_ADXFootSteps)について]
 * このスクリプトは、移動時の足音を制御するためのスクリプトです。
 * 
 * 本ゲームは一人称視点で進行し、プレイヤーキャラクターのモデルが存在しないため、
 * アニメーションに合わせた足音の再生が出来ず、細かな動きの描写は音のみで賄う必要がありました。
 * ゲーム体験を左右する歩行の感覚を没入感あるものにするために、スクリプト側とADX側の両方に様々な工夫を施しました。
 * 
 * スクリプト側では、管理する移動状態を３パターン設けることで、「動き出し」「移動中」「停止」という重要なポイントで、
 * 適切に音を鳴らし分けられるシステムを構築しました。 
*/

using CriWare;
using SecretOftheStar.SOS_CueSheet;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class S_ADXFootSteps : MonoBehaviour
{
    //CRI ADX関連
    private CriAtomExPlayer exPlayer;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;

    //インスペクタで設定するもの
    [SerializeField] GameObject playerObject;
    [Tooltip("足音の間隔(秒)")][SerializeField] float walkPace;

    //移動状態の管理
    public enum MoveState     //ゲームの仕様・目標とする表現に合わせて3パターンを用意
    {
        Stopped,
        StartMove,
        Moving,
    }
    public MoveState CurrentState { get; private set; } = MoveState.Stopped;


    private Vector3 previousPosition;    //展示等で使用するコントローラー環境が不確実であったため、inputではなくゲーム内の移動を基準に足音を管理
    private const float MoveThreshold = 0.04f;//移動検知用のしきい値。数値はプレイしながら調整した。
    private Coroutine runningCoroutine;


    void Start()//ExPlayerのインスタンス化と移動検知用変数の初期値設定
    {
        exPlayer = new CriWare.CriAtomExPlayer();//シーンとコンポーネントの寿命が一致しているため、このスクリプトでのDisposeは行わず、CRIの終了処理に任せている。
        previousPosition = playerObject.transform.position;
    }

    void Update()
    {
        if (Time.deltaTime == 0)
        {
            previousPosition = playerObject.transform.position;
            return;
        }

        float speed = (playerObject.transform.position - previousPosition).magnitude / Time.deltaTime;//前フレームからの移動距離÷時間
        bool moved = speed >= MoveThreshold;//動いていたかどうか         

        if (CurrentState == MoveState.Stopped)//歩き始めの検知
        {
            if (moved)
            {
                CurrentState = MoveState.StartMove;
                S_ADXCommands.playCue(exPlayer, cueReference, Cue.StartMove);//歩き始めのCue（音）2
                runningCoroutine = StartCoroutine(Moving());
            }
        }
        else if (CurrentState == MoveState.StartMove || CurrentState == MoveState.Moving)//歩き終わりの検知
        {
            if (!moved)
            {
                StopMove();
                S_ADXCommands.playCue(exPlayer, cueReference, Cue.StopMove);//歩き終わりのCue（音）
            }
        }

        previousPosition = playerObject.transform.position;
    }

    public void StopMove()//スクリプト側からも停止処理を書けるようにUpdate内から分離したもの
    {
        CurrentState = MoveState.Stopped;
        if (runningCoroutine != null)
        {
            StopCoroutine(runningCoroutine);
            runningCoroutine = null;
        }
    }

    IEnumerator Moving()
    {
        while (true)
        {
            if (CurrentState == MoveState.StartMove)//最初の一歩。通常の間隔よりも短い待機時間
            {
                yield return new WaitForSeconds(walkPace / 3);
                S_ADXCommands.playCue(exPlayer, cueReference, Cue.FootSteps);
                CurrentState = MoveState.Moving;
            }
            else if (CurrentState == MoveState.Moving)//2歩目以降の間隔を維持した足音
            {
                yield return new WaitForSeconds(walkPace);
                S_ADXCommands.playCue(exPlayer, cueReference, Cue.FootSteps);
            }
            else
            {
                yield break;
            }
        }
    }

    public void SetSurface(string label)//床の素材やイベント発生による足音の変化用。ゲーム側の仕様変更により最終版では使用されていない。
    {
        exPlayer.SetSelectorLabel("Selector_0", label);
    }
}
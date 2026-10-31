/*[このスクリプト(S_ADXPlayer)について]
 * このスクリプトは、サウンド管轄外のスクリプトから呼び出したいキューの再生命令を集めたものです。
 * 
 * 開発順序の問題から、他のプログラマが実装したプログラムに後から音の再生を仕込むという方法が難しく、
 * 時間的な制約の中で上手く協働するために、サウンド側で予め関数と再生を仕込むポイントを依頼し、
 * 各々のプログラマが担当部分を実装したタイミングで仕込んでもらうという流れを取りました。
 * 
 * この手法を取ったことで、発表や展示の当日早朝に実装されたようなプログラムにも、しっかり音を付けられるようになり、
 * ギリギリまで質を高めたい他プログラマーと上手く連携することができました。
 * 
 * なお、他の方に依頼した部分でも、出音の確認を欠かさず行うなど、サウンドに責任を持つ姿勢は一貫して心掛けました。
*/

using CriWare;
using SecretOftheStar.SOS_CueSheet;
using UnityEngine;

public class S_ADXPlayer : MonoBehaviour
{
    private CriAtomExPlayer exPlayer;
    [SerializeField]
    CriWare.Assets.CriAtomCueReference cueReference;

    void Awake()
    {
        exPlayer = new CriWare.CriAtomExPlayer();
    }

    //他スクリプトからの呼び出し例
    //  GameObject adxManager = GameObject.Find("ADXManager");
    //  adxManager.GetComponent<S_ADXPlayer>().ADX_GameStart();


    //タイトル
    public void ADX_TitleMusic()//タイトル画面のBGM
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.TitleMusic);
    }

    public void ADX_GameStart()//ゲーム開始時の効果音
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.GameStart);
    }

    public void ADX_PrologueStart()//プロローグの開始
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.Prologue);
    }

    public void ADX_PrologueEnd()//プロローグの終了
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.PrologueEnd);
    }

    public void ADX_TitleUI()//タイトル画面でのUI操作
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SkipText);
    }


    //オプション
    public void ADX_OptionOpen()//オプション画面を開く
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.OptionOpen);
    }

    public void ADX_OptionClose()//オプション画面を閉じる
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.OptionClose);
    }


    //テキスト表示
    public void ADX_PopTextWindow()//テキストウィンドウの出現
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.PopText);
    }

    public void ADX_TextSkip()//テキスト送り、ウィンドウを閉じる操作
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SkipText);
    }


    //ダイス
    public void ADX_GoDice()//技能判定(目星・アイデア)でダイス画面へ遷移
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.UseSkill);
    }

    public void ADX_GoDice_San()//SAN値判定でダイス画面へ遷移
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SanRoll);
    }

    public void ADX_DiceResult_Good()//ダイス判定の結果が良好
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.DiceResult_Good);
    }

    public void ADX_DiceResult_Great()//ダイス判定の結果が非常に良好
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.DiceGreat);
    }

    public void ADX_DiceResult_Excellent()//ダイス判定の結果が最良
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.DiceResult_Good);
    }

    public void ADX_DiceResult_Bad()//ダイス判定の結果が不良
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.DiceResult_Bad);
    }

    public void ADX_DiceResult_Safe()//SAN値判定の結果が良好
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.DiceResult_Safe);
    }

    public void ADX_DiceResult_View()//ダイス結果の確認
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SkipText);
    }

    public void ADX_Find()//目星の実行
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.Find);
    }

    public void ADX_DiceCancel()//目星のキャンセル
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SkillCancel);
    }

    public void ADX_DiceReady()//ダイスを振る準備の完了
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SkipText);
    }

    public void ADX_DiceGauge()//ダイスのゲージ演出
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.DiceGauge);
    }

    public void ADX_GetSS()//SSの獲得
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.GetSS);
    }


    //アイテム取得
    public void ADX_GetItem()//アイテムの入手
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.GetItem);
    }

    public void ADX_GetItem_First()//アイテムの初回入手
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.GetItem_First);
    }

    public void ADX_GlassBreak()//目の入った瓶を投げ捨てる
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.GlassBreak);
    }

    public void ADX_SanRecovery()//SAN値回復アイテムの入手
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SanRecovery);
    }

    public void ADX_ItemFocus()//注視したアイテムのUI表示
    {
        //TODO: Cue未割り当て
    }


    //インベントリ
    public void ADX_InventoryOpen()//インベントリを開く
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.InventoryOpen);
    }

    public void ADX_InventoryUI_Move()//UIカーソルの移動
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.InventoryUI_Hover);
    }

    public void ADX_InventoryUI_Decide()//項目の決定
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.InventoryUI_Decide);
    }

    public void ADX_InventoryUI_Back()//前の画面へ戻る、閉じる
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.InventoryUI_Back);
    }

    public void ADX_UseSuccess()//アイテム使用の成功
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.UseSuccess);
    }

    public void ADX_UseMiss()//アイテム使用の失敗
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.UseMiss);
    }

    public void ADX_ItemUseUI()//アイテム使用画面でのUI操作
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SkipText);
    }


    //探索進捗
    public void ADX_TutorialExit()//チュートリアルエリアからの退出
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.TutorialExit);
    }

    public void ADX_EnterRoom()//部屋への入室
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.EnterRoom);
    }

    public void ADX_ExitRoom()//部屋からの退室
    {
        //TODO: Cue未割り当て
    }


    //ミニゲーム
    public void ADX_MinigameStart()//ミニゲームの開始
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.MinigameStart);
    }

    public void ADX_MinigameClear()//ミニゲームのクリア
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.ClearMinigame);
    }

    public void ADX_SmallDoor()//小さな扉が開く
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.SmallDoor);
    }

    public void ADX_BigDoor()//地面が揺れて大きな扉が開く
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.BigDoor);
    }


    //ゲーム終了
    public void ADX_GameClear()//ゲームクリア画面への遷移
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.ClearGame);
    }

    public void ADX_BadEnd_Loop()//バッドエンドのモノローグ開始
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.BadEnd_Loop);
    }

    public void ADX_BadEnd_End()//バッドエンドの表示
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.BadEnd_End);
    }

    public void ADX_GoodEnd()//ゲームクリア後の「探索は続く」表示
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.GoodEnd);
    }


    //デバイス
    public void ADX_DeviceDisconnect()//デバイスの切断
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.DeviceDisconnect);
    }

    public void ADX_DeviceConnect()//デバイスの接続
    {
        S_ADXCommands.playCue(exPlayer, cueReference, Cue.DeviceConnect);
    }
}
/*[このスクリプト(S_ADX3Dpos)について]
 * このスクリプトは、スキルによって発見したオブジェクトや、マップ上を徘徊する敵キャラクターに対し
 * 3Dポジショニングを伴うサウンド表現を行ったものです。
 * 
 * 実装の都合から予め音の再生位置を設定することが難しいものがあり、
 * 他のスクリプトと干渉しない範囲で、目的とする表現を行うことに苦労しました。
*/


using CriWare;
using SecretOftheStar.SOS_CueSheet;
using UnityEngine;

public class S_ADX3DPos : MonoBehaviour
{
    private const int MaxFoundObjects = 10;//同時に鳴らせる発見オブジェクトの音の数(＝マップ上に設置されるオブジェクトの総数）

    private CriAtomExPlayer exPlayer;
    [SerializeField]
    private CriWare.Assets.CriAtomCueReference cueReference;
    private CriAtomEx3dListener listener;

    [SerializeField] private Transform cameraTransform;//リスナーの位置・向きの基準。未設定ならMainCameraを使う

    //マップ周回型の敵キャラクター
    [SerializeField] private Transform enemyEye01;
    [SerializeField] private Transform enemyEye02;
    private CriAtomEx3dSource enemySource01;
    private CriAtomEx3dSource enemySource02;
    private CriAtomExPlayback enemyPlayback01;
    private CriAtomExPlayback enemyPlayback02;

    //発見オブジェクト(スロットを順番に使い回す)
    private readonly CriAtomEx3dSource[] foundObjectSources = new CriAtomEx3dSource[MaxFoundObjects];
    private readonly CriAtomExPlayback[] foundObjectPlaybacks = new CriAtomExPlayback[MaxFoundObjects];
    private readonly GameObject[] foundObjects = new GameObject[MaxFoundObjects];
    private int nextSlot;


    void Awake()
    {
        exPlayer = new CriAtomExPlayer();
        listener = new CriAtomEx3dListener();
        exPlayer.Set3dListener(listener);

        for (int i = 0; i < MaxFoundObjects; i++)
        {
            foundObjectSources[i] = new CriAtomEx3dSource();
        }
        enemySource01 = new CriAtomEx3dSource();
        enemySource02 = new CriAtomEx3dSource();
    }

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
        UpdateListener();

        enemyPlayback01 = StartEnemySound(enemySource01, enemyEye01);
        enemyPlayback02 = StartEnemySound(enemySource02, enemyEye02);
    }

    void Update()
    {
        UpdateListener();
        UpdateSource(enemySource01, enemyEye01);
        UpdateSource(enemySource02, enemyEye02);
    }


    //オブジェクトを発見したとき。その位置で定位するループ音を鳴らす
    public void ADX_ObjectFound(GameObject itemObj)
    {
        //使い回すスロットで音が残っていれば止める
        if (foundObjects[nextSlot] != null)
        {
            foundObjectPlaybacks[nextSlot].Stop();
        }

        foundObjects[nextSlot] = itemObj;
        UpdateSource(foundObjectSources[nextSlot], itemObj.transform);
        exPlayer.Set3dSource(foundObjectSources[nextSlot]);
        exPlayer.SetCue(cueReference.AcbAsset.Handle, (int)Cue.FoundObjects);
        foundObjectPlaybacks[nextSlot] = exPlayer.Start();

        nextSlot = (nextSlot + 1) % MaxFoundObjects;
    }

    //発見したオブジェクトを取得したとき。対応するループ音を止める
    public void ADX_ObjectGet(GameObject itemObj)
    {
        if (itemObj == null) return;

        for (int i = 0; i < MaxFoundObjects; i++)
        {
            if (foundObjects[i] == itemObj)
            {
                foundObjectPlaybacks[i].Stop();
                foundObjects[i] = null;
            }
        }
    }

    //敵が消えたとき。対応する敵の音を止める
    public void ADX_EnemyDisappear(GameObject enemyEye)
    {
        if (enemyEye.transform == enemyEye01)
        {
            enemyPlayback01.Stop();
        }
        else if (enemyEye.transform == enemyEye02)
        {
            enemyPlayback02.Stop();
        }
        else
        {
            Debug.LogWarning("S_ADX3DPos.ADX_EnemyDisappear: unknown enemy eye");
        }
    }


    private CriAtomExPlayback StartEnemySound(CriAtomEx3dSource source, Transform eye)
    {
        exPlayer.SetCue(cueReference.AcbAsset.Handle, (int)Cue.EnemyEye);
        exPlayer.Set3dSource(source);
        UpdateSource(source, eye);
        return exPlayer.Start();
    }

    //カメラの位置と向きをリスナーに反映
    private void UpdateListener()
    {
        Vector3 pos = cameraTransform.position;
        Vector3 forward = cameraTransform.forward;
        Vector3 up = cameraTransform.up;
        listener.SetPosition(pos.x, pos.y, pos.z);
        listener.SetOrientation(forward.x, forward.y, forward.z, up.x, up.y, up.z);
        listener.Update();
    }

    //対象の位置を音源に反映
    private void UpdateSource(CriAtomEx3dSource source, Transform target)
    {
        Vector3 pos = target.position;
        source.SetPosition(pos.x, pos.y, pos.z);
        source.Update();
    }
}
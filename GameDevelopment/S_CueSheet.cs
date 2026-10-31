/*[このスクリプト(S_CueSheet)について]
 * このスクリプトは、ADXのビルド時に出力されるCueSheetの情報です。
 * 
 * Cue(音）の再生を行う際、始めは手軽に実装できるid指定を行っていたのですが、
 * 指定ミスの判別がつきづらいという問題に気が付き、ADXファイルを用意する際に生成されるenumを用いた指定に切り替えました。 
 * マジックナンバーの多用を控えられたことで、チームの他プログラマからも理解しやすい実装が出来たと考えます。
 */

///<summary></summary>
namespace SecretOftheStar.SOS_CueSheet
{
    public class SOS_CueSheet
    {
        ///<summary></summary>
        public const int FootSteps = (0);
        ///<summary></summary>
        public const int Kinuzure = (1);
        ///<summary></summary>
        public const int StartMove = (2);
        ///<summary></summary>
        public const int StopMove = (3);
        ///<summary></summary>
        public const int GetItem = (4);
        ///<summary></summary>
        public const int InventoryOpen = (5);
        ///<summary></summary>
        public const int InventoryUI_Back = (6);
        ///<summary></summary>
        public const int InventoryUI_Hover = (7);
        ///<summary></summary>
        public const int Ambient = (8);
        ///<summary></summary>
        public const int UseSkill = (9);
        ///<summary></summary>
        public const int ShakeDice = (10);
        ///<summary></summary>
        public const int DiceRolling = (11);
        ///<summary></summary>
        public const int DiceResult_Good = (12);
        ///<summary></summary>
        public const int DiceReady = (13);
        ///<summary></summary>
        public const int TitleMusic = (14);
        ///<summary></summary>
        public const int GameStart = (15);
        ///<summary></summary>
        public const int BidamaRoll = (16);
        ///<summary></summary>
        public const int BidamaStop = (17);
        ///<summary></summary>
        public const int ClearMinigame = (18);
        ///<summary></summary>
        public const int MinigameStart = (19);
        ///<summary></summary>
        public const int SanRoll = (20);
        ///<summary></summary>
        public const int DiceResult_Bad = (21);
        ///<summary></summary>
        public const int DiceResult_Safe = (22);
        ///<summary></summary>
        public const int InventoryUI_Decide = (23);
        ///<summary></summary>
        public const int Find = (24);
        ///<summary></summary>
        public const int FoundItem = (25);
        ///<summary></summary>
        public const int GetItem_First = (26);
        ///<summary></summary>
        public const int UseSuccess = (27);
        ///<summary></summary>
        public const int UseMiss = (28);
        ///<summary></summary>
        public const int OptionOpen = (29);
        ///<summary></summary>
        public const int OptionClose = (30);
        ///<summary></summary>
        public const int ClearGame = (31);
        ///<summary></summary>
        public const int SmallDoor = (32);
        ///<summary></summary>
        public const int BigDoor = (33);
        ///<summary></summary>
        public const int SkipText = (36);
        ///<summary></summary>
        public const int PopText = (37);
        ///<summary></summary>
        public const int Kagee = (38);
        ///<summary></summary>
        public const int KokePop = (39);
        ///<summary></summary>
        public const int Prologue = (40);
        ///<summary></summary>
        public const int PrologueEnd = (41);
        ///<summary></summary>
        public const int GlassBreak = (42);
        ///<summary></summary>
        public const int BadEnd_Loop = (43);
        ///<summary></summary>
        public const int BadEnd_End = (44);
        ///<summary></summary>
        public const int GoodEnd = (45);
        ///<summary></summary>
        public const int SkillCancel = (46);
        ///<summary></summary>
        public const int SanRecovery = (47);
        ///<summary></summary>
        public const int TutorialExit = (48);
        ///<summary></summary>
        public const int EnterRoom = (49);
        ///<summary></summary>
        public const int DeviceDisconnect = (50);
        ///<summary></summary>
        public const int DeviceConnect = (51);
        ///<summary></summary>
        public const int GetSS = (52);
        ///<summary></summary>
        public const int EnemyEye = (53);
        ///<summary></summary>
        public const int FoundObjects = (54);
        ///<summary></summary>
        public const int DiceGreat = (55);
        ///<summary></summary>
        public const int DiceGauge = (103);
    }

    public enum Cue
    {
        ///<summary></summary>
        FootSteps = 0,
        ///<summary></summary>
        Kinuzure = 1,
        ///<summary></summary>
        StartMove = 2,
        ///<summary></summary>
        StopMove = 3,
        ///<summary></summary>
        GetItem = 4,
        ///<summary></summary>
        InventoryOpen = 5,
        ///<summary></summary>
        InventoryUI_Back = 6,
        ///<summary></summary>
        InventoryUI_Hover = 7,
        ///<summary></summary>
        Ambient = 8,
        ///<summary></summary>
        UseSkill = 9,
        ///<summary></summary>
        ShakeDice = 10,
        ///<summary></summary>
        DiceRolling = 11,
        ///<summary></summary>
        DiceResult_Good = 12,
        ///<summary></summary>
        DiceReady = 13,
        ///<summary></summary>
        TitleMusic = 14,
        ///<summary></summary>
        GameStart = 15,
        ///<summary></summary>
        BidamaRoll = 16,
        ///<summary></summary>
        BidamaStop = 17,
        ///<summary></summary>
        ClearMinigame = 18,
        ///<summary></summary>
        MinigameStart = 19,
        ///<summary></summary>
        SanRoll = 20,
        ///<summary></summary>
        DiceResult_Bad = 21,
        ///<summary></summary>
        DiceResult_Safe = 22,
        ///<summary></summary>
        InventoryUI_Decide = 23,
        ///<summary></summary>
        Find = 24,
        ///<summary></summary>
        FoundItem = 25,
        ///<summary></summary>
        GetItem_First = 26,
        ///<summary></summary>
        UseSuccess = 27,
        ///<summary></summary>
        UseMiss = 28,
        ///<summary></summary>
        OptionOpen = 29,
        ///<summary></summary>
        OptionClose = 30,
        ///<summary></summary>
        ClearGame = 31,
        ///<summary></summary>
        SmallDoor = 32,
        ///<summary></summary>
        BigDoor = 33,
        ///<summary></summary>
        SkipText = 36,
        ///<summary></summary>
        PopText = 37,
        ///<summary></summary>
        Kagee = 38,
        ///<summary></summary>
        KokePop = 39,
        ///<summary></summary>
        Prologue = 40,
        ///<summary></summary>
        PrologueEnd = 41,
        ///<summary></summary>
        GlassBreak = 42,
        ///<summary></summary>
        BadEnd_Loop = 43,
        ///<summary></summary>
        BadEnd_End = 44,
        ///<summary></summary>
        GoodEnd = 45,
        ///<summary></summary>
        SkillCancel = 46,
        ///<summary></summary>
        SanRecovery = 47,
        ///<summary></summary>
        TutorialExit = 48,
        ///<summary></summary>
        EnterRoom = 49,
        ///<summary></summary>
        DeviceDisconnect = 50,
        ///<summary></summary>
        DeviceConnect = 51,
        ///<summary></summary>
        GetSS = 52,
        ///<summary></summary>
        EnemyEye = 53,
        ///<summary></summary>
        FoundObjects = 54,
        ///<summary></summary>
        DiceGreat = 55,
        ///<summary></summary>
        DiceGauge = 103,
    }
    public enum AisacControl
    {
        ///<summary></summary>
        AisacControl_00 = 0,
    }
}
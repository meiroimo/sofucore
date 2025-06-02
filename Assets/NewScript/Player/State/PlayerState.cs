/// <summary>
/// わからなかったら
/// 「unity player state Pattern」で検索してみて   
/// </summary>
public abstract class PlayerState
{
    protected PlayerController player;

    //コンストラクタ
    public PlayerState(PlayerController player)
    {
        this.player = player;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

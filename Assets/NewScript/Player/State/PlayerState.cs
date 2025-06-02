/// <summary>
/// �킩��Ȃ�������
/// �uunity player state Pattern�v�Ō������Ă݂�   
/// </summary>
public abstract class PlayerState
{
    protected PlayerController player;

    //�R���X�g���N�^
    public PlayerState(PlayerController player)
    {
        this.player = player;
    }

    public abstract void Enter();
    public abstract void Update();
    public abstract void Exit();
}

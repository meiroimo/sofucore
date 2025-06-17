using UnityEngine;

public class PlayerLightAttackState : PlayerState
{
    Ray ray;

    private float attackRadius = 5f;
    private float attackAngle = 60f;
    private int attackDamage = 10;
    private LayerMask enemyLayer;

    public PlayerLightAttackState(PlayerController player) : base(player) 
    {
        this.enemyLayer = player.enemyLayer; // �R���g���[���[���烌�C���[�擾
    }

    public override void Enter()
    {
        //Debug.Log("Entered LightAttack State");

    }

    public override void Update()
    {
        //�}�E�X�ʒu�ւ�Ray���擾
        ray = player.mainCamera.ScreenPointToRay(Input.mousePosition);

        //�v���C���[�̍����ɐ����ȉ��z���ʂ��쐬
        Plane groundPlane = new Plane(Vector3.up, player.transform.position);

        if (groundPlane.Raycast(ray, out float distance))
        {
            Vector3 lookPoint = ray.GetPoint(distance);

            // 3. �v���C���[���}�E�X�ʒu�̕���������
            Vector3 targetDirection = lookPoint - player.transform.position;
            targetDirection.y = 0f; // �����̂݉�]
            if (targetDirection != Vector3.zero)
            {
                player.transform.rotation = Quaternion.LookRotation(targetDirection);
            }
        }

        PlayerLAttack();

        // �U�����I�������ҋ@��Ԃɖ߂�
        player.ChangeState(new PlayerIdleState(player));

    }

    public override void Exit()
    {
        //Debug.Log("Exited LightAttack State");
    }

    private void PlayerLAttack()
    {
        Vector3 origin = player.transform.position;
        Vector3 forward = player.transform.forward;

        Collider[] hits = Physics.OverlapSphere(origin, attackRadius, enemyLayer);

        foreach (Collider col in hits)
        {
            Vector3 dirToTarget = (col.transform.position - origin).normalized;
            dirToTarget.y = 0; // �����݂̂Ŕ�r

            float angle = Vector3.Angle(forward, dirToTarget);
            if (angle < attackAngle / 2f)
            {
                Debug.Log($"{col.name} �ɍU�����������܂����I");
                EnemyController enemy = col.GetComponent<EnemyController>();
                if (enemy != null)
                {
                    enemy.OnHit(player);

                }
            }
        }
    }


}

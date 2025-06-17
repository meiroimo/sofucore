using UnityEngine;
using UnityEngine.Windows;

/// <summary>
/// �v���C���[�̕K�E�Z�i8��A���Ђ������j�𐧌䂷��X�e�[�g
/// </summary>
public class PlayerSkillAttackState : PlayerState
{
    private int attackCount = 0;                // ���܂ł̂Ђ�������
    private float attackInterval = 0.5f;        // �e�Ђ������̊Ԋu�i�b�j
    private float timer = 0f;                   // �o�ߎ���
    private int maxAttacks = 8;                 // �ő�Ђ������񐔁i8��j

    private float attackMoveSpeedMultiplier = 1.2f; // �U�����̈ړ����x�{���i�ʏ��1.2�{�j

    Ray ray;

    private float attackRadius = 5f;
    private float attackAngle = 50f;
    private int attackDamage = 10;
    private LayerMask enemyLayer;

    public PlayerSkillAttackState(PlayerController player) : base(player)
    {
        this.enemyLayer = player.enemyLayer; // �R���g���[���[���烌�C���[�擾
    }

    public override void Enter()
    {
        //Debug.Log("Entered LightAttack State");
        attackCount = 0;
        timer = 0f;

        //player.SetInvincible(true);             // �U�����͖��G�ɂ���
        Debug.Log($"�Ђ������U��{attackCount + 1}���");
        //DoClawAttack();                         // �ŏ��̂Ђ������U���𔭓�
    }

    public override void Update()
    {
        // �v���C���[�̈ړ��i���͂ɉ����āA���x��1.2�{�j
        Vector2 moveInput = player.MoveInput;

        if (moveInput != Vector2.zero)
        {
            //Vector3 moveDir = player.GetCameraRelativeDirection(moveInput);
            Vector3 moveDirection = new Vector3(moveInput.x, 0, moveInput.y); // Z�����ړ�
            player.MoveCharacter(moveDirection, player.moveForce * attackMoveSpeedMultiplier);
        }

        //�}�E�X�ʒu�ւ�Ray���擾
        ray = player.mainCamera.ScreenPointToRay(UnityEngine.Input.mousePosition);

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

        //PlayerLAttack();

        // ���Ԃ��J�E���g���ĂЂ������Ԋu���Ǘ�
        timer += Time.deltaTime;

        // �ő�񐔂ɓ��B������I���iIdle�ɖ߂��j
        if (attackCount >= maxAttacks)
        {
            player.ChangeState(new PlayerIdleState(player));
            return;
        }

        // ��莞�Ԍo�߂����玟�̂Ђ������𔭓�
        if (timer >= attackInterval)
        {
            timer = 0f;
            //Debug.Log($"�Ђ������U��{attackCount + 1}���");
            DoClawAttack();
        }

        // �U�����I�������ҋ@��Ԃɖ߂�
        //player.ChangeState(new PlayerIdleState(player));



    }

    public override void Exit()
    {
        //Debug.Log("Exited LightAttack State");
    }

    // �ЂƂ̂Ђ���������
    private void DoClawAttack()
    {
        attackCount++;                          // �񐔃J�E���g

        //player.PlayAttackAnimation(attackCount); // �A�j���[�V�����iClaw1 / Claw2 �ؑցj
        //player.DealDamageInFront();              // �O���Ƀ_���[�W��^���鏈���i�����蔻��j
        PlayerLAttack();
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
                //Enemy enemy = col.GetComponent<Enemy>();
                //if (enemy != null)
                //{
                //    enemy.TakeDamage(attackDamage);
                //    
                //}
            }
        }
    }
}

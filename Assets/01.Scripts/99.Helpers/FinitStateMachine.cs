using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Finite State Machine (유한 상태 머신)
// 객체가 가질 수 있는 여러가지 상태중에, 현재 상태를 딱 하나로 고정

public class Player : MonoBehaviour
{

}

public enum MonsterState
{
    IDLE,
    MOVE,
    ATTACK,
    DEATH,
}

public class Monster : MonoBehaviour
{
    private MonsterState _state;
    private Player _player;

    public void SetState(MonsterState state)
    {
        _state = state;

        switch (_state)
        {
            case MonsterState.IDLE:
                OnIdle();
                break;

            case MonsterState.MOVE:
                OnMove();
                break;

            case MonsterState.ATTACK:
                OnAttack();
                break;

            case MonsterState.DEATH:
                OnDeath();
                break;
        }
    }

    private void OnIdle()
    {
        // 아이들 애니메이션 재생
        // 코루틴을 이용해서, 플레이어가 가까이 접근하는지 체크
    }

    private void OnMove()
    {
        // 코루틴을 이용해서, 플레이어에게 접근하도록
    }

    private void OnAttack()
    {
        // 코루틴을 이용해서, 공격 딜레이마다 플레이어 공격
    }

    private void OnDeath()
    {
        // 죽음 애니메이션 재생
        // 게임 오브젝트 파괴 / 비활성화
    }
}

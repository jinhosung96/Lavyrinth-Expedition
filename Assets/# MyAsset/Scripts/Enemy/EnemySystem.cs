using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace JHS
{
    #region 머리말 주석
    /// <summary>
    ///
    /// 원 저작자(개발자) : 진호성 <para></para>
    /// 개요 : <para></para>
    /// 
    /// </summary>
    #endregion
    public class EnemySystem : JHS.SystemObject<EnemySystem>
    {
        #region 필드

        [SerializeField] Vector3 monsterSpawnPos;
        [SerializeField] GameObject[] monsters;

        #endregion

        #region 공개 메소드

        public GameObject SpawnRandomMonster()
        {
            int rnd = (int)(Random.value * monsters.Length);
            GameObject monster = PoolManager.Instance.PopObject(monsters[rnd]);
            monster.transform.parent = FolderSystem.Instance.MonsterFolder;
            monster.transform.localPosition = monsterSpawnPos;

            return monster;
        }

        #endregion
    }
}

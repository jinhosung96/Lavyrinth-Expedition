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
    public class TileSystem : JHS.SystemObject<TileSystem>
    {
        #region 필드

        [SerializeField] GameObject currentTile;
        [SerializeField] Vector3 tileSpawnPos;
        [SerializeField] GameObject[] tiles;
        [SerializeField] float tileWidth;

        #endregion

        #region 속성

        public GameObject CurrentTile { get { return currentTile; } set { currentTile = value; } }

        public float TileWidth => tileWidth;

        #endregion

        #region 공개 메소드

        public GameObject SpawnRandomTile()
        {
            int rnd = (int)(Random.value * tiles.Length);
            GameObject tile = PoolManager.Instance.PopObject(tiles[rnd]);
            tile.transform.parent = FolderSystem.Instance.MonsterFolder;
            tile.transform.localPosition = tileSpawnPos;

            return tile;
        }

        #endregion
    }
}

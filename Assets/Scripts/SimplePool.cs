﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SimplePool
{

    const int DEFAULT_POOL_SIZE = 3;


    class Pool
    {

        int nextId = 1;
        Stack<GameObject> inactive;
        GameObject prefab;
        public Pool(GameObject prefab, int initialQty)
        {
            this.prefab = prefab;
            inactive = new Stack<GameObject>(initialQty);
        }

        public GameObject Spawn(Vector3 pos, Quaternion rot, GameObject parent = null)
        {
            GameObject obj;
            if (inactive.Count == 0)
            {
                obj = (GameObject)GameObject.Instantiate(prefab, pos, rot);
                obj.name = prefab.name + " (" + (nextId++) + ")";

                obj.AddComponent<PoolMember>().myPool = this;
            }
            else
            {
                obj = inactive.Pop();

                if (obj == null)
                {
                    return Spawn(pos, rot, parent);
                }
            }

            obj.transform.position = pos;
            obj.transform.rotation = rot;
            if (parent != null)
                obj.transform.parent = parent.transform;
            obj.SetActive(true);
            return obj;

        }

        public void Despawn(GameObject obj)
        {
            obj.SetActive(false);

            inactive.Push(obj);
        }
    }


    class PoolMember : MonoBehaviour
    {
        public Pool myPool;
    }

    static Dictionary<GameObject, Pool> pools;

    static void Init(GameObject prefab = null, int qty = DEFAULT_POOL_SIZE)
    {
        if (pools == null)
        {
            pools = new Dictionary<GameObject, Pool>();
        }
        if (prefab != null && pools.ContainsKey(prefab) == false)
        {
            pools[prefab] = new Pool(prefab, qty);
        }
    }


    static public void Preload(GameObject prefab, int qty = 1)
    {
        Init(prefab, qty);

        GameObject[] obs = new GameObject[qty];
        for (int i = 0; i < qty; i++)
        {
            obs[i] = Spawn(prefab, Vector3.zero, Quaternion.identity);
        }

        for (int i = 0; i < qty; i++)
        {
            Despawn(obs[i]);
        }
    }

    static public GameObject Spawn(GameObject prefab, Vector3 pos, Quaternion rot, GameObject parent = null)
    {
        Init(prefab);

        return pools[prefab].Spawn(pos, rot, parent);
    }

    static public void Despawn(GameObject obj)
    {
        PoolMember pm = obj.GetComponent<PoolMember>();
        if (pm == null)
        {
            Debug.Log("Object '" + obj.name + "' wasn't spawned from a pool. Destroying it instead.");
            GameObject.Destroy(obj);
        }
        else
        {
            pm.myPool.Despawn(obj);
        }
    }

}
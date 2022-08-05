using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

public class LoadAsset : MonoBehaviour
{
    // Assign in Editor or in code
    public string m_address = "0";

    // Retain handle to release asset and operation
    private AsyncOperationHandle<GameObject>[] handles;
    private List<GameObject> gos;

    // Start the load operation on start
    void Start()
    {
        handles = new AsyncOperationHandle<GameObject>[3];
        gos = new List<GameObject>(3);
        StartCoroutine(Loop());
    }

    // Instantiate the loaded prefab on complete
    private void Handle_Completed(AsyncOperationHandle<GameObject> operation)
    {
        if (operation.Status == AsyncOperationStatus.Succeeded)
        {
            gos.Add(Instantiate(operation.Result, transform));
            gos[gos.Count - 1].SetActive(true);
        }
        else
        {
            Debug.LogError($"Asset for {m_address} failed to load.");
        }
    }

    // Release asset when parent object is destroyed
    private void OnDestroy()
    {
        foreach (var handle in handles)
        {
            Addressables.Release(handle);
        }
    }

    IEnumerator Loop()
    {
        int curr = int.Parse(m_address);
        while (true)
        {
            // Hide previous GameObject
            int prevIdx = mod((curr - 1), 3);
            if (prevIdx < gos.Count && gos[prevIdx] != null)
            {
                gos[prevIdx].SetActive(false);
            }
            if (curr >= gos.Count || gos[curr] == null)
            {
                var handle = Addressables.LoadAssetAsync<GameObject>(m_address);
                handle.Completed += Handle_Completed;
                handles[curr] = handle;
                handle.WaitForCompletion();
            }
            else
            {
                gos[curr].SetActive(true);
            }
            m_address = mod(++curr, 3).ToString();
            if (curr == 3) curr = 0;
            yield return new WaitForSeconds(2f);
        }
    }

    private int mod(int x, int m)
    {
        return (x % m + m) % m;
    }
}

using System.Collections.Generic;
using UnityEngine;

public class BlockGenerator : MonoBehaviour
{
    [SerializeField] private GameObject blockPrefab;
    [SerializeField] private int rows = 3;
    [SerializeField] private int cols = 9;

    private int UpperSpace = 3;

    private UIScript _uiScript;

    private List<GameObject> blocks = new List<GameObject>();

    private void Start()
    {
        _uiScript = FindObjectOfType<UIScript>();
        GenerateBlocks();
    }

    private void GenerateBlocks()
    {
        for (int row = 0; row < rows; row++)
        {
            int colsCount = cols - row % 2;

            for (int col = 0; col < colsCount; col++)
            {
                Vector2 position = new Vector2((col * 2) - (colsCount - 1), row * -1 + UpperSpace);
                GameObject block = Instantiate(blockPrefab, position, Quaternion.identity);

                blocks.Add(block);
                block.GetComponent<BlocksBehavior>().onBlockDestroyed.AddListener(RemoveBlock);
            }
        }
    }

    public void RemoveBlock(GameObject block)
    {
        blocks.Remove(block);
        Destroy(block);

        if (blocks.Count == 0)
            DoSomething();
    }

    private void DoSomething()
    {
        Time.timeScale = 0;
        _uiScript.SetEndingUI();
    }
}
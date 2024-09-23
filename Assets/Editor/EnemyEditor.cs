using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Tilemaps;
using UnityEngine.Tilemaps;

// 定义了一个自定义编辑器类，它可以编辑多个对象，并专门用于编辑 Enemy 类型的对象。
[CanEditMultipleObjects, CustomEditor(typeof(Enemy))]
public class EnemyEditor : Editor
{
    // 重写 OnInspectorGUI 方法，该方法在 Inspector 面板中绘制自定义的 GUI 控件。
    public override void OnInspectorGUI()
    {
        // 调用基类的 OnInspectorGUI 方法，以显示默认的 Inspector GUI。
        base.OnInspectorGUI();

        // 如果用户点击了 "设置位置" 按钮...
        if (GUILayout.Button("设置位置"))
        {
            // 查找名为 "Grid/ground" 的 GameObject，并获取其 Tilemap 组件。
            Tilemap tileMap = GameObject.Find("Grid/ground").GetComponent<Tilemap>();

            // 获取 Tilemap 的所有单元格位置的枚举器。
            var allPos = tileMap.cellBounds.allPositionsWithin;

            // 初始化最小 x 和 y 坐标的变量。
            int min_x = 0;
            int min_y = 0;

            // 如果枚举器可以移动到下一个位置...
            if (allPos.MoveNext())
            {
                // 获取当前位置。
                Vector3Int current = allPos.Current;
                // 将当前位置的 x 和 y 坐标赋给最小坐标变量。
                // 注意：这里假设第一个位置就是最小坐标，如果需要找到真正的最小坐标，需要遍历所有位置。
                min_x = current.x;
                min_y = current.y;
            }

            // 获取当前选中的 Enemy 组件实例。
            Enemy enemy = target as Enemy;

            // 将 Enemy 的位置转换为 Tilemap 中的单元格位置。
            Vector3Int cellPos = tileMap.WorldToCell(enemy.transform.position);

            // 计算 Enemy 在 Tilemap 中的行和列索引。
            enemy.RowIndex = Mathf.Abs(min_y - cellPos.y);
            enemy.ColIndex = Mathf.Abs(min_x - cellPos.x);

            // 更新 Enemy 的位置，使其位于 Tilemap 单元格的中心。
            //enemy.transform.position = tileMap.CellToWorld(cellPos) + new Vector3(0.5f, 0.5f, -1);
            enemy.transform.position = tileMap.CellToWorld(cellPos) + new Vector3(0.5f, 0.5f, -1);
        }
    }
}
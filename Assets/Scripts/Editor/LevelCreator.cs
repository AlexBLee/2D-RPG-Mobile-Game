﻿using UnityEngine;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine.SceneManagement;
using UnityEditor.SceneManagement;
using System.Collections.Generic;

public class SceneCreator : EditorWindow 
{
    Sprite background;
    public string levelName;

    [SerializeField] List<Object> enemyList = new List<Object>();
    int numberOfEnemies;
    ReorderableList list;

    [MenuItem("Tools/Level Creator")]
    private static void ShowWindow() 
    {
        var window = GetWindow<SceneCreator>();
        window.titleContent = new GUIContent("SceneCreator");
        window.Show();
    }

    private void OnGUI() 
    {
        GUILayout.Label("Background", EditorStyles.boldLabel);
        GUILayout.Label("A background size of 1280x720 is recommended.");

        EditorGUILayout.Space();

        background = (Sprite)EditorGUILayout.ObjectField("Image", background, typeof(Sprite), true);
        
        EditorGUILayout.Space();

        numberOfEnemies = Mathf.Max(0, EditorGUILayout.DelayedIntField("Number of enemies:", numberOfEnemies));

        while (numberOfEnemies < enemyList.Count)
        {
            enemyList.RemoveAt( enemyList.Count - 1 );
        }
        while (numberOfEnemies > enemyList.Count)
        {
            enemyList.Add(null);
        }
        
        for(int i = 0; i < enemyList.Count; i++)
        {
            enemyList[i] = (Enemy)EditorGUILayout.ObjectField(enemyList[i], typeof(Enemy), true);
        }

        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();
        EditorGUILayout.Space();


        levelName = EditorGUILayout.TextField("Level Name: ", levelName);

        EditorGUILayout.Space();


        if(GUILayout.Button("Make Level!"))
        {
            if(levelName == null)
            {
                Debug.LogError("Please name the level.");
            }
            else
            {
                string localPath = "Assets/Scenes/" + levelName + ".unity";
                localPath = AssetDatabase.GenerateUniqueAssetPath(localPath);

                AssetDatabase.CopyAsset("Assets/Scenes/Level1.unity", localPath);
                Scene scene = EditorSceneManager.OpenScene(localPath);

                GameObject bg = GameObject.Find("BG1");
                bg.GetComponent<SpriteRenderer>().sprite = background;

                BattleManager bm = GameObject.FindObjectOfType<BattleManager>();
                bm.spawnableEnemies = new List<GameObject>(numberOfEnemies);


                EditorSceneManager.MarkSceneDirty(scene);


                
            }
            
        }
    }
}
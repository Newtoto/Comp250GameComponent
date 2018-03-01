using UnityEditor;
using UnityEngine;

namespace GUIFunctionality
{
    [CustomEditor(typeof(StarOptions))]
    public class StarOptionsGUI : Editor
    {

        private const int STAROPTIONS = 0;
        private const int STAROBJECTS = 1;

        public override void OnInspectorGUI()
        {
            serializedObject.Update();
            StarOptions starOptions = target as StarOptions;

            //EditorGUILayout.BeginVertical();

            GUIContent[] optionTabs = new GUIContent[2];
            optionTabs[0] = new GUIContent("Level Specific");
            optionTabs[1] = new GUIContent("Star Objects");
            starOptions.optionTabsInt = GUILayout.Toolbar(starOptions.optionTabsInt, optionTabs);
            EditorGUILayout.Separator();

            switch (starOptions.optionTabsInt)
            {
                case STAROPTIONS:

                    EditorGUILayout.Separator();

                    EditorGUILayout.LabelField("Choices to be made!");

                    EditorGUILayout.Separator();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("Time Based");
                    starOptions.Time = EditorGUILayout.Toggle(starOptions.Time);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.PrefixLabel("Objective Based");
                    starOptions.Objectives = EditorGUILayout.Toggle(starOptions.Objectives);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.Separator();

                    if (starOptions.Time == true)
                    {


                        EditorGUILayout.BeginHorizontal();

                        EditorGUILayout.PrefixLabel("Time For 1 Star");
                        starOptions.oneStarTime = EditorGUILayout.FloatField(starOptions.oneStarTime);

                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();

                        EditorGUILayout.PrefixLabel("Time For 2 Star");
                        starOptions.twoStarTime = EditorGUILayout.FloatField(starOptions.twoStarTime);

                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();

                        EditorGUILayout.PrefixLabel("Time For 3 Star");
                        starOptions.threeStarTime = EditorGUILayout.FloatField(starOptions.threeStarTime);

                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.Separator();
                    }

                    if (starOptions.Objectives)
                    {

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("Object For 1 Star");
                        EditorGUILayout.ObjectField(starOptions.oneStarObj, typeof(GameObject), false);
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("Object For 2 Star");
                        EditorGUILayout.ObjectField(starOptions.twoStarObj, typeof(GameObject), false);
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.BeginHorizontal();
                        EditorGUILayout.PrefixLabel("Object For 3 Star");
                        EditorGUILayout.ObjectField(starOptions.threeStarObj, typeof(GameObject), false);
                        EditorGUILayout.EndHorizontal();

                        EditorGUILayout.Separator();

                    }


                    break;

                case STAROBJECTS:

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.ObjectField("Star 1", starOptions.oneStarObj, typeof(GameObject), true);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.ObjectField("Star 2", starOptions.twoStarObj, typeof(GameObject), true);
                    EditorGUILayout.EndHorizontal();

                    EditorGUILayout.BeginHorizontal();
                    EditorGUILayout.ObjectField("Star 3", starOptions.threeStarObj, typeof(GameObject), true);
                    EditorGUILayout.EndHorizontal();

                    break;
            }

            serializedObject.ApplyModifiedProperties();
            
        }
    }
}

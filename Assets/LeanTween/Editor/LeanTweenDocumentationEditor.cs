using UnityEngine;
using System.Collections;
using UnityEditor;

public class LeanTweenDocumentationEditor : Editor {

	[MenuItem ("Lean/LeanTween Documentation")]
	static void openDocumentation()
	{
		#if !UNITY_3_5 && !UNITY_4_0 && !UNITY_4_0_1 && !UNITY_4_1 && !UNITY_4_2 && !UNITY_4_3
		// Loops through all items in case the user has moved the default installation directory
		string[] guids = AssetDatabase.FindAssets ("LeanTween", null);
		string documentationPath = "";
		foreach (string guid in guids){
			string path = AssetDatabase.GUIDToAssetPath(guid);
			if(path.IndexOf("classes/LeanTween.html")>=0){
				documentationPath = path;
				break;
			}
		}
		documentationPath = documentationPath.Substring(documentationPath.IndexOf("/"));
		string browserPath = "file://" + Application.dataPath + documentationPath + "#index";
		Application.OpenURL(browserPath);

		#else
		// assumes the default installation directory
		string documentationPath = "file://"+Application.dataPath + "/LeanTween/Documentation/classes/LeanTween.html#index";
		Application.OpenURL(documentationPath);

		#endif
	}

	[MenuItem ("Lean/LeanTween Forum (ask questions)")]
	static void openForum()
	{
		Application.OpenURL("http://forum.unity3d.com/threads/leantween-a-tweening-engine-that-is-up-to-5x-faster-than-competing-engines.161113/");
	}

	[MenuItem ("Lean/LeanTween GitHub (contribute code)")]
	static void openGit()
	{
		Application.OpenURL("https://github.com/dentedpixel/LeanTween");
	}

	[MenuItem ("Lean/Dented Pixel News")]
	static void openDPNews()
	{
		Application.OpenURL("http://dentedpixel.com/category/developer-diary/");
	}
}
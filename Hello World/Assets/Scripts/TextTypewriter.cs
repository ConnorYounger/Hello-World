using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextTypewriter : MonoBehaviour
{
	private TMP_Text txt;
	private string story;

	private void Start()
	{
		Time.timeScale = 1;
		
		// TODO: add optional delay when to start
		StartCoroutine("PlayText");
	}

	void Awake()
	{
		txt = GetComponent<TMP_Text>();
		story = txt.text;
		txt.text = "";
	}

	IEnumerator PlayText()
	{
		foreach (char c in story)
		{
			txt.text += c;
			yield return new WaitForSeconds(0.05f);
		}
	}
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Use this to create dialogue in the asset menu. Right click -> Create -> Dialogue
 * 
 */

[CreateAssetMenu]
public class Dialogue : ScriptableObject {
	public List<string> Speech = new List<string>();
	public GameState StateOfGameAfterDialogue;
}

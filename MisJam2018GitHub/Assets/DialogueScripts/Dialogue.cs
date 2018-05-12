using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Dialogue : ScriptableObject {
	public List<string> Speech = new List<string>();
	public GameState StateOfGameAfterDialogue;
}

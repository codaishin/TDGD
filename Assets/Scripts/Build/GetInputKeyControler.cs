using UnityEngine;

public abstract class GetKeyControler : MonoBehaviour
{
	public abstract bool GetKeyDown(in KeyCode keyCode);
	public abstract bool GetKey(in KeyCode keyCode);
	public abstract bool GetKeyUp(in KeyCode keyCode);
}

public class GetInputKeyControler : GetKeyControler
{
	public override
	bool GetKeyDown(in KeyCode keyCode) => Input.GetKeyDown(keyCode);

	public override
	bool GetKey(in KeyCode keyCode) => Input.GetKey(keyCode);

	public override
	bool GetKeyUp(in KeyCode keyCode) => Input.GetKeyUp(keyCode);
}

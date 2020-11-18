using UnityEngine;

public abstract class GetKeyControler : MonoBehaviour
{
	public enum Option { Down = default, Hold, Up }

	private delegate bool GetFunc(in KeyCode keyCode);


	private readonly GetFunc[] keyFuncs;

	public abstract bool GetKeyDown(in KeyCode keyCode);
	public abstract bool GetKeyHold(in KeyCode keyCode);
	public abstract bool GetKeyUp(in KeyCode keyCode);

	public bool GetKey(in GetKeyControler.Option option, in KeyCode keyCode)
	{
		return this.keyFuncs[(int)option](keyCode);
	}

	public GetKeyControler() : base()
	{
		this.keyFuncs = new GetFunc[] {
			this.GetKeyDown,
			this.GetKeyHold,
			this.GetKeyUp,
		};
	}
}

public class GetInputKeyControler : GetKeyControler
{
	public override
	bool GetKeyDown(in KeyCode keyCode) => Input.GetKeyDown(keyCode);

	public override
	bool GetKeyHold(in KeyCode keyCode) => Input.GetKey(keyCode);

	public override
	bool GetKeyUp(in KeyCode keyCode) => Input.GetKeyUp(keyCode);
}

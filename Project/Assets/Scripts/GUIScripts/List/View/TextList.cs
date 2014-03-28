using UnityEngine;
using System.Collections;
using System.Text;
public class TextList : MonoBehaviour {

	private ListModedl<string> model;
	private TextMesh textField;
	void Start () {
		textField = GetComponent<TextMesh> ();
		SetModel (model);
		model.OnListChange += ListChange;
	}
	

	void Update () {
	
	}

	public void ListChange(object sender, ListChangeEventArgs args){
		RefreshList ();
	}

	public void SetModel(ListModedl<string> model){
		this.model = model;
		RefreshList ();
	}

	private void RefreshList(){
		StringBuilder builder = new StringBuilder ();
		foreach (string line in model) {
			builder.Append(line);
			builder.Append("\n");
		}
		textField.text = builder.ToString ();

	}
}

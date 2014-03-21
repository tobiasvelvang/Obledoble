using UnityEngine;
using System.Collections;
using System.Text;
public class TextList : MonoBehaviour {

	private ListModedl<string> model;
	private TextMesh textField;
	void Start () {
		init ();
	}
	public void init(){

		textField = GetComponent<TextMesh> ();
		SetModel (new ListModedl<string>());
		model.OnListChange += ListChange;

	}
	
	public void ListChange(object sender, ListChangeEventArgs args){
		RefreshList ();
	}

	public void SetModel(ListModedl<string> model){
		this.model = model;
		RefreshList ();
	}

	public ListModedl<string> GetModel(){
		return this.model;
	}

	private void RefreshList(){
		textField.text = "";
		if (model == null) return;
		StringBuilder builder = new StringBuilder ();
		foreach (string line in model) {
			builder.Append(line);
			builder.Append("\n");

		}
		textField.text = builder.ToString ();

	}
}

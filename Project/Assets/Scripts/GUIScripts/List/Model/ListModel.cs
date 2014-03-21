using UnityEngine;
using System.Collections.Generic;
using System;
using System.Collections;
public class ListChangeEventArgs: EventArgs{
	public int index;
}
public delegate void OnListChangeEvent(object sender, ListChangeEventArgs args);
public class ListModedl<T>: IEnumerable<T>, IEnumerable{

	public OnListChangeEvent OnListChange;
	List<T> items;
	public ListModedl(){
		items = new List<T> ();

	}
	public void add(T item){

		items.Add (item);
		if (OnListChange != null)
			OnListChange (this, new ListChangeEventArgs (){ index = items.Count -1 });
	}

	public void get(T item, int index){
		items[index] = item;
		if (OnListChange != null)
			OnListChange (this, new ListChangeEventArgs (){ index = index });
	}

	public IEnumerator<T> GetEnumerator(){
		return items.GetEnumerator ();
	}

	System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
	{
		return items.GetEnumerator();
	}

}

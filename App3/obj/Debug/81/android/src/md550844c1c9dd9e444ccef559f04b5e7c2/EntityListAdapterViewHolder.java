package md550844c1c9dd9e444ccef559f04b5e7c2;


public class EntityListAdapterViewHolder
	extends android.support.v7.widget.RecyclerView.ViewHolder
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App3.Resources.EntityListAdapterViewHolder, App3", EntityListAdapterViewHolder.class, __md_methods);
	}


	public EntityListAdapterViewHolder (android.view.View p0)
	{
		super (p0);
		if (getClass () == EntityListAdapterViewHolder.class)
			mono.android.TypeManager.Activate ("App3.Resources.EntityListAdapterViewHolder, App3", "Android.Views.View, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}

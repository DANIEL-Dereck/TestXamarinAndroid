package md56b537a863e73a163728b485bb6fa50db;


public class EntityItemDecorator
	extends android.support.v7.widget.RecyclerView.ItemDecoration
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("App3.EntityItemDecorator, App3", EntityItemDecorator.class, __md_methods);
	}


	public EntityItemDecorator ()
	{
		super ();
		if (getClass () == EntityItemDecorator.class)
			mono.android.TypeManager.Activate ("App3.EntityItemDecorator, App3", "", this, new java.lang.Object[] {  });
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

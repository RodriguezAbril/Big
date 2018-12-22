package md5a3639a17e5693fd14d8daa2ce6223be2;


public class FilePrintDocumentAdapter
	extends android.print.PrintDocumentAdapter
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onLayout:(Landroid/print/PrintAttributes;Landroid/print/PrintAttributes;Landroid/os/CancellationSignal;Landroid/print/PrintDocumentAdapter$LayoutResultCallback;Landroid/os/Bundle;)V:GetOnLayout_Landroid_print_PrintAttributes_Landroid_print_PrintAttributes_Landroid_os_CancellationSignal_Landroid_print_PrintDocumentAdapter_LayoutResultCallback_Landroid_os_Bundle_Handler\n" +
			"n_onWrite:([Landroid/print/PageRange;Landroid/os/ParcelFileDescriptor;Landroid/os/CancellationSignal;Landroid/print/PrintDocumentAdapter$WriteResultCallback;)V:GetOnWrite_arrayLandroid_print_PageRange_Landroid_os_ParcelFileDescriptor_Landroid_os_CancellationSignal_Landroid_print_PrintDocumentAdapter_WriteResultCallback_Handler\n" +
			"";
		mono.android.Runtime.register ("BIG.Mobile.Droid.FilePrintDocumentAdapter, BIG.Mobile.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", FilePrintDocumentAdapter.class, __md_methods);
	}


	public FilePrintDocumentAdapter ()
	{
		super ();
		if (getClass () == FilePrintDocumentAdapter.class)
			mono.android.TypeManager.Activate ("BIG.Mobile.Droid.FilePrintDocumentAdapter, BIG.Mobile.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	public FilePrintDocumentAdapter (java.lang.String p0, java.lang.String p1)
	{
		super ();
		if (getClass () == FilePrintDocumentAdapter.class)
			mono.android.TypeManager.Activate ("BIG.Mobile.Droid.FilePrintDocumentAdapter, BIG.Mobile.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e:System.String, mscorlib, Version=2.0.5.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e", this, new java.lang.Object[] { p0, p1 });
	}


	public void onLayout (android.print.PrintAttributes p0, android.print.PrintAttributes p1, android.os.CancellationSignal p2, android.print.PrintDocumentAdapter.LayoutResultCallback p3, android.os.Bundle p4)
	{
		n_onLayout (p0, p1, p2, p3, p4);
	}

	private native void n_onLayout (android.print.PrintAttributes p0, android.print.PrintAttributes p1, android.os.CancellationSignal p2, android.print.PrintDocumentAdapter.LayoutResultCallback p3, android.os.Bundle p4);


	public void onWrite (android.print.PageRange[] p0, android.os.ParcelFileDescriptor p1, android.os.CancellationSignal p2, android.print.PrintDocumentAdapter.WriteResultCallback p3)
	{
		n_onWrite (p0, p1, p2, p3);
	}

	private native void n_onWrite (android.print.PageRange[] p0, android.os.ParcelFileDescriptor p1, android.os.CancellationSignal p2, android.print.PrintDocumentAdapter.WriteResultCallback p3);

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

package md5a3639a17e5693fd14d8daa2ce6223be2;


public class PdfViewRenderer_PdfWebChromeClient
	extends android.webkit.WebChromeClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onJsAlert:(Landroid/webkit/WebView;Ljava/lang/String;Ljava/lang/String;Landroid/webkit/JsResult;)Z:GetOnJsAlert_Landroid_webkit_WebView_Ljava_lang_String_Ljava_lang_String_Landroid_webkit_JsResult_Handler\n" +
			"";
		mono.android.Runtime.register ("BIG.Mobile.Droid.PdfViewRenderer+PdfWebChromeClient, BIG.Mobile.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", PdfViewRenderer_PdfWebChromeClient.class, __md_methods);
	}


	public PdfViewRenderer_PdfWebChromeClient ()
	{
		super ();
		if (getClass () == PdfViewRenderer_PdfWebChromeClient.class)
			mono.android.TypeManager.Activate ("BIG.Mobile.Droid.PdfViewRenderer+PdfWebChromeClient, BIG.Mobile.Android, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public boolean onJsAlert (android.webkit.WebView p0, java.lang.String p1, java.lang.String p2, android.webkit.JsResult p3)
	{
		return n_onJsAlert (p0, p1, p2, p3);
	}

	private native boolean n_onJsAlert (android.webkit.WebView p0, java.lang.String p1, java.lang.String p2, android.webkit.JsResult p3);

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

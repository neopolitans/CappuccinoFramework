----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	[CAPPUCCINO EDITOR FRAMEWORK > EXTENSIONS INFORMATION]
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Cappuccino has many different classes, scripts and folders within the Core folder.
To prevent any accidental errors or corruptions, if you want to customize your copy of Cappuccino, the Extensions folder is provided for you.

It's best to store your custom extension for Cappuccino inside it's own folder in Extensions. 

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	Rules of Thumb:

	1. New Extensions to Cappuccino should be 100% compatible with Unity's GUI, GUILayout, EditorGUI and EditorGUILayout classes.
	   (Esepecially useful in case a method breaks in the extension.)

	2. Try avoid using class and namespace names similar to Unity Engine classes and Namespace. Alternatives are:

		- Cappuccino.Extensions.<extensionName>					| Default expected namespace.
		- Cappuccino.Extensions.Experimental.<extensionName>	| If your extension(s) are experimental and you wish to separate them from regular extensions.
		- Cappuccino.Core.<extensionName>						| If you're looking to retool or extend the core framework.
		- Cappuccino.Experimental.<extensionName>				| Used internally for plugin features that aren't finalized but still available.

	3. Provide clear, concise documentation for your extensions using comments or, preferably, XML Comments.
		- You do not need to provide comments for internal-only classes, though it will help your understanding.
		- You can find examples of XML Docummentation in any of CappuccinoFramework's scripts.

	4. Clearly structure your Extension for legibility, accessibility and extensibiltiy. Especially useful for your own sake.
		- Although minute, it's helpful to know where you could find specific method types.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	Notes:

	- Extensions can be placed within the Cappucino, Cappuccino.Extensions and Cappuccino.Core namespaces. It's not recommneded for the latter as to not mix up built-in
	  classes and methods with your own implementations. If you wish to extend Cappuccino.Core, make sure to provide XML Documentation for the
	  methods and clearly highlight them as your own for your (and end-users') sake.
	  
	- You can edit the Cappuccino and Cappuccino.Core namespaces. Any non-static class is inheritable, however be careful to if you're overriding
	  certain classes. An example being Cappuccino.Core.CEditor - a partial class spread accross multiple scripts for ease of editing & dissecting.
	  Editing CEditor may cause any of your extensions and editor windows to be non-functional if you do not provide custom implementations for any
	  of the methods you're using in your editor windows.

	- Some classes like CAssetLoader are already optional and if you wish to extend these, you can. Though in some cases you may find it
	  more optimal to create your own extension or asset loader.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	Notice about Extensions:
		Some folders within [CappuccinoFramework > Core > Utilities] are given the name "Extensions", this is not to be confused with [CappuccinoFramework > Extensions].
		If you see a folder labelled <...>Extensions, these are almost certainly additional methods for classes like CEditor and CProperty which separate extremely
		long (and monotonous) code to provide shorthands or Quality-of-Life properties & methods. It's advised not to remove them or modify them unless you are fully aware
		of what each extension does, how it affects your (and others') extensions and what you'll be missing from your local copy of Cappuccino if you remove them.

		Example case: CEditorTitleContent
			CEditorTitleContent abstracts the EditorWindow.titleContent property and provides two methods to dynamically change the window titlebar. These methods are:
				CEditor.Rename(string)
				CEditor.Icon(Texture2D)

		Additionally, some folders suffixed with "Extensions" provide extra methods specifically to provide alternative code structuring. One example of this being
		[CappuccinoFramework > Core > InterfaceToolkit > HandlesExtensions] which wraps around pr simplifies elements of UnityEditor's Handles namespace. These folders are
		also not necessary to the core function of CappuccinoFramework, however modifying them does still require knowledge of both the framework and Unity Engine's
		original equivalents.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	
	DISCLAIMER 
		[NOTICE: This is not a legally binding disclaimer. It is included as general guidelines for the sample release of Cappuccino Editor Framework.]

		The Author(s) of Cappuccino Editor Framework provide the features as-is with no guarantee that the framework is production-ready at any given time. Features and
		additional Extensions included by the Author(s) are subject to change and/or removal at any time with no guarantee on stability. Cappuccino Editor Framework is
		exclusviely dependent on Unity Engine, Unity Editor and associated properties under ownership of Unity Technologies. Cappuccino Editor Framework makes extensive 
		use of multiple underlying properties, as well as read-only referencing of the publicly available source code of Unity Engine.

		Some Stylization options provided in Cappuccino Editor Framework are provided under the SIL Open Font License (Fira Mono by Carrois Apostrophe) and are non-profit
		extensions based on the visual design of ROBLOX Studio (Dark Theme by ROBLOX Corporation). The Author(s) do not intend to claim reponsibility, ownership or express 
		rights to the use or depiction of the afformentioned elements.

		The author(s) are not responsible for any damage incurred as a result of personalization of Cappuccino and cannot be held liable for any modifications therein,
		malicious or otherwise. It is the express understanding that modifications and the results therein are the express result, and liability, of the individual(s)
		responsible for the distribution created.

		Any sources distributing the source code for monetary gain are working without the express approval of the author(s).
		
		Designed for Unity Engine 2021.3.6f1 - Backwards and Forwards Compatibility may vary. Some features may not work as intended for versions previously and currently
		available. 
		
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

See Also:
	https://docs.unity3d.com/ScriptReference/
	https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/
	
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
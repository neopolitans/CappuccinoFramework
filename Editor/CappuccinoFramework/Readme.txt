----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	[CAPPUCCINO EDITOR FRAMEWORK]
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	Cappuccino Editor Framework is a set of tools for users who wish to start making their own custom Editor Windows without having to write out extensives blocks of
	code for things as simple as dividers, headers and foldouts. The toolkits provided combine the methods within the GUI, EditorGUI, GUILayout and EditorGUILayout
	classes so drawing parts of the editor is as quick and as easy to modify as possible. This Framework also aims to be fully interoperable with the default behaviours 
	of Unity's GUI Drawing methods. Extensive testing is actively ongoing to catch any incompatibility and missing features from the core toolkit.

	Cappuccino contains extensive documentation for as many of the methods (and overrides) as possible. Clear definitions, alternatives and notices are provided where
	applicable for the benefit of the developer and anyone looking to modify the internal workings of Cappuccino's classes. Everything inside can be overriden, Nothing is 
	off-limits. The full framework can be blended and brewed to your liking.

	Some of the tools included:

		CEditor
			- Abstracted elements of UnityEditor.EditorWindow.
			- Simplified Renaming & Icon Changing.
			- Default Panel Suppport.

		CProperty 
			- Genericized means of accessing the underlying value of a SerializedProperty, with Safe counterparts for error handling.
			- Support for backwards navigation to it's parent and owner independently of each other*.

		Cappuccino.Core.UI
			- Combined methods for drawing frequently used UI Elements**.

		CAssetLoader^
			- Simplified Asset Loader type for an Editor Window, with some common methods for loading assets^^.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	INSTALLING CAPPUCCINO EDITOR FRAMEWORK
		Unity Editor Windows are expected to be stored in a folder within the Assets folder of a project called "Editor" as to prevent scripts therein from being compiled
		with the main build(s) of a game. Cappuccino Editor Framework also must be installed with a folder clearly labelled "Editor". The contents should be within:

		[/.../ProjectName/Assets/Editor/]

		You'll know you've done it right if when you open the framework folder, the directory bar for your File Explorer reads:

		[/.../ProjectName/Assets/Editor/CappuccinoFramework/]

	USING A CUSTOM FOLDER LOCATION:
		If you use a custom folder for your installation of Cappuccino Editor Framework, you need to change "defaultDirectory" on Line 21 in the following script:

		[/.../ProjectName/Assets/.../CappuccinoFramework/Core/Utilities/CDefaults.cs]

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	REPORTING ISSUES AND REQUESTING FEATURES

		If you notice any missing documentation, erroneous inclusions or bugs within the included work(s), please send a message to Azrael#6166 (B512325) through
		the [UCLeeds - Games] Discord Server (not Direct Messages). 
		
		Errors and incorrect documentation are the priority as the current iteration of Cappuccino Editor Framework is the coresample constructed in 1~ Week. Attempts to 
		parse through and catch errors have been numerous but it is still possible that these slip through the cracks. No design is perfect first time around.

		Any features you wish to request which have been overlooked by Cappuccino Editor Framework may be sent, however the time it may take to add the feature individuals
		are looking to take advantage of immediately may not be as quick as fixing errors and documentation. At the time of writing, additional features not core to the
		intended design and approach of Cappuccino Editor Framework will not be considered immediately. (Still won't mind if you ask though :))

		Remember too, you have access to a framework with documentation and detailed descriptions as well as a Game Engine with a (mostly) well documented
		website full of Scripting API information (including a Manual). You can still add in features yourself if you feel the immediate need for them.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	FOOTNOTES

		Some methods which are used in plugins may require custom implementations of methods from types and classes which are overridden. Failure to provide replacement 
		methods for those overridden may result in errors, crashes and missing features that are otherwise expected by users in your personalized flavor of Cappuccino.

		* Restricted to some variations of the included methods, documentation provided.

		** Although the best of care is taken to transfer commonly used methods into Cappuccino.Core.UI, some may be absent at time of writing.
		   Some methods have their own unique classes instead to avoid confusion. (E.G. CHeader is a separate class from UI to contain several, separate header types.)

		^ Still in development. Not all asset types are supported.

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

		This variation of Cappuccino Editor Framework is provided to Leeds City College, Leeds Universtiy Centre and Luminate Education Group as part of ongoing 
		independent studies into extending Game Engines. The current work(s) enclosed (Cappuccino Editor Framework) is not ready for publication, instead being provided
		(or otherwise made available) to select individuals with the intention to catch issues, trial concepts and produce a working example as a practical demonstration 
		of the studies undertaken by the author(s). Documentation for the work(s) enclosed is still an ongoing process, with digital booklets and guides in the works 
		following the initial sample release to select individuals. 

		It is the hope of the author(s) that the development and design of the enclosed work(s) can reach a stable grounds with applied principles for intuitive and
		reliable results, at least within the specific build(s) the plugin has been designed for. The DISCLAIMER above is provided as a general guideline for later overview
		and publication for future written work(s). 

		It is advised not to use this on coursework actively being used unless you are able to verify with a certainty that the contents within Cappuccino Editor Framework
		does not cause any disruption or damage to your work(s). Practice and experiment safely on non-production and non-course work(s) (or otherwise duplicates of the
		former) for the safest results.

			- B512325 
		Alexander Gilbertson

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
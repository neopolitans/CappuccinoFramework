----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	[CAPPUCCINO EDITOR FRAMEWORK -> Example Plugins]
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	As to aid with the dissection and understanding of Cappuccino Editor Framework during the early stages of development, some sample plugins are provided inside an
	accompanying folder (/.../CappuccinoFramework/ExamplePlugins). These plugins may not be fully compatible with everything Unity Engine has to offer and are provided
	as-is, with the understanding that developers who wish to further optimize and expand on them may do so at their own leisure. Every care has been made to document 
	and provide plugins with as few errors as possible, though some may remain.

	With this build of Cappuccino Editor Framework, the following Plugins are included:

		>------------------------------------------------------------------------------------------------------------------------------------------------------------------<
									ROProperty : A proof-of-concept port of ROBLOX Studio's Properties panel to Unity Engine - Dark Theme Only.
		>------------------------------------------------------------------------------------------------------------------------------------------------------------------<

			- Includes Custom Style - Studio Dark : A set of Unique GUIStyles based on ROBLOX Studio's Palette. (Colour Accuracy may vary.)
			  Location: /.../CappuccinoFramework/Core/CustomStyles/StudioDark/

			- Includes two extra fonts: Fira Mono (Default) & Source Sans Pro.
			  Location: /.../CappuccinoFramework/Core/Fonts/.../

			[X] Designed for 3840x2160 resolutions, Spaces in between elements may not display correctly on some display sizes though the best care has been taken.
			[X] This is an incomplete proof-of-concept meant to demonstrate the ability to use interoperable manual-layout and auto-layout plugins.
			[?] This proof-of-concept is known to have issues. This plugin does not currently support list-foldouts drawn 
				by UnityEngine from PropertyFields / CProperty.Draw()

		>------------------------------------------------------------------------------------------------------------------------------------------------------------------<

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	REPORTING ISSUES AND REQUESTING FEATURES

		If you notice any missing documentation, erroneous inclusions or bugs within the included work(s), please send a message to Azrael#6166 (B512325) through
		the [UCLeeds - Games] Discord Server (not Direct Messages). 
		
		Errors and incorrect documentation are the priority as the current iteration of Cappuccino Editor Framework is the coresample constructed in 1~ Week. Attempts to 
		parse through and catch errors have been numerous but it is still possible that these slip through the cracks. No design is perfect first time around.

		Any features you wish to request which have been overlooked by Cappuccino Editor Framework may be sent, however the time it may take to add the feature individuals
		are looking to take advantage of immediately may not be as quick as fixing errors and documentation. At the time of writing, additional features not core to the
		intended design and approach of Cappuccino Editor Framework will not be considered immediately. Plugins are examples of what can be done, like documentation, and 
		are not priority with the exception of errors in the example plugins.

		Remember too, you have access to a framework with documentation and detailed descriptions as well as a Game Engine with a (mostly) well documented
		website full of Scripting API information (including a Manual). You can still add in features yourself if you feel the immediate need for them.

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

	DISCLAIMER 
		[NOTICE: This is not a legally binding disclaimer. It is included as general guidelines for the sample release of Cappuccino Editor Framework.]

		The Author(s) of Cappuccino Editor Framework provide the features as-is with no guarantee that the framework is production-ready at any given time. Features and
		additional Extensions included by the Author(s) are subject to change and/or removal at any time with no guarantee on stability. Cappuccino Editor Framework is
		exclusviely dependent on Unity Engine, Unity Editor and associated properties under ownership of Unity Technologies. Cappuccino Editor Framework makes extensive 
		use of multiple underlying properties, as well as read-only referencing of the publicly available source code of Unity Engine.

		Some Stylization options provided in Cappuccino Editor Framework are provided under the SIL Open Font License (Fira Mono by Carrois Apostrophe) and are non-profit
		extensions based on the visual design of ROBLOX Studio (Dark Theme by ROBLOX Corporation). The Author(s) do not intend to claim reponsibility, ownership or express 
		rights to th euse or depiction of the afformentioned elements.

		The author(s) are not responsible for any damage incurred as a result of personalization of Cappuccino and cannot be held liable for any modifications therein,
		malicious or otherwise. It is the express understanding that modifications and the results therein are the express result, and liability, of the individual(s)
		responsible for the distribution created.

		Any sources distributing the source code for monetary gain are working without the express approval of the author(s).
		
		Designed for Unity Engine 2021.3.6f1 - Backwards and Forwards Compatibility may vary. Some features may not work as intended for versions previously and currently
		available. 
		
-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
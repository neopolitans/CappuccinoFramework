----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
	[CAPPUCCINO EDITOR FRAMEWORK > EXTENSIONS > TEMPLATE SCRIPTS INFORMATION]
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

Cappuccino provides several template scripts for you to duplicate and use as a basis to create your own extensions of built-in methods. These scripts contain nothing but 
the namespaces and the class setup basics for you to build outwards with and should not be placed within the [CappuccinoFramework > Core] folder. For your sake, you're best 
off providing your own extensions in a sub-folder of [CappuccinoFramework > Extensions] so that you can delineate between methods that you've added to the framework from 
methods that came pre-packaged. 

Additionally, it's best to add your own XML commentation for each method (if your installed IDE's C# Compiler is compatible with C# XML Documentation Comments). If you're
wondering how Cappuccino achieves the documentation highlighting of it's own name in the language-word highlight - it's done through the use of the following prefixed
before the message you're going to display:

	[ ]<see langword="Cappuccino:"/> ]

[!] This is by no means recommended for any IDE other than Visual Studio Community (2019/2022)

----------------------------------------------------------------------------------------------------------------------------------------------------------------------------

See Also:
	https://docs.unity3d.com/ScriptReference/
	https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc/
	
----------------------------------------------------------------------------------------------------------------------------------------------------------------------------
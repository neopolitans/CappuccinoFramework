#  Cappuccino Framework
Cappuccino Framework is an in-development Engine Utility for Unity that abstracts, extends and simplifies various elements of the Plugin & Toolkit development process. Cappuccino is focused on building up from the foundations created by Unity Technologies, incorporating multiple additional features through modularity.

This framework is designed to allow for developers and programmers to take what they need, personalizing their flavour of Cappuccino to their needs.

## Current Features

#### Immediate-Mode GUI Support
-  **CEditor** - An expansion of EditorWindow containing various additional properties and methods to assist with creating editor windows.

- **Cappuccino.Core.UI** - A class dedicated to providing simplified, combined and additional UI Customization methods on top of UnityEditor's **GUI** and **EditorGUI** classes.

#### Extensions of SerializedObject & SerializedProperty
- **CObject** - Extension of SerializedObject, containing simplified naming to quickly draw children of C# objects without manual unpacking and additional tools for Hierarchical Navigation.

- **CProperty** - Extension of SerializedProperty, containing simplified naming to quickly draw properties as well as additional extras for List/Array access, various means of value access - i.e. CProperty.Bool, CProperty.GetValue(out Type value) or CProperty.value (requires casting from Object)

## In-Development
#### Visual Scripting 
With the rising trends of game development and more people actively adopting tools such as Unreal Engine's BLUEPRINTS and Unity Engine's BOLT, Cappuccino is committed to creating it's own tools based on these through the use of Unity's GraphView API. A proof of concept exists in this build with dynamically-resolving nodes for previewing. Next steps for this system are:

- Saving and Loading Visual Scripts for Plugins
- More nodes that work for Unity's IMGUI and UIToolkit as well as Cappuccino's UI & Graph scripts. These will allow developers to utilise the systems they are most comfortable with and interchange the two at will.
- Additional optimizations for lowering processing overhead between Editor & Graph updates. 
- Conversion Tools to other Engines (Long-Term)

#### UI Toolkit
Unity Technologies' most recent suite of tools for various applications, UI Toolkit, is a prominent and newly introduced way to construct  intuitive and user-friendly UI through the use of web-development languages alongside C# *or* through their visual UI Builder. Cappuccino aims to provide additional behaviours that make incorporating or rebuilding in UI-Toolkit more accessible for developers and programmers used to the Immediate Mode GUI workflow.

#### Cappuccino GitHub Wiki
This framework is full of many bell, whistles and quality-of-life features for developers. Almost everything in Cappuccino has written documentation to work with Visual Studio IntelliSense (and compatible IDEs) in XML for C# with fairly clear descriptions. All existing information needs to be incorporated into dedicated Wiki pages for the repository so that developers and programmers can easily access and understand all the included features.

## In-Research
#### C++ Integration
C# is a higher level language with performance costs that are less desireable compared to C++ integration. One of the biggest pieces of feedback received so far has been to incorporate C++ for improving and optimizing Cappuccino Framework for a variety of systems. The cost of this is that any custom libraries created for the framework must be compiled in both x86 and x64 architectures separately, costing more research and development.

Challenges currently exist with this framework. Using C++ in a way that interacts with Unity Engine without sacrificing performance due to the cross-language boundary requires further research before it can be decisively put back into the development pool.

## Engine Support

Not every version of Unity Engine is compatible, though Cappuccino aims to make use of features exclusviely available since 2019 in order to ensure longetivity and compatibility. Choices have been made to ensure as much compatibility as possible, such as utilizng the long-standing **GraphView** API (present since 2019) over the more recently engine-integrated **GraphToolsFoundation** API.

Cappuccino has been designed in **Unity Engine 2021.3** and all features are known to work in this version.

#### Complete Compatibility:

- Unity Engine 2022 - Additional features for USS Object Model were added for Unity Engine 2022 mistakenly in 2021 and exist expressly to work with this verion and above.

- Unity Engine 2021

#### Known Compatibility
- Unity Engine 2020 

- Unity Engine 2019 *(Visual Scripting Unverified)*

#### Unverified Compatibility
- Unity Engine 2023 

- Unity Engine 2018 *(IMGUI ONLY)*

- Unity Engine 2017 *(IMGUI ONLY)*

# maui-ios-navigation-broken-by-di
This project shows that shell navigation is broken on iOS when using DI, but works for Android.

The reason this is a problem is that some pages in a real world application will require DI in their constructors to carry out thewir purpose.

It seems there is an issue with adding/removing the pages from the navigation stack when building/deploying to iOS only.


## Broken Navigation Reproduction Steps:

*GIVEN* I am building for iOS simulator or physical device, and within `MauiProgram.cs` ensure that the DI for the pages, ln 24-26, IS NOT commented out.

*WHEN* The app loads

*THEN* I click the buttons to go to Page 2, Page 3 and then Main Page the navigation works,
I then go to Page 2, Then Page 3 and back to Page 2, Page 2 will not load, I then go to Main Page, Page 2 and Page 3 buttons work again. The exception us swallowed because of async/await.


## Broken Navigation Reproduction Steps, exception thrown:

*GIVEN* I am building for iOS simulator or physical device, and within `MauiProgram.cs` ensure that the DI for the pages, ln 24-26, IS NOT commented out. and I change `_Clicked` methods to async/await.

*WHEN* The app loads

*THEN* I click the buttons to go to Page 2, Page 3 and then Main Page the navigation works, I then go to Page 2, Then Page 3 and back to Page 2, the below exception will be thrown within `UIApplication.Main(args, null, typeof(AppDelegate));`

```
Objective-C exception thrown.
Name: NSInvalidArgumentException Reason: <Microsoft_Maui_Controls_Platform_Compatibility_ShellSectionRenderer: 0x7fdb03348000>
is pushing the same view controller instance (<Microsoft_Maui_Platform_PageViewController: 0x7fdb02fef5c0>)
more than once which is not supported and is most likely an error in the application : com.companyname.navigationcrashtest
```


## Working Navigation Reproduction Steps:

*GIVEN* I am building for iOS or Android simulator or physical device, and within `MauiProgram.cs` ensure that the DI for the pages, ln 24-26, IS commented out

*WHEN* The app loads

*THEN* I click the buttons to go to Page 2, Page 3 and then Main Page the navigation works, and pressing any futher buttons the will navigate to the requiered pages.




## Full Exception with stack
Microsoft access for the full exception with trace, enjoy!

```
Objective-C exception thrown.  Name: NSInvalidArgumentException Reason: <Microsoft_Maui_Controls_Platform_Compatibility_ShellSectionRenderer: 0x7fa17f5bfe00> is pushing the same view controller instance (<Microsoft_Maui_Platform_PageViewController: 0x7fa17c3d40e0>) more than once which is not supported and is most likely an error in the application : com.companyname.navigationcrashtest
Native stack trace:
	0   CoreFoundation                      0x000000010c5748cb __exceptionPreprocess + 242
	1   libobjc.A.dylib                     0x000000011c9f5ba3 objc_exception_throw + 48
	2   UIKitCore                           0x0000000128229273 -[UINavigationController pushViewController:transition:forceImmediate:] + 3898
	3   UIKitCore                           0x00000001282281a8 -[UINavigationController pushViewController:animated:] + 669
	4   libxamarin-dotnet-debug.dylib       0x000000010994149c xamarin_dyn_objc_msgSendSuper + 220
	5   ???                                 0x0000000151f76ca7 0x0 + 5670136999
	6   libmonosgen-2.0.dylib               0x000000010a10844a ves_pinvoke_method + 474
	7   libmonosgen-2.0.dylib               0x000000010a0fb2a9 interp_exec_method + 3737
	8   libmonosgen-2.0.dylib               0x000000010a0f8a53 interp_runtime_invoke + 259
	9   libmonosgen-2.0.dylib               0x0000000109f1f4cd mono_runtime_try_invoke + 157
	10  libmonosgen-2.0.dylib               0x0000000109f2165f mono_runtime_invoke + 95
	11  NavigationCrashTest                 0x0000000100911b48 _ZL30native_to_managed_trampoline_9P11objc_objectP13objc_selectorPP11_MonoMethodj + 280
	12  NavigationCrashTest                 0x0000000100957f09 -[UIKit_UIControlEventProxy BridgeSelector] + 41
	13  UIKitCore                           0x0000000128bf5d05 -[UIApplication sendAction:to:from:forEvent:] + 95
	14  UIKitCore                           0x0000000128357c74 -[UIControl sendAction:to:forEvent:] + 110
	15  UIKitCore                           0x0000000128358078 -[UIControl _sendActionsForEvents:withEvent:] + 345
	16  UIKitCore                           0x0000000128354203 -[UIButton _sendActionsForEvents:withEvent:] + 148
	17  UIKitCore                           0x00000001283568cf -[UIControl touchesEnded:withEvent:] + 485
	18  UIKitCore                           0x0000000128c3ae95 -[UIWindow _sendTouchesForEvent:] + 1292
	19  UIKitCore                           0x0000000128c3cef1 -[UIWindow sendEvent:] + 5304
	20  UIKitCore                           0x0000000128c107f2 -[UIApplication sendEvent:] + 898
	21  UIKit                               0x0000000166b3aa90 -[UIApplicationAccessibility sendEvent:] + 85
	22  UIKitCore                           0x0000000128cb7e61 __dispatchPreprocessedEventFromEventQueue + 9381
	23  UIKitCore                           0x0000000128cba569 __processEventQueue + 8334
	24  UIKitCore                           0x0000000128cb08a1 __eventFetcherSourceCallback + 272
	25  CoreFoundation                      0x000000010c4d4035 __CFRUNLOOP_IS_CALLING_OUT_TO_A_SOURCE0_PERFORM_FUNCTION__ + 17
	26  CoreFoundation                      0x000000010c4d3f74 __CFRunLoopDoSource0 + 157
	27  CoreFoundation                      0x000000010c4d3771 __CFRunLoopDoSources0 + 212
	28  CoreFoundation                      0x000000010c4cde73 __CFRunLoopRun + 927
	29  CoreFoundation                      0x000000010c4cd6f7 CFRunLoopRunSpecific + 560
	30  GraphicsServices                    0x0000000120f3a28a GSEventRunModal + 139
	31  UIKitCore                           0x0000000128bef62b -[UIApplication _run] + 994
	32  UIKitCore                           0x0000000128bf4547 UIApplicationMain + 123
	33  libxamarin-dotnet-debug.dylib       0x00000001098fba5a xamarin_UIApplicationMain + 58
	34  libmonosgen-2.0.dylib               0x000000010a109619 do_icall + 345
	35  libmonosgen-2.0.dylib               0x000000010a108123 do_icall_wrapper + 291
	36  libmonosgen-2.0.dylib               0x000000010a0fb180 interp_exec_method + 3440
	37  libmonosgen-2.0.dylib               0x000000010a0f8a53 interp_runtime_invoke + 259
	38  libmonosgen-2.0.dylib               0x0000000109f1da18 mono_runtime_invoke_checked + 136
	39  libmonosgen-2.0.dylib               0x0000000109f25a2c do_exec_main_checked + 92
	40  libmonosgen-2.0.dylib               0x000000010a054a82 mono_jit_exec + 354
	41  libxamarin-dotnet-debug.dylib       0x000000010993fe77 xamarin_main + 1927
	42  NavigationCrashTest                 0x00000001009a50b4 main + 68
	43  dyld                                0x00000001095192bf start_sim + 10
	44  ???                                 0x0000000200ee3310 0x0 + 8605545232
```
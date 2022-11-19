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
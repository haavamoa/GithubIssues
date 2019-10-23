### Description

When updating from `4.2.0.848062` to `4.3.0.908675` I noticed a null pointer when working with a `<ScrollView>` that contains a `<Grid>` with two custom views.

In our production app, the custom views are:
    1. A filter that should filter a list
    2. The list
These two should be wrapped with a `<ScrollView>` so the user can scroll the whole page when the list is too long.

#### The problem

The filter should invoke a command when the user press some buttons in it's view. But the problem is that it should also invoke the command initially (at app startup) with a preset filter. The way we have achieved this is to `override OnMeasure`, check a boolean value to see if we are initializing, and invoking the command.

The view-model that recieves this command execution, is simply adding items to a `ObservableCollection` that the custom view that displays the list is bound to.

The list component is a `<StackLayout>` that is using the `BindableLayout` style of creating a list. When the items gets notifiied, the `<ScrollView>` throws an exception.

#### The solution

To get passed the null pointer, I will have to re-architect my solution. This is something that I have been thinking about for a while, even before this bug, so that is most likely what I will be doing.
The obvious solution would be to not do the filtering from a call from the filter component, but to do it from the `OnStart` method in the view model and setting the filter to a initial value without it calling anything.

### Steps to Reproduce

1. Clone my Git repository
2. Change `Xamarin.Forms` version to `4.2.0.848062`
3. Start the app
4. It will throw a null pointer, check device log to see the exception.

### Expected Behavior

That my scrollable page will display with a list of items that is set from a command that is invoked from `OnMeasure` of the filter custom view.

### Actual Behavior

Null pointer exception:

```
Time	Device Name	Type	PID	Tag	Message
10-23 07:23:33.106	pixel	Info	26019	MonoDroid	System.NullReferenceException: Object reference not set to an instance of an object.
  at Xamarin.Forms.Grid.CalculateAutoCells (System.Double width, System.Double height) [0x00195] in D:\a\1\s\Xamarin.Forms.Core\GridCalc.cs:113 
  at Xamarin.Forms.Grid.MeasureGrid (System.Double width, System.Double height, System.Boolean requestSize) [0x0000c] in D:\a\1\s\Xamarin.Forms.Core\GridCalc.cs:485 
  at Xamarin.Forms.Grid.OnSizeRequest (System.Double widthConstraint, System.Double heightConstraint) [0x0002a] in D:\a\1\s\Xamarin.Forms.Core\GridCalc.cs:60 
  at Xamarin.Forms.VisualElement.OnMeasure (System.Double widthConstraint, System.Double heightConstraint) [0x00000] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:762 
  at Xamarin.Forms.VisualElement.GetSizeRequest (System.Double widthConstraint, System.Double heightConstraint) [0x00053] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:644 
  at Xamarin.Forms.Layout.GetSizeRequest (System.Double widthConstraint, System.Double heightConstraint) [0x00000] in D:\a\1\s\Xamarin.Forms.Core\Layout.cs:132 
  at Xamarin.Forms.VisualElement.Measure (System.Double widthConstraint, System.Double heightConstraint, Xamarin.Forms.MeasureFlags flags) [0x00054] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:702 
  at Xamarin.Forms.ScrollView.LayoutChildren (System.Double x, System.Double y, System.Double width, System.Double height) [0x000dd] in D:\a\1\s\Xamarin.Forms.Core\ScrollView.cs:230 
  at Xamarin.Forms.Layout.UpdateChildrenLayout () [0x00158] in D:\a\1\s\Xamarin.Forms.Core\Layout.cs:266 
  at Xamarin.Forms.Layout.OnSizeAllocated (System.Double width, System.Double height) [0x0000f] in D:\a\1\s\Xamarin.Forms.Core\Layout.cs:224 
  at Xamarin.Forms.VisualElement.SizeAllocated (System.Double width, System.Double height) [0x00000] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:784 
  at Xamarin.Forms.VisualElement.SetSize (System.Double width, System.Double height) [0x00021] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:1023 
  at Xamarin.Forms.VisualElement.set_Bounds (Xamarin.Forms.Rectangle value) [0x0005d] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:307 
  at Xamarin.Forms.VisualElement.Layout (Xamarin.Forms.Rectangle bounds) [0x00000] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:686 
  at Xamarin.Forms.Layout.LayoutChildIntoBoundingRegion (Xamarin.Forms.VisualElement child, Xamarin.Forms.Rectangle region) [0x001da] in D:\a\1\s\Xamarin.Forms.Core\Layout.cs:178 
  at Xamarin.Forms.Page.LayoutChildren (System.Double x, System.Double y, System.Double width, System.Double height) [0x0010d] in D:\a\1\s\Xamarin.Forms.Core\Page.cs:234 
  at Xamarin.Forms.Page.UpdateChildrenLayout () [0x000c9] in D:\a\1\s\Xamarin.Forms.Core\Page.cs:310 
  at Xamarin.Forms.Page.OnSizeAllocated (System.Double width, System.Double height) [0x0000f] in D:\a\1\s\Xamarin.Forms.Core\Page.cs:290 
  at Xamarin.Forms.VisualElement.SizeAllocated (System.Double width, System.Double height) [0x00000] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:784 
  at Xamarin.Forms.VisualElement.SetSize (System.Double width, System.Double height) [0x00021] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:1023 
  at Xamarin.Forms.VisualElement.set_Bounds (Xamarin.Forms.Rectangle value) [0x0005d] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:307 
  at Xamarin.Forms.VisualElement.Layout (Xamarin.Forms.Rectangle bounds) [0x00000] in D:\a\1\s\Xamarin.Forms.Core\VisualElement.cs:686 
  at Xamarin.Forms.Platform.Android.AppCompat.Platform.LayoutRootPage (Xamarin.Forms.Page page, System.Int32 width, System.Int32 height) [0x00000] in D:\a\1\s\Xamarin.Forms.Platform.Android\AppCompat\Platform.cs:384 
  at Xamarin.Forms.Platform.Android.AppCompat.Platform.Xamarin.Forms.Platform.Android.IPlatformLayout.OnLayout (System.Boolean changed, System.Int32 l, System.Int32 t, System.Int32 r, System.Int32 b) [0x0000c] in D:\a\1\s\Xamarin.Forms.Platform.Android\AppCompat\Platform.cs:229 
  at Xamarin.Forms.Platform.Android.PlatformRenderer.OnLayout (System.Boolean changed, System.Int32 l, System.Int32 t, System.Int32 r, System.Int32 b) [0x0001b] in D:\a\1\s\Xamarin.Forms.Platform.Android\PlatformRenderer.cs:75 
  at Android.Views.ViewGroup.n_OnLayout_ZIIII (System.IntPtr jnienv, System.IntPtr native__this, System.Boolean changed, System.Int32 l, System.Int32 t, System.Int32 r, System.Int32 b) [0x00009] in <11a340ccc8de43f09c97400139266ef5>:0 
  at (wrapper dynamic-method) Android.Runtime.DynamicMethodNameCounter.28(intptr,intptr,bool,int,int,int,int)

```

### Basic Information

- Version with issue: 4.3.0.908675
- Last known good version: 4.2.0.848062
- IDE: Visual Studio 2019
- Platform Target Frameworks: <!-- All that apply -->
  - Android: 7.1
- Android Support Library Version: No
- Nuget Packages: Xamarin.Forms & Xamarin.Essentials
- Affected Devices: Tested on pixel

### Reproduction Link

<!-- Please upload or provide a link to a reproduction case -->

using Xamarin.Forms;

namespace FrameCornerRadius.Behaviours
{
    /// <summary>
    /// A rounded frame behaviour, this will set the corner radius to the correct values if the frame has set its `HeightRequest`
    /// Android : Corner radius should be the same as the height
    /// iOS : Corner radius should be 58.33% of the height
    /// </summary>
    internal class RoundedFrameBehaviour : Behavior<Frame>
    {
        protected override void OnAttachedTo(BindableObject bindable)
        {
            base.OnAttachedTo(bindable);

            if (!(bindable is Frame frame))
                return;

            frame.CornerRadius = Device.RuntimePlatform switch
                {
                Device.Android => (float)(frame.HeightRequest * 1),
                Device.iOS => (float)(frame.HeightRequest * 0.5833),
                _ => 0
                };
        }
    }
}
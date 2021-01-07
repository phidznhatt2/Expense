using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Expense.Views;
using ExpenseManagement.Droid;

[assembly: ExportRenderer(typeof(CustomPicker), typeof(CustomPickerRerender))]
namespace ExpenseManagement.Droid {
#pragma warning disable CS0618 // Type or member is obsolete
    public class CustomPickerRerender : PickerRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e) {
            base.OnElementChanged(e);
            if (Control != null) {
                GradientDrawable gd = new GradientDrawable();
                gd.SetStroke(0, Android.Graphics.Color.Transparent);
                Control.SetBackground(gd);
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Android.Graphics.Drawables;
using Expense.Views;
using Expense.Droid;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRerender))]
namespace Expense.Droid {
#pragma warning disable CS0618 // Type or member is obsolete
    public class CustomEntryRerender : EntryRenderer {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);

            if (e.OldElement == null) {
                Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                //var gradientDrawable = new GradientDrawable();
                //gradientDrawable.SetCornerRadius(60f);
                //gradientDrawable.SetStroke(5, Android.Graphics.Color.DeepPink);
                //gradientDrawable.SetColor(Android.Graphics.Color.LightGray);
                //Control.SetBackground(gradientDrawable);

                //Control.SetPadding(50, Control.PaddingTop, Control.PaddingRight,
                //    Control.PaddingBottom);
            }
        }
    }
#pragma warning restore CS0618 // Type or member is obsolete
}
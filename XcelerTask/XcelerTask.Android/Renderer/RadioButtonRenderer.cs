using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XcelerTask.CustomControl.RadioButtonCustom;
using Xamarin.Forms;
using XcelerTask.Droid.Renderer;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomRadioButton), typeof(RadioButtonRenderer))]
namespace XcelerTask.Droid.Renderer
{
    public class RadioButtonRenderer : ViewRenderer<CustomRadioButton, RadioButton>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomRadioButton> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                e.OldElement.PropertyChanged += ElementOnPropertyChanged;
            }

            if (this.Control == null)
            {
                var radButton = new RadioButton(this.Context);
                //radButton.SetTextColor(Color.White.ToAndroid());

                radButton.CheckedChange += radButton_CheckedChange;
                //Added
                //GradientDrawable strokeDrawable = new GradientDrawable();
                //strokeDrawable.SetStroke(3, Color.White.ToAndroid());
                //strokeDrawable.SetCornerRadius(50);
                //strokeDrawable.SetColor(Color.White.ToAndroid());

                //radButton.SetBackground(strokeDrawable);

                this.SetNativeControl(radButton);
            }

            Control.Text = e.NewElement.Text;
            Control.Checked = e.NewElement.Checked;
            Control.SetTextColor(e.NewElement.TextColor.ToAndroid());
            Element.PropertyChanged += ElementOnPropertyChanged;
        }

        void radButton_CheckedChange(object sender, CompoundButton.CheckedChangeEventArgs e)
        {
            this.Element.Checked = e.IsChecked;
        }



        void ElementOnPropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "Checked":
                    Control.Checked = Element.Checked;
                    break;
                case "Text":
                    Control.Text = Element.Text;
                    break;

            }
        }
    }
}
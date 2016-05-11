// ***********************************************************************
// Assembly         : XLabs.Forms
// Author           : XLabs Team
// Created          : 12-27-2015
// 
// Last Modified By : XLabs Team
// Last Modified On : 01-04-2016
// ***********************************************************************
// <copyright file="CheckBox.cs" company="XLabs Team">
//     Copyright (c) XLabs Team. All rights reserved.
// </copyright>
// <summary>
//       This project is licensed under the Apache 2.0 license
//       https://github.com/XLabs/Xamarin-Forms-Labs/blob/master/LICENSE
//       
//       XLabs is a open source project that aims to provide a powerfull and cross 
//       platform set of controls tailored to work with Xamarin Forms.
// </summary>
// ***********************************************************************
// 

using System;
using System.Collections;
using Core.Controls;
using Xamarin.Forms;

namespace XLabs.Forms.Controls
{
    /// <summary>
    /// The check box.
    /// </summary>
    public class CheckBox : View
    {
        public static readonly BindableProperty CheckedProperty = BindableProperty.Create(
                                                                       defaultBindingMode: BindingMode.TwoWay,
                                                                       propertyName: "Checked",
                                                                       returnType: typeof(bool),
                                                                       declaringType: typeof(CheckBox),
                                                                       propertyChanged: OnCheckedPropertyChanged,
                                                                       defaultValue: false);

        public static readonly BindableProperty CheckedTextProperty = BindableProperty.Create(
                                                                           defaultBindingMode: BindingMode.TwoWay,
                                                                           propertyName: "CheckedText",
                                                                           returnType: typeof(string),
                                                                           declaringType: typeof(CheckBox),
                                                                           defaultValue: string.Empty);


        public static readonly BindableProperty UncheckedTextProperty = BindableProperty.Create(
                                                                          defaultBindingMode: BindingMode.TwoWay,
                                                                          propertyName: "UncheckedText",
                                                                          returnType: typeof(string),
                                                                          declaringType: typeof(CheckBox),
                                                                          defaultValue: string.Empty);



        public static readonly BindableProperty DefaultTextProperty = BindableProperty.Create(
                                                                          defaultBindingMode: BindingMode.TwoWay,
                                                                          propertyName: "Text",
                                                                          returnType: typeof(string),
                                                                          declaringType: typeof(CheckBox),
                                                                          defaultValue: string.Empty);

        public static readonly BindableProperty TextColorProperty = BindableProperty.Create(
                                                                  defaultBindingMode: BindingMode.TwoWay,
                                                                  propertyName: "TextColor",
                                                                  returnType: typeof(Color),
                                                                  declaringType: typeof(CheckBox),
                                                                  defaultValue: Color.Default);

        public static readonly BindableProperty FontSizeProperty = BindableProperty.Create(
                                                                 defaultBindingMode: BindingMode.TwoWay,
                                                                 propertyName: "FontSize",
                                                                 returnType: typeof(double),
                                                                 declaringType: typeof(CheckBox),
                                                                 defaultValue: -1d);

        public static readonly BindableProperty FontNameProperty = BindableProperty.Create(
                                                                          defaultBindingMode: BindingMode.TwoWay,
                                                                          propertyName: "FontName",
                                                                          returnType: typeof(string),
                                                                          declaringType: typeof(CheckBox),
                                                                          defaultValue: string.Empty);

        /// <summary>
        /// The checked changed event.
        /// </summary>
        public event EventHandler<EventArgs<bool>> CheckedChanged;

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        public bool Checked
        {
            get
            {
                return (bool)GetValue(CheckedProperty);
            }

            set
            {
                if (this.Checked != value)
                {
                    this.SetValue(CheckedProperty, value);
                    //this.CheckedChanged.Invoke(this, new EventArgs<bool>(value));
                }
            }
        }

        /// <summary>
        /// Gets or sets a value indicating the checked text.
        /// </summary>
        /// <value>The checked state.</value>
        /// <remarks>
        /// Overwrites the default text property if set when checkbox is checked.
        /// </remarks>
        public string CheckedText
        {
            get
            {
                return (string)GetValue(CheckedTextProperty);
            }

            set
            {
                this.SetValue(CheckedTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the control is checked.
        /// </summary>
        /// <value>The checked state.</value>
        /// <remarks>
        /// Overwrites the default text property if set when checkbox is checked.
        /// </remarks>
        public string UncheckedText
        {
            get
            {
                return (string)GetValue(UncheckedTextProperty);
            }

            set
            {
                this.SetValue(UncheckedTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the text.
        /// </summary>
        public string DefaultText
        {
            get
            {
                return (string)GetValue(DefaultTextProperty);
            }

            set
            {
                this.SetValue(DefaultTextProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the color of the text.
        /// </summary>
        /// <value>The color of the text.</value>
        public Color TextColor
        {
            get
            {
                return (Color)GetValue(TextColorProperty);
            }

            set
            {
                this.SetValue(TextColorProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the size of the font.
        /// </summary>
        /// <value>The size of the font.</value>
        public double FontSize
        {
            get
            {
                return (double)GetValue(FontSizeProperty);
            }
            set
            {
                SetValue(FontSizeProperty, value);
            }
        }

        /// <summary>
        /// Gets or sets the name of the font.
        /// </summary>
        /// <value>The name of the font.</value>
        public string FontName
        {
            get
            {
                return (string)GetValue(FontNameProperty);
            }
            set
            {
                SetValue(FontNameProperty, value);
            }
        }
        /// <summary>
        /// Gets the text.
        /// </summary>
        /// <value>The text.</value>
        public string Text
        {
            get
            {
                return this.Checked
                    ? (string.IsNullOrEmpty(this.CheckedText) ? this.DefaultText : this.CheckedText)
                        : (string.IsNullOrEmpty(this.UncheckedText) ? this.DefaultText : this.UncheckedText);
            }
        }

        /// <summary>
        /// Called when [checked property changed].
        /// </summary>
        /// <param name="bindable">The bindable.</param>
        /// <param name="oldValue">if set to <c>true</c> [oldvalue].</param>
        /// <param name="newValue">if set to <c>true</c> [newvalue].</param>
        private static void OnCheckedPropertyChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var checkBox = (CheckBox)bindable;
            checkBox.Checked = (bool)newValue;
        }
    }
}

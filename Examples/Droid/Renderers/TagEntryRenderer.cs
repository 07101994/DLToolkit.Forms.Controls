﻿using System;
using Xamarin.Forms.Platform.Android;
using Android.Content;
using Android.Util;
using Android.Runtime;
using Xamarin.Forms;
using DLToolkit.Forms.Controls;
using Examples.Droid.Renderers;

[assembly: ExportRenderer (typeof (TagEntry), typeof (TagEntryRenderer))]
namespace Examples.Droid.Renderers
{
	public class TagEntryRenderer : EntryRenderer
	{
		public static void Init()
		{
			#pragma warning disable 0219
			var dummy = new Renderers.TagEntryRenderer();
			#pragma warning restore 0219
		}

		public TagEntryRenderer()
		{
		}

		public TagEntryRenderer(Context context) : base() 
		{
		}

		public TagEntryRenderer(Context context, IAttributeSet attrs) : base()
		{
		}

		public TagEntryRenderer(Context context, IAttributeSet attrs, int defStyle) : base()
		{
		}
		public TagEntryRenderer (IntPtr a, JniHandleOwnership b) : base ()
		{
		}
	}
}


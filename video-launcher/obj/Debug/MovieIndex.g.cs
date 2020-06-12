﻿#pragma checksum "..\..\MovieIndex.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "1AC111D092D4E3BCA99A411141F7903B63F4F301"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using FontAwesome5;
using FontAwesome5.Converters;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;
using video_launcher;


namespace video_launcher {
    
    
    /// <summary>
    /// MovieIndex
    /// </summary>
    public partial class MovieIndex : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector, System.Windows.Markup.IStyleConnector {
        
        
        #line 106 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btRefresh;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock tbRefresh;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander exFilters;
        
        #line default
        #line hidden
        
        
        #line 127 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox tbSearch;
        
        #line default
        #line hidden
        
        
        #line 128 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander exGenres;
        
        #line default
        #line hidden
        
        
        #line 137 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Expander exWatched;
        
        #line default
        #line hidden
        
        
        #line 139 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbAllWatched;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbUnwatched;
        
        #line default
        #line hidden
        
        
        #line 141 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbWatched;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\MovieIndex.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lvMovies;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/video-launcher;component/movieindex.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MovieIndex.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 95 "..\..\MovieIndex.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClickHome);
            
            #line default
            #line hidden
            return;
            case 2:
            this.btRefresh = ((System.Windows.Controls.Button)(target));
            
            #line 106 "..\..\MovieIndex.xaml"
            this.btRefresh.Click += new System.Windows.RoutedEventHandler(this.ClickRefresh);
            
            #line default
            #line hidden
            return;
            case 3:
            this.tbRefresh = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.exFilters = ((System.Windows.Controls.Expander)(target));
            return;
            case 5:
            this.tbSearch = ((System.Windows.Controls.TextBox)(target));
            
            #line 127 "..\..\MovieIndex.xaml"
            this.tbSearch.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.SearchTextChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.exGenres = ((System.Windows.Controls.Expander)(target));
            return;
            case 8:
            this.exWatched = ((System.Windows.Controls.Expander)(target));
            return;
            case 9:
            this.rbAllWatched = ((System.Windows.Controls.RadioButton)(target));
            
            #line 139 "..\..\MovieIndex.xaml"
            this.rbAllWatched.Click += new System.Windows.RoutedEventHandler(this.ClickWatchedRadio);
            
            #line default
            #line hidden
            return;
            case 10:
            this.rbUnwatched = ((System.Windows.Controls.RadioButton)(target));
            
            #line 140 "..\..\MovieIndex.xaml"
            this.rbUnwatched.Click += new System.Windows.RoutedEventHandler(this.ClickWatchedRadio);
            
            #line default
            #line hidden
            return;
            case 11:
            this.rbWatched = ((System.Windows.Controls.RadioButton)(target));
            
            #line 141 "..\..\MovieIndex.xaml"
            this.rbWatched.Click += new System.Windows.RoutedEventHandler(this.ClickWatchedRadio);
            
            #line default
            #line hidden
            return;
            case 12:
            
            #line 144 "..\..\MovieIndex.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ClickResetFilters);
            
            #line default
            #line hidden
            return;
            case 13:
            this.lvMovies = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        void System.Windows.Markup.IStyleConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 7:
            
            #line 132 "..\..\MovieIndex.xaml"
            ((System.Windows.Controls.CheckBox)(target)).Click += new System.Windows.RoutedEventHandler(this.ClickCheckBox);
            
            #line default
            #line hidden
            break;
            case 14:
            
            #line 168 "..\..\MovieIndex.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.ShowMovie);
            
            #line default
            #line hidden
            break;
            }
        }
    }
}


﻿#pragma checksum "..\..\..\Items\wndItems.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "611C8E757EAD54BA4B6277E82C69624DAAB7FE97BF509D477B9B6A2AF8974E37"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using GroupProject.Items;
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


namespace GroupProject.Items {
    
    
    /// <summary>
    /// wndItems
    /// </summary>
    public partial class wndItems : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 17 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid ItemListBox;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button AddItemBtn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button EditItemBtn;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button DeleteItemBtn;
        
        #line default
        #line hidden
        
        
        #line 39 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ItemCodeBox;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ItemDescriptionBox;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox ItemCostBox;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveItemBtn;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Items\wndItems.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BackBtn;
        
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
            System.Uri resourceLocater = new System.Uri("/GroupProject;component/items/wnditems.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Items\wndItems.xaml"
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
            this.ItemListBox = ((System.Windows.Controls.DataGrid)(target));
            
            #line 18 "..\..\..\Items\wndItems.xaml"
            this.ItemListBox.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.ItemListBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AddItemBtn = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\..\Items\wndItems.xaml"
            this.AddItemBtn.Click += new System.Windows.RoutedEventHandler(this.AddItemBtn_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.EditItemBtn = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\..\Items\wndItems.xaml"
            this.EditItemBtn.Click += new System.Windows.RoutedEventHandler(this.EditItemBtn_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.DeleteItemBtn = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Items\wndItems.xaml"
            this.DeleteItemBtn.Click += new System.Windows.RoutedEventHandler(this.DeleteItemBtn_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.ItemCodeBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.ItemDescriptionBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.ItemCostBox = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.SaveItemBtn = ((System.Windows.Controls.Button)(target));
            
            #line 49 "..\..\..\Items\wndItems.xaml"
            this.SaveItemBtn.Click += new System.Windows.RoutedEventHandler(this.SaveItemBtn_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.BackBtn = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Items\wndItems.xaml"
            this.BackBtn.Click += new System.Windows.RoutedEventHandler(this.BackBtn_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}


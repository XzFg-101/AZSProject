﻿#pragma checksum "..\..\MainMenu.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "CFBA5334EF0D855E6114607268C3D8322ED686984842391C617F7A36BB832DB3"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using AZSProject;
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


namespace AZSProject {
    
    
    /// <summary>
    /// MainMenu
    /// </summary>
    public partial class MainMenu : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 20 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock AzsStatusText;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock StatusText;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Support;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Fuel;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Service;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\MainMenu.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Out;
        
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
            System.Uri resourceLocater = new System.Uri("/AZSProject;component/mainmenu.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainMenu.xaml"
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
            this.AzsStatusText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.StatusText = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 3:
            this.Support = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\MainMenu.xaml"
            this.Support.Click += new System.Windows.RoutedEventHandler(this.ButtonSupport_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Fuel = ((System.Windows.Controls.Button)(target));
            
            #line 25 "..\..\MainMenu.xaml"
            this.Fuel.Click += new System.Windows.RoutedEventHandler(this.ButtonFuel_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Service = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\MainMenu.xaml"
            this.Service.Click += new System.Windows.RoutedEventHandler(this.ButtonService_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.Out = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\MainMenu.xaml"
            this.Out.Click += new System.Windows.RoutedEventHandler(this.ButtonClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

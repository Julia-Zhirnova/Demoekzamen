﻿#pragma checksum "..\..\..\Pages\ManagerPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "9A8FE22DAF5D43B9D9C3C7F7B4694D0BB766BDA247FA1D4124C6C55F79CE6E19"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using CPKiO.Pages;
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


namespace CPKiO.Pages {
    
    
    /// <summary>
    /// ManagerPage
    /// </summary>
    public partial class ManagerPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 28 "..\..\..\Pages\ManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnExit;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\Pages\ManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image UserPhoto;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\Pages\ManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock UserTB;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\Pages\ManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock RoleTB;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\Pages\ManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock TimeTB;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\Pages\ManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnPlaceAnOrder;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\Pages\ManagerPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button BtnAcceptProducts;
        
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
            System.Uri resourceLocater = new System.Uri("/CPKiO;component/pages/managerpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Pages\ManagerPage.xaml"
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
            this.BtnExit = ((System.Windows.Controls.Button)(target));
            
            #line 28 "..\..\..\Pages\ManagerPage.xaml"
            this.BtnExit.Click += new System.Windows.RoutedEventHandler(this.BtnExit_Click);
            
            #line default
            #line hidden
            return;
            case 2:
            this.UserPhoto = ((System.Windows.Controls.Image)(target));
            return;
            case 3:
            this.UserTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.RoleTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 5:
            this.TimeTB = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.BtnPlaceAnOrder = ((System.Windows.Controls.Button)(target));
            
            #line 51 "..\..\..\Pages\ManagerPage.xaml"
            this.BtnPlaceAnOrder.Click += new System.Windows.RoutedEventHandler(this.BtnPlaceAnOrder_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BtnAcceptProducts = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


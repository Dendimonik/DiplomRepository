﻿#pragma checksum "..\..\..\..\Views\Pages\MainPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A32661928EBCA88C59C70BEC8DB919BE2569602CFEA0939E6E237D9B2738BBFD"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

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
using TourfirmApp.Views.Pages;


namespace TourfirmApp.Views.Pages {
    
    
    /// <summary>
    /// MainPage
    /// </summary>
    public partial class MainPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 19 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label Идея;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid UnderMain;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox txtFind;
        
        #line default
        #line hidden
        
        
        #line 30 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbPaymentStatus;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cmbOrderStatus;
        
        #line default
        #line hidden
        
        
        #line 40 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEdit;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Views\Pages\MainPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgOrders;
        
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
            System.Uri resourceLocater = new System.Uri("/TourfirmApp;component/views/pages/mainpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Views\Pages\MainPage.xaml"
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
            this.Идея = ((System.Windows.Controls.Label)(target));
            return;
            case 2:
            this.UnderMain = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.txtFind = ((System.Windows.Controls.TextBox)(target));
            
            #line 29 "..\..\..\..\Views\Pages\MainPage.xaml"
            this.txtFind.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.txtFind_TextChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cmbPaymentStatus = ((System.Windows.Controls.ComboBox)(target));
            
            #line 30 "..\..\..\..\Views\Pages\MainPage.xaml"
            this.cmbPaymentStatus.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbPaymentStatus_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cmbOrderStatus = ((System.Windows.Controls.ComboBox)(target));
            
            #line 35 "..\..\..\..\Views\Pages\MainPage.xaml"
            this.cmbOrderStatus.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.cmbOrderStatus_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnEdit = ((System.Windows.Controls.Button)(target));
            
            #line 40 "..\..\..\..\Views\Pages\MainPage.xaml"
            this.btnEdit.Click += new System.Windows.RoutedEventHandler(this.btnEdit_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.dgOrders = ((System.Windows.Controls.DataGrid)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}


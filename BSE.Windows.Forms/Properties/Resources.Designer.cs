﻿//------------------------------------------------------------------------------
// <auto-generated>
//     此代码由工具生成。
//     运行时版本:4.0.30319.296
//
//     对此文件的更改可能会导致不正确的行为，并且如果
//     重新生成代码，这些更改将会丢失。
// </auto-generated>
//------------------------------------------------------------------------------

namespace BSE.Windows.Forms.Properties {
    using System;
    
    
    /// <summary>
    ///   一个强类型的资源类，用于查找本地化的字符串等。
    /// </summary>
    // 此类是由 StronglyTypedResourceBuilder
    // 类通过类似于 ResGen 或 Visual Studio 的工具自动生成的。
    // 若要添加或移除成员，请编辑 .ResX 文件，然后重新运行 ResGen
    // (以 /str 作为命令选项)，或重新生成 VS 项目。
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   返回此类使用的缓存的 ResourceManager 实例。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("BSE.Windows.Forms.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   使用此强类型资源类，为所有资源查找
        ///   重写当前线程的 CurrentUICulture 属性。
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        internal static System.Drawing.Bitmap ChevronDown {
            get {
                object obj = ResourceManager.GetObject("ChevronDown", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap ChevronLeft {
            get {
                object obj = ResourceManager.GetObject("ChevronLeft", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap ChevronRight {
            get {
                object obj = ResourceManager.GetObject("ChevronRight", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap ChevronUp {
            get {
                object obj = ResourceManager.GetObject("ChevronUp", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap closePanel {
            get {
                object obj = ResourceManager.GetObject("closePanel", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Collapse {
            get {
                object obj = ResourceManager.GetObject("Collapse", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Collapse_h {
            get {
                object obj = ResourceManager.GetObject("Collapse_h", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Expand {
            get {
                object obj = ResourceManager.GetObject("Expand", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        internal static System.Drawing.Bitmap Expand_h {
            get {
                object obj = ResourceManager.GetObject("Expand_h", resourceCulture);
                return ((System.Drawing.Bitmap)(obj));
            }
        }
        
        /// <summary>
        ///   查找类似 Parameter {0} can&apos;t be null 的本地化字符串。
        /// </summary>
        internal static string IDS_ArgumentException {
            get {
                return ResourceManager.GetString("IDS_ArgumentException", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Value of &apos;{0}&apos; is not valid for &apos;{1}&apos;. &apos;Value&apos; should be between &apos;{2}&apos; and &apos;{3}&apos;.
        ///Parameter name: {1} 的本地化字符串。
        /// </summary>
        internal static string IDS_InvalidBoundArgument {
            get {
                return ResourceManager.GetString("IDS_InvalidBoundArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Value of &apos;{0}&apos; is not valid for &apos;{1}&apos;. &apos;Maximum&apos; must be greater than or equal to 0.
        ///Parameter name: {1} 的本地化字符串。
        /// </summary>
        internal static string IDS_InvalidLowBoundArgument {
            get {
                return ResourceManager.GetString("IDS_InvalidLowBoundArgument", resourceCulture);
            }
        }
        
        /// <summary>
        ///   查找类似 Value of &apos;{0}&apos; is not valid for &apos;{1}&apos;. &apos;{1}&apos; must be greater than or equal to {2}.
        ///Parameter name: {1} 的本地化字符串。
        /// </summary>
        internal static string IDS_InvalidOperationExceptionInteger {
            get {
                return ResourceManager.GetString("IDS_InvalidOperationExceptionInteger", resourceCulture);
            }
        }
    }
}

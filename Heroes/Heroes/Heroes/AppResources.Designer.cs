﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Heroes {
    using System;
    using System.Reflection;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class AppResources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal AppResources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("Heroes.AppResources", typeof(AppResources).GetTypeInfo().Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
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
        
        /// <summary>
        ///   Looks up a localized string similar to Charisma.
        /// </summary>
        internal static string Charisma {
            get {
                return ResourceManager.GetString("Charisma", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Constitution.
        /// </summary>
        internal static string Constitution {
            get {
                return ResourceManager.GetString("Constitution", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Dexterity.
        /// </summary>
        internal static string Dexterity {
            get {
                return ResourceManager.GetString("Dexterity", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Intelligence.
        /// </summary>
        internal static string Intelligence {
            get {
                return ResourceManager.GetString("Intelligence", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Strength.
        /// </summary>
        internal static string Strength {
            get {
                return ResourceManager.GetString("Strength", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Wisdom.
        /// </summary>
        internal static string Wisdom {
            get {
                return ResourceManager.GetString("Wisdom", resourceCulture);
            }
        }
    }
}
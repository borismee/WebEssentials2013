﻿using System.ComponentModel;
using Microsoft.VisualStudio.Shell;

namespace MadsKristensen.EditorExtensions
{
    class JavaScriptOptions : DialogPage
    {
        public JavaScriptOptions()
        {
            Settings.Updated += delegate { LoadSettingsFromStorage(); };
        }

        public override void SaveSettingsToStorage()
        {
            Settings.SetValue(WESettings.Keys.EnableJsMinification, EnableJsMinification);
            Settings.SetValue(WESettings.Keys.JavaScriptEnableGzipping, EnableGzipping);
            Settings.SetValue(WESettings.Keys.GenerateJavaScriptSourceMaps, GenerateJavaScriptSourceMaps);
            Settings.SetValue(WESettings.Keys.JavaScriptCommentCompletion, JavaScriptCommentCompletion);

            Settings.Save();
        }

        public override void LoadSettingsFromStorage()
        {
            EnableJsMinification = WESettings.GetBoolean(WESettings.Keys.EnableJsMinification);
            EnableGzipping = WESettings.GetBoolean(WESettings.Keys.JavaScriptEnableGzipping);
            GenerateJavaScriptSourceMaps = WESettings.GetBoolean(WESettings.Keys.GenerateJavaScriptSourceMaps);
            JavaScriptCommentCompletion = WESettings.GetBoolean(WESettings.Keys.JavaScriptCommentCompletion);
        }

        [LocDisplayName("Minify JavaScript files on save")]
        [Description("When a .js file (foo.js) is saved and a minified version (foo.min.js) exist, the minified file will be updated. Right-click any .js file to generate .min.js file.")]
        [Category("JavaScript")]
        public bool EnableJsMinification { get; set; }

        [LocDisplayName("Gzip JavaScript files on save")]
        [Description("When a .js file (foo.js) is saved and a minified version (foo.min.js) exist, a gzipped file will be created.")]
        [Category("JavaScript")]
        public bool EnableGzipping { get; set; }

        [LocDisplayName("Generate source maps (.map)")]
        [Description("When minification is enabled, a source map file (*.min.js.map) will be generated.")]
        [Category("JavaScript")]
        public bool GenerateJavaScriptSourceMaps { get; set; }

        [LocDisplayName("Enable comment completion")]
        [Description("Auto-complete /* comment blocks and insert * on new lines.")]
        [Category("JavaScript")]
        public bool JavaScriptCommentCompletion { get; set; }
    }
}

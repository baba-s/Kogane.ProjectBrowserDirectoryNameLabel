using System.IO;
using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [InitializeOnLoad]
    internal static class ProjectBrowserDirectoryNameLabel
    {
        private static GUIStyle m_style;

        static ProjectBrowserDirectoryNameLabel()
        {
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        private static void OnGUI( string guid, Rect selectionRect )
        {
            if ( !ProjectBrowserDirectoryNameLabelSetting.instance.IsEnable ) return;

            if ( string.IsNullOrWhiteSpace( ProjectBrowserInternal.SearchFieldText ) ) return;

            var assetPath = AssetDatabase.GUIDToAssetPath( guid );

            if ( string.IsNullOrWhiteSpace( assetPath ) ) return;

            var filename   = Path.GetFileNameWithoutExtension( assetPath );
            var labelStyle = EditorStyles.label;
            var content    = new GUIContent( filename );
            var position   = selectionRect;

            position.x += labelStyle.CalcSize( content ).x + 24;

            m_style ??= new( labelStyle )
            {
                normal =
                {
                    textColor = new Color32( 144, 144, 144, 255 ),
                },
            };

            var directoryName = Path.GetDirectoryName( assetPath );

            EditorGUI.LabelField( position, directoryName, m_style );
        }
    }
}
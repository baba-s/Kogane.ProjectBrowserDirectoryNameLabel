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
            var setting = ProjectBrowserDirectoryNameLabelSetting.instance;

            if ( !setting.IsEnable ) return;

            if ( string.IsNullOrWhiteSpace( ProjectBrowserInternal.SearchFieldText ) ) return;

            var assetPath = AssetDatabase.GUIDToAssetPath( guid );

            if ( string.IsNullOrWhiteSpace( assetPath ) ) return;

            var filename = setting.IsConsiderExtension
                    ? Path.GetFileName( assetPath )
                    : Path.GetFileNameWithoutExtension( assetPath )
                ;

            var labelStyle = EditorStyles.label;
            var content    = new GUIContent( filename );
            var offset     = setting.Offset;
            var position   = selectionRect;

            position.x += labelStyle.CalcSize( content ).x + 24;
            position.x += offset.x;
            position.y += offset.y;

            m_style ??= new( labelStyle )
            {
                normal =
                {
                    textColor = setting.Color,
                },
            };

            var directoryName = Path.GetDirectoryName( assetPath );

            EditorGUI.LabelField( position, directoryName, m_style );
        }
    }
}
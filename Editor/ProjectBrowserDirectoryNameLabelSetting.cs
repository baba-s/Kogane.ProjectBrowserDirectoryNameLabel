using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/ProjectBrowserDirectoryNameLabelSetting.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class ProjectBrowserDirectoryNameLabelSetting : ScriptableSingleton<ProjectBrowserDirectoryNameLabelSetting>
    {
        [SerializeField] private bool       m_isEnable;
        [SerializeField] private bool       m_isConsiderExtension;
        [SerializeField] private Vector2Int m_offset;
        [SerializeField] private Color      m_color = new Color32( 144, 144, 144, 255 );

        public bool       IsEnable            => m_isEnable;
        public bool       IsConsiderExtension => m_isConsiderExtension;
        public Vector2Int Offset              => m_offset;
        public Color      Color               => m_color;

        public void Save()
        {
            Save( true );
        }
    }
}
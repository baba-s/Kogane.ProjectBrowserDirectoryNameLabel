using UnityEditor;
using UnityEngine;

namespace Kogane.Internal
{
    [FilePath( "UserSettings/Kogane/ProjectBrowserDirectoryNameLabel.asset", FilePathAttribute.Location.ProjectFolder )]
    internal sealed class ProjectBrowserDirectoryNameLabelSetting : ScriptableSingleton<ProjectBrowserDirectoryNameLabelSetting>
    {
        [SerializeField] private bool m_isEnable;

        public bool IsEnable => m_isEnable;

        public void Save()
        {
            Save( true );
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerHelper.Core.MapResetTool
{
    [Serializable]
    public class MapResetConfig
    {
        public string MapSaveFolder { get; set; } = Properties.Settings.Default.MapFolderPath;
        public string PathToZonesFile { get; set; } = null;
        public bool BypassPrivate { get; set; } = true;
        public bool BackupFiles { get; set; } = true;
        public ProgressBar ProgressBar { get; set; } = null;
        public Label CurrentFile { get; set; } = null;
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cosmos.System.FileSystem;
using Cosmos.System.FileSystem.VFS;

namespace shiboxos.Utils
{
    public class FS
    {
        public CosmosVFS fs = new CosmosVFS();
        public FS()
        {
            VFSManager.RegisterVFS(fs);
        }
    }
}

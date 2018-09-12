﻿using Emby.Server.Implementations.IO;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.System;
using Mono.Unix.Native;

namespace MediaBrowser.Server.Mono.Native
{
    public class MonoFileSystem : ManagedFileSystem
    {
        public MonoFileSystem(ILogger logger, IEnvironmentInfo environment, string defaultDirectory, string tempPath, bool enableSeperateFileAndDirectoryQueries)
            : base(logger, environment,defaultDirectory, tempPath, enableSeperateFileAndDirectoryQueries)
        {
        }

        public override void SetExecutable(string path)
        {
            // Linux: File permission to 666, and user's execute bit
            Logger.Info("Syscall.chmod {0} FilePermissions.DEFFILEMODE | FilePermissions.S_IRWXU | FilePermissions.S_IXGRP | FilePermissions.S_IXOTH", path);

            Syscall.chmod(path, FilePermissions.DEFFILEMODE | FilePermissions.S_IRWXU | FilePermissions.S_IXGRP | FilePermissions.S_IXOTH);
        }
    }
}

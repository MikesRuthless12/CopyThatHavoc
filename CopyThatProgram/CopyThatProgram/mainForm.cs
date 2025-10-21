using ClosedXML.Excel; // Enables working with Excel files without Microsoft Office installed.
using CopyThatProgram.Models;
using CustomControls;
using DocumentFormat.OpenXml.Drawing;
using DocumentFormat.OpenXml.EMMA;
using DocumentFormat.OpenXml.Vml;
using DocumentFormat.OpenXml.Wordprocessing;
using Microsoft.Win32;
using Newtonsoft.Json; // Provides a framework for serializing and deserializing JSON objects.
using SHDocVw; // Offers access to the Shell's Document View (e.g., Internet Explorer).
using Shell32;
using System.Collections.Concurrent; // Includes thread-safe collection classes for multi-threaded access.
using System.Collections.Specialized; // Provides specialized collections like NameValueCollection.
using System.ComponentModel; // Supports components, data binding, and licensing.
using System.Data; // Provides classes for managing data from various sources (e.g., DataTables).
using System.Diagnostics; // Allows interaction with system processes, event logs, and performance counters.
using System.DirectoryServices.ActiveDirectory;
using System.Globalization; // Provides culture-specific information like date and number formatting.
using System.IO.Compression;
using System.Linq; // Offers LINQ for querying data sources with a syntax similar to SQL.
using System.Media; // Enables playing system sounds.
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices; // Provides a collection of services for interacting with COM objects, native APIs, and other system components.
using System.Runtime.Versioning; // Contains attributes for specifying the target operating system version.
using System.Security; // Provides the underlying structure of the Common Language Runtime (CLR) security system.
using System.Security.Cryptography;
using System.Text; // Contains classes for character encodings (e.g., ASCII, UTF-8).
using System.Text.Json; // Provides functionality to serialize objects to and deserialize objects from JSON.
using System.Threading.Tasks.Dataflow; // Offers a library for creating dataflow pipelines, useful for asynchronous data processing.
using System.Xml; // Provides a framework for working with XML data.
using System.Xml.Linq; // Offers LINQ for XML, a convenient way to manipulate XML documents.
using Color = System.Drawing.Color;
using FastFileSystemEntry = CopyThatProgram.FastEnumerator.Entry; // Alias for a file system entry class, likely for performance.
using Label = System.Windows.Forms.Label; // Explicitly specifies the Label control from Windows Forms.
using String = System.String; // Explicitly specifies the String class.
using TextBox = System.Windows.Forms.TextBox; // Explicitly specifies the TextBox control from Windows Forms.
using Timer = System.Windows.Forms.Timer; // Explicitly specifies the Timer control from Windows Forms.
namespace CopyThatProgram
{
    public partial class mainForm : Form
    {
        // =====================
        // 🔢 Integers
        // =====================
        private int _walkCounter = 0; // Counts the number of directory walk operations performed.
        private int _processedFolders = 0; // Tracks the number of folders that have been processed.
        private int _totalFolders = 0; // Stores the total number of folders to be processed.
        private int _totalFileCount = 0; // Holds the total number of files in the source directory.
        private int _processedFiles = 0; // Counts the number of files that have been processed (copied, moved, or deleted).
        private int _totalFilesCopied = 0; // Total count of files successfully copied.
        private int _totalFilesMoved = 0; // Total count of files successfully moved.
        private int _totalFilesDeleted = 0; // Total count of files successfully deleted.
        private int _totalFilesSkipped = 0; // Total count of files skipped during an operation.
        private int _totalFilesFailed = 0; // Total count of files that failed to process.
        private int _multiThreadProcessedFiles = 0; // Count of files processed in a multi-threaded operation.
        private int _currentFileIndex = 0; // The index of the file currently being processed.
        private int _roundRobinTargetIndex = 0; // Used for distributing files among multiple target directories.
        private int _retryCount = 0; // The number of times a file operation has been retried.
        private int _filesProcessed = 0; // Another counter for files processed, likely for a different scope.
        private int _totalFilesToProcess = 0; // Stores the total number of files in the current job.
        private int _totalFoldersToProcess = 0; // Stores the total number of folders in the current job.
        private int scrollSpeed = 4; // Defines the speed of scrolling for UI elements.
        private int animationStep = 10; // Speed of animation (pixels per tick).
        private int targetHeight; // The height the form should reach during an animation.
        private int animationDirection; // +1 for expand, -1 for collapse.
        int progressPercentageFile = 0; // The percentage of progress for the current file.
        private int bufferSize; // The size of the buffer used for file operations (copying, etc.).
        private const int MAX_RETRIES = 3; // The maximum number of retries for a failed operation.                
        private int _currentIndex = 0; // An integer to track the current index in a list.
        private int _totalDirs;// An interger for the total directories.
        // =====================
        // 🧮 Longs
        // =====================
        private long filesLeft; // Number of files remaining to be processed.
        private long _totalBytesProcessed = 0; // The number of bytes that have been processed in the current operation.
        private long _lastProcessedBytesForSpeed = 0; // Used to calculate the transfer speed.
        private long _copiedBytes; // Total bytes copied.
        long totalBytesProcessed = 0; // Total bytes processed, likely for a specific operation.
        long totalBytesProcessed2 = 0; // A second total bytes processed variable, likely for a different scope.
        long bytesCopied = 0; // Total bytes copied in the current job.
        long totalBytes = 0; // Another total bytes counter.
        long totalFolderBytes = 0; // Total bytes of all files within a folder.
        long totalBytesProcessedFile = 0; // Total bytes processed for a single file.
        private long _lastSpeedBytes = 0; // Stores the last number of bytes processed for speed calculation.
        private long _totalBytesToProcess = 0; // Overall total bytes of the entire job.
        private long _currentAddSize; // The size of the file or folder currently being added.
        private long _filesToProcess; // Another counter for the number of files to process.
        long _grandTotalFileCount = 0; // The total number of files to process across all selected items.
        long _grandTotalBytesToProcess = 0; // The total size of all files in the job, in bytes.
        private long _startTick; // The system tick count at the start of an operation, used for timing.            
        long fileCount = 0;// A field to keep track of the file count.
        long totalBytesCopied = 0;// A field to keep track of the total bytes copied.
        // =====================
        // 💯 Doubles
        // =====================
        double totalPercentDouble = 0; // The overall progress percentage as a double.
        double pct = 0; // A temporary variable for storing a percentage value.
        double opacity = Properties.Settings.Default.Opacity; // The opacity setting for the form, loaded from user settings.

        // =====================
        // 📅 DateTimes
        // =====================
        private DateTime _lastSpeedTime = DateTime.MinValue; // The last time the speed was calculated.
        private DateTime _lastSpeedCalcTime = DateTime.MinValue; // The last time the speed was calculated, likely a different variable for a different scope.

        // =====================
        // 🔠 Strings
        // =====================
        private string _cachedCustomTargetPath = null; // Stores the path for a custom target directory.
        private String folderPath = ""; // Stores the path to a folder.
        string overwriteOption = ""; // Stores the user's selected overwrite option.
        string path = ""; // A general-purpose string for storing a file or folder path.
        string originalSourcePath = "Select Files/Directory"; // The default text for the source path label.
        string originalTargetPath = "Select Directory"; // The default text for the target path label.
        private string _currentAddFolder; // The path to the folder currently being added.
        private string _customDirectoryName; // The name for a user-created custom directory.
        string priority = Properties.Settings.Default.Priority; // The process priority setting loaded from user settings.
        string status = "";
        public static String globalMODE = "";
        string pathNow;// A string to hold the current path.
        private const string RUN_KEY = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";//A string for the registry entry input.
        private string APP_Name = "";//A string to hold the application's name to perform registry changes.
        // A private field to store the root path of the current scan.
        private string _currentSourceRootPath = "";//A string to hold the current source directories root directory.


        // =====================
        // ✅ Booleans - State Flags
        // =====================
        bool copied = false; // A flag to indicate if a copy operation is complete.
        private bool _isMultiThreaded = false; // A flag to indicate if the current operation is multi-threaded.
        bool alreadySet = false; // A general-purpose flag to check if a value has been set.
        private bool isAnimating = false; // A flag to indicate if a UI animation is in progress.
        private bool isRolledUp = false; // A flag to indicate if the form is in its "rolled up" state.
        private bool _isPaused = false; // A flag to indicate if the current operation is paused.
        private bool _isCanceled = false; // A flag to indicate if the operation has been cancelled.
        private bool cancelled = false; // Another flag for cancellation status.
        private bool isInitialized = false; // A flag to indicate if the form has been initialized.
        private volatile bool _finishCurrentFileAndQuit; // A flag to signal the operation to finish the current file and then quit.
        private bool _overwriteAll; // A flag for the "overwrite all" option.
        private bool _doNotOverwrite; // A flag for the "do not overwrite" option.
        private bool _overwriteIfNewer; // A flag for the "overwrite if newer" option.
        private bool _createCustomDirectory; // A flag for the "create custom directory" option.

        // ✅ Booleans - UI/Behavior Options
        private bool sortAscendingBytes = true; // Sorting preference for file size.
        private bool sortAscending = true; // Sorting preference for other columns.
        bool noDragDrop = false; // A flag to disable drag-and-drop functionality.
        private bool _keepDirectoryStructure; // A flag for the "keep directory structure" option.
        private bool _copyFilesOnly; // A flag for the "copy files only" option.
        private bool _keepEmptyFolders; // A flag for the "keep empty folders" option.
        private bool _keepOnlyFiles; // A flag for the "keep only files" option.
        private bool _elapsedTimerRunning = false; // A private boolean variable to track if the elapsed timer is running.
        private bool allowTabChanges = true;

        // ✅ Booleans - User Preferences (Settings)

        bool multiThread = Properties.Settings.Default.Multithreading; // Multi-threading preference from user settings.
        bool proVersion = Properties.Settings.Default.VersionPro; // Pro version status from user settings.
        bool updateAuto = Properties.Settings.Default.UpdateAuto; // Automatic update preference from user settings.
        bool updateManually = Properties.Settings.Default.UpdateManually; // Manual update preference from user settings.
        bool updateBeta = Properties.Settings.Default.UpdateBeta; // Beta update preference from user settings.
        bool onlyNames = Properties.Settings.Default.FileOnlyNames; // Flag to export/list only file names from user settings.
        bool fullPaths = Properties.Settings.Default.FileFullPaths; // Flag to export/list full paths from user settings.
        bool zipT = Properties.Settings.Default.ZipSeparately; // Zip files separately preference from user settings.
        bool zipS = Properties.Settings.Default.ZipTogether; // Zip files together preference from user settings.
        bool undermb = Properties.Settings.Default.CopyFilesUnder; // Preference to copy files under a certain size from user settings.
        bool overmb = Properties.Settings.Default.CopyFilesOver; // Preference to copy files over a certain size from user settings.
        bool emailFull = Properties.Settings.Default.EmailFullPaths; // Email full paths preference from user settings.
        bool emailDirNames = Properties.Settings.Default.EmailOnlyNames; // Email only directory names preference from user settings.
        bool restartProgram = Properties.Settings.Default.RestartOnError; // Restart program on error preference from user settings.
        bool closeProgram = Properties.Settings.Default.CloseOnError; // Close program on error preference from user settings.

        // =====================
        // ⏱ Stopwatches
        // =====================
        private Stopwatch _copyStopwatch = new Stopwatch(); // A stopwatch to measure the duration of a copy operation.
        private Stopwatch _stopwatch = new Stopwatch(); // A general-purpose stopwatch for timing.
        private Stopwatch _globalStopwatch = new Stopwatch(); // A stopwatch to time the entire operation.
        private Stopwatch _operationTimer = new Stopwatch(); // A stopwatch specifically for timing a file operation.

        // =====================
        // 🗂 Collections
        // =====================
        private readonly HashSet<int> _currentlyCopyingIndicesSingle = new(); // A set to track indices of files being copied in a single-threaded operation.
        private readonly HashSet<int> _currentlyCopyingIndices = new(); // A set to track indices of files being copied in a multi-threaded operation.
        private readonly ConcurrentDictionary<string, int> _fileRetryCounter = new(); // A thread-safe dictionary to count retries for each file.
        private ConcurrentDictionary<int, FileProgressInfo> _currentOperations = new ConcurrentDictionary<int, FileProgressInfo>(); // A thread-safe dictionary to store progress info for concurrent operations.
        private List<string> targetPaths = new List<string>(); // A list of target directories.
        private List<string> _sourceDirectories = new List<string>(); // A list of source directories to process.
        private List<string> _targetDirectories = new List<string>(); // A list of target directories.
        private List<string> _currentTargetPaths = new List<string>(); // A list of the currently selected target paths.
        private List<BackgroundWorker> _workers = new List<BackgroundWorker>(); // A list of background workers for multi-threading.
        private BindingList<FileInfoWrapper> _fileList = new BindingList<FileInfoWrapper>(); // A data-bindable list to hold file information for the UI.
        private readonly SortableBindingList<FileInfoWrapper> _exportList = new SortableBindingList<FileInfoWrapper>(); // A data-bindable, sortable list for files to be exported.
        private BindingList<SkippedFileInfo> _skippedFilesList = new BindingList<SkippedFileInfo>(); // A data-bindable list for skipped files.
        private Task[] _multiThreadTasks = new Task[4]; // An array of tasks for multi-threaded operations.
        private List<TabPage> allTabs = new List<TabPage>();//A list to hold all tab pages.
        private readonly HashSet<string> _seenPaths = new(StringComparer.OrdinalIgnoreCase);//A hash set to hold seen paths for a directory.

        // =====================
        // 🎛 UI Controls
        // =====================
        private NumericUpDown bufferNumUpDown; // The UI control for setting the buffer size.
        private System.Windows.Forms.CheckBox keepDirStructCheckBox; // UI control for the "keep directory structure" option.
        private System.Windows.Forms.CheckBox leaveEmptyFoldersCheckBox; // UI control for the "keep empty folders" option.
        private System.Windows.Forms.CheckBox verifyCheckBox; // UI control for the "verify" option.
        private Label totalHDSpaceLeftLabel; // UI label to display the total hard disk space left.
        private Label fileCountOnLabel; // UI label to display the file count progress.
        private System.Windows.Forms.CheckBox createCustomDirCheckBox; // UI control for creating a custom directory.
        private System.Windows.Forms.CheckBox keepOnlyFilesCheckBox; // UI control for the "keep only files" option.
        private System.Windows.Forms.CheckBox copyFilesDirsCheckBox; // UI control for the "copy files and directories" option.
        private Label fileProcessedLabel; // UI label to show the number of files processed.
        private Label totalCopiedProgressLabel; // UI label to show the total progress in bytes.
        private Label speedLabel; // UI label to display the transfer speed.
        private NotifyIcon _systemTrayIcon; // The system tray icon.
        private Size originalSize; // The original size of the form, used for animations.
        private mainForm main; // An instance of the main form.
        private System.Windows.Forms.Timer _timer; // A UI timer.
        private BindingSource _bindingSource = new BindingSource(); // The binding source for the file list data grid view.
        private BindingSource _bindingSourceExport = new BindingSource(); // The binding source for the export list data grid view.
        private System.Windows.Forms.ToolTip toolTip1; // The tool tip control for UI elements.                       
        private System.Windows.Forms.Timer _updateTimer;// A timer object for UI updates.

        // =====================
        // ⚙️ Workers / Background Tasks
        // =====================
        private BackgroundWorker _copyWorker; // The background worker for copy operations.
        private BackgroundWorker _moveWorker; // The background worker for move operations.
        private BackgroundWorker _deleteWorker; // The background worker for delete operations.

        // =====================
        // 🔒 Threading / Sync
        // =====================
        private readonly ManualResetEvent _cancelDialogEvent = new ManualResetEvent(true); // An event to signal that a cancellation dialog has been closed.
        private ManualResetEvent _pauseEvent = new ManualResetEvent(true); // An event to signal that the operation is paused or unpaused.
        private readonly object _lockObject = new object(); // A lock object for thread synchronization.
        private readonly object _progressLock = new object(); // A lock object for updating progress variables.
        private object _syncLock = new object(); // A general-purpose lock object.
        private CancellationTokenSource _cancellationTokenSource; // Used to manage cancellation of tasks.

        // Fields for progress reporting and cancellation.
        private Progress<ProgressReport> progress;
        private CancellationTokenSource _cts;
        private readonly object _batchLock = new();

        // =====================
        // 📦 Other Objects
        // =====================
        private FileOperation _currentOperation; // An enum to represent the current file operation (Copy, Move, Secure Delete).
        private readonly ControlStateManager stateManager = new(); // A class to manage the enabled/disabled state of UI controls.

        // Defines the size of the form when rolled up and rolled down.
        private readonly Size rolledUpSize = new(1594, 22);
        private readonly Size rolledDownSize = new(1594, 665);


        // =====================
        // ⚙️ Configurations For Updating Copy That
        // =====================
        private const string GITHUB_PAGES_BASE =
            "https://mikesruthless12.github.io/CopyThat-Releases/files"; // Base URL for update files
                                                                         // =================================
                                                                         // Current local version (e.g. "1.0")
        private readonly string _localVersion;

        // Local ZIP name (e.g. "CTv1.0.zip")
        private readonly string _localZip;

        // Remote ZIP name if a newer version is found (e.g. "CTv1.1.zip")
        private string? _remoteZip;






        private static string GetAppName()
        {
            try
            {
                // Try to get from assembly product attribute first
                var productName = Assembly.GetEntryAssembly()?.GetCustomAttribute<AssemblyProductAttribute>()?.Product;
                if (!string.IsNullOrEmpty(productName))
                    return productName;

                // Fall back to application name
                if (!string.IsNullOrEmpty(Application.ProductName))
                    return Application.ProductName;

                // Final fallback to executable name
                return System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            }
            catch
            {
                // Ultimate fallback
                return "CopyThat";
            }
        }

        // Usage:
        private void GetMyAppsName()
        {
            APP_Name = GetAppName();
            // Use appName with RUN_KEY
        }


        //private CustomControls.ModernCircularProgressBar fileProgressBar;
        //private CustomControls.ModernCircularProgressBar totalProgressBar;
        public class ControlStateManager
        {
            // A dictionary to store the original `Enabled` state of each control.
            private readonly Dictionary<System.Windows.Forms.Control, bool> controlStates = new();

            /// <summary>
            /// Stores the current state of all controls on the form and disables them.
            /// This is useful for preventing user interaction during an operation.
            /// </summary>
            /// <param name="parent">The parent control (usually the main form) to start from.</param>
            public void DisableAllControls(System.Windows.Forms.Control parent)
            {
                try
                {
                    controlStates.Clear(); // Clear any previously stored states.
                    StoreAndDisableControls(parent); // Start the recursive process.
                }
                catch { } // Catches and ignores any errors that occur while disabling controls.
            }

            /// <summary>
            /// Restores all controls to their state before `DisableAllControls` was called.
            /// </summary>
            public void RestoreControlStates()
            {
                foreach (var kvp in controlStates)
                {
                    // Set the control's Enabled property back to its original value.
                    kvp.Key.Enabled = kvp.Value;
                }
            }

            /// <summary>
            /// A recursive helper method that stores the state and disables all controls and their children.
            /// </summary>
            /// <param name="parent">The parent control to process.</param>
            private void StoreAndDisableControls(System.Windows.Forms.Control parent)
            {
                foreach (System.Windows.Forms.Control ctrl in parent.Controls)
                {
                    // Store the original state of the control.
                    controlStates[ctrl] = ctrl.Enabled;

                    // Disable the control.
                    ctrl.Enabled = false;

                    // If the control has child controls, call this method recursively.
                    if (ctrl.HasChildren)
                    {
                        StoreAndDisableControls(ctrl);
                    }
                }
            }
        }

        /// <summary>
        /// Defines the type of UI update being sent to the main form from a background process.
        /// </summary>
        public enum UIUpdateType
        {
            InitialScanStarted,   // The initial scan of files has begun.
            InitialScanProgress,  // Progress update for the initial scan.
            InitialScanCompleted, // The initial scan is complete.
            Progress,             // General progress update for an ongoing operation (copy, move, etc.).
            OperationCanceled,    // The operation has been cancelled.
            OperationCompleted,   // The operation has completed successfully.
            Error,                // An error has occurred.
            StatusMessage         // A general status message to be displayed.
        }

        /// <summary>
        /// A class to hold information about a file that was skipped during an operation.
        /// </summary>
        public class SkippedFileInfo
        {
            public string Reason { get; set; }          // The reason why the file was skipped.
            public string FileName { get; set; }        // The name of the file.
            public string FileSize { get; set; }        // The size of the file as a formatted string.
            public string SourceFilePath { get; set; }  // The source path of the file.
            public string DestinationFilePath { get; set; } // The destination path of the file.
            public string ErrorMessage { get; set; }    // A detailed error message if applicable.
        }

        /// <summary>
        /// A class to hold progress information for a file operation.
        /// </summary>
        public class FileProgressInfo
        {
            public int FileIndex { get; set; }                          // The index of the file in the list.
            public long BytesTransferredCurrentFile { get; set; }       // Bytes transferred for the current file.
            public long TotalBytesCurrentFile { get; set; }             // Total bytes of the current file.
            public long OverallBytesProcessed { get; set; }             // Total bytes processed across the entire operation.
            public long OverallTotalBytes { get; set; }                 // Total bytes for the entire operation.
            public string CurrentFileName { get; set; }                 // The name of the file being processed.
            public string CurrentStatus { get; set; }                   // The current status (e.g., "Copying...").
            public int OverallPercent { get; set; }                     // The overall percentage of the operation completed.
        }

        /// <summary>
        /// A wrapper class for file information, used for display in the UI.
        /// </summary>
        public class FileInfoWrapper
        {
            public string FileName { get; set; }      // The name of the file.
            public string FilePath { get; set; }      // The full path of the file.
            public string FileSize { get; set; }      // The size of the file as a formatted string.
            public long BytesRaw { get; set; }        // The raw size of the file in bytes.
            public string Status { get; set; }        // The current status of the file (e.g., "Pending").
            public bool IsDirectory { get; set; }     // A flag to indicate if the item is a directory.
            public string SourceRoot { get; set; }    // The root source directory of the file.

            /// <summary>
            /// A read-only property that returns a user-friendly description of the item type.
            /// </summary>
            public string ItemType
            {
                get
                {
                    if (IsDirectory) return "Folder"; // If it's a directory, return "Folder".

                    var map = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
                    {
                        // Add mappings for file extensions to user-friendly descriptions.
                        // This dictionary maps common file extensions to human-readable names.

                    // This section of the code is incomplete and would need to be filled in with
                    // a mapping from file extensions to a human-readable name.
                    // ── Microsoft / Office ---------------------------------------------
                    { ".docx", "Word Document" },  { ".doc", "Word 97-2003" },
            { ".xlsx", "Excel Workbook" }, { ".xls", "Excel 97-2003" },
            { ".pptx", "PowerPoint" },     { ".ppt", "PowerPoint 97-2003" },
            { ".vsdx", "Visio Drawing" },  { ".pub", "Publisher Document" },
            { ".one",  "OneNote Notebook" },
            { ".ost", "Outlook Offline" }, { ".pst", "Outlook Personal" },
            { ".msg", "Outlook Message" }, { ".eml", "Email Message" },

            // ── Web / Mark-up ---------------------------------------------------
            { ".html", "HTML Document" },  { ".htm", "HTML Document" },
            { ".css",  "CSS Style Sheet" }, { ".scss", "Sass (SCSS)" },
            { ".sass", "Sass (Indented)" }, { ".less", "Less Style" },
            { ".js",   "JavaScript" },      { ".jsx", "React JSX" },
            { ".ts",   "TypeScript" },      { ".tsx", "React TSX" },
            { ".json", "JSON Data" },       { ".xml", "XML Document" },
            { ".yml",  "YAML Config" },

            // ── Microsoft / .NET ----------------------------------------------
            { ".cs", "C# Source" },         { ".csx", "C# Script" },
            { ".fs", "F# Source" },         { ".vb", "VB.NET Source" },
            { ".il", "IL Assembly" },       { ".resx", "Resource XML" },
            { ".xaml", "XAML Mark-up" },    { ".sln", "Visual Studio Solution" },
            { ".vbproj", "VB Project" },
            { ".vcxproj", "C++ Project" },  { ".props", "MSBuild Props" },
            { ".targets", "MSBuild Targets" },

            // ── C / C++ --------------------------------------------------------
            { ".cpp", "C++ Source" },       { ".cc", "C++ Source" },
            { ".cxx", "C++ Source" },       { ".c", "C Source" },
            { ".hpp", "C++ Header" },       { ".h", "C/C++ Header" },
            { ".inl", "Inline C++" },       { ".idl", "Interface Definition" },
            { ".rc", "Resource Script" },   { ".manifest", "Application Manifest" },

            // ── Java / JVM ------------------------------------------------------
            { ".java", "Java Source" },     { ".class", "Java Class" },
            { ".jar", "Java Archive" },     { ".war", "Java Web Archive" },
            { ".ear", "Enterprise Archive" }, { ".scala", "Scala Source" },
            { ".groovy", "Groovy Source" }, { ".clj", "Clojure Source" },

            // ── Python ----------------------------------------------------------
            { ".py", "Python Script" },     { ".pyw", "Python (No Console)" },
            { ".pyi", "Python Stub" },      { ".pyc", "Python Bytecode" },
            { ".pyo", "Python Optimised" }, { ".pyd", "Python Extension" },
            { ".whl", "Python Wheel" },     { ".ipynb", "Jupyter Notebook" },

            // ── Mobile ----------------------------------------------------------
            { ".swift", "Swift Source" },   { ".dart", "Dart Source" },
            { ".kt", "Kotlin Source" },     { ".kts", "Kotlin Script" },
            { ".gradle", "Gradle Script" }, { ".aar", "Android Archive" },
            { ".apk", "Android Package" },  { ".aab", "Android App Bundle" },
            { ".ipa", "iOS Package" },

            // ── Game Dev / 3D ---------------------------------------------------
            { ".unity", "Unity Scene" },    { ".prefab", "Unity Prefab" },
            { ".uasset", "Unreal Asset" },  { ".umap", "Unreal Map" },
            { ".fbx", "FBX 3D Model" },     { ".obj", "Wavefront 3D" },
            { ".gltf", "glTF 3D Model" },   { ".blend", "Blender Project" },
            { ".dae", "Collada Model" },    { ".3ds", "3D Studio Model" },
            { ".stl", "STL Model" },        { ".dxf", "AutoCAD DXF" },

            // ── Creative / Adobe ----------------------------------------------
            { ".psd", "Photoshop Document" }, { ".psb", "Photoshop Large" },
            { ".ai",  "Illustrator Art" },   { ".indd", "InDesign Document" },
            { ".prproj", "Premiere Project" }, { ".aep", "After Effects" },
            { ".xd",  "Adobe XD Prototype" }, { ".sketch", "Sketch Document" },
            { ".fig", "Figma Document" },

            // ── Audio -----------------------------------------------------------
            { ".mp3", "MP3 Audio" },        { ".wav", "Wave Audio" },
            { ".flac", "FLAC Audio" },      { ".aac", "AAC Audio" },
            { ".ogg", "OGG Vorbis" },       { ".wma", "Windows Audio" },
            { ".opus", "Opus Audio" },      { ".m4a", "MPEG-4 Audio" },
            { ".midi", "MIDI Sequence" },   { ".aiff", "AIFF Audio" },

            // ── Video -----------------------------------------------------------
            { ".mp4", "MP4 Video" },        { ".mkv", "Matroska Video" },
            { ".avi", "AVI Video" },        { ".mov", "QuickTime Video" },
            { ".wmv", "Windows Video" },    { ".webm", "WebM Video" },
            { ".flv", "Flash Video" },      { ".m4v", "M4V Video" },
            { ".m3u8", "HLS Playlist" },
            { ".ogv", "OGG Video" },        { ".3gp", "3GP Video" },

            // ── Images ----------------------------------------------------------
            { ".jpg", "JPEG Image" },       { ".jpeg", "JPEG Image" },
            { ".png", "PNG Image" },        { ".gif", "GIF Image" },
            { ".bmp", "BMP Image" },        { ".tiff", "TIFF Image" },
            { ".webp", "WebP Image" },      { ".ico", "Icon" },
            { ".svg", "SVG Vector" },       { ".eps", "Encapsulated PostScript" },
            { ".raw", "RAW Image" },
            { ".cr2", "Canon RAW" },        { ".nef", "Nikon RAW" },
            { ".arw", "Sony RAW" },         { ".dng", "Digital Negative" },

            // ── Archives --------------------------------------------------------
            { ".zip", "ZIP Archive" },      { ".rar", "RAR Archive" },
            { ".7z",  "7-Zip Archive" },    { ".tar", "Tar Archive" },
            { ".gz",  "GZip Archive" },     { ".bz2", "BZip2 Archive" },
            { ".xz",  "XZ Archive" },       { ".zst", "Zstd Archive" },
            { ".lz4", "LZ4 Archive" },      { ".cab", "Cabinet Archive" },
            { ".iso", "Disc Image" },       { ".dmg", "macOS Disk Image" },
            { ".img", "Raw Disk Image" },   { ".vhd", "Virtual Hard Disk" },
            { ".vhdx","Hyper-V Disk" },     { ".wim", "Windows Image" },

            // ── Database --------------------------------------------------------
            { ".sql", "SQL Script" },       { ".db",  "Database" },
            { ".sqlite", "SQLite DB" },     { ".mdb", "Access DB" },
            { ".accdb", "Access Database" }, { ".mdf", "SQL Server DB" },
            { ".ndf", "SQL Server NDF" },   { ".ldf", "SQL Server Log" },
            { ".bak", "SQL Backup" },       { ".dmp", "Database Dump" },

            // ── Scientific / Math ---------------------------------------------
            { ".mat", "MATLAB Data" },      { ".m", "MATLAB Script" },
            { ".r", "R Script" },           { ".rdata", "R Dataset" },
            { ".csv", "CSV Data" },         { ".tsv", "TSV Data" },
            { ".sas", "SAS Program" },      { ".sav", "SPSS Dataset" },
            { ".por", "SPSS Portable" },

            // ── Crypto / Blockchain -------------------------------------------
            { ".gpg", "GPG Encrypted" },    { ".pgp", "PGP Encrypted" },
            { ".asc", "PGP Signature" },    { ".sig", "Detached Signature" },
            { ".wallet", "Crypto Wallet" }, { ".key", "Key File" },
            { ".pem", "PEM Certificate" },  { ".crt", "Certificate" },
            { ".p12", "PKCS#12 Keystore" }, { ".pfx", "Windows Keystore" },

            // ── Emulation / ROMs ----------------------------------------------
            { ".gba", "Game Boy ROM" },     { ".nds", "Nintendo DS ROM" },
            { ".wbfs", "Wii Backup" },
            { ".cia", "3DS Installer" },    { ".nsp", "Switch Package" },
            { ".xci", "Switch Cartridge" }, { ".wad", "Wii Channel" },

            // ── Misc ------------------------------------------------------------
            { ".exe", "Windows Executable" }, { ".msi", "Windows Installer" },
            { ".com", "DOS Command" },      { ".bat", "Batch Script" },
            { ".ps1", "PowerShell Script" }, { ".cmd", "Command Script" },
            { ".reg", "Registry Entry" },
            { ".url", "Internet Shortcut" }, { ".torrent", "BitTorrent" },
            { ".log", "Log File" },         { ".ini", "INI Configuration" },
            { ".cfg", "Config File" },      { ".conf", "Configuration" },
            { ".yaml", "YAML Config" },     { ".toml", "TOML Config" },
            { ".env", "Environment File" }, { ".gitignore", "Git Ignore" },
            { ".dockerfile", "Dockerfile" }, { ".md", "Markdown" },
            { ".tex", "LaTeX Source" },     { ".bib", "BibTeX Library" },

            // ── Additional / Misc ---------------------------------------------
            { ".dwp", "SharePoint Web Part" },
            { ".fxp", "FoxPro Compiled" },
            { ".asd", "Word AutoSave" },
            { ".fsc", "Windows Search Cache" },
            { ".mid", "MIDI Sequence" },
            { ".fst", "FL Studio State" },
            { ".txt", "Plain Text File" },
            { ".pdb", "Program Database" },
            { ".dll", "Dynamic-Link Library" },
            { ".resources", ".NET Resources" },
            { ".cache", "Cache File" },
            { ".settings", "Settings XML" },
            { ".csproj", "C# Project" },
            { ".editorconfig", "EditorConfig" },
            { ".kdbx", "KeePass File" },
            { ".nupkg", "NuGet Package" },
            { ".p7s", "PKCS #7 Signature" },
            { ".map", "Source-Map File" },
            { ".flow", "Flow Type Declaration" },
            { ".mjs", "ES Module (JavaScript)" },
            { ".cjs", "CommonJS (JavaScript)" },
            { ".cts", "TypeScript CommonJS" },
            { ".mts", "TypeScript ES Module" },
            { ".jst", "JavaScript Template" },
            { ".markdown", "Markdown Document" },
            { ".applescript", "AppleScript" },
            { ".ch1", "Nintendo Character Data" },
            { ".vital", "Vital Synthesizer Preset" },
            { ".ds_store", "macOS Desktop Services Store" },
            { ".zpw", "ZippedWeb Package" },
            { ".flp", "FL Studio Project" },
            { ".flstheme", "FL Studio Theme" },
            { ".nmsv", "Native Instruments NMSV Preset" },
            { ".wav.256", "256-bit WAV Variant" },
            { ".pdf", "Portable Document Format" },
            { ".config", "Configuration XML/JSON" },
            { ".user", "User Settings" },
            { ".uptodate", "Up2Date Cache Flag" },
            { ".rtf", "Rich Text Format" },
            { ".buildwithskipanalyzers", "MSBuild Skip-Analyzers Flag" },
            { ".node", "Node.js Binary Module" },
            { ".snap", "Snapcraft Package" },
            { ".def", "Module-Definition File" },
            { ".bsd", "BSD Licence/Configuration" },
            { ".babelrc", "Babel Configuration" },
            { ".prettierrc", "Prettier Configuration" },
            { ".npignore", "NuGet Ignore Rules" },
            { ".php", "PHP Script" },
            { ".eslintignore", "ESLint Ignore" },
            { ".lic", "License File" },
            { ".nib", "NeXT Interface Builder" },
            { ".plist", "macOS Property List" },
            { ".mui", "Multilingual User Interface" },
            { ".efi", "UEFI Firmware" },
            { ".cip", "Chrome CIP Package" },
            { ".bin", "Binary Data" },
            { ".sdi", "System Deployment Image" },
            { ".ttf", "TrueType Font" },
            { ".cur", "Windows Cursor" },
            { ".ani", "Animated Cursor" },
            { ".diagpkg", "Windows Diagnostic Package" },
            { ".dat", "Generic Data File" },
            { ".diffbase", "Diff Base Snapshot" },
            { ".lm", "Language Model" },
            { ".lm1", "Language Model Variant 1" },
            { ".lm2", "Language Model Variant 2" },
            { ".lm3", "Language Model Variant 3" },
            { ".lex", "Lexicon Data" },
            { ".res", "Windows Resource" },
            { ".nlt", "NetLink Trust Data" },
            { ".nls", "National Language Support" },
            { ".chm", "Compiled HTML Help" },
            { ".fil", "File List Container" },
            { ".msixbundle", "MSIX Bundle" },
            { ".p7x", "PKCS #7 Extended" },
            { ".pri", "Package Resource Index" },
            { ".etl", "Event Trace Log" },
            { ".nlp", "Natural Language Processor Data" },
            { ".compositefont", "WPF Composite Font" },
            { ".aspx", "ASP.NET Page" },
            { ".ascx", "ASP.NET User Control" },
            { ".master", "ASP.NET Master Page" },
            { ".browser", "Browser Definition" },
            { ".lnk", "Windows Shortcut" },
            { ".default", "Default Settings" },
            { ".comments", "Comment Metadata" },
            { ".rsp", "Response File" },
            { ".tld", "Tag Library Descriptor" },
            { ".win32manifest", "Win32 Manifest" },
            { ".man", "Manual Page" },
            { ".mof", "Managed Object Format" },
            { ".uninstall", "Uninstall Script" },
            { ".tasks", "MSBuild Tasks" },
            { ".overridetasks", "MSBuild Override Tasks" },
            { ".orp", "ORP Data" },
            { ".adml", "Administrative Template Language" },
            { ".ppkg", "Provisioning Package" },
            { ".mstheme", "Microsoft Theme" },
            { ".msstyles", "Windows Style" },
            { ".mum", "Manifest Update Module" },
            { ".cat", "Security Catalog" },
            { ".jfm", "Jet Database Metadata" },
            { ".rs", "Rust Source" },
            { ".jll", "Julia LLVM Bitcode" },
            { ".sys", "Windows System Driver" },
            { ".p7b", "PKCS #7 Certificate Chain" },
            { ".wmfw", "Windows Media Framework" },
            { ".inf_loc", "INF Localization" },
            { ".winmd", "Windows Metadata" },
            { ".xbf", "XAML Binary Format" },
            { ".license", "License Token" },
            { ".fpie", "FPGA Intermediate Executable" },
            { ".cso", "Compiled Shader Object" },
            { ".sccd", "System Center Config Data" },
            { ".bundle", "Application Bundle" },
            { ".schema", "JSON/XML Schema" },
            { ".csg", "Constructive Solid Geometry" },
            { ".mun", "Multi-Unit Network" },
            { ".uce", "Universal Chess Engine" },
            { ".cpl", "Control Panel Applet" },
            { ".msc", "Microsoft Management Console" },
            { ".ax", "DirectShow Filter" },
            { ".table", "Lookup/Hash Table" },
            { ".tsp", "TSP Package/Script" },
            { ".tbl", "Table Data" },
            { ".drv", "Device Driver" },
            { ".sep", "Separator File" },
            { ".ocx", "ActiveX Control" },
            { ".msp", "Windows Installer Patch" },
            { ".scr", "Windows Screen Saver" },
            { ".vbs", "VBScript" },
            { ".grxml", "Grammar XML" },
            { ".xrm-ms", "Microsoft License" },
            { ".rll", "Resource Link Library" },
            { ".mfl", "MFL Language File" },
            { ".cdxml", "Cmdlet Definition XML" },
            { ".dtd", "Document Type Definition" },
            { ".psm1", "PowerShell Module Script" },
            { ".ps1xml", "PowerShell Format Data" },
            { ".wprp", "Windows Performance Recorder Profile" },
            { ".xsl", "XSLT Stylesheet" },
            { ".gyp", "Generate Your Projects" },
            { ".rld", "ReLoad Data" },
            { ".job", "Windows Task Job" },
            { ".gypi", "GYP Include" },
            { ".hlp", "Windows Help" },
            { ".gdl", "Generic Description Language" },
            { ".elf", "Executable and Linkable Format" },
            { ".ppd", "PostScript Printer Description" },
            { ".gpd", "Generic Printer Description" },
            { ".mbn", "Modem Binary" },
            { ".pak", "PAK Archive" },
            { ".dgml", "Directed Graph Markup" },
            { ".smp", "Sample File" },
            { ".lxa", "Microsoft Lexicon Audio" },
            { ".wwd", "Microsoft Works Wizard" },
            { ".wsf", "Windows Script File" },
            { ".cw", "CardWorks Template" },
            { ".phn", "Phun Physics Scene" },
            { ".am", "Automake File" },
            { ".fe", "File Encryptor" },
            { ".mllr", "Maximum Likelihood Linear Regression" },
            { ".ngr", "NEOGEO ROM" },
            { ".sch", "Schedule/Schema" },
            { ".adlm", "Autodesk License Manager" },
            { ".adxm", "Administrative XML" },
            { ".nmnl", "Normalized Minimal" },
            { ".propdesc", "Property Description" },
            { ".nsl", "Nokia Sound Library" },
            { ".ntf", "National Transfer Format" },
            { ".ntp", "NTP Configuration" },
            { ".forms", "Windows Forms" },
            { ".runtime", "Runtime Manifest" },
            { ".interop", "COM Interop Data" },
            { ".frm", "Visual Basic Form" },
            { ".bas", "Visual Basic Module" },
             { ".dwb", "Drum Workshop Bundle" },
            { ".npmignore", "NPM Ignore Rules" },
            { ".rsrc", "macOS Resource Fork" },
            { ".upd2date", "Up2Date Cache Flag" },
            { ".Up2Date", "Up2Date Cache Flag" },
            { ".jshintrc", "JSHint Configuration" },
            { ".lock", "Lock/Dependency Pin" },
            { ".nix", "Nix Expression" },
            { ".hr1", "HR1 Game Data" },
            { ".hr2", "HR2 Game Data" },
            { ".hr3", "HR3 Game Data" },
            { ".hr4", "HR4 Game Data" },
            { ".hr5", "HR5 Game Data" },
            { ".hr6", "HR6 Game Data" },
            { ".hr7", "HR7 Game Data" },
            { ".hr8", "HR8 Game Data" },
            { ".hr9", "HR9 Game Data" },
            { ".bnf", "Backus-Naur Form Grammar" },
            { ".clb", "COM+ Catalog" },
            { ".tlb", "Type Library" },
            { ".dic", "Dictionary/Lexicon" },
            { ".aux", "Auxiliary TeX File" },
            { ".ds", "DataStore/DS_Store" },
            { ".inc", "Include/Source Include" },
            { ".cpx", "Code Page Translation" },
            { ".mdl", "Model/Module File" },
            { ".dls", "Downloadable Sounds Bank" },
            { ".cdf-ms", "ClickOnce Deployment Manifest" },
            { ".addin", "Visual Studio Add-in" },
            { ".scp", "Windows Script Component" },
            { ".wmz", "Compressed Windows Media Player Skin" },
            { ".iec", "IEC Database" },
            { ".wsc", "Windows Script Component" },
            { ".vrg", "Visual Studio Registry Script" },
            { ".prx", "Proxy Auto-Config" },
            { ".nuspec", "NuGet Specification" },
            
            // ── Extended Archive / Compression --------------------------------
            { ".zipx", "ZIPX Archive" },
            { ".alz", "ALZip Archive" },
            { ".eeg", "EEG Compressed" },
            { ".001", "Split Archive Part 1" },
            { ".arj", "ARJ Archive" },
            { ".bh",  "BlakHole Archive" },
            { ".lha", "LHA Archive" },
            { ".lzh", "LHA/LZH Archive" },
            { ".pma", "PMarc Archive" },
            { ".arc", "ARC Archive" },
            { ".ace", "ACE Archive" },
            { ".aes", "AES-Encrypted File" },
            { ".zpak", "ZPAQ Archive" },
            { ".zstd", "Zstandard Archive" },
            { ".br",  "Brotli Archive" },
            { ".pea", "PeaZip Archive" },
            { ".tbz", "Tar.BZ Archive" },
            { ".tbz2", "Tar.BZ2 Archive" },
            { ".txz", "Tar.XZ Archive" },
            { ".tlz", "Tar.LZMA Archive" },
            { ".uu",  "UUEncoded File" },
            { ".uue", "UUEncoded File" },
            { ".xxe", "XXEncoded File" },
            { ".z",   "Unix Compress" },
            { ".tgz", "Tar.GZ Archive" },
            { ".isz", "ISO-Zipped Image" },
            { ".udf", "Universal Disk Format" },
            { ".i00", "DVD Decrypter Split Image Part 1" }
        };

                    string ext = System.IO.Path.GetExtension(FileName);
                    return map.TryGetValue(ext, out var desc) ? desc : "File";
                }
            }
        }
        /// <summary>
        /// A private class to pass a bundle of parameters to a BackgroundWorker's DoWork event.
        /// This encapsulates all the necessary settings for a file operation.
        /// </summary>
        private class DoWorkParameters
        {
            public FileOperation Operation { get; set; }          // The type of operation (e.g., Copy, Move, Delete).
            public List<string> TargetPaths { get; set; }         // The list of destination directories.
            public bool OverwriteAll { get; set; }                // Flag for "overwrite all" behavior.
            public bool DoNotOverwrite { get; set; }              // Flag for "do not overwrite" behavior.
            public bool OverwriteIfNewer { get; set; }            // Flag for "overwrite if newer" behavior.
            public bool KeepDirectoryStructure { get; set; }      // Flag to maintain the original folder structure.
            public bool CopyFilesOnly { get; set; }               // Flag to only copy files, not folders.
            public bool KeepEmptyFolders { get; set; }            // Flag to keep empty folders after a move/delete.
            public bool KeepOnlyFiles { get; set; }               // Flag to process only files.
        }

        /// <summary>
        /// A class to hold real-time information about the current file operation.
        /// This is likely used for displaying live progress in the UI.
        /// </summary>
        public class CurrentOperation
        {
            public string FileName { get; set; }  // The name of the file currently being processed.
            public long FileSize { get; set; }    // The size of the current file in bytes.
            public double Speed { get; set; }     // The current transfer speed.
        }

        /// <summary>
        /// Toggles the enabled state of various UI controls based on the application's state.
        /// This is typically used to enable/disable buttons like Start, Cancel, and Pause/Resume.
        /// </summary>
        /// <param name="enabled">If true, enables Start/Add buttons and disables Cancel/Pause/Resume. If false, does the opposite.</param>
        private void ToggleUIState(bool enabled)
        {
            addFileButton.Enabled = enabled;
            sourceDirectoryLabel.Enabled = enabled;
            startButton.Enabled = enabled;
            cancelButton.Enabled = !enabled;
            pauseResumeButton.Enabled = !enabled;
        }

        /// <summary>
        /// The main constructor for the mainForm class. It initializes components and sets up the application's state and workers.
        /// </summary>
        public mainForm()
        {
            /*  derive version from the EXE that is currently running  */
            var exe = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath);
            if (!exe.StartsWith("CTv") || !Version.TryParse(exe[3..], out _))
                throw new InvalidDataException("Executable must be named CTvX.Y.exe");
            _localVersion = exe[3..];        // "1.0"
            _localZip = exe + ".zip";    // "CTv1.0.zip"

            // Initializes the combo boxes for post-copy actions and file operations.
            InitializeComponent();              // Initializes the visual components of the form.



            _slots = new[]
            {
            new Slot(1, progressBarMutli1, filesNameLabel1),
            new Slot(2, progressBarMutli2, filesNameLabel2),
            new Slot(3, progressBarMutli3, filesNameLabel3),
            new Slot(4, progressBarMutli4, filesNameLabel4)
            };


            InitializeDefaultSettings();        // Sets up default values for application settings if they don't exist.
            ConfigureApplicationSettings();     // A method placeholder (not shown) for configuring app settings.
            CheckForIllegalCrossThreadCalls = false; // Allows background workers to update the UI directly (Note: Not a best practice, but common for simplicity in some projects).
            filesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Configures how users select rows in the DataGridView.

            // Initialize the BackgroundWorker for 'Move' operations.
            _moveWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,          // Allows reporting progress updates.
                WorkerSupportsCancellation = true      // Allows the worker to be cancelled.
            };
            _moveWorker.DoWork += DeleteWorker_DoWork; // Attaches the event handler for the main work. (Note: The name `DeleteWorker_DoWork` is likely a typo, it should probably be `MoveWorker_DoWork` if it's a dedicated method.)
            _moveWorker.RunWorkerCompleted += MoveWorker_RunWorkerCompleted; // Attaches the event handler for when the worker completes.
            _moveWorker.ProgressChanged += MoveWorker_ProgressChanged;      // Attaches the event handler for progress updates.

            // Initialize the BackgroundWorker for 'Delete' operations.
            _deleteWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            _deleteWorker.DoWork += DeleteWorker_DoWork;
            _deleteWorker.RunWorkerCompleted += DeleteWorker_RunWorkerCompleted;
            _deleteWorker.ProgressChanged += DeleteWorker_ProgressChanged;


            // Initialize the BackgroundWorker for 'Copy' operations.
            _copyWorker = new BackgroundWorker();
            _copyWorker.WorkerReportsProgress = true;
            _copyWorker.WorkerSupportsCancellation = true;
            _copyWorker.DoWork += _copyWorker_DoWork;
            _copyWorker.ProgressChanged += _copyWorker_ProgressChanged;
            _copyWorker.RunWorkerCompleted += _copyWorker_RunWorkerCompleted;

            // Initialize a Timer for UI updates, such as status labels or progress bars.
            if (_updateTimer == null)
            {
                _updateTimer = new Timer();
                _updateTimer.Interval = 1000; // Sets the timer to tick every 1000ms (1 second).
                _updateTimer.Tick += _updateTimer_Tick; // Attaches the event handler for each tick.
            }
            _cancellationTokenSource = new CancellationTokenSource(); // Creates an object for managing task cancellations.

            startWithWindowsCheckBox.Checked = Properties.Settings.Default.StartWithWindows;

            startWithWindowsCheckBox.CheckedChanged += startWithWindowsCheckBox_CheckedChanged;
            GetMyAppsName();
            //SyncStartupSetting();

            this.Shown += MainForm_Shown;
        }

        /// <summary>
        /// Initializes the default application settings. This method is called once when the application is first run.
        /// </summary>
        private void InitializeDefaultSettings()
        {
            if (!CopyThatProgram.Properties.Settings.Default.Initialized)
            {
                // Sets default values for various settings.
                CopyThatProgram.Properties.Settings.Default.FontSize = 9;
                CopyThatProgram.Properties.Settings.Default.Skin = "Dark Mode";
                CopyThatProgram.Properties.Settings.Default.LogRetentionDays = 10;
                CopyThatProgram.Properties.Settings.Default.BufferSize = 1024;
                CopyThatProgram.Properties.Settings.Default.AlwaysOnTop = false;
                CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop = true;
                CopyThatProgram.Properties.Settings.Default.MinimizeToTray = false;
                CopyThatProgram.Properties.Settings.Default.StartWithWindows = false;
                CopyThatProgram.Properties.Settings.Default.Initialized = true; // Marks settings as initialized.
                CopyThatProgram.Properties.Settings.Default.Save(); // Saves the new default settings.
            }
        }

        /// <summary>
        /// Loads the current application settings from the user's configuration file and applies them to the UI controls.
        /// </summary>
        private void LoadCurrentSettings()
        {
            // Windows Settings Group
            alwaysOnTopCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.AlwaysOnTop;
            confirmDragDropCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop;
            minimizeSystemTrayCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.MinimizeToTray;




            // Log Settings
            logFileCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.LogToFile;
            logDaysNumUpDown.Minimum = 10;
            logDaysNumUpDown.Maximum = 30;
            logDaysNumUpDown.Value = CopyThatProgram.Properties.Settings.Default.LogRetentionDays;

            // Performance Settings
            bufferNumUpDown.Minimum = 100;
            bufferNumUpDown.Maximum = 1024;
            bufferNumUpDown.Value = CopyThatProgram.Properties.Settings.Default.BufferSize;

            overMBCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.CopyFilesOver;
            setMBGBOverNumUpDown.Minimum = 1;
            setMBGBOverNumUpDown.Maximum = 100;
            setMBGBOverNumUpDown.Value = CopyThatProgram.Properties.Settings.Default.OverNum;

            // Other Settings
            onErrorCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.RestartOnError;
            closeProgramCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.CloseOnError;
            startWithWindowsCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.StartWithWindows;

            // Sound Settings
            onFinishCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.SoundCopyComplete;
            onAddFilesCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.SoundFileAdded;
            onCancelCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.SoundCancel;
            onErrorCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.SoundError;

            // Auto Save Settings
            saveAutoCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.AutoSaveSettings;
        }

        /// <summary>
        /// Initializes the main DataGridView control, sets up its data source, and defines its columns.
        /// </summary>
        private void InitializeDataGridView()
        {
            _bindingSource.DataSource = _fileList;           // Binds the DataGridView to the list of FileInfoWrapper objects.
            filesDataGridView.DataSource = _bindingSource;   // Sets the DataGridView's data source.

            filesDataGridView.AutoGenerateColumns = false;   // Prevents automatic column creation.
            filesDataGridView.Columns.Clear();               // Clears any existing columns.

            // Adds columns to the DataGridView, mapping them to the properties of FileInfoWrapper.
            filesDataGridView.Columns.AddRange(new DataGridViewColumn[]
            {
             new DataGridViewTextBoxColumn { DataPropertyName = "FileName", HeaderText = "Name", Width = 200 },
             new DataGridViewTextBoxColumn { DataPropertyName = "FilePath", HeaderText = "Path", Width = 300 },
             new DataGridViewTextBoxColumn { DataPropertyName = "ItemType", HeaderText = "Type", Width = 80 },
             new DataGridViewTextBoxColumn { DataPropertyName = "FileSize", HeaderText = "Size", Width = 60 },
             new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Width = 100 },
             new DataGridViewTextBoxColumn { DataPropertyName = "BytesRaw", HeaderText = "BytesRaw", Visible = false } // Hides this column from the user.
            });

            ConfigureSecondaryGridViews(); // Calls a method to set up other DataGridViews.

            // Attaches an event handler for cell clicks, first removing it to prevent duplicates.
            filesDataGridView.CellMouseClick -= filesDataGridView_CellMouseClick;
            filesDataGridView.CellMouseClick += filesDataGridView_CellMouseClick;

            _bindingSource.ResetBindings(false); // Refreshes the data bindings.
        }


        /// <summary>
        /// Configures the columns for the secondary DataGridView controls (dataGridView1 and dataGridView2).
        /// </summary>
        private void ConfigureSecondaryGridViews()
        {
            // Configures dataGridView1 if its columns have not been set up.
            if (dataGridView1.Columns.Count == 0)
            {
                dataGridView1.Columns.AddRange(new DataGridViewColumn[]
                {
                 new DataGridViewTextBoxColumn { DataPropertyName = "FileName", HeaderText = "File's Name", Width = 200 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "FilePath", HeaderText = "File's Path", Width = 300 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "ItemType", HeaderText = "Type", Width = 80 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "FileSize", HeaderText = "File's Size", Width = 100 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Width = 100 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "BytesRaw", HeaderText = "BytesRaw", Visible = false }
                });
            }

            // Configures dataGridView2 if its columns have not been set up.
            if (dataGridView2.Columns.Count == 0)
            {
                dataGridView2.Columns.AddRange(new DataGridViewColumn[]
                {
                 new DataGridViewTextBoxColumn { DataPropertyName = "FileName", HeaderText = "File's Name", Width = 200 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "FilePath", HeaderText = "File/Dir(s) Path", Width = 300 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "ItemType", HeaderText = "Type", Width = 80 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "FileSize", HeaderText = "File's Size", Width = 100 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Width = 100 },
                 new DataGridViewTextBoxColumn { DataPropertyName = "BytesRaw", HeaderText = "BytesRaw", Visible = false }
                });
            }
        }

        /// <summary>
        /// This method provides a centralized way to update the UI from any thread.
        /// It checks if a UI update is required and, if so, invokes the action on the UI thread.
        /// </summary>
        /// <param name="type">The type of UI update, defined in the UIUpdateType enum.</param>
        /// <param name="message">An optional message to display (e.g., for errors or completion notices).</param>
        private void UpdateUI(UIUpdateType type, string message = "")
        {
            // Check if the current thread is not the UI thread.
            if (InvokeRequired)
            {
                // If not, use Invoke to execute this method on the UI thread.
                Invoke(new Action(() => UpdateUI(type, message)));
                return;
            }

            // Handle the UI update based on the specified type.
            switch (type)
            {
                case UIUpdateType.InitialScanStarted:
                    // This case is currently empty, but would be used to handle UI changes when a scan begins.
                    break;
                case UIUpdateType.InitialScanProgress:
                    // This case is currently empty, but would be used to update progress during the initial scan.
                    break;
                case UIUpdateType.InitialScanCompleted:
                    // This case is currently empty, but would be used to handle UI changes when a scan completes.
                    break;
                case UIUpdateType.Progress:
                    // This case is currently empty, but would be used to update progress bars and labels.
                    break;
                case UIUpdateType.OperationCanceled:
                    // Display a message box informing the user that the operation was canceled.
                    MessageBox.Show(message, "Operation Canceled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Call a method to reset all UI elements and variables related to progress.
                    ResetProgressUIAndVariables();
                    break;
                case UIUpdateType.OperationCompleted:
                    // Display a message box informing the user that the operation is complete.
                    MessageBox.Show(message, "Operation Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Reset all progress-related UI and variables.
                    ResetProgressUIAndVariables();
                    break;
                case UIUpdateType.Error:
                    // Display an error message box with the provided message.
                    MessageBox.Show("Error: " + message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case UIUpdateType.StatusMessage:
                    // This case is currently empty, but would be used to display simple status messages.
                    break;
                default:
                    // Default case, does nothing.
                    break;
            }
        }

        /// <summary>
        /// A custom class that extends BindingList to add sorting functionality.
        /// This allows a data-bound control, like a DataGridView, to be sorted by clicking column headers.
        /// </summary>
        /// <typeparam name="T">The type of items in the list.</typeparam>
        public class SortableBindingList<T> : BindingList<T>
        {
            private bool isSortedValue;               // Stores whether the list is currently sorted.
            private ListSortDirection sortDirectionValue; // Stores the direction of the current sort.
            private PropertyDescriptor sortPropertyValue;  // Stores the property used for the current sort.

            // Overrides to tell the BindingList that sorting is supported.
            protected override bool SupportsSortingCore => true;
            protected override bool IsSortedCore => isSortedValue;

            // Overrides to return the current sort property and direction.
            protected override PropertyDescriptor SortPropertyCore => sortPropertyValue;
            protected override ListSortDirection SortDirectionCore => sortDirectionValue;

            /// <summary>
            /// Applies the sort to the list based on the given property descriptor and direction.
            /// </summary>
            /// <param name="prop">The property to sort by.</param>
            /// <param name="direction">The sort direction (Ascending or Descending).</param>
            protected override void ApplySortCore(PropertyDescriptor prop, ListSortDirection direction)
            {
                var items = Items as List<T>;
                if (items != null)
                {
                    // Use LINQ to order the list items.
                    var sortedItems = direction == ListSortDirection.Ascending
                        ? items.OrderBy(x => prop.GetValue(x)).ToList()
                        : items.OrderByDescending(x => prop.GetValue(x)).ToList();

                    // Clear the original list and add the sorted items back.
                    items.Clear();
                    foreach (var item in sortedItems)
                        items.Add(item);

                    // Update the sort properties.
                    sortPropertyValue = prop;
                    sortDirectionValue = direction;
                    isSortedValue = true;

                    // Raise a ListChanged event to notify bound controls to refresh.
                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                }
            }

            /// <summary>
            /// Removes the sort from the list.
            /// </summary>
            protected override void RemoveSortCore()
            {
                isSortedValue = false;
            }
        }
        private void InitializeOperationComboBox()
        {



            string selectedLanguage = CopyThatProgram.Properties.Settings.Default.Language;
            // Populate the combo box with the available file operations.
            copyMoveDeleteComboBox.Items.Clear();
            onFinishComboBox.Items.Clear();
            if ((selectedLanguage == "English" || selectedLanguage == "Inglés"))
            {
                copyMoveDeleteComboBox.Items.AddRange(new[] { "Copy Files", "Move Files", "Secure Delete" });

                onFinishComboBox.Items.AddRange(new string[]
                {
                    "Do Nothing",
                    "Sleep",
                    "Log Off",
                    "Exit Program",
                    "Shut Down"
                });


            }
            else if (selectedLanguage == "Spanish" || selectedLanguage == "Español")
            {
                copyMoveDeleteComboBox.Items.AddRange(new[] { "Copiar archivos", "Mover archivos", "Borrado seguro" });
                onFinishComboBox.Items.AddRange(new string[]
                {
                        "No hacer nada",
                        "Suspender",
                        "Cerrar sesión",
                        "Salir del programa",
                        "Apagar"
                });

                onFinishMultiComboBox.Items.AddRange(new string[]
                {
                        "No hacer nada",
                        "Suspender",
                        "Cerrar sesión",
                        "Salir del programa",
                        "Apagar"
                });
            }


            // Attach an event handler to update the UI when the selected item changes.
            copyMoveDeleteComboBox.SelectedIndexChanged += (s, e) => UpdateUIForOperation();
        }

        /// <summary>
        /// Updates the UI based on the selected file operation.
        /// </summary>
        private void UpdateUIForOperation()
        {
            // Check if the "Secure Delete" option is selected.
            bool isDelete = copyMoveDeleteComboBox.SelectedItem.ToString() == "Secure Delete";
            // Disable the target directory label if the operation is "Secure Delete".
            targetDirLabel.Enabled = !isDelete;
            // Disable the source directory label if the operation is "Secure Delete".
            sourceDirectoryLabel.Enabled = !isDelete;
        }
        private void SetupUI()
        {
            // Configure the main DataGridView control.
            filesDataGridView.AutoGenerateColumns = false; // Prevents the grid from automatically creating columns.
            filesDataGridView.AllowUserToAddRows = false; // Prevents the user from adding new rows.

            // Set the maximum value for all progress bars to 10000 for finer granularity.
            fileProgressBar.Maximum = 10000;
            totalProgressBar.Maximum = 10000;
            progressBarMutli1.Maximum = 10000;
            progressBarMutli2.Maximum = 10000;
            progressBarMutli3.Maximum = 10000;
            progressBarMutli4.Maximum = 10000;
            progressBarMultiThreadTotal.Maximum = 10000;
            multithreadCheckBox.Checked = true;
            keepDirStructCheckBox.Checked = true;
        }

        /// <summary>
        /// Resets all progress-related UI elements and variables to their initial state.
        /// This is called after an operation is completed or canceled.
        /// </summary>
        private void ResetProgressUIAndVariables()
        {
            // Ensure the method is executed on the UI thread.
            if (InvokeRequired)
            {
                Invoke(new Action(ResetProgressUIAndVariables));
                return;
            }

            _processedFiles = 0;
            fileProgressBar.Value = 0;
            totalProgressBar.Value = 0;


            fileProgressBar.Text = "0.00%";
            totalProgressBar.Text = "0.00%";

            // Reset the total progress label and bar.
            fileProcessedLabel.Text = "File Processed: 0 Bytes / 0 Bytes";
            totalCopiedProgressLabel.Text = "Total C/M/D: 0 Bytes / 0 Bytes";
            fileCountOnLabel.Text = "File Count: 0 / 0";
            // Reset internal total bytes processed counters.
            _totalBytesProcessed = 0;
            _totalBytesToProcess = 0;

            // Reset all multithreaded progress bars and labels.
            progressBarMutli1.Value = 0;
            progressBarMutli1.Text = "0.00%";
            progressBarMutli2.Value = 0;
            progressBarMutli2.Text = "0.00%";
            progressBarMutli3.Value = 0;
            progressBarMutli3.Text = "0.00%";
            progressBarMutli4.Value = 0;
            progressBarMutli4.Text = "0.00%";
            progressBarMultiThreadTotal.Value = 0;
            progressBarMultiThreadTotal.Text = "0.00%";
            //multiThreadTotalProgressLabel.Text = "0.00%";

            // Reset the path labels to their default text.
            filePathLabel.Text = "Nothing";
            fromFilesDirLabel.Text = "Select Files / Directory";
            targetDirLabel.Text = "Select Target Directory";
            _fileList.Clear();
            _sourceDirectories.Clear();
            _currentTargetPaths.Clear();

        }
        /// <summary>
        /// Configures all application settings by applying user preferences from the settings store.
        /// This method initializes core application behavior and UI settings during startup or settings changes.
        /// </summary>
        private void ConfigureApplicationSettings()
        {
            // Apply application settings that affect core behavior.
            ConfigureWindowsStartup(CopyThatProgram.Properties.Settings.Default.StartWithWindows);
            ConfigureAlwaysOnTop(CopyThatProgram.Properties.Settings.Default.AlwaysOnTop);
            ConfigureDragDropConfirmation(CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop);

            // Apply UI-related settings.
            ApplyLanguageSettings();
        }

        /// <summary>
        /// Configures whether the application starts automatically with Windows using the Registry.
        /// </summary>
        /// <param name="startWithWindows">True to add the app to startup, false to remove it.</param>
        private void ConfigureWindowsStartup(bool startWithWindows)
        {
            const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";
            // Open the Run key in the current user's registry hive with write permissions.
            using (var key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(RunKey, true))
            {
                if (startWithWindows)
                {
                    // Set a new value with the application's executable path.
                    key.SetValue("CopyThatProgram", System.Windows.Forms.Application.ExecutablePath);
                }
                else
                {
                    // Delete the value if it exists. The 'false' parameter prevents an exception if the value is not found.
                    key.DeleteValue("CopyThatProgram", false);
                }
            }
        }
        /// <summary>
        /// Configures drag-and-drop functionality with optional confirmation prompt before processing files.
        /// Based on the configuration setting, either attaches confirmation-based or standard drag-drop event handlers.
        /// </summary>
        /// <param name="confirmDragDrop">True to show confirmation prompts before processing dragged files, false to process files immediately</param>
        private void ConfigureDragDropConfirmation(bool confirmDragDrop)
        {
            // The `confirmDragDrop` setting determines if a confirmation prompt should appear before processing dragged files.
            if (confirmDragDrop == true)
            {
                // Enable drag-and-drop and attach event handlers for confirmation logic.
                this.AllowDrop = true;
                this.DragEnter += MainForm_DragEnterWithConfirmation;
                this.DragDrop += MainForm_DragDropWithConfirmation;
            }
            else
            {
                // Enable drag-and-drop and attach standard event handlers without a confirmation.
                this.AllowDrop = true;
                this.DragEnter += MainForm_DragEnter;
                this.DragDrop += MainForm_DragDrop;
            }
        }

        /// <summary>
        /// This event handler is for the UI timer's tick event. It calculates and updates
        /// the transfer speed and estimated time remaining every second.
        /// </summary>
        private void updateTimer_Tick(object sender, EventArgs e)
        {
            // Do nothing if the operation is paused or canceled.
            if (_isPaused || _isCanceled) return;
            // Do nothing if the stopwatch hasn't started or no bytes have been processed.
            if (_stopwatch.ElapsedMilliseconds == 0 && _totalBytesProcessed == 0)
                return;

            long elapsedMs = _stopwatch.ElapsedMilliseconds;
            if (elapsedMs == 0)
                return;

            // Calculate bytes processed since the last tick.
            long bytesSinceLastTick = _totalBytesProcessed - _lastProcessedBytesForSpeed;

            // Calculate speed in bytes per second.
            double speedBps = bytesSinceLastTick / ((DateTime.Now - _lastSpeedCalcTime).TotalSeconds);

            // Use a switch expression to format the speed into B/s, KB/s, MB/s, or GB/s.
            string speedText = speedBps switch
            {
                < 1024 => $"{speedBps:F2} B/s",
                < 1024 * 1024 => $"{speedBps / 1024:F2} KB/s",
                < 1024L * 1024 * 1024 => $"{speedBps / (1024.0 * 1024):F2} MB/s",
                _ => $"{speedBps / (1024.0 * 1024 * 1024):F2} GB/s"
            };

            // Calculate the estimated time remaining.
            long bytesRemaining = _totalBytesToProcess - _totalBytesProcessed;
            TimeSpan eta = bytesRemaining <= 0 || speedBps <= 0
                ? TimeSpan.Zero
                : TimeSpan.FromSeconds(bytesRemaining / speedBps);

            TimeSpan elapsed = TimeSpan.FromMilliseconds(elapsedMs);

            // Calculate the total estimated target time.
            TimeSpan target = elapsed + eta;

            // Calculate running grand totals (current operation + previously saved totals)
            var settings = Properties.Settings.Default;
            _grandElapsedTime = TimeSpan.FromSeconds(settings.TotalElapsedTimeSeconds) + elapsed;
            _grandTargetTime = TimeSpan.FromSeconds(settings.TotalTargetTimeSeconds) + target;

            // Update the UI labels with the new speed and time information
            if (speedLabel != null && !speedLabel.IsDisposed)
                speedLabel.Text = $"Speed: {speedText}";

            // Update current operation time display
            if (elapsedAndTargetTimeLabel != null && !elapsedAndTargetTimeLabel.IsDisposed)
                elapsedAndTargetTimeLabel.Text = $"Elapsed / Target Time: {elapsed:hh\\:mm\\:ss} / {target:hh\\:mm\\:ss}";

            // Update running totals display
            if (totalElapsedTimeLabel != null && !totalElapsedTimeLabel.IsDisposed)
                totalElapsedTimeLabel.Text = $"Total Elapsed Time: {TotalsManager.FormatTimeWithDaysAndYears(_grandElapsedTime)}";
            if (totalTargetTimeLabel != null && !totalTargetTimeLabel.IsDisposed)
                totalTargetTimeLabel.Text = $"Total Target Time: {TotalsManager.FormatTimeWithDaysAndYears(_grandTargetTime)}";

            // Store the current values for the next calculation.
            _lastProcessedBytesForSpeed = _totalBytesProcessed;
            _lastSpeedCalcTime = DateTime.Now;

            // Update the drive space information.
            UpdateDriveSpaceInfo();
        }




        /// <summary>
        /// This method retrieves the file path of the currently active Windows Explorer window.
        /// It uses COM objects and P/Invoke to interact with the Windows Shell.
        /// </summary>
        /// <returns>The path of the active Explorer window, or the Desktop path if no Explorer window is active or the path cannot be determined.</returns>
        private static string GetExplorerPath()
        {
            string value = "";
            // Get the handle of the active window (foreground window) using a P/Invoke call.
            IntPtr handle = GetForegroundWindow();

            // Instantiate the ShellWindows COM object, which represents all open shell windows.
            // A reference to SHDocVw.dll is required for this.
            ShellWindows shellWindows = new SHDocVw.ShellWindows();

            // Iterate through all open shell windows.
            foreach (InternetExplorer window in shellWindows)
            {
                // Check if the current window is the active (foreground) window.
                if ((IntPtr)window.HWND == handle)
                {
                    // Try to get the ShellFolderViewDual2 object, which represents the file list of an Explorer window.
                    var shellWindow = window.Document as Shell32.IShellFolderViewDual2;

                    if (shellWindow != null)
                    {
                        // Retrieve the current folder item.
                        var currentFolder = shellWindow.Folder.Items().Item();

                        // Check for special cases like "Desktop" or other virtual folders, which have a "::" path.
                        if (currentFolder == null || currentFolder.Path.StartsWith("::"))
                        {
                            // If it's a special folder, use the window title as a fallback path.
                            const int nChars = 256;
                            StringBuilder Buff = new StringBuilder(nChars);
                            if (GetWindowText(handle, Buff, nChars) > 0)
                            {
                                return Buff.ToString();
                            }
                        }
                        else
                        {
                            // If a valid path is found, return it.
                            value = currentFolder.Path;
                            return currentFolder.Path;
                        }
                    }
                }
            }

            // If the foreground window wasn't an Explorer window, or the path couldn't be determined,
            // iterate through all open Explorer windows again to find the first valid path.
            foreach (InternetExplorer window in shellWindows)
            {
                var shellWindow = window.Document as Shell32.IShellFolderViewDual2;
                if (shellWindow != null)
                {
                    var currentFolder = shellWindow.Folder.Items().Item();
                    if (currentFolder == null || currentFolder.Path.StartsWith("::"))
                    {
                        const int nChars = 256;
                        StringBuilder Buff = new StringBuilder(nChars);
                        if (GetWindowText((IntPtr)window.HWND, Buff, nChars) > 0)
                        {
                            return Buff.ToString();
                        }
                    }
                    else
                    {
                        value = currentFolder.Path;
                        return currentFolder.Path;
                    }
                }
            }

            // As a final fallback, return the path to the user's Desktop.
            string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            return (desktopPath);
        }

        // P/Invoke method declarations to call unmanaged functions from user32.dll.
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);

        /// <summary>
        /// Initializes the combo box for post-operation actions.
        /// </summary>
        private void InitializePostCopyActionComboBox()
        {
            // Populate the combo box with options for what the program should do after an operation is complete.
            onFinishComboBox.Items.AddRange(new string[]
            {
    "Do Nothing",
    "Sleep",
    "Log Off",
    "Exit Program",
    "Shut Down"
            });

            onFinishMultiComboBox.Items.AddRange(new string[]
{
    "Do Nothing",
    "Sleep",
    "Log Off",
    "Exit Program",
    "Shut Down"
});
        }

        /// <summary>
        /// Configures the application's "Always On Top" setting.
        /// </summary>
        /// <param name="alwaysOnTop">A boolean indicating whether the window should be the topmost window.</param>
        private void ConfigureAlwaysOnTop(bool alwaysOnTop)
        {
            // Set the form's TopMost property based on the setting.
            this.TopMost = alwaysOnTop;
        }

        /// <summary>
        /// Applies the language settings based on user preferences.
        /// The switch statement is a placeholder for future localization logic.
        /// </summary>
        private void ApplyLanguageSettings()
        {
            // Placeholder logic for applying different language settings.
            switch (CopyThatProgram.Properties.Settings.Default.Language)
            {
                case "English":
                    break;
                case "Inglés":
                    break;
                case "French":
                    break;
                case "Francés":
                    break;
                case "German":
                    break;
                case "Deutsch":
                    break;
                case "Spanish":
                    break;
                case "Español":
                    break;
            }
        }

        /// <summary>
        /// Applies the theme and font settings based on user preferences.
        /// </summary>
        /// 

        private void ApplyThemeSettings()
        {
            string savedSkinKey = CopyThatProgram.Properties.Settings.Default.Skin ?? "Light Mode";

            switch (savedSkinKey)
            {
                case "Dark Mode":
                    // Apply dark theme colors (Your existing color logic)
                    ChangeControlsForeColor(this, System.Drawing.Color.White);
                    ChangeControlsBackColor(this, System.Drawing.Color.Black);
                    ChangeControlColorsLabelsCheckBoxes(System.Drawing.Color.Transparent);
                    this.BackColor = System.Drawing.Color.Black;
                    filesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.Black; // Keep grid text readable
                    filesDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                    break;

                case "Medium Mode":
                    // Apply medium theme colors
                    ChangeControlsForeColor(this, System.Drawing.Color.Black);
                    ChangeControlsBackColor(this, System.Drawing.Color.Gainsboro);
                    ChangeControlColorsLabelsCheckBoxes(System.Drawing.Color.Transparent);
                    this.BackColor = System.Drawing.Color.Gainsboro;
                    filesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    filesDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                    break;

                case "Light Mode":
                    // Apply light theme colors
                    ChangeControlsForeColor(this, System.Drawing.Color.Black);
                    ChangeControlsBackColor(this, System.Drawing.Color.White);
                    ChangeControlColorsLabelsCheckBoxes(System.Drawing.Color.Transparent);
                    this.BackColor = System.Drawing.Color.White;
                    filesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    filesDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                    break;

                case "Custom Color":
                    // Apply custom theme colors read from settings
                    ChangeControlsBackColor(this, Properties.Settings.Default.CustomBackColor);
                    ChangeControlsForeColor(this, Properties.Settings.Default.CustomForeColor);
                    ChangeControlColorsLabelsCheckBoxes(System.Drawing.Color.Transparent);
                    this.BackColor = Properties.Settings.Default.CustomBackColor;
                    this.ForeColor = Properties.Settings.Default.CustomForeColor;
                    filesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.Black; // Keep grid text readable
                    filesDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                    break;

                default: // Fallback to Light Mode if key is unrecognized
                    ChangeControlsForeColor(this, System.Drawing.Color.Black);
                    ChangeControlsBackColor(this, System.Drawing.Color.White);
                    ChangeControlColorsLabelsCheckBoxes(System.Drawing.Color.Transparent);
                    this.BackColor = System.Drawing.Color.White;
                    filesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
                    filesDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
                    break;
            }

            this.Font = new System.Drawing.Font("Arial Regular", CopyThatProgram.Properties.Settings.Default.FontSize);
        }



        /// <summary>
        /// Asynchronously scans a directory and updates the UI with the found files and folders.
        /// This method uses an asynchronous approach to prevent the UI from freezing.
        /// </summary>
        /// <param name="path">The directory path to scan.</param>
        /// <param name="updateIntervalMs">The interval in milliseconds to update the UI with progress.</param>
        public async Task ScanDirectoryWithUpdatesAsync(string path, int updateIntervalMs = 10)
        {
            // Disable the DataGridView while scanning to prevent user interaction and visual glitches.
            filesDataGridView.Enabled = false;

            // Validation checks to ensure the path is valid and exists.
            if (string.IsNullOrWhiteSpace(path) || !Directory.Exists(path))
            {
                MessageBox.Show($"Invalid folder: {path}", "Scan Error",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var fullPath = System.IO.Path.GetFullPath(path).TrimEnd(System.IO.Path.DirectorySeparatorChar);
            _currentSourceRootPath = fullPath;

            // Check to prevent the user from trying to scan an entire drive.
            string root = System.IO.Path.GetPathRoot(fullPath).TrimEnd(System.IO.Path.DirectorySeparatorChar);
            if (string.Equals(root, fullPath, StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("You cannot scan an entire drive.", "Scan Not Allowed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Clear previous scan data.
            _fileList.Clear();
            _seenPaths.Clear();
            _grandTotalFileCount = 0;
            _totalDirs = 0;
            _totalBytesToProcess = 0;

            // Temporarily suspend UI layout updates for the DataGridView for performance.
            filesDataGridView.SuspendLayout();
            filesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            filesDataGridView.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.DisableResizing;

            // Define a set of folders to exclude from the scan.
            var exclude = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "$Recycle.Bin", "Recycle Bin", "System Volume Information"
    };

            // Define enumeration options for the directory scan.
            var options = new EnumerationOptions
            {
                RecurseSubdirectories = true,
                IgnoreInaccessible = true,
                AttributesToSkip = FileAttributes.System | FileAttributes.Hidden,
                ReturnSpecialDirectories = false
            };

            // Start the scanning process on a background thread to keep the UI responsive.
            await Task.Run(() => DoScan(exclude, options, updateIntervalMs));

            // Resume UI layout updates and re-enable controls after the scan is complete.
            filesDataGridView.ResumeLayout();
            EnableAllControls(this);
            if (onAddFilesCheckBox.Checked) PlayRes(Properties.Resources.OnAddFiles);
        }

        /// <summary>
        /// The core scanning logic that runs on a background thread.
        /// It enumerates files and folders and adds them to a batch for periodic UI updates.
        /// </summary>
        /// <param name="exclude">A set of folder names to exclude.</param>
        /// <param name="opts">The enumeration options.</param>
        /// <param name="intervalMs">The interval for flushing batches to the UI.</param>
        private void DoScan(HashSet<string> exclude, EnumerationOptions opts, int intervalMs)
        {
            var batch = new List<FileInfoWrapper>(512);
            var sw = Stopwatch.StartNew();

            /* ----------  NEW: add the root directory itself  ---------- */
            var rootDir = new DirectoryInfo(_currentSourceRootPath);
            if (!exclude.Contains(rootDir.Name))          // respect exclusion list
            {
                batch.Add(new FileInfoWrapper
                {
                    FileName = rootDir.Name,
                    FilePath = rootDir.FullName,
                    IsDirectory = true,
                    BytesRaw = 0,
                    FileSize = "<DIR>",
                    Status = "Pending"
                });
                Interlocked.Increment(ref _totalDirs);
            }
            /* ---------------------------------------------------------- */

            foreach (var entry in FastEnumerator.Enumerate(_currentSourceRootPath, opts))
            {
                if (_cancellationTokenSource?.IsCancellationRequested == true)
                    break;

                if (Exclude(entry, exclude))
                    continue;

                batch.Add(new FileInfoWrapper
                {
                    FileName = entry.Name,
                    FilePath = entry.FullPath,
                    IsDirectory = entry.IsDirectory,
                    BytesRaw = entry.Length,
                    FileSize = entry.IsDirectory ? "<DIR>" : FormatBytes(entry.Length),
                    Status = "Pending"
                });

                if (entry.IsDirectory)
                    Interlocked.Increment(ref _totalDirs);
                else
                {
                    Interlocked.Increment(ref _grandTotalFileCount);
                    Interlocked.Add(ref _totalBytesToProcess, entry.Length);
                }

                if (batch.Count >= 200 || sw.ElapsedMilliseconds >= intervalMs)
                {
                    var snapshot = batch.ToArray();
                    batch.Clear();
                    FlushBatch(snapshot);
                    sw.Restart();
                }
            }

            if (batch.Count > 0)
            {
                var snapshot = batch.ToArray();
                batch.Clear();
                FlushBatch(snapshot);
            }
        }
        /// <summary>
        /// Adds a batch of file information to the UI thread for display.
        /// </summary>
        /// <param name="snapshot">An array of FileInfoWrapper objects to add.</param>
        private void FlushBatch(FileInfoWrapper[] snapshot)
        {
            if (snapshot.Length == 0) return;

            // Capture the current counts for display.
            long filesSnap = _grandTotalFileCount;
            long bytesSnap = _totalBytesToProcess;

            // Format the strings on the worker thread to offload work from the UI thread.
            string fileText = $"File Count: 0 Out of {filesSnap:N0}";
            string byteText = $"Total C/M/D: 0 / {FormatBytes(bytesSnap)}";

            // Use BeginInvoke to add the batch to the UI thread's queue.
            this.BeginInvoke((Action)(() =>
            {
                // Use a lock to ensure thread-safe access to the _fileList.
                lock (_batchLock)
                {
                    foreach (var item in snapshot)
                    {
                        // Use a HashSet to prevent duplicate entries from being added to the list.
                        if (_seenPaths.Add(item.FilePath))
                        {
                            _fileList.Add(item);
                        }
                    }

                    // Update the UI labels with the new counts.
                    fileCountOnLabel.Text = fileText;
                    totalCopiedProgressLabel.Text = byteText;
                }
            }));
        }

        /// <summary>
        /// Checks if a file system entry should be excluded from the scan.
        /// </summary>
        /// <param name="e">The file system entry.</param>
        /// <param name="exclude">The set of excluded names.</param>
        /// <returns>True if the entry should be excluded, otherwise false.</returns>
        private static bool Exclude(FastFileSystemEntry e, HashSet<string> exclude)
        {
            // Check if any part of the full path contains an excluded name.
            foreach (var x in exclude)
            {
                if (e.FullPath.IndexOf(x, StringComparison.OrdinalIgnoreCase) >= 0)
                    return true;
            }
            return false;
        }

        /// <summary>
        /// Clears the DataGridView and resets all scan-related variables.
        /// </summary>
        private void ClearDataGridView()
        {
            // Create a new BindingList to clear the data.
            _fileList = new BindingList<FileInfoWrapper>();
            // Rebind the data source to the new, empty list.
            _bindingSource.DataSource = _fileList;
            filesDataGridView.DataSource = _bindingSource;

            // Force a refresh of the binding context to update the UI.
            CurrencyManager cm = (CurrencyManager)BindingContext[_bindingSource];
            cm.Refresh();

            // Reset all counters.
            _grandTotalFileCount = 0;
            _totalBytesToProcess = 0;
        }

        /// <summary>
        /// Updates the UI with the current scanning progress, showing the file being processed.
        /// </summary>
        /// <param name="currentPath">The path of the file currently being scanned.</param>
        /// <param name="currentCount">The current number of files found.</param>
        /// <param name="totalCount">The total number of files to be scanned (not used in this implementation).</param>
        private void UpdateScanProgress(string currentPath, int currentCount, int totalCount)
        {
            // Update the status and file path labels.
            statusLabel.Text = $"Scanning: {System.IO.Path.GetFileName(currentPath)}";
            filePathLabel.Text = currentPath;
        }

        /// <summary>
        /// Adds a batch of file items to the UI list and updates the progress labels.
        /// </summary>
        /// <param name="items">The list of items to add.</param>
        /// <param name="currentPath">The current path being scanned.</param>
        /// <param name="isFinalBatch">A flag to indicate if this is the last batch.</param>
        private void AddItemsBatchToUI(List<FileInfoWrapper> items, string currentPath, bool isFinalBatch)
        {
            foreach (var item in items)
                // Use Invoke to add each item to the UI list thread-safely.
                Invoke((Delegate)(() =>
                {
                    _fileList.Add(item);
                    // Auto-scroll the DataGridView to show the newly added item.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = filesDataGridView.RowCount - 1;
                }));

            // Update the status labels if it's not the final batch.
            if (!isFinalBatch)
            {
                statusLabel.Text = $"Adding: {System.IO.Path.GetFileName(currentPath)}";
                filePathLabel.Text = currentPath;
            }
        }

        /// <summary>
        /// Finalizes the UI updates after the scan is complete.
        /// This method ensures the DataGridView and other UI elements are correctly displayed with the final results.
        /// </summary>
        /// <param name="fileCount">The total number of files found.</param>
        /// <param name="dirCount">The total number of directories found.</param>
        /// <param name="totalBytes">The total size in bytes of all files.</param>
        private void CompleteScanUpdate(int fileCount, int dirCount, long totalBytes)
        {
            // Re-enable binding events.
            _bindingSource.RaiseListChangedEvents = true;

            // Force the data source to refresh its bindings.
            _bindingSource.ResetBindings(false);

            // Invalidate and refresh the DataGridView and its parent to ensure all changes are rendered.
            filesDataGridView.Invalidate(true);
            filesDataGridView.Update();
            filesDataGridView.Refresh();

            if (filesDataGridView.Parent != null)
            {
                filesDataGridView.Parent.Invalidate(true);
                filesDataGridView.Parent.Update();
            }

            // A workaround to force a full re-render of the DataGridView.
            var tempDataSource = _bindingSource.DataSource;
            _bindingSource.DataSource = null;
            _bindingSource.DataSource = tempDataSource;

            // Update the final counters and labels with the total scan results.
            _grandTotalFileCount = fileCount;
            _totalBytesToProcess = totalBytes;

            fileCountOnLabel.Text = $"File Count: 0 Out of {_grandTotalFileCount:N0}";
            totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / {FormatBytes(_totalBytesToProcess)}";
            fromFilesDirLabel.Text = $"Scan complete: {_grandTotalFileCount:N0} files and {dirCount:N0} folders || {FormatBytes(_totalBytesToProcess)} total";
            statusLabel.Text = $"Scan complete: {_totalFileCount:N0} files…";
            filePathLabel.Text = "Ready";
        }


        /// <summary>
        /// This method is intended to update the UI with scan progress information.
        /// However, it has a logical flaw: it adds new files to the list both before and after checking `InvokeRequired`.
        /// This can lead to duplicate entries and an error if called from a non-UI thread without proper handling.
        /// </summary>
        /// <param name="currentFileCount">The current number of files found (not used correctly).</param>
        /// <param name="currentTotalSize">The current total size of files found (not used correctly).</param>
        /// <param name="newFiles">A list of new FileInfoWrapper objects to add to the UI.</param>
        private void UpdateScanProgressUI(long currentFileCount, long currentTotalSize, List<FileInfoWrapper> newFiles)
        {
            // This loop adds files to the list on the calling thread, which could be a background thread.
            // This is problematic because `_fileList` is bound to the UI, so it should only be modified on the UI thread.
            foreach (var fileInfo in newFiles)
            {
                _fileList.Add(fileInfo);
            }

            // Checks if the method is being called from a different thread than the one that created the control.
            if (this.InvokeRequired)
            {
                // If so, it uses `Invoke` to call the method again on the UI thread, ensuring thread safety.
                // The return statement prevents the rest of the method from executing on the background thread.
                this.Invoke(new Action(() => UpdateScanProgressUI(currentFileCount, currentTotalSize, newFiles)));
                return;
            }

            // Checks if the `fileCountOnLabel` control exists.
            if (fileCountOnLabel != null)
            {
                // Updates the text of the label with the total file count.
                fileCountOnLabel.Text = $"File Count: 0 Out of " + _grandTotalFileCount.ToString("N0") + "";
            }
            // Checks if the `totalCopiedProgressLabel` control exists.
            if (totalCopiedProgressLabel != null)
            {
                // Updates the text of the label with the total size of files to be processed.
                totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / {FormatBytes(_totalBytesToProcess)}";
            }

            // This is the second time the files are being added, which will result in duplicate entries.
            foreach (var item in newFiles)
            {
                _fileList.Add(item);
            }
        }


        /// <summary>
        /// Recursively disables all controls within a given parent control.
        /// </summary>
        /// <param name="parent">The parent control whose children should be disabled.</param>
        private void DisableAllControls(System.Windows.Forms.Control parent)
        {
            // Iterates through each control in the parent's control collection.
            foreach (System.Windows.Forms.Control ctrl in parent.Controls)
            {
                // Sets the `Enabled` property of the current control to false.
                ctrl.Enabled = false;

                // If the current control has child controls, it calls itself recursively.
                if (ctrl.HasChildren)
                {
                    DisableAllControls(ctrl);
                }
            }
        }
        /// <summary>
        /// An array of strings representing the size suffixes (Bytes, KB, MB, etc.).
        /// </summary>
        private static readonly string[] Suffixes =
        {
    "Bytes", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB"
};

        /// <summary>
        /// Formats a number of bytes into a human-readable string with a size suffix.
        /// </summary>
        /// <param name="bytes">The number of bytes.</param>
        /// <param name="decimalPlaces">The number of decimal places to round to.</param>
        /// <returns>A formatted string (e.g., "1.23 GB").</returns>
        private static string FormatBytes(long bytes, int decimalPlaces = 2)
        {
            // If the number of bytes is 0, return "0 Bytes".
            if (bytes == 0) return "0 Bytes";

            double size = bytes;
            int idx = 0;

            // A series of if/else if statements to determine the correct suffix and value.
            // It checks for Terabytes, Gigabytes, Megabytes, and Kilobytes.
            if (bytes >= (1L << 40))
            {
                size = bytes / (double)(1L << 40);
                idx = 4; // TB
            }
            else if (bytes >= (1L << 30))
            {
                size = bytes / (double)(1L << 30);
                idx = 3; // GB
            }
            else if (bytes >= (1L << 20))
            {
                size = bytes / (double)(1L << 20);
                idx = 2; // MB
            }
            else if (bytes >= 1024)
            {
                size = bytes / 1024d;
                idx = 1; // KB
            }

            // Rounds the size to the specified number of decimal places.
            size = Math.Round(size, decimalPlaces);

            // Returns the formatted string using string interpolation.
            return $"{size.ToString($"F{decimalPlaces}")} {Suffixes[idx]}";
        }

        /// <summary>
        /// Attempts to parse a formatted size string (e.g., "1.23 GB") back into a long integer of bytes.
        /// </summary>
        /// <param name="input">The formatted string to parse.</param>
        /// <param name="result">The parsed long value if successful.</param>
        /// <returns>True if parsing was successful, otherwise false.</returns>
        public static bool TryParseFormattedSize(string input, out long result)
        {
            result = 0;

            // Returns false if the input string is null.
            if (input == null)
            {
                return false;
            }

            // Defines the suffixes to check for.
            string[] suffixes = { "Bytes", "KB", "MB", "GB", "TB" };
            // Trims whitespace from the input string.
            input = input.Trim();

            // Loops through the suffixes in reverse order (from largest to smallest).
            for (int i = suffixes.Length - 1; i >= 0; i--)
            {
                string suffix = suffixes[i];
                // Checks if the input string ends with the current suffix.
                if (input.EndsWith(suffix, StringComparison.OrdinalIgnoreCase))
                {
                    // Extracts the numeric part of the string.
                    string numberPart = input[..^suffix.Length].Trim();

                    // Tries to parse the numeric part as a double.
                    if (double.TryParse(numberPart, NumberStyles.Any, CultureInfo.InvariantCulture, out double number))
                    {
                        // Calculates the multiplier for the current suffix.
                        long multiplier = 1L << (i * 10);

                        // Checks for potential overflow before multiplication.
                        if (number > 0 && number > (double)long.MaxValue / multiplier)
                        {
                            result = long.MaxValue;
                            return false;
                        }
                        else if (number < 0 && number < (double)long.MinValue / multiplier)
                        {
                            result = long.MinValue;
                            return false;
                        }

                        // Calculates the final result in bytes and returns true.
                        result = (long)(number * multiplier);
                        return true;
                    }
                }
            }

            // As a fallback, try to parse the entire input as a simple long integer.
            if (long.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out result))
            {
                return true;
            }

            return false;
        }
        /// <summary>
        /// Recursively enables all controls within a given parent control.
        /// </summary>
        /// <param name="parent">The parent control whose children should be enabled.</param>
        private void EnableAllControls(System.Windows.Forms.Control parent)
        {
            try
            {
                // Iterates through each control in the parent's control collection.
                foreach (System.Windows.Forms.Control ctrl in parent.Controls)
                {
                    // Sets the `Enabled` property of the current control to true.
                    ctrl.Enabled = true;

                    // If the current control has child controls, it calls itself recursively.
                    if (ctrl.HasChildren)
                    {
                        EnableAllControls(ctrl);
                    }
                }
            }
            catch { } // An empty catch block, which is generally bad practice as it can hide errors.
        }

        /// <summary>
        /// Initializes a `Progress` object to handle and report progress updates to the UI.
        /// </summary>
        private void InitializeProgressHandler()
        {
            // Creates a new Progress object with an action to be executed when progress is reported.
            progress = new Progress<ProgressReport>(report =>
            {
                totalProgressBar.Value = report.PercentComplete;
                // Forces the progress bar to repaint itself.
                totalProgressBar.Refresh();

                // Updates the text of the file path label.
                fromFilesDirLabel.Text = report.CurrentFile;
                // Forces the label to repaint.
                fromFilesDirLabel.Refresh();
                // Updates the text of the speed label.
                speedLabel.Text = $"{report.Speed:0.00} MB/s";
                // Forces the speed label to repaint.
                speedLabel.Refresh();
            });
        }
        /// <summary>
        /// Calculates the data transfer speed in MB/s based on total bytes copied and elapsed time.
        /// </summary>
        /// <param name="totalBytesCopied">The total number of bytes copied.</param>
        /// <returns>The speed in megabytes per second.</returns>
        private double CalculateSpeed(long totalBytesCopied)
        {
            // Gets the elapsed time in seconds from a stopwatch.
            double elapsedTimeInSeconds = _stopwatch.Elapsed.TotalSeconds;
            // Returns 0 if no time has elapsed to avoid division by zero. Otherwise, calculates and returns the speed.
            return elapsedTimeInSeconds > 0 ? (totalBytesCopied / elapsedTimeInSeconds) / 1024 / 1024 : 0;
        }
        /// <summary>
        /// Displays a message box with a summary of a file operation.
        /// </summary>
        /// <param name="title">The title of the message box.</param>
        /// <param name="status">The status of the operation (e.g., "Complete", "Canceled").</param>
        /// <param name="operation">The type of file operation (e.g., Copy, Move).</param>
        /// <param name="totalFilesConsidered">The total number of files considered in the operation.</param>
        private void ShowOperationSummaryMessageBox(string title, string status, FileOperation operation, int totalFilesConsidered)
        {
            // Gets the name of the operation from the enum.
            string operationName = operation.ToString();
            // Constructs the message string with a summary of the operation statistics.
            string message = $"----- {operationName} Operation Summary ({status}) -----\n\n" +
                             $"Total files considered: {totalFilesConsidered:N0}\n" +
                             $"Files copied: {_processedFiles:N0} / {_grandTotalFileCount:N0}\n" +
                             $"Files skipped (by filter/user): {_totalFilesSkipped:N0}\n" +
                             $"Files failed (due to error): {_totalFilesFailed:N0}\n\n" +
                             $"Total bytes processed: {FormatBytes(_totalBytesProcessed)}\n\n" +
                             $"Total bytes to process (estimated): {FormatBytes(_totalBytesToProcess)}\n\n" +
                             $"{operationName} {status}!";

            // Sets the icon of the message box based on the operation's status.
            MessageBoxIcon icon = MessageBoxIcon.Information;
            if (status == "Cancelled")
            {
                icon = MessageBoxIcon.Warning;
            }
            else if (status == "Failed")
            {
                icon = MessageBoxIcon.Error;
            }

            // Displays the message box.
            MessageBox.Show(message, title, MessageBoxButtons.OK, icon);
        }
        /// <summary>
        /// A setter method for a private folder path field.
        /// </summary>
        /// <param name="path">The folder path string to set.</param>
        public void SetFolderPath(string path)
        {
            folderPath = path;
        }
        /// <summary>
        /// A nested class representing a progress report.
        /// It contains properties to hold information about the current state of a task.
        /// </summary>
        public class ProgressReport
        {
            public int PercentComplete { get; set; }
            public string CurrentFile { get; set; }
            public string FilePath { get; set; }
            public double Speed { get; set; }
            public string Status { get; set; }
            public long BytesCopied { get; set; }
        }
        /// <summary>
        /// Plays a system sound based on the type of event and user settings.
        /// </summary>
        /// <param name="soundType">A string indicating which sound to play (e.g., "CopyComplete").</param>
        private void PlaySound(string soundType)
        {
            // A switch statement to handle different sound types.
            switch (soundType)
            {
                case "CopyComplete":
                    // Plays a sound if the setting for "SoundCopyComplete" is enabled.
                    if (CopyThatProgram.Properties.Settings.Default.SoundCopyComplete)
                        SystemSounds.Asterisk.Play();
                    break;
                case "FileAdded":
                    // Plays a sound if the setting for "SoundFileAdded" is enabled.
                    if (CopyThatProgram.Properties.Settings.Default.SoundFileAdded)
                        SystemSounds.Exclamation.Play();
                    break;
            }
        }
        /// <summary>
        /// Logs a file that was skipped during the operation.
        /// </summary>
        /// <param name="fileItem">The `FileInfoWrapper` object for the skipped file.</param>
        /// <param name="reason">The reason the file was skipped (e.g., "File already exists").</param>
        /// <param name="intendedTargetPath">The intended destination path of the file.</param>
        private void HandleSkippedFile(FileInfoWrapper fileItem, string reason, string intendedTargetPath)
        {
            // Calls a method to add the skipped file to a log.
            AddToSkippedFiles(
                reason,
                fileItem.FileName,
                fileItem.BytesRaw,
                fileItem.FilePath,
                intendedTargetPath,
                ""
            );
        }
        /// <summary>
        /// Logs a file that caused an error during the operation.
        /// </summary>
        /// <param name="fileItem">The `FileInfoWrapper` object for the errored file.</param>
        /// <param name="errorMessage">The specific error message.</param>
        /// <param name="intendedTargetPath">The intended destination path of the file.</param>
        private void HandleErrorFile(FileInfoWrapper fileItem, string errorMessage, string intendedTargetPath)
        {
            // Ignores directories, only logs file errors.
            if (fileItem.IsDirectory)
                return;

            // Calls a method to add the errored file to a log.
            AddToSkippedFiles(
                "Error",
                fileItem.FileName,
                fileItem.BytesRaw,
                fileItem.FilePath,
                intendedTargetPath,
                errorMessage
            );
        }
        /// <summary>
        /// Initializes the timer for a form animation.
        /// </summary>
        private void InitializeRollAnimation()
        {
            // Creates a new Timer object.
            rollTimer = new Timer();
            // Sets the timer's interval to 10 milliseconds.
            rollTimer.Interval = 10;
            // Wires the `RollTimer_Tick` method to the timer's `Tick` event.
            rollTimer.Tick += RollTimer_Tick;
        }

        /// <summary>
        /// Changes the application's icon in the taskbar.
        /// </summary>
        /// <param name="iconPath">The file path of the new icon.</param>
        private void ChangeTaskbarIcon(string iconPath)
        {
            try
            {
                // Creates a new Icon object from the specified path.
                Icon newIcon = new Icon(iconPath);
                // Sets the form's `Icon` property to the new icon.
                this.Icon = newIcon;
            }
            catch (Exception ex)
            {
                // Shows a message box if the icon fails to load.
                MessageBox.Show($"Failed to load icon: {ex.Message}");
            }
        }

        // Fields for a context menu and hover color.
        private ContextMenuStrip exportMenu;
        private readonly System.Drawing.Color HoverColor = SystemColors.Control;

        /// <summary>
        /// An event handler for when the mouse enters a label.
        /// It changes the label's background color to the hover color.
        /// </summary>
        /// <param name="sender">The label control that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Label_MouseEnter(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            lbl.BackColor = HoverColor;
        }

        /// <summary>
        /// An event handler for when the mouse leaves a label.
        /// It restores the label's original background color.
        /// </summary>
        /// <param name="sender">The label control that triggered the event.</param>
        /// <param name="e">The event arguments.</param>
        private void Label_MouseLeave(object sender, EventArgs e)
        {
            var lbl = (Label)sender;
            // Restores the background color from the `Tag` property, which was saved previously.
            lbl.BackColor = (System.Drawing.Color)lbl.Tag;
        }

        /// <summary>
        /// Wires the mouse enter and leave event handlers to a predefined set of labels.
        /// </summary>
        private void WireHoverLabels()
        {
            // An array of labels to apply the hover effect to.
            Label[] labels =
            {
        rollUpLabel, rollDownLabel, settingsLabel,
        exitLabel, minimizeLabel, allAboutLabel
    };

            // Iterates through each label in the array.
            foreach (var lbl in labels)
            {
                if (lbl == null) continue;

                // Sets the initial background color to transparent and stores it in the `Tag` property.
                lbl.BackColor = System.Drawing.Color.Transparent;
                lbl.Tag = System.Drawing.Color.Transparent;
                // Wires the `MouseEnter` and `MouseLeave` event handlers.
                lbl.MouseEnter += Label_MouseEnter;
                lbl.MouseLeave += Label_MouseLeave;
            }
        }

        private void TabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            if (allowTabChanges)
            {
                e.Cancel = false;
            }
            else
            {
                e.Cancel = false;
            }
        }

        /// <summary>
        /// Hides all tabs except the currently selected tab, effectively showing only one tab at a time.
        /// This method is useful for creating a focused or simplified view of the tab control.
        /// </summary>
        private void ShowOnlyCurrentTab()
        {
            var currentTab = tabControl1.SelectedTab;
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.Add(currentTab);
        }

        /// <summary>
        /// Restores all previously hidden tabs to the tab control, returning to the full tab view.
        /// This method reverses the effect of ShowOnlyCurrentTab and displays all available tabs.
        /// </summary>
        private void ShowAllTabs()
        {
            tabControl1.TabPages.Clear();
            tabControl1.TabPages.AddRange(allTabs.ToArray());
        }
        /// <summary>
        /// Navigates to the specified tab page and displays it as the only visible tab.
        /// Temporarily allows tab changes during navigation to prevent interference with change event handlers.
        /// </summary>
        /// <param name="targetTab">The tab page to navigate to and display exclusively</param>
        public void NavigateToTab(TabPage targetTab)
        {
            allowTabChanges = true;
            tabControl1.SelectedTab = targetTab;
            allowTabChanges = false;
            ShowOnlyCurrentTab();
        }


        private bool _isLoadingForm = false;

        private static readonly Dictionary<string, string> LangKeyToDisplay =
            new(StringComparer.OrdinalIgnoreCase)
        {
    {"English", "English"},
    {"Spanish", "Español"},
    {"French",  "Français"},
    {"German",  "Deutsch"}
        };






        // ==================== MAIN FORM LOAD ====================
        private void MainForm_Load(object sender, EventArgs e)
        {
            _multiThreadUiTimer.Interval = 500; // update UI every 0.5s
            _multiThreadUiTimer.Tick += UpdateMultiThreadUiTimer_Tick;

            _isUpdatingLanguage = true;
            _isLoadingForm = true;

            languageComboBox.SelectedIndexChanged -= languageComboBox_SelectedIndexChanged;
            skinsComboBox.SelectedIndexChanged -= skinsComboBox_SelectedIndexChanged;

            try
            {
                string savedLangKey = Properties.Settings.Default.Language ?? "English";
                string savedSkinKey = Properties.Settings.Default.Skin ?? "Light Mode";

                // SET THE CULTURE FIRST based on saved language
                string culture = savedLangKey switch
                {
                    "Spanish" => "es-ES",
                    "French" => "fr-FR",
                    "German" => "de-DE",
                    _ => "en"
                };
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

                InitializeLanguageComboBox(savedLangKey);
                UpdateSkinsComboBoxItems(savedLangKey);
                LoadCurrentSettings();

                // Apply localized .resx resources
                var resMan = new ComponentResourceManager(typeof(mainForm));
                ApplyAllResources(resMan);

                // Apply manual translations for Spanish/English
                if (savedLangKey == "Spanish")
                    ApplyManualSpanishUpdates();
                else
                    ApplyManualEnglishUpdates();

                allTabs.AddRange(tabControl1.TabPages.Cast<TabPage>());
                tabControl1.Selecting += TabControl1_Selecting;
                InitializeResetButton();
                TotalsManager.LoadTotalsIntoLabels(
                    totalCopyOperationsLabel, totalMoveOperationsLabel, totalDeleteOperationsLabel,
                    totalCancelledOperationsLabel, totalCompletedOperationsLabel,
                    totalFilesConsideredLabel, totalFilesCopiedLabel, totalFilesMovedLabel,
                    totalFilesDeletedLabel, totalFilesSkippedLabel, totalFilesFailedLabel,
                    totalBytesProcessedLabel, totalBytesToProcessLabel,
                    totalElapsedTimeLabel, totalTargetTimeLabel,
                    resetTotalsButton);
                CleanupOldVersions();
                WireHoverLabels();

                CheckForIllegalCrossThreadCalls = false;
                _bindingSource.DataSource = _fileList;
                filesDataGridView.DataSource = _bindingSource;
                filesDataGridView.AutoGenerateColumns = false;

                InitializeDataGridView();
                InitializeRollAnimation();
                proVersion = true;
                titleLabel.Text = proVersion ? "Copy That v1.0 Pro - File/Directory Tool - Home"
                                             : "Copy That v1.0 - File/Directory Tool - Home";

                overwriteOption = "Overwrite Type - If Newer";
                fileProgressBar.Value = 0;
                totalProgressBar.Value = 0;
                startButton.Enabled = true;
                pauseResumeButton.Enabled = false;
                cancelButton.Enabled = false;
                allowedTextBox.Text = "*.";
                excludedTextBox.Text = "*.";
                isInitialized = true;
                this.MinimumSize = Size.Empty;
                tabControl1.MinimumSize = Size.Empty;

                if (!string.IsNullOrEmpty(folderPath))
                    ProcessFolder(folderPath);

                if (this.WindowState == FormWindowState.Normal)
                    notifyIcon1.Visible = false;

                InitializePostCopyActionComboBox();
                InitializeOperationComboBox();

                if (onFinishComboBox.SelectedIndex == -1) onFinishComboBox.SelectedIndex = 0;
                if (onFinishMultiComboBox.SelectedIndex == -1) onFinishMultiComboBox.SelectedIndex = 0;
                if (copyMoveDeleteComboBox.SelectedIndex == -1) copyMoveDeleteComboBox.SelectedIndex = 0;

                TranslateGridHeaders();
                _bindingSource.ResetBindings(false);

                this.MinimumSize = new Size(tabControl1.Right + 1, titleLabel.Bottom);
                this.MaximumSize = new Size(tabControl1.Right + 1, tabControl1.Bottom + 1);
                this.Size = this.MaximumSize;
                StoreOriginalSize();

                // Select the skin in ComboBox (but don't apply colors yet)
                SelectSkinInCombo(savedSkinKey);
            }
            finally
            {
                _isUpdatingLanguage = false;
                _isLoadingForm = false; // CRITICAL: Set to false here!

                languageComboBox.SelectedIndexChanged += languageComboBox_SelectedIndexChanged;
                skinsComboBox.SelectedIndexChanged += skinsComboBox_SelectedIndexChanged;
            }
        }

        private static string FormatTime(double seconds)
        {
            if (seconds < 60)
                return $"{seconds:F0}s";
            if (seconds < 3600)
                return $"{seconds / 60:F1}m";
            return $"{seconds / 3600:F1}h";
        }

        private static string FormatSpeed(double bytesPerSec)
        {
            const double KB = 1024.0;
            const double MB = KB * 1024.0;
            const double GB = MB * 1024.0;

            if (bytesPerSec >= GB)
                return $"{bytesPerSec / GB:F2} GB/s";
            if (bytesPerSec >= MB)
                return $"{bytesPerSec / MB:F2} MB/s";
            if (bytesPerSec >= KB)
                return $"{bytesPerSec / KB:F2} KB/s";
            return $"{bytesPerSec:F0} B/s";
        }



        // ==================== MAIN FORM SHOWN ====================
        private void MainForm_Shown(object sender, EventArgs e)
        {
            // Apply skin colors AFTER the form is fully shown
            string savedSkinKey = Properties.Settings.Default.Skin ?? "Light Mode";

            if (savedSkinKey == "Custom Color")
            {
                var savedBack = Properties.Settings.Default.CustomBackColor;
                var savedFore = Properties.Settings.Default.CustomForeColor;

                // Validate custom colors (check if alpha is non-zero)
                if (savedBack.A != 0 && savedFore.A != 0)
                {
                    ApplySkin("Custom Color", savedFore, savedBack);
                    System.Diagnostics.Debug.WriteLine($"[SHOWN] Applied Custom Color - Back: {savedBack}, Fore: {savedFore}");
                }
                else
                {
                    // Fallback to Light Mode if custom colors are invalid
                    System.Diagnostics.Debug.WriteLine("[SHOWN] Custom Color invalid, falling back to Light Mode");
                    ApplySkin("Light Mode");
                    CopyThatProgram.Properties.Settings.Default.Skin = "Light Mode";
                    SelectSkinInCombo("Light Mode");
                    if (saveAutoCheckBox.Checked)
                        CopyThatProgram.Properties.Settings.Default.Save();
                }
            }
            else
            {
                // Apply standard skin
                ApplySkin(savedSkinKey);
                System.Diagnostics.Debug.WriteLine($"[SHOWN] Applied skin: {savedSkinKey}");
            }
        }

        // ==================== INITIALIZE LANGUAGE COMBOBOX ====================
        private void InitializeLanguageComboBox(string language)
        {
            languageComboBox.Items.Clear();
            languageComboBox.Items.AddRange(language switch
            {
                "Spanish" => new[] { "Inglés", "Francés", "Deutsch", "Español" },  // FIXED: Match pattern
                "French" => new[] { "Anglais", "Français", "Allemand", "Espagnol" },
                "German" => new[] { "Englisch", "Französisch", "Deutsch", "Spanisch" },
                _ => new[] { "English", "French", "German", "Spanish" }
            });
            languageComboBox.SelectedItem = LangKeyToDisplay.TryGetValue(language, out var d) ? d : language;
        }

        // ==================== APPLY SKIN ====================
        private void ApplySkin(string englishKey, Color? foreColor = null, Color? backColor = null)
        {
            // FIXED: Guard against both flags
            if (_isUpdatingLanguage || _isLoadingForm) return;

            try
            {
                this.SuspendLayout();

                // Determine the colors to use
                Color fg;
                Color bg;

                switch (englishKey)
                {
                    case "Dark Mode":
                        fg = foreColor ?? Color.White;
                        bg = backColor ?? Color.Black;
                        break;

                    case "Medium Mode":
                        fg = foreColor ?? Color.Black;
                        bg = backColor ?? Color.Gainsboro;
                        break;

                    case "Light Mode":
                        fg = foreColor ?? Color.Black;
                        bg = backColor ?? Color.White;
                        break;

                    case "Custom Color":
                        // For custom color, use provided colors or load from settings
                        if (foreColor.HasValue && backColor.HasValue)
                        {
                            fg = foreColor.Value;
                            bg = backColor.Value;
                        }
                        else
                        {
                            // Load saved custom colors if not provided
                            fg = CopyThatProgram.Properties.Settings.Default.CustomForeColor;
                            bg = CopyThatProgram.Properties.Settings.Default.CustomBackColor;
                        }
                        break;

                    default:
                        fg = foreColor ?? Color.Black;
                        bg = backColor ?? Color.White;
                        break;
                }

                // Apply to form
                this.BackColor = bg;
                this.ForeColor = fg;

                // Apply to all child controls
                foreach (System.Windows.Forms.Control ctrl in this.Controls)
                    ApplyColorsToControl(ctrl, fg, bg);

                // Update title bar
                string displayName = ToDisplay(englishKey);
                this.Text = $"Copy That v1.0 - {displayName}";

                this.ResumeLayout(true);
                this.Refresh();

                System.Diagnostics.Debug.WriteLine($"[ApplySkin] Applied '{englishKey}' - ForeColor: {fg}, BackColor: {bg}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error applying skin '{englishKey}': {ex.Message}");
            }
        }

        // ==================== HELPER METHODS ====================
        private void UpdateSkinsComboBoxItems(string languageKey)
        {
            skinsComboBox.Items.Clear();

            switch (languageKey)
            {
                case "Spanish":
                    skinsComboBox.Items.AddRange(new[] { "Modo Claro", "Modo Medio", "Modo Oscuro", "_________________", "Color Personalizado" });
                    break;
                case "French":
                    skinsComboBox.Items.AddRange(new[] { "Mode Clair", "Mode Moyen", "Mode Sombre", "_________________", "Couleur Personnalisée" });
                    break;
                case "German":
                    skinsComboBox.Items.AddRange(new[] { "Heller Modus", "Mittlerer Modus", "Dunkler Modus", "_________________", "Benutzerdefinierte Farbe" });
                    break;
                default: // English
                    skinsComboBox.Items.AddRange(new[] { "Light Mode", "Medium Mode", "Dark Mode", "_________________", "Custom Color" });
                    break;
            }
        }

        private void SelectSkinInCombo(string englishKey)
        {
            if (skinsComboBox == null || skinsComboBox.Items.Count == 0) return;

            string localizedDisplay = ToDisplay(englishKey);
            int index = skinsComboBox.Items.IndexOf(localizedDisplay);

            if (index != -1)
            {
                skinsComboBox.SelectedIndex = index;
            }
            else
            {
                // Fallback: try English key directly
                index = skinsComboBox.Items.IndexOf(englishKey);
                if (index != -1)
                {
                    skinsComboBox.SelectedIndex = index;
                }
                else
                {
                    // Last resort: default to first item
                    skinsComboBox.SelectedIndex = 0;
                }
            }
        }

        private string ToDisplay(string englishKey)
        {
            if (!SkinLocalized.TryGetValue(englishKey, out var translations))
                return englishKey;

            string currentLang = languageComboBox.SelectedItem?.ToString() ?? "English";

            return currentLang switch
            {
                "Español" or "Spanish" => translations.Spanish,
                "Français" or "French" => translations.French,
                "Deutsch" or "German" => translations.German,
                _ => englishKey
            };
        }

        private string ToEn(string display) => display switch
        {
            "Modo Claro" or "Mode Clair" or "Heller Modus" => "Light Mode",
            "Modo Medio" or "Mode Moyen" or "Mittlerer Modus" => "Medium Mode",
            "Modo Oscuro" or "Mode Sombre" or "Dunkler Modus" => "Dark Mode",
            "Color Personalizado" or "Couleur Personnalisée" or "Benutzerdefinierte Farbe" => "Custom Color",
            _ => display
        };

        private void ApplyColorsToControl(System.Windows.Forms.Control ctrl, Color fore, Color back)
        {
            ctrl.ForeColor = fore;
            ctrl.BackColor = back;

            foreach (System.Windows.Forms.Control child in ctrl.Controls)
                ApplyColorsToControl(child, fore, back);
        }

        private static readonly Dictionary<string, (string Spanish, string French, string German)> SkinLocalized =
            new(StringComparer.OrdinalIgnoreCase)
        {
    { "Light Mode", ("Modo Claro", "Mode Clair", "Heller Modus") },
    { "Medium Mode", ("Modo Medio", "Mode Moyen", "Mittlerer Modus") },
    { "Dark Mode", ("Modo Oscuro", "Mode Sombre", "Dunkler Modus") },
    { "Custom Color", ("Color Personalizado", "Couleur Personnalisée", "Benutzerdefinierte Farbe") }
        };

        /// <summary>
        /// Translates the header text of the DataGridView columns using a resource manager.
        /// </summary>
        private void TranslateGridHeaders()
        {
            // Creates a new resource manager.
            var rm = new ComponentResourceManager(typeof(mainForm));
            // Iterates through several DataGridViews.
            foreach (var grid in new[] { filesDataGridView, dataGridView1, dataGridView2 })
            {
                // Iterates through each column in the current DataGridView.
                foreach (DataGridViewColumn col in grid.Columns)
                    // Retrieves the translated header text from resources; if not found, keeps the original text.
                    col.HeaderText = rm.GetString($"{grid.Name}.Header.{col.Name}") ?? col.HeaderText;
            }
            // Repeats the process for the `skippedDataGridView`.
            foreach (DataGridViewColumn col in skippedDataGridView.Columns)
                col.HeaderText = rm.GetString($"skippedDataGridView.Header.{col.Name}") ?? col.HeaderText;
            // Repeats the process for the `copyHistoryDGV`.
            foreach (DataGridViewColumn col in copyHistoryDGV.Columns)
                col.HeaderText = rm.GetString($"copyHistoryDGV.Header.{col.Name}") ?? col.HeaderText;
        }
        /// <summary>
        /// Gets a list of file and directory paths from the main DataGridView,
        /// based on the state of the "full paths" and "only names" check boxes.
        /// </summary>
        /// <returns>A list of strings representing the file/directory paths.</returns>
        public List<string> GetDataGridViewData()
        {
            // Initializes a new list to store the data.
            List<string> data = new List<string>();

            // Iterates through each row in the `filesDataGridView`.
            foreach (DataGridViewRow row in filesDataGridView.Rows)
            {
                // Checks if the "full paths" check box is checked.
                if (fullPathsCheckBox.Checked == true)
                {
                    // Retrieves the value from the first cell of the current row (assumed to be the full path).
                    object cellValueFullPath = row.Cells[0].Value;

                    // Checks if the cell value is not null.
                    if (cellValueFullPath != null)
                    {
                        // Checks if the path is a directory.
                        if (Directory.Exists(cellValueFullPath.ToString()))
                        {
                            // If it's a directory, it enumerates all files within it and adds their paths to the list.
                            foreach (var sourceFilePath in Directory.EnumerateFiles(cellValueFullPath.ToString(), "*", System.IO.SearchOption.AllDirectories))
                            {
                                data.Add(sourceFilePath.ToString());
                            }
                        }
                        else
                        {
                            // If it's a file, it adds the full path to the list.
                            data.Add(cellValueFullPath.ToString());
                        }
                    }
                }
                // Checks if the "only names" check box is checked.
                else if (onlyNamesCheckBox.Checked == true)
                {
                    // Retrieves the value from the second cell of the current row (assumed to be the file/directory name).
                    object cellValueFileDirNames = row.Cells[1].Value;

                    // Checks if the cell value is not null.
                    if (cellValueFileDirNames != null)
                    {
                        // Checks if the path (name) is a directory. Note: This logic seems flawed as `Directory.Exists`
                        // needs a full path, not just a name.
                        if (Directory.Exists(cellValueFileDirNames.ToString()))
                        {
                            // If it's a directory, it enumerates all files within it and adds their paths to the list.
                            foreach (var sourceFilePath in Directory.EnumerateFiles(cellValueFileDirNames.ToString(), "*", System.IO.SearchOption.AllDirectories))
                            {
                                data.Add(sourceFilePath.ToString());
                            }
                        }
                        else
                        {
                            // If it's a file, it adds the path (name) to the list.
                            data.Add(cellValueFileDirNames.ToString());
                        }
                    }
                }
            }
            // Returns the final list of data.
            return data;
        }

        /// <summary>
        /// Exports a list of strings to a specified file path.
        /// </summary>
        /// <param name="filePath">The path of the file to write to.</param>
        /// <param name="data">The list of strings to export.</param>
        public void ExportDataToFile(string filePath, List<string> data)
        {
            // Uses a `StreamWriter` to write the data to the file, ensuring the writer is properly disposed.
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Iterates through the list of strings.
                foreach (var item in data)
                {
                    // Writes each string to a new line in the file.
                    sw.WriteLine(item);
                }
            }
        }
        /// <summary>
        /// Processes a folder, adding its contents to the file list and starting a background worker.
        /// This method also handles UI state changes like enabling/disabling controls.
        /// </summary>
        /// <param name="folderPath">The path of the folder to process.</param>
        private void ProcessFolder(string folderPath)
        {
            // If the "always on top" option is checked, temporarily disables it.
            if (alwaysOnTopCheckBox.Checked == true)
            {
                this.TopMost = false;
            }
            // Sets a flag to prevent drag and drop operations.
            noDragDrop = true;

            // Sets the default foreground color for the rows in the DataGridView.
            this.filesDataGridView.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;

            // Disables a large number of UI controls to prevent user interaction during processing.
            startButton.Enabled = false;
            clearFileListButton.Enabled = false;
            cancelButton.Enabled = false;
            removeFileButton.Enabled = false;
            skipButton.Enabled = false;
            addFileButton.Enabled = false;
            doNotOverwriteCheckBox.Enabled = false;
            overwriteAllCheckBox.Enabled = false;
            overwriteIfNewerCheckBox.Enabled = false;
            clearTextButton.Enabled = false;
            searchTextBox.Enabled = false;
            sourceDirectoryLabel.Enabled = false;
            targetDirectoryLabel.Enabled = false;
            moveFileUpLabel.Enabled = false;
            moveFileDownLabel.Enabled = false;
            moveToTopLabel.Enabled = false;
            moveToBottomLabel.Enabled = false;

            // Updates the `fromFilesDirLabel` with the path of the folder being processed.
            fromFilesDirLabel.Text = folderPath;
            path = folderPath;
            string folder = new DirectoryInfo(path).Name;

            // Checks if the path is a root directory and shows an error message if so.
            if (folderPath == Directory.GetDirectoryRoot(folderPath))
            {
                MessageBox.Show("You cannot copy/move/delete the root directory!", "Copy That v1.0 By: Havoc - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                noDragDrop = false;
            }
            // Checks if the file list is empty.
            else if (filesDataGridView.Rows.Count == 0)
            {
                // If the background worker is not busy, it starts it to begin processing.
                if (!_copyWorker.IsBusy)
                {
                    _copyWorker.RunWorkerAsync();
                }
                noDragDrop = false;
            }
            // Checks if the file list is not empty.
            else if (filesDataGridView.Rows.Count > 0)
            {
                // Checks if the file/folder has already been added to the list.
                if (!DoesRowExist(path))
                {
                    // If the background worker is not busy, it starts it.
                    if (!_copyWorker.IsBusy)
                    {
                        _copyWorker.RunWorkerAsync();
                    }
                    noDragDrop = false;
                }
                else
                {
                    // Shows a message if the file/folder has already been added.
                    MessageBox.Show("File/Folder was already added to the file/folder list!", "Copy That v1.0 - File/Directory Tool - File/Folder Already Added!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    noDragDrop = false;
                }
            }

            // Resets the `noDragDrop` flag to false.
            noDragDrop = false;
            // Re-enables the UI controls that were disabled earlier.
            startButton.Enabled = true;
            clearFileListButton.Enabled = true;
            removeFileButton.Enabled = true;
            addFileButton.Enabled = true;
            doNotOverwriteCheckBox.Enabled = true;
            overwriteAllCheckBox.Enabled = true;
            overwriteIfNewerCheckBox.Enabled = true;
            clearTextButton.Enabled = true;
            searchTextBox.Enabled = true;
            sourceDirectoryLabel.Enabled = true;
            targetDirectoryLabel.Enabled = true;
            moveFileUpLabel.Enabled = true;
            moveFileDownLabel.Enabled = true;
            moveToTopLabel.Enabled = true;
            moveToBottomLabel.Enabled = true;

            // Re-enables the "always on top" setting if it was checked.
            if (alwaysOnTopCheckBox.Checked == true)
            {
                this.TopMost = true;
            }
        }

        /// <summary>
        /// A method to update the UI with progress information from a background task.
        /// It ensures thread safety using `InvokeRequired`.
        /// </summary>
        /// <param name="progress">The progress report object containing update information.</param>
        private void UpdateUI(ProgressReport progress)
        {
            // Checks if the method is being called from a different thread than the UI thread.
            if (InvokeRequired)
            {
                // If so, it uses `Invoke` to call the method on the UI thread.
                Invoke(new Action(() => UpdateUI(progress)));
                return;
            }

            totalProgressBar.Value = progress.PercentComplete;
            totalProgressBar.Refresh();

            totalProgressBar.Text = $"{progress.PercentComplete}%";
            totalProgressBar.Refresh();
            // Updates the text of the `speedLabel`.
            speedLabel.Text = $"Speed: {progress.Speed:0.00} MB/s";

            // Updates the text of the `fromFilesDirLabel`.
            fromFilesDirLabel.Text = $"Current Source: {progress.CurrentFile}";
        }

        /// <summary>
        /// Gets a default target directory path based on a source path.
        /// </summary>
        /// <param name="sourcePath">The source file or directory path.</param>
        /// <returns>A default target directory path.</returns>
        private string GetDefaultTargetDirectory(string sourcePath)
        {
            // Defines a hardcoded default directory.
            string defaultDirectory = @"C:\Users\YourUsername\Documents\BackupFiles";

            // If the source path is a directory, it appends the directory name to the default path.
            if (Directory.Exists(sourcePath))
            {
                return System.IO.Path.Combine(defaultDirectory, new DirectoryInfo(sourcePath).Name);
            }

            // If the source path is a file, it appends the file name (without extension) to the default path.
            if (File.Exists(sourcePath))
            {
                string fileNameWithoutExtension = System.IO.Path.GetFileNameWithoutExtension(sourcePath);
                return System.IO.Path.Combine(defaultDirectory, fileNameWithoutExtension);
            }

            // If neither a directory nor a file, it returns the default path.
            return defaultDirectory;
        }
        /// <summary>
        /// An event handler for when a drag-and-drop operation enters the form.
        /// It checks the dropped data and sets the drag-and-drop effect.
        /// </summary>
        /// <param name="sender">The object that triggered the event.</param>
        /// <param name="e">The event arguments, which contain drag-and-drop data.</param>
        private void MainForm_DragEnter(object sender, DragEventArgs e)
        {
            try
            {
                // Checks if the user has enabled the "Confirm Drag and Drop" setting.
                if (CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop)
                {
                    // Checks if the dropped data is a file drop.
                    if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                    {
                        // Retrieves the array of file/directory paths.
                        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                        // Checks if any of the dropped items are entire drives.
                        if (files.Any(f => DriveInfo.GetDrives().Any(d => d.RootDirectory.FullName.TrimEnd('\\') == f.TrimEnd('\\'))))
                        {
                            // Shows a warning message and disallows the drop if a drive is detected.
                            MessageBox.Show("Dropping Drives is Not Allowed.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Effect = DragDropEffects.None;
                            return;
                        }

                        // Shows a confirmation dialog to the user.
                        DialogResult result = MessageBox.Show(
                            $"Do You Want to Add {files.Length} File(s) to Copy?",
                            "Confirm Drag and Drop",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        // Sets the drag-and-drop effect based on the user's response.
                        if (result == DialogResult.Yes)
                        {
                            e.Effect = DragDropEffects.Copy;
                        }
                        else
                        {
                            e.Effect = DragDropEffects.None;
                        }
                    }
                    else
                    {
                        // Disallows the drop if the data format is not a file drop.
                        e.Effect = DragDropEffects.None;
                    }
                }
                else
                {
                    // If the confirmation setting is disabled, it proceeds without asking.
                    if (e.Data.GetDataPresent(DataFormats.FileDrop, false))
                    {
                        // Retrieves the file/directory paths.
                        string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                        // Checks for and disallows dropping drives.
                        if (files.Any(f => DriveInfo.GetDrives().Any(d => d.RootDirectory.FullName.TrimEnd('\\') == f.TrimEnd('\\'))))
                        {
                            MessageBox.Show("Dropping Drives is Not Allowed.", "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            e.Effect = DragDropEffects.None;
                            return;
                        }

                        // Allows the drop as a copy operation.
                        e.Effect = DragDropEffects.Copy;
                    }
                    else
                    {
                        // Disallows the drop if the data format is not a file drop.
                        e.Effect = DragDropEffects.None;
                    }
                }
            }
            catch (Exception ex)
            {
                // Shows a generic error message if something goes wrong during the drag-and-drop process.
                MessageBox.Show("Sorry, but the directory or file couldn't be added.", "Copy That v1.0 By: Havoc - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// Adds a single file to the file list.
        /// </summary>
        /// <param name="filePath">The path of the file to add.</param>
        /// <param name="targetPath">The target path (not used in this method).</param>
        private void AddSingleFile(string filePath, string targetPath)
        {
            // Creates a `FileInfo` object for the specified file path.
            FileInfo fileInfo2 = new FileInfo(filePath);

            // Creates a new `FileInfoWrapper` object and populates its properties from the `FileInfo`.
            FileInfoWrapper fileWrapper = new FileInfoWrapper
            {
                FileName = fileInfo2.Name,
                FilePath = fileInfo2.FullName,
                FileSize = FormatBytes(fileInfo2.Length),
                BytesRaw = fileInfo2.Length,
                Status = "Pending",
                IsDirectory = false
            };

            // Adds the newly created wrapper object to the `_fileList`.
            _fileList.Add(fileWrapper);
        }

        /// <summary>
        /// Retrieves the full path of a file.
        /// </summary>
        /// <param name="filePath">The path of the file.</param>
        /// <returns>The full path of the file.</returns>
        private string getFileName(string filePath)
        {
            // Returns the full path for the specified file.
            return System.IO.Path.GetFullPath(filePath);
        }
        /// <summary>
        /// This method is the event handler for the form's `DragDrop` event.
        /// It processes the files and directories that are dropped onto the form.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data, which includes the dropped files.</param>
        private void MainForm_DragDrop(object sender, DragEventArgs e)
        {
            // Retrieves the list of dropped file and directory paths.
            string[] droppedFiles = (string[])e.Data.GetData(DataFormats.FileDrop);
            // If no files were dropped, it shows an error message and exits the method.
            if (droppedFiles.Length == 0)
            {
                MessageBox.Show("Sorry, But That Directory or File Couln't be Added");
                return;
            }
            // Iterates through each dropped file or directory.
            foreach (string file in droppedFiles)
            {
                // Gets the full path of the dropped item.
                string fileName = getFileName(file);
                // Shows a message box to inform the user what they dropped.
                MessageBox.Show("You dropped" + fileName);

                // Checks if the dropped item is a directory.
                if (Directory.Exists(file))
                {
                    // If it's a directory, this line is commented out, but it would call a method to add files from that directory.
                    //AddFilesFromDirectory(fileName, targetDirLabel.Text);
                }
                // Checks if the dropped item is a file.
                else if (File.Exists(file))
                {
                    // If it's a file, it calls the `AddSingleFile` method to add it to the list.
                    AddSingleFile(fileName, targetDirLabel.Text);
                }
            }
            // Plays a sound indicating that a file has been added.
            PlaySound("FileAdded");
        }
        /// <summary>
        /// An event handler for the form's `DragEnter` event, specifically with confirmation enabled.
        /// It checks if the dropped data is a file drop and asks the user for confirmation.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void MainForm_DragEnterWithConfirmation(object sender, DragEventArgs e)
        {
            try
            {
                // Checks if the dropped data is in the `FileDrop` format.
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                    // If so, it sets the effect to `All`, allowing a copy, move, or link operation.
                    e.Effect = DragDropEffects.All;
                else
                {
                    // If not a file drop, it gets the available data formats (this line doesn't affect the outcome).
                    String[] strGetFormats = e.Data.GetFormats();
                    // It then sets the effect to `None`, disallowing the drop.
                    e.Effect = DragDropEffects.None;
                }

                // It checks the data format again, which is redundant but harmless.
                if (e.Data.GetDataPresent(DataFormats.FileDrop))
                {
                    // Retrieves the array of dropped files.
                    string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                    // Displays a message box to confirm with the user if they want to add the files.
                    DialogResult result = MessageBox.Show(
                        $"Do you want to add {files.Length} file(s) to copy?",
                        "Confirm Drag and Drop",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question
                    );

                    // Sets the drag-and-drop effect based on the user's response.
                    if (result == DialogResult.Yes)
                    {
                        e.Effect = DragDropEffects.Copy;
                    }
                    else
                    {
                        e.Effect = DragDropEffects.None;
                    }
                }
            }
            catch (Exception ex)
            {
                // Catches any exceptions and displays a generic error message.
                MessageBox.Show("Sorry, but the directory or file couldn't be added.", "Copy That v1.0 By: Havoc - Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        /// <summary>
        /// This method is the event handler for the form's `DragDrop` event when confirmation is enabled.
        /// It adds the dropped files and folders to the file list.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void MainForm_DragDropWithConfirmation(object sender, DragEventArgs e)
        {
            // Retrieves the array of dropped files.
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Checks if the files array is not null and contains items.
            if (files != null && files.Length > 0)
            {
                // Iterates through each dropped file or folder.
                foreach (string file in files)
                {
                    // Checks if the item is a directory.
                    if (Directory.Exists(file))
                    {
                        // If it's a directory, this commented-out line would add its contents.
                        //AddFilesFromDirectory(file, targetDirLabel.Text);
                    }
                    // Checks if the item is a file.
                    else if (File.Exists(file))
                    {
                        // If it's a file, it calls `AddSingleFile`.
                        AddSingleFile(file, targetDirLabel.Text);
                    }
                }
            }
            // Plays a sound.
            PlaySound("FileAdded");
        }

        /// <summary>
        /// An event handler for a button click that restores the default settings.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void btnRestoreDefaults_Click(object sender, EventArgs e)
        {
            // Calls a method to restore the settings to their default values.
            RestoreDefaultSettings();
        }

        /// <summary>
        /// Saves the current state of the application's settings to the user's configuration file.
        /// </summary>
        private void SaveSettings()
        {
            // Saves settings related to the application window and behavior (e.g., Always on Top, Minimize to Tray).
            CopyThatProgram.Properties.Settings.Default.AlwaysOnTop = alwaysOnTopCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop = confirmDragDropCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.MinimizeToTray = minimizeSystemTrayCheckBox.Checked;

            // Saves theme and language settings.
            CopyThatProgram.Properties.Settings.Default.Language = languageComboBox.SelectedItem.ToString();
            CopyThatProgram.Properties.Settings.Default.Skin = skinsComboBox.SelectedItem.ToString();

            // Saves logging settings.
            CopyThatProgram.Properties.Settings.Default.LogToFile = logFileCheckBox.Checked;
            //CopyThatProgram.Properties.Settings.Default.LogRetentionDays = (int)numLogDays.Value;

            // Saves performance-related settings like buffer size and file size filters.
            CopyThatProgram.Properties.Settings.Default.BufferSize = (int)bufferNumUpDown.Value;
            CopyThatProgram.Properties.Settings.Default.CopyFilesOver = overMBCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.CopyFilesUnder = underMBCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.OverNum = (int)setMBGBOverNumUpDown.Value;
            CopyThatProgram.Properties.Settings.Default.UnderNum = (int)setMBGBUnderNumUpDown.Value;

            // Saves settings related to file and folder handling (e.g., zip options, path types).
            CopyThatProgram.Properties.Settings.Default.ZipSeparately = zipSeparateCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.ZipTogether = zipTogetherCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.FileOnlyNames = onlyNamesCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.FileFullPaths = fullPathsCheckBox.Checked;

            // Saves other operational settings.
            CopyThatProgram.Properties.Settings.Default.RestartOnError = restartCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.CloseOnError = closeProgramCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.StartWithWindows = startWithWindowsCheckBox.Checked;

            // Saves sound-related settings.
            CopyThatProgram.Properties.Settings.Default.SoundCopyComplete = onFinishCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.SoundFileAdded = onAddFilesCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.SoundCancel = onCancelCheckBox.Checked;
            CopyThatProgram.Properties.Settings.Default.SoundError = onErrorCheckBox.Checked;

            // Saves the setting for automatic saving.
            CopyThatProgram.Properties.Settings.Default.AutoSaveSettings = saveAutoCheckBox.Checked;
            // Commits the changes to the settings file.
            CopyThatProgram.Properties.Settings.Default.Save();
        }

        /// <summary>
        /// Resets the application's settings to their default values and reloads them.
        /// </summary>
        private void RestoreDefaultSettings()
        {
            // Calls the `Reset` method on the default settings to revert all properties.
            CopyThatProgram.Properties.Settings.Default.Reset();
            // Calls a method to load the newly reset settings into the UI.
            LoadCurrentSettings();
        }

        /// <summary>
        /// An event handler for a button click that applies a set of recommended settings.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private void recSettingsButton_Click(object sender, EventArgs e)
        {
            // Sets the `AlwaysOnTop` setting to false and updates the corresponding checkbox.
            Properties.Settings.Default.AlwaysOnTop = false;
            alwaysOnTopCheckBox.Checked = false;

            // Sets the `MinimizeToTray` setting to false and updates the checkbox.
            Properties.Settings.Default.MinimizeToTray = false;
            minimizeSystemTrayCheckBox.Checked = false;

            // Sets the `ConfirmDragDrop` setting to true and updates the checkbox.
            Properties.Settings.Default.ConfirmDragDrop = true;
            confirmDragDropCheckBox.Checked = true;

            // Sets the `SoundCopyComplete` setting to false but checks the checkbox to true, which is a logic error.
            Properties.Settings.Default.SoundCopyComplete = false;
            onFinishCheckBox.Checked = true;

            // Sets the `SoundCancel` setting to false and updates the checkbox.
            Properties.Settings.Default.SoundCancel = false;
            onCancelCheckBox.Checked = false;

            // Sets the `SoundError` setting to true and updates the checkbox.
            Properties.Settings.Default.SoundError = true;
            onErrorCheckBox.Checked = true;

            // Sets the `SoundFileAdded` setting to false and updates the checkbox.
            Properties.Settings.Default.SoundFileAdded = false;
            onAddFilesCheckBox.Checked = false;

            // Sets the `AutoSaveSettings` setting to true and updates the checkbox.
            Properties.Settings.Default.AutoSaveSettings = true;
            saveAutoCheckBox.Checked = true;

            // Sets the `ContextMenu` setting to true and updates the checkbox.
            Properties.Settings.Default.ContextMenu = true;
            contextMenuCheckBox.Checked = true;

            // Sets the `RestartOnError` setting to true and updates the checkbox.
            Properties.Settings.Default.RestartOnError = true;
            restartCheckBox.Checked = true;

            // Sets the `CopyFilesUnder` setting to false and updates the checkbox.
            Properties.Settings.Default.CopyFilesUnder = false;
            underMBCheckBox.Checked = false;

            // Sets the `CopyFilesOver` setting to false and updates the checkbox.
            Properties.Settings.Default.CopyFilesOver = false;
            overMBCheckBox.Checked = false;

            // Sets the `Multithreading` setting to true and updates the checkbox.
            Properties.Settings.Default.Multithreading = true;
            multithreadCheckBox.Checked = true;
        }
        /// <summary>
        /// Removes duplicate files from a list based on their file path.
        /// </summary>
        /// <param name="list">The list of `FileInfoWrapper` objects to process.</param>
        private static void RemoveDuplicatesByFilePath(BindingList<FileInfoWrapper> list)
        {
            // Creates a `HashSet` to keep track of seen file paths for efficient lookup.
            var seen = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            // Iterates through the list backwards to safely remove items during the loop.
            for (int i = list.Count - 1; i >= 0; i--)
            {
                // Tries to add the current file's path to the `HashSet`. `Add` returns false if the item already exists.
                if (!seen.Add(list[i].FilePath))
                    // If the path is a duplicate, it removes the item from the list.
                    list.RemoveAt(i);
            }
        }

        private void _updateTimer_Tick(object sender, EventArgs e)
        {
            // Do nothing if the operation is paused or canceled.
            if (_isPaused || _isCanceled) return;
            // Do nothing if the stopwatch hasn't started or no bytes have been processed.
            if (_stopwatch.ElapsedMilliseconds == 0 && _totalBytesProcessed == 0)
                return;

            long elapsedMs = _stopwatch.ElapsedMilliseconds;
            if (elapsedMs == 0)
                return;

            // Calculate bytes processed since the last tick.
            long bytesSinceLastTick = _totalBytesProcessed - _lastProcessedBytesForSpeed;
            // Calculate speed in bytes per second.
            double speedBps = bytesSinceLastTick / ((DateTime.Now - _lastSpeedCalcTime).TotalSeconds);

            // Use a switch expression to format the speed into B/s, KB/s, MB/s, or GB/s.
            string speedText = speedBps switch
            {
                < 1024 => $"{speedBps:F2} B/s",
                < 1024 * 1024 => $"{speedBps / 1024:F2} KB/s",
                < 1024L * 1024 * 1024 => $"{speedBps / (1024.0 * 1024):F2} MB/s",
                _ => $"{speedBps / (1024.0 * 1024 * 1024):F2} GB/s"
            };

            // Calculate the estimated time remaining.
            long bytesRemaining = _totalBytesToProcess - _totalBytesProcessed;
            TimeSpan eta = bytesRemaining <= 0 || speedBps <= 0
                ? TimeSpan.Zero
                : TimeSpan.FromSeconds(bytesRemaining / speedBps);

            TimeSpan elapsed = TimeSpan.FromMilliseconds(elapsedMs);
            // Calculate the total estimated target time.
            TimeSpan target = elapsed + eta;

            // Calculate running grand totals (previous totals + current operation)
            var settings = Properties.Settings.Default;
            TimeSpan grandElapsedRunning = TimeSpan.FromSeconds(settings.TotalElapsedTimeSeconds) + elapsed;
            TimeSpan grandTargetRunning = TimeSpan.FromSeconds(settings.TotalTargetTimeSeconds) + target;

            // Update the UI labels with the new speed and time information
            if (speedLabel != null && !speedLabel.IsDisposed)
                speedLabel.Text = $"Speed: {speedText}";

            // Update current operation time display
            if (elapsedAndTargetTimeLabel != null && !elapsedAndTargetTimeLabel.IsDisposed)
                elapsedAndTargetTimeLabel.Text = $"Elapsed / Target Time: {elapsed:hh\\:mm\\:ss} / {target:hh\\:mm\\:ss}";

            // Update running totals display (showing what the totals WILL be when this operation completes)
            if (totalElapsedTimeLabel != null && !totalElapsedTimeLabel.IsDisposed)
                totalElapsedTimeLabel.Text = $"Total Elapsed Time: {grandElapsedRunning:hh\\:mm\\:ss}";

            if (totalTargetTimeLabel != null && !totalTargetTimeLabel.IsDisposed)
                totalTargetTimeLabel.Text = $"Total Target Time: {grandTargetRunning:hh\\:mm\\:ss}";

            // Store the current values for the next calculation.
            _lastProcessedBytesForSpeed = _totalBytesProcessed;
            _lastSpeedCalcTime = DateTime.Now;

            // Update the drive space information.
            UpdateDriveSpaceInfo();
        }

        /// <summary>
        /// An asynchronous event handler for the `startButton` click. This method initiates the file operation (copy, move, or secure delete).
        /// It performs various checks, sets up the UI, and starts the background worker.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The event data.</param>
        private async void startButton_Click(object sender, EventArgs e)
        {
            // Resets the timestamp for speed calculation.
            _lastSpeedCalcTime = DateTime.Now;

            // Initializes the `_updateTimer` if it's null.
            if (_updateTimer == null)
            {
                _updateTimer = new System.Windows.Forms.Timer { Interval = 500 };
                _updateTimer.Tick += _updateTimer_Tick;
            }
            // Resets flags for cancellation and pausing.
            _isCanceled = false;
            _isPaused = false;
            // Sets the pause event to unblock any waiting threads.
            _pauseEvent.Set();

            // Resets various counters for files and bytes processed.
            _totalBytesProcessed = _totalBytesProcessed = 0;
            _multiThreadProcessedFiles = _processedFiles = 0;
            _totalFilesCopied = _totalFilesMoved = _totalFilesDeleted = 0;
            _totalFilesSkipped = _totalFilesFailed = 0;
            // Clears the list of skipped files.
            _skippedFilesList.Clear();
            // Resets the flag to finish the current file and quit.
            _finishCurrentFileAndQuit = false;

            // Checks if the file list is empty and shows a warning if so.
            if (_fileList == null || _fileList.Count == 0)
            {
                MessageBox.Show("You must select files or folders to Copy/Move/Delete!",
                                "No Source Items", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Clears the current target paths.
            _currentTargetPaths.Clear();
            // Checks if the user wants to create a custom directory.
            if (createCustomDirCheckBox.Checked)
            {
                // Gets the custom directory path from the user.
                string customDir = GetCustomDirectoryFromUser();
                // If the path is invalid, shows a message and exits.
                if (string.IsNullOrWhiteSpace(customDir))
                {
                    MessageBox.Show("Operation cancelled: Custom directory not specified.",
                                    "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                // Adds the custom directory to the target paths.
                _currentTargetPaths.Add(customDir);
            }
            else
            {
                // If not creating a custom directory, checks if a target path is selected.
                if (this.targetPaths == null || this.targetPaths.Count == 0)
                {
                    MessageBox.Show("Please select at least one destination folder.",
                                    "Missing Destination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                // Adds the existing target paths.
                _currentTargetPaths.AddRange(this.targetPaths);
            }

            // Calculates the total bytes of files to be processed.
            long neededBytes = _fileList.Where(f => !f.IsDirectory).Sum(f => f.BytesRaw);

            // If there are target paths, it checks for sufficient disk space.
            if (_currentTargetPaths.Any())
            {
                // Gets a list of unique drive roots for the target paths.
                var driveRoots = _currentTargetPaths
                                     .Select(tp => System.IO.Path.GetPathRoot(tp))
                                     .Where(r => !string.IsNullOrEmpty(r))
                                     .Distinct(StringComparer.OrdinalIgnoreCase)
                                     .ToList();

                // Defines a minimum amount of free space to keep.
                long keepBytes = 20 * 1024 * 1024;
                // Defines the minimum free space after the operation.
                long minFreeAfter = 100 * 1024 * 1024;

                // Iterates through each unique drive root.
                foreach (var root in driveRoots)
                {
                    DriveInfo drive;
                    try
                    {
                        // Gets a `DriveInfo` object for the current drive root.
                        drive = new DriveInfo(root);
                    }
                    catch
                    {
                        // Skips to the next drive if there's an error.
                        continue;
                    }

                    // If the drive is not ready, it skips to the next one.
                    if (!drive.IsReady) continue;

                    // Calculates the free space after the operation.
                    long freeAfter = drive.AvailableFreeSpace - neededBytes;

                    // Checks if a full overwrite is not selected and if the free space will fall below the minimum.
                    if (!overwriteAllCheckBox.Checked && freeAfter < minFreeAfter)
                    {
                        // Calculates the maximum allowed bytes to copy to maintain the `keepBytes` free space.
                        long maxAllowed = drive.AvailableFreeSpace - keepBytes;
                        long allowedBytes = Math.Min(neededBytes, maxAllowed);

                        // If no space is available, it shows an error message.
                        if (allowedBytes <= 0)
                        {
                            MessageBox.Show("Not enough space left on drive " + drive.Name + ".",
                                            "Out of space", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        // Shows a warning message to the user about low disk space and asks for confirmation.
                        var result = MessageBox.Show(
                            $"Drive {drive.Name} will have less than 100 MB free.\n\n" +
                            $"Only {FormatBytes(allowedBytes)} will be copied so that around {FormatBytes(keepBytes)} remain.\n\nContinue?",
                            "Low disk space",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        // If the user does not confirm, it exits the method.
                        if (result != DialogResult.Yes) return;

                        // Trims the file list to only include files that will fit within the allowed space.
                        long running = 0;
                        var trimmed = _fileList.Where(f => !f.IsDirectory)
                                                 .TakeWhile(f => (running += f.BytesRaw) <= allowedBytes)
                                                 .ToList();

                        // Clears the original list and adds the trimmed list.
                        _fileList.Clear();
                        foreach (var f in trimmed) _fileList.Add(f);
                    }
                }
            }

            // Checks how many "behavior" options are selected.
            int behaviourOptions = 0;
            if (keepDirStructCheckBox.Checked) behaviourOptions++;
            if (copyFilesDirsCheckBox.Checked) behaviourOptions++;
            if (keepOnlyFilesCheckBox.Checked) behaviourOptions++;
            if (leaveEmptyFoldersCheckBox.Checked) behaviourOptions++;

            // If creating a custom directory, allow up to 3 checkboxes to be selected
            // Otherwise, only allow 1 behavior option
            int maxBehaviorOptions = createCustomDirCheckBox.Checked ? 3 : 2;

            if (behaviourOptions > maxBehaviorOptions)
            {
                string message = createCustomDirCheckBox.Checked
                    ? "When creating a custom directory or keeping only empty folders, you may select up to 3 behavior options."
                    : "Only one behaviour option may be selected at a time.";

                MessageBox.Show(message, "Invalid Options", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validate keepEmptyFolders requires either keepDirectoryStructure or copyFilesOnly
            if (leaveEmptyFoldersCheckBox.Checked &&
                !keepDirStructCheckBox.Checked &&
                !copyFilesDirsCheckBox.Checked)
            {
                MessageBox.Show("'Keep Empty Folders Only' must be used with either 'Keep Directory Structure' or 'Copy Files Only'.",
                               "Invalid Combination", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // When creating a custom directory, ensure at least one overwrite option and one directory structure option are selected
            if (createCustomDirCheckBox.Checked)
            {
                // Check that at least one overwrite option is selected
                int overwriteModes = 0;
                if (overwriteAllCheckBox.Checked) overwriteModes++;
                if (doNotOverwriteCheckBox.Checked) overwriteModes++;
                if (overwriteIfNewerCheckBox.Checked) overwriteModes++;

                if (overwriteModes == 0)
                {
                    MessageBox.Show("When creating a custom directory, you must select an overwrite option (Overwrite All, Do Not Overwrite, or Overwrite If Newer).",
                                   "Missing Overwrite Option", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check that at least one directory structure option is selected
                if (behaviourOptions == 0)
                {
                    MessageBox.Show("When creating a custom directory, you must select at least one directory structure option (Keep Directory Structure, Copy Files Only, Keep Only Files, or Keep Empty Folders).",
                                   "Missing Directory Structure Option", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // Checks how many overwrite modes are selected (for normal operations).
            int totalOverwriteModes = 0;
            if (overwriteAllCheckBox.Checked) totalOverwriteModes++;
            if (doNotOverwriteCheckBox.Checked) totalOverwriteModes++;
            if (overwriteIfNewerCheckBox.Checked) totalOverwriteModes++;

            // Shows an error if more than one overwrite mode is selected.
            if (totalOverwriteModes > 1)
            {
                MessageBox.Show("Only one overwrite behaviour may be selected.",
                               "Invalid Options", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Sets boolean flags based on the state of the checkboxes.
            _overwriteAll = overwriteAllCheckBox.Checked;
            _doNotOverwrite = doNotOverwriteCheckBox.Checked;
            _overwriteIfNewer = overwriteIfNewerCheckBox.Checked;
            _keepDirectoryStructure = keepDirStructCheckBox.Checked;
            _copyFilesOnly = copyFilesDirsCheckBox.Checked;
            _keepEmptyFolders = leaveEmptyFoldersCheckBox.Checked;
            _keepOnlyFiles = keepOnlyFilesCheckBox.Checked;

            // Determines the file operation based on the selected item in the combo box.
            FileOperation operation;
            switch (copyMoveDeleteComboBox.SelectedItem?.ToString())
            {
                case "Copy Files": operation = FileOperation.Copy; break;
                case "Move Files": operation = FileOperation.Move; break;
                case "Secure Delete Files": operation = FileOperation.SecureDelete; break;
                default:
                    // Shows an error if no valid operation is selected.
                    MessageBox.Show("Please select a valid operation.",
                                    "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
            }
            // Stores the selected operation.
            _currentOperation = operation;

            // Removes any duplicate file paths from the list.
            RemoveDuplicatesByFilePath(_fileList);

            // Calculates the total number of files and total bytes to process.
            _grandTotalFileCount = _fileList.Count(f => !f.IsDirectory);
            _totalBytesToProcess = _fileList.Where(f => !f.IsDirectory)
                                             .Sum(f => f.BytesRaw);

            // Resets progress counters.
            _totalBytesProcessed = 0;
            _filesProcessed = 0;
            // Restarts the stopwatch to time the operation.
            _stopwatch.Restart();
            // Starts the UI update timer.
            _updateTimer.Start();

            // Initializes the progress handler.
            InitializeProgressHandler();

            // Resets pause/resume button text.
            pauseResumeMultiButton.Text = "Pause";

            // Enables and disables buttons.
            startButton.Enabled = false;
            pauseResumeMultiButton.Enabled = true;
            cancelMultiButton.Enabled = true;

            // Sets the enabled state of various buttons.
            cancelButton.Enabled = true;
            pauseResumeButton.Enabled = true;
            skipButton.Enabled = true;

            // Enable/disable controls based on whether custom directory is being used
            bool isCustomDir = createCustomDirCheckBox.Checked;

            // Always disable these during operation
            copyMoveDeleteComboBox.Enabled = false;
            addFileButton.Enabled = false;
            removeFileButton.Enabled = false;
            clearFileListButton.Enabled = false;
            sourceDirectoryLabel.Enabled = false;
            targetDirectoryLabel.Enabled = false;
            moveFileUpLabel.Enabled = false;
            moveFileDownLabel.Enabled = false;
            moveToTopLabel.Enabled = false;
            moveToBottomLabel.Enabled = false;
            minimizeLabel.Enabled = false;
            settingsLabel.Enabled = false;
            allAboutLabel.Enabled = false;

            // These remain enabled during operation
            exitLabel.Enabled = true;
            rollDownLabel.Enabled = true;
            rollUpLabel.Enabled = true;

            // For custom directory operations, keep some checkboxes enabled
            // For normal operations, disable all checkboxes
            if (isCustomDir)
            {
                // Keep overwrite options enabled (user might want to change during operation)
                overwriteAllCheckBox.Enabled = true;
                doNotOverwriteCheckBox.Enabled = true;
                overwriteIfNewerCheckBox.Enabled = true;

                // Keep directory structure options enabled
                keepDirStructCheckBox.Enabled = true;
                leaveEmptyFoldersCheckBox.Enabled = true;
                keepOnlyFilesCheckBox.Enabled = true;
                copyFilesDirsCheckBox.Enabled = true;
            }
            else
            {
                // Normal operation - disable all option checkboxes
                overwriteAllCheckBox.Enabled = false;
                doNotOverwriteCheckBox.Enabled = false;
                overwriteIfNewerCheckBox.Enabled = false;
                keepDirStructCheckBox.Enabled = false;
                leaveEmptyFoldersCheckBox.Enabled = false;
                keepOnlyFilesCheckBox.Enabled = false;
                copyFilesDirsCheckBox.Enabled = false;
            }

            // Always disable the custom directory checkbox during operation
            createCustomDirCheckBox.Enabled = false;

            try
            {
                // A switch statement to start the appropriate background worker based on the selected operation.
                switch (_currentOperation)
                {
                    case FileOperation.Copy:
                        // If multithreading is enabled, it processes files in parallel.
                        if (multithreadCheckBox.Checked)
                        {
                            // --- Calculate Grand Totals Correctly ---
                            int targetCount = _currentTargetPaths.Count;
                            _grandTotalFileCount = _fileList.Count(f => !f.IsDirectory);
                            _totalBytesToProcess = _fileList.Where(f => !f.IsDirectory)
                                                            .Sum(f => f.BytesRaw);

                            // ✅ If copying/moving to multiple targets, multiply totals
                            if (_currentOperation != FileOperation.SecureDelete && targetCount > 1)
                            {
                                _grandTotalFileCount *= targetCount;
                                _totalBytesToProcess *= targetCount;
                            }

                            // ✅ Update initial UI
                            fileCountOnLabel.Text = $"File Count: 0 Out of {_grandTotalFileCount:N0}";
                            totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / {FormatBytes(_totalBytesToProcess)}";


                            tabControl1.SelectedTab = cmdMultithread;
                            // Disable all other tabs
                            ShowOnlyCurrentTab();
                            allowTabChanges = false;
                            await ProcessFilesMultiThreaded(_fileList.ToList(), _currentTargetPaths.ToArray());
                            _copyWorker_RunWorkerCompleted(this,
                                new RunWorkerCompletedEventArgs("Parallel copy complete", null, false));
                        }
                        else
                        {
                            // --- Calculate Grand Totals Correctly ---
                            int targetCount2 = _currentTargetPaths.Count;
                            _grandTotalFileCount = _fileList.Count(f => !f.IsDirectory);
                            _totalBytesToProcess = _fileList.Where(f => !f.IsDirectory)
                                                            .Sum(f => f.BytesRaw);

                            // ✅ If copying/moving to multiple targets, multiply totals
                            if (_currentOperation != FileOperation.SecureDelete && targetCount2 > 1)
                            {
                                _grandTotalFileCount *= targetCount2;
                                _totalBytesToProcess *= targetCount2;
                            }

                            // ✅ Update initial UI
                            fileCountOnLabel.Text = $"File Count: 0 Out of {_grandTotalFileCount:N0}";
                            totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / {FormatBytes(_totalBytesToProcess)}";


                            // Disable all other tabs
                            ShowOnlyCurrentTab();
                            allowTabChanges = false;
                            // Otherwise, it starts the single-threaded copy worker.
                            _copyWorker?.RunWorkerAsync();
                        }
                        break;

                    case FileOperation.Move:
                        // --- Calculate Grand Totals Correctly ---
                        int targetCount3 = _currentTargetPaths.Count;
                        _grandTotalFileCount = _fileList.Count(f => !f.IsDirectory);
                        _totalBytesToProcess = _fileList.Where(f => !f.IsDirectory)
                                                        .Sum(f => f.BytesRaw);

                        // ✅ If copying/moving to multiple targets, multiply totals
                        if (_currentOperation != FileOperation.SecureDelete && targetCount3 > 1)
                        {
                            _grandTotalFileCount *= targetCount3;
                            _totalBytesToProcess *= targetCount3;
                        }

                        // ✅ Update initial UI
                        fileCountOnLabel.Text = $"File Count: 0 Out of {_grandTotalFileCount:N0}";
                        totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / {FormatBytes(_totalBytesToProcess)}";

                        // Starts the move worker.
                        _moveWorker?.RunWorkerAsync();
                        break;

                    case FileOperation.SecureDelete:
                        // --- Calculate Grand Totals Correctly ---
                        int targetCount4 = _currentTargetPaths.Count;
                        _grandTotalFileCount = _fileList.Count(f => !f.IsDirectory);
                        _totalBytesToProcess = _fileList.Where(f => !f.IsDirectory)
                                                        .Sum(f => f.BytesRaw);

                        // ✅ If copying/moving to multiple targets, multiply totals
                        if (_currentOperation != FileOperation.SecureDelete && targetCount4 > 1)
                        {
                            _grandTotalFileCount *= targetCount4;
                            _totalBytesToProcess *= targetCount4;
                        }

                        // ✅ Update initial UI
                        fileCountOnLabel.Text = $"File Count: 0 Out of {_grandTotalFileCount:N0}";
                        totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / {FormatBytes(_totalBytesToProcess)}";


                        // Starts the delete worker.
                        _deleteWorker?.RunWorkerAsync();
                        break;
                }
            }
            catch (Exception ex)
            {
                // Catches any exceptions that occur and calls the completion handler with the error.
                _copyWorker_RunWorkerCompleted(this,
                    new RunWorkerCompletedEventArgs(null, ex, false));
            }
        }

        private void StartElapsedTimer()
        {
            if (!_elapsedTimerRunning) // Checks if the timer is not already running.
            {
                _elapsedTimerRunning = true; // Sets the flag to true to indicate the timer is now running.
                _updateTimer.Start(); // Starts the update timer.
            }
        }

        private void StopElapsedTimer()
        {
            if (_elapsedTimerRunning) // Checks if the timer is currently running.
            {
                _elapsedTimerRunning = false; // Sets the flag to false, indicating the timer is stopped.
                _updateTimer.Stop(); // Stops the update timer.
            }
        }
        private void pauseResumeButton_Click(object sender, EventArgs e) // Event handler for the pause/resume button click.
        {
            _isPaused = !_isPaused; // Toggles the boolean state of the _isPaused variable.

            if (_isPaused) // Checks if the application is now in a paused state.
            {
                _pauseEvent.Reset(); // Resets the pause event, effectively blocking a waiting thread.
                pauseResumeButton.Text = "Resume"; // Changes the button's text to "Resume".

                StopElapsedTimer(); // Calls the helper method to stop the timer.
            }
            else // If the application is not paused (it's resuming).
            {
                _pauseEvent.Set(); // Sets the pause event, allowing a blocked thread to continue.
                pauseResumeButton.Text = "Pause"; // Changes the button's text to "Pause".

                StartElapsedTimer(); // Calls the helper method to start the timer.
            }
        }

        /// <summary>
        /// Performs a secure file deletion based on U.S. Department of Defense (DoD) standards.
        /// Overwrites the file content with specific patterns multiple times before deletion
        /// to prevent data recovery.
        /// </summary>
        /// <param name="path">The full path of the file to securely delete</param>
        private static void DoDSecureDelete(string path) // A method to perform a secure file deletion based on DoD standards.
        {
            const int BUFFER = 64 * 1024; // Defines a constant for the buffer size (64KB).
            const int PASSES = 3; // Defines a constant for the number of overwrite passes.

            byte[][] patterns = // An array of byte arrays, representing the overwrite patterns.
                    {
        Enumerable.Repeat((byte)0xFF, BUFFER).ToArray(), // Fills a buffer with all 1s (0xFF).
                Enumerable.Repeat((byte)0x00, BUFFER).ToArray(), // Fills a buffer with all 0s (0x00).
                Enumerable.Repeat((byte)0xF6, BUFFER).ToArray() // Fills a buffer with a specific byte pattern (0xF6).
            };

            File.SetAttributes(path, FileAttributes.Normal); // Sets the file attributes to normal, ensuring it can be written to.

            using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Write, FileShare.None)) // Opens the file for writing and ensures exclusive access.
            {
                long fileLen = fs.Length; // Gets the total length of the file.

                foreach (byte[] pattern in patterns) // Loops through each of the defined overwrite patterns.
                {
                    fs.Position = 0; // Resets the file stream position to the beginning of the file.
                    long bytesLeft = fileLen; // Initializes a counter for the remaining bytes to write.

                    while (bytesLeft > 0) // Continues looping as long as there are bytes left to write.
                    {
                        int toWrite = (int)Math.Min(BUFFER, bytesLeft); // Determines the number of bytes to write, which is the smaller of the buffer size or the remaining bytes.
                        fs.Write(pattern, 0, toWrite); // Writes the current pattern to the file.
                        bytesLeft -= toWrite; // Decrements the bytes left counter.
                    }
                    fs.Flush(true); // Flushes all buffered data to the underlying file, ensuring the write operation is complete.
                }
            }
            File.Delete(path); // Deletes the file from the file system.
        }



        private void cancelButton_Click(object sender, EventArgs e) // Event handler for the cancel button.
        {
            if (!_copyWorker.IsBusy) return; // Checks if the copy worker is busy. If not, the method exits.

            _cancelDialogEvent.Reset(); // Resets a dialog event, possibly to block a cancel confirmation dialog.

            bool finish = ConfirmCancelCopy(); // Calls a method to show a confirmation dialog and get the result.

            _pauseEvent.Set(); // Sets the pause event, allowing any paused operations to continue.
            _cancelDialogEvent.Set(); // Sets the cancel dialog event, allowing the dialog to close or the blocked thread to proceed.
            _isCanceled = true;
        }

        /// <summary>
        /// Determines whether a file with the specified full path already exists in the file list.
        /// Uses case-insensitive comparison to check for existing file paths.
        /// </summary>
        /// <param name="fullPath">The full file path to check for existence in the list</param>
        /// <returns>True if the file path already exists in the list, false otherwise</returns>
        private bool DoesRowExist(string fullPath)
        {
            // Uses LINQ to check if any item in the list matches the given path.
            return _fileList.Any(w =>
                // Performs a case-insensitive comparison of file paths.
                string.Equals(w.FilePath, fullPath, StringComparison.OrdinalIgnoreCase));
        }

        private void addFileButton_Click(object sender, EventArgs e) // Event handler for the "Add File" button.
        {
            noDragDrop = true; // Sets a flag to disable drag and drop functionality.

            openFileDialog.Multiselect = true; // Allows the user to select multiple files.
            openFileDialog.FileName = ""; // Clears the file name in the dialog.
            openFileDialog.Title = "Select File(s) to Add"; // Sets the title of the file dialog.
            long totalSizeBytesFile = 0; // Initializes a variable to track the total size of selected files.

            DialogResult dr = this.openFileDialog.ShowDialog(); // Opens the file dialog and stores the user's action.

            if (dr == System.Windows.Forms.DialogResult.OK) // Checks if the user clicked "OK".
            {
                foreach (string file in openFileDialog.FileNames) // Iterates through each file selected by the user.
                {
                    var fileInfoNow = new FileInfo(file); // Creates a new FileInfo object for the current file.

                    if (!DoesRowExist(fileInfoNow.FullName)) // Checks if the file is not already in the list.
                    {

                        if (fileInfoNow.Length <= 0) // Skips the file if its size is zero or less.
                            continue;

                        try // Begins a try-catch block for error handling.
                        {
                            if (File.Exists(file)) // Double-checks if the file still exists on the file system.
                            {
                                totalSizeBytesFile += fileInfoNow.Length; // Adds the file's size to the running total.

                                _fileList.Add(new FileInfoWrapper // Creates a new FileInfoWrapper object and adds it to the list.
                                {
                                    FileName = System.IO.Path.GetFileName(fileInfoNow.FullName), // Gets just the file name.
                                    FilePath = System.IO.Path.GetFullPath(fileInfoNow.FullName), // Gets the full file path.
                                    FileSize = FormatBytes(fileInfoNow.Length), // Formats the file size for display.
                                    BytesRaw = 0, // Sets the raw bytes to 0 (this may be an error, as fileInfoNow.Length should be used).
                                    IsDirectory = false, // Explicitly marks it as not a directory.
                                    Status = "Pending" // Sets the initial status of the file.
                                });

                                _grandTotalFileCount++; // Increments the total file count.
                                _totalBytesToProcess += fileInfoNow.Length; // Adds the file's size to the total bytes to be processed.

                                this.fileCountOnLabel.Text = // Updates a UI label with the current file count.
                                    $"File Count: 0 Out of {_grandTotalFileCount:N0}";
                                totalCopiedProgressLabel.Text = // Updates a UI label with the total bytes to process.
                                                    $"Total C/M/D: 0 Bytes / {FormatBytes(_totalBytesToProcess)}";

                                totalSizeBytesFile = 0; // Resets the local size counter.
                            }
                            else // If the file does not exist on the file system.
                            {
                                MessageBox.Show( // Displays a message box to the user.
                                                    "File/Folder was already added to the file/folder list!",
                                  "Copy That v1.0 By: Havoc - File/Folder Already Added!",
                                  MessageBoxButtons.OK,
                                  MessageBoxIcon.Error);

                                noDragDrop = false; // Re-enables drag and drop.
                                return; // Exits the method.
                            }
                        }
                        catch (SecurityException ex) // Catches a security exception if the user doesn't have permissions.
                        {
                            MessageBox.Show( // Displays a security error message.
                                              $"Security error!\n\nError message: {ex.Message}\n\nDetails:\n\n{ex.StackTrace}",
                              "Copy That v1.0 By: Havoc - Error!",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                        }
                        catch (Exception ex) // Catches any other general exception.
                        {
                            MessageBox.Show( // Displays a general error message.
                                              $"Cannot display the file: ({fileInfoNow.Name}). You may not have permission to read the file, or it may be corrupt.\n\nReported error: {ex.Message}",
                              "Copy That v1.0 By: Havoc - Error!",
                              MessageBoxButtons.OK,
                              MessageBoxIcon.Error);
                        }
                    }
                }
                pauseResumeButton.Enabled = false; // Disables the pause/resume button.
                cancelButton.Enabled = false; // Disables the cancel button.
                skipButton.Enabled = false; // Disables the skip button.
            }
            else // If the user did not click "OK" in the file dialog.
            {
                noDragDrop = false; // Re-enables drag and drop.
            }
            noDragDrop = false; // Re-enables drag and drop again after the loop, redundant but harmless.
        }
        private void removeFileButton_Click(object sender, EventArgs e) // Event handler for the "Remove File" button.
        {
            if (filesDataGridView.SelectedRows.Count == 0) return; // If no row is selected in the grid, the method exits.

            var selected = filesDataGridView.SelectedRows[0].DataBoundItem as FileInfoWrapper; // Gets the selected item from the grid.
            if (selected == null) return; // Exits if the selected item is not a FileInfoWrapper.

            // quick UI lock
            foreach (TabPage tp in tabControl1.TabPages) // Loops through each tab page.
                tp.Enabled = false; // Disables all tab pages to prevent user interaction.

            try // Begins a try-catch-finally block.
            {
                string rootToRemove = selected.FilePath; // Stores the file path of the selected item.

                // Build everything under this directory (files + sub-dirs)
                var toDelete = new List<FileInfoWrapper>(); // Creates a new list to hold items to be deleted.

                if (selected.IsDirectory && Directory.Exists(rootToRemove)) // Checks if the selected item is a directory and exists.
                {
                    toDelete.AddRange( // Adds all entries in the directory (recursively) to the list to be deleted.
                                  Directory.EnumerateFileSystemEntries(rootToRemove, "*", SearchOption.AllDirectories)
                          .Select(p => new FileInfoWrapper // Maps each entry to a new FileInfoWrapper object.
                          {
                              FilePath = p,
                              IsDirectory = (File.GetAttributes(p) & FileAttributes.Directory) != 0,
                              BytesRaw = (File.GetAttributes(p) & FileAttributes.Directory) == 0
                                  ? new FileInfo(p).Length : 0L
                          }));
                }
                toDelete.Add(selected); // Adds the initially selected item to the list to be deleted.

                long bytesRemoved = 0; // Initializes a counter for removed bytes.
                int filesRemoved = 0; // Initializes a counter for removed files.

                foreach (var item in toDelete) // Iterates through the list of items to be deleted.
                {
                    var gridItem = _fileList.FirstOrDefault(f => // Finds the corresponding item in the main file list.
                                  f.FilePath.Equals(item.FilePath, StringComparison.OrdinalIgnoreCase));

                    if (gridItem != null) // If the item is found in the main file list.
                    {
                        if (!gridItem.IsDirectory) // If the item is a file (not a directory).
                        {
                            bytesRemoved += gridItem.BytesRaw; // Adds the file's size to the removed bytes counter.
                            filesRemoved++; // Increments the files removed counter.
                        }
                        _fileList.Remove(gridItem); // Removes the item from the main file list.
                    }
                }

                _totalBytesToProcess -= bytesRemoved; // Subtracts the removed bytes from the total bytes to process.
                _grandTotalFileCount -= filesRemoved; // Subtracts the removed files from the total file count.

                UpdateFileCountLabels(); // Calls a method to refresh the UI labels.
            }
            finally // The finally block always executes, regardless of whether an exception was thrown.
            {
                foreach (TabPage tp in tabControl1.TabPages) // Loops through each tab page again.
                    tp.Enabled = true; // Re-enables all tab pages.
            }
        }

        private void clearFileListButton_Click(object sender, EventArgs e) // Event handler for the "Clear File List" button.
        {
            _cancellationTokenSource?.Cancel(); // Requests cancellation of any pending operations.
            _cancellationTokenSource?.Dispose(); // Disposes of the cancellation token source.
            _cancellationTokenSource = null; // Sets the cancellation token source to null.

            _fileList.Clear(); // Clears the list of files.

            _sourceDirectories.Clear(); // Clears the list of source directories.
            _targetDirectories.Clear(); // Clears the list of target directories.
            targetPaths.Clear(); // Clears the list of target paths.

            _grandTotalFileCount = 0; // Resets the total file count.
            _totalFolders = 0; // Resets the total folders count.
            _totalBytesToProcess = 0; // Resets the total bytes to process.
            _totalBytesProcessed = 0; // Resets the processed bytes.
            _processedFiles = 0; // Resets the processed files count.
            _processedFolders = 0; // Resets the processed folders count.


            fileCountOnLabel.Text = "File Count: 0 Out of 0"; // Resets the file count UI label.
            totalCopiedProgressLabel.Text = "Total C/M/D: 0 Bytes / 0 Bytes"; // Resets the progress UI label.
            fromFilesDirLabel.Text = "Select Files/Directory"; // Resets the source directory UI label.
            targetDirLabel.Text = "Select Directory"; // Resets the target directory UI label.
            fileCountMultiLabel.Text = "File Count: 0 Out of 0"; // Resets a multi-file count UI label.
            totalCMDMultiLabel.Text = "Total C/M/D: 0 Bytes / 0 Bytes"; // Resets a multi-file progress UI label.
            filePathLabel.Text = "Nothing"; // Resets the file path UI label.
        }
        private void onFinishComboBox_SelectedIndexChanged(object sender, EventArgs e) // Event handler for the "onFinish" combo box selection change.
        {
            if (onFinishMultiComboBox.SelectedIndex == -1) // Checks if the multi-select combo box has no selection.
            {
                onFinishMultiComboBox.SelectedIndex = 0; // Sets a default value.
            }
            if (onFinishComboBox.SelectedIndex == -1) // Checks if the single-select combo box has no selection.
            {
                onFinishComboBox.SelectedIndex = 0;// Sets a default value.
            }
            onFinishMultiComboBox.Text = onFinishComboBox.Text; // Synchronizes the text of the two combo boxes.
        }
        private void copyMoveDeleteComboBox_SelectedIndexChanged(object sender, EventArgs e) // Event handler for the copy/move/delete combo box selection change.
        {
            string selectedOperation = copyMoveDeleteComboBox.SelectedItem?.ToString(); // Gets the selected operation as a string.

            securePassesNumUpDown.Enabled = (selectedOperation == "Secure Delete Files"); // Enables the secure passes numeric up-down control only if "Secure Delete Files" is selected.
            secureDeleteLabel.Enabled = (selectedOperation == "Secure Delete Files"); // Enables the corresponding label.

        }

        /// <summary>
        /// Calculates a contrasting foreground color (black or white) for a given background color
        /// based on perceived brightness using the luminance formula.
        /// </summary>
        /// <param name="backColor">The background color to calculate the contrasting color for</param>
        /// <returns>Black for light background colors, white for dark background colors</returns>
        private System.Drawing.Color GetContrastingColor(System.Drawing.Color backColor)
        {
            // Calculates the perceived brightness of the color using a standard formula.
            // Uses the luminance formula: 0.299*R + 0.587*G + 0.114*B (normalized to 0-1 range)
            double brightness = (0.299 * backColor.R +
                                0.587 * backColor.G +
                                0.114 * backColor.B) / 255.0;

            // Returns black if the background is bright (brightness > 0.5), white if the background is dark.
            return brightness > 0.5
                ? System.Drawing.Color.Black
                : System.Drawing.Color.White;
        }
        private void skinsComboBox_SelectedIndexChanged(object sender, EventArgs e) // Event handler for skin selection changes.
        {
            try
            {
                if (_isUpdatingLanguage || _isLoadingForm) return;
                if (skinsComboBox.SelectedItem == null) return;

                string selectedDisplay = skinsComboBox.SelectedItem.ToString();

                if (selectedDisplay == "_________________")
                {
                    string savedKey = CopyThatProgram.Properties.Settings.Default.Skin ?? "Light Mode";
                    SelectSkinInCombo(savedKey);
                    return;
                }

                string englishKey = ToEn(selectedDisplay);

                switch (englishKey)
                {
                    case "Light Mode":
                        ApplySkin("Light Mode", Color.Black, Color.White);
                        break;

                    case "Dark Mode":
                        ApplySkin("Dark Mode", Color.White, Color.Black);
                        break;

                    case "Medium Mode":
                        ApplySkin("Medium Mode", Color.Black, Color.Gainsboro);
                        break;

                    case "Custom Color":
                        PickCustomColor();
                        return;

                    default:
                        ApplySkin("Light Mode", Color.Black, Color.White);
                        englishKey = "Light Mode";
                        break;
                }

                CopyThatProgram.Properties.Settings.Default.Skin = englishKey;
                CopyThatProgram.Properties.Settings.Default.skinsIndex = skinsComboBox.SelectedIndex;

                if (saveAutoCheckBox.Checked)
                    CopyThatProgram.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error applying skin: {ex.Message}");
                MessageBox.Show($"Error applying skin: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        /// <summary>
        /// Recursively changes the foreground color of a control and all its child controls.
        /// </summary>
        /// <param name="control">The parent control to start the color change from</param>
        /// <param name="newColor">The new foreground color to apply</param>
        private void ChangeControlsForeColor(System.Windows.Forms.Control control, System.Drawing.Color newColor) // A recursive method to change the foreground color of a control and all its children.
        {
            foreach (System.Windows.Forms.Control ctrl in control.Controls) // Iterates through all child controls.
            {
                ctrl.ForeColor = newColor; // Sets the foreground color of the current control.

                if (ctrl.HasChildren) // Checks if the current control has child controls.
                {
                    ChangeControlsForeColor(ctrl, newColor); // Recursively calls the method for the child control.
                }
            }
        }

        /// <summary>
        /// Recursively changes the background color of a control and all its child controls.
        /// </summary>
        /// <param name="control">The parent control to start the color change from</param>
        /// <param name="newColor">The new background color to apply</param>
        private void ChangeControlsBackColor(System.Windows.Forms.Control control, System.Drawing.Color newColor) // A recursive method to change the background color of a control and its children.
        {
            foreach (System.Windows.Forms.Control ctrl in control.Controls) // Iterates through all child controls.
            {
                ctrl.BackColor = newColor; // Sets the background color of the current control.

                if (ctrl.HasChildren) // Checks for child controls.
                {
                    ChangeControlsBackColor(ctrl, newColor); // Recursively calls the method.
                }
            }
        }

        /// <summary>
        /// Attempts to change the background color of Label, CheckBox, and TextBox controls.
        /// Note: This method contains a logical flaw - the conditional check will never be true
        /// since a control cannot be all three types simultaneously.
        /// </summary>
        /// <param name="newColor">The new background color to apply</param>
        private void ChangeControlColorsLabelsCheckBoxes(System.Drawing.Color newColor) // A method to change the background color of specific control types.
        {
            foreach (System.Windows.Forms.Control control in Controls) // Iterates through all controls on the form.
            {
                // This conditional check is logically flawed; a control cannot be a Label, CheckBox, and TextBox simultaneously.
                if ((control is Label) && (control is System.Windows.Forms.CheckBox) && (control is TextBox))
                {
                    control.BackColor = newColor; // Sets the background color, but this code block will never execute.
                }
            }
        }
        private void confirmDragDropCheckBox_CheckedChanged(object sender, EventArgs e) // Event handler for the confirm drag and drop checkbox.
        {
            if (confirmDragDropCheckBox.Checked) // If the checkbox is checked.
            {
                CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop = true; // Sets the application setting to true.
                ConfigureDragDropConfirmation(CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop); // Calls a method to configure the drag and drop behavior.
            }
            else // If the checkbox is unchecked.
            {
                CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop = false; // Sets the application setting to false.
                ConfigureDragDropConfirmation(CopyThatProgram.Properties.Settings.Default.ConfirmDragDrop); // Calls the configuration method.
            }
        }
        private void alwaysOnTopCheckBox_CheckedChanged(object sender, EventArgs e) // Event handler for the always-on-top checkbox.
        {
            if (alwaysOnTopCheckBox.Checked) // Checks if the checkbox is checked.
            {
                if (contextMenuCheckBox.Checked) // Checks if the context menu checkbox is also checked.
                {
                    alwaysOnTopCheckBox.Checked = false; // Unchecks the always-on-top box.
                    this.TopMost = false; // Sets the form to not be always on top.
                    MessageBox.Show("You may not have this form always on top if you add the context menu item.", "Information", // Shows an informational message box.
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                else // If the context menu checkbox is not checked.
                {
                    Properties.Settings.Default.AlwaysOnTop = true; // Sets the setting to true.
                    alwaysOnTopCheckBox.Checked = true; // Redundant, as this is already true.
                    this.TopMost = true; // Sets the form to be always on top.
                }
            }
            else // If the checkbox is unchecked.
            {
                Properties.Settings.Default.AlwaysOnTop = false; // Sets the setting to false.
                alwaysOnTopCheckBox.Checked = false; // Redundant, as this is already false.
                this.TopMost = false; // Sets the form to not be always on top.
            }
            if (saveAutoCheckBox.Checked) // Checks for auto-save.
            {
                Properties.Settings.Default.Save(); // Saves the settings.
            }
        }

        private void minimizeSystemTrayCheckBox_CheckedChanged(object sender, EventArgs e) // Event handler for the minimize to system tray checkbox.
        {
            if (minimizeSystemTrayCheckBox.Checked) // Checks if the checkbox is checked.
            {
                Properties.Settings.Default.MinimizeToTray = true; // Sets the setting to true.
                minimizeSystemTrayCheckBox.Checked = true; // Redundant, as this is already true.
            }
            else // If the checkbox is unchecked.
            {
                Properties.Settings.Default.MinimizeToTray = false; // Sets the setting to false.
                minimizeSystemTrayCheckBox.Checked = false; // Redundant, as this is already false.
            }

            if (saveAutoCheckBox.Checked) // Checks for auto-save.
            {
                Properties.Settings.Default.Save(); // Saves the settings.
            }
        }

        private void defaultSettingsButton_Click(object sender, EventArgs e) // Event handler for the "Default Settings" button.
        {
            Properties.Settings.Default.MinimizeToTray = true; // Sets the minimize to tray setting to true.
            minimizeSystemTrayCheckBox.Checked = true; // Updates the corresponding checkbox.

            Properties.Settings.Default.ConfirmDragDrop = true; // Sets the confirm drag and drop setting to true.
            confirmDragDropCheckBox.Checked = true; // Updates the checkbox.

            Properties.Settings.Default.SoundCopyComplete = true; // Sets the sound on copy complete setting to true.
            onFinishCheckBox.Checked = true; // Updates the checkbox.

            Properties.Settings.Default.SoundCancel = true; // Sets the sound on cancel setting to true.
            onCancelCheckBox.Checked = true; // Updates the checkbox.

            Properties.Settings.Default.SoundError = true; // Sets the sound on error setting to true.
            onErrorCheckBox.Checked = true; // Updates the checkbox.

            Properties.Settings.Default.SoundFileAdded = false; // Sets the sound on file added setting to false.
            onAddFilesCheckBox.Checked = false; // Updates the checkbox.

            Properties.Settings.Default.AutoSaveSettings = true; // Sets the auto-save settings to true.
            saveAutoCheckBox.Checked = true; // Updates the checkbox.

            Properties.Settings.Default.ContextMenu = true; // Sets the context menu setting to true.
            contextMenuCheckBox.Checked = true; // Updates the checkbox.

            Properties.Settings.Default.RestartOnError = true; // Sets the restart on error setting to true.
            restartCheckBox.Checked = true; // Updates the checkbox.

            Properties.Settings.Default.CopyFilesUnder = false; // Sets the copy files under setting to false.
            underMBCheckBox.Checked = false; // Updates the checkbox.

            Properties.Settings.Default.CopyFilesOver = false; // Sets the copy files over setting to false.
            overMBCheckBox.Checked = false; // Updates the checkbox.

            Properties.Settings.Default.Multithreading = true; // Sets the multithreading setting to true.
            multithreadCheckBox.Checked = true; // Updates the checkbox.

            if (proVersion) // Checks if the "proVersion" is enabled.
            {
                updateAutoCheckBox.Checked = true; // Updates auto-update checkbox.
                updateBetaCheckBox.Checked = true; // Updates beta update checkbox.
                updateAuto = true; // Sets the auto-update flag.
                updateBeta = true; // Sets the beta update flag.
                updateManuallyCheckBox.Checked = false; // Unchecks manual update.
                updateManually = false; // Sets the manual update flag.
                zipTogetherCheckBox.Checked = true; // Checks the zip together checkbox.
                fullPathsCheckBox.Checked = true; // Checks the full paths checkbox.
                emailPathsCheckBox.Checked = true; // Checks the email paths checkbox.
            }
            else // If it's not the "proVersion".
            {
                updateAutoCheckBox.Checked = false; // Unchecks auto-update.
                updateBetaCheckBox.Checked = false; // Unchecks beta update.
                updateAuto = false; // Sets the auto-update flag to false.
                updateBeta = false; // Sets the beta update flag to false.
                updateManuallyCheckBox.Checked = true; // Checks the manual update checkbox.
                updateManually = true; // Sets the manual update flag to true.
            }
        }

        private void clearSettingsButton_Click(object sender, EventArgs e) // Event handler for the "Clear Settings" button.
        {
            // Set the 'alwaysOnTop' setting to false and update the associated checkbox.
            Properties.Settings.Default.AlwaysOnTop = false; // Sets the setting to false.
            alwaysOnTopCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'minimizeToTray' setting to false and update the associated checkbox.
            Properties.Settings.Default.MinimizeToTray = false; // Sets the setting to false.
            minimizeSystemTrayCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'confirmDragDrop' setting to false and update the associated checkbox.
            Properties.Settings.Default.ConfirmDragDrop = false; // Sets the setting to false.
            confirmDragDropCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'contextMenu' setting to false and update the associated checkbox.
            Properties.Settings.Default.ContextMenu = false; // Sets the setting to false.
            contextMenuCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'soundOnFinish' setting to false and update the associated checkbox.
            Properties.Settings.Default.SoundCopyComplete = false; // Sets the setting to false.
            onFinishCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'soundOnCancel' setting to false and update the associated checkbox.
            Properties.Settings.Default.SoundCancel = false; // Sets the setting to false.
            onCancelCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'soundOnError' setting to false and update the associated checkbox.
            Properties.Settings.Default.SoundError = false; // Sets the setting to false.
            onErrorCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'soundOnFilesAdded' setting to false and update the associated checkbox.
            Properties.Settings.Default.SoundFileAdded = false; // Sets the setting to false.
            onAddFilesCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'saveAutomatically' setting to false and update the associated checkbox.
            Properties.Settings.Default.AutoSaveSettings = false; // Sets the setting to false.
            saveAutoCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'updateManually' setting to true and update the associated checkbox.
            Properties.Settings.Default.UpdateManually = true; // Sets the setting to true.
            updateManuallyCheckBox.Checked = true; // Updates the checkbox.

            // Set the 'restartProgram' setting to true and update the associated checkbox.
            Properties.Settings.Default.RestartOnError = true; // Sets the setting to true.
            restartCheckBox.Checked = true; // Updates the checkbox.

            // Set the 'underMB' setting to false and update the associated checkbox.
            Properties.Settings.Default.CopyFilesUnder = false; // Sets the setting to false.
            underMBCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'overMB' setting to false and update the associated checkbox.
            Properties.Settings.Default.CopyFilesOver = false; // Sets the setting to false.
            overMBCheckBox.Checked = false; // Updates the checkbox.

            // Set the 'fileFullPaths' setting to true and update the associated checkbox.
            Properties.Settings.Default.FileFullPaths = true; // Sets the setting to true.
            fullPathsCheckBox.Checked = true; // Updates the checkbox.

            // Set the 'emailFullPaths' setting to true and update the associated checkbox.
            Properties.Settings.Default.EmailFullPaths = true; // Sets the setting to true.
            emailPathsCheckBox.Checked = true; // Updates the checkbox.
        }
        private void saveSettingsButton_Click(object sender, EventArgs e) // Event handler for the "Save Settings" button.
        {
            Properties.Settings.Default.Save(); // Calls the Save method on the application's settings to persist them.
        }

        /// <summary>
        /// Determines whether the specified path represents the root directory of a drive.
        /// </summary>
        /// <param name="path">The path to check (e.g., "C:\", "D:\")</param>
        /// <returns>True if the path is a drive root, false otherwise</returns>
        private bool IsDriveRoot(string path)
        {
            try
            {
                if (path.Length == 3 && path[1] == ':' && path[2] == '\\') // Checks if the path has a length of 3 and a specific format (e.g., C:\).
                    return true; // Returns true if it matches the format.

                var dir = new DirectoryInfo(path); // Creates a DirectoryInfo object.
                return dir.Parent == null; // Returns true if the directory has no parent, indicating it's a root directory.
            }
            catch // Catches any exceptions that occur.
            {
                return false; // Returns false if an exception occurs, indicating it's not a valid drive root.
            }
        }

        /// <summary>
        /// Removes duplicate file items from a list based on file path comparison.
        /// Uses case-insensitive comparison to identify duplicates efficiently.
        /// </summary>
        /// <param name="existingList">The binding list containing existing file items</param>
        /// <param name="newItems">The list of new file items to filter for duplicates</param>
        private static void RemoveDuplicatesByFilePath(BindingList<FileInfoWrapper> existingList, List<FileInfoWrapper> newItems)
        {
            // Create a hash set to store file paths of existing items for fast lookup.
            var existingPaths = new HashSet<string>(existingList.Select(x => x.FilePath), StringComparer.OrdinalIgnoreCase);

            // Loop through the new items in reverse to safely remove duplicates without affecting the loop's index.
            for (int i = newItems.Count - 1; i >= 0; i--)
            {
                // Check if the current new item's file path already exists in the hash set.
                if (existingPaths.Contains(newItems[i].FilePath))
                {
                    // If a duplicate is found, remove the item from the list.
                    newItems.RemoveAt(i);
                }
            }
        }

        //private void AddFilesFromDirectory(string directoryPath, string targetDirectoryBase, bool recursive = true)
        //{
        //    if (Directory.Exists(directoryPath))
        //    {
        //        Invoke(new Action(() =>
        //        {
        //            _fileList.Add(new FileInfoWrapper
        //            {
        //                FileName = Path.GetFileName(directoryPath),
        //                FilePath = Path.GetFullPath(directoryPath),
        //                FileSize = FormatBytes(0),
        //                BytesRaw = 0,
        //                IsDirectory = true,
        //                Status = "Queued"
        //            });
        //        }));
        //    }

        //    foreach (string filePath in Directory.EnumerateFiles(directoryPath, "*", SearchOption.TopDirectoryOnly))
        //    {
        //        try
        //        {
        //            FileInfo file = new FileInfo(filePath);
        //            Invoke(new Action(() =>
        //            {
        //                Invoke(new Action(() =>
        //                {
        //                    _fileList.Add(new FileInfoWrapper
        //                    {
        //                        FileName = file.Name,
        //                        FilePath = file.FullName,
        //                        FileSize = FormatBytes(file.Length),
        //                        BytesRaw = file.Length,
        //                        IsDirectory = false,
        //                        Status = "Queued"
        //                    });
        //                }));
        //            }));
        //        }
        //        catch (UnauthorizedAccessException ex)
        //        {
        //            Debug.WriteLine($"Access denied to file: {filePath} - {ex.Message}");
        //        }
        //        catch (PathTooLongException ex)
        //        {
        //            Debug.WriteLine($"Path too long: {filePath} - {ex.Message}");
        //        }
        //        catch (Exception ex)
        //        {
        //            Debug.WriteLine($"Error adding file {filePath}: {ex.Message}");
        //        }
        //    }

        //    if (recursive)
        //    {
        //        foreach (string subDirectoryPath in Directory.EnumerateDirectories(directoryPath, "*", SearchOption.TopDirectoryOnly))
        //        {
        //            try
        //            {
        //                AddFilesFromDirectory(subDirectoryPath, targetDirectoryBase, recursive);
        //            }
        //            catch (UnauthorizedAccessException ex)
        //            {
        //                Debug.WriteLine($"Access denied to directory: {subDirectoryPath} - {ex.Message}");
        //            }
        //            catch (PathTooLongException ex)
        //            {
        //                Debug.WriteLine($"Path too long: {subDirectoryPath} - {ex.Message}");
        //            }
        //            catch (Exception ex)
        //            {
        //                Debug.WriteLine($"Error adding directory {subDirectoryPath}: {ex.Message}");
        //            }
        //        }
        //    }
        //}
        private async void fromDirPicBox_Click(object sender, EventArgs e)
        {
            // Set the default text and selection color for the DataGridView.
            filesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            filesDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            // Use a FolderBrowserDialog to allow the user to select a source folder.
            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a source folder to copy/move/delete from:";
                folderDialog.ShowNewFolderButton = false;

                // Check if the user selected a folder and clicked OK.
                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceDir = folderDialog.SelectedPath;

                    _sourceDirectories.Add(folderDialog.SelectedPath);
                    // Prevent the user from selecting a source folder that is also a target folder.
                    if (targetPaths.Any(tp => string.Equals(tp, sourceDir, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("The source folder cannot be the same as one of the target folders.",
                                        "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    // Temporarily disable various UI controls to prevent user interaction during the scan.
                    startButton.Enabled = false;
                    clearFileListButton.Enabled = false;
                    removeFileButton.Enabled = false;
                    cancelButton.Enabled = false;
                    skipButton.Enabled = false;
                    addFileButton.Enabled = false;

                    // Enable labels to show progress and information.
                    filePathLabel.Enabled = true;
                    totalCopiedProgressLabel.Enabled = true;
                    fileCountOnLabel.Enabled = true;
                    totalHDSpaceLeftLabel.Enabled = true;

                    // Create a Progress object to update the UI label asynchronously.
                    var progress = new Progress<string>(msg => fromFilesDirLabel.Text = msg);

                    try
                    {
                        // Asynchronously scan the selected directory for files.
                        await ScanDirectoryWithUpdatesAsync(sourceDir, updateIntervalMs: 50);
                        _bindingSource.ResetBindings(false);
                    }
                    catch (Exception ex)
                    {
                        // Handle and display any errors that occur during the scanning process.
                        fromFilesDirLabel.Text = $"Error: {ex.Message}";
                        MessageBox.Show($"An error occurred during scanning: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        // Re-enable all controls and update the UI to reflect the end of the scan.
                        EnableAllControls(cmdHomePage);
                        startButton.Enabled = true;
                        pauseResumeButton.Enabled = false;
                        cancelButton.Enabled = false;
                        skipButton.Enabled = false;
                        addFileButton.Enabled = true;
                        clearFileListButton.Enabled = true;
                        removeFileButton.Enabled = true;
                        sourceDirectoryLabel.Enabled = true;
                    }

                    // Play a sound to indicate that files have been added.
                    PlaySound("FileAdded");
                }

                // Reset the file path label and update the data bindings.
                filePathLabel.Text = "Nothing";
                _bindingSource.ResetBindings(false);
            }
        }

        private void contextMenuCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Check if the context menu checkbox is checked.
            if (contextMenuCheckBox.Checked == true)
            {
                // Set the ContextMenu setting to true.
                Properties.Settings.Default.ContextMenu = true;
                contextMenuCheckBox.Checked = true;
                alwaysOnTopCheckBox.Checked = false;
            }
            else
            {
                // Set the ContextMenu setting to false.
                Properties.Settings.Default.ContextMenu = false;
                contextMenuCheckBox.Checked = false;
            }

            // If the auto-save checkbox is checked, save the settings.
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }
        void editSavedCheckBoxes()
        {
            // GENERAL SETTINGS SECTION
            // Check and set the "Always on Top" setting.
            bool onTop = Properties.Settings.Default.AlwaysOnTop;
            if (onTop == true)
            {
                Properties.Settings.Default.AlwaysOnTop = true;
                this.TopMost = true;
                alwaysOnTopCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.AlwaysOnTop = false;
                this.TopMost = false;
                alwaysOnTopCheckBox.Checked = false;
            }

            // Check and set the "Confirm Drag and Drop" setting.
            bool alwaysConfirmDragAndDrop = Properties.Settings.Default.ConfirmDragDrop;
            if (alwaysConfirmDragAndDrop == true)
            {
                Properties.Settings.Default.ConfirmDragDrop = true;
                confirmDragDropCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.ConfirmDragDrop = false;
                confirmDragDropCheckBox.Checked = false;
            }

            // Check and set the "Minimize to System Tray" setting.
            bool minimizeToSystemTray = Properties.Settings.Default.MinimizeToTray;
            if (minimizeToSystemTray == true)
            {
                Properties.Settings.Default.MinimizeToTray = true;
                minimizeSystemTrayCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.MinimizeToTray = false;
                minimizeSystemTrayCheckBox.Checked = false;
            }

            // Check and set the "Context Menu" setting.
            bool contextmenu = Properties.Settings.Default.ContextMenu;
            if (contextmenu == true)
            {
                Properties.Settings.Default.ContextMenu = true;
                contextMenuCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.ContextMenu = false;
                contextMenuCheckBox.Checked = false;
            }

            // SOUND SETTINGS SECTION
            // Check and set the "Sound on Add Files" setting.
            bool soundAddFiles = Properties.Settings.Default.SoundFileAdded;
            if (soundAddFiles == true)
            {
                Properties.Settings.Default.SoundFileAdded = true;
                onAddFilesCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.SoundFileAdded = false;
                onAddFilesCheckBox.Checked = false;
            }

            // Check and set the "Sound on Cancel" setting.
            bool soundCancel = Properties.Settings.Default.SoundCancel;
            if (soundCancel)
            {
                Properties.Settings.Default.SoundCancel = true;
                onCancelCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.SoundCancel = false;
                onCancelCheckBox.Checked = false;
            }

            // Check and set the "Sound on Error" setting.
            bool soundError = Properties.Settings.Default.SoundError;
            if (soundError == true)
            {
                Properties.Settings.Default.SoundError = true;
                onErrorCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.SoundError = false;
                onErrorCheckBox.Checked = false;
            }

            // Check and set the "Sound on Finish" setting.
            bool soundFinish = Properties.Settings.Default.SoundCopyComplete;
            if (soundFinish == true)
            {
                Properties.Settings.Default.SoundCopyComplete = true;
                onFinishCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.SoundCopyComplete = false;
                onFinishCheckBox.Checked = false;
            }

            // OTHER SETTINGS SECTION
            // Check if the application is the "pro version" and enable/disable the register button accordingly.
            if (proVersion == true)
            {
                registerButton.Enabled = false;
            }
            else
            {
                registerButton.Enabled = true;
            }

            // Check and set the "Close on Error" and "Restart on Error" settings.
            if (closeProgram == true)
            {
                restartCheckBox.Checked = false;
                Properties.Settings.Default.CloseOnError = true;
                Properties.Settings.Default.RestartOnError = false;
            }
            else
            {
                restartCheckBox.Checked = true;
                Properties.Settings.Default.CloseOnError = false;
                Properties.Settings.Default.RestartOnError = true;
            }

            // This section seems to be a duplicate of the previous one, managing the same settings.
            if (restartProgram == true)
            {
                closeProgramCheckBox.Checked = false;
                Properties.Settings.Default.CloseOnError = false;
                Properties.Settings.Default.RestartOnError = true;
            }
            else
            {
                closeProgramCheckBox.Checked = true;
                Properties.Settings.Default.CloseOnError = true;
                Properties.Settings.Default.RestartOnError = false;
            }

            // Check and set the "Start with Windows" setting.
            bool startUp = Properties.Settings.Default.StartWithWindows;
            if (startUp == true)
            {
                startWithWindowsCheckBox.Checked = true;
            }
            else
            {
                startWithWindowsCheckBox.Checked = false;
            }

            // UPDATE SETTINGS SECTION
            // If it's the pro version, enable and set update settings checkboxes.
            if (proVersion == true)
            {
                bool updateAuto = Properties.Settings.Default.UpdateAuto;
                if (updateAuto == true)
                {
                    updateAutoCheckBox.Checked = true;
                    updateManuallyCheckBox.Checked = false;
                }

                bool updateBeta = Properties.Settings.Default.UpdateBeta;
                if (updateBeta == true)
                {
                    updateBetaCheckBox.Checked = true;
                    updateManuallyCheckBox.Checked = false;
                }

                bool updateManual = Properties.Settings.Default.UpdateManually;
                if (updateManual == true)
                {
                    updateManuallyCheckBox.Checked = true;
                    updateAutoCheckBox.Checked = false;
                    updateBetaCheckBox.Checked = false;
                }
            }
            else
            {
                // If not the pro version, disable beta and auto updates, and force manual updates.
                updateBetaCheckBox.Enabled = false;
                updateAutoCheckBox.Enabled = false;
                updateManuallyCheckBox.Checked = true;
                updateManually = true;
            }

            // EMAIL SETTINGS SECTION
            // If it's the pro version, enable the email settings group box.
            if (proVersion == true)
            {
                emailGroupBox.Enabled = true;
                // The following lines appear to be redundant or have conflicting logic.
                emailNamesCheckBox.Checked = true;
                emailPathsCheckBox.Checked = true;
                setUpEmailButton.Enabled = true;
                bool emailDirNames = Properties.Settings.Default.EmailOnlyNames;
                if (emailDirNames == true)
                {
                    emailPathsCheckBox.Checked = false;
                    Properties.Settings.Default.EmailOnlyNames = true;
                    Properties.Settings.Default.EmailFullPaths = false;
                }
                else
                {
                    emailPathsCheckBox.Checked = true;
                    Properties.Settings.Default.EmailOnlyNames = false;
                    Properties.Settings.Default.EmailFullPaths = true;
                }

                bool emailFull = Properties.Settings.Default.EmailFullPaths;
                if (emailFull == true)
                {
                    Properties.Settings.Default.EmailOnlyNames = false;
                    Properties.Settings.Default.EmailFullPaths = true;
                    emailNamesCheckBox.Checked = false;
                }
                else
                {
                    emailNamesCheckBox.Checked = true;
                    Properties.Settings.Default.EmailOnlyNames = true;
                    Properties.Settings.Default.EmailFullPaths = false;
                }

                // More redundant code for email settings.
                if (emailDirNames == true)
                {
                    Properties.Settings.Default.EmailOnlyNames = true;
                    emailPathsCheckBox.Checked = false;
                }
                else
                {
                    Properties.Settings.Default.EmailOnlyNames = false;
                    emailPathsCheckBox.Checked = true;
                }

                bool emailfullPaths = Properties.Settings.Default.EmailFullPaths;
                if (emailfullPaths == true)
                {
                    Properties.Settings.Default.EmailFullPaths = true;
                    emailNamesCheckBox.Checked = false;
                }
                else
                {
                    Properties.Settings.Default.EmailFullPaths = false;
                    emailNamesCheckBox.Checked = true;
                }
            }
            else
            {
                // If not the pro version, disable the email settings group box.
                emailGroupBox.Enabled = false;
            }

            // FILE/FOLDER SETTINGS SECTION
            // If it's the pro version, enable file/folder settings and set the 'only names' vs 'full paths' settings.
            if (proVersion == true)
            {
                fileDirSettingsGroupBox.Enabled = true;
                emailNamesCheckBox.Checked = true;
                emailPathsCheckBox.Checked = true;
                setUpEmailButton.Enabled = true;

                bool onlyNames = Properties.Settings.Default.FileOnlyNames;
                if (onlyNames == true)
                {
                    Properties.Settings.Default.FileOnlyNames = true;
                    fullPathsCheckBox.Checked = false;
                    onlyNamesCheckBox.Checked = true;
                }
                else
                {
                    Properties.Settings.Default.FileOnlyNames = false;
                    fullPathsCheckBox.Checked = true;
                    onlyNamesCheckBox.Checked = false;
                }

                // Duplicate logic for full paths.
                bool fullPaths = Properties.Settings.Default.FileFullPaths;
                if (fullPaths == true)
                {
                    Properties.Settings.Default.FileFullPaths = true;
                    onlyNamesCheckBox.Checked = false;
                    fullPathsCheckBox.Checked = true;
                }
                else
                {
                    Properties.Settings.Default.FileFullPaths = false;
                    onlyNamesCheckBox.Checked = true;
                    fullPathsCheckBox.Checked = false;
                }

                // Set the "Zip Separately" vs "Zip Together" settings.
                bool zipItSep = Properties.Settings.Default.ZipSeparately;
                if (zipItSep == true)
                {
                    Properties.Settings.Default.ZipSeparately = true;
                    Properties.Settings.Default.ZipTogether = false;
                    zipTogetherCheckBox.Checked = false;
                    zipSeparateCheckBox.Checked = true;
                }
                else
                {
                    Properties.Settings.Default.ZipSeparately = false;
                    Properties.Settings.Default.ZipTogether = true;
                    zipTogetherCheckBox.Checked = true;
                    zipSeparateCheckBox.Checked = false;
                }
            }
            else
            {
                // If not the pro version, disable the file/folder settings group box.
                fileDirSettingsGroupBox.Enabled = false;
            }

            // PERFORMANCE SETTINGS SECTION
            // Set the "Copy Files Under MB" setting.
            bool underMBY = Properties.Settings.Default.CopyFilesUnder;
            if (underMBY == true)
            {
                Properties.Settings.Default.CopyFilesUnder = true;
                underMBCheckBox.Checked = true;
            }
            else if (underMBY == false)
            {
                Properties.Settings.Default.CopyFilesUnder = false;
                underMBCheckBox.Checked = false;
            }

            // Set the "Copy Files Over MB" setting.
            bool overMBY = Properties.Settings.Default.CopyFilesOver;
            if (overMBY == true)
            {
                Properties.Settings.Default.CopyFilesOver = true;
                saveAutoCheckBox.Checked = true;
                overMBCheckBox.Checked = true;
            }
            else if (overMBY == false)
            {
                Properties.Settings.Default.CopyFilesOver = false;
                overMBCheckBox.Checked = false;
            }

            // Set the "Multithreading" setting.
            if (Properties.Settings.Default.Multithreading == true)
            {
                multithreadCheckBox.Checked = true;
                multiThread = true;
                Properties.Settings.Default.Multithreading = multiThread;
            }
            else
            {
                multithreadCheckBox.Checked = false;
                multiThread = false;
                Properties.Settings.Default.Multithreading = multiThread;
            }

            // THEMES AND LANGUAGES SETTINGS SECTION
            // Set the application's theme (skin) based on the saved setting.

            ApplyThemeSettings();

            //Modo Oscuro
            //Modo Medio
            //Modo Claro
            //_________________
            //Color Personalizado

            //Inglés
            //Español
            //Alemán
            //Francés

            // Set background color of various labels to transparent.
            nLabel.BackColor = System.Drawing.Color.Transparent;
            neLabel.BackColor = System.Drawing.Color.Transparent;
            eLabel.BackColor = System.Drawing.Color.Transparent;
            seLabel.BackColor = System.Drawing.Color.Transparent;
            sLabel.BackColor = System.Drawing.Color.Transparent;
            swLabel.BackColor = System.Drawing.Color.Transparent;
            wLabel.BackColor = System.Drawing.Color.Transparent;
            nwLabel.BackColor = System.Drawing.Color.Transparent;

            // AUTOMATICALLY SAVE, LOGGING, PRIORITY, & TRANSPARENCY SETTINGS
            // Set the "Auto Save Settings" setting.
            bool saveAuto = Properties.Settings.Default.AutoSaveSettings;
            if (saveAuto == true)
            {
                Properties.Settings.Default.AutoSaveSettings = true;
                saveAutoCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.AutoSaveSettings = false;
                saveAutoCheckBox.Checked = false;
            }

            // Set the "Save to Log File" setting.
            bool saveLog = Properties.Settings.Default.LogToFile;
            if (saveLog == true)
            {
                Properties.Settings.Default.LogToFile = true;
                logFileCheckBox.Checked = true;
            }
            else
            {
                Properties.Settings.Default.LogToFile = false;
                logFileCheckBox.Checked = false;
            }

            // Set the program's priority.
            if (priority == "Below Normal")
            {
                priorityTrackBar.Value = 0;
                priorityLabel.Text = "Program Priority: \nBelow Normal";
                Properties.Settings.Default.Priority = "Below Normal";
                using (Process p = Process.GetCurrentProcess()) { p.PriorityClass = ProcessPriorityClass.BelowNormal; }
            }
            else if (priority == "Normal")
            {
                priorityTrackBar.Value = 1;
                priorityLabel.Text = "Program Priority: \nNormal";
                Properties.Settings.Default.Priority = "Normal";
                using (Process p = Process.GetCurrentProcess()) { p.PriorityClass = ProcessPriorityClass.Normal; }
            }
            else if (priority == "Above Normal")
            {
                priorityTrackBar.Value = 2;
                priorityLabel.Text = "Program Priority: \nAbove Normal";
                Properties.Settings.Default.Priority = "Above Normal";
                using (Process p = Process.GetCurrentProcess()) { p.PriorityClass = ProcessPriorityClass.AboveNormal; }
            }
            else if (priority == "High")
            {
                priorityTrackBar.Value = 3;
                priorityLabel.Text = "Program Priority: \nHigh";
                Properties.Settings.Default.Priority = "High";
                using (Process p = Process.GetCurrentProcess()) { p.PriorityClass = ProcessPriorityClass.High; }
            }
            else if (priority == "Real Time")
            {
                priorityTrackBar.Value = 4;
                priorityLabel.Text = "Program Priority: \nReal Time";
                Properties.Settings.Default.Priority = "Real Time";
                using (Process p = Process.GetCurrentProcess()) { p.PriorityClass = ProcessPriorityClass.RealTime; }
            }

            // Set the form's opacity.
            int opacity = Properties.Settings.Default.Opacity;
            opacityTrackBar.Value = opacity;
            double opacityValue = opacityTrackBar.Value / 100.0;
            int opacityText = Convert.ToInt32(opacityValue * 100);
            opacityLabel.Text = "Opacity: \n" + opacityText.ToString() + "%";
            Properties.Settings.Default.Opacity = opacityText;
            this.Opacity = opacityValue;

            // Save settings if auto-save is enabled.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }

            // Final color adjustments for directional labels.
            nLabel.BackColor = System.Drawing.Color.Transparent;
            neLabel.BackColor = System.Drawing.Color.Transparent;
            eLabel.BackColor = System.Drawing.Color.Transparent;
            seLabel.BackColor = System.Drawing.Color.Transparent;
            sLabel.BackColor = System.Drawing.Color.Transparent;
            swLabel.BackColor = System.Drawing.Color.Transparent;
            wLabel.BackColor = System.Drawing.Color.Transparent;
            nwLabel.BackColor = System.Drawing.Color.Transparent;

            nLabel.ForeColor = System.Drawing.Color.Black;
            neLabel.ForeColor = System.Drawing.Color.Black;
            eLabel.ForeColor = System.Drawing.Color.Black;
            seLabel.ForeColor = System.Drawing.Color.Black;
            sLabel.ForeColor = System.Drawing.Color.Black;
            swLabel.ForeColor = System.Drawing.Color.Black;
            wLabel.ForeColor = System.Drawing.Color.Black;
            nwLabel.ForeColor = System.Drawing.Color.Black;
        }
        private void InitializeScrolling()
        {
            // Starts a timer to handle scrolling functionality.
            scrollTimer.Start();
        }
        void exitPlease()
        {
            // Checks if the "save automatically" checkbox is checked.
            if (saveAutoCheckBox.Checked)
            {
                // Upgrades the user settings from the previous version.
                Properties.Settings.Default.Upgrade();
                // Saves the user settings.
                Properties.Settings.Default.Save();
            }
            // Sets a flag to indicate that the operation has been canceled.
            _isCanceled = true;


            // Checks if a background worker is currently busy.
            if (_copyWorker.IsBusy)
            {
                // Requests the background worker to cancel its asynchronous operation.
                _copyWorker.CancelAsync();

                // Pauses the current thread for a short period to allow time for cancellation.
                Thread.Sleep(12);

                // Re-checks if the background worker is still busy.
                if (_copyWorker.IsBusy)
                {
                    // Outputs a message to the console.
                    Console.WriteLine("Background worker is still busy. Waiting for completion...");

                    // Subscribes to the RunWorkerCompleted event to exit the application after the worker finishes.
                    _copyWorker.RunWorkerCompleted += (s, e) => { Environment.Exit(0); };
                }
                else
                {
                    // Outputs a message to the console indicating the worker completed.
                    Console.WriteLine("Background worker completed after cancellation. Exiting...");
                    // Exits the application.
                    Environment.Exit(0);
                }
            }
            else
            {
                // Outputs a message to the console.
                Console.WriteLine("Background worker is not busy. Exiting...");
                // Exits the application.
                Environment.Exit(0);
            }

            // Pauses the thread for a short period.
            Thread.Sleep(12);
            // Closes the current form.
            this.Close();
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        // Imports a function from a Windows DLL to send messages to a window.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        // Imports a function from a Windows DLL to release the mouse capture.
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void titleLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Checks if the left mouse button was pressed.
            if (e.Button == MouseButtons.Left)
            {
                // Releases the mouse capture.
                ReleaseCapture();
                // Sends a message to the window to enable dragging.
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void filePathLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Checks if the left mouse button was pressed.
            if (e.Button == MouseButtons.Left)
            {
                // Releases the mouse capture.
                ReleaseCapture();

                // Sends a message to the window to enable dragging.
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
        private void fromFilesDirLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Checks if the left mouse button was pressed.
            if (e.Button == MouseButtons.Left)
            {
                // Releases the mouse capture.
                ReleaseCapture();

                // Sends a message to the window to enable dragging.
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void targetDirLabel_MouseDown(object sender, MouseEventArgs e)
        {
            // Checks if the left mouse button was pressed.
            if (e.Button == MouseButtons.Left)
            {
                // Releases the mouse capture.
                ReleaseCapture();

                // Sends a message to the window to enable dragging.
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void overwriteIfNewerCHKBOX_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if this checkbox is selected.
            if (overwriteIfNewerCheckBox.Checked)
            {
                // Sets the overwrite option string.
                overwriteOption = "Overwrite Type: If Newer";

                // Unchecks the other two overwrite options.
                overwriteAllCheckBox.Checked = false;
                doNotOverwriteCheckBox.Checked = false;
            }
            // If all three overwrite options are unchecked, this one is automatically selected.
            else if (!overwriteIfNewerCheckBox.Checked && !overwriteAllCheckBox.Checked && !doNotOverwriteCheckBox.Checked)
            {
                doNotOverwriteCheckBox.Checked = true;
                overwriteIfNewerCheckBox.Checked = false;
                overwriteAllCheckBox.Checked = false;
            }

            // Manages the state of the "restart" and "close" checkboxes.
            if (!restartCheckBox.Checked)
            {
                closeProgramCheckBox.Checked = true;
            }
            else if (restartCheckBox.Checked)
            {
                closeProgramCheckBox.Checked = false;
            }
            else if (!closeProgramCheckBox.Checked && !restartCheckBox.Checked)
            {
                restartCheckBox.Checked = true;
            }
        }
        private void keepDirStructCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If this checkbox is selected, it unchecks other related options.
            if (keepDirStructCheckBox.Checked)
            {
                keepOnlyFilesCheckBox.Checked = false;
                copyFilesDirsCheckBox.Checked = false;
            }
            else if (!leaveEmptyFoldersCheckBox.Checked && !keepOnlyFilesCheckBox.Checked && !copyFilesDirsCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = true;
            }
            // If all related options are unchecked, this one is automatically selected.
            else if (!leaveEmptyFoldersCheckBox.Checked && !keepOnlyFilesCheckBox.Checked && !copyFilesDirsCheckBox.Checked && !createCustomDirCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = true;
            }
        }

        private void overwriteAllCHKBOX_CheckedChanged(object sender, EventArgs e)
        {
            // If this checkbox is selected, it unchecks the other two overwrite options.
            if (overwriteAllCheckBox.Checked == true)
            {
                // Sets the overwrite option string.
                overwriteOption = "Overwrite: All Files";

                overwriteIfNewerCheckBox.Checked = false;
                doNotOverwriteCheckBox.Checked = false;
            }
            // If all three overwrite options are unchecked, the "do not overwrite" one is automatically selected.
            else if (!overwriteIfNewerCheckBox.Checked && !overwriteAllCheckBox.Checked && !doNotOverwriteCheckBox.Checked)
            {
                doNotOverwriteCheckBox.Checked = true;
                overwriteIfNewerCheckBox.Checked = false;
                overwriteAllCheckBox.Checked = false;
            }
        }

        private void createCustomDirCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If this checkbox is selected, it unchecks all other directory structure options.
            if (createCustomDirCheckBox.Checked)
            {
                if (keepDirStructCheckBox.Checked && leaveEmptyFoldersCheckBox.Checked)
                {
                    createCustomDirCheckBox.Checked = false;
                }
                else if (leaveEmptyFoldersCheckBox.Checked && copyFilesDirsCheckBox.Checked)
                {
                    createCustomDirCheckBox.Checked = false;
                }
            }
            // If all directory structure options are unchecked, the "keep directory structure" option is selected.
            else if (!leaveEmptyFoldersCheckBox.Checked && !keepOnlyFilesCheckBox.Checked && !copyFilesDirsCheckBox.Checked && !createCustomDirCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = true;
            }
        }

        private void doNotOverwriteCHKBOX_CheckedChanged(object sender, EventArgs e)
        {
            // If this checkbox is selected, it unchecks the other two overwrite options.
            if (doNotOverwriteCheckBox.Checked == true)
            {
                // Sets the overwrite option string.
                overwriteOption = "Overwrite: Do Not Overwrite";

                overwriteIfNewerCheckBox.Checked = false;
                overwriteAllCheckBox.Checked = false;
            }
            // If all three overwrite options are unchecked, this one is automatically selected.
            else if (!overwriteIfNewerCheckBox.Checked && !overwriteAllCheckBox.Checked && !doNotOverwriteCheckBox.Checked)
            {
                doNotOverwriteCheckBox.Checked = true;
                overwriteIfNewerCheckBox.Checked = false;
                overwriteAllCheckBox.Checked = false;
            }
        }

        private void copyFilesDirsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If this checkbox is selected, it unchecks all other directory structure options.
            if (copyFilesDirsCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = false;
                keepOnlyFilesCheckBox.Checked = false;
                createCustomDirCheckBox.Checked = false;

            }
            // If all directory structure options are unchecked, the "keep directory structure" option is selected.
            else if (!leaveEmptyFoldersCheckBox.Checked && !keepOnlyFilesCheckBox.Checked && !copyFilesDirsCheckBox.Checked && !createCustomDirCheckBox.Checked)
            {
                keepDirStructCheckBox.Checked = true;
            }
        }

        private void clearTextButton_Click(object sender, EventArgs e)
        {
            // Clears the text in the search text box.
            searchTextBox.Text = string.Empty;
            // Sets the focus to the search text box.
            searchTextBox.Focus();
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e)
        {
            // Gets the search string and converts it to lowercase for a case-insensitive search.
            string searchString = searchTextBox.Text.ToLower();

            // Loops through each row in the files data grid view.
            foreach (DataGridViewRow row in filesDataGridView.Rows)
            {
                // Gets the values from two specific cells in the current row and converts them to lowercase.
                string cellValue1 = row.Cells[2].Value.ToString().ToLower();
                string cellValue2 = row.Cells[3].Value.ToString().ToLower();

                // Checks if either cell value contains the search string.
                if (cellValue1.Contains(searchString) || cellValue2.Contains(searchString))
                {
                    // Selects the row if a match is found.
                    row.Selected = true;

                    // Scrolls the data grid view to display the found row.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = row.Index;

                    // Exits the loop after finding the first match.
                    break;
                }
                else
                {
                    // Deselects the row if no match is found.
                    row.Selected = false;
                }
            }
        }

        private void moveBottomPicBox_Click(object sender, EventArgs e)
        {
            try
            {
                // Gets the index of the currently selected row.
                int index = filesDataGridView.SelectedRows[0].Index;
                DataGridViewRow row = new DataGridViewRow();

                // Checks if the selected row is already the last one.
                if (index == filesDataGridView.Rows.Count - 1)
                {
                    // If so, it returns without doing anything.
                    return;
                }
                else
                {
                    // Scrolls to the last row.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = filesDataGridView.RowCount - 1;
                    // Gets the index of the last row.
                    int lastRowIndex = filesDataGridView.Rows.Count - 1;
                    // If the last row index is valid, it selects the last row.
                    if (lastRowIndex >= 0)
                    {
                        filesDataGridView.Rows[lastRowIndex].Selected = true;
                    }
                }
            }
            // Catches any exceptions and ignores them.
            catch { }
        }

        private void fileDownPicBox_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                // Gets the index of the currently selected row.
                int index = filesDataGridView.SelectedRows[0].Index;

                // Checks if the selected row is the last one.
                if (index == filesDataGridView.Rows.Count - 1)
                {
                    // If so, it returns without doing anything.
                    return;
                }
                else
                {
                    row = filesDataGridView.SelectedRows[0];

                    // Clears any existing selection.
                    filesDataGridView.ClearSelection();
                    // Selects the next row.
                    filesDataGridView.Rows[index + 1].Selected = true;
                    // Scrolls the data grid view to display the newly selected row.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = index + 1;
                }
            }
            // Catches any exceptions and ignores them.
            catch { }
        }

        /// <summary>
        /// Scrolls the files DataGridView to the top row and selects the first item.
        /// This method ensures the grid view is positioned at the beginning of the file list
        /// with the first row visibly selected.
        /// </summary>
        private void ScrollToTopRow()
        {
            // Checks if the data grid view has any rows.
            if (filesDataGridView.Rows.Count > 0)
            {
                // Clears the current selection.
                filesDataGridView.ClearSelection();
                // Selects the first row.
                filesDataGridView.Rows[0].Selected = true;
                // Sets the current cell to the first cell of the first row.
                filesDataGridView.CurrentCell = filesDataGridView.Rows[0].Cells[0];
                // Scrolls the data grid view to the top.
                filesDataGridView.FirstDisplayedScrollingRowIndex = 0;
            }
        }

        private void fileUpPicBox_Click(object sender, EventArgs e)
        {
            try
            {
                DataGridViewRow row = new DataGridViewRow();
                // Gets the index of the currently selected row.
                int index = filesDataGridView.SelectedRows[0].Index;

                // Checks if the selected row is the second or first row.
                if (index == 1 || index == 0)
                {
                    // If the data grid view has rows.
                    if (filesDataGridView.Rows.Count > 0)
                    {
                        // Selects the first row.
                        filesDataGridView.Rows[0].Selected = true;
                        // Scrolls to the top.
                        filesDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    }
                    // Returns without further action.
                    return;
                }
                // Checks if the selected row is the third or fourth row.
                else if (index == 2 || index == 3)
                {
                    // Clears the current selection.
                    filesDataGridView.ClearSelection();
                    // Selects the previous row.
                    filesDataGridView.Rows[index - 1].Selected = true;
                    // Scrolls to the newly selected row.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = index - 1;
                }
                else
                {
                    // For all other cases, clears selection.
                    filesDataGridView.ClearSelection();
                    // Selects the previous row.
                    filesDataGridView.Rows[index - 1].Selected = true;
                    // Scrolls to the newly selected row.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = index - 1;
                }
            }
            // Catches any exceptions and ignores them.
            catch { }
        }

        private void removeDirBGW_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Sets the text of a label to a default value.
            fromFilesDirLabel.Text = "Select Files/Directory";

            // Sets the selected tab to the command home page.
            tabControl1.SelectedTab = cmdHomePage;
        }

        private void priorityTrackBar_Scroll(object sender, EventArgs e)
        {
            // Checks the value of the track bar to set the process priority.
            if (priorityTrackBar.Value == 0)
            {
                // Sets the label text and saves the setting.
                priorityLabel.Text = "Program Priority: \nBelow Normal";
                Properties.Settings.Default.Priority = "Below Normal";
                // Changes the priority of the current process.
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.BelowNormal;
                }
            }
            else if (priorityTrackBar.Value == 1)
            {
                // Sets the label text and saves the setting.
                priorityLabel.Text = "Program Priority: \nNormal";
                Properties.Settings.Default.Priority = "Normal";
                // Changes the priority of the current process.
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.Normal;
                }
            }
            else if (priorityTrackBar.Value == 2)
            {
                // Sets the label text and saves the setting.
                priorityLabel.Text = "Program Priority: \nAbove Normal";
                Properties.Settings.Default.Priority = "Above Normal";
                // Changes the priority of the current process.
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.AboveNormal;
                }
            }
            else if (priorityTrackBar.Value == 3)
            {
                // Sets the label text and saves the setting.
                priorityLabel.Text = "Program Priority: \nHigh";
                Properties.Settings.Default.Priority = "High";
                // Changes the priority of the current process.
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.High;
                }
            }
            else if (priorityTrackBar.Value == 4)
            {
                // Sets the label text and saves the setting.
                priorityLabel.Text = "Program Priority: \nReal Time";
                Properties.Settings.Default.Priority = "Real Time";
                // Changes the priority of the current process.
                using (Process p = Process.GetCurrentProcess())
                {
                    p.PriorityClass = ProcessPriorityClass.RealTime;
                }
            }
            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void opacityTrackBar_Scroll(object sender, EventArgs e)
        {
            // Calculates the opacity value from the track bar value.
            double opacityValue = opacityTrackBar.Value / 100.0;

            // Converts the opacity value to an integer percentage.
            int opacityText = Convert.ToInt32(opacityValue * 100);

            // Updates the opacity label text.
            opacityLabel.Text = "Opacity: \n" + opacityText.ToString() + "%";

            // Saves the opacity setting.
            Properties.Settings.Default.Opacity = opacityText;

            // Sets the form's opacity.
            this.Opacity = opacityValue;

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void onFinishCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (onFinishCheckBox.Checked)
            {
                // Sets the corresponding application setting to true.
                Properties.Settings.Default.SoundCopyComplete = true;
                onFinishCheckBox.Checked = true;
            }
            else
            {
                // Sets the corresponding application setting to false.
                Properties.Settings.Default.SoundCopyComplete = false;
                onFinishCheckBox.Checked = false;
            }

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void onAddFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (onAddFilesCheckBox.Checked)
            {
                // Sets the corresponding application setting to true.
                Properties.Settings.Default.SoundFileAdded = true;
                onAddFilesCheckBox.Checked = true;
            }
            else
            {
                // Sets the corresponding application setting to false.
                Properties.Settings.Default.SoundFileAdded = false;
                onAddFilesCheckBox.Checked = false;
            }
            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void onCancelCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (onCancelCheckBox.Checked)
            {
                // Sets the corresponding application setting to true.
                Properties.Settings.Default.SoundCancel = true;
                onCancelCheckBox.Checked = true;
            }
            else
            {
                // Sets the corresponding application setting to false.
                Properties.Settings.Default.SoundCancel = false;
                onCancelCheckBox.Checked = false;
            }

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void onErrorCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (onErrorCheckBox.Checked)
            {
                // Sets the corresponding application setting to true.
                Properties.Settings.Default.SoundError = true;
                onErrorCheckBox.Checked = true;
            }
            else
            {
                // Sets the corresponding application setting to false.
                Properties.Settings.Default.SoundError = false;
                onErrorCheckBox.Checked = false;
            }

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }
        private void updateManuallyCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (updateManuallyCheckBox.Checked)
            {
                updateManuallyCheckBox.Checked = true;
                // Sets the corresponding application setting to true.
                Properties.Settings.Default.UpdateManually = true;
                // Unchecks the other two update options.
                updateBetaCheckBox.Checked = false;
                updateAutoCheckBox.Checked = false;
            }
            // If all three update options are unchecked, this one is automatically selected.
            else if (!updateAutoCheckBox.Checked && !updateBetaCheckBox.Checked)
            {
                Properties.Settings.Default.UpdateManually = true;
                updateManuallyCheckBox.Checked = true;
            }
            else
            {
                // Sets the corresponding application setting to false.
                Properties.Settings.Default.UpdateManually = false;
                updateManuallyCheckBox.Checked = false;
            }
            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void updateAutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the program is not the "Pro" version, this option is disabled.
            if (proVersion == false)
            {
                updateAutoCheckBox.Checked = false;
                updateManuallyCheckBox.Checked = true;
                Properties.Settings.Default.UpdateManually = true;
            }
            else
            {
                // If the checkbox is checked, it sets the setting to true.
                if (updateAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.UpdateAuto = true;
                }
                else
                {
                    // Otherwise, it sets the setting to false.
                    Properties.Settings.Default.UpdateAuto = false;
                    updateAutoCheckBox.Checked = false;
                }
                // Checks if either auto or beta update is selected.
                if (updateBetaCheckBox.Checked || updateAutoCheckBox.Checked)
                {
                    // Unchecks the manual update option.
                    updateManuallyCheckBox.Checked = false;
                    Properties.Settings.Default.UpdateManually = false;
                }
                else
                {
                    // Otherwise, it checks the manual update option.
                    updateManuallyCheckBox.Checked = true;
                    Properties.Settings.Default.UpdateManually = true;
                }
            }
            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void updateBetaCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the program is not the "Pro" version, this option is disabled.
            if (proVersion == false)
            {
                updateBetaCheckBox.Checked = false;
                updateManuallyCheckBox.Checked = true;
                Properties.Settings.Default.UpdateManually = true;
            }
            else
            {
                // If the checkbox is checked, it sets the setting to true.
                if (updateBetaCheckBox.Checked)
                {
                    Properties.Settings.Default.UpdateBeta = true;
                }
                else
                {
                    // Otherwise, it sets the setting to false.
                    Properties.Settings.Default.UpdateBeta = false;
                    updateBetaCheckBox.Checked = false;
                }
                // Checks if either beta or auto update is selected.
                if (updateBetaCheckBox.Checked || updateAutoCheckBox.Checked)
                {
                    // Unchecks the manual update option.
                    updateManuallyCheckBox.Checked = false;
                    Properties.Settings.Default.UpdateManually = false;
                }
                else
                {
                    // Otherwise, it checks the manual update option.
                    updateManuallyCheckBox.Checked = true;
                    Properties.Settings.Default.UpdateManually = true;
                }

                // If auto-save is enabled, saves the settings.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
        }

        /// <summary>
        /// Syncs registry with saved setting at startup.
        /// </summary>
        private void SyncStartupSetting()
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_KEY, true))
                {
                    bool registryHasEntry = key.GetValue(APP_Name) != null;
                    bool settingEnabled = Properties.Settings.Default.StartWithWindows;

                    if (settingEnabled && !registryHasEntry)
                    {
                        // Setting says enabled but registry missing -> add it
                        key.SetValue(APP_Name, Application.ExecutablePath);
                    }
                    else if (!settingEnabled && registryHasEntry)
                    {
                        // Setting says disabled but registry has entry -> remove it
                        key.DeleteValue(APP_Name);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Startup sync failed: {ex.Message}",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private void startWithWindowsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                using (RegistryKey key = Registry.CurrentUser.OpenSubKey(RUN_KEY, true))
                {
                    if (startWithWindowsCheckBox.Checked)
                    {
                        // Add to startup
                        key.SetValue(APP_Name, Application.ExecutablePath);
                        Properties.Settings.Default.StartWithWindows = true;
                    }
                    else
                    {
                        // Remove from startup
                        if (key.GetValue(APP_Name) != null)
                            key.DeleteValue(APP_Name);
                        Properties.Settings.Default.StartWithWindows = false;
                    }

                    // Save setting
                    Properties.Settings.Default.Save();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to update startup setting: {ex.Message}",
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void restartCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (restartCheckBox.Checked)
            {
                // Unchecks the other checkbox and sets the corresponding settings.
                closeProgramCheckBox.Checked = false;
                Properties.Settings.Default.CloseOnError = false;
                Properties.Settings.Default.RestartOnError = true;
            }
            else
            {
                // Checks the other checkbox and sets the corresponding settings.
                closeProgramCheckBox.Checked = true;
                Properties.Settings.Default.CloseOnError = true;
                Properties.Settings.Default.RestartOnError = false;
            }

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void closeProgramCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (closeProgramCheckBox.Checked)
            {
                // Unchecks the other checkbox and sets the corresponding settings.
                restartCheckBox.Checked = false;
                Properties.Settings.Default.CloseOnError = true;
                Properties.Settings.Default.RestartOnError = false;
            }
            else
            {
                // Checks the other checkbox and sets the corresponding settings.
                restartCheckBox.Checked = true;
                Properties.Settings.Default.CloseOnError = false;
                Properties.Settings.Default.RestartOnError = true;
            }
            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void registerButton_Click(object sender, EventArgs e)
        {
            // Checks if the serial number is a specific value.
            if (serialMaskedTextBox.Text == "ABCD-EFGH-IJKL-MN12")
            {
                // If correct, enables the pro version, disables the register button, and clears the text box.
                proVersion = true;
                registerButton.Enabled = false;
                editSavedCheckBoxes();
                serialMaskedTextBox.Text = "";
            }
            else
            {
                // If incorrect, sets the pro version to false and enables the register button.
                proVersion = false;
                registerButton.Enabled = true;
                editSavedCheckBoxes();
            }
        }

        // Returns the value of the globalMODE string variable.
        public string GetStringVariable()
        {
            return globalMODE;
        }
        private void setUpEmailButton_Click(object sender, EventArgs e)
        {
            // Checks if there are any rows in the data grid view.
            if (dataGridView1.Rows.Count > 0)
            {
                // Checks if an item is selected in the skins combo box.
                if (skinsComboBox.SelectedItem != null)
                {
                    if (languageComboBox.SelectedItem.ToString() == "English" || languageComboBox.SelectedItem.ToString() == "Inglés")
                    {
                        // Gets the selected skin string.
                        string selectedSkin = skinsComboBox.SelectedItem.ToString();
                        // Uses a switch statement to set the global mode based on the selected skin.
                        switch (selectedSkin)
                        {
                            case "Dark Mode":
                                globalMODE = "Dark Mode";
                                break;
                            case "Medium Mode":
                                globalMODE = "Medium Mode";
                                break;
                            case "Light Mode":
                                globalMODE = "Light Mode";
                                break;
                            case "Custom Color":
                                globalMODE = "Custom Color";
                                break;
                            default:
                                globalMODE = "Dark Mode";
                                break;
                        }

                        // Creates and shows a new email form.
                        new emailForm().ShowDialog();
                    }
                    else if (languageComboBox.SelectedItem.ToString() == "Spanish" || languageComboBox.SelectedItem.ToString() == "Español")
                    {
                        // Gets the selected skin string.
                        string selectedSkin = skinsComboBox.SelectedItem.ToString();
                        // Uses a switch statement to set the global mode based on the selected skin.
                        switch (selectedSkin)
                        {
                            case "Modo Claro":
                                globalMODE = "Modo Claro";
                                break;
                            case "Modo Medio":
                                globalMODE = "Modo Medio";
                                break;
                            case "Modo Oscuro":
                                globalMODE = "Modo Oscuro";
                                break;
                            case "Color Personalizado":
                                globalMODE = "Color Personalizado";
                                break;
                            default:
                                globalMODE = "Modo Oscuro";
                                break;
                        }
                        // Creates and shows a new email form.
                        new emailForm().ShowDialog();
                    }
                }
            }
        }

        private void setUpSMSButton_Click(object sender, EventArgs e)
        {
            // Checks if an item is selected in the skins combo box.
            if (skinsComboBox.SelectedItem != null)
            {
                if (languageComboBox.SelectedItem.ToString() == "English" || languageComboBox.SelectedItem.ToString() == "Inglés")
                {
                    // Gets the selected skin string.
                    string selectedSkin = skinsComboBox.SelectedItem.ToString();
                    // Uses a switch statement to set the global mode based on the selected skin.
                    switch (selectedSkin)
                    {
                        case "Dark Mode":
                            globalMODE = "Dark Mode";
                            break;
                        case "Medium Mode":
                            globalMODE = "Medium Mode";
                            break;
                        case "Light Mode":
                            globalMODE = "Light Mode";
                            break;
                        case "Custom Color":
                            globalMODE = "Custom Color";
                            break;
                        default:
                            globalMODE = "Dark Mode";
                            break;
                    }

                    // Creates and shows a new email form.
                    new emailForm().ShowDialog();
                }
                else if (languageComboBox.SelectedItem.ToString() == "Spanish" || languageComboBox.SelectedItem.ToString() == "Español")
                {
                    // Gets the selected skin string.
                    string selectedSkin = skinsComboBox.SelectedItem.ToString();
                    // Uses a switch statement to set the global mode based on the selected skin.
                    switch (selectedSkin)
                    {
                        case "Modo Claro":
                            globalMODE = "Modo Claro";
                            break;
                        case "Modo Medio":
                            globalMODE = "Modo Medio";
                            break;
                        case "Modo Oscuro":
                            globalMODE = "Modo Oscuro";
                            break;
                        case "Color Personalizado":
                            globalMODE = "Color Personalizado";
                            break;
                        default:
                            globalMODE = "Modo Oscuro";
                            break;
                    }
                    // Creates and shows a new email form.
                    new smsForm().ShowDialog();
                }
            }
        }

        private void emailPathsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (emailPathsCheckBox.Checked)
            {
                // Sets the corresponding settings and unchecks the other checkbox.
                Properties.Settings.Default.EmailOnlyNames = false;
                Properties.Settings.Default.EmailFullPaths = true;
                emailNamesCheckBox.Checked = false;
            }
            else
            {
                // Sets the corresponding settings and checks the other checkbox.
                emailNamesCheckBox.Checked = true;
                Properties.Settings.Default.EmailOnlyNames = true;
                Properties.Settings.Default.EmailFullPaths = false;
            }

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.Save();
            }
        }

        private void emailNamesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (emailNamesCheckBox.Checked)
            {
                // Unchecks the other checkbox and sets the corresponding settings.
                emailPathsCheckBox.Checked = false;
                Properties.Settings.Default.EmailOnlyNames = true;
                Properties.Settings.Default.EmailFullPaths = false;
            }
            else
            {
                // Checks the other checkbox and sets the corresponding settings.
                emailPathsCheckBox.Checked = true;
                Properties.Settings.Default.EmailOnlyNames = false;
                Properties.Settings.Default.EmailFullPaths = true;
            }
            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void zipTogetherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (zipTogetherCheckBox.Checked)
            {
                // Sets the corresponding settings and unchecks the other checkbox.
                Properties.Settings.Default.ZipTogether = true;
                Properties.Settings.Default.ZipSeparately = false;
                zipTogetherCheckBox.Checked = true;
                zipSeparateCheckBox.Checked = false;
            }
            else
            {
                // Sets the corresponding settings and checks the other checkbox.
                Properties.Settings.Default.ZipTogether = false;
                Properties.Settings.Default.ZipSeparately = true;
                zipTogetherCheckBox.Checked = false;
                zipSeparateCheckBox.Checked = true;
            }
            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void zipSeparateCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (zipSeparateCheckBox.Checked)
            {
                // Sets the corresponding setting and unchecks the other checkbox.
                Properties.Settings.Default.ZipSeparately = true;
                zipTogetherCheckBox.Checked = false;
            }
            else
            {
                // Sets the corresponding setting and checks the other checkbox.
                Properties.Settings.Default.ZipTogether = false;
                zipTogetherCheckBox.Checked = true;
            }

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void fullPathsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (fullPathsCheckBox.Checked)
            {
                // Sets the corresponding setting and unchecks the other checkbox.
                Properties.Settings.Default.FileFullPaths = true;
                fullPathsCheckBox.Checked = true;
                onlyNamesCheckBox.Checked = false;
            }
            else
            {
                // Sets the corresponding setting and checks the other checkbox.
                Properties.Settings.Default.FileFullPaths = false;
                fullPathsCheckBox.Checked = false;
                onlyNamesCheckBox.Checked = true;
            }

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            // Checks if the data grid view is empty.
            if (dataGridView1.Rows.Count == 0)
            {
                // Displays a message box if there is no data to export.
                MessageBox.Show("There is no data to export.", "Copy That v1.0 File/Directory Tool - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            // Calls a method to update the total count label.
            UpdateTotalCountLabel();

            // Displays the export menu at the location of the export button.
            exportMenu.Show(exportButton, new System.Drawing.Point(0, exportButton.Height));
        }

        private void onlyNamesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (onlyNamesCheckBox.Checked)
            {
                // Sets the corresponding setting and unchecks the other checkbox.
                Properties.Settings.Default.FileOnlyNames = true;
                onlyNamesCheckBox.Checked = true;
                fullPathsCheckBox.Checked = false;
            }
            else
            {
                // Sets the corresponding setting and checks the other checkbox.
                Properties.Settings.Default.FileOnlyNames = false;
                onlyNamesCheckBox.Checked = false;
                fullPathsCheckBox.Checked = true;
            }

            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void multithreadCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the checkbox is selected.
            if (multithreadCheckBox.Checked)
            {
                // Sets the corresponding setting to true.
                Properties.Settings.Default.Multithreading = true;
            }
            else
            {
                // Sets the corresponding setting to false.
                Properties.Settings.Default.Multithreading = false;
            }
            // If auto-save is enabled, saves the settings.
            if (saveAutoCheckBox.Checked == true)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void cmbOnFinishMulti_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If no item is selected, it defaults to the first item.
            if (onFinishMultiComboBox.SelectedIndex == -1)
            {
                onFinishMultiComboBox.SelectedIndex = 0;
            }
            // If no item is selected, it defaults to the first item.
            if (onFinishComboBox.SelectedIndex == -1)
            {
                onFinishComboBox.SelectedIndex = 0;
            }
            // Synchronizes the text of the two combo boxes.
            onFinishComboBox.Text = onFinishMultiComboBox.Text;
        }

        private void nLabel_Click(object sender, EventArgs e)
        {
            // Sets the form's start position to manual.
            this.StartPosition = FormStartPosition.Manual;

            // Gets the primary screen's working area.
            Screen primaryScreen = Screen.PrimaryScreen;
            System.Drawing.Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculates the top and centered left position.
            int top = workingArea.Top;
            int left = (workingArea.Width - this.Width) / 2;

            // Sets the form's location.
            this.Location = new System.Drawing.Point(left, top);
        }

        private void neLabel_Click(object sender, EventArgs e)
        {
            // Sets the form's start position to manual.
            this.StartPosition = FormStartPosition.Manual;

            // Gets the primary screen's working area.
            Screen primaryScreen = Screen.PrimaryScreen;
            System.Drawing.Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculates the top-right position.
            int left = workingArea.Right - this.Width;
            int top = workingArea.Top;

            // Sets the form's location.
            this.Location = new System.Drawing.Point(left, top);
        }

        private void eLabel_Click(object sender, EventArgs e)
        {
            // Sets the form's start position to manual.
            this.StartPosition = FormStartPosition.Manual;

            // Gets the primary screen's working area.
            Screen primaryScreen = Screen.PrimaryScreen;
            System.Drawing.Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculates the right and centered vertical position.
            int left = workingArea.Right - this.Width;
            int top = (workingArea.Height - this.Height) / 2;

            // Sets the form's location.
            this.Location = new System.Drawing.Point(left, top);
        }

        private void seLabel_Click(object sender, EventArgs e)
        {
            // Sets the form's start position to manual.
            this.StartPosition = FormStartPosition.Manual;
            // Gets the primary screen's working area.
            Screen primaryScreen = Screen.PrimaryScreen;
            System.Drawing.Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculates the bottom-right position.
            int left = workingArea.Right - this.Width;
            int top = workingArea.Bottom - this.Height;

            // Sets the form's location.
            this.Location = new System.Drawing.Point(left, top);
        }

        private void sLabel_Click(object sender, EventArgs e)
        {
            // Sets the form's starting position to be manually controlled.
            this.StartPosition = FormStartPosition.Manual;

            // Gets the primary screen and its working area (excluding the taskbar).
            Screen primaryScreen = Screen.PrimaryScreen;
            System.Drawing.Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculates the 'top' position to place the form at the bottom of the screen.
            int top = workingArea.Bottom - this.Height;
            // Calculates the 'left' position to center the form horizontally.
            int left = (workingArea.Width - this.Width) / 2;

            // Sets the form's new location.
            this.Location = new System.Drawing.Point(left, top);
        }

        private void swLabel_Click(object sender, EventArgs e)
        {
            // Sets the form's starting position to be manually controlled.
            this.StartPosition = FormStartPosition.Manual;

            // Gets the primary screen and its working area (excluding the taskbar).
            Screen primaryScreen = Screen.PrimaryScreen;
            System.Drawing.Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculates the 'left' position to place the form at the far left of the screen.
            int left = workingArea.Left;
            // Calculates the 'top' position to place the form at the bottom of the screen.
            int top = workingArea.Bottom - this.Height;

            // Sets the form's new location.
            this.Location = new System.Drawing.Point(left, top);
        }

        private void wLabel_Click(object sender, EventArgs e)
        {
            // Sets the form's starting position to be manually controlled.
            this.StartPosition = FormStartPosition.Manual;

            // Gets the primary screen and its working area.
            Screen primaryScreen = Screen.PrimaryScreen;
            System.Drawing.Rectangle workingArea = primaryScreen.WorkingArea;

            // Calculates the 'left' position to place the form at the far left of the screen.
            int left = workingArea.Left;
            // Calculates the 'top' position to vertically center the form.
            int top = (workingArea.Height - this.Height) / 2;

            // Sets the form's new location.
            this.Location = new System.Drawing.Point(left, top);
        }

        private void nwLabel_Click(object sender, EventArgs e)
        {
            // Sets the form's starting position to be manually controlled.
            this.StartPosition = FormStartPosition.Manual;

            // Gets the primary screen and its working area.
            Screen primaryScreen = Screen.PrimaryScreen;
            System.Drawing.Rectangle workingArea = primaryScreen.WorkingArea;

            // Sets the 'left' and 'top' positions to place the form in the top-left corner.
            int left = workingArea.Left;
            int top = workingArea.Top;

            // Sets the form's new location.
            this.Location = new System.Drawing.Point(left, top);
        }

        private void StoreOriginalSize()
        {
            // Stores the current size of the form in a variable.
            originalSize = this.Size;
        }

        private void RollTimer_Tick(object sender, EventArgs e)
        {
            // Calculates the new height for the form based on the animation direction and step.
            int newHeight = this.Height + animationStep * animationDirection;

            // Checks if the form has reached its target height.
            if ((animationDirection < 0 && newHeight <= targetHeight) ||
        (animationDirection > 0 && newHeight >= targetHeight))
            {
                // Sets the form's height to the exact target height.
                this.Height = targetHeight;
                // Stops the animation timer.
                rollTimer.Stop();
                // Sets the animating flag to false.
                isAnimating = false;

                // If rolling down, makes the tab control visible and updates the rolled-up flag.
                if (animationDirection > 0)
                {
                    tabControl1.Visible = true;
                    isRolledUp = false;
                }
                // If rolling up, updates the rolled-up flag.
                else
                {
                    isRolledUp = true;
                }
            }
            else
            {
                // Continues the animation by setting the form's height to the new height.
                this.Height = newHeight;
            }
        }

        /// <summary>
        /// Animates the form to roll down to its original full height.
        /// This method expands the form from a rolled-up state to show all content.
        /// </summary>
        private void ToggleRollDown()
        {
            // Prevents rolling down if already animating or not rolled up.
            if (isAnimating || !isRolledUp) return;

            // Sets the target height to the original form size.
            targetHeight = originalSize.Height;
            // Sets the animation direction to 'down'.
            animationDirection = +1;
            // Sets the animating flag to true.
            isAnimating = true;
            // Starts the roll timer.
            rollTimer.Start();
        }

        /// <summary>
        /// Animates the form to roll up to a compact height, showing only the title area.
        /// This method collapses the form to hide content while keeping the title visible.
        /// </summary>
        private void ToggleRollUp()
        {
            // Prevents rolling up if already animating.
            if (isAnimating) return;

            // Undocks and unanchors the tab control to allow precise height control.
            tabControl1.Dock = DockStyle.None;
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Left;

            // Calculates the bottom edge of the title label in the form's coordinate system.
            int labelBottom = this.PointToClient(
                 titleLabel.Parent.PointToScreen(titleLabel.Location)).Y
               + titleLabel.Height;
            // Sets the target height to the label's bottom edge plus one pixel.
            targetHeight = labelBottom + 1;

            // Sets the animation direction to 'up'.
            animationDirection = -1;
            // Sets the animating flag to true.
            isAnimating = true;
            // Starts the roll timer.
            rollTimer.Start();
        }

        private void btnGoToInExplorer_Click(object sender, EventArgs e)
        {
            // Gets the index of the currently selected row in the DataGridView.
            int currentRow = skippedDataGridView.SelectedRows[0].Index;

            // Retrieves the file path from the fourth cell of the selected row.
            string file = skippedDataGridView.Rows[currentRow].Cells[3].Value.ToString();

            // Checks if the file path is a valid file.
            if (File.Exists(file))
            {
                // If it exists, opens Windows Explorer and selects the file.
                SelectFileInExplorer(file);
            }
        }

        /// <summary>
        /// Opens Windows Explorer and selects the specified file, highlighting it in the file browser.
        /// </summary>
        /// <param name="filePath">The full path of the file to select in Windows Explorer</param>
        private static void SelectFileInExplorer(string filePath)
        {
            Process.Start(new ProcessStartInfo()
            {
                FileName = "explorer.exe",
                Arguments = @$"/select,""{filePath}"""
            });
        }

        private void btnClearSkippedList_Click(object sender, EventArgs e)
        {
            // Clears all rows from the skipped files DataGridView.
            skippedDataGridView.Rows.Clear();
            // Resets the "Total Skipped Files" label to 0.
            totalSkippedLabel.Text = "Total Skipped Files: 0";
        }

        private void clearHistoryButton_Click(object sender, EventArgs e)
        {
            // Clears all rows from the copy history DataGridView.
            copyHistoryDGV.Rows.Clear();
            // Resets the "Total History Items" label to 0.
            totalHistoryLabel.Text = "Total History Items: 0";
        }

        private void btnAddAllowed_Click(object sender, EventArgs e)
        {
            // Gets the text from the allowed extensions text box.
            string newText = allowedTextBox.Text;

            // Checks if the text box is not empty and has a valid length (5 or 6 characters).
            if (allowedTextBox.Text != string.Empty && (allowedTextBox.TextLength == 5 || allowedTextBox.TextLength == 6))
            {
                // If the list of allowed extensions contains a wildcard, it clears the list and adds the new extension.
                if (!allowedExtListBox.Items.Contains(newText) && !excludedExtListBox.Items.Contains(newText) && allowedExtListBox.Items.Contains("*.*"))
                {
                    allowedExtListBox.Items.Clear();
                    allowedExtListBox.Items.Add(newText);

                    // Resets the text box and sets the cursor position.
                    allowedTextBox.Text = "*.";
                    allowedTextBox.SelectionStart = 2;
                    allowedTextBox.Focus();
                }
                // If the extension doesn't exist in either list, adds it to the allowed list.
                else if (!allowedExtListBox.Items.Contains(newText) && !excludedExtListBox.Items.Contains(newText))
                {
                    allowedExtListBox.Items.Add(newText);

                    // Resets the text box and sets the cursor position.
                    allowedTextBox.Text = "*.";
                    allowedTextBox.SelectionStart = 2;
                }
                else
                {
                    // Shows a message box if the extension already exists.
                    MessageBox.Show("This extension already exists in the excluded extensions or in the added extensions.",
            "Copy That v1.0 File/Directory Tool - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    allowedTextBox.Focus();
                }
            }
        }

        private void btnRemoveAllowed_Click(object sender, EventArgs e)
        {
            // Checks if an item is selected in the allowed extensions list box.
            if (allowedExtListBox.SelectedIndex != -1)
            {
                // Removes the selected item.
                allowedExtListBox.Items.RemoveAt(allowedExtListBox.SelectedIndex);

                // If the list becomes empty, adds the wildcard and clears the excluded list.
                if (allowedExtListBox.Items.Count == 0)
                {
                    excludedExtListBox.Items.Clear();
                    allowedExtListBox.Items.Add("*.*");
                    allowedTextBox.Focus();
                }
            }
            else
            {
                // Shows a message box if no item is selected to remove.
                MessageBox.Show("Please select an item to remove.",
                "Copy That v1.0 File/Directory Tool - Information",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearAllowed_Click(object sender, EventArgs e)
        {
            // Checks if there are items in the allowed list box.
            if (allowedExtListBox.Items.Count > 0)
            {
                // Clears both the allowed and excluded lists.
                allowedExtListBox.Items.Clear();
                allowedExtListBox.Items.Add("*.*");
                excludedExtListBox.Items.Clear();
            }

            // Sets the focus to the allowed text box.
            allowedTextBox.Focus();
        }

        private void btnAddExcluded_Click(object sender, EventArgs e)
        {
            // Gets the text from the excluded extensions text box.
            string newText = excludedTextBox.Text;

            // Checks if the text box is not empty and has a valid length.
            if (excludedTextBox.Text != string.Empty && (excludedTextBox.TextLength == 5 || excludedTextBox.TextLength == 6))
            {
                // Checks if the extension doesn't already exist in either list.
                if (!excludedExtListBox.Items.Contains(newText) && !allowedExtListBox.Items.Contains(newText))
                {
                    // Adds the new extension to the excluded list.
                    excludedExtListBox.Items.Add(newText);

                    // Resets the text box and sets the cursor position.
                    excludedTextBox.Text = "*.";
                    excludedTextBox.SelectionStart = 2;
                    excludedTextBox.Focus();
                }
                else
                {
                    // Shows a message box if the extension already exists.
                    MessageBox.Show("This extension already exists in the excluded extensions or in the added extensions.",
            "Copy That v1.0 File/Directory Tool - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    excludedTextBox.Focus();
                }
            }
        }

        private void btnRemoveExcluded_Click(object sender, EventArgs e)
        {
            // Checks if an item is selected in the excluded extensions list box.
            if (excludedExtListBox.SelectedIndex != -1)
            {
                // Removes the selected item.
                excludedExtListBox.Items.RemoveAt(excludedExtListBox.SelectedIndex);

                // If the list becomes empty, sets the focus to the text box.
                if (excludedExtListBox.Items.Count == 0)
                {
                    excludedTextBox.Focus();
                }
            }
            else
            {
                // Shows a message box if no item is selected to remove.
                MessageBox.Show("Please select an item to remove.",
            "Copy That v1.0 File/Directory Tool - Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClearExcluded_Click(object sender, EventArgs e)
        {
            // Checks if there are items in the excluded list box.
            if (excludedExtListBox.Items.Count > 0)
            {
                // Clears all items from the excluded list box.
                excludedExtListBox.Items.Clear();
            }
            // Sets the focus to the excluded text box.
            excludedTextBox.Focus();
        }

        private void allowedTextBox_TextChanged(object sender, EventArgs e)
        {
            // If the text box contains only a wildcard, it adds a period to create a valid extension pattern.
            if (allowedTextBox.Text == "*")
            {
                allowedTextBox.Text = "*.";
                // Sets the cursor position to the end.
                allowedTextBox.SelectionStart = 2;
            }
        }

        private void excludedTextBox_TextChanged(object sender, EventArgs e)
        {
            // If the text box contains only a wildcard, it adds a period.
            if (excludedTextBox.Text == "*")
            {
                excludedTextBox.Text = "*.";
                // Sets the cursor position to the end.
                excludedTextBox.SelectionStart = 2;
            }
        }

        private void excludedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the text length is less than 2, it handles the key press to prevent invalid input.
            if (excludedTextBox.Text.Length < 2)
            {
                e.Handled = true;
                excludedTextBox.Text = "*.";
                excludedTextBox.SelectionStart = 2;
            }
            // Resets the text to "*. " if it's just a wildcard.
            if (excludedTextBox.Text == "*")
            {
                excludedTextBox.Text = "*.";
            }
        }

        private void excludedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Suppresses key presses for invalid characters if the text length is less than 3.
            if ((!(char.IsLetter((char)e.KeyValue) || e.KeyCode == Keys.Back)) && excludedTextBox.TextLength < 3)
            {
                e.SuppressKeyPress = true;
            }
            // If a letter is pressed, ensures the text starts with "*. ".
            else if (char.IsLetter((char)e.KeyValue))
            {
                if (excludedTextBox.SelectionStart <= 2)
                {
                    excludedTextBox.Text = "*.";
                    excludedTextBox.SelectionStart = 2;
                }
            }
            // Suppresses the delete key and resets the text if it's pressed.
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                excludedTextBox.Text = "*.";
                excludedTextBox.SelectionStart = 2;
            }
        }

        private void allowedTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If the text length is less than 2, handles the key press and forces the text to start with "*. ".
            if (allowedTextBox.Text.Length < 2)
            {
                e.Handled = true;
                allowedTextBox.Text = "*.";
                allowedTextBox.SelectionStart = 2;
            }
        }

        private void allowedTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            // Suppresses key presses for invalid characters if the text length is less than 3.
            if ((!(char.IsLetter((char)e.KeyValue) || e.KeyCode == Keys.Back)) && allowedTextBox.TextLength < 3)
            {
                e.SuppressKeyPress = true;
            }
            // If a letter is pressed, ensures the text starts with "*. ".
            else if (char.IsLetter((char)e.KeyValue))
            {
                if (allowedTextBox.SelectionStart <= 2)
                {
                    allowedTextBox.Text = "*.";
                    allowedTextBox.SelectionStart = 2;
                }
            }
            // Suppresses the delete key and resets the text if it's pressed.
            if (e.KeyCode == Keys.Delete)
            {
                e.SuppressKeyPress = true;
                allowedTextBox.Text = "*.";
                allowedTextBox.SelectionStart = 2;
            }
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            // If the form is minimized and the system tray option is checked, hides the form.
            if (FormWindowState.Minimized == this.WindowState && minimizeSystemTrayCheckBox.Checked == true)
            {
                notifyIcon1.Visible = true;
                this.Hide();
            }
            // If the form is normalized and the system tray option is unchecked, hides the tray icon.
            else if (FormWindowState.Normal == this.WindowState && minimizeSystemTrayCheckBox.Checked == false)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            // Shows the form.
            Show();

            // Restores the form to its normal state.
            this.WindowState = FormWindowState.Normal;

            // Hides the system tray icon and clears its tag.
            notifyIcon1.Visible = false;
            notifyIcon1.Tag = "";
        }

        private void logFileCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Updates the LogToFile setting based on the checkbox state.
            if (logFileCheckBox.Checked)
            {
                Properties.Settings.Default.LogToFile = true;
            }
            else
            {
                Properties.Settings.Default.LogToFile = false;
            }

            // Saves the settings if the auto-save checkbox is checked.
            if (saveAutoCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void tabControl1_Selected(object sender, TabControlEventArgs e)
        {
            // Checks which tab page has been selected.
            if (e.TabPage == cmdHomePage)
            {
                // Stops and disposes of the scroll timer.
                scrollTimer.Stop();
                scrollTimer.Dispose();

                // Updates the title label text based on the version (Pro or standard).
                titleLabel.Text = proVersion ? "Copy That v1.0 Pro By: Havoc - Home" : "Copy That v1.0 By: Havoc - Home";

                // Saves settings if auto-save is enabled.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }

            // Handles the case when the Multithread tab is selected.
            else if (e.TabPage == cmdMultithread)
            {
                // Stops and disposes of the scroll timer.
                scrollTimer.Stop();
                scrollTimer.Dispose();

                // Updates the title label.
                titleLabel.Text = proVersion ? "Copy That v1.0 Pro By: Havoc - Multithreading" : "Copy That v1.0 By: Havoc - MultiThreading";

                // Saves settings if auto-save is enabled.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }

            // Handles the case when the Exclusions tab is selected.
            else if (e.TabPage == cmdExclusions)
            {
                // Sets the selected tab.
                tabControl1.SelectedTab = cmdExclusions;
                // Stops and disposes of the scroll timer.
                scrollTimer.Stop();
                scrollTimer.Dispose();

                // Updates the title label.
                titleLabel.Text = proVersion ? "Copy That v1.0 Pro By: Havoc - Allow/Exclude" : "Copy That v1.0 By: Havoc - Allow/Exclude";

                // Saves settings if auto-save is enabled.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }


            // Handles the case when the Skipped Files tab is selected.
            else if (e.TabPage == cmdSkipPage)
            {
                // Sets the selected tab.
                tabControl1.SelectedTab = cmdSkipPage;
                // Stops and disposes of the scroll timer.
                scrollTimer.Stop();
                scrollTimer.Dispose();

                // Updates the title label.
                titleLabel.Text = proVersion ? "Copy That v1.0 Pro By: Havoc - Skipped Files/Dirs." : "Copy That v1.0 By: Havoc - Skipped Files/Dirs.";

                // Saves settings if auto-save is enabled.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
            // Handles the case when the About tab is selected.
            else if (e.TabPage == cmdAboutPage)
            {
                // Sets the selected tab.
                tabControl1.SelectedTab = cmdAboutPage;
                // Stops and disposes of the scroll timer.
                scrollTimer.Stop();
                scrollTimer.Dispose();

                // Defines logo dimensions and padding.
                int logoWidth = 300;
                int logoHeight = 300;
                int logoPadding = 10;

                // Sets the size and size mode for the PictureBoxes.
                copyThatPB.Width = logoWidth;
                copyThatPB.Height = logoHeight;
                copyThatPB.SizeMode = PictureBoxSizeMode.Zoom;

                havocSoftwarePB.Width = logoWidth;
                havocSoftwarePB.Height = logoHeight;
                havocSoftwarePB.SizeMode = PictureBoxSizeMode.Zoom;

                // Calculates the total width of the logos and the starting X position to center them.
                int totalLogoWidth = (logoWidth * 2) + logoPadding;
                int startX = (aboutPanel.Width - totalLogoWidth) / 2;

                // Positions the first logo.
                copyThatPB.Left = startX;
                copyThatPB.Top = aboutPanel.Height;

                // Positions the second logo with padding.
                havocSoftwarePB.Left = startX + logoWidth + logoPadding;
                havocSoftwarePB.Top = aboutPanel.Height;


                // Configures the About label properties.
                aboutLabel.AutoSize = true;
                aboutLabel.MaximumSize = new Size(aboutPanel.Width - 20, 0);
                aboutLabel.TextAlign = ContentAlignment.TopCenter;

                // Positions the About label.
                aboutLabel.Left = (aboutPanel.Width - aboutLabel.Width) / 2;
                aboutLabel.Top = copyThatPB.Top + logoHeight + 10;

                // Adds controls to the panel if they aren't already there.
                if (!aboutPanel.Controls.Contains(copyThatPB))
                    aboutPanel.Controls.Add(copyThatPB);
                if (!aboutPanel.Controls.Contains(havocSoftwarePB))
                    aboutPanel.Controls.Add(havocSoftwarePB);
                if (!aboutPanel.Controls.Contains(aboutLabel))
                    aboutPanel.Controls.Add(aboutLabel);

                // Initializes and starts a new scroll timer.
                scrollTimer = new Timer();
                scrollTimer.Interval = 25;
                scrollTimer.Tick += ScrollTimer_Tick;
                scrollTimer.Start();

                // Saves settings if auto-save is enabled.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }

            // Handles the case when the Settings tab is selected.
            else if (e.TabPage == cmdSettingsPage)
            {
                // Stops and disposes of the scroll timer.
                scrollTimer.Stop();
                scrollTimer.Dispose();

                // Calls a method to update saved checkboxes.
                editSavedCheckBoxes();

                // Updates the title label.
                titleLabel.Text = proVersion ? "Copy That v1.0 Pro By: Havoc - Settings" : "Copy That v1.0 By: Havoc - Settings";


                //ApplyThemeSettings();

                // Sets the back color of directional labels to transparent.
                nLabel.BackColor = System.Drawing.Color.Transparent;
                neLabel.BackColor = System.Drawing.Color.Transparent;
                eLabel.BackColor = System.Drawing.Color.Transparent;
                seLabel.BackColor = System.Drawing.Color.Transparent;
                sLabel.BackColor = System.Drawing.Color.Transparent;
                swLabel.BackColor = System.Drawing.Color.Transparent;
                wLabel.BackColor = System.Drawing.Color.Transparent;
                nwLabel.BackColor = System.Drawing.Color.Transparent;

                // Saves settings if auto-save is enabled.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
            // Handles the case when the Copy History tab is selected.
            else if (e.TabPage == cmdCopyHistory)
            {

                // Sets the selected tab.
                tabControl1.SelectedTab = cmdCopyHistory;
                // Stops and disposes of the scroll timer.
                scrollTimer.Stop();
                scrollTimer.Dispose();

                // Updates the title label.
                titleLabel.Text = proVersion ? "Copy That v1.0 Pro By: Havoc - History" : "Copy That v1.0 By: Havoc - History";

                // Saves settings if auto-save is enabled.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }
            }
        }



        /// <summary>
        /// Form class that monitors clipboard operations and detects when files are about to be pasted
        /// from Windows Explorer or Desktop. Displays notifications via system tray and message boxes.
        /// </summary>
        public class FilePasteMonitor : Form
        {
            // Constant for the Windows message indicating a clipboard update.
            private const int WM_CLIPBOARDUPDATE = 0x031D;
            private IntPtr _clipboardViewerNext;

            // Imports external functions from user32.dll for clipboard listener.
            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool AddClipboardFormatListener(IntPtr hwnd);

            [DllImport("user32.dll", SetLastError = true)]
            private static extern bool RemoveClipboardFormatListener(IntPtr hwnd);

            [DllImport("user32.dll")]
            private static extern IntPtr GetForegroundWindow();

            [DllImport("user32.dll", CharSet = CharSet.Auto)]
            private static extern int GetClassName(IntPtr hWnd, StringBuilder lpClassName, int nMaxCount);

            /// <summary>
            /// Initializes a new instance of the FilePasteMonitor class.
            /// Registers for clipboard updates and creates a system tray icon.
            /// </summary>
            public FilePasteMonitor()
            {
                // Registers the form to listen for clipboard updates.
                AddClipboardFormatListener(this.Handle);

                // Creates a system tray icon.
                var trayIcon = new NotifyIcon
                {
                    Icon = SystemIcons.Information,
                    Text = "File Paste Monitor",
                    Visible = true
                };

                // Sets up a context menu for the tray icon with an "Exit" option.
                trayIcon.ContextMenuStrip = new ContextMenuStrip();
                trayIcon.ContextMenuStrip.Items.Add("Exit", null, (s, e) => System.Windows.Forms.Application.Exit());
            }

            /// <summary>
            /// Processes Windows messages, specifically handling clipboard update notifications.
            /// </summary>
            /// <param name="m">The Windows message to process</param>
            protected override void WndProc(ref Message m)
            {
                // Overrides the Windows procedure to handle custom messages.
                // If the message is a clipboard update, it checks the clipboard for files.
                if (m.Msg == WM_CLIPBOARDUPDATE)
                {
                    CheckClipboardForFiles();
                }
                // Calls the base method to handle other messages.
                base.WndProc(ref m);
            }

            /// <summary>
            /// Checks the clipboard for file drop operations and displays a notification
            /// if files are being pasted from Explorer or Desktop.
            /// </summary>
            private void CheckClipboardForFiles()
            {
                try
                {
                    // Checks if the clipboard contains a file drop list and if the active window is Explorer or the Desktop.
                    if (Clipboard.ContainsFileDropList() && IsExplorerOrDesktopActive())
                    {
                        // Gets the list of files from the clipboard.
                        StringCollection files = Clipboard.GetFileDropList();
                        StringBuilder fileList = new StringBuilder();
                        fileList.AppendLine("Files about to be pasted:");

                        // Iterates through the list of files and appends them to a string builder.
                        foreach (string file in files)
                        {
                            fileList.AppendLine($"- {System.IO.Path.GetFileName(file)}");
                            fileList.AppendLine($"  (From: {System.IO.Path.GetDirectoryName(file)})");
                        }

                        // Displays a message box with the list of files.
                        MessageBox.Show(fileList.ToString(),
               "Paste Operation Detected",
               MessageBoxButtons.OK,
               MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    // Writes an error message to the debug output if an exception occurs.
                    Debug.WriteLine($"Error checking clipboard: {ex.Message}");
                }
            }

            /// <summary>
            /// Determines whether the currently active window is Windows Explorer or Desktop.
            /// </summary>
            /// <returns>True if the active window is Explorer or Desktop, otherwise false</returns>
            private bool IsExplorerOrDesktopActive()
            {
                // Gets a handle to the foreground window.
                IntPtr foregroundWindow = GetForegroundWindow();
                // Returns false if no foreground window is found.
                if (foregroundWindow == IntPtr.Zero)
                    return false;

                // Gets the class name of the foreground window.
                StringBuilder className = new StringBuilder(256);
                GetClassName(foregroundWindow, className, className.Capacity);

                // Checks if the window class name is associated with Explorer or the Desktop.
                string windowClass = className.ToString();
                return windowClass.Contains("ExplorerWClass") ||
                   windowClass.Contains("Progman") ||
                   windowClass.Contains("CabinetWClass");
            }

            /// <summary>
            /// Clean up any resources being used, specifically removing clipboard monitoring.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false</param>
            protected override void Dispose(bool disposing)
            {
                // Removes the form from the clipboard listener list.
                RemoveClipboardFormatListener(this.Handle);
                // Calls the base Dispose method.
                base.Dispose(disposing);
            }
        }


        private void autoScrollCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // If the DataGridView is empty, unchecks the auto-scroll checkbox and returns.
            if (filesDataGridView.Rows.Count == 0)
            {
                autoScrollCheckBox.Checked = false;
                return;
            }

            // If auto-scroll is being enabled, scroll to and select the first row
            if (autoScrollCheckBox.Checked)
            {
                // Start from the first row and ensure it's visible
                filesDataGridView.FirstDisplayedScrollingRowIndex = 0;
                filesDataGridView.ClearSelection();
                filesDataGridView.Rows[0].Selected = true;
                _walkCounter = 0; // Reset counter if needed
            }
        }

        /// <summary>
        /// Attaches custom sorting functionality to the BytesRaw column in the files DataGridView.
        /// Configures the column for programmatic sorting and prepares it for custom comparison logic.
        /// </summary>
        private void AttachCustomSort()
        {
            // Gets the "BytesRaw" column.
            var col = filesDataGridView.Columns["BytesRaw"];
            // If the column is not found, returns.
            if (col == null) return;

            // Sets the sort mode for the column to be handled programmatically.
            col.SortMode = DataGridViewColumnSortMode.Programmatic;
        }

        /// <summary>
        /// Custom comparer class for sorting DataGridView rows based on file size and directory status.
        /// Implements IComparer to provide custom sorting logic for file items.
        /// </summary>
        private sealed class FileRowComparer : System.Collections.IComparer
        {
            // Stores the sort direction.
            private readonly ListSortDirection _dir;

            /// <summary>
            /// Initializes a new instance of the FileRowComparer with the specified sort direction.
            /// </summary>
            /// <param name="dir">The direction to sort (ascending or descending)</param>
            public FileRowComparer(ListSortDirection dir) => _dir = dir;

            /// <summary>
            /// Compares two DataGridView rows based on directory status and file size.
            /// Directories are always sorted before files, then files are sorted by size.
            /// </summary>
            /// <param name="x">The first DataGridViewRow to compare</param>
            /// <param name="y">The second DataGridViewRow to compare</param>
            /// <returns>
            /// Less than zero if x is less than y, zero if equal, greater than zero if x is greater than y
            /// </returns>
            public int Compare(object x, object y)
            {
                // Casts the objects to DataGridViewRows.
                var row1 = (DataGridViewRow)x;
                var row2 = (DataGridViewRow)y;

                // Gets the data-bound items.
                var item1 = (FileInfoWrapper)row1.DataBoundItem;
                var item2 = (FileInfoWrapper)row2.DataBoundItem;

                // Sorts directories first.
                if (item1.IsDirectory && !item2.IsDirectory) return -1;
                if (!item1.IsDirectory && item2.IsDirectory) return 1;

                // Gets the raw byte sizes.
                long v1 = item1.BytesRaw;
                long v2 = item2.BytesRaw;

                // Compares the byte sizes.
                int cmp = v1.CompareTo(v2);
                // Returns the comparison result based on the sort direction.
                return _dir == ListSortDirection.Ascending ? cmp : -cmp;
            }
        }

        private void filesDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // If the DataGridView is empty or the wrong column is clicked, returns.
            if (filesDataGridView.Rows.Count == 0) return;
            if (e.ColumnIndex != 3) return; // Size column

            // Sorts the file list: directories first, then by size.
            var sorted = _fileList
        .OrderBy(item => item.IsDirectory ? 0 : 1)
        .ThenBy(item => sortAscendingBytes ? item.BytesRaw : -item.BytesRaw)
        .ToList();

            // Clears the original list and adds the sorted items.
            _fileList.Clear();
            foreach (var item in sorted)
            {
                _fileList.Add(item);
            }

            // Refreshes the data bindings and toggles the sort direction.
            _bindingSource.ResetBindings(false);
            sortAscendingBytes = !sortAscendingBytes;
        }

        /// <summary>
        /// Populates and standardizes the byte size information for all files in both main and export lists.
        /// Converts between formatted size strings (e.g., "1.5 MB") and raw byte values as needed.
        /// </summary>
        private void PopulateBytesRawAndFormat()
        {
            // Iterates through the main file list.
            foreach (var item in _fileList)
            {
                // Skips directories.
                if (item.IsDirectory) continue;

                // If the raw bytes are not set, it tries to parse the formatted size string.
                if (item.BytesRaw == 0 && !string.IsNullOrWhiteSpace(item.FileSize))
                {
                    if (TryParseFormattedSize(item.FileSize, out long bytes))
                        item.BytesRaw = bytes;
                    // Tries to parse as a raw long if the formatted parsing fails.
                    else if (long.TryParse(item.FileSize, out bytes))
                        item.BytesRaw = bytes;
                }
                // Updates the formatted size string from the raw byte value.
                item.FileSize = FormatBytes(item.BytesRaw);
            }
            // Refreshes the binding for the main list.
            _bindingSource.ResetBindings(false);

            // Repeats the process for the export list.
            foreach (var item in _exportList)
            {
                if (item.IsDirectory) continue;

                if (item.BytesRaw == 0 && !string.IsNullOrWhiteSpace(item.FileSize))
                {
                    if (TryParseFormattedSize(item.FileSize, out long bytes))
                        item.BytesRaw = bytes;
                    else if (long.TryParse(item.FileSize, out bytes))
                        item.BytesRaw = bytes;
                }
                item.FileSize = FormatBytes(item.BytesRaw);
            }
            // Refreshes the binding for the export list.
            _bindingSourceExport.ResetBindings(false);
        }

        private void skipButton_Click(object sender, EventArgs e)
        {
            // Check if there are still files left to process in the list.
            if (_currentFileIndex < _fileList.Count)
            {
                // Get the file wrapper object for the current file being processed.
                FileInfoWrapper currentFileWrapper = _fileList[_currentFileIndex];
                // Extract the full source path and the file name.
                string currentSourceFile = currentFileWrapper.FilePath;
                string fileName = System.IO.Path.GetFileName(currentSourceFile);

                // Check if a destination folder has been selected.
                if (this.targetPaths == null || this.targetPaths.Count == 0)
                {
                    // Show a user-friendly error message box.
                    MessageBox.Show("No destination folder selected. Cannot skip and log file with intended destination.", "Skip Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    // Update the status of the file in the list to "Skipped (No Target)".
                    UpdateFileStatus(_fileList[_currentFileIndex], "Skipped (No Target)"); ;
                    // Increment the counters for files processed and skipped.
                    System.Threading.Interlocked.Increment(ref _processedFiles);
                    System.Threading.Interlocked.Increment(ref _totalFilesSkipped);
                    // Move to the next file in the list.
                    _currentFileIndex++;
                    return;
                }
                // Get the first target directory from the list of target paths.
                string targetRoot = this.targetPaths.First();
                // Determine the intended destination path for the current file.
                string intendedDestinationFile = GetTargetDirectory(currentSourceFile, targetRoot, currentFileWrapper.IsDirectory, _currentSourceRootPath);

                // If the file is not a directory and a file with the same name exists at the destination, attempt to securely delete it.
                if (!currentFileWrapper.IsDirectory && File.Exists(intendedDestinationFile))
                {
                    try
                    {
                        // Call a method to securely delete the file.
                        DoDSecureDelete(intendedDestinationFile);
                    }
                    catch (Exception delEx)
                    {
                        // Log a warning if the secure deletion fails.
                        LogWarning($"Could not securely delete partial file {intendedDestinationFile}: {delEx.Message}");
                    }
                }

                // If the intended destination file path is null or empty, log a "No Destination" skip reason.
                if (string.IsNullOrEmpty(intendedDestinationFile))
                {
                    AddToSkippedFiles(
                      "Skipped: No Destination",                                // reason
                                  currentFileWrapper.FileName,                              // fileName
                                  currentFileWrapper.BytesRaw,                              // rawFileSize
                                  currentFileWrapper.FilePath,                              // sourcePath
                                  "N/A (empty target)",                                     // targetPath
                                  "Destination path not determined"                         // errorMessage
                              );
                }
                // Otherwise, log a "Skipped By User" reason with the determined destination path.
                else
                {
                    AddToSkippedFiles(
                      "Skipped By User",                                        // reason
                                  currentFileWrapper.FileName,                              // fileName
                                  currentFileWrapper.BytesRaw,                              // rawFileSize
                                  currentFileWrapper.FilePath,                              // sourcePath
                                  intendedDestinationFile,                                  // targetPath
                                  ""                                                        // errorMessage
                              );
                }

                // Update the file status to "Skipped" in the UI.
                UpdateFileStatus(_fileList[_currentFileIndex], "Skipped");
                // Increment the total files processed and skipped counters.
                System.Threading.Interlocked.Increment(ref _processedFiles);
                System.Threading.Interlocked.Increment(ref _totalFilesSkipped);

                // Move to the next file.
                _currentFileIndex++;
            }
        }

        /// <summary>
        /// Overloaded method to simplify logging and skipping when an exception occurs.
        /// Logs the exception details and adds the file to the skipped files list.
        /// </summary>
        /// <param name="item">The file item wrapper containing file information</param>
        /// <param name="ex">The exception that caused the file to be skipped</param>
        private void LogAndSkip(FileInfoWrapper item, Exception ex)
            // Overloaded method to simplify logging and skipping when an exception occurs.
            => LogAndSkip(item, $"{ex.GetType().Name}: {ex.Message}", ex);

        /// <summary>
        /// Logs a file skip operation, updates counters, and refreshes UI elements.
        /// Handles both exception-based and reason-based skipping.
        /// </summary>
        /// <param name="item">The file item wrapper containing file information</param>
        /// <param name="reason">The reason why the file was skipped</param>
        /// <param name="ex">Optional exception that caused the skip</param>
        private void LogAndSkip(FileInfoWrapper item, string reason, Exception ex = null)
        {
            // Determine the destination path for the item.
            string dst = GetDestinationPath(item, _currentTargetPaths.FirstOrDefault() ?? "");

            // Add the file to the skipped files list with the given reason.
            AddToSkippedFiles(reason,
                item.FileName,
                item.BytesRaw,
                item.FilePath,
                dst,
                ex?.Message ?? reason);
            // Increment the total number of skipped and failed files.
            _totalFilesSkipped++;
            // Update the UI label showing the total number of skipped files.
            totalSkippedLabel.Text = "Total Skipped Files: " + _totalFilesSkipped.ToString("N0") + "";
            // Update the file's status in the list to "Failed".
            UpdateFileStatus(item, "Failed");
            _totalFilesFailed++;
        }

        /// <summary>
        /// Updates overall progress labels on the UI thread with current operation statistics.
        /// Displays processed file count and bytes processed vs total bytes.
        /// </summary>
        private void UpdateOverallLabels()
        {
            // Check if an Invoke is required to update the UI from a different thread.
            if (InvokeRequired) { Invoke(new Action(UpdateOverallLabels)); return; }

            // Update the file count label with the number of processed files out of the grand total.
            fileCountOnLabel.Text = $"File Count: {_processedFiles:N0} Out of " + _grandTotalFileCount.ToString("N0") + "";
            // Update the label showing total bytes copied, moved, or deleted.
            totalCopiedProgressLabel.Text = $"Total C/M/D: {FormatBytes(_totalBytesProcessed)} / {FormatBytes(_totalBytesToProcess)}";
        }

        /// <summary>
        /// Reports file copy progress to the UI with percentage completion and byte counts.
        /// Ensures thread-safe UI updates through Invoke if necessary.
        /// </summary>
        /// <param name="pct10k">Progress percentage in hundredths (e.g., 5000 = 50.00%)</param>
        /// <param name="fileName">The name of the file being processed</param>
        /// <param name="bytesDone">The number of bytes processed so far</param>
        /// <param name="bytesTotal">The total number of bytes to process</param>
        private void ReportFileProgress(int pct10k, string fileName,
                    long bytesDone, long bytesTotal)
        {
            // Check if an Invoke is required to update the UI.
            if (InvokeRequired)
            {
                Invoke(new Action(() => ReportFileProgress(pct10k, fileName,
                                     bytesDone, bytesTotal)));
                return;
            }

            fileProgressBar.Value = Math.Min((int)(pct10k * 100), fileProgressBar.Maximum);
            fileProgressBar.Refresh();

            // Update the label with the percentage of the current file processed.
            fileProgressBar.Text = $"{pct10k / 100.0:F2}%";
            fileProgressBar.Refresh();

            // Update the label with the bytes processed for the current file.
            fileProcessedLabel.Text =
            $"File Processed: {FormatBytes(bytesDone)} / {FormatBytes(bytesTotal)}";
            fileProcessedLabel.Refresh();
        }

        private void _copyWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Check if the progress information is of type ProgressInfo.
            if (e.UserState is ProgressInfo pi)
            {
                // Ensure the total progress value doesn't exceed the maximum.
                pi.TotalProgress = Math.Min(pi.TotalProgress, totalProgressBar.Maximum);

                // Update the UI based on the progress information.
                UpdateUI(pi);
                // Update the file count labels.
                UpdateFileCountLabels();
            }
            else
            {
                // If not a ProgressInfo object, use the progress percentage.
                int pct = Math.Min(e.ProgressPercentage, totalProgressBar.Maximum);

                totalProgressBar.Value = pct;
                totalProgressBar.Refresh();

                totalProgressBar.Text = $"{(pct / 100.0):F2}%";
                totalProgressBar.Refresh();
            }
        }

        public class ProgressInfo
        {
            // A class to hold various progress information.
            // Overall progress for the main progress bar (0-10000 scale).
            public int TotalProgress { get; set; }
            // Total number of files planned to be processed.
            public long TotalFiles { get; set; }
            // Number of files that have been processed so far.
            public int ProcessedFiles { get; set; }
            // Total bytes expected to be processed for all files.
            public long TotalBytes { get; set; }
            // Total bytes that have been processed across all files.
            public long ProcessedBytes { get; set; }
            // Alternative property names for total and processed bytes.
            public long TotalBytesToProcess { get; set; }
            public long BytesProcessed { get; set; }
            // Properties for current file progress.
            public string CurrentFileName { get; set; }
            public long CurrentFileBytesProcessed { get; set; }
            public long CurrentFileTotalBytes { get; set; }
        }

        /// <summary>
        /// Logs an error message with optional source path, target path, and exception details to a log file.
        /// </summary>
        /// <param name="message">The main error message to log</param>
        /// <param name="sourcePath">Optional source file path related to the error</param>
        /// <param name="targetPath">Optional target file path related to the error</param>
        /// <param name="exceptionMessage">Optional exception message or details</param>
        private void LogError(string message, string sourcePath = "", string targetPath = "", string exceptionMessage = "")
        {
            // Create a timestamped log entry string with the provided message.
            string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}";
            // Append source and target paths to the log entry if they are provided.
            if (!string.IsNullOrEmpty(sourcePath))
            {
                logEntry += $"\n  Source: {sourcePath}";
            }
            if (!string.IsNullOrEmpty(targetPath))
            {
                logEntry += $"\n  Target: {targetPath}";
            }
            // Append exception details if they are provided.
            if (!string.IsNullOrEmpty(exceptionMessage))
            {
                logEntry += $"\n  Details: {exceptionMessage}";
            }

            // Define the path for the log file.
            string logFilePath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "application_errors.log");

            try
            {
                // Append the log entry to the log file.
                File.AppendAllText(logFilePath, logEntry + Environment.NewLine + Environment.NewLine);
            }
            catch (Exception ex)
            {
                // If logging fails, write a debug message to the output.
                Debug.WriteLine($"Failed to write to log file '{logFilePath}': {ex.Message}");
                Debug.WriteLine($"Original Log Entry: {logEntry}");
            }
        }

        /// <summary>
        /// Resets the status of all files in the file list to "Pending..." and updates the UI.
        /// </summary>
        private void ResetAllFileStatuses()
        {
            foreach (var f in _fileList)
                f.Status = "Pending...";

            // Make sure the grid redraws with the new values
            Invoke(() =>
            {
                filesDataGridView.Refresh();
            });

            Invoke(() =>
            {
                if (filesDataGridView.Rows.Count > 0)
                    filesDataGridView.ClearSelection();
            });
        }

        /// <summary>
        /// Updates the status of a specific file in the file list.
        /// </summary>
        /// <param name="fileInfo">The file information wrapper containing the file path</param>
        /// <param name="status">The new status to set for the file</param>
        private void UpdateFileStatus(FileInfoWrapper fileInfo, string status)
        {
            // Find the file in the file list by its file path.
            var itemToUpdate = _fileList.FirstOrDefault(f => f.FilePath == fileInfo.FilePath);
            // If the file is found, update its status.
            if (itemToUpdate != null)
            {
                itemToUpdate.Status = status;
            }
        }

        /// <summary>
        /// Adds a file to the skipped files list with detailed information about why it was skipped.
        /// </summary>
        /// <param name="reason">The reason why the file was skipped</param>
        /// <param name="fileName">The name of the skipped file</param>
        /// <param name="rawFileSize">The size of the file in bytes</param>
        /// <param name="sourceFilePath">The full source file path</param>
        /// <param name="destinationFilePath">The intended destination file path</param>
        /// <param name="errorMessage">Optional error message details</param>
        private void AddToSkippedFiles(string reason, string fileName, long rawFileSize, string sourceFilePath, string destinationFilePath, string errorMessage = "")
        {
            // Format the raw file size into a human-readable string.
            string formattedFileSize = FormatBytes(rawFileSize);

            // Check if an Invoke is required to update the UI from a different thread.
            if (filesDataGridView.InvokeRequired)
            {
                filesDataGridView.Invoke(new Action(() =>
                {
                    // Add a new SkippedFileInfo object to the list.
                    _skippedFilesList.Add(new SkippedFileInfo
                    {
                        Reason = reason,
                        FileName = fileName,
                        FileSize = formattedFileSize,
                        SourceFilePath = sourceFilePath,
                        DestinationFilePath = destinationFilePath,
                        ErrorMessage = errorMessage
                    });
                }));
            }
            else
            {
                // If no Invoke is needed, add the new SkippedFileInfo object directly.
                _skippedFilesList.Add(new SkippedFileInfo
                {
                    Reason = reason,
                    FileName = fileName,
                    FileSize = formattedFileSize,
                    SourceFilePath = sourceFilePath,
                    DestinationFilePath = destinationFilePath,
                    ErrorMessage = errorMessage
                });
            }
        }

        /// <summary>
        /// Placeholder method for file integrity verification. Currently always returns true.
        /// </summary>
        /// <param name="sourceFile">The source file path</param>
        /// <param name="destinationFile">The destination file path</param>
        /// <returns>Always returns true (verification not implemented)</returns>
        private bool VerifyFileIntegrity(string sourceFile, string destinationFile)
        {
            // Log a debug message indicating the start of file integrity verification.
            Debug.WriteLine($"Verifying integrity: {sourceFile} vs {destinationFile}");
            // This is a placeholder; the method currently always returns true.
            return true;
        }

        /// <summary>
        /// Updates drive space information for all target paths and displays it in the UI.
        /// </summary>
        private void UpdateDriveSpaceInfo()
        {
            try
            {
                // Check if there are target paths to update drive space information for.
                if (this.targetPaths != null && this.targetPaths.Any())
                {
                    // Get a distinct list of drive roots from the target paths.
                    var driveRoots = this.targetPaths
                        .Select(tp => System.IO.Path.GetPathRoot(tp))
                        .Where(r => !string.IsNullOrEmpty(r))
                        .Distinct(StringComparer.OrdinalIgnoreCase)
                        .ToList();

                    // If no drive roots are found, set the label to indicate an invalid path.
                    if (driveRoots.Count == 0)
                    {
                        SetDriveInfoLabel("Invalid Target Path");
                        return;
                    }

                    long totalSpaceAll = 0;
                    long usedSpaceAll = 0;
                    var driveNames = new List<string>();

                    // Iterate through each unique drive root.
                    foreach (var root in driveRoots)
                    {
                        try
                        {
                            // Create a DriveInfo object for the current drive.
                            DriveInfo drive = new DriveInfo(root);

                            // Skip drives that are not ready (e.g., disconnected network drives).
                            if (!drive.IsReady)
                            {
                                continue;
                            }

                            // Get the total and available free space.
                            long totalSpace = drive.TotalSize;
                            long availableFreeSpace = drive.AvailableFreeSpace;
                            // Calculate used space and add it to the totals.
                            long usedSpace = totalSpace - availableFreeSpace;

                            totalSpaceAll += totalSpace;
                            usedSpaceAll += usedSpace;

                            // Add the drive name to the list.
                            string driveName = drive.Name.TrimEnd(System.IO.Path.DirectorySeparatorChar);
                            driveNames.Add($"{driveName} ({drive.DriveType})");
                        }
                        catch (Exception ex)
                        {
                            // Log an error if reading drive information fails.
                            LogError($"Error reading drive '{root}': {ex.Message}");
                        }
                    }

                    // If at least one drive name was found, update the UI labels.
                    if (driveNames.Count > 0)
                    {
                        string drivesCombined = string.Join(", ", driveNames);
                        string text =
                            $"Total Space ({drivesCombined}): {FormatBytes(usedSpaceAll)} / {FormatBytes(totalSpaceAll)}";

                        // Check and use InvokeRequired to update the labels safely.
                        if (totalHDSpaceLeftLabel != null)
                        {
                            if (totalHDSpaceLeftLabel.InvokeRequired)
                            {
                                totalHDSpaceLeftLabel.Invoke(new Action(() =>
                                {
                                    totalHDSpaceLeftLabel.Text = text;
                                    totalSpaceMultiLabel.Text = text;
                                }));
                            }
                            else
                            {
                                totalHDSpaceLeftLabel.Text = text;
                                totalSpaceMultiLabel.Text = text;
                            }
                        }
                    }
                    // If no drive names were found, indicate that no drives are ready.
                    else
                    {
                        SetDriveInfoLabel("No drives ready");
                    }
                }
                // If no target paths are set, prompt the user to select one.
                else
                {
                    SetDriveInfoLabel("Select a Destination to see Drive Space");
                }
            }
            catch (Exception ex)
            {
                // Log any exceptions that occur during the process.
                LogError($"Error updating drive space information: {ex.Message}");
                // Set the UI label to indicate an error.
                SetDriveInfoLabel("Error Getting Drive Space");
            }
        }

        /// <summary>
        /// Safely updates the drive information label text from any thread.
        /// </summary>
        /// <param name="text">The text to display in the drive information label</param>
        private void SetDriveInfoLabel(string text)
        {
            // Check if the totalHDSpaceLeftLabel object exists.
            if (totalHDSpaceLeftLabel != null)
            {
                // Use InvokeRequired to safely update the label's text from a different thread.
                if (totalHDSpaceLeftLabel.InvokeRequired)
                {
                    totalHDSpaceLeftLabel.Invoke(new Action(() =>
                    {
                        totalHDSpaceLeftLabel.Text = text;
                        totalSpaceMultiLabel.Text = text;
                    }));
                }
                else
                {
                    // If not required, set the text directly.
                    totalHDSpaceLeftLabel.Text = text;
                    totalSpaceMultiLabel.Text = text;
                }
            }
        }

        /// <summary>
        /// Creates the target directory structure by replicating the source directory hierarchy.
        /// </summary>
        /// <param name="sourceDirs">List of source directory paths to replicate</param>
        /// <param name="targetDirs">List of target directory paths where structure should be created</param>
        private void CreateTargetDirectoryStructure(List<string> sourceDirs, List<string> targetDirs)
        {
            // Check if source or target directories are null or empty.
            if (sourceDirs == null || !sourceDirs.Any() || targetDirs == null || !targetDirs.Any())
            {
                // Log an error if the directory paths are not specified.
                LogError("Cannot create target directory structure: Source or target directories are not specified.");
                return;
            }

            // Get the base target directory.
            string targetBaseDir = targetDirs[0];

            // Loop through each source base path.
            foreach (string sourceBasePath in sourceDirs)
            {
                // Check if the source path exists.
                if (!Directory.Exists(sourceBasePath) && !File.Exists(sourceBasePath))
                {
                    // Log an error if the source path does not exist.
                    LogError($"Source path does not exist: '{sourceBasePath}'");
                    continue;
                }

                // Get the parent directory of the source path.
                string sourceBasePathParent = System.IO.Path.GetDirectoryName(sourceBasePath.TrimEnd(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar));

                // If the parent path is empty, get the drive root.
                if (string.IsNullOrEmpty(sourceBasePathParent))
                {
                    sourceBasePathParent = System.IO.Path.GetPathRoot(sourceBasePath);
                }

                // Use a Stack to manage directories to process.
                Stack<string> directoriesToProcess = new Stack<string>();

                // Push the source base path onto the stack if it's a directory.
                if (Directory.Exists(sourceBasePath))
                {
                    directoriesToProcess.Push(sourceBasePath);
                }
                // If it's a file, get its parent directory.
                else if (File.Exists(sourceBasePath))
                {
                    string parentOfFile = System.IO.Path.GetDirectoryName(sourceBasePath);
                    if (!string.IsNullOrEmpty(parentOfFile))
                    {
                        // Note: This section appears to have incomplete logic
                    }
                }

                // Process directories from the stack until it is empty.
                while (directoriesToProcess.Count > 0)
                {
                    // Pop the next directory to process.
                    string currentSourceDir = directoriesToProcess.Pop();

                    // Determine the relative path and combine it with the target base directory.
                    string relativePath = currentSourceDir.Substring(sourceBasePathParent.Length).TrimStart(System.IO.Path.DirectorySeparatorChar, System.IO.Path.AltDirectorySeparatorChar);
                    string currentTargetDir = System.IO.Path.Combine(targetBaseDir, relativePath);

                    // If the target directory does not exist, create it.
                    if (!Directory.Exists(currentTargetDir))
                    {
                        try
                        {
                            Directory.CreateDirectory(currentTargetDir);
                        }
                        catch (Exception ex)
                        {
                            // Log an error if directory creation fails.
                            LogError($"Failed to create directory '{currentTargetDir}': {ex.Message}");
                        }
                    }

                    try
                    {
                        // Get all subdirectories and push them onto the stack for processing.
                        foreach (string subDir in Directory.GetDirectories(currentSourceDir))
                        {
                            directoriesToProcess.Push(subDir);
                        }
                    }
                    // Catch and log access denied exceptions.
                    catch (UnauthorizedAccessException ex)
                    {
                        LogError($"Access denied to directory '{currentSourceDir}': {ex.Message}");
                    }
                    // Catch and log any other exceptions.
                    catch (Exception ex)
                    {
                        LogError($"Error enumerating subdirectories in '{currentSourceDir}': {ex.Message}");
                    }
                }
            }
        }

        private void MoveWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Check if the totalCopiedProgressLabel object is valid and not disposed.
            if (totalCopiedProgressLabel != null && !totalCopiedProgressLabel.IsDisposed)
            {
                // Update the label text with the total bytes processed.
                totalCopiedProgressLabel.Text = $"Total C/M/D: {FormatBytes(_totalBytesProcessed)} / {FormatBytes(_totalBytesToProcess)}";
            }
        }

        private void DeleteWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // Check if the totalCopiedProgressLabel object is valid and not disposed.
            if (totalCopiedProgressLabel != null && !totalCopiedProgressLabel.IsDisposed)
            {
                // Update the label text with the total bytes processed.
                totalCopiedProgressLabel.Text = $"Total C/M/D: {FormatBytes(_totalBytesProcessed)} / {FormatBytes(_totalBytesToProcess)}";
            }
        }
        private void Worker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Reset the UI and variables related to progress.
            ResetProgressUIAndVariables();
            // Stop the UI update timer.
            _updateTimer.Stop();

            // Check if an error occurred during the worker's execution.
            if (e.Error != null)
            {
                // Show a message box with the error.
                MessageBox.Show($"Copy operation completed with errors: {e.Error.Message}", "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Log the error.
                LogError($"Copy Worker Error: {e.Error}");
            }
            // Check if the operation was cancelled.
            else if (e.Cancelled)
            {
                // Show a message box confirming cancellation.
                MessageBox.Show("Copy operation cancelled by user.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // If no errors or cancellations, show a summary of the completed operation.
            else
            {
                // Create a summary message string with the results.
                string summaryMessage = $"Copy Operation Completed!\n\n" +
                    $"Files Copied: {_totalFilesCopied}\n" +
                    $"Files Skipped: {_totalFilesSkipped}\n" +
                    $"Files Failed: {_totalFilesFailed}\n" +
                    $"Total Files Processed: {_processedFiles} / {_grandTotalFileCount:N0}\n" +
                    $"Total Bytes Processed: {FormatBytes(_totalBytesProcessed)} / {FormatBytes(_totalBytesToProcess)}";

                // Show the summary message box.
                MessageBox.Show(summaryMessage, "Copy Operation Summary", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // If the verify checkbox is checked and the operation was "Copy Files", start file verification.
                if (verifyCheckBox != null && verifyCheckBox.Checked && copyMoveDeleteComboBox != null && copyMoveDeleteComboBox.SelectedItem != null && copyMoveDeleteComboBox.SelectedItem.ToString() == "Copy Files")
                {
                    VerifyFiles();
                }

            }
            // Always update the drive space information after the operation completes.
            UpdateDriveSpaceInfo();
        }

        /// <summary>
        /// Updates the file count label on the UI thread, displaying the current count out of total files.
        /// </summary>
        private void UpdateFileCountLabel()
        {
            // Check if Invoke is required and call the method recursively on the UI thread.
            if (InvokeRequired)
                Invoke((Action)UpdateFileCountLabel);
            // Otherwise, update the label directly.
            else
                fileCountOnLabel.Text = $"File Count: 0 Out of " + _grandTotalFileCount.ToString("N0") + "";
        }

        /// <summary>
        /// Calculates the target directory path for a source file or directory based on relative path calculation.
        /// </summary>
        /// <param name="sourcePath">The full path of the source file or directory</param>
        /// <param name="targetRootPath">The root target directory path</param>
        /// <param name="isDirectory">True if the source is a directory, false if it's a file</param>
        /// <param name="sourceRootPathForRelativeCalculation">Optional source root path for relative path calculation</param>
        /// <returns>The calculated target directory path</returns>
        public string GetTargetDirectory(string sourcePath,
                     string targetRootPath,
                     bool isDirectory,
                     string sourceRootPathForRelativeCalculation)
        {
            // Determine the source root path for calculating the relative path.
            string srcRoot = string.IsNullOrWhiteSpace(sourceRootPathForRelativeCalculation)
              ? (isDirectory ? sourcePath : System.IO.Path.GetDirectoryName(sourcePath))
              : sourceRootPathForRelativeCalculation;

            // Normalize the source root path.
            srcRoot = System.IO.Path.GetFullPath(srcRoot).TrimEnd(System.IO.Path.DirectorySeparatorChar,
                              System.IO.Path.AltDirectorySeparatorChar);

            // Get the full path of the source.
            string fullPath = System.IO.Path.GetFullPath(sourcePath);

            // Get the relative path from the source root to the full path.
            string relative = System.IO.Path.GetRelativePath(srcRoot, isDirectory ? fullPath
                                  : System.IO.Path.GetDirectoryName(fullPath));

            // Combine the target root path with the relative path to get the final destination.
            string targetDir = System.IO.Path.Combine(targetRootPath, relative);

            // Ensure the target path ends with a directory separator if it's a directory.
            if (isDirectory && !targetDir.EndsWith(System.IO.Path.DirectorySeparatorChar.ToString()))
                targetDir += System.IO.Path.DirectorySeparatorChar;

            return targetDir;
        }

        /// <summary>
        /// Attempts to open a file with retry logic for handling temporary IO errors and access issues.
        /// </summary>
        /// <param name="path">The file path to open</param>
        /// <param name="mode">The file mode for opening</param>
        /// <param name="access">The file access permissions</param>
        /// <param name="share">The file sharing mode</param>
        /// <returns>A FileStream if successful, null if all retries fail or access is denied</returns>
        private FileStream RetryOpen(string path, FileMode mode, FileAccess access, FileShare share)
        {
            // Constants for the retry logic.
            const int MAX_RETRIES = 5;
            const int RETRY_DELAY_MS = 100;

            // Loop a maximum number of times to attempt to open the file.
            for (int i = 0; i <= MAX_RETRIES; i++)
            {
                try
                {
                    // Attempt to create and return a new FileStream.
                    return new FileStream(path, mode, access, share);
                }
                // Catch IOException and retry after a delay.
                catch (IOException) when (i < MAX_RETRIES)
                {
                    Thread.Sleep(RETRY_DELAY_MS * (i + 1));
                }
                // Catch UnauthorizedAccessException and handle the error.
                catch (UnauthorizedAccessException ex)
                {
                    // Call a method to handle the file error.
                    HandleErrorFile(
            new FileInfoWrapper { FileName = System.IO.Path.GetFileName(path), FilePath = System.IO.Path.GetFullPath(path) },
            $"Access denied: {ex.Message}",
            path);
                    // Increment the total failed files counter and return null.
                    Interlocked.Increment(ref _totalFilesFailed);
                    return null;
                }
            }
            // Return null if all retries fail.
            return null;
        }



        private async Task<FileStream> RetryOpenAsync(
        string path,
        FileMode mode,
        FileAccess access,
        FileShare share,
        int bufferSize,
        FileOptions options)
        {
            // Constants for the retry logic.
            const int MAX_RETRIES = 5;
            const int RETRY_DELAY_MS = 100;

            // Loop a maximum number of times to attempt to open the file.
            for (int i = 0; i <= MAX_RETRIES; i++)
            {
                try
                {
                    // Attempt to create and return a new FileStream with all parameters.
                    return new FileStream(path, mode, access, share, bufferSize, options);
                }
                // Catch IOException and retry after an ASYNCHRONOUS delay.
                catch (IOException) when (i < MAX_RETRIES)
                {
                    // ✅ Use await Task.Delay() instead of Thread.Sleep()
                    await Task.Delay(RETRY_DELAY_MS * (i + 1));
                }
                // Catch UnauthorizedAccessException and handle the error.
                catch (UnauthorizedAccessException ex)
                {
                    // Call a method to handle the file error.
                    HandleErrorFile(
                        new FileInfoWrapper { FileName = System.IO.Path.GetFileName(path), FilePath = System.IO.Path.GetFullPath(path) },
                        $"Access denied: {ex.Message}",
                        path);
                    // Increment the total failed files counter and return null.
                    Interlocked.Increment(ref _totalFilesFailed);
                    return null;
                }
            }
            // Return null if all retries fail.
            return null;
        }

        /// <summary>
        /// Determines whether a file should be overwritten based on user preferences and file timestamps.
        /// </summary>
        /// <param name="source">The source file path</param>
        /// <param name="destination">The destination file path</param>
        /// <returns>True if the file should be overwritten, false otherwise</returns>
        private bool HandleOverwriteLogic(string source, string destination)
        {
            // If the destination file does not exist, there's no need to overwrite, so return true.
            if (!File.Exists(destination)) return true;

            // If "overwrite all" is checked, return true to overwrite.
            if (overwriteAllCheckBox.Checked)
                return true;

            // If "do not overwrite" is checked, return false to skip.
            if (doNotOverwriteCheckBox.Checked)
                return false;

            // If "overwrite if newer" is checked, compare last write times.
            if (overwriteIfNewerCheckBox.Checked)
            {
                // Get file info for both source and destination.
                var srcInfo = new FileInfo(source);
                var destInfo = new FileInfo(destination);
                // Return true if the source file is newer than the destination file.
                return srcInfo.LastWriteTime > destInfo.LastWriteTime;
            }

            // Default to not overwriting if no option is selected.
            return false;
        }

        /// <summary>
        /// Prompts the user to create a custom directory name and validates the input.
        /// </summary>
        /// <returns>The full path of the created custom directory, or null if cancelled</returns>
        private string GetCustomDirectoryFromUser()
        {
            string inputDir = null;

            // Check if we have any target paths available
            if (this.targetPaths == null || this.targetPaths.Count == 0)
            {
                MessageBox.Show("No target paths available for custom directory creation.",
                               "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }

            // Use the first target path as the base for custom directory
            string baseTargetPath = this.targetPaths[0];

            // Loop until a valid directory is chosen or the user cancels.
            while (true)
            {
                // Show a custom dialog box to prompt for a directory name.
                inputDir = Prompt.ShowDialog("Enter custom directory name:", "Custom Directory");

                // If the input is null or whitespace, return null to indicate cancellation.
                if (string.IsNullOrWhiteSpace(inputDir))
                    return null;

                // Validate the directory name for invalid characters
                if (inputDir.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) >= 0)
                {
                    MessageBox.Show("Directory name contains invalid characters. Please try again.",
                                   "Invalid Directory Name", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    continue;
                }

                // Combine the input with the target path to get the full path.
                string fullPath = System.IO.Path.Combine(baseTargetPath, inputDir);

                // Show a confirmation message box to the user.
                var result = MessageBox.Show($"Copy files into:\n\n{fullPath}?\n\nYes = Use This\nNo = Edit Again\nCancel = Abort",
                    "Confirm Directory",
                    MessageBoxButtons.YesNoCancel,
                    MessageBoxIcon.Question);

                // If the user confirms, create the directory and return the path.
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(fullPath);
                        return fullPath;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to create directory:\n{ex.Message}\n\nPlease try a different name.",
                                       "Directory Creation Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        // Continue the loop to let user try again
                    }
                }
                // If the user cancels, return null.
                else if (result == DialogResult.Cancel)
                {
                    return null;
                }
                // If user clicked No, continue the loop to edit again
            }
        }

        /// <summary>
        /// Static class providing a simple input dialog prompt for user input.
        /// </summary>
        public static class Prompt
        {
            // A static class to display a simple input dialog.
            /// <summary>
            /// Displays a modal dialog box with a prompt and text input field.
            /// </summary>
            /// <param name="text">The prompt text to display</param>
            /// <param name="caption">The dialog caption/title</param>
            /// <returns>The user's input text, or null if cancelled</returns>
            public static string ShowDialog(string text, string caption)
            {
                // Create a new Form for the dialog box.
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 160,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterParent
                };

                // Create a label for the prompt text and a text box for user input.
                Label textLabel = new Label() { Left = 20, Top = 20, Text = text, Width = 340 };
                TextBox inputBox = new TextBox() { Left = 20, Top = 50, Width = 340 };

                // Create an "OK" button for confirmation.
                System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "OK", Left = 280, Width = 80, Top = 80, DialogResult = DialogResult.OK };

                // Add the controls to the form.
                prompt.Controls.Add(textLabel);
                prompt.Controls.Add(inputBox);
                prompt.Controls.Add(confirmation);
                // Set the OK button as the default accept button for the form.
                prompt.AcceptButton = confirmation;

                // Show the dialog and return the text from the input box if the result is OK.
                return prompt.ShowDialog() == DialogResult.OK ? inputBox.Text : null;
            }
        }

        /// <summary>
        /// Determines if a file should be excluded from processing based on operation type and file path.
        /// Currently a placeholder method that always returns false (no exclusions).
        /// </summary>
        /// <param name="filePath">The path of the file to check</param>
        /// <param name="operation">The type of file operation being performed</param>
        /// <returns>True if the file should be excluded, false otherwise</returns>
        private bool IsFileExcluded(string filePath, FileOperation operation)
        {
            // Placeholder for file exclusion logic.
            // The comments within the method show examples of how to implement exclusion rules.
            // Currently, it always returns false, meaning no files are excluded by default.
            return false;
        }

        /// <summary>
        /// Enumeration defining the types of file operations supported by the application.
        /// </summary>
        private enum FileOperation
        {
            // An enumeration to define the types of file operations.
            Copy,
            Move,
            SecureDelete
        }

        /// <summary>
        /// Determines whether a file should be skipped during processing based on overwrite rules and file timestamps.
        /// </summary>
        /// <param name="sourceFilePath">The source file path</param>
        /// <param name="destinationFilePath">The destination file path</param>
        /// <returns>True if the file should be skipped, false otherwise</returns>
        private bool ShouldSkipFile(string sourceFilePath, string destinationFilePath)
        {
            // Determine if a file should be skipped based on overwrite rules.
            // If the destination file does not exist, it should not be skipped.
            if (!File.Exists(destinationFilePath))
            {
                return false;
            }

            // If the "overwrite all" option is enabled, don't skip.
            if (_overwriteAll)
            {
                return false;
            }
            // If the "do not overwrite" option is enabled, always skip.
            else if (_doNotOverwrite)
            {
                return true;
            }
            // If the "overwrite if newer" option is enabled, compare timestamps.
            else if (_overwriteIfNewer)
            {
                try
                {
                    // Get the last write times for both source and destination files.
                    DateTime sourceLastWriteTime = File.GetLastWriteTimeUtc(sourceFilePath);
                    DateTime destLastWriteTime = File.GetLastWriteTimeUtc(destinationFilePath);

                    // Skip the file if the source is older or the same age as the destination.
                    return sourceLastWriteTime <= destLastWriteTime;
                }
                catch (Exception ex)
                {
                    // Log an error if there's an issue checking timestamps.
                    LogError($"Error checking file timestamps for skipping: {ex.Message}", sourceFilePath, destinationFilePath, ex.Message);
                    // Default to skipping the file on error to prevent data loss.
                    return true;
                }
            }
            // Default to skipping if no specific rule is matched.
            return true;
        }

        /// <summary>
        /// Marks a file as currently being copied by adding it to the copying indices list and updating UI selection.
        /// </summary>
        /// <param name="index">The index of the file in the file list</param>
        private void MarkFileAsCopying(int index)
        {
            // Use Invoke to ensure UI updates are on the correct thread.
            Invoke(() =>
            {
                // Add the file index to the list of currently copying files.
                _currentlyCopyingIndices.Add(index);
                // Update the DataGridView selection to highlight the file.
                UpdateDataGridViewSelection();
            });
        }

        /// <summary>
        /// Marks a file as completed copying by removing it from the copying indices list and updating UI selection.
        /// </summary>
        /// <param name="index">The index of the file in the file list</param>
        private void MarkFileAsCopied(int index)
        {
            // Use Invoke to ensure UI updates are on the correct thread.
            Invoke(() =>
            {
                // Remove the file index from the list of currently copying files.
                _currentlyCopyingIndices.Remove(index);
                // Unselect the row in the DataGridView.
                if (index >= 0 && index < dataGridView2.Rows.Count)
                    dataGridView2.Rows[index].Selected = false;
                // Update the DataGridView selection.
                UpdateDataGridViewSelection();
            });
        }

        /// <summary>
        /// Clears all file selection states in the UI by emptying the copying indices list and deselecting all rows.
        /// </summary>
        private void ClearAllSelections()
        {
            // Use Invoke to ensure UI updates are on the correct thread.
            Invoke(() =>
            {
                // Clear the list of copying indices and clear all selections in the DataGridView.
                _currentlyCopyingIndices.Clear();
                dataGridView2.ClearSelection();
            });
        }

        /// <summary>
        /// Updates the DataGridView selection to highlight all files currently being copied.
        /// </summary>
        private void UpdateDataGridViewSelection()
        {
            // Clear previous selections and highlight rows based on the current copying indices list.
            dataGridView2.ClearSelection();
            foreach (int idx in _currentlyCopyingIndices)
            {
                if (idx >= 0 && idx < dataGridView2.Rows.Count)
                    dataGridView2.Rows[idx].Selected = true;
            }
        }

        /// <summary>
        /// Marks a file as currently being copied in single-file mode by adding it to the single-file copying list.
        /// </summary>
        /// <param name="index">The index of the file in the file list</param>
        private void MarkFileAsCopyingSingle(int index)
        {
            // Use Invoke to safely update the UI from a different thread.
            Invoke(() =>
            {
                // Add the index to a list for single file copying.
                _currentlyCopyingIndicesSingle.Add(index);
                // Update the single file DataGridView selection.
                UpdateDataGridViewSelectionSingle();
            });
        }

        /// <summary>
        /// Marks a file as completed copying in single-file mode by removing it from the single-file copying list.
        /// </summary>
        /// <param name="index">The index of the file in the file list</param>
        private void MarkFileAsCopiedSingle(int index)
        {
            // Use Invoke to safely update the UI from a different thread.
            Invoke((Delegate)(() =>
            {
                // Remove the index from the single file copying list.
                _currentlyCopyingIndicesSingle.Remove(index);
                // Unselect the corresponding row in the DataGridView.
                if (index >= 0 && index < filesDataGridView.Rows.Count)
                    filesDataGridView.Rows[index].Selected = false;
                // Update the single file DataGridView selection.
                UpdateDataGridViewSelectionSingle();
            }));
        }

        /// <summary>
        /// Clears all file selection states in single-file mode UI.
        /// </summary>
        private void ClearAllSelectionsSingle()
        {
            // Use Invoke to safely update the UI from a different thread.
            Invoke((Delegate)(() =>
            {
                // Clear the list and the DataGridView selections.
                _currentlyCopyingIndicesSingle.Clear();
                filesDataGridView.ClearSelection();
            }));
        }

        /// <summary>
        /// Updates the single-file DataGridView selection to highlight files currently being copied.
        /// </summary>
        private void UpdateDataGridViewSelectionSingle()
        {
            // Clear previous selections and highlight the rows specified in the list.
            filesDataGridView.ClearSelection();
            foreach (int idx in _currentlyCopyingIndicesSingle)
            {
                if (idx >= 0 && idx < filesDataGridView.Rows.Count)
                    filesDataGridView.Rows[idx].Selected = true;
            }
        }

        /// <summary>
        /// Processes files using multi-threaded copying with semaphore-based concurrency control.
        /// Handles directory creation, progress tracking, and parallel file operations.
        /// </summary>
        /// <param name="files">The list of files to process</param>
        /// <param name="targetPaths">The target directory paths for copying</param>
        /// <returns>A task representing the asynchronous operation</returns>
        /// 

        private readonly System.Windows.Forms.Timer _multiThreadUiTimer = new System.Windows.Forms.Timer();


        #region ----------  multi-thread copy with per-slot objects  ----------

        private record Slot(int Id,
                            ModernCircularProgressBar Bar,
                            Label NameLabel);

        private Slot[] _slots;

        public async Task ProcessFilesMultiThreaded(List<FileInfoWrapper> files, string[] targetPaths)
        {
            try
            {
                _stopwatch.Restart();

                _cancellationTokenSource?.Dispose();
                _cancellationTokenSource = new CancellationTokenSource();
                var token = _cancellationTokenSource.Token;

                if (files == null || files.Count == 0) return;

                ToggleControlsForOperation(false);
                _multiThreadUiTimer.Start();

                using var writeSlots = new SemaphoreSlim(4, 4);

                string sourceRoot = _currentSourceRootPath;
                string targetBase = targetPaths[0];

                // ---- pre-create directories ----
                foreach (var dir in files.Where(f => f.IsDirectory))
                {
                    string destDir = ComputeDestinationPath(dir.FilePath, true, targetBase, sourceRoot);
                    if (!string.IsNullOrEmpty(destDir)) Directory.CreateDirectory(destDir);
                }

                // ---- build work queue ----
                var todo = files
                    .Where(f => !f.IsDirectory)
                    .Select(f => new
                    {
                        Item = f,
                        Src = f.FilePath,
                        Dest = ComputeDestinationPath(f.FilePath, false, targetBase, sourceRoot)
                    })
                    .Where(x => !string.IsNullOrEmpty(x.Dest))
                    .ToList();

                _grandTotalFileCount = todo.Count;
                _totalBytesToProcess = todo.Sum(x => new FileInfo(x.Src).Length);
                _totalBytesProcessed = 0;
                _multiThreadProcessedFiles = 0;
                _totalFilesSkipped = 0;
                _totalFilesFailed = 0;

                // SLOT-QUEUE: 4 slots that get recycled
                var slotQ = new System.Collections.Concurrent.ConcurrentQueue<Slot>();
                foreach (var s in _slots) slotQ.Enqueue(s);

                await Parallel.ForEachAsync(todo,
                    new ParallelOptions
                    {
                        CancellationToken = token,
                        MaxDegreeOfParallelism = 4
                    },
                    async (job, ct) =>
                    {
                        // 1.  pick next free slot (will be returned later)
                        slotQ.TryDequeue(out Slot slot);

                        // 2.  acquire semaphore
                        await writeSlots.WaitAsync(ct);

                        try
                        {
                            // 3.  show which file we are about to copy
                            Invoke(() => UpdateMultiSlotStatus(slot.Id, "Copying…", job.Src));

                            // 4.  do the copy
                            await CopyFileWithSlotAsync(slot.Id, job.Src, job.Dest, token);

                            // 5.  success
                            Invoke(() => UpdateMultiSlotStatus(slot.Id, "Done", job.Src));
                            Interlocked.Increment(ref _totalFilesCopied);
                        }
                        catch (OperationCanceledException)
                        {
                            Invoke(() => UpdateMultiSlotStatus(slot.Id, "Canceled", job.Src));
                            Interlocked.Increment(ref _totalFilesSkipped);
                        }
                        catch (Exception ex)
                        {
                            Invoke(() => UpdateMultiSlotStatus(slot.Id, "Failed", $"{job.Src} — {ex.Message}"));
                            Interlocked.Increment(ref _totalFilesFailed);
                        }
                        finally
                        {
                            writeSlots.Release();   // always release semaphore
                            slotQ.Enqueue(slot);    // always return slot to pool
                        }
                    });

                _multiThreadUiTimer.Stop();
                _stopwatch.Stop();

                Invoke(() =>
                {
                    progressBarMultiThreadTotal.Value = 0;
                    progressBarMultiThreadTotal.Text = "0.00%";
                    fileCountMultiLabel.Text = "Files Processed: 0 Out of 0";
                    speedMultiLabel.Text = "Speed: 0 B/s";
                    totalCMDMultiLabel.Text = "Total C/M/D: 0 Bytes / 0 Bytes";
                    totalTimeMultiLabel.Text = "Elapsed / Target Time: 00:00:00 / 00:00:00";
                    totalSpaceMultiLabel.Text = "Total Space Used: 0 Bytes / 0 Bytes";

                    foreach (var s in _slots) UpdateMultiSlotStatus(s.Id, "Idle", string.Empty);

                    ToggleControlsForOperation(true);
                    ClearAllSelections();
                });

                //_copyWorker_RunWorkerCompleted(this,
                //new RunWorkerCompletedEventArgs("Multi-threaded copy complete", null, false));
            }
            catch (OperationCanceledException)
            {
                _multiThreadUiTimer.Stop();
                Invoke(() => { speedMultiLabel.Text = "Operation canceled."; ToggleControlsForOperation(true); });
                //_copyWorker_RunWorkerCompleted(this, new RunWorkerCompletedEventArgs(null, null, true));
            }
            catch (Exception ex)
            {
                _multiThreadUiTimer.Stop();
                Invoke(() => { speedMultiLabel.Text = $"Error: {ex.Message}"; ToggleControlsForOperation(true); });
                //_copyWorker_RunWorkerCompleted(this, new RunWorkerCompletedEventArgs(null, ex, false));
            }
        }
        #endregion

        private void ApplySkin(string skinName, Color foreColor, Color backColor)
        {
            try
            {
                // Apply to form
                this.BackColor = backColor;
                this.ForeColor = foreColor;

                // Apply to all controls recursively
                ApplyColorsToControls(this.Controls, foreColor, backColor);

                // ✅ Apply contrasting color to ModernCircularProgressBars (passing backColor)
                ApplyProgressBarColors(backColor);

                System.Diagnostics.Debug.WriteLine($"Applied skin: {skinName}, ForeColor: {foreColor}, BackColor: {backColor}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error in ApplySkin: {ex.Message}");
                throw;
            }
        }

        // ✅ NEW: Apply colors specifically to ModernCircularProgressBars
        private void ApplyProgressBarColors(Color backgroundColor)
        {
            try
            {
                // Get the contrasting color based on the background
                Color contrastingColor = GetContrastingTextColor(backgroundColor);

                // Create gradient colors for the progress arc based on contrasting color
                Color progressStart = Color.FromArgb(200, contrastingColor);
                Color progressEnd = Color.FromArgb(200, contrastingColor);

                System.Diagnostics.Debug.WriteLine($"Applying progress bar colors - Background: {backgroundColor}, Contrasting: {contrastingColor}");

                // Apply to single-threaded progress bars (if they exist)
                if (this.Controls.Find("fileProgressBar", true).FirstOrDefault() is CustomControls.ModernCircularProgressBar fileBar)
                {
                    fileBar.ForeColor = contrastingColor;
                    fileBar.ProgressStartColor = progressStart;
                    fileBar.ProgressEndColor = progressEnd;
                    fileBar.Invalidate(); // Force redraw
                    System.Diagnostics.Debug.WriteLine($"Applied to fileProgressBar - ForeColor: {fileBar.ForeColor}");
                }

                if (this.Controls.Find("totalProgressBar", true).FirstOrDefault() is CustomControls.ModernCircularProgressBar totalBar)
                {
                    totalBar.ForeColor = contrastingColor;
                    totalBar.ProgressStartColor = progressStart;
                    totalBar.ProgressEndColor = progressEnd;
                    totalBar.Invalidate(); // Force redraw
                    System.Diagnostics.Debug.WriteLine($"Applied to totalProgressBar - ForeColor: {totalBar.ForeColor}");
                }

                // ✅ Apply contrasting color to multithreaded progress bars (text AND arc)
                if (progressBarMutli1 != null)
                {
                    progressBarMutli1.ForeColor = contrastingColor;
                    progressBarMutli1.ProgressStartColor = progressStart;
                    progressBarMutli1.ProgressEndColor = progressEnd;
                    progressBarMutli1.Invalidate(); // Force redraw
                }
                if (progressBarMutli2 != null)
                {
                    progressBarMutli2.ForeColor = contrastingColor;
                    progressBarMutli2.ProgressStartColor = progressStart;
                    progressBarMutli2.ProgressEndColor = progressEnd;
                    progressBarMutli2.Invalidate(); // Force redraw
                }
                if (progressBarMutli3 != null)
                {
                    progressBarMutli3.ForeColor = contrastingColor;
                    progressBarMutli3.ProgressStartColor = progressStart;
                    progressBarMutli3.ProgressEndColor = progressEnd;
                    progressBarMutli3.Invalidate(); // Force redraw
                }
                if (progressBarMutli4 != null)
                {
                    progressBarMutli4.ForeColor = contrastingColor;
                    progressBarMutli4.ProgressStartColor = progressStart;
                    progressBarMutli4.ProgressEndColor = progressEnd;
                    progressBarMutli4.Invalidate(); // Force redraw
                }
                if (progressBarMultiThreadTotal != null)
                {
                    progressBarMultiThreadTotal.ForeColor = contrastingColor;
                    progressBarMultiThreadTotal.ProgressStartColor = progressStart;
                    progressBarMultiThreadTotal.ProgressEndColor = progressEnd;
                    progressBarMultiThreadTotal.Invalidate(); // Force redraw
                }

                System.Diagnostics.Debug.WriteLine($"Applied contrasting progress bar colors: {contrastingColor} for background: {backgroundColor}");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error applying progress bar colors: {ex.Message}");
            }
        }

        // Recursive helper to apply colors to all controls
        private void ApplyColorsToControls(System.Windows.Forms.Control.ControlCollection controls, Color foreColor, Color backColor)
        {
            foreach (System.Windows.Forms.Control control in controls)
            {
                // Skip certain control types that shouldn't inherit colors
                if (control is Button || control is TextBox || control is ComboBox)
                {
                    // These typically maintain their own appearance
                    continue;
                }

                // Apply colors
                control.ForeColor = foreColor;
                control.BackColor = backColor;

                // Recursively apply to child controls
                if (control.HasChildren)
                {
                    ApplyColorsToControls(control.Controls, foreColor, backColor);
                }
            }
        }


        private void PickCustomColor()
        {
            using (ColorDialog colorDialog = new ColorDialog())
            {
                colorDialog.Color = this.BackColor;
                colorDialog.AllowFullOpen = true;
                colorDialog.FullOpen = true;

                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    Color selectedColor = colorDialog.Color;
                    Color textColor = GetContrastingTextColor(selectedColor);

                    ApplySkin("Custom Color", textColor, selectedColor);

                    CopyThatProgram.Properties.Settings.Default.Skin = "Custom Color";
                    CopyThatProgram.Properties.Settings.Default.CustomBackColor = selectedColor;
                    CopyThatProgram.Properties.Settings.Default.CustomForeColor = textColor;
                    CopyThatProgram.Properties.Settings.Default.skinsIndex = skinsComboBox.SelectedIndex;

                    CopyThatProgram.Properties.Settings.Default.Save();

                    System.Diagnostics.Debug.WriteLine($"Saved Custom Color - Fore: {textColor}, Back: {selectedColor}");
                }
                else
                {
                    string savedKey = CopyThatProgram.Properties.Settings.Default.Skin ?? "Light Mode";
                    SelectSkinInCombo(savedKey);
                }
            }
        }

        private Color GetContrastingTextColor(Color backgroundColor)
        {
            double brightness = (0.299 * backgroundColor.R +
                                0.587 * backgroundColor.G +
                                0.114 * backgroundColor.B) / 255;

            return brightness > 0.5 ? Color.Black : Color.White;
        }



        private void UpdateMultiThreadUiTimer_Tick(object? sender, EventArgs e)
        {
            if (_totalBytesToProcess == 0) return;

            double totalPct = (_totalBytesProcessed / (double)_totalBytesToProcess) * 100.0;
            double elapsedSec = _stopwatch.Elapsed.TotalSeconds;
            double bytesPerSec = elapsedSec > 0 ? _totalBytesProcessed / elapsedSec : 0;
            double remainingSec = bytesPerSec > 0
                ? (_totalBytesToProcess - _totalBytesProcessed) / bytesPerSec
                : 0;

            TimeSpan elapsed = TimeSpan.FromSeconds(elapsedSec);
            TimeSpan target = TimeSpan.FromSeconds(elapsedSec + remainingSec);

            progressBarMultiThreadTotal.Value = Math.Min((int)(totalPct * 100), 10000);
            progressBarMultiThreadTotal.Text = $"{totalPct:F2}%";

            fileCountMultiLabel.Text = $"Files Processed: {_multiThreadProcessedFiles:N0} Out of {_grandTotalFileCount:N0}";
            totalCMDMultiLabel.Text = $"Total C/M/D: {FormatBytes(_totalBytesProcessed)} / {FormatBytes(_totalBytesToProcess)}";
            speedMultiLabel.Text = $"Speed: {FormatSpeed(bytesPerSec)}";

            totalTimeMultiLabel.Text = $"Elapsed / Target Time: {elapsed:hh\\:mm\\:ss} / {target:hh\\:mm\\:ss}";
        }


        private async Task CopyFileWithSlotAsync(
            int slotIndex,
            string sourceFile,
            string destinationFile,
            CancellationToken token)
        {
            try
            {
                Directory.CreateDirectory(System.IO.Path.GetDirectoryName(destinationFile)!);

                var srcInfo = new FileInfo(sourceFile);
                long totalBytes = srcInfo.Length;

                if (File.Exists(destinationFile))
                {
                    var dstInfo = new FileInfo(destinationFile);

                    if (_doNotOverwrite)
                    {
                        Invoke(() => UpdateMultiSlotStatus(slotIndex, "Skipped (exists)", sourceFile));
                        Interlocked.Increment(ref _totalFilesSkipped);
                        string reason = "File exists and 'Do Not Overwrite' is selected.";
                        var skippedItem = new FileInfoWrapper { FileName = srcInfo.Name, BytesRaw = totalBytes, FilePath = sourceFile };
                        HandleSkippedFile(skippedItem, reason, destinationFile);
                        return;
                    }
                    if (_overwriteIfNewer && srcInfo.LastWriteTime <= dstInfo.LastWriteTime)
                    {
                        Invoke(() => UpdateMultiSlotStatus(slotIndex, "Skipped (not newer)", sourceFile));
                        Interlocked.Increment(ref _totalFilesSkipped);
                        string reason = "Destination file is newer or the same age.";
                        var skippedItem = new FileInfoWrapper { FileName = srcInfo.Name, BytesRaw = totalBytes, FilePath = sourceFile };
                        HandleSkippedFile(skippedItem, reason, destinationFile);
                        return;
                    }
                    File.Delete(destinationFile);
                }

                int bufferBytes = (int)(bufferNumUpDown.Value * 1024);
                byte[] buffer = new byte[bufferBytes];
                long bytesCopied = 0;

                var sw = Stopwatch.StartNew();
                long lastBytes = 0;
                double lastUpdateTime = 0;

                await using var src = await RetryOpenAsync(
                    sourceFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite,
                    bufferBytes, FileOptions.SequentialScan);
                if (src == null) return;

                await using var dst = await RetryOpenAsync(
                    destinationFile, FileMode.CreateNew, FileAccess.Write, FileShare.None,
                    bufferBytes, FileOptions.SequentialScan);
                if (dst == null) return;

                while (true)
                {
                    token.ThrowIfCancellationRequested();
                    _pauseEvent.WaitOne();

                    int bytesRead = await src.ReadAsync(buffer.AsMemory(0, buffer.Length), token);
                    if (bytesRead == 0)
                        break;

                    await dst.WriteAsync(buffer.AsMemory(0, bytesRead), token);

                    bytesCopied += bytesRead;
                    Interlocked.Add(ref _totalBytesProcessed, bytesRead);

                    double pct = totalBytes > 0 ? (bytesCopied / (double)totalBytes) * 100 : 100;

                    double currentTime = sw.Elapsed.TotalSeconds;
                    double deltaTime = currentTime - lastUpdateTime;

                    if (deltaTime < 0.1)
                        continue;

                    double bytesThisInterval = bytesCopied - lastBytes;
                    double speedBytesPerSec = deltaTime > 0 ? bytesThisInterval / deltaTime : 0;
                    double speedMBps = speedBytesPerSec / (1024 * 1024);

                    double remainingBytes = totalBytes - bytesCopied;
                    double etaSeconds = speedBytesPerSec > 0 ? remainingBytes / speedBytesPerSec : 0;

                    lastBytes = bytesCopied;
                    lastUpdateTime = currentTime;

                    string currentFileName = System.IO.Path.GetFileName(sourceFile);
                    string processedStr = FormatBytes(bytesCopied);
                    string totalStr = FormatBytes(totalBytes);
                    string speedStr = $"{speedMBps:F2} MB/Sec";

                    string etaStr;
                    if (etaSeconds > 3600)
                        etaStr = $"{etaSeconds / 3600:F1} hr";
                    else if (etaSeconds > 60)
                        etaStr = $"{etaSeconds / 60:F1} min";
                    else
                        etaStr = $"{etaSeconds:F1} sec";

                    string displayText = $"File: {currentFileName} || Processed: {processedStr} / {totalStr} || Speed: {speedStr} || ETA: {etaStr}";

                    Invoke(() =>
                    {
                        UpdateMultiSlotProgress(slotIndex, pct, sourceFile);
                        UpdateMultiSlotLabel(slotIndex, displayText);
                    });
                }

                sw.Stop();
                Interlocked.Increment(ref _multiThreadProcessedFiles);
                Interlocked.Increment(ref _totalFilesCopied); // ✅ Track copied files
                Invoke(() => UpdateMultiSlotStatus(slotIndex, "Done", sourceFile));
            }
            catch (OperationCanceledException)
            {
                Invoke(() => UpdateMultiSlotStatus(slotIndex, "Canceled", sourceFile));
                Interlocked.Increment(ref _totalFilesSkipped);
            }
            catch (Exception ex)
            {
                Invoke(() => UpdateMultiSlotStatus(slotIndex, "Failed", $"{sourceFile}\n{ex.Message}"));
                Interlocked.Increment(ref _totalFilesFailed);
            }
        }

        private void UpdateMultiSlotLabel(int slot, string text)
        {
            Label label = slot switch
            {
                1 => filesNameLabel1,
                2 => filesNameLabel2,
                3 => filesNameLabel3,
                4 => filesNameLabel4,
                _ => filesNameLabel1
            };

            label.Text = text;
        }

        private void UpdateMultiSlotProgress(int slot, double percent, string fileName)
        {
            CustomControls.ModernCircularProgressBar bar = slot switch
            {
                1 => progressBarMutli1,
                2 => progressBarMutli2,
                3 => progressBarMutli3,
                4 => progressBarMutli4,
                _ => progressBarMutli1
            };

            Label fileLabel = slot switch
            {
                1 => filesNameLabel1,
                2 => filesNameLabel2,
                3 => filesNameLabel3,
                4 => filesNameLabel4,
                _ => filesNameLabel1
            };

            bar.Value = Math.Min((int)(percent * 100), 10000);
            bar.Text = $"{percent:F2}%";
        }

        private void UpdateMultiSlotStatus(int slot, string status, string file)
        {
            Label label = slot switch
            {
                1 => filesNameLabel1,
                2 => filesNameLabel2,
                3 => filesNameLabel3,
                4 => filesNameLabel4,
                _ => filesNameLabel1
            };

            string fileName = string.IsNullOrEmpty(file) ? "" : System.IO.Path.GetFileName(file);
            label.Text = string.IsNullOrEmpty(fileName) ? status : $"{fileName} — {status}";
        }

        /// <summary>
        /// Converts a file path to extended length format to support paths longer than MAX_PATH.
        /// </summary>
        /// <param name="path">The original file path</param>
        /// <returns>The path in extended length format</returns>
        private static string ToExtendedLengthPath(string path)
        {
            // Checks if the path is already in extended length format
            if (path.StartsWith(@"\\?\"))
                return path;
            // If it's a UNC path (starts with \\), converts it to the extended UNC format
            if (path.StartsWith(@"\\"))
                return @"\\?\UNC\" + path.Substring(2);
            // For all other paths, adds the extended length prefix
            return @"\\?\" + path;
        }

        /// <summary>
        /// Copies files to a single target directory with retry logic, progress reporting, and directory structure creation.
        /// </summary>
        /// <param name="bw">The background worker for cancellation support</param>
        /// <param name="e">DoWorkEventArgs for cancellation handling</param>
        /// <param name="targetBase">The base target directory path</param>
        /// <returns>A task representing the asynchronous copy operation</returns>
        private async Task CopyToSingleTarget(BackgroundWorker bw,
                                         DoWorkEventArgs e,
                                         string targetBase)
        {
            const int MAX_RETRIES = 3;
            _finishCurrentFileAndQuit = false;

            // --- separate directories and files ---
            var dirs = _fileList.Where(i => i.IsDirectory).ToList();
            var files = _fileList.Where(i => !i.IsDirectory).ToList();

            _filesToProcess = files.Count;

            _copyStopwatch.Restart();
            _lastSpeedBytes = 0;
            _startTick = Environment.TickCount64;

            // ===== Create directory skeleton =====
            var allDirs = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            if (!Directory.Exists(targetBase))
                allDirs.Add(targetBase);

            foreach (var item in _fileList)
            {
                if (_keepOnlyFiles && item.IsDirectory) continue;

                string dest = ComputeDestinationPath(item.FilePath, item.IsDirectory,
                                                     targetBase, _currentSourceRootPath);
                if (string.IsNullOrEmpty(dest)) continue;

                string dirToCreate = item.IsDirectory
                                     ? dest
                                     : System.IO.Path.GetDirectoryName(dest);
                if (!string.IsNullOrEmpty(dirToCreate))
                    allDirs.Add(dirToCreate);
            }

            var finalDirs = new HashSet<string>(allDirs, StringComparer.OrdinalIgnoreCase);
            foreach (var d in allDirs)
            {
                string parent = System.IO.Path.GetDirectoryName(d);
                while (!string.IsNullOrEmpty(parent) && parent.Length >= targetBase.Length)
                {
                    finalDirs.Add(parent);
                    parent = System.IO.Path.GetDirectoryName(parent);
                }
            }

            var sortedDirs = finalDirs.OrderBy(d => d.Length).ToList();
            foreach (string dirPath in sortedDirs)
            {
                _pauseEvent.WaitOne();
                if (bw.CancellationPending) { e.Cancel = true; return; }

                try
                {
                    if (!Directory.Exists(dirPath))
                    {
                        Directory.CreateDirectory(dirPath);          // <<-- folder now exists

                        // --- update UI -------------------------------------------------
                        Invoke(() =>
                        {
                            fromFilesDirLabel.Text = dirPath;
                            statusLabel.Text = $"Creating folder – {System.IO.Path.GetFileName(dirPath)}";

                            // find the *directory* item that owns this path
                            var dirItem = _fileList.FirstOrDefault(d => d.IsDirectory &&
                                                                       d.FilePath.Equals(dirPath, StringComparison.OrdinalIgnoreCase));
                            if (dirItem != null)
                                UpdateFileStatus(dirItem, "Folder Created...");
                        });
                        // ----------------------------------------------------------------
                    }
                }
                catch (Exception ex)
                {
                    LogWarning($"Failed to create directory {dirPath}: {ex.Message}");
                }
            }

            // ===== Copy each file =====
            foreach (var item in files)
            {
                Interlocked.Increment(ref _processedFiles);
                UpdateOverallLabels();
                if (bw.CancellationPending) { e.Cancel = true; return; }

                string dstPath = ComputeDestinationPath(item.FilePath, false,
                                                        targetBase, _currentSourceRootPath);
                if (string.IsNullOrEmpty(dstPath))
                {
                    LogAndSkip(item, "Could not compute destination path.");
                    Interlocked.Increment(ref _processedFiles);
                    continue;
                }

                _pauseEvent.WaitOne();

                int gridIndex = _fileList.IndexOf(item);
                long fileSize = new FileInfo(item.FilePath).Length;

                Invoke(() =>
                {

                    filePathLabel.Text = item.FilePath;
                    fromFilesDirLabel.Text = System.IO.Path.GetDirectoryName(item.FilePath);
                    statusLabel.Text = $"Copying – {System.IO.Path.GetFileName(item.FilePath)}";
                    SelectCurrentFileInGrid(gridIndex);
                });

                bool copied = false;
                Exception lastEx = null;

                for (int attempt = 1; attempt <= MAX_RETRIES; attempt++)
                {
                    try
                    {
                        await CopyFileWithProgress(item, fileSize, 0, targetBase);
                        copied = true;
                        break;
                    }
                    catch (IOException ex) when (attempt < MAX_RETRIES)
                    {
                        Invoke(() => UpdateFileStatus(item, $"Failed: Retry #{attempt}"));
                        LogWarning($"Retry {attempt}/{MAX_RETRIES} – {ex.Message}");
                        await Task.Delay(500);
                    }
                    catch (Exception ex)
                    {
                        lastEx = ex;
                        break;
                    }
                }

                if (copied)
                {
                    Interlocked.Increment(ref _totalFilesCopied);
                    Invoke(() => UpdateFileStatus(item, "File Copied..."));
                }
                else
                {
                    LogAndSkip(item, lastEx);
                }
                // Checks if the user requested to quit
                if (_finishCurrentFileAndQuit) break;
            }
        }

        /// <summary>
        /// Background worker DoWork event handler that coordinates file copying to multiple target directories.
        /// Handles iteration through target paths, cancellation, and final UI updates.
        /// </summary>
        /// <param name="sender">The event sender (background worker)</param>
        /// <param name="e">DoWorkEventArgs containing event data</param>
        private void _copyWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = sender as BackgroundWorker;

            try
            {
                new Func<BackgroundWorker, Task>(async bw =>
                {
                    // 🔑 iterate over every target folder
                    foreach (string targetBase in targetPaths)
                    {
                        if (string.IsNullOrWhiteSpace(targetBase))
                            continue;

                        ResetAllFileStatuses();

                        // --- Update header labels for this target ---
                        Invoke(() =>
                        {
                            fromFilesDirLabel.Text = $"Target: {targetBase}";
                            statusLabel.Text = $"Starting copy to {targetBase}";
                        });

                        // --- Perform the actual copy for this target ---
                        await CopyToSingleTarget(bw, e, targetBase);

                        if (bw.CancellationPending || e.Cancel)
                            break;
                    }

                    // Final UI update
                    Invoke(() =>
                    {
                        statusLabel.Text = bw.CancellationPending ? "Cancelled" : "All targets complete";
                        totalProgressBar.Value = totalProgressBar.Maximum;
                        totalProgressBar.Text = "100.00%";
                    });

                })(worker).GetAwaiter().GetResult();
            }
            catch (OperationCanceledException)
            {
                e.Cancel = true;
            }
        }


        private void MoveWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Casts the sender to a BackgroundWorker
            var worker = sender as BackgroundWorker;
            try
            {
                // Defines and executes an async function on the worker thread
                new Func<BackgroundWorker, Task>(async bw =>
                {
                    // Gets the first target path
                    string targetBase = _currentTargetPaths.FirstOrDefault();
                    // If no target path exists, cancels the operation
                    if (string.IsNullOrEmpty(targetBase)) { e.Cancel = true; return; }

                    // Defines the maximum number of retries
                    const int MAX_RETRIES = 3;
                    // Resets the quit flag
                    _finishCurrentFileAndQuit = false;

                    // Separates files into directories and non-directories
                    var dirs = _fileList.Where(i => i.IsDirectory).ToList();
                    var files = _fileList.Where(i => !i.IsDirectory).ToList();

                    _filesToProcess = files.Count;

                    // Restarts the stopwatch
                    _copyStopwatch.Restart();

                    // Creates all the destination directories before starting file moves
                    foreach (var dirItem in dirs)
                    {
                        // Waits for a pause signal and checks for cancellation
                        _pauseEvent.WaitOne();
                        if (bw.CancellationPending) { e.Cancel = true; return; }

                        // Computes the destination directory path
                        string dstDir = ComputeDestinationPath(dirItem.FilePath, true,
                                                                targetBase, _currentSourceRootPath);
                        // Creates the directory and updates the UI status
                        Directory.CreateDirectory(dstDir);
                        Invoke(() => UpdateFileStatus(dirItem, "Folder Created"));
                    }

                    // Loops through each file to be moved
                    foreach (var item in files)
                    {
                        // Waits for a pause signal and checks for cancellation
                        _pauseEvent.WaitOne();
                        if (bw.CancellationPending) { e.Cancel = true; return; }

                        // Gets the index of the current file and its size
                        int gridIndex = _fileList.IndexOf(item);
                        long fileSize = new FileInfo(item.FilePath).Length;
                        long bytesThisFile = 0;

                        // Updates UI labels with move progress
                        Invoke(() =>
                        {
                            fileCountOnLabel.Text = $"File Count: {_processedFiles:N0} / {_grandTotalFileCount:N0}";
                            filePathLabel.Text = item.FilePath;
                            statusLabel.Text = $"Moving – {System.IO.Path.GetFileName(item.FilePath)}";
                        });

                        // Selects the current file in the grid
                        SelectCurrentFileInGrid(gridIndex);

                        // Flag to check if the move was successful and an exception variable
                        bool moved = false;
                        Exception lastEx = null;

                        // Retries the move operation up to MAX_RETRIES times
                        for (int attempt = 0; attempt <= MAX_RETRIES; attempt++)
                        {
                            try
                            {
                                // Computes the destination path
                                string dest = ComputeDestinationPath(item.FilePath, false,
                                                                      targetBase, _currentSourceRootPath);
                                // Ensures the destination directory exists
                                EnsureDirectoryExistsForFile(dest);

                                // Moves the file from the source to the destination
                                File.Move(item.FilePath, dest);
                                // Sets the moved flag and breaks the loop on success
                                moved = true;
                                break;
                            }
                            // Catches any exception and stores it
                            catch (Exception ex) { lastEx = ex; }
                        }

                        // If the file was moved successfully
                        if (moved)
                        {
                            // Updates the file status and waits briefly
                            item.Status = "Moved";
                            await Task.Delay(25);
                        }
                        // If the move failed, logs and skips the file
                        else
                        {
                            LogAndSkip(item, lastEx);
                        }

                        // Increments the processed files count
                        Interlocked.Increment(ref _processedFiles);
                        // Checks if the user requested to quit
                        if (_finishCurrentFileAndQuit) break;
                    }

                    // Updates the UI to show 100% completion
                    Invoke((Delegate)(() =>
                    {
                        fileProgressBar.Value = fileProgressBar.Maximum;
                        fileProgressBar.Text = "100.00%";
                        totalProgressBar.Value = totalProgressBar.Maximum;
                        totalProgressBar.Text = "100.00%";
                    }));
                    // Ensures the async method runs synchronously
                })(worker).GetAwaiter().GetResult();
            }
            // Catches a cancellation exception and sets the cancel flag
            catch (OperationCanceledException) { e.Cancel = true; }
        }

        private void DeleteWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Casts the sender to a BackgroundWorker
            var worker = sender as BackgroundWorker;
            try
            {
                // Defines and executes an async function
                new Func<BackgroundWorker, Task>(async bw =>
                {
                    // Defines the maximum number of retries
                    const int MAX_RETRIES = 3;
                    // Resets the quit flag
                    _finishCurrentFileAndQuit = false;

                    // Confirms secure deletion with the user
                    if (copyMoveDeleteComboBox.SelectedItem?.ToString() == "Secure Delete Files")
                    {
                        // Gets the root folder of the first file
                        string rootFolder = System.IO.Path.GetDirectoryName(_fileList.FirstOrDefault()?.FilePath ?? "");
                        // Shows a confirmation message box
                        var confirm = MessageBox.Show(
                            $"Secure deletion is about to take place on folder:\n\n{rootFolder}\n\nWould you like to continue?",
                            "Confirm Secure Delete",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Warning);

                        // If the user does not confirm, cancels the operation
                        if (confirm != DialogResult.Yes) { e.Cancel = true; return; }
                    }

                    // Separates files into directories and non-directories
                    var dirs = _fileList.Where(i => i.IsDirectory).ToList();
                    var files = _fileList.Where(i => !i.IsDirectory).ToList();

                    _filesToProcess = files.Count;

                    // Restarts the stopwatch
                    _copyStopwatch.Restart();

                    // Loops through each file to be deleted
                    foreach (var item in files)
                    {
                        // Waits for a pause signal and checks for cancellation
                        _pauseEvent.WaitOne();
                        if (bw.CancellationPending) { e.Cancel = true; return; }

                        // Gets the index of the current file and its size
                        int gridIndex = _fileList.IndexOf(item);
                        long fileSize = new FileInfo(item.FilePath).Length;

                        // Updates UI labels with delete progress
                        Invoke(() =>
                        {
                            fileCountOnLabel.Text = $"File Count: {_processedFiles:N0} / {_grandTotalFileCount:N0}";
                            filePathLabel.Text = item.FilePath;
                            statusLabel.Text = $"Secure deleting – {System.IO.Path.GetFileName(item.FilePath)}";
                        });

                        // Selects the current file in the grid
                        SelectCurrentFileInGrid(gridIndex);

                        // Flag to check if the delete was successful and an exception variable
                        bool deleted = false;
                        Exception lastEx = null;

                        // Retries the delete operation up to MAX_RETRIES times
                        for (int attempt = 0; attempt <= MAX_RETRIES; attempt++)
                        {
                            try
                            {
                                // Calls the secure delete method
                                SecureDeleteFile(item.FilePath);
                                // Sets the deleted flag and breaks the loop on success
                                deleted = true;
                                break;
                            }
                            // Catches any exception and stores it
                            catch (Exception ex) { lastEx = ex; }
                        }

                        // If the file was deleted successfully
                        if (deleted)
                        {
                            // Updates the file status and waits briefly
                            item.Status = "Securely Deleted";
                            await Task.Delay(25);
                        }
                        // If the delete failed, logs and skips the file
                        else
                        {
                            LogAndSkip(item, lastEx);
                        }

                        // Increments the processed files count
                        Interlocked.Increment(ref _processedFiles);
                        // Checks if the user requested to quit
                        if (_finishCurrentFileAndQuit) break;
                    }

                    // Deletes empty directories, starting from the deepest level
                    foreach (var dirItem in dirs.OrderByDescending(d => d.FilePath.Length))
                    {
                        var dir = dirItem.FilePath;
                        // Checks if the directory exists and is empty
                        if (Directory.Exists(dir) && !Directory.EnumerateFileSystemEntries(dir).Any())
                        {
                            try { Directory.Delete(dir, false); }
                            // Ignores any exceptions during directory deletion
                            catch { /* ignore */ }
                        }
                    }

                    // Updates the UI to show 100% completion
                    Invoke((Delegate)(() =>
                    {
                        fileProgressBar.Value = fileProgressBar.Maximum;
                        fileProgressBar.Text = "100.00%";
                        totalProgressBar.Value = totalProgressBar.Maximum;
                        totalProgressBar.Text = "100.00%";
                    }));
                    // Ensures the async method runs synchronously
                })(worker).GetAwaiter().GetResult();
            }
            // Catches a cancellation exception and sets the cancel flag
            catch (OperationCanceledException) { e.Cancel = true; }
        }







        // ADD THIS HELPER
        [System.Runtime.InteropServices.DllImport("shell32.dll", CharSet = CharSet.Auto)]
        private static extern IntPtr SHGetFileInfo(string pszPath, uint dwFileAttributes,
                                                   ref SHFILEINFO psfi, uint cbFileInfo, uint uFlags);

        private struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public uint dwAttributes;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        private const uint SHGFI_ICON = 0x100;
        private const uint SHGFI_SMALLICON = 0x0;


        // ADD THIS SMALL WRAPPER
        private void SetFileIcon(string filePath)
        {
            if (multithreadCheckBox.Checked) return;          // ignore in multi-thread
            if (string.IsNullOrEmpty(filePath) || !File.Exists(filePath))
            {
                fileIconPicBox.Image = null;                  // blank when no file
                return;
            }

            SHFILEINFO shfi = new SHFILEINFO();
            SHGetFileInfo(filePath, 0, ref shfi, (uint)System.Runtime.InteropServices.Marshal.SizeOf(shfi),
                          SHGFI_ICON | SHGFI_SMALLICON);

            if (shfi.hIcon != IntPtr.Zero)
            {
                using (System.Drawing.Icon ico = System.Drawing.Icon.FromHandle(shfi.hIcon))
                    fileIconPicBox.Image = ico.ToBitmap();
                // release native handle to avoid leak
                DestroyIcon(shfi.hIcon);
            }
        }

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        private static extern bool DestroyIcon(IntPtr hIcon);

        /// <summary>
        /// Asynchronously copies a single file with detailed progress reporting, UI updates, and performance monitoring.
        /// Handles extended length paths, progress throttling, and real-time statistics display.
        /// </summary>
        /// <param name="item">The file item wrapper containing file metadata and source information</param>
        /// <param name="fileSize">The total size of the file in bytes</param>
        /// <param name="fileBytesDone">The number of bytes already processed for this file (for resuming)</param>
        /// <param name="targetBase">The base target directory where the file should be copied</param>
        /// <returns>A task representing the asynchronous file copy operation</returns>
        private async Task CopyFileWithProgress(FileInfoWrapper item,
                                                     long fileSize,
                                                     long fileBytesDone,
                                                     string targetBase)
        {
            string srcPath = ToExtendedLengthPath(item.FilePath);
            string dstPath = ToExtendedLengthPath(
                ComputeDestinationPath(item.FilePath, false, targetBase, _currentSourceRootPath));
            if (string.IsNullOrEmpty(dstPath)) return;

            if (File.Exists(dstPath))
            {
                var srcInfo = new FileInfo(srcPath);
                var dstInfo = new FileInfo(dstPath);

                if (_doNotOverwrite)
                {
                    string reason = "File exists and 'Do Not Overwrite' is selected.";
                    Invoke(() => UpdateFileStatus(item, "Skipped (exists)"));
                    Interlocked.Increment(ref _totalFilesSkipped);
                    HandleSkippedFile(item, reason, dstPath);
                    return;
                }
                if (_overwriteIfNewer && srcInfo.LastWriteTime <= dstInfo.LastWriteTime)
                {
                    string reason = "Destination file is newer or the same age.";
                    Invoke(() => UpdateFileStatus(item, "Skipped (not newer)"));
                    Interlocked.Increment(ref _totalFilesSkipped);
                    HandleSkippedFile(item, reason, dstPath);
                    return;
                }
                File.Delete(dstPath);
            }

            Directory.CreateDirectory(System.IO.Path.GetDirectoryName(dstPath)!);

            int bufferBytes = (int)(bufferNumUpDown.Value * 1024);
            byte[] buffer = new byte[bufferBytes];
            long lastTick = Environment.TickCount64;

            // ✅ Use RetryOpenAsync and check for null
            await using var src = await RetryOpenAsync(srcPath, FileMode.Open, FileAccess.Read,
                                                 FileShare.ReadWrite, bufferBytes,
                                                 FileOptions.SequentialScan);
            if (src == null) return; // Error was handled by RetryOpenAsync

            // ✅ Use RetryOpenAsync and check for null
            await using var dst = await RetryOpenAsync(dstPath, FileMode.CreateNew, FileAccess.Write,
                                                 FileShare.None, bufferBytes,
                                                 FileOptions.SequentialScan);
            if (dst == null) return; // Error was handled by RetryOpenAsync

            while (true)
            {
                SetFileIcon(item.FilePath);
                _pauseEvent.WaitOne();
                _cancelDialogEvent.WaitOne();

                int read = await src.ReadAsync(buffer, 0, buffer.Length);
                if (read == 0) break;

                await dst.WriteAsync(buffer, 0, read);
                fileBytesDone += read;
                _totalBytesProcessed += read;

                double filePct = fileSize > 0 ? fileBytesDone * 100.0 / fileSize : 100.0;
                double overallPct = _totalBytesToProcess > 0
                                    ? _totalBytesProcessed * 100.0 / _totalBytesToProcess
                                    : 100.0;

                Invoke(() =>
                {
                    fileProgressBar.Value = Math.Min((int)(filePct * 100), 10_000);
                    totalProgressBar.Value = Math.Min((int)(overallPct * 100), 10_000);
                    UpdateFileStatus(item, $"{filePct:F2}% done");
                });
            }
        }




        private void MoveWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Checks if there are any skipped files in the list.
            if (_skippedFilesList.Any())
            {
                // If the current thread is not the UI thread, it invokes a delegate
                // to set the selected tab to the second one (index 2) on the UI thread.
                if (InvokeRequired)
                    Invoke(new Action(() => tabControl1.SelectedIndex = 2));
                // Otherwise, it directly sets the selected tab.
                else
                    tabControl1.SelectedIndex = 2;
            }

            // Ensures that the following UI updates are performed on the UI thread.
            Invoke((Delegate)(() =>
            {

                fileProgressBar.Value = fileProgressBar.Maximum;
                // Updates the file progress label to "100.00%".
                fileProgressBar.Text = "100.00%";
                // Sets the total progress bar to its maximum value.
                totalProgressBar.Value = totalProgressBar.Maximum;
                // Updates the total progress label to "100.00%".
                totalProgressBar.Text = "100.00%";
            }));

            // Checks if the background worker completed with an error.
            if (e.Error != null)
            {
                // Displays a message box with the error message.
                MessageBox.Show($"Move operation completed with errors: {e.Error.Message}", "Move Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Logs the error.
                LogError($"Move Worker Error: {e.Error}");
                // Invokes a delegate to show operation statistics and reset the UI.
                Invoke(() =>
                {
                    ShowOperationStatisticsSummary(false);
                    ResetProgressUIAndVariables();
                });
                // Stops the stopwatch that measures the operation duration.
                _stopwatch.Stop();
                // Stops the timer used for updating the UI.
                _updateTimer.Stop();
            }
            // Checks if the operation was cancelled by the user.
            else if (e.Cancelled)
            {
                // Displays a message box informing the user of the cancellation.
                MessageBox.Show("Move operation cancelled by user.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // If the operation completed without errors or cancellation.
            else
            {
                // Invokes a delegate to show the operation summary and reset the UI.
                Invoke(() =>
                {
                    ShowOperationStatisticsSummary(false);
                    ResetProgressUIAndVariables();
                });
                // Stops the stopwatch.
                _stopwatch.Stop();
                // Stops the update timer.
                _updateTimer.Stop();
            }

            // Updates the drive space information on the UI.
            UpdateDriveSpaceInfo();

            // Loads the application icon from the embedded resources.
            using (var ms = new System.IO.MemoryStream(Properties.Resources.CopyThatIcon))
            {
                this.Icon = new System.Drawing.Icon(ms);
            }

            // Stops the operation timer if it's not null.
            _operationTimer?.Stop();
            // Signals the pause event, unblocking any waiting threads.
            _pauseEvent.Set();
            // Updates the NotifyIcon text based on the application version and user settings.
            if (proVersion)
            {
                if (minimizeSystemTrayCheckBox.Checked)
                {
                    notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc || Double-Click To Open";
                }
                else
                {
                    notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc";
                }
            }
            else
            {
                if (minimizeSystemTrayCheckBox.Checked)
                {
                    notifyIcon1.Text = "Copy That v1.0 By: Havoc || Double-Click To Open";
                }
                else
                {
                    notifyIcon1.Text = "Copy That v1.0 By: Havoc";
                }
            }

            // Resets the text of the pause/resume button.
            pauseResumeMultiButton.Text = "Pause";

            // Enables and disables various UI controls after the operation.
            startButton.Enabled = true;
            pauseResumeMultiButton.Enabled = false;
            cancelMultiButton.Enabled = false;


            totalProgressBar.Text = "0.00%";
            fileProgressBar.Text = "0.00%";


            totalProgressBar.Value = 0;
            fileProgressBar.Value = 0;
            // Resets various progress-related labels.
            fileProcessedLabel.Text = $"File Processed: 0 Bytes / 0 Bytes";
            totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / 0 Bytes";
            speedLabel.Text = "Speed: N/A";
            elapsedAndTargetTimeLabel.Text = $"Elapsed / Target Time: 00:00:00 / 00:00:00";

            // Resets internal counters and variables.
            _totalBytesProcessed = 0;
            _totalBytesToProcess = 0;
            // Disposes of the CancellationTokenSource and sets it to null.
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;

            // Sets the enabled state of various buttons.
            cancelButton.Enabled = false;
            pauseResumeButton.Enabled = false;
            startButton.Enabled = true;
            skipButton.Enabled = false;

            // Re-enables a large number of UI controls.
            addFileButton.Enabled = true;
            removeFileButton.Enabled = true;
            clearFileListButton.Enabled = true;
            sourceDirectoryLabel.Enabled = true;
            targetDirectoryLabel.Enabled = true;
            moveFileUpLabel.Enabled = true;
            moveFileDownLabel.Enabled = true;
            moveToTopLabel.Enabled = true;
            moveToBottomLabel.Enabled = true;
            exitLabel.Enabled = true;
            minimizeLabel.Enabled = true;
            rollDownLabel.Enabled = true;
            rollUpLabel.Enabled = true;
            settingsLabel.Enabled = true;
            allAboutLabel.Enabled = true;
            overwriteAllCheckBox.Enabled = true;
            doNotOverwriteCheckBox.Enabled = true;
            overwriteIfNewerCheckBox.Enabled = true;
            keepDirStructCheckBox.Enabled = true;
            leaveEmptyFoldersCheckBox.Enabled = true;
            keepOnlyFilesCheckBox.Enabled = true;
            copyFilesDirsCheckBox.Enabled = true;
            createCustomDirCheckBox.Enabled = true;

            // Calls a method to reset the UI and variables again. This seems redundant but is in the original code.
            ResetProgressUIAndVariables();
            // Stops the update timer again.
            _updateTimer.Stop();

            // Updates drive space info again. Also seems redundant.
            UpdateDriveSpaceInfo();
        }

        private void DeleteWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Checks if there are any skipped files.
            if (_skippedFilesList.Any())
            {
                // Invokes the UI thread to set the selected tab to 2.
                if (InvokeRequired)
                    Invoke(new Action(() => tabControl1.SelectedIndex = 2));
                // Directly sets the tab if already on the UI thread.
                else
                    tabControl1.SelectedIndex = 2;
            }
            // Ensures UI updates are on the main thread.
            Invoke((Delegate)(() =>
            {

                fileProgressBar.Value = fileProgressBar.Maximum;

                // Sets file progress label to "100.00%".

                fileProgressBar.Text = "100.00%";

                // Sets total progress bar to 100%.
                totalProgressBar.Value = totalProgressBar.Maximum;
                // Sets total progress label to "100.00%".

                totalProgressBar.Text = "100.00%";
            }));

            // Checks for errors during deletion.
            if (e.Error != null)
            {
                // Displays error message.
                MessageBox.Show($"Secure Delete operation completed with errors: {e.Error.Message}", "Secure Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                // Logs the error.
                LogError($"Secure Delete Worker Error: {e.Error}");
                // Invokes a method to show stats and reset UI.
                Invoke(() =>
                {
                    ShowOperationStatisticsSummary(false);
                    ResetProgressUIAndVariables();
                });
                // Stops the stopwatch and update timer.
                _stopwatch.Stop();
                _updateTimer.Stop();
            }
            // Checks if deletion was cancelled.
            else if (e.Cancelled)
            {
                // Displays cancellation message.
                MessageBox.Show("Secure Delete operation cancelled by user.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            // If deletion completed successfully.
            else
            {
                // Invokes a method to show stats and reset UI.
                Invoke(() =>
                {
                    ShowOperationStatisticsSummary(false);
                    ResetProgressUIAndVariables();
                });
                // Stops the stopwatch and update timer.
                _stopwatch.Stop();
                _updateTimer.Stop();
            }

            // Updates drive space information.
            UpdateDriveSpaceInfo();

            // Sets the application icon.
            using (var ms = new System.IO.MemoryStream(Properties.Resources.CopyThatIcon))
            {
                this.Icon = new System.Drawing.Icon(ms);
            }
            // Stops the operation timer.
            _operationTimer?.Stop();
            // Unblocks paused threads.
            _pauseEvent.Set();
            // Updates the notify icon text based on version and settings.
            if (proVersion)
            {
                if (minimizeSystemTrayCheckBox.Checked)
                {
                    notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc || Double-Click To Open";
                }
                else
                {
                    notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc";
                }
            }
            else
            {
                if (minimizeSystemTrayCheckBox.Checked)
                {
                    notifyIcon1.Text = "Copy That v1.0 By: Havoc || Double-Click To Open";
                }
                else
                {
                    notifyIcon1.Text = "Copy That v1.0 By: Havoc";
                }
            }

            // Resets the pause/resume button text.
            pauseResumeMultiButton.Text = "Pause";

            // Enables and disables buttons.
            startButton.Enabled = true;
            pauseResumeMultiButton.Enabled = false;
            cancelMultiButton.Enabled = false;

            // Resets progress labels.
            totalProgressBar.Text = "0.00%";
            fileProgressBar.Text = "0.00%";

            totalProgressBar.Value = 0;
            fileProgressBar.Value = 0;
            // Resets status labels.
            fileProcessedLabel.Text = $"File Processed: 0 Bytes / 0 Bytes";
            totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / 0 Bytes";
            speedLabel.Text = "Speed: N/A";
            elapsedAndTargetTimeLabel.Text = $"Elapsed / Target Time: 00:00:00 / 00:00:00";

            // Resets internal state variables.
            _totalBytesProcessed = 0;
            _totalBytesToProcess = 0;
            // Disposes the cancellation token source.
            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;

            // Sets the enabled state of various buttons.
            cancelButton.Enabled = false;
            pauseResumeButton.Enabled = false;
            startButton.Enabled = true;
            skipButton.Enabled = false;

            // Re-enables a large number of UI controls.
            sourceDirectoryLabel.Enabled = true;
            targetDirectoryLabel.Enabled = true;
            moveFileUpLabel.Enabled = true;
            moveFileDownLabel.Enabled = true;
            moveToTopLabel.Enabled = true;
            moveToBottomLabel.Enabled = true;
            addFileButton.Enabled = true;
            removeFileButton.Enabled = true;
            clearFileListButton.Enabled = true;
            exitLabel.Enabled = true;
            minimizeLabel.Enabled = true;
            rollDownLabel.Enabled = true;
            rollUpLabel.Enabled = true;
            settingsLabel.Enabled = true;
            allAboutLabel.Enabled = true;
            overwriteAllCheckBox.Enabled = true;
            doNotOverwriteCheckBox.Enabled = true;
            overwriteIfNewerCheckBox.Enabled = true;
            keepDirStructCheckBox.Enabled = true;
            leaveEmptyFoldersCheckBox.Enabled = true;
            keepOnlyFilesCheckBox.Enabled = true;
            copyFilesDirsCheckBox.Enabled = true;
            createCustomDirCheckBox.Enabled = true;

            // Resets UI and variables.
            ResetProgressUIAndVariables();
            // Stops update timer.
            _updateTimer.Stop();

            // Updates drive space info.
            UpdateDriveSpaceInfo();
        }

        private int _totalCopyOps = 0;
        private int _totalMoveOps = 0;
        private int _totalDeleteOps = 0;
        private int _totalCancelledOps = 0;
        private int _totalCompletedOps = 0;

        // File counters
        private long _grandFilesConsidered = 0;
        private long _grandFilesCopied = 0;
        private long _grandFilesMoved = 0;
        private long _grandFilesDeleted = 0;
        private long _grandFilesSkipped = 0;
        private long _grandFilesFailed = 0;

        // Byte counters
        private long _grandBytesProcessed = 0;
        private long _grandBytesToProcess = 0;

        // Timing
        private TimeSpan _grandElapsedTime = TimeSpan.Zero;
        private TimeSpan _grandTargetTime = TimeSpan.Zero;

        TimeSpan elapsed = TimeSpan.Zero;
        private DateTime _lastUpdateTime = DateTime.Now;
        private long _lastBytesProcessed = 0;



        /// <summary>
        /// Updates running totals for file operations, accumulating statistics for the current operation
        /// and updating both in-memory counters and the UI display.
        /// </summary>
        /// <param name="operation">The type of file operation being performed (Copy, Move, or SecureDelete)</param>
        /// <param name="cancelled">Indicates whether the operation was cancelled</param>
        private void UpdateRunningTotals(FileOperation operation, bool cancelled)
        {
            // Operation counters
            switch (operation)
            {
                case FileOperation.Copy:
                    _totalCopyOps++;
                    _grandFilesCopied += _processedFiles;
                    break;
                case FileOperation.Move:
                    _totalMoveOps++;
                    _grandFilesMoved += _processedFiles;
                    break;
                case FileOperation.SecureDelete:
                    _totalDeleteOps++;
                    _grandFilesDeleted += _processedFiles;
                    break;
            }

            if (_isCanceled)
                _totalCancelledOps++;
            else
                _totalCompletedOps++;

            // Files
            _grandFilesConsidered += _grandTotalFileCount;
            _grandFilesSkipped += _totalFilesSkipped;
            _grandFilesFailed += _totalFilesFailed;

            // Bytes
            _grandBytesProcessed += _totalBytesProcessed;
            _grandBytesToProcess += _totalBytesToProcess;

            // Time - capture the current operation's time
            if (_stopwatch != null && _stopwatch.IsRunning)
            {
                _grandElapsedTime += _stopwatch.Elapsed;

                // Calculate target time for this operation
                long bytesRemaining = _totalBytesToProcess - _totalBytesProcessed;
                if (bytesRemaining > 0 && _totalBytesProcessed > 0)
                {
                    double avgSpeed = _totalBytesProcessed / _stopwatch.Elapsed.TotalSeconds;
                    TimeSpan remainingTime = TimeSpan.FromSeconds(bytesRemaining / avgSpeed);
                    _grandTargetTime += _stopwatch.Elapsed + remainingTime;
                }
                else
                {
                    _grandTargetTime += _stopwatch.Elapsed;
                }
            }

            // Update UI
            UpdateRunningTotalsTab();
        }

        /// <summary>
        /// Updates the running totals tab UI with current accumulated statistics.
        /// This method must be called on the UI thread and stops timers before updating labels.
        /// </summary>
        private void UpdateRunningTotalsTab()
        {
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateRunningTotalsTab));
                return;
            }

            // Stop the timer and stopwatch
            _updateTimer.Stop();
            _stopwatch.Stop();

            // Update all the labels...
            totalCopyOperationsLabel.Text = $"Copying Operations Total: {_totalCopyOps}";
            totalMoveOperationsLabel.Text = $"Moving Operations Total: {_totalMoveOps}";
            totalDeleteOperationsLabel.Text = $"Secure Delete Operations Total: {_totalDeleteOps}";
            totalCancelledOperationsLabel.Text = $"Cancelled Operations Total: {_totalCancelledOps}";
            totalCompletedOperationsLabel.Text = $"Completed Operations Total: {_totalCompletedOps}";
            totalFilesConsideredLabel.Text = $"Total Files Considered: {_grandFilesConsidered:N0}";
            totalFilesCopiedLabel.Text = $"Files Copied: {_grandFilesCopied:N0}";
            totalFilesMovedLabel.Text = $"Files Moved: {_grandFilesMoved:N0}";
            totalFilesDeletedLabel.Text = $"Files Securely Deleted: {_grandFilesDeleted:N0}";
            totalFilesSkippedLabel.Text = $"Files Skipped: {_grandFilesSkipped:N0}";
            totalFilesFailedLabel.Text = $"Files Failed: {_grandFilesFailed:N0}";
            totalBytesProcessedLabel.Text = $"Total Bytes Processed: {FormatBytes(_grandBytesProcessed)}";
            totalBytesToProcessLabel.Text = $"Total Bytes To Process (est): {FormatBytes(_grandBytesToProcess)}";

            // Use the static method from TotalsManager for time display
            totalElapsedTimeLabel.Text = $"Total Elapsed Time: {TotalsManager.FormatTimeWithDaysAndYears(_grandElapsedTime)}";
            totalTargetTimeLabel.Text = $"Total Target Time: {TotalsManager.FormatTimeWithDaysAndYears(_grandTargetTime)}";

            // Update reset button state
            resetTotalsButton.Enabled = TotalsManager.HasAnyTotals();
        }

        /// <summary>
        /// Initializes the reset totals button state based on whether any totals exist in persistent storage.
        /// Enables the button only if there are totals to reset.
        /// </summary>
        private void InitializeResetButton()
        {
            resetTotalsButton.Enabled = TotalsManager.HasAnyTotals();
        }


        /// <summary>
        /// Static class responsible for managing and persisting operation totals and statistics
        /// across application sessions using application settings.
        /// </summary>
        public static class TotalsManager
        {
            // Add this helper method to format TimeSpan with days and years
            /// <summary>
            /// Formats a TimeSpan into a human-readable string that includes years, days, and time components
            /// when applicable. Formats as "Xy Yd HH:MM:SS", "Xd HH:MM:SS", or "HH:MM:SS" depending on duration.
            /// </summary>
            /// <param name="timeSpan">The TimeSpan to format</param>
            /// <returns>Formatted time string with appropriate time components</returns>
            public static string FormatTimeWithDaysAndYears(TimeSpan timeSpan)
            {
                if (timeSpan.TotalSeconds < 1)
                    return "00:00:00";

                int totalDays = (int)timeSpan.TotalDays;
                int years = totalDays / 365;
                int remainingDays = totalDays % 365;
                int hours = timeSpan.Hours;
                int minutes = timeSpan.Minutes;
                int seconds = timeSpan.Seconds;

                if (years > 0)
                {
                    return $"{years}y {remainingDays}d {hours:00}:{minutes:00}:{seconds:00}";
                }
                else if (remainingDays > 0)
                {
                    return $"{remainingDays}d {hours:00}:{minutes:00}:{seconds:00}";
                }
                else
                {
                    return $"{hours:00}:{minutes:00}:{seconds:00}";
                }
            }

            // Add this method to check if there are any totals
            /// <summary>
            /// Checks if any operation totals have been recorded in the application settings.
            /// </summary>
            /// <returns>True if any total values are non-zero, otherwise false</returns>
            public static bool HasAnyTotals()
            {
                var settings = Properties.Settings.Default;

                return settings.TotalCopyOperations > 0 ||
                       settings.TotalMoveOperations > 0 ||
                       settings.TotalDeleteOperations > 0 ||
                       settings.TotalCancelledOperations > 0 ||
                       settings.TotalCompletedOperations > 0 ||
                       settings.TotalFilesConsidered > 0 ||
                       settings.TotalFilesCopied > 0 ||
                       settings.TotalFilesMoved > 0 ||
                       settings.TotalFilesDeleted > 0 ||
                       settings.TotalFilesSkipped > 0 ||
                       settings.TotalFilesFailed > 0 ||
                       settings.TotalBytesProcessed > 0 ||
                       settings.TotalBytesToProcess > 0 ||
                       settings.TotalElapsedTimeSeconds > 0 ||
                       settings.TotalTargetTimeSeconds > 0;
            }

            /// <summary>
            /// Saves operation statistics to application settings by accumulating values with existing totals.
            /// </summary>
            /// <param name="copyOps">Number of copy operations to add</param>
            /// <param name="moveOps">Number of move operations to add</param>
            /// <param name="deleteOps">Number of delete operations to add</param>
            /// <param name="cancelledOps">Number of cancelled operations to add</param>
            /// <param name="completedOps">Number of completed operations to add</param>
            /// <param name="filesConsidered">Number of files considered to add</param>
            /// <param name="filesCopied">Number of files copied to add</param>
            /// <param name="filesMoved">Number of files moved to add</param>
            /// <param name="filesDeleted">Number of files deleted to add</param>
            /// <param name="filesSkipped">Number of files skipped to add</param>
            /// <param name="filesFailed">Number of files failed to add</param>
            /// <param name="bytesProcessed">Number of bytes processed to add</param>
            /// <param name="bytesToProcess">Number of bytes to process to add</param>
            /// <param name="elapsedTime">Elapsed time to add to total elapsed time</param>
            /// <param name="targetTime">Target time to add to total target time</param>
            public static void SaveTotals(
                int copyOps, int moveOps, int deleteOps, int cancelledOps, int completedOps,
                long filesConsidered, long filesCopied, long filesMoved, long filesDeleted, long filesSkipped, long filesFailed,
                long bytesProcessed, long bytesToProcess,
                TimeSpan elapsedTime, TimeSpan targetTime)
            {
                var settings = Properties.Settings.Default;

                // Operations
                settings.TotalCopyOperations += copyOps;
                settings.TotalMoveOperations += moveOps;
                settings.TotalDeleteOperations += deleteOps;
                settings.TotalCancelledOperations += cancelledOps;
                settings.TotalCompletedOperations += completedOps;

                // Files
                settings.TotalFilesConsidered += filesConsidered;
                settings.TotalFilesCopied += filesCopied;
                settings.TotalFilesMoved += filesMoved;
                settings.TotalFilesDeleted += filesDeleted;
                settings.TotalFilesSkipped += filesSkipped;
                settings.TotalFilesFailed += filesFailed;

                // Bytes
                settings.TotalBytesProcessed += bytesProcessed;
                settings.TotalBytesToProcess += bytesToProcess;

                // Time (store as seconds)
                settings.TotalElapsedTimeSeconds += elapsedTime.TotalSeconds;
                settings.TotalTargetTimeSeconds += targetTime.TotalSeconds;

                settings.Save();
            }

            /// <summary>
            /// Loads saved totals from application settings and populates the corresponding UI labels.
            /// Optionally updates the enabled state of a reset button based on whether totals exist.
            /// </summary>
            /// <param name="totalCopyOperationsLabel">Label for total copy operations count</param>
            /// <param name="totalMoveOperationsLabel">Label for total move operations count</param>
            /// <param name="totalDeleteOperationsLabel">Label for total delete operations count</param>
            /// <param name="totalCancelledOperationsLabel">Label for total cancelled operations count</param>
            /// <param name="totalCompletedOperationsLabel">Label for total completed operations count</param>
            /// <param name="totalFilesConsideredLabel">Label for total files considered count</param>
            /// <param name="totalFilesCopiedLabel">Label for total files copied count</param>
            /// <param name="totalFilesMovedLabel">Label for total files moved count</param>
            /// <param name="totalFilesDeletedLabel">Label for total files deleted count</param>
            /// <param name="totalFilesSkippedLabel">Label for total files skipped count</param>
            /// <param name="totalFilesFailedLabel">Label for total files failed count</param>
            /// <param name="totalBytesProcessedLabel">Label for total bytes processed</param>
            /// <param name="totalBytesToProcessLabel">Label for total bytes to process</param>
            /// <param name="totalElapsedTimeLabel">Label for total elapsed time</param>
            /// <param name="totalTargetTimeLabel">Label for total target time</param>
            /// <param name="resetTotalsButton">Optional reset button to enable/disable based on totals existence</param>
            public static void LoadTotalsIntoLabels(
                Label totalCopyOperationsLabel, Label totalMoveOperationsLabel, Label totalDeleteOperationsLabel,
                Label totalCancelledOperationsLabel, Label totalCompletedOperationsLabel,
                Label totalFilesConsideredLabel, Label totalFilesCopiedLabel, Label totalFilesMovedLabel,
                Label totalFilesDeletedLabel, Label totalFilesSkippedLabel, Label totalFilesFailedLabel,
                Label totalBytesProcessedLabel, Label totalBytesToProcessLabel,
                Label totalElapsedTimeLabel, Label totalTargetTimeLabel,
                Button resetTotalsButton = null) // Add optional parameter for reset button
            {
                var settings = Properties.Settings.Default;

                // Operations
                totalCopyOperationsLabel.Text = $"{settings.TotalCopyOperations:N0}";
                totalMoveOperationsLabel.Text = $"{settings.TotalMoveOperations:N0}";
                totalDeleteOperationsLabel.Text = $"{settings.TotalDeleteOperations:N0}";
                totalCancelledOperationsLabel.Text = $"{settings.TotalCancelledOperations:N0}";
                totalCompletedOperationsLabel.Text = $"{settings.TotalCompletedOperations:N0}";

                // Files
                totalFilesConsideredLabel.Text = $"{settings.TotalFilesConsidered:N0}";
                totalFilesCopiedLabel.Text = $"{settings.TotalFilesCopied:N0}";
                totalFilesMovedLabel.Text = $"{settings.TotalFilesMoved:N0}";
                totalFilesDeletedLabel.Text = $"{settings.TotalFilesDeleted:N0}";
                totalFilesSkippedLabel.Text = $"{settings.TotalFilesSkipped:N0}";
                totalFilesFailedLabel.Text = $"{settings.TotalFilesFailed:N0}";

                // Bytes
                totalBytesProcessedLabel.Text = FormatBytes(settings.TotalBytesProcessed);
                totalBytesToProcessLabel.Text = FormatBytes(settings.TotalBytesToProcess);

                // Time
                TimeSpan elapsed = TimeSpan.FromSeconds(settings.TotalElapsedTimeSeconds);
                TimeSpan target = TimeSpan.FromSeconds(settings.TotalTargetTimeSeconds);

                totalElapsedTimeLabel.Text = FormatTimeWithDaysAndYears(elapsed);
                totalTargetTimeLabel.Text = FormatTimeWithDaysAndYears(target);

                // Update reset button state if provided
                if (resetTotalsButton != null)
                {
                    resetTotalsButton.Enabled = HasAnyTotals();
                }
            }

            /// <summary>
            /// Resets all operation totals to zero in application settings and updates the corresponding UI labels.
            /// Optionally updates the enabled state of a reset button.
            /// </summary>
            /// <param name="totalCopyOperationsLabel">Label for total copy operations count</param>
            /// <param name="totalMoveOperationsLabel">Label for total move operations count</param>
            /// <param name="totalDeleteOperationsLabel">Label for total delete operations count</param>
            /// <param name="totalCancelledOperationsLabel">Label for total cancelled operations count</param>
            /// <param name="totalCompletedOperationsLabel">Label for total completed operations count</param>
            /// <param name="totalFilesConsideredLabel">Label for total files considered count</param>
            /// <param name="totalFilesCopiedLabel">Label for total files copied count</param>
            /// <param name="totalFilesMovedLabel">Label for total files moved count</param>
            /// <param name="totalFilesDeletedLabel">Label for total files deleted count</param>
            /// <param name="totalFilesSkippedLabel">Label for total files skipped count</param>
            /// <param name="totalFilesFailedLabel">Label for total files failed count</param>
            /// <param name="totalBytesProcessedLabel">Label for total bytes processed</param>
            /// <param name="totalBytesToProcessLabel">Label for total bytes to process</param>
            /// <param name="totalElapsedTimeLabel">Label for total elapsed time</param>
            /// <param name="totalTargetTimeLabel">Label for total target time</param>
            /// <param name="resetTotalsButton">Optional reset button to disable after reset</param>
            public static void ResetTotals(
                Label totalCopyOperationsLabel, Label totalMoveOperationsLabel, Label totalDeleteOperationsLabel,
                Label totalCancelledOperationsLabel, Label totalCompletedOperationsLabel,
                Label totalFilesConsideredLabel, Label totalFilesCopiedLabel, Label totalFilesMovedLabel,
                Label totalFilesDeletedLabel, Label totalFilesSkippedLabel, Label totalFilesFailedLabel,
                Label totalBytesProcessedLabel, Label totalBytesToProcessLabel,
                Label totalElapsedTimeLabel, Label totalTargetTimeLabel,
                Button resetTotalsButton = null) // Add optional parameter for reset button
            {
                var settings = Properties.Settings.Default;

                // Reset values
                settings.TotalCopyOperations = 0;
                settings.TotalMoveOperations = 0;
                settings.TotalDeleteOperations = 0;
                settings.TotalCancelledOperations = 0;
                settings.TotalCompletedOperations = 0;

                settings.TotalFilesConsidered = 0;
                settings.TotalFilesCopied = 0;
                settings.TotalFilesMoved = 0;
                settings.TotalFilesDeleted = 0;
                settings.TotalFilesSkipped = 0;
                settings.TotalFilesFailed = 0;

                settings.TotalBytesProcessed = 0;
                settings.TotalBytesToProcess = 0;

                settings.TotalElapsedTimeSeconds = 0;
                settings.TotalTargetTimeSeconds = 0;

                settings.Save();

                // Immediately refresh labels and button state
                LoadTotalsIntoLabels(
                    totalCopyOperationsLabel, totalMoveOperationsLabel, totalDeleteOperationsLabel,
                    totalCancelledOperationsLabel, totalCompletedOperationsLabel,
                    totalFilesConsideredLabel, totalFilesCopiedLabel, totalFilesMovedLabel,
                    totalFilesDeletedLabel, totalFilesSkippedLabel, totalFilesFailedLabel,
                    totalBytesProcessedLabel, totalBytesToProcessLabel,
                    totalElapsedTimeLabel, totalTargetTimeLabel,
                    resetTotalsButton // Pass the button to update its state
                );
            }
        }
        void PlayRes(System.IO.Stream wavStream)   // accept any Stream
        {
            if (wavStream == null) return;
            try
            {
                using var ms = new System.IO.MemoryStream();
                wavStream.CopyTo(ms);          // copy resource stream
                ms.Position = 0;
                using var sp = new System.Media.SoundPlayer(ms);
                sp.Play();
            }
            catch { }
        }
        private void _copyWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs isCancelled)
        {
            bool isMultiThreaded = multithreadCheckBox.Checked;

            UpdateRunningTotals(FileOperation.Copy, _isCanceled);

            TotalsManager.SaveTotals(
                _totalCopyOps, _totalMoveOps, _totalDeleteOps, _totalCancelledOps, _totalCompletedOps,
                _grandFilesConsidered, _grandFilesCopied, _grandFilesMoved, _grandFilesDeleted, _grandFilesSkipped, _grandFilesFailed,
                _grandBytesProcessed, _grandBytesToProcess,
                _grandElapsedTime, _grandTargetTime
            );

            TotalsManager.LoadTotalsIntoLabels(
                totalCopyOperationsLabel, totalMoveOperationsLabel, totalDeleteOperationsLabel,
                totalCancelledOperationsLabel, totalCompletedOperationsLabel,
                totalFilesConsideredLabel, totalFilesCopiedLabel, totalFilesMovedLabel,
                totalFilesDeletedLabel, totalFilesSkippedLabel, totalFilesFailedLabel,
                totalBytesProcessedLabel, totalBytesToProcessLabel,
                totalElapsedTimeLabel, totalTargetTimeLabel,
                resetTotalsButton
            );

            allowTabChanges = true;

            if (_skippedFilesList.Any())
            {
                if (InvokeRequired)
                    Invoke(new Action(() => tabControl1.SelectedIndex = 2));
                else
                    tabControl1.SelectedIndex = 2;
            }

            Invoke((Delegate)(() =>
            {
                fileProgressBar.Value = 0;
                totalProgressBar.Value = 0;
                totalProgressBar.Text = "0.00%";
                fileProgressBar.Text = "0.00%";
                fileProgressBar.Value = fileProgressBar.Minimum;
                totalProgressBar.Value = totalProgressBar.Minimum;

                if (isMultiThreaded)
                {
                    progressBarMultiThreadTotal.Value = 0;
                    progressBarMultiThreadTotal.Text = "0.00%";
                }
            }));

          

            if (isCancelled.Error != null)        
            {
                status = "Error";
                _stopwatch.Stop();
                _updateTimer.Stop();
                elapsedAndTargetTimeLabel.Text = $"Elapsed / Target Time: 00:00:00 / 00:00:00";
                MessageBox.Show($"Copy operation completed with errors: {isCancelled.Error.Message}", "Copy Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LogError($"Copy Worker Error: {isCancelled.Error}");
                if (onErrorCheckBox.Checked) PlayRes(Properties.Resources.OnError);
                Invoke(() => { ShowOperationStatisticsSummary(isMultiThreaded); ResetProgressUIAndVariables(); });
            }
            else if (isCancelled.Cancelled)      
            {
                status = "Cancelled";
                _stopwatch.Stop();
                _updateTimer.Stop();
                elapsedAndTargetTimeLabel.Text = $"Elapsed / Target Time: 00:00:00 / 00:00:00";
                MessageBox.Show("Copy operation cancelled by user.", "Operation Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                if (onCancelCheckBox.Checked) PlayRes(Properties.Resources.OnCancel);
                ShowOperationStatisticsSummary(isMultiThreaded);
                ResetProgressUIAndVariables();
            }
            else                                  
            {
                status = "Completed";
                if (onFinishCheckBox.Checked) PlayRes(Properties.Resources.OnFinish);
                Invoke((Delegate)(() =>
                {
                    fileProgressBar.Value = 0;
                    totalProgressBar.Value = 0;
                    totalProgressBar.Text = "0.00%";
                    fileProgressBar.Text = "0.00%";
                    fileProgressBar.Value = fileProgressBar.Minimum;
                    totalProgressBar.Value = totalProgressBar.Minimum;

                    if (isMultiThreaded)
                    {
                        progressBarMultiThreadTotal.Value = 0;
                        progressBarMultiThreadTotal.Text = "0.00%";
                    }
                }));
                Invoke(() => { ShowOperationStatisticsSummary(isMultiThreaded); ResetProgressUIAndVariables(); });
                _stopwatch.Stop();
                _updateTimer.Stop();
                elapsedAndTargetTimeLabel.Text = $"Elapsed / Target Time: 00:00:00 / 00:00:00";
            }

            UpdateDriveSpaceInfo();

            using (var ms = new System.IO.MemoryStream(Properties.Resources.CopyThatIcon))
            {
                this.Icon = new System.Drawing.Icon(ms);
            }

            _operationTimer?.Stop();
            _pauseEvent.Set();

            if (proVersion)
            {
                if (minimizeSystemTrayCheckBox.Checked)
                    notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc || Double-Click To Open";
                else
                    notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc";
            }
            else
            {
                if (minimizeSystemTrayCheckBox.Checked)
                    notifyIcon1.Text = "Copy That v1.0 By: Havoc || Double-Click To Open";
                else
                    notifyIcon1.Text = "Copy That v1.0 By: Havoc";
            }

            Invoke((Delegate)(() =>
            {
                fileProgressBar.Value = 0;
                totalProgressBar.Value = 0;
                totalProgressBar.Text = "0.00%";
                fileProgressBar.Text = "0.00%";
                fileProgressBar.Value = fileProgressBar.Minimum;
                totalProgressBar.Value = totalProgressBar.Minimum;
            }));

            pauseResumeMultiButton.Text = "Pause";

            startButton.Enabled = true;
            pauseResumeMultiButton.Enabled = false;
            cancelMultiButton.Enabled = false;

            totalProgressBar.Text = "0.00%";
            fileProgressBar.Text = "0.00%";

            totalProgressBar.Value = 0;
            fileProgressBar.Value = 0;

            fileProcessedLabel.Text = $"File Processed: 0 Bytes / 0 Bytes";
            totalCopiedProgressLabel.Text = $"Total C/M/D: 0 Bytes / 0 Bytes";
            speedLabel.Text = "Speed: N/A";

            _totalBytesProcessed = 0;
            _totalBytesToProcess = 0;

            _cancellationTokenSource?.Dispose();
            _cancellationTokenSource = null;

            cancelButton.Enabled = false;
            pauseResumeButton.Enabled = false;
            skipButton.Enabled = false;

            copyMoveDeleteComboBox.Enabled = true;
            addFileButton.Enabled = true;
            removeFileButton.Enabled = true;
            clearFileListButton.Enabled = true;
            sourceDirectoryLabel.Enabled = true;
            targetDirectoryLabel.Enabled = true;
            moveFileUpLabel.Enabled = true;
            moveFileDownLabel.Enabled = true;
            moveToTopLabel.Enabled = true;
            moveToBottomLabel.Enabled = true;
            exitLabel.Enabled = true;
            minimizeLabel.Enabled = true;
            rollDownLabel.Enabled = true;
            rollUpLabel.Enabled = true;
            settingsLabel.Enabled = true;
            allAboutLabel.Enabled = true;
            overwriteAllCheckBox.Enabled = true;
            doNotOverwriteCheckBox.Enabled = true;
            overwriteIfNewerCheckBox.Enabled = true;
            keepDirStructCheckBox.Enabled = true;
            leaveEmptyFoldersCheckBox.Enabled = true;
            keepOnlyFilesCheckBox.Enabled = true;
            copyFilesDirsCheckBox.Enabled = true;
            createCustomDirCheckBox.Enabled = true;

            ResetProgressUIAndVariables();
            _updateTimer.Stop();

            UpdateDriveSpaceInfo();

            ShowAllTabs();
        }

        /// <summary>
        /// Toggles the enabled state of UI controls based on whether an operation is in progress.
        /// Disables controls during an active operation and re-enables them when operations are stopped.
        /// </summary>
        /// <param name="enabled">True to enable controls (no operation in progress), false to disable controls (operation in progress)</param>
        private void ToggleControlsForOperation(bool enabled)
        {
            // If not on the UI thread, invokes a delegate to run this method on the UI thread.
            if (InvokeRequired)
            {
                Invoke(new Action(() => ToggleControlsForOperation(enabled)));
                return;
            }

            // Sets the enabled state of various buttons based on the 'enabled' parameter.
            startButton.Enabled = enabled;
            pauseResumeButton.Enabled = !enabled;
            cancelButton.Enabled = !enabled;
            addFileButton.Enabled = enabled;
            removeFileButton.Enabled = enabled;
            clearFileListButton.Enabled = enabled;
            sourceDirectoryLabel.Enabled = enabled;
            targetDirectoryLabel.Enabled = enabled;
            moveFileUpLabel.Enabled = enabled;
            moveFileDownLabel.Enabled = enabled;
            moveToTopLabel.Enabled = enabled;
            moveToBottomLabel.Enabled = enabled;
            exitLabel.Enabled = enabled;
            minimizeLabel.Enabled = enabled;
            rollDownLabel.Enabled = enabled;
            rollUpLabel.Enabled = enabled;
            settingsLabel.Enabled = enabled;
            allAboutLabel.Enabled = enabled;

            // Sets the enabled state of various checkboxes.
            overwriteAllCheckBox.Enabled = enabled;
            doNotOverwriteCheckBox.Enabled = enabled;
            overwriteIfNewerCheckBox.Enabled = enabled;
            keepDirStructCheckBox.Enabled = enabled;
            leaveEmptyFoldersCheckBox.Enabled = enabled;
            keepOnlyFilesCheckBox.Enabled = enabled;
            copyFilesDirsCheckBox.Enabled = enabled;
            createCustomDirCheckBox.Enabled = enabled;
        }

        /// <summary>
        /// Computes the destination path for a file or directory based on various copy mode flags
        /// and directory structure preferences.
        /// </summary>
        /// <param name="sourcePath">The full path of the source file or directory</param>
        /// <param name="isDirectory">True if the source path is a directory, false if it's a file</param>
        /// <param name="targetBase">The base target directory where items should be copied</param>
        /// <param name="sourceRoot">The root source directory used for calculating relative paths</param>
        /// <returns>The computed destination path, or null if the item should be skipped</returns>
        private string ComputeDestinationPath(string sourcePath, bool isDirectory, string targetBase, string sourceRoot)
        {
            if (string.IsNullOrEmpty(sourcePath) || string.IsNullOrEmpty(targetBase) || string.IsNullOrEmpty(sourceRoot))
                return null;

            string destinationPath;

            if (_keepDirectoryStructure)
            {
                // Keep full directory structure - include the parent directory name
                string sourceRootName = System.IO.Path.GetFileName(sourceRoot.TrimEnd(System.IO.Path.DirectorySeparatorChar));

                // Create relative path including the source root directory name
                string relativePath = sourcePath.Substring(sourceRoot.Length);
                if (!string.IsNullOrEmpty(relativePath))
                {
                    // Include the source root name in the path
                    relativePath = System.IO.Path.Combine(sourceRootName, relativePath.TrimStart(System.IO.Path.DirectorySeparatorChar));
                }
                else
                {
                    // This is the source root directory itself
                    relativePath = sourceRootName;
                }

                destinationPath = System.IO.Path.Combine(targetBase, relativePath);
            }
            else if (_copyFilesOnly)
            {
                // Copy Files Only - copy everything inside top folder but not the top folder itself
                if (isDirectory)
                {
                    // For directories, remove the top level directory from the path
                    string relativePath = sourcePath.Substring(sourceRoot.Length);
                    string[] pathParts = relativePath.TrimStart(System.IO.Path.DirectorySeparatorChar).Split(System.IO.Path.DirectorySeparatorChar);
                    if (pathParts.Length > 1)
                    {
                        // This is a subdirectory, include it
                        string subPath = string.Join(System.IO.Path.DirectorySeparatorChar.ToString(), pathParts, 1, pathParts.Length - 1);
                        destinationPath = System.IO.Path.Combine(targetBase, subPath);
                    }
                    else
                    {
                        // This is the top directory itself, skip it
                        return null;
                    }
                }
                else
                {
                    // For files, place them directly in target base (no subfolders)
                    destinationPath = System.IO.Path.Combine(targetBase, System.IO.Path.GetFileName(sourcePath));
                }
            }
            else if (_keepEmptyFolders)
            {
                // Keep Empty Folders Only - copy directory structure but only empty folders
                if (isDirectory)
                {
                    // Check if directory is empty
                    bool isEmpty = !Directory.EnumerateFileSystemEntries(sourcePath).Any();
                    if (isEmpty)
                    {
                        string relativePath = sourcePath.Substring(sourceRoot.Length);
                        destinationPath = System.IO.Path.Combine(targetBase, relativePath.TrimStart(System.IO.Path.DirectorySeparatorChar));
                    }
                    else
                    {
                        return null; // Skip non-empty directories
                    }
                }
                else
                {
                    return null; // Skip all files
                }
            }
            else if (_keepOnlyFiles)
            {
                // Keep Only Files - copy only files, no directory structure
                if (!isDirectory)
                {
                    // Files go directly to target base with their original names
                    string fileName = System.IO.Path.GetFileName(sourcePath);
                    destinationPath = System.IO.Path.Combine(targetBase, fileName);
                    // Check for duplicates and rename if necessary
                    if (File.Exists(destinationPath) || Directory.Exists(destinationPath))
                    {
                        string nameWithoutExt = System.IO.Path.GetFileNameWithoutExtension(fileName);
                        string extension = System.IO.Path.GetExtension(fileName);
                        int counter = 1;
                        do
                        {
                            string newFileName = $"{nameWithoutExt} ({counter}){extension}";
                            destinationPath = System.IO.Path.Combine(targetBase, newFileName);
                            counter++;
                        } while (File.Exists(destinationPath) || Directory.Exists(destinationPath));
                    }
                }
                else
                {
                    return null; // Skip all directories
                }
            }
            else
            {
                // Default behavior - flat copy to target base
                destinationPath = System.IO.Path.Combine(targetBase, System.IO.Path.GetFileName(sourcePath));
            }

            return destinationPath;
        }

        /// <summary>
        /// Creates the directory structure in the target location based on the computed destination paths
        /// for all directories and files that will be copied.
        /// </summary>
        /// <param name="targetBase">The base target directory</param>
        /// <param name="sourceRoot">The root source directory</param>
        /// <param name="dirs">List of directory items to process</param>
        /// <param name="files">List of file items to process</param>
        private void CreateDirectoryStructure(string targetBase, string sourceRoot, List<FileItem> dirs, List<FileItem> files)
        {
            var allDirectories = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            // Add target base first
            allDirectories.Add(targetBase);

            // Process directories
            foreach (var dir in dirs)
            {
                string destPath = ComputeDestinationPath(dir.FilePath, true, targetBase, sourceRoot);
                if (!string.IsNullOrEmpty(destPath))
                {
                    AddDirectoryAndParents(allDirectories, destPath, targetBase);
                }
            }

            // Process files
            foreach (var file in files)
            {
                string destPath = ComputeDestinationPath(file.FilePath, false, targetBase, sourceRoot);
                if (!string.IsNullOrEmpty(destPath))
                {
                    string parentDir = System.IO.Path.GetDirectoryName(destPath);
                    if (!string.IsNullOrEmpty(parentDir))
                    {
                        AddDirectoryAndParents(allDirectories, parentDir, targetBase);
                    }
                }
            }

            // Create directories in order (deepest first)
            var sortedDirs = allDirectories.OrderByDescending(d => d.Count(c => c == '\\' || c == '/')).ToList();
            foreach (var dir in sortedDirs)
            {
                if (!Directory.Exists(dir))
                {
                    Directory.CreateDirectory(dir);
                }
            }
        }

        /// <summary>
        /// Recursively adds a directory and all its parent directories to the hash set,
        /// ensuring all necessary directory paths are included for creation.
        /// </summary>
        /// <param name="directories">Hash set containing all directories to be created</param>
        /// <param name="path">The directory path to add</param>
        /// <param name="targetBase">The base target directory to stop recursion</param>
        private void AddDirectoryAndParents(HashSet<string> directories, string path, string targetBase)
        {
            string current = path;
            while (!string.IsNullOrEmpty(current) &&
                   current.StartsWith(targetBase, StringComparison.OrdinalIgnoreCase) &&
                   current != targetBase)
            {
                directories.Add(current);
                current = System.IO.Path.GetDirectoryName(current);
            }
            directories.Add(targetBase);
        }



        /// <summary>
        /// Gets the progress bar control for the specified slot index.
        /// </summary>
        /// <param name="index">The slot index (0-3)</param>
        /// <returns>The corresponding ModernCircularProgressBar control</returns>
        private ModernCircularProgressBar GetProgressBar(int index) => index switch
        {
            // Returns the correct progress bar based on the index.
            0 => progressBarMutli1,
            1 => progressBarMutli2,
            2 => progressBarMutli3,
            3 => progressBarMutli4,
            // Throws an exception for an out-of-range index.
            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// Gets the file name label control for the specified slot index.
        /// </summary>
        /// <param name="index">The slot index (0-3)</param>
        /// <returns>The corresponding Label control</returns>
        private Label GetFileNameLabel(int index) => index switch
        {
            // Returns the correct label based on the index.
            0 => filesNameLabel1,
            1 => filesNameLabel2,
            2 => filesNameLabel3,
            3 => filesNameLabel4,
            // Throws an exception for an out-of-range index.
            _ => throw new ArgumentOutOfRangeException()
        };

        /// <summary>
        /// Gets the destination path for a file item, optionally incorporating a custom directory name.
        /// </summary>
        /// <param name="item">The file item wrapper</param>
        /// <param name="targetBaseDirectory">The base target directory</param>
        /// <returns>The computed destination path including custom directory if specified</returns>
        private string GetDestinationPath(FileInfoWrapper item, string targetBaseDirectory)
        {
            // Checks if the user wants to create a custom directory.
            if (_createCustomDirectory && !string.IsNullOrWhiteSpace(_customDirectoryName))
                // Combines the target base with the custom directory name.
                targetBaseDirectory = System.IO.Path.Combine(targetBaseDirectory, _customDirectoryName);

            // Returns the final target directory path.
            return GetTargetDirectory(item.FilePath,
                                      targetBaseDirectory,
                                      item.IsDirectory,
                                      item.SourceRoot ?? _currentSourceRootPath);
        }

        /// <summary>
        /// Reports file copy progress to the UI, updating the progress bar and file name display.
        /// </summary>
        /// <param name="fileProgress10k">Progress value in hundredths of a percent (0-10000)</param>
        /// <param name="fileName">The name of the file being processed</param>
        private void ReportFileProgress(int fileProgress10k, string fileName)
        {
            // Checks if an Invoke is required to run on the UI thread.
            if (InvokeRequired) { Invoke(new Action(() => ReportFileProgress(fileProgress10k, fileName))); return; }

            fileProgressBar.Value = Math.Min(fileProgress10k, fileProgressBar.Maximum);
            // Updates the file path label with the file name.
            filePathLabel.Text = fileName;
            fileProgressBar.Text = $"{(fileProgress10k / 100.0):F2}%";
        }




        /// <summary>
        /// Securely deletes a file by overwriting its contents with random data for a specified number of passes before final deletion.
        /// </summary>
        /// <param name="filePath">The path of the file to be securely deleted.</param>
        private void SecureDeleteFile(string filePath)
        {
            // Checks if the file exists at the given path.
            if (!File.Exists(filePath))
                return; // If it doesn't exist, exit the method.

            // Creates a FileInfo object to get information about the file.
            FileInfo fileInfo = new FileInfo(filePath);
            // Gets the size of the file in bytes.
            long fileSize = fileInfo.Length;
            // Gets the number of overwrite passes from a numeric up-down control.
            int overwritePasses = (int)securePassesNumUpDown.Value;

            // Opens the file for writing in a FileStream, ensuring it's closed properly.
            using (FileStream stream = new FileStream(filePath, FileMode.Open, FileAccess.Write))
            {
                // Creates a buffer to hold data for overwriting.
                byte[] buffer = new byte[bufferSize];
                // Initializes a Random object to generate random data.
                Random random = new Random();

                // Loop for the specified number of overwrite passes.
                for (int pass = 0; pass < overwritePasses; pass++)
                {
                    // Moves the stream's position to the beginning of the file for each pass.
                    stream.Seek(0, SeekOrigin.Begin);
                    // Initializes a counter for the number of bytes written in the current pass.
                    long bytesWritten = 0;

                    // Loops until the entire file is overwritten.
                    while (bytesWritten < fileSize)
                    {
                        // Checks for a pause signal without blocking.
                        if (!_pauseEvent.WaitOne(0))
                        {
                            // If a pause is not requested, check for cancellation.
                            _cancellationTokenSource.Token.ThrowIfCancellationRequested();
                        }
                        // Checks if cancellation has been requested.
                        if (_cancellationTokenSource?.IsCancellationRequested == true)
                            return; // If so, exit the method.

                        // Determines the number of bytes to write in the current chunk.
                        int bytesToWrite = (int)Math.Min(bufferSize, fileSize - bytesWritten);
                        // Fills the buffer with random bytes.
                        random.NextBytes(buffer);
                        // Writes the buffer to the file.
                        stream.Write(buffer, 0, bytesToWrite);
                        // Updates the count of bytes written.
                        bytesWritten += bytesToWrite;

                        // Adds the number of bytes written to a total processed counter.
                        _totalBytesProcessed += bytesToWrite;
                    }

                    // Flushes the stream buffer to ensure all data is written to the file system.
                    stream.Flush();
                }
            }

            // After overwriting, deletes the file from the disk.
            File.Delete(filePath);
        }

        /// <summary>
        /// Ensures that the directory for a given file path exists, creating it if it does not.
        /// </summary>
        /// <param name="destinationFile">The full path of the file for which the directory should be created.</param>
        private static void EnsureDirectoryExistsForFile(string destinationFile)
        {
            // Gets the directory path from the full file path.
            string dir = System.IO.Path.GetDirectoryName(destinationFile);
            // Checks if the directory path is null or whitespace.
            if (string.IsNullOrWhiteSpace(dir)) return;

            // Tries to create the directory.
            try
            {
                // Checks if the directory already exists.
                if (!Directory.Exists(dir))
                    Directory.CreateDirectory(dir); // Creates the directory if it doesn't exist.
            }
            catch (Exception ex)
            {
                // Catches any exceptions during directory creation.
                // Throws a new IOException with a custom error message and the original exception.
                throw new IOException(
                    $"Failed to create destination directory '{dir}' for file '{System.IO.Path.GetFileName(destinationFile)}'. Reason: {ex.Message}",
                    ex);
            }
        }

        /// <summary>
        /// Finds the zero-based index of a row in a DataGridView that corresponds to a specific file path.
        /// </summary>
        /// <param name="grid">The DataGridView to search.</param>
        /// <param name="filePath">The file path to find.</param>
        /// <returns>The row index if a match is found; otherwise, -1.</returns>
        private int FindRowIndexForFile(DataGridView grid, string filePath)
        {
            // Iterates through each row in the DataGridView.
            foreach (DataGridViewRow row in grid.Rows)
            {
                // Checks if the "FilePath" cell value is not null.
                if (row.Cells["FilePath"].Value != null &&
                    // Compares the file path in the cell with the provided file path, ignoring case.
                    string.Equals(row.Cells["FilePath"].Value.ToString(), filePath, StringComparison.OrdinalIgnoreCase))
                {
                    return row.Index; // Returns the index of the row if a match is found.
                }
            }
            return -1; // Returns -1 if no matching row is found.
        }

        /// <summary>
        /// Logs an error message to the debug console.
        /// </summary>
        /// <param name="message">The error message to log.</param>
        private void LogError(string message)
        {
            // Writes an error message to the debug output.
            Debug.WriteLine("[ERROR] " + message);
        }

        /// <summary>
        /// Logs a warning message to the debug console.
        /// </summary>
        /// <param name="message">The warning message to log.</param>
        private void LogWarning(string message)
        {
            // Writes a warning message to the debug output.
            Debug.WriteLine("[WARN] " + message);
        }

        /// <summary>
        /// Sets the file name text for a specific thread's UI label.
        /// </summary>
        /// <param name="index">The 0-based index of the thread.</param>
        /// <param name="name">The file name to display.</param>
        private void SetThreadFileNameLabel(int index, string name)
        {
            // Uses a switch statement to update the text of a specific file name label based on the thread index.
            switch (index)
            {
                case 0: filesNameLabel1.Text = name; break;
                case 1: filesNameLabel2.Text = name; break;
                case 2: filesNameLabel3.Text = name; break;
                case 3: filesNameLabel4.Text = name; break;
            }
        }

        /// <summary>
        /// Sets the progress text for a specific thread's UI label.
        /// </summary>
        /// <param name="index">The 0-based index of the thread.</param>
        /// <param name="text">The progress text to display.</param>
        private void SetThreadProgressLabel(int index, string text)
        {
            // Uses a switch statement to update the text of a specific progress label based on the thread index.
            switch (index)
            {
                //case 0: totalPCTMultiLabel1.Text = text; break;
                //case 1: totalPCTMultiLabel2.Text = text; break;
                //case 2: totalPCTMultiLabel3.Text = text; break;
                //case 3: totalPCTMultiLabel4.Text = text; break;
            }
        }

        /// <summary>
        /// Sets the value for a specific thread's UI progress bar.
        /// </summary>
        /// <param name="index">The 0-based index of the thread.</param>
        /// <param name="value">The value to set the progress bar to.</param>
        private void SetThreadProgressBar(int index, int value)
        {
            // Uses a switch statement to update the value of a specific progress bar based on the thread index.
            switch (index)
            {
                case 0: progressBarMutli1.Value = value; break;
                case 1: progressBarMutli2.Value = value; break;
                case 2: progressBarMutli3.Value = value; break;
                case 3: progressBarMutli4.Value = value; break;
            }
        }

        /// <summary>
        /// Updates the overall UI elements for a multi-threaded operation, including progress bar, speed, and time labels.
        /// </summary>
        private void UpdateOverallMultiThreadProgressUI()
        {
            // Returns if the total bytes to process are zero or less.
            if (_totalBytesToProcess <= 0) return;

            // Reads the total bytes processed in a thread-safe manner.
            long processedBytes = Interlocked.Read(ref _totalBytesProcessed);
            // Calculates the percentage of completion.
            double percent = (double)processedBytes / _totalBytesToProcess * 100;

            // Updates a label with the formatted percentage.
            //multiThreadTotalProgressLabel.Text = $"{percent:F2}%";

            // Calculates the progress bar value scaled to 10000.
            int progressBarValue = (int)(percent * 100);
            // Clamps the progress bar value to be within the valid range of 0 to 10000.
            progressBarValue = Math.Max(0, Math.Min(progressBarValue, 10000));

            // Updates the progress bar value, with a check to avoid exceptions.
            try
            {
                progressBarMultiThreadTotal.Value = progressBarValue;
            }
            catch
            {
                // If an exception occurs, checks the value and updates again.
                if (progressBarMultiThreadTotal.Value != progressBarValue)
                {
                    progressBarMultiThreadTotal.Value = progressBarValue;
                }
            }

            // Updates the label showing total bytes copied/moved/deleted.
            totalCMDMultiLabel.Text = $"Total C/M/D: {FormatBytes(processedBytes)} / {FormatBytes(_totalBytesToProcess)}";


            // Calls a method to update drive space information.
            UpdateDriveSpaceInfo();

            double mbPerSec = 0;
            // Checks if the stopwatch has been started and has a positive elapsed time.
            if (_stopwatch != null && _stopwatch.Elapsed.TotalSeconds > 0)
            {
                // Calculates the speed in MB per second.
                mbPerSec = processedBytes / 1024d / 1024d / _stopwatch.Elapsed.TotalSeconds;
            }

            // Gets the elapsed time from the stopwatch.
            TimeSpan elapsed = _stopwatch.Elapsed;

            // Calculates the estimated total time for the operation.
            TimeSpan estTotal = TimeSpan.FromSeconds(_totalBytesToProcess / Math.Max(_totalBytesProcessed / Math.Max(elapsed.TotalSeconds, 0.1), 1));
            // Updates a label with the elapsed and estimated total time.
            totalTimeMultiLabel.Text = $"Elapsed / Target Time: {elapsed:hh\\:mm\\:ss} / {estTotal:hh\\:mm\\:ss}";
            // Updates a label with the calculated speed.
            speedMultiLabel.Text = $"Speed: {mbPerSec:F2} MB/sec";
        }

        /// <summary>
        /// Resets all UI components related to the multi-threaded operation to their initial state.
        /// </summary>
        private void ResetMultiThreadedUI()
        {
            // Resets the text of all file name labels to "Nothing".
            filesNameLabel1.Text = "Nothing";
            filesNameLabel2.Text = "Nothing";
            filesNameLabel3.Text = "Nothing";
            filesNameLabel4.Text = "Nothing";

            // Resets the text of all percentage labels to "0.00%".
            //totalPCTMultiLabel1.Text = "0.00%";
            //totalPCTMultiLabel2.Text = "0.00%";
            //totalPCTMultiLabel3.Text = "0.00%";
            //totalPCTMultiLabel4.Text = "0.00%";

            // Resets the value of all individual progress bars to 0.
            progressBarMutli1.Value = 0;
            progressBarMutli2.Value = 0;
            progressBarMutli3.Value = 0;
            progressBarMutli4.Value = 0;

            // Resets the overall progress bar and label.
            progressBarMultiThreadTotal.Value = 0;
            //multiThreadTotalProgressLabel.Text = "0.00%";
            // Resets the source directory label.
            fromFilesDirLabel.Text = "Current Source: None";
            // Resets all counters and stopwatch.
            _multiThreadProcessedFiles = 0;
            _totalBytesToProcess = 0;
            _stopwatch.Reset();
            // Resets all status labels to their initial values.
            fileCountMultiLabel.Text = "File Count: 0 Out of 0";
            totalTimeMultiLabel.Text = "Elapsed / Target Time: 00:00:00 / 00:00:00";
            totalCMDMultiLabel.Text = "Total C/M/D: 0 B / 0 B";
            totalSpaceMultiLabel.Text = "Total Space Used: 0 Bytes / 0 Bytes";
            speedMultiLabel.Text = "Speed: 0 MB/sec.";
        }

        /// <summary>
        /// Displays a message box showing a summary of statistics for the completed file operation.
        /// </summary>
        /// <param name="isMultiThreaded">Indicates if the summary is for a multi-threaded operation.</param>
        private void ShowOperationStatisticsSummary(bool isMultiThreaded)
        {
            // Gets the name of the current operation from a variable.
            string operationName = _currentOperation.ToString();
            // Sets the status based on whether the operation was cancelled.

            // Checks if the multi-threaded checkbox is checked and if the operation was multi-threaded.
            if (multithreadCheckBox.Checked && isMultiThreaded)
            {
                // Prepends "Multi-threaded" to the operation name.
                operationName = "Multi-threaded " + operationName;

                // Creates a message string summarizing the multi-threaded operation results.
                string message = $"- {operationName} Operation Summary ({status}) -\n\n" +
                                     $"Files Copied: {_totalFilesCopied}\n" +
                                     $"Files Skipped: {_totalFilesSkipped}\n" +
                                     $"Files Failed: {_totalFilesFailed}\n" +
                                     $"Total Files Processed: {_processedFiles} / {_grandTotalFileCount:N0}\n" +
                                     $"Total Bytes Processed: {FormatBytes(_totalBytesProcessed)} / {FormatBytes(_grandBytesToProcess)}";

                // Determines the message box icon based on the status.
                MessageBoxIcon icon = _isCanceled ? MessageBoxIcon.Warning : MessageBoxIcon.Information;

                // Displays a message box with the summary.
                MessageBox.Show(message, $"Operation {status}", MessageBoxButtons.OK, icon);

                // Sends an SMS notification with the summary.
                //smsForm.SendOperationSummaryNotification(message);
            }
            // Checks if the multi-threaded checkbox is not checked and the operation was single-threaded.
            else if (!multithreadCheckBox.Checked && !isMultiThreaded)
            {
                // Prepends "Single-threaded" to the operation name.
                operationName = "Single-threaded " + operationName;

                // Creates a message string summarizing the single-threaded operation results.
                string message = $"- {operationName} Operation Summary ({status}) -\n\n" +
                                                 $"Files Copied: {_totalFilesCopied}\n" +
                                                 $"Files Skipped: {_totalFilesSkipped}\n" +
                                                 $"Files Failed: {_totalFilesFailed}\n" +
                                                 $"Total Files Processed: {_processedFiles} / {_grandTotalFileCount:N0}\n" +
                                                 $"Total Bytes Processed: {FormatBytes(_totalBytesProcessed)} / {FormatBytes(_grandBytesToProcess)}";

                // Determines the message box icon based on the status.
                MessageBoxIcon icon = _isCanceled ? MessageBoxIcon.Warning : MessageBoxIcon.Information;

                // Displays a message box with the summary.
                MessageBox.Show(message, $"Operation {status}", MessageBoxButtons.OK, icon);

                // Sends an SMS notification with the summary.
                //smsForm.SendOperationSummaryNotification(message);
            }

        }

        /// <summary>
        /// Handles a file processing error by attempting a limited number of retries.
        /// If retries fail, the file is marked as skipped.
        /// </summary>
        /// <param name="filePath">The path of the file that failed to process.</param>
        /// <param name="ex">The exception that occurred.</param>
        /// <param name="fileIndex">The index of the failed file in the file list.</param>
        private void HandleFileError(string filePath, Exception ex, int fileIndex)
        {
            // Increments the retry count.
            _retryCount++;

            // Checks if the retry count is within the maximum limit.
            if (_retryCount <= MAX_RETRIES)
            {
                try
                {
                    // Pauses the thread for a short duration before retrying.
                    Thread.Sleep(12);
                    // Sets the current file index to retry.
                    _currentFileIndex = fileIndex;
                    return; // Exits the method to allow for a retry.
                }
                catch
                {
                    // Catches any exceptions from Thread.Sleep.
                }
            }

            // Gets the file name from the path.
            string fileName = System.IO.Path.GetFileName(filePath);
            // Gets the file size, or 0 if the file doesn't exist.
            long fileSizeRaw = File.Exists(filePath) ? new FileInfo(filePath).Length : 0;
            // Gets the reason for the error, prioritizing the inner exception message.
            string reason = ex.InnerException?.Message ?? ex.Message;


            // Constructs the intended destination path.
            string intendedDestination = System.IO.Path.Combine(_targetDirectories[0], fileName);
            // Adds the file to a list of skipped files with a reason.
            AddToSkippedFiles(
                "Skipped",                  // The general reason for the operation status
                fileName,                   // The name of the file
                fileSizeRaw,                // The raw size of the file (long)
                filePath,                   // The source path of the file
                intendedDestination,        // The intended destination path
                reason                      // The specific reason/error message provided
            );
            // Updates the status of the file in a UI component (likely a DataGridView).
            UpdateFileStatus(_fileList[fileIndex], "Skipped");

            // Resets the retry count after the file has been handled as skipped.
            _retryCount = 0;
        }
        public class SkippedFile
        {
            // Defines a public property for the file name.
            public string FileName { get; set; }
            // Defines a public property for the file size.
            public long FileSize { get; set; }
            // Defines a public property for the source file path.
            public string SourceFilePath { get; set; }
            // Defines a public property for the destination file path.
            public string DestinationFilePath { get; set; }
            // Defines a public property for the reason the file was skipped.
            public string Reason { get; set; }
        }
        /// <summary>
        /// Converts a file size in bytes into a human-readable string (e.g., "1.23 MB").
        /// </summary>
        /// <param name="bytes">The size in bytes to format.</param>
        /// <returns>A formatted string with the appropriate size unit (B, KB, MB, etc.).</returns>
        private string FormatFileSize(long bytes)
        {
            // An array of size units.
            string[] sizes = { "B", "KB", "MB", "GB", "TB" };
            // The length to be converted.
            double len = bytes;
            // The index for the size units.
            int order = 0;

            // Loops while the size is greater than or equal to 1024 and there are more units.
            while (len >= 1024 && order < sizes.Length - 1)
            {
                order++; // Increments the unit index.
                len = len / 1024; // Divides the size by 1024.
            }

            // Formats the size to two decimal places and appends the unit.
            return $"{len:0.##} {sizes[order]}";
        }

        /// <summary>
        /// Gathers current progress statistics and reports them to any active background worker.
        /// </summary>
        private void ReportProgress()
        {
            // Calculates the total progress percentage, or sets it to 0 if no files are being processed.
            int totalProgress = _grandTotalFileCount > 0 ? (int)Math.Round(((double)_processedFiles / _grandTotalFileCount) * 100.0) : 0;

            // Creates a new ProgressInfo object to hold progress details.
            var progressInfo = new ProgressInfo
            {
                TotalProgress = totalProgress,
                ProcessedFiles = _processedFiles,
                TotalFiles = _grandTotalFileCount,
                ProcessedBytes = _totalBytesProcessed,
                TotalBytes = _totalBytesToProcess
            };

            // Reports progress to the relevant background worker.
            _copyWorker?.ReportProgress(totalProgress, progressInfo);
            _moveWorker?.ReportProgress(totalProgress, progressInfo);
            _deleteWorker?.ReportProgress(totalProgress, progressInfo);
        }

        /// <summary>
        /// Selects a specified row in the files DataGridView, optionally scrolling it into view.
        /// This method is thread-safe.
        /// </summary>
        /// <param name="rowIndex">The zero-based index of the row to select.</param>
        private void SelectCurrentFileInGrid(int rowIndex)
        {
            // Invokes the method on the UI thread if necessary.
            if (InvokeRequired)
            {
                Invoke(new Action(() => SelectCurrentFileInGrid(rowIndex)));
                return;
            }

            // Returns if the row index is out of bounds.
            if (rowIndex < 0 || rowIndex >= filesDataGridView.RowCount)
                return;

            // Returns if auto-scrolling is not enabled.
            if (!autoScrollCheckBox.Checked)
            {
                // Just select without scrolling
                filesDataGridView.ClearSelection();
                filesDataGridView.Rows[rowIndex].Selected = true;
                return;
            }

            // Gets the first visible row index and the number of visible rows.
            int firstVisible = filesDataGridView.FirstDisplayedScrollingRowIndex;
            int visibleCount = filesDataGridView.DisplayedRowCount(true);
            int lastVisible = firstVisible + visibleCount - 1;

            // Check if the current row is not visible
            if (rowIndex > lastVisible)
            {
                // Scroll to make this row the first visible row
                filesDataGridView.FirstDisplayedScrollingRowIndex = rowIndex;
            }
            // If the row is before the first visible row, scroll to make it visible at top
            else if (rowIndex < firstVisible)
            {
                filesDataGridView.FirstDisplayedScrollingRowIndex = rowIndex;
            }

            // Clears any existing selection.
            filesDataGridView.ClearSelection();

            // Selects the row at the specified index.
            filesDataGridView.Rows[rowIndex].Selected = true;

            // Optional: Ensure the selected row is fully visible
            filesDataGridView.CurrentCell = filesDataGridView.Rows[rowIndex].Cells[0];

            _walkCounter++; // Increments a counter.
        }

        /// <summary>
        /// Updates the overall progress bar's value and text based on the total bytes processed.
        /// This method is thread-safe.
        /// </summary>
        private void UpdateOverallProgress()
        {
            // Invokes the method on the UI thread if necessary.
            if (InvokeRequired) { Invoke(new Action(UpdateOverallProgress)); return; }

            // Calculates the progress percentage scaled to 10000.
            int pct = _totalBytesToProcess > 0
                ? (int)Math.Round(_totalBytesProcessed / (double)_totalBytesToProcess * 10000)
                : 0;
            totalProgressBar.Value = Math.Min(pct, 10000);

            totalProgressBar.Text = $"{pct / 100.0:F2}%";
        }

        /// <summary>
        /// Updates various UI elements based on the data in a ProgressInfo object.
        /// This method is thread-safe.
        /// </summary>
        /// <param name="pi">An object containing the current progress details.</param>
        private void UpdateUI(ProgressInfo pi)
        {
            // Invokes the method on the UI thread if necessary.
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateUI(pi)));
                return;
            }

            totalProgressBar.Value = pi.TotalProgress;
            totalProgressBar.Refresh();

            totalProgressBar.Text = $"{(pi.TotalProgress / 100.0):F2}%";
            totalProgressBar.Refresh();
            // Sets the text of the file path label to the current file name.
            filePathLabel.Text = $"{pi.CurrentFileName}";
        }

        /// <summary>
        /// Updates the file count and total size labels on the UI.
        /// This method is thread-safe.
        /// </summary>
        private void UpdateFileCountLabels()
        {
            // Invokes the method on the UI thread if necessary.
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateFileCountLabels));
                return;
            }

            // Updates the file count label with processed and total file counts.
            fileCountOnLabel.Text = $"File Count: {_processedFiles:N0} Out of " + _grandTotalFileCount.ToString("N0") + "";
            // Updates the label for total bytes copied/moved/deleted.
            totalCopiedProgressLabel.Text = $"Total C/M/D: {FormatFileSize(_totalBytesProcessed)} / {FormatFileSize(_totalBytesToProcess)}";
        }

        /// <summary>
        /// Resets the progress bars on the user interface to zero.
        /// This method is thread-safe.
        /// </summary>
        private void UpdateProgressBars()
        {
            // Invokes the method on the UI thread if necessary.
            if (InvokeRequired)
            {
                Invoke(new Action(UpdateProgressBars));
                return;
            }

            // Resets both file and total progress bars to 0.

            fileProgressBar.Value = 0;
            totalProgressBar.Value = 0;
            fileProgressBar.Text = "0.00%";
            totalProgressBar.Text = "0.00%";
        }

        /// <summary>
        /// Initiates a background process to verify that source files match destination files.
        /// </summary>
        private void VerifyFiles()
        {
            // Creates a new BackgroundWorker to perform file verification in the background.
            BackgroundWorker verifyWorker = new BackgroundWorker();
            // Enables progress reporting for the worker.
            verifyWorker.WorkerReportsProgress = true;
            // Attaches a handler for the DoWork event.
            verifyWorker.DoWork += (s, e) =>
            {
                // Initializes a counter for verified files.
                int verifiedFiles = 0;
                // Gets the total number of files to verify.
                long totalFiles = _grandTotalFileCount;

                // Checks if a destination folder is selected.
                if (this.targetPaths == null || this.targetPaths.Count == 0)
                {
                    // Displays a message box if no destination is selected.
                    MessageBox.Show("No destination folder selected. Cannot verify files.", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    e.Cancel = true; // Cancels the operation.
                    return;
                }

                // Gets the first target directory.
                string targetRoot = this.targetPaths.First();

                // Iterates through each file in the list to verify.
                foreach (FileInfoWrapper sourceFileWrapper in _fileList)
                {
                    // Checks if a cancellation is pending.
                    if (verifyWorker.CancellationPending)
                    {
                        e.Cancel = true; // Sets the cancel flag.
                        break; // Exits the loop.
                    }

                    // Gets the source file path.
                    string sourceFile = sourceFileWrapper.FilePath;

                    // Determines the destination file path.
                    string destinationFile = GetTargetDirectory(sourceFile, targetRoot, sourceFileWrapper.IsDirectory, _currentSourceRootPath);

                    // Checks if the destination path could not be determined.
                    if (string.IsNullOrEmpty(destinationFile))
                    {
                        // Adds the file to the skipped list with a reason.
                        AddToSkippedFiles(
                            "Verification Skipped",
                            System.IO.Path.GetFileName(sourceFile),
                            sourceFileWrapper.BytesRaw,
                            sourceFile,
                            "N/A (empty target)",
                            "Destination path not determined"
                        );
                        continue; // Skips to the next file.
                    }

                    // Checks if the current item is a file (not a directory).
                    if (!sourceFileWrapper.IsDirectory)
                    {
                        // Checks if the destination file exists.
                        if (File.Exists(destinationFile))
                        {
                            // Verifies the integrity of the source and destination files.
                            if (VerifyFileIntegrity(sourceFile, destinationFile))
                            {
                                verifiedFiles++; // Increments the verified files counter.
                            }
                            else
                            {
                                // Adds the file to the skipped list if integrity check fails.
                                AddToSkippedFiles(
                                    "Verification Failed",
                                    System.IO.Path.GetFileName(sourceFile),
                                    new FileInfo(sourceFile).Length,
                                    sourceFile,
                                    destinationFile,
                                    "Integrity check failed"
                                );
                            }
                        }
                        else
                        {
                            // Adds the file to the skipped list if the destination file is not found.
                            AddToSkippedFiles(
                                "Verification Failed",
                                System.IO.Path.GetFileName(sourceFile),
                                sourceFileWrapper.BytesRaw,
                                sourceFile,
                                destinationFile,
                                "Destination file not found"
                            );
                        }
                    }
                    else
                    {
                        // Adds the directory to the skipped list with a reason.
                        AddToSkippedFiles(
                            "Verification Skipped",
                            System.IO.Path.GetFileName(sourceFile),
                            0,
                            sourceFile,
                            destinationFile,
                            "Is a Directory"
                        );
                    }


                    // Calculates the current progress.
                    int progress = (int)((verifiedFiles * 100.0) / _grandTotalFileCount);
                    // Reports the progress to the UI thread.
                    verifyWorker.ReportProgress(progress);
                }
            };

            // Attaches a handler for the ProgressChanged event.
            verifyWorker.ProgressChanged += (s, e) =>
            {
                // This is where you would update the UI with progress, if needed.
            };

            // Attaches a handler for the RunWorkerCompleted event.
            verifyWorker.RunWorkerCompleted += (s, e) =>
            {
                // Checks if an error occurred during verification.
                if (e.Error != null)
                {
                    // Displays a message box about the error.
                    MessageBox.Show($"File verification completed with errors: {e.Error.Message}", "Verification Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    LogError($"Verification Worker Error: {e.Error}"); // Logs the error.
                }
                else if (e.Cancelled) // Checks if the operation was cancelled.
                {
                    // Displays a message box about the cancellation.
                    MessageBox.Show("File verification cancelled.", "Verification Cancelled", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else // The operation completed successfully.
                {
                    // Displays a message box about successful completion.
                    MessageBox.Show("File verification completed.", "Verification Complete",
                                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            };

            // Starts the background worker asynchronously.
            verifyWorker.RunWorkerAsync();
        }

        /// <summary>
        /// Logs a specified error message to a file, if logging is enabled.
        /// </summary>
        /// <param name="message">The error message to write to the log.</param>
        private void LogError2(string message)
        {
            // Checks if the 'logFileCheckBox' is checked to determine if logging should occur.
            if (logFileCheckBox.Checked)
            {
                try
                {
                    // Combines the application's startup path with the "Logs" directory name to create a full path.
                    string logPath = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "Logs");
                    // Creates the "Logs" directory if it doesn't already exist.
                    Directory.CreateDirectory(logPath);

                    // Creates a log file name with the prefix "CopyThat_" and the current date in yyyyMMdd format.
                    string logFile = System.IO.Path.Combine(logPath, $"CopyThat_{DateTime.Now:yyyyMMdd}.log");

                    // Formats the log entry string with the current timestamp, "ERROR:", the provided message, and a new line.
                    string logEntry = $"[{DateTime.Now:yyyy-MM-dd HH:mm:ss}] ERROR: {message}{Environment.NewLine}";
                    // Appends the formatted log entry to the log file.
                    File.AppendAllText(logFile, logEntry);

                    // Calls a separate method to clean up old log files.
                    CleanOldLogFiles(logPath);
                }
                catch
                {
                    // An empty catch block, which silently handles any exceptions during the logging process.
                }
            }
        }

        /// <summary>
        /// Deletes log files in a specified directory that are older than a configured number of days.
        /// </summary>
        /// <param name="logPath">The path to the directory containing log files.</param>
        private void CleanOldLogFiles(string logPath)
        {
            try
            {
                // Retrieves the number of days to keep log files from the 'logDaysNumUpDown' control.
                int keepDays = (int)logDaysNumUpDown.Value;
                // Calculates the cutoff date by subtracting the number of days to keep from the current date.
                DateTime cutoffDate = DateTime.Now.AddDays(-keepDays);

                // Creates a DirectoryInfo object for the log path to easily work with its contents.
                DirectoryInfo logDir = new DirectoryInfo(logPath);
                // Loops through all files in the directory that match the "CopyThat_*.log" pattern.
                foreach (FileInfo file in logDir.GetFiles("CopyThat_*.log"))
                {
                    // Checks if a file's creation time is older than the calculated cutoff date.
                    if (file.CreationTime < cutoffDate)
                    {
                        // Deletes the file if it is older than the cutoff date.
                        file.Delete();
                    }
                }
            }
            catch
            {
                // An empty catch block to silently handle any exceptions that occur during the cleanup process.
            }
        }
        private void btnPauseResumeMulti_Click(object sender, EventArgs e)
        {
            // Checks if the pause event has a signal. `WaitOne(0)` checks without blocking.
            if (_pauseEvent.WaitOne(0))
            {
                // Resets the event, effectively pausing the operation.
                _pauseEvent.Reset();
                // Changes the button text to "Resume".
                pauseResumeMultiButton.Text = "Resume";
            }
            else
            {
                // Sets the event, effectively resuming the operation.
                _pauseEvent.Set();
                // Changes the button text to "Pause".
                pauseResumeMultiButton.Text = "Pause";
            }
        }
        private void cancelMultiButton_Click(object sender, EventArgs e)
        {
            // Requests cancellation on the CancellationTokenSource.
            _cancellationTokenSource?.Cancel();
            // Sets the pause event, which unblocks any paused threads.
            _pauseEvent.Set();

            // Checks if the copy worker is busy and requests it to cancel asynchronously.
            if (_copyWorker.IsBusy)
                _copyWorker.CancelAsync();
            // Checks if the move worker is busy and requests it to cancel asynchronously.
            if (_moveWorker.IsBusy)
                _moveWorker.CancelAsync();
            // Checks if the delete worker is busy and requests it to cancel asynchronously.
            if (_deleteWorker.IsBusy)
                _deleteWorker.CancelAsync();
        }
        /// <summary>
        /// Updates the user interface to reflect the progress of a specific background thread.
        /// This method is thread-safe; it handles calls from non-UI threads by marshaling them
        /// to the UI thread.
        /// </summary>
        /// <param name="threadIndex">The 0-based index of the thread reporting progress.</param>
        /// <param name="progress">The current progress value (expected to be between 0 and 10000).</param>
        /// <param name="fileName">The name of the file the thread is currently processing.</param>
        private void UpdateMultiThreadProgress(int threadIndex, int progress, string fileName)
        {
            // This block ensures that UI updates are always performed on the main UI thread,
            // preventing cross-thread exceptions.
            // Checks if the call is from a different thread.
            if (InvokeRequired)
            {
                // If so, it marshals the call back to the UI thread.
                Invoke(new Action(() => UpdateMultiThreadProgress(threadIndex, progress, fileName)));
                return;
            }

            // This block updates the specific set of UI controls (progress bar and labels)
            // that correspond to the reporting thread's index.
            // A switch statement to update UI elements based on the thread index.
            switch (threadIndex)
            {
                case 0:
                    // Sets the value of the first progress bar, ensuring it doesn't exceed 10000.
                    progressBarMutli1.Value = Math.Min(progress, 10000);
                    // Updates the percentage label for the first thread.
                    progressBarMutli1.Text = $"{(progress / 100.0):F2}%";
                    // Updates the file name label for the first thread.
                    filesNameLabel1.Text = fileName;
                    break;
                case 1:
                    // Sets the value of the second progress bar.
                    progressBarMutli2.Value = Math.Min(progress, 10000);
                    // Updates the percentage label for the second thread.
                    progressBarMutli2.Text = $"{(progress / 100.0):F2}%";
                    // Updates the file name label for the second thread.
                    filesNameLabel2.Text = fileName;
                    break;
                case 2:
                    // Sets the value of the third progress bar.
                    progressBarMutli3.Value = Math.Min(progress, 10000);
                    // Updates the percentage label for the third thread.
                    progressBarMutli3.Text = $"{(progress / 100.0):F2}%";
                    // Updates the file name label for the third thread.
                    filesNameLabel3.Text = fileName;
                    break;
                case 3:
                    // Sets the value of the fourth progress bar.
                    progressBarMutli4.Value = Math.Min(progress, 10000);
                    // Updates the percentage label for the fourth thread.
                    progressBarMutli4.Text = $"{(progress / 100.0):F2}%";
                    // Updates the file name label for the fourth thread.
                    filesNameLabel4.Text = fileName;
                    break;
            }
        }
        private void bufferNumUpDown_ValueChanged(object sender, EventArgs e)
        {
            // Updates the bufferSize variable based on the value of the 'bufferNumUpDown' control, converting it to kilobytes.
            bufferSize = (int)bufferNumUpDown.Value * 1024;
        }
        private class progressInfo
        {
            // Defines a class to hold progress information.
            public int TotalProgress { get; set; }
            public int ProcessedFiles { get; set; }
            public long TotalFiles { get; set; }
            public long ProcessedBytes { get; set; }
            public long TotalBytes { get; set; }
            public string CurrentFileName { get; set; }
            public int FileProgress { get; set; }
        }
        /// <summary>
        /// Handles cleanup and cancellation when the form is closing.
        /// Cancels any ongoing operations (copy, move, delete) and stops timers
        /// before calling the base <see cref="Form.OnFormClosing(FormClosingEventArgs)"/> method.
        /// </summary>
        /// <param name="e">Provides data for the <see cref="Form.FormClosing"/> event.</param>
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            // Cancels the operation using the CancellationTokenSource.
            _cancellationTokenSource?.Cancel();
            // Stops the update timer.
            _updateTimer?.Stop();

            // Checks if the copy worker is busy and requests it to cancel.
            if (_copyWorker?.IsBusy == true)
                _copyWorker.CancelAsync();
            // Checks if the move worker is busy and requests it to cancel.
            if (_moveWorker?.IsBusy == true)
                _moveWorker.CancelAsync();
            // Checks if the delete worker is busy and requests it to cancel.
            if (_deleteWorker?.IsBusy == true)
                _deleteWorker.CancelAsync();

            // Calls the base class method to continue with the form closing process.
            base.OnFormClosing(e);
        }

        /// <summary>
        /// Initializes UI elements when the form loads, including setting
        /// progress bar limits and initial button states.
        /// </summary>
        /// <param name="e">Provides data for the <see cref="Form.Load"/> event.</param>
        protected override void OnLoad(EventArgs e)
        {
            // Calls the base class method.
            base.OnLoad(e);

            // Sets the maximum value for various progress bars to 10000 for a granular progress display.
            progressBarMutli1.Maximum = 10000;
            progressBarMutli2.Maximum = 10000;
            progressBarMutli3.Maximum = 10000;
            progressBarMutli4.Maximum = 10000;
            progressBarMultiThreadTotal.Maximum = 10000;

            totalProgressBar.Minimum = 0;
            totalProgressBar.Maximum = 10000;
            fileProgressBar.Minimum = 0;
            fileProgressBar.Maximum = 10000;
            // Sets the initial text for the pause/resume buttons.
            pauseResumeButton.Text = "Pause";
            pauseResumeMultiButton.Text = "Pause";
        }

        /// <summary>
        /// Saves the current operation state (file list, progress, settings)
        /// to a JSON file so the operation can be resumed later if needed.
        /// </summary>
        private void SaveOperationState()
        {
            try
            {
                // Creates the path for the state file.
                string stateFile = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "operation_state.json");
                // Creates an anonymous object to hold the current operation state.
                var state = new
                {
                    FileList = _fileList,
                    CurrentIndex = _currentFileIndex,
                    ProcessedBytes = _totalBytesProcessed,
                    ProcessedFiles = _processedFiles,
                    Operation = copyMoveDeleteComboBox.SelectedItem?.ToString(),
                    SourcePath = sourcePath,
                    DestinationPath = destinationPath,
                    Settings = new
                    {
                        BufferSize = bufferSize,
                        IsMultiThreaded = _isMultiThreaded,
                        OverwriteAll = overwriteAllCheckBox.Checked,
                        DoNotOverwrite = doNotOverwriteCheckBox.Checked,
                        OverwriteOlderFiles = overwriteIfNewerCheckBox.Checked,
                        KeepDirectoryStructure = keepDirStructCheckBox.Checked,
                        CreateDirectoryPrior = createCustomDirCheckBox.Checked,
                        VerifyAfterTransfer = verifyCheckBox.Checked
                    }
                };

                // Serializes the state object to a JSON string with indentation.
                string json = Newtonsoft.Json.JsonConvert.SerializeObject(state, Newtonsoft.Json.Formatting.Indented);
                // Writes the JSON string to the state file.
                File.WriteAllText(stateFile, json);
            }
            catch
            {
                // An empty catch block to handle any exceptions during saving.
            }
        }

        /// <summary>
        /// Attempts to restore a previously saved operation state from disk.
        /// Prompts the user to resume the operation and, if confirmed,
        /// restores the file list, progress, and settings.
        /// </summary>
        private void RestoreOperationState()
        {
            try
            {
                // Creates the path for the state file.
                string stateFile = System.IO.Path.Combine(System.Windows.Forms.Application.StartupPath, "operation_state.json");
                // Checks if the state file exists and returns if it does not.
                if (!File.Exists(stateFile)) return;

                // Reads the entire content of the state file into a string.
                string json = File.ReadAllText(stateFile);

                // Displays a message box asking the user if they want to resume the operation.
                if (MessageBox.Show("Previous operation state found. Do you want to resume?",
                                     "Resume Operation", MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question) != DialogResult.Yes)
                {
                    // If the user chooses not to resume, deletes the state file and returns.
                    File.Delete(stateFile);
                    return;
                }

                // Deserializes the JSON string into a dynamic object.
                var state = JsonConvert.DeserializeObject<dynamic>(json);

                // Deserializes the FileList from the dynamic object to a List<FileInfoWrapper>.
                var temp = state.FileList != null
                    ? ((Newtonsoft.Json.Linq.JToken)state.FileList).ToObject<List<FileInfoWrapper>>()
                    : new List<FileInfoWrapper>();
                // Clears the existing file list and adds the restored files.
                _fileList.Clear();
                foreach (var f in temp) _fileList.Add(f);

                // Restores other state variables from the deserialized object.
                _currentFileIndex = state.CurrentIndex ?? 0;
                _totalBytesProcessed = state.ProcessedBytes ?? 0L;
                _processedFiles = state.ProcessedFiles ?? 0;

                // Restores UI control selections and values.
                copyMoveDeleteComboBox.SelectedItem = (string)state.Operation;
                sourcePath = state.SourcePath;
                destinationPath = state.DestinationPath;

                // Restores settings from the nested 'Settings' object.
                var s = state.Settings;
                if (s != null)
                {
                    bufferSize = s.BufferSize ?? 1024 * 1024;
                    _isMultiThreaded = s.IsMultiThreaded ?? false;
                    overwriteAllCheckBox.Checked = s.OverwriteAll ?? false;
                    doNotOverwriteCheckBox.Checked = s.DoNotOverwrite ?? false;
                    overwriteIfNewerCheckBox.Checked = s.OverwriteOlderFiles ?? false;
                    keepDirStructCheckBox.Checked = s.KeepDirectoryStructure ?? true;
                    createCustomDirCheckBox.Checked = s.CreateDirectoryPrior ?? false;
                    verifyCheckBox.Checked = s.VerifyAfterTransfer ?? false;
                }

                // Calls a method to rebuild the data grid view with the restored data.
                RebuildDataGridView();
                // Deletes the state file after successful restoration.
                File.Delete(stateFile);
            }
            catch
            {
                // An empty catch block to handle any exceptions during restoration.
            }
        }

        /// <summary>
        /// Rebuilds the DataGridView to reflect the current file list and progress,
        /// ensuring all file entries and their statuses are correctly displayed.
        /// </summary>
        private void RebuildDataGridView()
        {
            // Resets the data bindings for the binding source.
            _bindingSource.ResetBindings(false);
            // Loops through each file wrapper in the file list.
            foreach (FileInfoWrapper fileWrapper in _fileList)
            {
                // Checks if the file exists on the disk.
                if (File.Exists(fileWrapper.FilePath))
                {
                    // Creates a FileInfo object to get file details.
                    FileInfo fileInfo = new FileInfo(fileWrapper.FilePath);
                    // Determines the status of the file based on the current progress index.
                    string status = _fileList.IndexOf(fileWrapper) < _currentFileIndex ? "Complete" : "Pending";
                    // Adds the file information to the DataGridView.
                    AddToDataGridView(fileInfo.Name, fileWrapper.FilePath, fileInfo.Length, status);
                }
            }
            // Updates the total file count.
            _grandTotalFileCount = _fileList.Count;
            // Updates the file count labels on the UI.
            UpdateFileCountLabels();
        }

        /// <summary>
        /// Adds a new file entry to both DataGridViews and scrolls to the latest row,
        /// performing UI-thread marshaling if needed.
        /// </summary>
        /// <param name="fileName">The display name of the file.</param>
        /// <param name="filePath">The full file path.</param>
        /// <param name="fileSize">The file size in bytes.</param>
        /// <param name="status">The processing status of the file (e.g., Pending, Complete).</param>
        private void AddToDataGridView(string fileName, string filePath, long fileSize, string status)
        {
            // Checks if the call is from a different thread.
            if (InvokeRequired)
            {
                // If so, it marshals the call back to the UI thread.
                Invoke(new Action(() => AddToDataGridView(fileName, filePath, fileSize, status)));
                return;
            }

            // Adds a new row to the main files DataGridView with file information.
            filesDataGridView.Rows.Add(fileName, filePath, FormatFileSize(fileSize), status);

            // Checks if the DataGridView has any rows.
            if (filesDataGridView.Rows.Count > 0)
            {
                // Scrolls the DataGridView to the last added row.
                filesDataGridView.FirstDisplayedScrollingRowIndex = filesDataGridView.Rows.Count - 1;
            }

            // Adds a new row to a second DataGridView (dataGridView1).
            dataGridView1.Rows.Add(fileName, filePath, FormatFileSize(fileSize), status);

            // Checks if the second DataGridView has any rows.
            if (dataGridView1.Rows.Count > 0)
            {
                // Scrolls the second DataGridView to the last added row.
                dataGridView1.FirstDisplayedScrollingRowIndex = filesDataGridView.Rows.Count - 1;
            }
        }

        private void keepOnlyFilesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // Checks if the 'keepOnlyFilesCheckBox' is checked.
            if (keepOnlyFilesCheckBox.Checked)
            {
                // If it is, unchecks all other related checkboxes to ensure mutually exclusive options.
                keepDirStructCheckBox.Checked = false;
                leaveEmptyFoldersCheckBox.Checked = false;
                copyFilesDirsCheckBox.Checked = false;
            }
            // If the checkbox is unchecked, and all other related checkboxes are also unchecked...
            else if (!leaveEmptyFoldersCheckBox.Checked && !keepOnlyFilesCheckBox.Checked && !copyFilesDirsCheckBox.Checked && !createCustomDirCheckBox.Checked)
            {
                // ...re-checks the 'keepDirStructCheckBox' by default.
                keepDirStructCheckBox.Checked = true;
            }
        }
        private void keepEmptyFoldersCheckBox_CheckedChanged(object sender, EventArgs e)
        {

            // Checks if the 'keepEmptyFoldersCheckBox' is checked.
            if (leaveEmptyFoldersCheckBox.Checked)
            {
                // If it is, unchecks all other related checkboxes to ensure mutually exclusive options.
                keepOnlyFilesCheckBox.Checked = false;
                createCustomDirCheckBox.Checked = false;
            }
            // If the checkbox is unchecked, and all other related checkboxes are also unchecked...
            else if (!leaveEmptyFoldersCheckBox.Checked && !keepOnlyFilesCheckBox.Checked && !copyFilesDirsCheckBox.Checked && !createCustomDirCheckBox.Checked)
            {
                // ...re-checks the 'keepDirStructCheckBox' by default.
                keepDirStructCheckBox.Checked = true;
            }
        }
        private void filesDataGridView_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Ensures a valid row and column index were clicked.
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0 &&
                e.RowIndex < filesDataGridView.Rows.Count &&
                e.ColumnIndex < filesDataGridView.Columns.Count)
            {
                // Gets the cell at the clicked location in the first column.
                var cell = filesDataGridView.Rows[e.RowIndex].Cells[0];
                // Checks if the cell value is not null.
                if (cell?.Value != null)
                {
                    // Updates a label to show the name of the selected file.
                    filePathLabel.Text = "Current Selection: " + cell.Value.ToString();
                }
                else
                {
                    // If the cell value is null, updates the label to show "No File Selected".
                    filePathLabel.Text = "No File Selected";
                }
            }
            else
            {
                // If the click was outside the valid range, updates the label to show "No File Selected".
                filePathLabel.Text = "No File Selected";
            }
        }

        /// <summary>
        /// Displays a confirmation dialog to cancel the ongoing copy operation.
        /// If the user selects "Yes", the current file finishes copying before the process stops.
        /// Uses <see cref="InvokeRequired"/> to ensure thread-safe UI updates.
        /// </summary>
        /// <returns>
        /// <c>true</c> if the user confirmed cancellation (current file will complete, then stop);
        /// <c>false</c> if the user declined.
        /// </returns>
        private bool ConfirmCancelCopy()
        {
            bool finish = false;

            DialogResult dr = DialogResult.None;

            if (InvokeRequired)
            {
                Invoke(new Action(() =>
                {
                    cancelButton.Enabled = false;
                    dr = MessageBox.Show(
                            "Cancel the copy?\n\nChoosing ‘Yes’ will finish the current file and then stop.",
                            "Confirm cancel",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                }));
            }
            else
            {
                cancelButton.Enabled = false;
                dr = MessageBox.Show(
                        "Cancel the copy?\n\nChoosing ‘Yes’ will finish the current file and then stop.",
                        "Confirm cancel",
                        MessageBoxButtons.YesNo,
                        MessageBoxIcon.Question);
            }

            // ---- handle the answer ----
            if (dr == DialogResult.No)
            {
                // user clicked No – do whatever you need here
                cancelButton.Enabled = true;
                return false;               // don’t cancel
            }

            // user clicked Yes – proceed with cancel
            _finishCurrentFileAndQuit = true;
            return true;
        }

        private void tabControl1_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a descriptive text about the tab control.
            statusLabel.Text = "Tab Control: This control allows you to switch between different operation modes and settings.";
        }

        private void fileNamePicBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the file icon picture box.
            statusLabel.Text = "File's Icon PictureBox: The file's icon which reflect the current file will be shown here.";
        }

        private void fromDirPicBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the source directory button.
            statusLabel.Text = "Source Directory Button: This is the button to select your source directory from which files will be copied/moved/securely deleted.";
        }

        private void targetDirPicBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the target directory button.
            statusLabel.Text = "Target Directory Button: This is the button to select your target directory to which your files will be copied/moved.";
        }

        private void copyMoveDeleteComboBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the operation dropdown.
            statusLabel.Text = "Copy/Move/Secure Delete ComboBox: This dropdown combobox is to select the operation of Copy/Move/Secure Delete.";
        }

        private void onFinishComboBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the "on finish" dropdown.
            statusLabel.Text = "On Finish ComboBox: This dropdown combobox is to select the action to perform when the operation finishes.";
        }

        private void startButton_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the start button.
            statusLabel.Text = "Start Button: This button starts the operation of Copy/Move/Secure Delete.";
        }

        private void pauseResumeButton_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the pause/resume button.
            statusLabel.Text = "Pause/Resume Button: This button pauses/resumes the current operation.";
        }

        private void cancelButton_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the cancel button.
            statusLabel.Text = "Cancel Button: This button cancels the current operation.";
        }

        private void skipButton_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the skip button.
            statusLabel.Text = "This button skips the current file and moves to the next one in the operation.";
        }

        private void addFileButton_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the add file button.
            statusLabel.Text = "Add File Button: This button adds files to the list for the current operation.";
        }

        private void removeFileButton_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the remove file button.
            statusLabel.Text = "Remove File Button: This button removes the selected file from the list for the current operation.";
        }

        private void clearFileListButton_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the clear file list button.
            statusLabel.Text = "Clear File List Button: This button clears the entire file list for the current operation.";
        }

        private void fileCountOnLabel_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the file count label.
            statusLabel.Text = "File Count Label: This label shows the total number of files in the current operation.";
        }

        private void fileProcessedLabel_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the file processed label.
            statusLabel.Text = "File Processed Label: This label shows the number of converted bytes that have been processed in the current operation.";
        }

        private void totalCopiedProgressLabel_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the total copied progress label.
            statusLabel.Text = "Total Copied Progress Label: This label shows the total bytes processed and the total bytes to process in the current operation.";
        }

        private void elapsedAndTargetTimeLabel_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the elapsed and target time label.
            statusLabel.Text = "Elapsed Out of Target Time Label: This label shows the elapsed time and the estimated target time for the current operation.";
        }

        private void speedLabel_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the speed label.
            statusLabel.Text = "Speed Label: This label shows the current speed of the operation in bytes per second.";
        }

        private void totalHDSpaceLeftLabel_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the total hard drive space left label.
            statusLabel.Text = "Total HD Space Left Label: This label shows the total hard drive space left on the target drive.";
        }

        private void overwriteIfNewerCheckBox_MouseDown(object sender, MouseEventArgs e)
        {
            // Updates the status label with a description of the overwrite if newer checkbox.
            statusLabel.Text = "Overwrite If Newer CheckBox: This checkbox determines whether to overwrite files only if the source file is newer than the destination file.";
        }

        private void overwriteAllCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the overwrite all checkbox.
            statusLabel.Text = "Overwrite All CheckBox: This checkbox determines whether to overwrite all files in the target directory without checking their timestamps.";
        }

        private void doNotOverwriteCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the do not overwrite checkbox.
            statusLabel.Text = "Do Not Overwrite CheckBox: This checkbox determines whether to skip files that already exist in the target directory.";
        }

        private void keepEmptyFoldersCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the keep empty folders checkbox.
            statusLabel.Text = "Keep Empty Folders CheckBox: This checkbox determines whether to keep empty folders in the target directory after the operation.";
        }

        private void keepDirStructCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the keep directory structure checkbox.
            statusLabel.Text = "Keep Directory Structure CheckBox: This checkbox determines whether to keep the directory structure of the source files in the target directory.";
        }

        private void createCustomDirCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the create custom directory checkbox.
            statusLabel.Text = "Create Custom Directory Prior CheckBox: This checkbox determines whether to create a custom directory structure in the target directory based on the source files.";
        }

        private void copyFilesDirsCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the copy files and directories checkbox.
            statusLabel.Text = "Copy Only Files CheckBox: This checkbox determines whether to copy files and no directories from the source directory to the target directory.";
        }

        private void keepOnlyFilesCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Updates the status label with a description of the keep only files checkbox.
            statusLabel.Text = "Keep Only Files CheckBox: This checkbox determines whether to keep ONLY files inside the main directory.";
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (proVersion)
                {
                    // Updates the title label to show the current tab name.
                    titleLabel.Text = "Copy That v1.0 Pro By: Havoc";
                }
                else
                {
                    // Updates the title label to show the current tab name.
                    titleLabel.Text = "Copy That v1.0 By: Havoc";
                }
            }
            catch
            {

            }




            // Checks if the selected tab is the "About" page.
            if (tabControl1.SelectedTab == cmdAboutPage)
            {
                // Stops the scroll timer if it's running.
                scrollTimer?.Stop();
                // Removes the event handler for the timer.
                if (scrollTimer != null)
                {
                    scrollTimer.Tick -= ScrollTimer_Tick;
                }

                // Disposes of the old timer.
                scrollTimer?.Dispose();

                // Creates and starts a new timer for scrolling.
                scrollTimer = new Timer();
                scrollTimer.Interval = 25;
                scrollTimer.Tick += ScrollTimer_Tick;
                scrollTimer.Start();

                // Ensures the "About" page is the selected tab.
                tabControl1.SelectedTab = cmdAboutPage;

                // Updates the title label based on whether it's the "Pro" version.
                if (proVersion)
                {
                    titleLabel.Text = "Copy That v1.0 Pro By: Havoc - About";
                }
                else
                {
                    titleLabel.Text = "Copy That v1.0 By: Havoc - About";
                }

                // Defines constants for logo size and padding.
                int logoWidth = 300;
                int logoHeight = 300;
                int logoPadding = 10;

                // Sets the size and picture box mode for the logos.
                copyThatPB.Width = logoWidth;
                copyThatPB.Height = logoHeight;
                copyThatPB.SizeMode = PictureBoxSizeMode.Zoom;

                havocSoftwarePB.Width = logoWidth;
                havocSoftwarePB.Height = logoHeight;
                havocSoftwarePB.SizeMode = PictureBoxSizeMode.Zoom;

                // Calculates the total width of both logos and the padding.
                int totalLogoWidth = (logoWidth * 2) + logoPadding;
                // Calculates the starting X position to center the logos.
                int startX = (aboutPanel.Width - totalLogoWidth) / 2;

                // Sets the position of the first logo.
                copyThatPB.Left = startX;
                copyThatPB.Top = aboutPanel.Height;

                // Sets the position of the second logo.
                havocSoftwarePB.Left = startX + logoWidth + logoPadding;
                havocSoftwarePB.Top = aboutPanel.Height;



                // Configures the size and alignment of the "about" label.
                aboutCTLabel.AutoSize = true;
                aboutCTLabel.MaximumSize = new Size(aboutPanel.Width - 20, 0);
                aboutCTLabel.TextAlign = ContentAlignment.TopCenter;

                // Centers the "about" label horizontally and positions it below the logos.
                aboutCTLabel.Left = (aboutPanel.Width - aboutCTLabel.Width) / 2;
                aboutCTLabel.Top = copyThatPB.Top + logoHeight + 10;

                // Adds the picture boxes and label to the about panel if they are not already there.
                if (!aboutPanel.Controls.Contains(copyThatPB))
                    aboutPanel.Controls.Add(copyThatPB);
                if (!aboutPanel.Controls.Contains(havocSoftwarePB))
                    aboutPanel.Controls.Add(havocSoftwarePB);
                if (!aboutPanel.Controls.Contains(aboutLabel))
                    aboutPanel.Controls.Add(aboutLabel);
            }

            // Handles other tab selections by updating the status label.
            else if (tabControl1.SelectedTab == cmdCopyHistory)
            {
                toolStripCopyHistory.Text = "Current tab page: Copy History Page.";
            }
            else if (tabControl1.SelectedTab == cmdExclusions)
            {
                toolStripExclusions.Text = "Current tab page: Exclusions Page.";
            }
            else if (tabControl1.SelectedTab == cmdHomePage)
            {
                statusLabel.Text = "Current tab page: Home Page.";
            }
            else if (tabControl1.SelectedTab == cmdSettingsPage)
            {
                toolStripSettings.Text = "Current tab page: Settings Page.";
            }
            else if (tabControl1.SelectedTab == cmdSkipPage)
            {
                toolStripSkipped.Text = "Current tab page: Skipped Files Page.";
            }
            else
            {
                toolStripMulti.Text = "Current tab page: Multi-Thread Page.";
            }
        }

        private void cmdHomePage_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'statusLabel' to a descriptive message when the mouse enters the 'cmdHomePage' button.
            statusLabel.Text = "Home Page Tab: This tab contains the main interface for file operations such as copy, move, and secure delete.";
        }

        private void mainForm_MouseEnter(object sender, EventArgs e)
        {
            // Checks if the 'proVersion' boolean is true.
            // If true, it sets the status label to "Copy That v1.0 Pro By: Havoc - Home".
            // If false, it sets the status label to "Copy That v1.0 By: Havoc - Home".
            statusLabel.Text = proVersion ? "Copy That v1.0 Pro By: Havoc - Home" : "Copy That v1.0 By: Havoc - Home";
        }

        private void titleLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'statusLabel' to a message explaining the application's title.
            statusLabel.Text = "Copy That v1.0 By: Havoc - This is the title of the application, which reflects the current operation.";
        }

        private void filePathLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'filePathLabel' control.
            statusLabel.Text = "Current File Path: This label shows the path of the currently processed file in the operation.";
        }

        private void fromFilesDirLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'fromFilesDirLabel' control.
            statusLabel.Text = "Current Source Directory: This label shows the path of the source directory from which files will be copied/moved/securely deleted.";
        }

        private void targetDirLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'targetDirLabel' control.
            statusLabel.Text = "Current Target Directory: This label shows the path of the target directory to which files will be copied/moved.";
        }

        private void fileIconPicBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'fileIconPicBox' control.
            statusLabel.Text = "Current File Icon: This picture box shows the icon of the currently processed file in the operation.";
        }

        private void overwriteIfNewerCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'overwriteIfNewerCheckBox'.
            statusLabel.Text = "Overwrite If Newer: This checkbox determines whether to overwrite files only if the source file is newer than the destination file.";
        }

        private void fileProgressBar_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'fileProgressBar' control.
            statusLabel.Text = "File Progress Bar: This progress bar shows the progress of the current file being processed in the operation.";
        }

        private void fileTotalProgressLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'fileTotalProgressLabel'.
            statusLabel.Text = "File Progress Label: This label shows the percentage of progress for the current file being processed in the operation.";
        }

        private void totalProgressBar_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'totalProgressBar' control.
            statusLabel.Text = "Total Progress Bar: This progress bar shows the overall progress of the operation across all files being processed.";
        }

        private void totalProgressLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'totalProgressLabel'.
            statusLabel.Text = "Total Progress Label: This label shows the percentage of overall progress for the operation across all files being processed.";
        }

        private void searchTextBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'searchTextBox'.
            statusLabel.Text = "Search Text Box: This text box allows you to search for specific files in the file list. Type a keyword to filter the displayed files.";
        }

        private void clearTextButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'clearTextButton'.
            statusLabel.Text = "Clear Text Button: This button clears the text in the search box, allowing you to reset the search filter and view all files in the list.";
        }

        private void fileUpPicBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'fileUpPicBox'.
            statusLabel.Text = "Files Up Button: This button allows you to move the selected file up in the list, changing its order in the operation sequence.";
        }

        private void fileDownPicBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'fileDownPicBox'.
            statusLabel.Text = "Files Down Button: This button allows you to move the selected file down in the list, changing its order in the operation sequence.";
        }

        private void filesDataGridView_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'filesDataGridView'.
            statusLabel.Text = "Files Data Grid View: This grid displays the list of files to be processed in the current operation, including their names, paths, sizes, and statuses.";
        }

        private void autoScrollCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'autoScrollCheckBox'.
            statusLabel.Text = "Auto-Scroll CheckBox: This checkbox enables or disables automatic scrolling of the files data grid view while files are being processsed.";
        }

        private void verifyCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the status label to describe the 'verifyCheckBox'.
            statusLabel.Text = "Verify After Transfer CheckBox: This checkbox determines whether to verify the integrity of files after they have been copied or moved.";
        }

        private void pauseResumeMultiButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Pause/Resume Multi-Thread Button: This button pauses or resumes the multi-threaded operation.";
        }

        private void cancelMultiButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Cancel Multi-Thread Button: This button cancels the multi-threaded operation.";
        }

        private void onFinishMultiComboBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "On Finish Multi-Thread ComboBox: This dropdown combobox is to select the action to perform when the multi-threaded operation finishes.";
        }

        private void filesNameLabel1_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Files Name Label 1: This label shows the name of the file being processed by thread 1, along with the percentage and speed.";
        }

        private void totalPCTMultiLabel1_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Total Percentage Multi Label 1: This label shows the percentage of progress for the file being processed by thread 1.";
        }

        private void filesNameLabel2_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Files Name Label 2: This label shows the name of the file being processed by thread 2, along with the percentage and speed.";
        }

        private void filesNameLabel3_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Files Name Label 3: This label shows the name of the file being processed by thread 3, along with the percentage and speed.";
        }

        private void totalPCTMultiLabel2_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Total Percentage Multi Label 2: This label shows the percentage of progress for the file being processed by thread 2.";
        }

        private void totalPCTMultiLabel3_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Total Percentage Multi Label 3: This label shows the percentage of progress for the file being processed by thread 3.";
        }

        private void filesNameLabel4_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Files Name Label 4: This label shows the name of the file being processed by thread 4, along with the percentage and speed.";
        }

        private void totalPCTMultiLabel4_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Total Percentage Multi Label 4: This label shows the percentage of progress for the file being processed by thread 4.";
        }

        private void progressBarMultiThreadTotal_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Progress Bar Multi-Thread Total: This progress bar shows the overall progress of the multi-threaded operation across all threads.";
        }

        private void multiThreadTotalProgressLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Multi-Thread Total Progress Label: This label shows the percentage of overall progress for the multi-threaded operation across all threads.";
        }

        private void fileCountMultiLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "File Count Multi Label: This label shows the number of files processed out of the total number of files in the multi-threaded operation.";
        }

        private void totalTimeMultiLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Total Time Multi Label: This label shows the elapsed time out of the estimated target time for the multi-threaded operation.";
        }

        private void speedMultiLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Speed Multi Label: This label shows the current speed of the multi-threaded operation in bytes per second.";
        }

        private void totalCMDMultiLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Total C/M/D Label: This label shows the total space processed out of the total space for all files.";
        }

        private void totalSpaceMultiLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Total Space Left Label: This label shows the total hard drive used out of the total hard drive space left on the target drive for the multi-threaded operation.";
        }

        private void goToInExplorerButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSkipped' to a descriptive message.
            toolStripSkipped.Text = "Go To In Explorer Button: This button opens the selected file's location in Windows Explorer.";
        }

        private void totalSkippedLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSkipped' to a descriptive message.
            toolStripSkipped.Text = "Total Skipped Label: This label shows the total number of files that were skipped during the operation.";
        }

        private void clearSkippedListButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSkipped' to a descriptive message.
            toolStripSkipped.Text = "Clear Skipped List Button: This button clears the list of skipped files.";
        }

        private void skippedDataGridView_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSkipped' to a descriptive message.
            toolStripSkipped.Text = "Skipped Data Grid View: This grid displays the list of files that were skipped during the operation, including their names, paths, sizes, and reasons for skipping.";
        }

        private void cloneButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripCopyHistory' to a descriptive message.
            toolStripCopyHistory.Text = "Clone Button: This button clones the selected operation from the history list, allowing you to quickly repeat a previous operation.";
        }

        private void deleteEntryButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripCopyHistory' to a descriptive message.
            toolStripCopyHistory.Text = "Delete Entry Button: This button deletes the selected entry from the operation history list.";
        }

        private void clearHistoryButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripCopyHistory' to a descriptive message.
            toolStripCopyHistory.Text = "Clear History Button: This button clears the entire operation history list.";
        }

        private void totalHistoryLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripCopyHistory' to a descriptive message.
            toolStripCopyHistory.Text = "Total History Label: This label shows the total number of operations recorded in the history list.";
        }

        private void addAllowedButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Add Allowed Button: This button adds a new allowed file or directory to the allowed list.";
        }

        private void removeAllowedButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Remove Allowed Button: This button removes the selected allowed file or directory from the allowed list.";
        }

        private void clearAllowedButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Clear Allowed Button: This button clears the entire list of allowed files and directories.";
        }

        private void addExcludedButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Add Excluded Button: This button adds a new excluded file or directory to the exclusions list.";
        }

        private void removeExcludedButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Remove Excluded Button: This button removes the selected excluded file or directory from the exclusions list.";
        }

        private void clearExcludedButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Clear Excluded Button: This button clears the entire list of excluded files and directories.";
        }

        private void allowedTextBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Allowed Text Box: This text box allows you to enter file or directory paths to be added to the allowed list.";
        }

        private void excludedTextBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Excluded Text Box: This text box allows you to enter file or directory paths to be added to the exclusions list.";
        }

        private void allowedExtListBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Allowed List Box: This list box displays the list of allowed files and directories that will be included in the operation.";
        }

        private void excludedExtListBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Excluded List Box: This list box displays the list of excluded files and directories that will be skipped during the operation.";
        }

        private void cmdExclusions_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripExclusions' to a descriptive message.
            toolStripExclusions.Text = "Exclusions Tab: This tab allows you to manage the lists of allowed and excluded files and directories for the operation.";
        }

        private void cmdSkipPage_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSkipped' to a descriptive message.
            toolStripSkipped.Text = "Skipped Tab: This tab displays the list of files that were skipped during the operation, along with options to manage the skipped files.";
        }

        private void cmdMultithread_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripMulti' to a descriptive message.
            toolStripMulti.Text = "Multi-Thread Tab: This tab allows you to configure and monitor multi-threaded operations for copying or moving files.";
        }

        private void windowGroupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Window Group Box: This group box contains settings related to the application's window behavior, such as minimizing to the system tray.";
        }

        private void alwaysOnTopCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Always On Top CheckBox: This checkbox determines whether the application window should always stay on top of other windows.";
        }

        private void minimizeSystemTrayCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Minimize to System Tray CheckBox: This checkbox determines whether the application should minimize to the system tray instead of the taskbar.";
        }

        private void confirmDragDropCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Confirm Drag & Drop CheckBox: This checkbox determines whether to show a confirmation dialog when files are dragged and dropped into the application.";
        }

        private void contextMenuCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Context Menu CheckBox: This checkbox determines whether to add an option to the Windows context menu for quick access to the application.";
        }

        private void skinsLanguageGoupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Skins & Language Group Box: This group box contains settings related to the application's appearance and language preferences.";
        }

        private void languageComboBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Language ComboBox: This dropdown combobox allows you to select the language for the application's user interface.";
        }

        private void skinsComboBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Skins ComboBox: This dropdown combobox allows you to select different skins or themes for the application's appearance.";
        }

        private void fontNumUpDown_Enter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Font Size Numeric Up-Down: This control allows you to adjust the font size used in the application's user interface.";
        }

        private void soundsGroupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Sounds Group Box: This group box contains settings related to the application's sound notifications for various events.";
        }

        private void onFinishCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "On Finish CheckBox: This checkbox determines whether to play a sound notification when the file operation finishes.";
        }

        private void onCancelCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "On Cancel CheckBox: This checkbox determines whether to play a sound notification when the file operation is canceled.";
        }

        private void onAddFilesCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "On Add Files CheckBox: This checkbox determines whether to play a sound notification when files are added to the operation list.";
        }

        private void onErrorCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "On Error CheckBox: This checkbox determines whether to play a sound notification when an error occurs during the file operation.";
        }

        private void updateGroupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Update Group Box: This group box contains settings related to the application's update preferences.";
        }

        private void updateAutoCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Auto Check for Updates CheckBox: This checkbox determines whether the application should automatically check for updates on startup.";
        }

        private void updateBetaCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Include Beta Versions CheckBox: This checkbox determines whether to include beta versions when checking for updates.";
        }

        private void checkForUpdatesButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Check for Updates Button: This button manually checks for updates to the application.";
        }

        private void defaultSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Default Settings Button: This button resets all settings to their default values.";
        }

        private void recSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Recommended Settings Button: This button applies a set of recommended settings for optimal performance and usability.";
        }

        private void priorityTrackBar_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Priority Track Bar: This track bar allows you to adjust the priority level of the file operations, affecting how system resources are allocated.";
        }

        private void opacityTrackBar_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Opacity Track Bar: This track bar allows you to adjust the opacity level of the application window, making it more or less transparent.";
        }

        private void logFileCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Log File CheckBox: This checkbox determines whether to create a log file that records details of the file operations performed by the application.";
        }

        private void logDaysNumUpDown_Enter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Log Days Numeric Up-Down: This control allows you to specify the number of days to retain log files before they are automatically deleted.";
        }

        private void saveAutoCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Auto Save Settings CheckBox: This checkbox determines whether to automatically save the current settings when the application is closed.";
        }

        private void clearSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Clear Settings Button: This button clears all user-defined settings, reverting the application to its default configuration.";
        }

        private void saveSettingsButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Save Settings Button: This button saves the current settings, ensuring that any changes made are retained for future sessions.";
        }

        private void performanceGroupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Performance Group Box: This group box contains settings related to the application's performance, such as buffer size and multi-threading options.";
        }

        private void bufferNumUpDown_Enter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Buffer Size Numeric Up-Down: This control allows you to adjust the buffer size used during file operations, which can affect performance.";
        }

        private void multithreadCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Multi-Thread CheckBox: This checkbox enables or disables multi-threaded file operations, allowing multiple files to be processed simultaneously for improved performance.";
        }

        private void underMBCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Under MB CheckBox: This checkbox determines whether to apply multi-threading only to files smaller than the specified size in megabytes.";
        }

        private void overMBCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Over MB CheckBox: This checkbox determines whether to apply multi-threading only to files larger than the specified size in megabytes.";
        }

        private void setMBGBUnderNumUpDown_Enter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Set MB/GB Under Numeric Up-Down: This control allows you to specify the size threshold in megabytes for applying multi-threading to smaller files.";
        }

        private void setMBGBOverNumUpDown_Enter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Set MB/GB Over Numeric Up-Down: This control allows you to specify the size threshold in megabytes for applying multi-threading to larger files.";
        }

        private void fileDirSettingsGroupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "File/Directory Settings Group Box: This group box contains settings related to how files and directories are exported or zipped (before) for the copy or move operations.";
        }

        private void onlyNamesCheckBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Only Names CheckBox: This checkbox determines whether to export only the names of files and directories without their full paths.";
        }

        private void fullPathsCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Full Paths CheckBox: This checkbox determines whether to export the full paths of files and directories.";
        }

        private void exportButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Export Button: This button exports the list of files and directories to a text file based on the selected settings (only names or full paths).";
        }

        private void zipSeparateCheckBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Zip Separate CheckBox: This checkbox determines whether to create separate zip files for each file and directory before the copy or move operations.";
        }

        private void zipTogetherCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Zip Together CheckBox: This checkbox determines whether to create a single zip file containing all files and directories before the copy or move operations.";
        }

        private void emailGroupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Email Group Box: This group box contains settings related to exporting and emailing the file list for the application.";
        }

        private void smsGroupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "SMS Group Box: This group box contains settings for configuring SMS notifications when operations complete.";
        }

        private void setUpSMSButton_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Set Up SMS Button: This button opens the SMS notification setup dialog, allowing you to configure SMS settings for operation completion notifications.";
        }

        private void setUpEmailButton_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Set Up Email Button: This button opens the email setup dialog, allowing you to configure email settings for exporting and sending the file list.";
        }

        private void emailNamesCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Email Names CheckBox: This checkbox determines whether to include only the names of files and directories in the email export.";
        }

        private void emailPathsCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Email Paths CheckBox: This checkbox determines whether to include the full paths of files and directories in the email export.";
        }

        private void otherSettingsGroupBox_MouseHover(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Other Settings Group Box: This group box contains miscellaneous settings for the application.";
        }

        private void closeProgramCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Close Program CheckBox: This checkbox determines whether to automatically close the application when an error occurs.";
        }

        private void restartCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Restart CheckBox: This checkbox determines whether to automatically restart the application when an error occurs.";
        }

        private void startWithWindowsCheckBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Start with Windows CheckBox: This checkbox determines whether to launch the application automatically when Windows starts.";
        }

        private void serialMaskedTextBox_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Serial Key Text Box: This text box allows you to enter your serial key to activate the application.";
        }

        private void registerButton_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Register Button: This button submits the entered serial key for validation and activates the application if the key is valid.";
        }

        private void securePassesNumUpDown_Enter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Secure Passes Numeric Up-Down: This control allows you to specify the number of passes to use for securely deleting files.";
        }

        private void cmdSettingsPage_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Settings Tab: This tab allows you to configure various settings for the application, including window behavior, appearance, performance, and other preferences.";
        }

        private void seLabel_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Move Application Label:  This allows you to move the application to different parts of the screen.";
        }

        private void cmdSettingsPage_MouseEnter_1(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripSettings' to a descriptive message.
            toolStripSettings.Text = "Settings Tab: This tab allows you to configure various settings for the application, including window behavior, appearance, performance, and other preferences.";
        }

        private void copyHistoryDGV_MouseEnter(object sender, EventArgs e)
        {
            // Sets the text of the 'toolStripCopyHistory' to a descriptive message.
            toolStripCopyHistory.Text = "Copy History Data Grid View: This grid displays the history of file operations performed by the application, including details such as source and target paths, operation type, date, and status.";
        }

        private void exportDataGridView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // Checks if the DataGridView has any rows. If not, the method exits.
            if (dataGridView1.Rows.Count == 0) return;

            // Checks if the clicked column header is the one at index 2 (likely the size column).
            if (e.ColumnIndex == 2)
            {
                // Finds the column named "BytesRaw" which is used for sorting.
                var numericCol = dataGridView1.Columns["BytesRaw"];
                // If the column is not found, the method exits.
                if (numericCol == null) return;

                // Sorts the DataGridView based on the "BytesRaw" column in either ascending or descending order.
                dataGridView1.Sort(numericCol,
                    sortAscending ? ListSortDirection.Ascending : ListSortDirection.Descending);

                // Toggles the sorting direction for the next click.
                sortAscending = !sortAscending;
            }
        }

        /// <summary>
        /// Updates the total count label to display the number of visible,
        /// non-new rows in <see cref="dataGridView1"/>.
        /// The count is formatted with a thousands separator.
        /// </summary>
        private void UpdateTotalCountLabel()
        {
            // Initializes a counter for visible and non-new rows.
            int totalItems = dataGridView1.Rows.Cast<DataGridViewRow>().Count(r => r.Visible && !r.IsNewRow);
            // Updates the 'fileCountOnLabel' with the total count, formatted with a thousands separator.
            fileCountOnLabel.Text = $"Total File/Folder Count: {totalItems:N0}";
        }

        /// <summary>
        /// Retrieves the value of a specific cell from a given row and column
        /// in <see cref="dataGridView1"/> and returns it as a string.
        /// Returns an empty string if the cell is null.
        /// </summary>
        /// <param name="row">The <see cref="DataGridViewRow"/> containing the cell.</param>
        /// <param name="col">The <see cref="DataGridViewColumn"/> identifying the cell's column.</param>
        /// <returns>The cell value as a string, or an empty string if the cell is null.</returns>
        private string GetCellValue(DataGridViewRow row, DataGridViewColumn col)
        {
            // Retrieves the value from a cell in a specified row and column.
            object val = row.Cells[col.Index].Value;
            // Returns the cell's value as a string, or an empty string if the value is null.
            return val == null ? "" : val.ToString();
        }

        /// <summary>
        /// Formats a cell value for export, adding a row index prefix for
        /// FileName or FilePath columns. Other columns return the plain value.
        /// </summary>
        /// <param name="col">The <see cref="DataGridViewColumn"/> to retrieve data from.</param>
        /// <param name="row">The <see cref="DataGridViewRow"/> containing the cell.</param>
        /// <param name="index">The zero-based row index, used when numbering file names or paths.</param>
        /// <returns>The formatted cell value as a string.</returns>
        private string FormatCellWithIndex(DataGridViewColumn col, DataGridViewRow row, int index)
        {
            // Retrieves the cell's value as a string using the helper method GetCellValue.
            string val = GetCellValue(row, col);

            // Checks if the column's data property name is "FileName" or "FilePath".
            if (col.DataPropertyName == "FileName" || col.DataPropertyName == "FilePath")
            {
                // If it is, formats the value by prepending a numbered index (starting from 1).
                return $"#{index + 1} - {val}";
            }
            else
            {
                // Otherwise, returns the value without any additional formatting.
                return val;
            }
        }

        /// <summary>
        /// Exports the contents of the provided DataGridView columns and rows to a
        /// plain text (.txt) file, with each row written on a separate line and
        /// column values formatted as "Header: Value" pairs.
        /// </summary>
        /// <param name="filePath">The destination file path for the exported text file.</param>
        /// <param name="cols">The list of DataGridView columns to export.</param>
        /// <param name="rows">The list of DataGridView rows to export.</param>
        private void ExportTxt(string filePath, List<DataGridViewColumn> cols, List<DataGridViewRow> rows)
        {
            // Creates a new StreamWriter to write to the specified file path. The 'using' statement ensures the writer is properly disposed of.
            using (var sw = new StreamWriter(filePath))
            {
                // Writes the total file count label text to the first line of the file.
                sw.WriteLine(fileCountOnLabel.Text);

                // Iterates through each DataGridViewRow in the provided list.
                for (int i = 0; i < rows.Count; i++)
                {
                    // Gets the current row.
                    var row = rows[i];
                    // Creates a collection of strings, where each string is formatted as "Header Text: Cell Value".
                    var parts = cols.Select(c => $"{c.HeaderText}: {FormatCellWithIndex(c, row, i)}");
                    // Joins the formatted strings with " || " and writes the entire line to the file.
                    sw.WriteLine(string.Join(" || ", parts));
                }
            }
        }


        /// <summary>
        /// Exports the DataGridView data to a CSV (Comma-Separated Values) file.
        /// Includes a commented first line showing the total file count, followed by
        /// a header row and data rows with proper CSV escaping.
        /// </summary>
        /// <param name="filePath">Destination CSV file path.</param>
        /// <param name="cols">The columns to include in the export.</param>
        /// <param name="rows">The DataGridView rows to export.</param>
        private void ExportCsv(string filePath, List<DataGridViewColumn> cols, List<DataGridViewRow> rows)
        {
            // Creates a new StreamWriter to write to the specified file path.
            using (var sw = new StreamWriter(filePath))
            {
                // Writes the total file count label text as a commented line.
                sw.WriteLine($"# {fileCountOnLabel.Text}");

                // Writes the header row by joining the header text of all columns, enclosed in quotes.
                sw.WriteLine(string.Join(",", cols.Select(c => $"\"{c.HeaderText}\"")));

                // Iterates through each DataGridViewRow.
                for (int i = 0; i < rows.Count; i++)
                {
                    // Gets the current row.
                    var row = rows[i];
                    // Creates a collection of cell values, formatted and escaped for CSV.
                    var values = cols.Select(c =>
                    {
                        // Gets the formatted cell value and escapes any double quotes by doubling them.
                        var val = FormatCellWithIndex(c, row, i).Replace("\"", "\"\"");
                        // Encloses the escaped value in double quotes.
                        return $"\"{val}\"";
                    });
                    // Joins the formatted cell values with a comma and writes the line to the file.
                    sw.WriteLine(string.Join(",", values));
                }
            }
        }

        /// <summary>
        /// Exports the DataGridView data to a JSON file.
        /// Produces an object with a total count and an array of row objects,
        /// where each property name matches the column header.
        /// </summary>
        /// <param name="filePath">Destination JSON file path.</param>
        /// <param name="cols">The columns to include in the export.</param>
        /// <param name="rows">The DataGridView rows to export.</param>
        private void ExportJson(string filePath, List<DataGridViewColumn> cols, List<DataGridViewRow> rows)
        {
            // Creates a new list to hold dictionaries, where each dictionary represents a row.
            var list = new List<Dictionary<string, object>>();

            // Loops through each row in the DataGridView.
            for (int i = 0; i < rows.Count; i++)
            {
                // Gets the current row and creates a new dictionary for it.
                var row = rows[i];
                var dict = new Dictionary<string, object>();

                // Loops through each column.
                foreach (var col in cols)
                {
                    // Adds a key-value pair to the dictionary, using the column header text as the key and the formatted cell value as the value.
                    dict[col.HeaderText] = FormatCellWithIndex(col, row, i);
                }
                // Adds the dictionary to the list.
                list.Add(dict);
            }

            // Creates an anonymous object to act as the root of the JSON structure, including the total count and the list of items.
            var wrapper = new
            {
                TotalCount = fileCountOnLabel.Text,
                Items = list
            };

            // Serializes the wrapper object to a JSON string with indentation for readability.
            var json = System.Text.Json.JsonSerializer.Serialize(wrapper, new JsonSerializerOptions { WriteIndented = true });
            // Writes the JSON string to the specified file.
            File.WriteAllText(filePath, json);
        }

        /// <summary>
        /// Exports the DataGridView data to an XML file.
        /// Creates a root &lt;Export&gt; element with child elements for total count and each row.
        /// Column headers are encoded as valid XML element names.
        /// </summary>
        /// <param name="filePath">Destination XML file path.</param>
        /// <param name="cols">The columns to include in the export.</param>
        /// <param name="rows">The DataGridView rows to export.</param>
        private void ExportXml(string filePath, List<DataGridViewColumn> cols, List<DataGridViewRow> rows)
        {
            // Creates a new XML document.
            var doc = new XDocument(
                // The root element is "Export".
                new XElement("Export",
                    // Adds an element for the total count.
                    new XElement("TotalCount", fileCountOnLabel.Text),
                    // Adds an element to contain all the rows.
                    new XElement("Rows",
                        // Projects each row into a new "Row" XML element.
                        rows.Select((r, i) =>
                            new XElement("Row",
                                // Projects each column within the row into an XML element.
                                cols.Select(c =>
                                    // Creates an element with a sanitized header text as the name and the formatted cell value as the content.
                                    new XElement(XmlConvert.EncodeName(c.HeaderText.Replace(" ", "")), FormatCellWithIndex(c, r, i))
                                )
                            )
                        )
                    )
                )
            );
            // Saves the XML document to the specified file path.
            doc.Save(filePath);
        }

        /// <summary>
        /// Exports the DataGridView data to an RTF (Rich Text Format) file.
        /// Generates an RTF document containing a table with headers and data,
        /// including proper escaping of RTF control characters.
        /// </summary>
        /// <param name="filePath">Destination RTF file path.</param>
        /// <param name="cols">The columns to include in the export.</param>
        /// <param name="rows">The DataGridView rows to export.</param>
        private void ExportRtf(string filePath, List<DataGridViewColumn> cols, List<DataGridViewRow> rows)
        {
            // Defines a local function to escape characters for RTF format.
            string EscapeRtf(string text)
            {
                // If the text is null or empty, returns an empty string.
                if (string.IsNullOrEmpty(text)) return "";
                // Replaces backslashes, curly braces, and line breaks with their RTF escape sequences.
                return text
                    .Replace(@"\", @"\\")
                    .Replace("{", @"\{")
                    .Replace("}", @"\}")
                    .Replace("\r\n", @"\line ")
                    .Replace("\n", @"\line ")
                    .Replace("\r", @"\line ");
            }

            // Defines a local function to insert line breaks into a string.
            string InsertLineBreaks(string text, int maxChars = 50)
            {
                // If the text is null or empty, returns an empty string.
                if (string.IsNullOrEmpty(text)) return "";
                var sb = new System.Text.StringBuilder();
                // Iterates through the string, appending a line break after a certain number of characters.
                for (int i = 0; i < text.Length; i++)
                {
                    sb.Append(text[i]);
                    if ((i + 1) % maxChars == 0)
                        sb.Append(@"\line ");
                }
                return sb.ToString();
            }

            // Creates a new StreamWriter to write to the specified file.
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Writes the RTF header.
                sw.WriteLine(@"{\rtf1\ansi\deff0");

                // Writes the total count label text in bold, followed by a paragraph break.
                sw.WriteLine(@"\b " + EscapeRtf(fileCountOnLabel.Text) + @"\b0 \par");

                // Sets the cell width in twips (a unit of measurement in RTF).
                int cellWidthTwips = 1500;
                int totalWidth = cellWidthTwips * cols.Count;

                // Starts a table row definition.
                sw.Write(@"\trowd\trgaph108 ");
                // Defines the horizontal position of each cell.
                for (int i = 0; i < cols.Count; i++)
                {
                    sw.Write(@"\cellx" + cellWidthTwips * (i + 1) + " ");
                }
                sw.WriteLine();

                // Writes the header row, with each header text in bold inside a table cell.
                sw.Write(@"\b ");
                foreach (var col in cols)
                {
                    sw.Write(EscapeRtf(col.HeaderText) + @"\cell ");
                }
                // Ends the bold formatting and the row.
                sw.WriteLine(@"\b0 \row");

                // Loops through each data row.
                for (int i = 0; i < rows.Count; i++)
                {
                    var row = rows[i];
                    // Starts a new table row.
                    sw.Write(@"\trowd\trgaph108 ");
                    // Defines the cell positions for the current row.
                    for (int c = 0; c < cols.Count; c++)
                    {
                        sw.Write(@"\cellx" + cellWidthTwips * (c + 1) + " ");
                    }
                    sw.WriteLine();

                    // Loops through each column to write cell data.
                    foreach (var col in cols)
                    {
                        // Gets and formats the cell value, then escapes it for RTF.
                        string val = FormatCellWithIndex(col, row, i);
                        val = EscapeRtf(InsertLineBreaks(val));
                        // Writes the cell value and the cell end delimiter.
                        sw.Write(val + @"\cell ");
                    }
                    // Ends the current table row.
                    sw.WriteLine(@"\row");
                }

                // Writes the closing curly brace for the RTF document.
                sw.WriteLine("}");
            }
        }
        /// <summary>
        /// Exports the DataGridView data to an Excel (.xlsx) file using the ClosedXML library.
        /// Creates a formatted worksheet with a merged title cell, bold headers,
        /// auto-adjusted column widths, and thin borders.
        /// </summary>
        /// <param name="filePath">Destination Excel file path.</param>
        /// <param name="cols">The columns to include in the export.</param>
        /// <param name="rows">The DataGridView rows to export.</param>
        private void ExportXlsx(string filePath, List<DataGridViewColumn> cols, List<DataGridViewRow> rows)
        {
            // Creates a new Excel workbook using the ClosedXML library.
            using (var wb = new XLWorkbook())
            {
                // Adds a new worksheet to the workbook.
                var ws = wb.Worksheets.Add("Export");

                // Writes the total count to the first cell (1, 1).
                ws.Cell(1, 1).Value = fileCountOnLabel.Text;
                // Merges the first row's cells to span the width of the data.
                ws.Range(1, 1, 1, cols.Count).Merge();
                // Applies bold font and center alignment to the merged cell.
                ws.Cell(1, 1).Style.Font.Bold = true;
                ws.Cell(1, 1).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;

                // Loops through the columns to create the header row.
                for (int i = 0; i < cols.Count; i++)
                {
                    // Gets a cell in the second row (for headers).
                    var cell = ws.Cell(2, i + 1);
                    // Sets the header text as the cell value and applies formatting.
                    cell.Value = cols[i].HeaderText;
                    cell.Style.Font.Bold = true;
                    cell.Style.Fill.BackgroundColor = XLColor.LightGray;
                    cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                }

                // Loops through each data row and column to populate the worksheet with data.
                for (int r = 0; r < rows.Count; r++)
                {
                    for (int c = 0; c < cols.Count; c++)
                    {
                        // Gets a cell in the data region of the worksheet.
                        var cell = ws.Cell(r + 3, c + 1);
                        // Sets the formatted cell value and applies left alignment.
                        cell.Value = FormatCellWithIndex(cols[c], rows[r], r);
                        cell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                    }
                }

                // Adjusts the width of all columns to fit their content.
                ws.Columns().AdjustToContents();
                // Defines the range of the table (header + data).
                var range = ws.Range(1, 1, rows.Count + 2, cols.Count);
                // Applies thin borders to the outside and inside of the table range.
                range.Style.Border.OutsideBorder = XLBorderStyleValues.Thin;
                range.Style.Border.InsideBorder = XLBorderStyleValues.Thin;

                // Saves the workbook to the specified file path.
                wb.SaveAs(filePath);
            }
        }

        /// <summary>
        /// Exports the DataGridView data to a Markdown file.
        /// Creates a Markdown table with a header, separator row, and escaped cell values.
        /// </summary>
        /// <param name="filePath">Destination Markdown file path.</param>
        /// <param name="cols">The columns to include in the export.</param>
        /// <param name="rows">The DataGridView rows to export.</param>
        private void ExportMarkdown(string filePath, List<DataGridViewColumn> cols, List<DataGridViewRow> rows)
        {
            // Creates a new StreamWriter to write to the specified file.
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Writes the total count label text.
                sw.WriteLine(fileCountOnLabel.Text);

                // Writes the Markdown table header row, joining column header texts.
                sw.WriteLine("| " + string.Join(" | ", cols.Select(c => c.HeaderText)) + " |");
                // Writes the Markdown table separator row.
                sw.WriteLine("|" + string.Join("|", cols.Select(c => "---")) + "|");

                // Loops through each row to write the table data.
                for (int i = 0; i < rows.Count; i++)
                {
                    // Gets the current row.
                    var row = rows[i];
                    // Creates a collection of cell values, with the pipe character '|' escaped for Markdown.
                    var cells = cols.Select(c => FormatCellWithIndex(c, row, i).Replace("|", "\\|"));
                    // Writes the Markdown table row by joining the cell values.
                    sw.WriteLine("| " + string.Join(" | ", cells) + " |");
                }
            }
        }

        /// <summary>
        /// Opens a SaveFileDialog to prompt the user for a file path and extension,
        /// then triggers a dynamic export based on the selected file type.
        /// </summary>
        /// <param name="filter">The file type filter string for the dialog (e.g., "CSV Files|*.csv").</param>
        /// <param name="defaultExt">The default file extension (e.g., ".csv").</param>
        private void ExportWithDialog(string filter, string defaultExt)
        {
            // Creates a SaveFileDialog to prompt the user for a file path.
            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                // Sets the filter for file types and the default extension.
                saveFileDialog.Filter = filter;
                saveFileDialog.DefaultExt = defaultExt.TrimStart('.');
                saveFileDialog.Title = "Save Export File";

                // Shows the dialog and checks if the user clicked OK.
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Gets the selected file path and its extension.
                    string filePath = saveFileDialog.FileName;
                    string ext = System.IO.Path.GetExtension(filePath).ToLower();

                    // Calls the dynamic export method with the chosen path and extension.
                    ExportDataGridViewDynamic(filePath, ext);
                }
            }
        }

        /// <summary>
        /// Dynamically exports the DataGridView data to the specified file format
        /// based on the file extension, after preparing the appropriate column set.
        /// </summary>
        /// <param name="filePath">Destination file path.</param>
        /// <param name="fileExtension">The selected file extension (e.g., ".csv").</param>
        private void ExportDataGridViewDynamic(string filePath, string fileExtension)
        {
            // Creates a list to hold the columns to be exported.
            List<DataGridViewColumn> exportColumns = new List<DataGridViewColumn>();

            // Checks which checkbox is checked to determine which columns to export.
            if (fullPathsCheckBox.Checked)
            {
                // If "Full Paths" is checked, adds the FilePath, ItemType, and FileSize columns if they are visible.
                AddColumnIfVisible("FilePath", exportColumns);
                AddColumnIfVisible("ItemType", exportColumns);
                AddColumnIfVisible("FileSize", exportColumns);
            }
            else if (onlyNamesCheckBox.Checked)
            {
                // If "Only Names" is checked, adds the FileName, ItemType, and FileSize columns if they are visible.
                AddColumnIfVisible("FileName", exportColumns);
                AddColumnIfVisible("ItemType", exportColumns);
                AddColumnIfVisible("FileSize", exportColumns);
            }
            else
            {
                // If neither is checked, shows a warning message and exits the method.
                MessageBox.Show("Please check either Full Paths or Only Names before exporting.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Retrieves all visible and non-new rows from the DataGridView.
            var exportRows = dataGridView1.Rows.Cast<DataGridViewRow>()
                .Where(r => r.Visible && !r.IsNewRow)
                .ToList();

            // Updates the total file count label with the number of rows to be exported.
            int totalItems = exportRows.Count;
            fileCountOnLabel.Text = $"Total File/Folder Count: {totalItems:N0}";

            try
            {
                // Attempts to delete the file if it already exists to prevent an error.
                if (File.Exists(filePath))
                    File.Delete(filePath);

                // Uses a switch statement to call the appropriate export method based on the file extension.
                switch (fileExtension)
                {
                    case ".txt":
                        ExportTxt(filePath, exportColumns, exportRows);
                        break;
                    case ".csv":
                        ExportCsv(filePath, exportColumns, exportRows);
                        break;
                    case ".json":
                        ExportJson(filePath, exportColumns, exportRows);
                        break;
                    case ".xml":
                        ExportXml(filePath, exportColumns, exportRows);
                        break;
                    case ".xlsx":
                        ExportXlsx(filePath, exportColumns, exportRows);
                        break;
                    case ".rtf":
                        ExportRtf(filePath, exportColumns, exportRows);
                        break;
                    case ".md":
                        ExportMarkdown(filePath, exportColumns, exportRows);
                        break;
                    default:
                        MessageBox.Show("Unsupported file type.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                }

                // Displays a success message to the user.
                MessageBox.Show($"Exported successfully to: {filePath}", "Export Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                // Catches any exceptions that occur during the export process and shows an error message.
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Adds a DataGridView column to a list if it is visible and matches the specified DataPropertyName.
        /// </summary>
        /// <param name="dataPropertyName">The DataPropertyName of the column to search for.</param>
        /// <param name="list">The list to which the column will be added if found.</param>
        private void AddColumnIfVisible(string dataPropertyName, List<DataGridViewColumn> list)
        {
            // Finds the first column in the DataGridView that matches the specified data property name and is visible.
            var col = dataGridView1.Columns
                .Cast<DataGridViewColumn>()
                .FirstOrDefault(c => c.DataPropertyName == dataPropertyName && c.Visible);

            // If a matching column is found, it is added to the provided list.
            if (col != null)
                list.Add(col);
        }












        private void filesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            // This is an event handler for when the selection in the DataGridView changes.
            // The method body is currently empty, meaning no action is taken on this event.
        }

        private void saveAutoCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            // This event handler is triggered when the state of the 'saveAutoCheckBox' changes.
            // It saves the new checked state to the application's user settings.
            Properties.Settings.Default.AutoSaveSettings = saveAutoCheckBox.Checked;
        }



        private bool _isUpdatingLanguage = false;
        private string _savedSkinName;
        int skinNum = 0;


        private void languageComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_isUpdatingLanguage || _isLoadingForm) return; // Guard against recursion and initial load
            _isUpdatingLanguage = true;

            try
            {
                string display = languageComboBox.SelectedItem?.ToString() ?? string.Empty;

                (string key, string culture) = display switch
                {
                    "Español" or "Spanish" => ("Spanish", "es-ES"),
                    "Français" or "French" => ("French", "fr-FR"),
                    "Deutsch" or "German" => ("German", "de-DE"),
                    _ => ("English", "en")
                };

                // Save settings
                CopyThatProgram.Properties.Settings.Default.Language = key;
                CopyThatProgram.Properties.Settings.Default.Save();

                // Change culture
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(culture);
                Thread.CurrentThread.CurrentCulture = new CultureInfo(culture);

                // Temporarily suspend layout
                this.SuspendLayout();

                // Update language combo
                languageComboBox.Items.Clear();
                languageComboBox.Items.AddRange(key switch
                {
                    "Spanish" => new[] { "Inglés", "Francés", "Deutsch", "Español" },
                    "French" => new[] { "Anglais", "Français", "Allemand", "Espagnol" },
                    "German" => new[] { "Englisch", "Französisch", "Deutsch", "Spanisch" },
                    _ => new[] { "English", "French", "German", "Spanish" }
                });
                languageComboBox.SelectedItem = LangKeyToDisplay[key];

                // Apply localized .resx resources
                var resMan = new ComponentResourceManager(typeof(mainForm));
                ApplyAllResources(resMan);

                if (key == "Spanish")
                    ApplyManualSpanishUpdates();
                else
                    ApplyManualEnglishUpdates();

                // Remember saved skin (in English)
                _savedSkinName = CopyThatProgram.Properties.Settings.Default.Skin ?? "Light Mode";

                // Update skins combo list with new language
                UpdateSkinsComboBoxItems(key);

                // Select the previously saved skin (in current language) BEFORE applying it
                SelectSkinInCombo(_savedSkinName);

                // Apply the skin theme colors - handle custom colors specially
                if (_savedSkinName == "Custom Color")
                {
                    var savedBack = CopyThatProgram.Properties.Settings.Default.CustomBackColor;
                    var savedFore = CopyThatProgram.Properties.Settings.Default.CustomForeColor;

                    if (savedBack != Color.Empty && savedBack != Color.Transparent &&
                        savedFore != Color.Empty && savedFore != Color.Transparent)
                    {
                        ApplySkin("Custom Color", savedFore, savedBack);
                    }
                    else
                    {
                        ApplySkin("Light Mode");
                    }
                }
                else
                {
                    ApplySkin(_savedSkinName);
                }

                // Layout corrections
                languageLabel.Left = skinsLabel.Left + skinsLabel.Width - languageLabel.Width;
                fromLabel.Left = fileNameLabel.Left + fileNameLabel.Width - fromLabel.Width;
                targetLabel.Left = fromLabel.Left + fromLabel.Width - targetLabel.Width;

                this.ResumeLayout(true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error changing language: {ex.Message}", "Error",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                _isUpdatingLanguage = false;
            }
        }







        // This helper applies the .resx resources (your original code)
        private void ApplyAllResources(ComponentResourceManager resMan)
        {
            foreach (TabPage page in tabControl1.TabPages)
            {
                ApplyResourcesToControl(resMan, page);
            }
            resMan.ApplyResources(this, "$this");
        }

        // ==================  SPANISH  ==================
        private void ApplyManualSpanishUpdates()
        {
            try
            {
                /* ---------- grid headers ---------- */
                dataGridView1.Columns[0].HeaderText = "Nombre del Archivo";
                dataGridView1.Columns[1].HeaderText = "Ruta del Archivo";
                dataGridView1.Columns[2].HeaderText = "Tipo";
                dataGridView1.Columns[3].HeaderText = "Tamaño del Archivo";
                dataGridView1.Columns[4].HeaderText = "Estado";

                dataGridView2.Columns[0].HeaderText = "Nombre del Archivo";
                dataGridView2.Columns[1].HeaderText = "Ruta del Archivo";
                dataGridView2.Columns[2].HeaderText = "Tipo";
                dataGridView2.Columns[3].HeaderText = "Tamaño del Archivo";
                dataGridView2.Columns[4].HeaderText = "Estado";

                copyHistoryDGV.Columns[0].HeaderText = "Tipo de operación";
                copyHistoryDGV.Columns[1].HeaderText = "Ruta(s) de archivo de origen";
                copyHistoryDGV.Columns[2].HeaderText = "Ruta(s) de archivo de destino";
                copyHistoryDGV.Columns[3].HeaderText = "Tamaño total de carpeta(s)";

                skippedDataGridView.Columns[0].HeaderText = "Estado";
                skippedDataGridView.Columns[1].HeaderText = "Ruta del archivo de origen";
                skippedDataGridView.Columns[2].HeaderText = "Ruta del archivo de destino";
                skippedDataGridView.Columns[3].HeaderText = "Nombre del archivo";
                skippedDataGridView.Columns[4].HeaderText = "Tamaño del archivo";

                filesDataGridView.Columns[0].HeaderText = "Nombre";
                filesDataGridView.Columns[1].HeaderText = "Ruta";
                filesDataGridView.Columns[2].HeaderText = "Tipo";
                filesDataGridView.Columns[3].HeaderText = "Tamaño";
                filesDataGridView.Columns[4].HeaderText = "Estado";

                /* ---------- other controls ---------- */
                searchTextBox.PlaceholderText = "Ingrese el nombre del archivo o carpeta a buscar...";

                onFinishComboBox.Items.Clear();
                onFinishMultiComboBox.Items.Clear();
                onFinishComboBox.Items.AddRange(new[]{ "No hacer nada", "Suspender", "Cerrar sesión",
                                      "Salir del programa", "Apagar" });

                onFinishMultiComboBox.Items.AddRange(new[]{ "No hacer nada", "Suspender", "Cerrar sesión",
                                      "Salir del programa", "Apagar" });
                if (onFinishComboBox.SelectedIndex == -1) onFinishComboBox.SelectedIndex = 0;
                if (onFinishMultiComboBox.SelectedIndex == -1) onFinishMultiComboBox.SelectedIndex = 0;
                copyMoveDeleteComboBox.Items.Clear();
                copyMoveDeleteComboBox.Items.AddRange(new[] { "Copiar archivos", "Mover archivos", "Borrado seguro" });
                if (copyMoveDeleteComboBox.SelectedIndex == -1) copyMoveDeleteComboBox.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating Spanish UI: {ex.Message}");
            }
        }

        // ==================  ENGLISH  ==================
        private void ApplyManualEnglishUpdates()
        {
            try
            {
                /* ---------- grid headers ---------- */
                dataGridView1.Columns[0].HeaderText = "File's Name";
                dataGridView1.Columns[1].HeaderText = "File's Path";
                dataGridView1.Columns[2].HeaderText = "Type";
                dataGridView1.Columns[3].HeaderText = "File's Size";
                dataGridView1.Columns[4].HeaderText = "Status";

                dataGridView2.Columns[0].HeaderText = "File's Name";
                dataGridView2.Columns[1].HeaderText = "File's Path";
                dataGridView2.Columns[2].HeaderText = "Type";
                dataGridView2.Columns[3].HeaderText = "File's Size";
                dataGridView2.Columns[4].HeaderText = "Status";

                copyHistoryDGV.Columns[0].HeaderText = "Operation Type";
                copyHistoryDGV.Columns[1].HeaderText = "Source File Path(s)";
                copyHistoryDGV.Columns[2].HeaderText = "Destination File Path(s)";
                copyHistoryDGV.Columns[3].HeaderText = "Total Size of Dir(s)";

                skippedDataGridView.Columns[0].HeaderText = "Status";
                skippedDataGridView.Columns[1].HeaderText = "Source File's Path";
                skippedDataGridView.Columns[2].HeaderText = "Destination File's Path";
                skippedDataGridView.Columns[3].HeaderText = "File's Name";
                skippedDataGridView.Columns[4].HeaderText = "File's Size";

                filesDataGridView.Columns[0].HeaderText = "Name";
                filesDataGridView.Columns[1].HeaderText = "Path";
                filesDataGridView.Columns[2].HeaderText = "Type";
                filesDataGridView.Columns[3].HeaderText = "Size";
                filesDataGridView.Columns[4].HeaderText = "Status";

                /* ---------- other controls ---------- */
                searchTextBox.PlaceholderText = "Enter File/Folder Name to Search For...";

                onFinishComboBox.Items.Clear();
                onFinishComboBox.Items.AddRange(new[] { "Do Nothing", "Sleep", "Log Off", "Exit Program", "Shut Down" });
                if (onFinishComboBox.SelectedIndex == -1) onFinishComboBox.SelectedIndex = 0;

                onFinishMultiComboBox.Items.Clear();
                onFinishMultiComboBox.Items.AddRange(new[] { "Do Nothing", "Sleep", "Log Off", "Exit Program", "Shut Down" });
                if (onFinishMultiComboBox.SelectedIndex == -1) onFinishMultiComboBox.SelectedIndex = 0;

                copyMoveDeleteComboBox.Items.Clear();
                copyMoveDeleteComboBox.Items.AddRange(new[] { "Copy Files", "Move Files", "Secure Delete" });
                if (copyMoveDeleteComboBox.SelectedIndex == -1) copyMoveDeleteComboBox.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error updating English UI: {ex.Message}");
            }
        }

        /// <summary>
        /// Recursively applies localized resources to a control and all of its child controls.
        /// Uses the control's <see cref="Control.Name"/> as the resource key so that
        /// properties like text, size, and other localizable settings are updated
        /// according to the current culture.
        /// </summary>
        /// <param name="res">
        /// The <see cref="ComponentResourceManager"/> that provides localized resources.
        /// </param>
        /// <param name="ctrl">
        /// The root <see cref="System.Windows.Forms.Control"/> to which resources will be applied.
        /// </param>
        private static void ApplyResourcesToControl(ComponentResourceManager res, System.Windows.Forms.Control ctrl)
        {
            // Apply resources to the current control using its name as the key
            res.ApplyResources(ctrl, ctrl.Name);

            // Recursively apply resources to all child controls to ensure
            // every nested control on the form is localized
            foreach (System.Windows.Forms.Control child in ctrl.Controls)
                ApplyResourcesToControl(res, child);
        }



        /// <summary>
        /// Applies a visual skin theme by its English key name.
        /// </summary>
        /// <param name="englishKey">The English key (e.g. "Light Mode").</param>
        /// <param name="foreColor">Optional override for text color.</param>
        /// <param name="backColor">Optional override for background color.</param>
        /// 

        /// <summary>
        /// Applies a visual skin theme by its English key name.
        /// </summary>

        private void rollUpLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse pointer enters the area of the 'rollUpLabel'.
            // It updates the text of multiple ToolStripStatusLabels to provide a tooltip description.
            statusLabel.Text = "Roll Up Button: This button scrolls the form up, allowing you to view files that are currently not visible in the data grid view.";
            toolStripCopyHistory.Text = "Roll Up Button: This button scrolls the form up, allowing you to view files that are currently not visible in the data grid view.";
            toolStripExclusions.Text = "Roll Up Button: This button scrolls the form up, allowing you to view files that are currently not visible in the data grid view.";
            toolStripMulti.Text = "Roll Up Button: This button scrolls the form up, allowing you to view files that are currently not visible in the data grid view.";
            toolStripSettings.Text = "Roll Up Button: This button scrolls the form up, allowing you to view files that are currently not visible in the data grid view.";
            toolStripSkipped.Text = "Roll Up Button: This button scrolls the form up, allowing you to view files that are currently not visible in the data grid view.";
        }

        private void rollUpLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the 'rollUpLabel' is clicked.
            // It calls the ToggleRollUp() method, which likely handles the form's scrolling functionality.
            ToggleRollUp();
        }

        private void rollDownLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse pointer enters the 'rollDownLabel'.
            // It updates the text of multiple ToolStripStatusLabels with a tooltip description for the roll-down button.
            statusLabel.Text = "Roll Down Button: This button scrolls the form down, allowing you to view files that are currently not visible in the data grid view.";
            toolStripCopyHistory.Text = "Roll Down Button: This button scrolls the form down, allowing you to view files that are currently not visible in the data grid view.";
            toolStripExclusions.Text = "Roll Down Button: This button scrolls the form down, allowing you to view files that are currently not visible in the data grid view.";
            toolStripMulti.Text = "Roll Down Button: This button scrolls the form down, allowing you to view files that are currently not visible in the data grid view.";
            toolStripSettings.Text = "Roll Down Button: This button scrolls the form down, allowing you to view files that are currently not visible in the data grid view.";
            toolStripSkipped.Text = "Roll Down Button: This button scrolls the form down, allowing you to view files that are currently not visible in the data grid view.";
        }

        private void rollDownLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the 'rollDownLabel' is clicked.
            // It calls the ToggleRollDown() method, which likely handles the form's scrolling.
            ToggleRollDown();
        }

        private void settingsLabel_Click(object sender, EventArgs e)
        {
            try
            {
                // Sets the selected tab in the tab control to the settings page.
                tabControl1.SelectedTab = cmdSettingsPage;
                // If the auto-save checkbox is checked, it saves the application settings.
                if (saveAutoCheckBox.Checked)
                {
                    Properties.Settings.Default.Save();
                }

                // Calls a method to update the saved checkboxes based on settings.
                editSavedCheckBoxes();


                // Updates the form's title label based on whether it's the "Pro" version or not.
                if (proVersion)
                {
                    titleLabel.Text = "Copy That v1.0 Pro By: Havoc - Settings";
                }
                else
                {
                    titleLabel.Text = "Copy That v1.0 By: Havoc - Settings";
                }

                // Enables all controls on the form.
                EnableAllControls(this);
                // Disables specific buttons related to ongoing operations.
                pauseResumeButton.Enabled = false;
                cancelButton.Enabled = false;
                skipButton.Enabled = false;
            }
            catch { } // Catches and ignores any exceptions that occur. This is generally not good practice but is present in the code.
        }

        private void settingsLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse pointer enters the 'settingsLabel'.
            // It updates the text of multiple ToolStripStatusLabels with a tooltip description for the settings button.
            statusLabel.Text = "Settings Button: This button opens the settings dialog, allowing you to configure various options for the application, such as buffer size, multi-threading, and operation preferences.";
            toolStripCopyHistory.Text = "Settings Button: This button opens the settings dialog, allowing you to configure various options for the application, such as buffer size, multi-threading, and operation preferences.";
            toolStripExclusions.Text = "Settings Button: This button opens the settings dialog, allowing you to configure various options for the application, such as buffer size, multi-threading, and operation preferences.";
            toolStripMulti.Text = "Settings Button: This button opens the settings dialog, allowing you to configure various options for the application, such as buffer size, multi-threading, and operation preferences.";
            toolStripSettings.Text = "Settings Button: This button opens the settings dialog, allowing you to configure various options for the application, such as buffer size, multi-threading, and operation preferences.";
            toolStripSkipped.Text = "Settings Button: This button opens the settings dialog, allowing you to configure various options for the application, such as buffer size, multi-threading, and operation preferences.";
        }

        private void ScrollTimer_Tick(object sender, EventArgs e)
        {
            // This event handler is triggered by the 'ScrollTimer' at regular intervals.
            // It decrements the Top property of several controls, causing them to move up the form.
            copyThatPB.Top -= scrollSpeed;
            havocSoftwarePB.Top -= scrollSpeed;
            aboutCTLabel.Top -= scrollSpeed;

            // Checks if the 'aboutCTLabel' has scrolled completely out of view (its bottom is at or above the top of the form).
            if (aboutCTLabel.Bottom <= 0)
            {
                // Resets the position of the controls to the bottom of the about panel, creating a continuous scroll effect.
                int resetTop = aboutPanel.Height;
                copyThatPB.Top = resetTop;
                havocSoftwarePB.Top = resetTop;
                aboutCTLabel.Top = resetTop + copyThatPB.Height + 10;
            }
        }

        private void allAboutLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the 'allAboutLabel' is clicked.
            // Stops and disposes of the existing scroll timer if it exists.
            scrollTimer?.Stop();
            if (scrollTimer != null)
            {
                scrollTimer.Tick -= ScrollTimer_Tick;
            }
            scrollTimer?.Dispose();

            // Creates a new Timer object for scrolling.
            scrollTimer = new Timer();
            // Sets the timer's interval to 25 milliseconds.
            scrollTimer.Interval = 25;
            // Attaches the ScrollTimer_Tick method to the timer's Tick event.
            scrollTimer.Tick += ScrollTimer_Tick;
            // Starts the timer.
            scrollTimer.Start();

            // Changes the selected tab to the "About" page.
            tabControl1.SelectedTab = cmdAboutPage;

            // Updates the title label based on whether it's the "Pro" version or not.
            if (proVersion)
            {
                titleLabel.Text = "Copy That v1.0 Pro By: Havoc - About";
            }
            else
            {
                titleLabel.Text = "Copy That v1.0 By: Havoc - About";
            }

            // Defines constants for logo size and padding.
            int logoWidth = 300;
            int logoHeight = 300;
            int logoPadding = 10;

            // Sets the size and picture box mode for the logo picture boxes.
            copyThatPB.Width = logoWidth;
            copyThatPB.Height = logoHeight;
            copyThatPB.SizeMode = PictureBoxSizeMode.Zoom;

            havocSoftwarePB.Width = logoWidth;
            havocSoftwarePB.Height = logoHeight;
            havocSoftwarePB.SizeMode = PictureBoxSizeMode.Zoom;

            // Calculates the total width of the logos and the starting X position to center them.
            int totalLogoWidth = (logoWidth * 2) + logoPadding;
            int startX = (aboutPanel.Width - totalLogoWidth) / 2;

            // Sets the initial position of the logo picture boxes.
            copyThatPB.Left = startX;
            copyThatPB.Top = aboutPanel.Height;

            havocSoftwarePB.Left = startX + logoWidth + logoPadding;
            havocSoftwarePB.Top = aboutPanel.Height;


            // Configures the "About" label's properties for auto-sizing and alignment.
            aboutCTLabel.AutoSize = true;
            aboutCTLabel.MaximumSize = new Size(aboutPanel.Width - 20, 0);
            aboutCTLabel.TextAlign = ContentAlignment.TopCenter;

            // Sets the position of the "About" label relative to the logos.
            aboutCTLabel.Left = (aboutPanel.Width - aboutCTLabel.Width) / 2;
            aboutCTLabel.Top = copyThatPB.Top + logoHeight + 10;

            // Checks if the controls are already on the "aboutPanel" and adds them if they aren't.
            if (!aboutPanel.Controls.Contains(copyThatPB))
                aboutPanel.Controls.Add(copyThatPB);
            if (!aboutPanel.Controls.Contains(havocSoftwarePB))
                aboutPanel.Controls.Add(havocSoftwarePB);
            if (!aboutPanel.Controls.Contains(aboutCTLabel))
                aboutPanel.Controls.Add(aboutCTLabel);
        }

        private void minimizeLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the 'minimizeLabel' is clicked.
            // Checks if the "Minimize to System Tray" checkbox is checked.
            if (minimizeSystemTrayCheckBox.Checked == true)
            {
                // Re-checks the checkbox state from application settings.
                minimizeSystemTrayCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.MinimizeToTray;
                // Makes the notify icon in the system tray visible.
                notifyIcon1.Visible = true;
                // Minimizes the form window.
                this.WindowState = FormWindowState.Minimized;

                // Updates the text of the system tray icon based on the application version and minimize setting.
                if (proVersion)
                {
                    if (minimizeSystemTrayCheckBox.Checked)
                    {
                        notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc || Double-Click To Open";
                    }
                    else
                    {
                        notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc";
                    }
                }
                else
                {
                    if (minimizeSystemTrayCheckBox.Checked)
                    {
                        notifyIcon1.Text = "Copy That v1.0 By: Havoc || Double-Click To Open";
                    }
                    else
                    {
                        notifyIcon1.Text = "Copy That v1.0 By: Havoc";
                    }
                }
            }
            else
            {
                // If the "Minimize to System Tray" checkbox is not checked, it performs a standard minimize.
                // The following lines are redundant as they are the same as the 'if' block.
                minimizeSystemTrayCheckBox.Checked = CopyThatProgram.Properties.Settings.Default.MinimizeToTray;
                notifyIcon1.Visible = false;
                this.WindowState = FormWindowState.Minimized;

                // The logic below is identical to the 'if' block, which is also redundant.
                if (proVersion)
                {
                    if (minimizeSystemTrayCheckBox.Checked)
                    {
                        notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc || Double-Click To Open";
                    }
                    else
                    {
                        notifyIcon1.Text = "Copy That v1.0 Pro By: Havoc";
                    }
                }
                else
                {
                    if (minimizeSystemTrayCheckBox.Checked)
                    {
                        notifyIcon1.Text = "Copy That v1.0 By: Havoc || Double-Click To Open";
                    }
                    else
                    {
                        notifyIcon1.Text = "Copy That v1.0 By: Havoc";
                    }
                }
            }
        }

        private void minimizeLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse pointer enters the 'minimizeLabel'.
            // It updates the text of multiple ToolStripStatusLabels with a tooltip description.
            statusLabel.Text = "Minimize Button: This button minimizes the application to the taskbar or the system tray, allowing you to keep it running in the background without closing it.";
            toolStripCopyHistory.Text = "Minimize Button: This button minimizes the application to the taskbar or the system tray, allowing you to keep it running in the background without closing it.";
            toolStripExclusions.Text = "Minimize Button: This button minimizes the application to the taskbar or the system tray, allowing you to keep it running in the background without closing it.";
            toolStripMulti.Text = "Minimize Button: This button minimizes the application to the taskbar or the system tray, allowing you to keep it running in the background without closing it.";
            toolStripSettings.Text = "Minimize Button: This button minimizes the application to the taskbar or the system tray, allowing you to keep it running in the background without closing it.";
            toolStripSkipped.Text = "Minimize Button: This button minimizes the application to the taskbar or the system tray, allowing you to keep it running in the background without closing it.";
        }

        private async void exitLabel_Click(object sender, EventArgs e)
        {
            // Check if the "Minimize to System Tray" checkbox is checked
            if (minimizeSystemTrayCheckBox.Checked)
            {
                WindowState = FormWindowState.Minimized;
                return;
            }

            // Debug output (remove these after testing)
            // MessageBox.Show(skinsComboBox.SelectedItem.ToString());
            // MessageBox.Show(languageComboBox.SelectedItem.ToString());

            // Convert the display name back to the key we really want to store
            string skinKey = ToEn(skinsComboBox.SelectedItem.ToString());
            CopyThatProgram.Properties.Settings.Default.Skin = skinKey;

            // Save language
            CopyThatProgram.Properties.Settings.Default.Language = LangKeyToDisplay.FirstOrDefault(
                                                                        x => x.Value.Equals(languageComboBox.SelectedItem.ToString(),
                                                                                            StringComparison.OrdinalIgnoreCase))
                                                                        .Key ?? "English";

            // If custom color is selected, ensure the colors are saved
            if (skinKey == "Custom Color")
            {
                // Save current form colors as custom colors
                CopyThatProgram.Properties.Settings.Default.CustomBackColor = this.BackColor;
                CopyThatProgram.Properties.Settings.Default.CustomForeColor = this.ForeColor;

                // Debug output
                System.Diagnostics.Debug.WriteLine($"[EXIT] Saving Custom Color - Fore: {this.ForeColor}, Back: {this.BackColor}");
                // MessageBox.Show($"Saving: Back={this.BackColor}, Fore={this.ForeColor}");

                // ALWAYS save custom colors immediately, regardless of auto-save setting
                Properties.Settings.Default.Save();
            }
            else
            {
                // For non-custom skins, respect the auto-save setting
                if (saveAutoCheckBox.Checked)
                    Properties.Settings.Default.Save();
            }

            // Handle background workers
            if (_copyWorker?.IsBusy == true)
            {
                if (!ConfirmCancelCopy())
                    return;
                _finishCurrentFileAndQuit = true;
                _pauseEvent.Set();
                _cancelDialogEvent.Set();
                _cancellationTokenSource?.Cancel();
                _copyWorker?.CancelAsync();
                while (_copyWorker.IsBusy)
                    await Task.Delay(50);
            }

            if (_moveWorker?.IsBusy == true)
            {
                if (!ConfirmCancelCopy())
                    return;
                _finishCurrentFileAndQuit = true;
                _pauseEvent.Set();
                _cancelDialogEvent.Set();
                _cancellationTokenSource?.Cancel();
                _moveWorker?.CancelAsync();
                while (_moveWorker.IsBusy)
                    await Task.Delay(50);
            }

            if (_deleteWorker?.IsBusy == true)
            {
                if (!ConfirmCancelCopy())
                    return;
                _finishCurrentFileAndQuit = true;
                _pauseEvent.Set();
                _cancelDialogEvent.Set();
                _cancellationTokenSource?.Cancel();
                _deleteWorker?.CancelAsync();
                while (_deleteWorker.IsBusy)
                    await Task.Delay(50);
            }

            // Exit the application
            System.Windows.Forms.Application.Exit();
        }

        private void exitLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse pointer enters the 'exitLabel'.
            // It updates the text of multiple ToolStripStatusLabels with a tooltip description for the exit button.
            statusLabel.Text = "Exit Button: This button closes the application. If the 'Minimize to System Tray' option is enabled, it will minimize the application instead of closing it.";
            toolStripCopyHistory.Text = "Exit Button: This button closes the application. If the 'Minimize to System Tray' option is enabled, it will minimize the application instead of closing it.";
            toolStripExclusions.Text = "Exit Button: This button closes the application. If the 'Minimize to System Tray' option is enabled, it will minimize the application instead of closing it.";
            toolStripMulti.Text = "Exit Button: This button closes the application. If the 'Minimize to System Tray' option is enabled, it will minimize the application instead of closing it.";
            toolStripSettings.Text = "Exit Button: This button closes the application. If the 'Minimize to System Tray' option is enabled, it will minimize the application instead of closing it.";
            toolStripSkipped.Text = "Exit Button: This button closes the application. If the 'Minimize to System Tray' option is enabled, it will minimize the application instead of closing it.";
        }

        private void allAboutLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse pointer enters the 'allAboutLabel'.
            // It updates the text of multiple ToolStripStatusLabels with a tooltip description for the about button.
            statusLabel.Text = "About Button: This button opens the 'About' dialog, providing information about the application, its version, and the developer.";
            toolStripCopyHistory.Text = "About Button: This button opens the 'About' dialog, providing information about the application, its version, and the developer.";
            toolStripExclusions.Text = "About Button: This button opens the 'About' dialog, providing information about the application, its version, and the developer.";
            toolStripMulti.Text = "About Button: This button opens the 'About' dialog, providing information about the application, its version, and the developer.";
            toolStripSettings.Text = "About Button: This button opens the 'About' dialog, providing information about the application, its version, and the developer.";
            toolStripSkipped.Text = "About Button: This button opens the 'About' dialog, providing information about the application, its version, and the developer.";
        }


        private readonly List<string> _sourcePaths = new();

        private void AddSourceFolder(string fullPath)
        {
            // 1. Duplication check
            if (_sourcePaths.Any(p => p.Equals(fullPath, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("This source folder has already been added.",
                                "Duplicate folder", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            _sourcePaths.Add(fullPath);

            fromFilesDirLabel.Text = string.Join(", ",
                _sourcePaths.Select(p => System.IO.Path.GetFileName(p))); 

            UpdateDriveSpaceInfo();
        }
        private async void sourceDirectoryLabel_Click(object sender, EventArgs e)
        {
            filesDataGridView.DefaultCellStyle.ForeColor = System.Drawing.Color.Black;
            filesDataGridView.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;

            using (FolderBrowserDialog folderDialog = new FolderBrowserDialog())
            {
                folderDialog.Description = "Select a source folder to copy/move/delete from:";
                folderDialog.ShowNewFolderButton = false;

                if (folderDialog.ShowDialog() == DialogResult.OK)
                {
                    string sourceDir = folderDialog.SelectedPath;
                    if (!string.IsNullOrEmpty(targetDirLabel.Text) &&
                       targetPaths.Any(tp => string.Equals(tp, sourceDir, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("The source folder cannot be the same as one of the target folders.",
                                        "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    if (!string.IsNullOrEmpty(targetDirLabel.Text) &&
                       _sourceDirectories.Any(tp => string.Equals(tp, sourceDir, StringComparison.OrdinalIgnoreCase)))
                    {
                        MessageBox.Show("The source folder cannot be added twice.",
                                        "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }
                    else
                    {
                        _sourceDirectories.Add(folderDialog.SelectedPath);
                        AddSourceFolder(sourceDir);
                    }



                    startButton.Enabled = false;
                    clearFileListButton.Enabled = false;
                    removeFileButton.Enabled = false;
                    cancelButton.Enabled = false;
                    skipButton.Enabled = false;
                    addFileButton.Enabled = false;

                    filePathLabel.Enabled = true;
                    totalCopiedProgressLabel.Enabled = true;
                    fileCountOnLabel.Enabled = true;
                    totalHDSpaceLeftLabel.Enabled = true;

                    var progress = new Progress<string>(msg => fromFilesDirLabel.Text = msg);

                    try
                    {
                        await ScanDirectoryWithUpdatesAsync(sourceDir, updateIntervalMs: 50);
                        _bindingSource.ResetBindings(false);
                    }
                    catch (Exception ex)
                    {
                        fromFilesDirLabel.Text = $"Error: {ex.Message}";
                        MessageBox.Show($"An error occurred during scanning: {ex.Message}",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    finally
                    {
                        EnableAllControls(cmdHomePage);

                        startButton.Enabled = true;
                        pauseResumeButton.Enabled = false;
                        cancelButton.Enabled = false;
                        skipButton.Enabled = false;
                        addFileButton.Enabled = true;
                        clearFileListButton.Enabled = true;
                        removeFileButton.Enabled = true;
                        sourceDirectoryLabel.Enabled = true;
                        targetDirectoryLabel.Enabled = true;
                    }

                    PlaySound("FileAdded");
                }

                filePathLabel.Text = "Nothing";
                _bindingSource.ResetBindings(false);
            }
        }

        private void targetDirectoryLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the targetDirectoryLabel is clicked.
            // It uses a 'using' statement to ensure the FolderBrowserDialog is properly disposed of.
            using FolderBrowserDialog folderDialog = new();
            // Shows the folder selection dialog to the user.
            if (folderDialog.ShowDialog() == DialogResult.OK)
            {
                // Gets the path of the folder selected by the user.
                string selectedPath = folderDialog.SelectedPath;

                // Checks if the selected path is the same as the source directory.
                // It also checks if the source directory label is not empty.

                if (!string.IsNullOrEmpty(targetDirLabel.Text) &&
                         targetPaths.Any(tp => string.Equals(tp, selectedPath, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("The target folder cannot be added twice.",
                                    "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (!string.IsNullOrEmpty(targetDirLabel.Text) &&
                         _sourceDirectories.Any(tp => string.Equals(tp, selectedPath, StringComparison.OrdinalIgnoreCase)))
                {
                    MessageBox.Show("The target folder cannot be the same as one of the source folders.",
                                    "Invalid Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Checks if the targetPaths list is empty.
                if (targetPaths.Count == 0)
                {
                    // If it is, it clears the text of the target directory label.
                    targetDirLabel.Text = string.Empty;
                }

                // Adds the newly selected path to the list of target paths.
                targetPaths.Add(selectedPath);

                // Extracts just the folder name from the full path.
                string folderName = System.IO.Path.GetFileName(selectedPath);

                // If the target directory label already has text, it adds a comma and space.
                if (!string.IsNullOrWhiteSpace(targetDirLabel.Text))
                {
                    targetDirLabel.Text += ", ";
                }

                // Appends the new folder name to the target directory label's text.
                targetDirLabel.Text += folderName;

                // Calls a method to update the displayed drive space information.
                UpdateDriveSpaceInfo();
            }
        }
        private void sourceDirectoryLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse enters the sourceDirectoryLabel.
            // It updates the status bar's text to provide a tooltip description for the source directory button.
            statusLabel.Text = "Source Directory Button: This is the button to select your source directory from which files will be copied/moved/securely deleted.";
        }
        private void targetDirectoryLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse enters the targetDirectoryLabel.
            // It updates the status bar's text to provide a tooltip description for the target directory button.
            statusLabel.Text = "Target Directory Button: This is the button to select your target directory to which your files will be copied/moved.";
        }
        private void moveFileUpLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the moveFileUpLabel is clicked.
            try
            {
                // Creates a new DataGridViewRow object (though it isn't used).
                DataGridViewRow row = new DataGridViewRow();
                // Gets the index of the first selected row.
                int index = filesDataGridView.SelectedRows[0].Index;

                // Checks if the selected row is already at the top (index 1 or 0).
                if (index == 1 || index == 0)
                {
                    // If the grid has rows, it ensures the top row is selected and visible.
                    if (filesDataGridView.Rows.Count > 0)
                    {
                        filesDataGridView.Rows[0].Selected = true;
                        filesDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    }
                    // The method returns, as no upward movement is needed.
                    return;
                }
                // Checks if the selected row is at index 2 or 3.
                else if (index == 2 || index == 3)
                {
                    // It clears the current selection.
                    filesDataGridView.ClearSelection();
                    // Selects the row one position up.
                    filesDataGridView.Rows[index - 1].Selected = true;
                    // Scrolls the grid to make the newly selected row visible.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = index - 1;
                }
                else
                {
                    // For any other index, it performs the same move-up operation.
                    filesDataGridView.ClearSelection();
                    filesDataGridView.Rows[index - 1].Selected = true;
                    filesDataGridView.FirstDisplayedScrollingRowIndex = index - 1;
                }
            }
            catch { } // Catches and ignores any exceptions, such as no row being selected.
        }

        private void moveFileUpLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse enters the moveFileUpLabel.
            // It updates the status bar with a tooltip describing the button's function.
            statusLabel.Text = "Files Up Button: This button allows you to move the selected file up in the list, changing its order in the operation sequence.";
        }

        private void moveFileDownLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the moveFileDownLabel is clicked.
            try
            {
                // Creates a new DataGridViewRow object (unused in this logic).
                DataGridViewRow row = new DataGridViewRow();
                // Gets the index of the first selected row.
                int index = filesDataGridView.SelectedRows[0].Index;

                // Checks if the selected row is already the last row.
                if (index == filesDataGridView.Rows.Count - 1)
                {
                    // If it is, the method returns, as no downward movement is possible.
                    return;
                }
                else
                {
                    // Assigns the selected row to the 'row' variable.
                    row = filesDataGridView.SelectedRows[0];

                    // Clears the current selection.
                    filesDataGridView.ClearSelection();
                    // Selects the row one position down.
                    filesDataGridView.Rows[index + 1].Selected = true;
                    // Scrolls the grid to make the newly selected row visible.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = index + 1;
                }
            }
            catch { } // Catches and ignores exceptions, such as no row being selected.
        }

        private void moveFileDownLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse enters the moveFileDownLabel.
            // It updates the status bar with a tooltip describing the button's function.
            statusLabel.Text = "Files Down Button: This button allows you to move the selected file down in the list, changing its order in the operation sequence.";
        }

        private void moveToTopLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the moveToTopLabel is clicked.
            try
            {
                // Gets the index of the first selected row.
                int index = filesDataGridView.SelectedRows[0].Index;
                // Creates a new DataGridViewRow object (unused in this logic).
                DataGridViewRow row = new DataGridViewRow();

                // Checks if the selected row is already at the top (index 0).
                if (index == 0)
                {
                    // If it is, it scrolls the grid to the top and returns.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    return;
                }
                else
                {
                    // Scrolls the grid to display the first row.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = 0;
                    // Defines the index of the first row.
                    int lastRowIndex = 0;
                    // Checks if a valid row exists.
                    if (lastRowIndex >= 0)
                    {
                        // Selects the first row.
                        filesDataGridView.Rows[lastRowIndex].Selected = true;
                    }
                }
            }
            catch
            {
                // Catches and ignores any exceptions.
            }
        }

        private void moveToTopLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse enters the moveToTopLabel.
            // It updates the status bar with a tooltip describing the button's function.
            statusLabel.Text = "Move to Top Button: This button moves the selected file to the top of the list, making it the first file to be processed in the operation.";
        }

        private void moveToBottomLabel_Click(object sender, EventArgs e)
        {
            // This event handler is triggered when the moveToBottomLabel is clicked.
            try
            {
                // Gets the index of the first selected row.
                int index = filesDataGridView.SelectedRows[0].Index;
                // Creates a new DataGridViewRow object (unused in this logic).
                DataGridViewRow row = new DataGridViewRow();

                // Checks if the selected row is already the last row.
                if (index == filesDataGridView.Rows.Count - 1)
                {
                    // If it is, the method returns.
                    return;
                }
                else
                {
                    // Scrolls the grid to display the last row.
                    filesDataGridView.FirstDisplayedScrollingRowIndex = filesDataGridView.RowCount - 1;
                    // Defines the index of the last row.
                    int lastRowIndex = filesDataGridView.Rows.Count - 1;
                    // Checks if a valid last row exists.
                    if (lastRowIndex >= 0)
                    {
                        // Selects the last row.
                        filesDataGridView.Rows[lastRowIndex].Selected = true;
                    }
                }
            }
            catch { } // Catches and ignores exceptions.
        }
        private void moveToBottomLabel_MouseEnter(object sender, EventArgs e)
        {
            // This event handler is triggered when the mouse enters the moveToBottomLabel.
            // It updates the status bar with a tooltip describing the button's function.
            statusLabel.Text = "Move to Bottom Button: This button moves the selected file to the bottom of the list, making it the last file to be processed in the operation.";
        }


        /// <summary>
        /// Checks GitHub for a newer version of the program.
        /// If a newer ZIP is found, downloads it and starts the update process.
        /// Shows a message if already up to date.
        /// </summary>
        private async void CheckAndUpdateAsync()
        {
            try
            {
                // Create an HTTP client for web requests
                using var http = new HttpClient();

                // Parse the local version string into a Version object
                var localVer = new Version(_localVersion);

                // Loop through minor versions 0–9 to check for the next available update
                for (int minor = 0; minor <= 9; minor++)
                {
                    var nextVer = $"1.{minor}";
                    // Skip if the next version is not newer than the local version
                    if (new Version(nextVer) <= localVer) continue;

                    // Build the file and URL for the potential update
                    var file = $"CTv{nextVer}.zip";
                    var url = $"{GITHUB_PAGES_BASE}/{file}";

                    // Send a HEAD request to see if the file exists on GitHub
                    using var resp = await http.SendAsync(
                        new HttpRequestMessage(HttpMethod.Head, url));

                    // If the file exists, prepare to download it
                    if (resp.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        _remoteZip = file;
                        var tempPath = System.IO.Path.Combine(System.IO.Path.GetTempPath(), _remoteZip);

                        // Use WebClient to download the ZIP asynchronously
                        var wc = new WebClient();
                        wc.DownloadFileCompleted += Wc_DownloadFileCompleted;
                        wc.DownloadFileAsync(new Uri(url), tempPath);
                        return; // Exit once a valid update is found
                    }
                }

                // No update found – inform the user
                MessageBox.Show("The program is up to date.", "Updater",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            catch (Exception ex)
            {
                // Show error and exit if update check fails
                MessageBox.Show($"Update check failed:\n{ex.Message}", "Updater",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                System.Windows.Forms.Application.Exit();
                return;
            }
        }

        /// <summary>
        /// Deletes any executable or related files in the application folder
        /// that have an older version than the current running executable.
        /// </summary>
        private void CleanupOldVersions()
        {
            try
            {
                // Determine the current application folder
                var appFolder = AppDomain.CurrentDomain.BaseDirectory;
                // Get the current executable name without extension
                var currentExeName = System.IO.Path.GetFileNameWithoutExtension(Application.ExecutablePath);

                // Try to extract version number from current exe name
                var currentVersionString = ExtractVersionFromFileName(currentExeName);
                if (currentVersionString == null)
                {
                    Console.WriteLine("Could not determine current version from exe name");
                    return;
                }

                // Parse the extracted version string
                if (!Version.TryParse(currentVersionString, out var currentVersion))
                {
                    Console.WriteLine($"Could not parse current version: {currentVersionString}");
                    return;
                }

                // Get all files inside the application directory
                var allFiles = Directory.GetFiles(appFolder, "*.*", SearchOption.AllDirectories);

                // Iterate through each file to check its version
                foreach (var file in allFiles)
                {
                    var fileName = System.IO.Path.GetFileNameWithoutExtension(file);

                    // Skip the currently running executable
                    if (fileName.Equals(currentExeName, StringComparison.OrdinalIgnoreCase))
                        continue;

                    // Attempt to extract a version from the filename
                    var fileVersionString = ExtractVersionFromFileName(fileName);
                    if (fileVersionString == null)
                        continue;

                    // Compare file version to current version
                    if (Version.TryParse(fileVersionString, out var fileVersion))
                    {
                        if (fileVersion < currentVersion)
                        {
                            // Delete files with an older version
                            try
                            {
                                File.Delete(file);
                                Console.WriteLine($"Deleted older version: {fileName} (v{fileVersion}) - current is v{currentVersion}");
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Could not delete {fileName}: {ex.Message}");
                            }
                        }
                        else
                        {
                            Console.WriteLine($"Keeping {fileName} (v{fileVersion}) - not older than v{currentVersion}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error during cleanup: {ex.Message}");
            }
        }

        /// <summary>
        /// Extracts a version string (e.g. "1.2" or "3.1.4") from a filename
        /// following the pattern "...vX.Y...".
        /// Returns null if no match is found.
        /// </summary>
        private string ExtractVersionFromFileName(string fileName)
        {
            var match = System.Text.RegularExpressions.Regex.Match(fileName, @"v(\d+(\.\d+)+)");
            return match.Success ? match.Groups[1].Value : null;
        }

        /// <summary>
        /// Handles the completion of the update ZIP download.
        /// Extracts files, copies them to the app folder, and launches the new version.
        /// </summary>
        private void Wc_DownloadFileCompleted(object? sender, AsyncCompletedEventArgs e)
        {
            // Exit if the download encountered an error
            if (e.Error != null)
            {
                MessageBox.Show($"Download failed:\n{e.Error.Message}", "Updater",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
                return;
            }

            try
            {
                var appFolder = AppDomain.CurrentDomain.BaseDirectory;
                var tempZip = System.IO.Path.Combine(System.IO.Path.GetTempPath(), _remoteZip!);

                // Create a temporary extraction folder for the update
                var tempExtractFolder = System.IO.Path.Combine(System.IO.Path.GetTempPath(), Guid.NewGuid().ToString("N"));
                Directory.CreateDirectory(tempExtractFolder);

                try
                {
                    // Extract the downloaded ZIP into the temporary folder
                    ZipFile.ExtractToDirectory(tempZip, tempExtractFolder, true);

                    // Determine the expected name of the new executable
                    var newExeName = System.IO.Path.GetFileNameWithoutExtension(_remoteZip!) + ".exe";
                    var newExePathInTemp = System.IO.Path.Combine(tempExtractFolder, newExeName);

                    // Verify the new executable exists
                    if (!File.Exists(newExePathInTemp))
                        throw new FileNotFoundException($"New executable not found: {newExePathInTemp}");

                    // Copy new files into the application folder (overwrite if needed)
                    CopyDirectory(tempExtractFolder, appFolder, true);

                    // Set a flag in settings so the new version can perform cleanup
                    Properties.Settings.Default.Updated = true;
                    Properties.Settings.Default.Save();

                    // Delete temp ZIP and extracted files
                    File.Delete(tempZip);
                    Directory.Delete(tempExtractFolder, true);

                    // Launch the new executable
                    var newExePath = System.IO.Path.Combine(appFolder, newExeName);
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = newExePath,
                        UseShellExecute = true
                    });

                    // Exit the old application
                    Application.Exit();
                }
                finally
                {
                    // Safety cleanup in case of exceptions
                    if (File.Exists(tempZip))
                        File.Delete(tempZip);
                    if (Directory.Exists(tempExtractFolder))
                        Directory.Delete(tempExtractFolder, true);
                }
            }
            catch (Exception ex)
            {
                // Inform user if update process fails
                MessageBox.Show($"Update failed:\n{ex.Message}", "Updater",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        /// <summary>
        /// Recursively copies all files and directories from source to target.
        /// Creates target directories as needed.
        /// </summary>
        private void CopyDirectory(string sourceDir, string targetDir, bool overwrite = false)
        {
            var dir = new DirectoryInfo(sourceDir);

            // Ensure target directory exists
            Directory.CreateDirectory(targetDir);

            // Copy all files in the current directory
            foreach (var file in dir.GetFiles())
            {
                var targetFilePath = System.IO.Path.Combine(targetDir, file.Name);
                file.CopyTo(targetFilePath, overwrite);
            }

            // Recursively copy subdirectories
            foreach (var subDir in dir.GetDirectories())
            {
                var targetSubDir = System.IO.Path.Combine(targetDir, subDir.Name);
                CopyDirectory(subDir.FullName, targetSubDir, overwrite);
            }
        }

        /// <summary>
        /// Creates a staging folder and PowerShell script to replace
        /// the old application folder with the new version, then restart.
        /// Used when direct overwrite is not possible.
        /// </summary>
        private void StageReplaceAndRestart(string stagingFolder)
        {
            // Get the current application folder and its parent directory
            var oldFolder = AppDomain.CurrentDomain.BaseDirectory;
            var parentDir = System.IO.Path.GetDirectoryName(oldFolder)!;
            var leafName = System.IO.Path.GetFileName(oldFolder.TrimEnd(System.IO.Path.DirectorySeparatorChar));

            // Determine the new executable name from the ZIP
            var newExeName = System.IO.Path.GetFileNameWithoutExtension(_remoteZip!) + ".exe";

            // Create a temporary mirror folder for staging the replacement
            var mirror = System.IO.Path.Combine(parentDir, Guid.NewGuid().ToString("N"));
            DirectoryCopy(stagingFolder, mirror, true);

            // Build a PowerShell script to replace the old folder once the app exits
            var ps1 = System.IO.Path.Combine(parentDir, "CTupdate.ps1");
            File.WriteAllText(ps1, $$"""
Add-Type -AssemblyName System.Windows.Forms
[System.Windows.Forms.MessageBox]::Show('Waiting for old EXE to exit...','Updater')

$pidOld = {{Process.GetCurrentProcess().Id}}
$proc   = Get-Process -Id $pidOld -ErrorAction SilentlyContinue
while ($proc -and !$proc.HasExited) {
    Start-Sleep -Milliseconds 500
    $proc.Refresh()
}
if ($proc) { $proc.Kill(); $proc.WaitForExit() }
Start-Sleep -Seconds 1

[System.Windows.Forms.MessageBox]::Show('Replacing folder...','Updater')

$old = "{{oldFolder}}"
$new = "{{mirror}}"
$final = Join-Path "{{parentDir}}" "{{leafName}}"

if (!(Test-Path $new)) { throw "New folder missing: $new" }

Remove-Item -Path $old -Recurse -Force
Rename-Item -Path $new -NewName "{{leafName}}"

Start-Process (Join-Path $final "{{newExeName}}")
""");

            // Run the PowerShell script in a separate process
            _ = Task.Run(() =>
            {
                using var ps = Process.Start(new ProcessStartInfo
                {
                    FileName = "powershell",
                    Arguments = $"-NoProfile -ExecutionPolicy Bypass -File \"{ps1}\"",
                    WindowStyle = ProcessWindowStyle.Normal,
                    CreateNoWindow = false,
                    UseShellExecute = false
                });
                ps!.WaitForExit();
            });

            // Exit the current application so the script can proceed
            Application.Exit();
        }

        /// <summary>
        /// Copies a directory recursively to a new location, preserving subdirectories.
        /// Overwrites existing files if necessary.
        /// </summary>
        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            var dir = new DirectoryInfo(sourceDirName);
            var dirs = dir.GetDirectories();
            Directory.CreateDirectory(destDirName);

            // Copy all files in the current directory
            foreach (var file in dir.GetFiles())
                file.CopyTo(System.IO.Path.Combine(destDirName, file.Name), true);

            // Copy all subdirectories if requested
            if (copySubDirs)
            {
                foreach (var subDir in dirs)
                    DirectoryCopy(subDir.FullName, System.IO.Path.Combine(destDirName, subDir.Name), true);
            }
        }

        // Event handler for "Check for Updates" button
        private void checkForUpdatesButton_Click(object sender, EventArgs e)
        {
            CheckAndUpdateAsync(); // Trigger the update check process
        }

        // Event handler for "Reset Totals" button
        private void resetTotalsButton_Click(object sender, EventArgs e)
        {
            // Only show confirmation if totals exist
            if (!TotalsManager.HasAnyTotals())
                return;

            // Ask the user for confirmation before resetting
            DialogResult result = MessageBox.Show(
                "Are you sure you want to reset all totals? This action cannot be undone.",
                "Confirm Reset",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question
            );

            // Reset totals if user confirms
            if (result == DialogResult.Yes)
            {
                TotalsManager.ResetTotals(
                    totalCopyOperationsLabel, totalMoveOperationsLabel, totalDeleteOperationsLabel,
                    totalCancelledOperationsLabel, totalCompletedOperationsLabel,
                    totalFilesConsideredLabel, totalFilesCopiedLabel, totalFilesMovedLabel,
                    totalFilesDeletedLabel, totalFilesSkippedLabel, totalFilesFailedLabel,
                    totalBytesProcessedLabel, totalBytesToProcessLabel,
                    totalElapsedTimeLabel, totalTargetTimeLabel,
                    resetTotalsButton // Pass the button reference
                );
            }
        }
    }
}
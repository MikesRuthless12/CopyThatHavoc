﻿﻿﻿﻿namespace CopyThatProgram
{
    partial class mainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(mainForm));
            tabControl1 = new TabControl();
            cmdHomePage = new TabPage();
            fileOverAllProgressLabel = new Label();
            totalProgressBar = new CustomControls.ModernCircularProgressBar();
            fileProgressBar = new CustomControls.ModernCircularProgressBar();
            moveToBottomLabel = new Label();
            moveToTopLabel = new Label();
            moveFileDownLabel = new Label();
            moveFileUpLabel = new Label();
            targetDirectoryLabel = new Label();
            sourceDirectoryLabel = new Label();
            filesDataGridView = new DataGridView();
            fileOptionsLabel = new Label();
            statusStrip1 = new StatusStrip();
            statusLabel = new ToolStripStatusLabel();
            keepOnlyFilesCheckBox = new CheckBox();
            leaveEmptyFoldersCheckBox = new CheckBox();
            autoScrollCheckBox = new CheckBox();
            fileNameLabel = new Label();
            verifyCheckBox = new CheckBox();
            copyFilesDirsCheckBox = new CheckBox();
            createCustomDirCheckBox = new CheckBox();
            keepDirStructCheckBox = new CheckBox();
            totalHDSpaceLeftLabel = new Label();
            doNotOverwriteCheckBox = new CheckBox();
            overwriteAllCheckBox = new CheckBox();
            overwriteIfNewerCheckBox = new CheckBox();
            removeFileButton = new Button();
            addFileButton = new Button();
            clearFileListButton = new Button();
            moveBottomLabel = new Label();
            moveTopLabel = new Label();
            fileDownLabel = new Label();
            fileUpLabel = new Label();
            clearTextButton = new Button();
            searchTextBox = new TextBox();
            searchFileFolderLabel = new Label();
            fileListLabel = new Label();
            onFinishLabel = new Label();
            cmdLabel = new Label();
            onFinishComboBox = new ComboBox();
            skipButton = new Button();
            speedLabel = new Label();
            fileProcessedLabel = new Label();
            copyMoveDeleteComboBox = new ComboBox();
            totalCopiedProgressLabel = new Label();
            fileCountOnLabel = new Label();
            elapsedAndTargetTimeLabel = new Label();
            pauseResumeButton = new Button();
            overallProgressLabel = new Label();
            cancelButton = new Button();
            startButton = new Button();
            fileIconPicBox = new PictureBox();
            targetDirLabel = new Label();
            fromFilesDirLabel = new Label();
            filePathLabel = new Label();
            targetLabel = new Label();
            fromLabel = new Label();
            cmdMultithread = new TabPage();
            thread4Label = new Label();
            thread3Label = new Label();
            thread2Label = new Label();
            thread1Label = new Label();
            progressBarMutli1 = new CustomControls.ModernCircularProgressBar();
            progressBarMutli2 = new CustomControls.ModernCircularProgressBar();
            progressBarMutli3 = new CustomControls.ModernCircularProgressBar();
            progressBarMutli4 = new CustomControls.ModernCircularProgressBar();
            progressBarMultiThreadTotal = new CustomControls.ModernCircularProgressBar();
            dataGridView2 = new DataGridView();
            statusBarMulti = new StatusStrip();
            toolStripMulti = new ToolStripStatusLabel();
            totalProgressMultiLabel = new Label();
            filesNameLabel4 = new Label();
            filesNameLabel3 = new Label();
            filesNameLabel2 = new Label();
            filesNameLabel1 = new Label();
            onFinishMultiLabel = new Label();
            onFinishMultiComboBox = new ComboBox();
            pauseResumeMultiButton = new Button();
            cancelMultiButton = new Button();
            totalSpaceMultiLabel = new Label();
            speedMultiLabel = new Label();
            totalCMDMultiLabel = new Label();
            fileCountMultiLabel = new Label();
            totalTimeMultiLabel = new Label();
            cmdSkipPage = new TabPage();
            statusBarSkipped = new StatusStrip();
            toolStripSkipped = new ToolStripStatusLabel();
            totalSkippedLabel = new Label();
            clearSkippedListButton = new Button();
            goToInExplorerButton = new Button();
            skippedDataGridView = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            sourcePath = new DataGridViewTextBoxColumn();
            destinationPath = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            cmdCopyHistory = new TabPage();
            copyHistoryDGV = new DataGridView();
            Operation = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn11 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn12 = new DataGridViewTextBoxColumn();
            TotalDirSize = new DataGridViewTextBoxColumn();
            statusBarCopyHistory = new StatusStrip();
            toolStripCopyHistory = new ToolStripStatusLabel();
            deleteEntryButton = new Button();
            totalHistoryLabel = new Label();
            clearHistoryButton = new Button();
            cloneButton = new Button();
            cmdExclusions = new TabPage();
            statusBarExclusions = new StatusStrip();
            toolStripExclusions = new ToolStripStatusLabel();
            clearExcludedButton = new Button();
            removeExcludedButton = new Button();
            addExcludedButton = new Button();
            clearAllowedButton = new Button();
            removeAllowedButton = new Button();
            addAllowedButton = new Button();
            excludedTextBox = new TextBox();
            allowedTextBox = new TextBox();
            excludedLabel = new Label();
            allowedLabel = new Label();
            excludedExtListBox = new ListBox();
            allowedExtListBox = new ListBox();
            cmdTotals = new TabPage();
            resetTotalsButton = new Button();
            totalTargetTimeLabel = new Label();
            totalElapsedTimeLabel = new Label();
            totalBytesToProcessLabel = new Label();
            totalBytesProcessedLabel = new Label();
            totalTargetTimeTitleLabel = new Label();
            totalElapsedTimeTitleLabel = new Label();
            totalBytesToProcessTitleLabel = new Label();
            totalBytesProcessedTitleLabel = new Label();
            totalFilesMovedLabel = new Label();
            totalFilesMovedTitleLabel = new Label();
            totalFilesFailedLabel = new Label();
            totalFilesSkippedLabel = new Label();
            totalFilesDeletedLabel = new Label();
            totalFilesCopiedLabel = new Label();
            totalFilesConsideredTitleLabel = new Label();
            totalFilesFailedTitleLabel = new Label();
            totalFilesSkippedTitleLabel = new Label();
            totalFilesDeletedTitleLabel = new Label();
            totalFilesCopiedTitleLabel = new Label();
            totalFilesConsideredLabel = new Label();
            totalCompletedOperationsLabel = new Label();
            totalCancelledOperationsLabel = new Label();
            totalDeleteOperationsLabel = new Label();
            totalMoveOperationsLabel = new Label();
            totalCopyOperationsTitleLabel = new Label();
            totalCompletedOperationsTitleLabel = new Label();
            totalCancelledOperationsTitleLabel = new Label();
            totalDeleteOperationsTItleLabel = new Label();
            totalMoveOperationsTitleLabel = new Label();
            totalCopyOperationsLabel = new Label();
            titleTotalsLabel = new Label();
            cmdSettingsPage = new TabPage();
            dataGridView1 = new DataGridView();
            statusBarSettings = new StatusStrip();
            toolStripSettings = new ToolStripStatusLabel();
            retentionLabel = new Label();
            logDaysNumUpDown = new NumericUpDown();
            exportFileListLabel = new Label();
            opacityLabel = new Label();
            opacityTrackBar = new TrackBar();
            logFileCheckBox = new CheckBox();
            priorityLabel = new Label();
            priorityTrackBar = new TrackBar();
            saveAutoCheckBox = new CheckBox();
            defaultSettingsButton = new Button();
            recSettingsButton = new Button();
            clearSettingsButton = new Button();
            saveSettingsButton = new Button();
            emailGroupBox = new GroupBox();
            setUpSMSButton = new Button();
            setUpEmailButton = new Button();
            emailPathsCheckBox = new CheckBox();
            emailNamesCheckBox = new CheckBox();
            whenEmailingLabel = new Label();
            updateGroupBox = new GroupBox();
            updateManuallyCheckBox = new CheckBox();
            checkForUpdatesButton = new Button();
            updateBetaCheckBox = new CheckBox();
            updateAutoCheckBox = new CheckBox();
            performanceGroupBox = new GroupBox();
            kbLabel = new Label();
            multithreadCheckBox = new CheckBox();
            cmOnlyIfLabel = new Label();
            overMBCheckBox = new CheckBox();
            underMBCheckBox = new CheckBox();
            setMBGBOLabel = new Label();
            setMBGBULabel = new Label();
            setMBGBUnderNumUpDown = new NumericUpDown();
            setMBUmderLabel = new Label();
            setMBGBOverNumUpDown = new NumericUpDown();
            setMBGBOverLabel = new Label();
            bufferNumUpDown = new NumericUpDown();
            setBufferLabel = new Label();
            otherSettingsGroupBox = new GroupBox();
            secureDeleteLabel = new Label();
            securePassesNumUpDown = new NumericUpDown();
            seLabel = new Label();
            sLabel = new Label();
            swLabel = new Label();
            eLabel = new Label();
            neLabel = new Label();
            nLabel = new Label();
            nwLabel = new Label();
            wLabel = new Label();
            appLocationLabel = new Label();
            startWithWindowsCheckBox = new CheckBox();
            serialMaskedTextBox = new MaskedTextBox();
            registerButton = new Button();
            serialNumberLabel = new Label();
            errorOccursLabel = new Label();
            restartCheckBox = new CheckBox();
            closeProgramCheckBox = new CheckBox();
            fileDirSettingsGroupBox = new GroupBox();
            exportButton = new Button();
            zipSettingsLabel = new Label();
            zipTogetherCheckBox = new CheckBox();
            zipSeparateCheckBox = new CheckBox();
            exportListLabel = new Label();
            fullPathsCheckBox = new CheckBox();
            onlyNamesCheckBox = new CheckBox();
            soundsGroupBox = new GroupBox();
            onAddFilesCheckBox = new CheckBox();
            onErrorCheckBox = new CheckBox();
            onCancelCheckBox = new CheckBox();
            onFinishCheckBox = new CheckBox();
            skinsLanguageGoupBox = new GroupBox();
            skinsComboBox = new ComboBox();
            skinsLabel = new Label();
            languageComboBox = new ComboBox();
            languageLabel = new Label();
            windowGroupBox = new GroupBox();
            contextMenuCheckBox = new CheckBox();
            minimizeSystemTrayCheckBox = new CheckBox();
            alwaysOnTopCheckBox = new CheckBox();
            confirmDragDropCheckBox = new CheckBox();
            cmdAboutPage = new TabPage();
            aboutPanel = new Panel();
            aboutCTLabel = new Label();
            havocSoftwarePB = new PictureBox();
            copyThatPB = new PictureBox();
            titleLabel = new Label();
            scrollTimer = new System.Windows.Forms.Timer(components);
            openFileDialog = new OpenFileDialog();
            removeDirBGW = new System.ComponentModel.BackgroundWorker();
            rollTimer = new System.Windows.Forms.Timer(components);
            notifyIcon1 = new NotifyIcon(components);
            label2 = new Label();
            rollUpLabel = new Label();
            rollDownLabel = new Label();
            settingsLabel = new Label();
            allAboutLabel = new Label();
            minimizeLabel = new Label();
            exitLabel = new Label();
            tabControl1.SuspendLayout();
            cmdHomePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)filesDataGridView).BeginInit();
            statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)fileIconPicBox).BeginInit();
            cmdMultithread.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            statusBarMulti.SuspendLayout();
            cmdSkipPage.SuspendLayout();
            statusBarSkipped.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)skippedDataGridView).BeginInit();
            cmdCopyHistory.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)copyHistoryDGV).BeginInit();
            statusBarCopyHistory.SuspendLayout();
            cmdExclusions.SuspendLayout();
            statusBarExclusions.SuspendLayout();
            cmdTotals.SuspendLayout();
            cmdSettingsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            statusBarSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)logDaysNumUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)opacityTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)priorityTrackBar).BeginInit();
            emailGroupBox.SuspendLayout();
            updateGroupBox.SuspendLayout();
            performanceGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)setMBGBUnderNumUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)setMBGBOverNumUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bufferNumUpDown).BeginInit();
            otherSettingsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)securePassesNumUpDown).BeginInit();
            fileDirSettingsGroupBox.SuspendLayout();
            soundsGroupBox.SuspendLayout();
            skinsLanguageGoupBox.SuspendLayout();
            windowGroupBox.SuspendLayout();
            cmdAboutPage.SuspendLayout();
            aboutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)havocSoftwarePB).BeginInit();
            ((System.ComponentModel.ISupportInitialize)copyThatPB).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(cmdHomePage);
            tabControl1.Controls.Add(cmdMultithread);
            tabControl1.Controls.Add(cmdSkipPage);
            tabControl1.Controls.Add(cmdCopyHistory);
            tabControl1.Controls.Add(cmdExclusions);
            tabControl1.Controls.Add(cmdTotals);
            tabControl1.Controls.Add(cmdSettingsPage);
            tabControl1.Controls.Add(cmdAboutPage);
            tabControl1.Location = new Point(5, 66);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1552, 1115);
            tabControl1.TabIndex = 22;
            tabControl1.SelectedIndexChanged += tabControl1_SelectedIndexChanged;
            tabControl1.MouseEnter += tabControl1_MouseEnter;
            // 
            // cmdHomePage
            // 
            cmdHomePage.BorderStyle = BorderStyle.FixedSingle;
            cmdHomePage.Controls.Add(fileOverAllProgressLabel);
            cmdHomePage.Controls.Add(totalProgressBar);
            cmdHomePage.Controls.Add(fileProgressBar);
            cmdHomePage.Controls.Add(moveToBottomLabel);
            cmdHomePage.Controls.Add(moveToTopLabel);
            cmdHomePage.Controls.Add(moveFileDownLabel);
            cmdHomePage.Controls.Add(moveFileUpLabel);
            cmdHomePage.Controls.Add(targetDirectoryLabel);
            cmdHomePage.Controls.Add(sourceDirectoryLabel);
            cmdHomePage.Controls.Add(filesDataGridView);
            cmdHomePage.Controls.Add(fileOptionsLabel);
            cmdHomePage.Controls.Add(statusStrip1);
            cmdHomePage.Controls.Add(keepOnlyFilesCheckBox);
            cmdHomePage.Controls.Add(leaveEmptyFoldersCheckBox);
            cmdHomePage.Controls.Add(autoScrollCheckBox);
            cmdHomePage.Controls.Add(fileNameLabel);
            cmdHomePage.Controls.Add(verifyCheckBox);
            cmdHomePage.Controls.Add(copyFilesDirsCheckBox);
            cmdHomePage.Controls.Add(createCustomDirCheckBox);
            cmdHomePage.Controls.Add(keepDirStructCheckBox);
            cmdHomePage.Controls.Add(totalHDSpaceLeftLabel);
            cmdHomePage.Controls.Add(doNotOverwriteCheckBox);
            cmdHomePage.Controls.Add(overwriteAllCheckBox);
            cmdHomePage.Controls.Add(overwriteIfNewerCheckBox);
            cmdHomePage.Controls.Add(removeFileButton);
            cmdHomePage.Controls.Add(addFileButton);
            cmdHomePage.Controls.Add(clearFileListButton);
            cmdHomePage.Controls.Add(moveBottomLabel);
            cmdHomePage.Controls.Add(moveTopLabel);
            cmdHomePage.Controls.Add(fileDownLabel);
            cmdHomePage.Controls.Add(fileUpLabel);
            cmdHomePage.Controls.Add(clearTextButton);
            cmdHomePage.Controls.Add(searchTextBox);
            cmdHomePage.Controls.Add(searchFileFolderLabel);
            cmdHomePage.Controls.Add(fileListLabel);
            cmdHomePage.Controls.Add(onFinishLabel);
            cmdHomePage.Controls.Add(cmdLabel);
            cmdHomePage.Controls.Add(onFinishComboBox);
            cmdHomePage.Controls.Add(skipButton);
            cmdHomePage.Controls.Add(speedLabel);
            cmdHomePage.Controls.Add(fileProcessedLabel);
            cmdHomePage.Controls.Add(copyMoveDeleteComboBox);
            cmdHomePage.Controls.Add(totalCopiedProgressLabel);
            cmdHomePage.Controls.Add(fileCountOnLabel);
            cmdHomePage.Controls.Add(elapsedAndTargetTimeLabel);
            cmdHomePage.Controls.Add(pauseResumeButton);
            cmdHomePage.Controls.Add(overallProgressLabel);
            cmdHomePage.Controls.Add(cancelButton);
            cmdHomePage.Controls.Add(startButton);
            cmdHomePage.Controls.Add(fileIconPicBox);
            cmdHomePage.Controls.Add(targetDirLabel);
            cmdHomePage.Controls.Add(fromFilesDirLabel);
            cmdHomePage.Controls.Add(filePathLabel);
            cmdHomePage.Controls.Add(targetLabel);
            cmdHomePage.Controls.Add(fromLabel);
            cmdHomePage.ForeColor = Color.Black;
            cmdHomePage.Location = new Point(4, 34);
            cmdHomePage.Name = "cmdHomePage";
            cmdHomePage.Padding = new Padding(3);
            cmdHomePage.Size = new Size(1544, 1077);
            cmdHomePage.TabIndex = 0;
            cmdHomePage.Text = "- Home";
            cmdHomePage.UseVisualStyleBackColor = true;
            cmdHomePage.MouseEnter += cmdHomePage_MouseEnter;
            // 
            // fileOverAllProgressLabel
            // 
            fileOverAllProgressLabel.BackColor = Color.Transparent;
            fileOverAllProgressLabel.ForeColor = Color.Black;
            fileOverAllProgressLabel.Location = new Point(25, 466);
            fileOverAllProgressLabel.Name = "fileOverAllProgressLabel";
            fileOverAllProgressLabel.Size = new Size(176, 118);
            fileOverAllProgressLabel.TabIndex = 189;
            fileOverAllProgressLabel.Text = "File Overall Progress:";
            fileOverAllProgressLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // totalProgressBar
            // 
            totalProgressBar.BackColor = Color.Transparent;
            totalProgressBar.BackgroundRingColor = Color.FromArgb(80, 80, 80, 80);
            totalProgressBar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            totalProgressBar.ForeColor = Color.White;
            totalProgressBar.LineWidth = 12;
            totalProgressBar.Location = new Point(1172, 466);
            totalProgressBar.Maximum = 100;
            totalProgressBar.Minimum = 0;
            totalProgressBar.Name = "totalProgressBar";
            totalProgressBar.ProgressEndColor = Color.FromArgb(200, 0, 191, 255);
            totalProgressBar.ProgressStartColor = Color.FromArgb(200, 123, 104, 238);
            totalProgressBar.Size = new Size(120, 120);
            totalProgressBar.TabIndex = 188;
            totalProgressBar.Text = "modernCircularProgressBar1";
            totalProgressBar.Value = 0;
            // 
            // fileProgressBar
            // 
            fileProgressBar.BackColor = Color.Transparent;
            fileProgressBar.BackgroundRingColor = Color.FromArgb(80, 80, 80, 80);
            fileProgressBar.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            fileProgressBar.ForeColor = Color.White;
            fileProgressBar.LineWidth = 12;
            fileProgressBar.Location = new Point(218, 466);
            fileProgressBar.Maximum = 100;
            fileProgressBar.Minimum = 0;
            fileProgressBar.Name = "fileProgressBar";
            fileProgressBar.ProgressEndColor = Color.FromArgb(200, 0, 191, 255);
            fileProgressBar.ProgressStartColor = Color.FromArgb(200, 123, 104, 238);
            fileProgressBar.Size = new Size(120, 120);
            fileProgressBar.TabIndex = 187;
            fileProgressBar.Text = "modernCircularProgressBar1";
            fileProgressBar.Value = 0;
            // 
            // moveToBottomLabel
            // 
            moveToBottomLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moveToBottomLabel.Location = new Point(1001, 636);
            moveToBottomLabel.Name = "moveToBottomLabel";
            moveToBottomLabel.Size = new Size(48, 52);
            moveToBottomLabel.TabIndex = 186;
            moveToBottomLabel.Text = "⤓";
            moveToBottomLabel.TextAlign = ContentAlignment.MiddleCenter;
            moveToBottomLabel.Click += moveToBottomLabel_Click;
            moveToBottomLabel.MouseEnter += moveToBottomLabel_MouseEnter;
            // 
            // moveToTopLabel
            // 
            moveToTopLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moveToTopLabel.Location = new Point(747, 633);
            moveToTopLabel.Name = "moveToTopLabel";
            moveToTopLabel.Size = new Size(48, 52);
            moveToTopLabel.TabIndex = 185;
            moveToTopLabel.Text = "⤒";
            moveToTopLabel.TextAlign = ContentAlignment.MiddleCenter;
            moveToTopLabel.Click += moveToTopLabel_Click;
            moveToTopLabel.MouseEnter += moveToTopLabel_MouseEnter;
            // 
            // moveFileDownLabel
            // 
            moveFileDownLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moveFileDownLabel.Location = new Point(467, 633);
            moveFileDownLabel.Name = "moveFileDownLabel";
            moveFileDownLabel.Size = new Size(48, 52);
            moveFileDownLabel.TabIndex = 184;
            moveFileDownLabel.Text = "▼";
            moveFileDownLabel.TextAlign = ContentAlignment.MiddleCenter;
            moveFileDownLabel.Click += moveFileDownLabel_Click;
            moveFileDownLabel.MouseEnter += moveFileDownLabel_MouseEnter;
            // 
            // moveFileUpLabel
            // 
            moveFileUpLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            moveFileUpLabel.Location = new Point(200, 633);
            moveFileUpLabel.Name = "moveFileUpLabel";
            moveFileUpLabel.Size = new Size(48, 52);
            moveFileUpLabel.TabIndex = 183;
            moveFileUpLabel.Text = "▲";
            moveFileUpLabel.TextAlign = ContentAlignment.MiddleCenter;
            moveFileUpLabel.Click += moveFileUpLabel_Click;
            moveFileUpLabel.MouseEnter += moveFileUpLabel_MouseEnter;
            // 
            // targetDirectoryLabel
            // 
            targetDirectoryLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            targetDirectoryLabel.Location = new Point(25, 108);
            targetDirectoryLabel.Name = "targetDirectoryLabel";
            targetDirectoryLabel.Size = new Size(54, 52);
            targetDirectoryLabel.TabIndex = 182;
            targetDirectoryLabel.Text = "📁";
            targetDirectoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            targetDirectoryLabel.Click += targetDirectoryLabel_Click;
            targetDirectoryLabel.MouseEnter += targetDirectoryLabel_MouseEnter;
            // 
            // sourceDirectoryLabel
            // 
            sourceDirectoryLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            sourceDirectoryLabel.Location = new Point(25, 54);
            sourceDirectoryLabel.Name = "sourceDirectoryLabel";
            sourceDirectoryLabel.Size = new Size(54, 52);
            sourceDirectoryLabel.TabIndex = 181;
            sourceDirectoryLabel.Text = "📁";
            sourceDirectoryLabel.TextAlign = ContentAlignment.MiddleCenter;
            sourceDirectoryLabel.Click += sourceDirectoryLabel_Click;
            sourceDirectoryLabel.MouseEnter += sourceDirectoryLabel_MouseEnter;
            // 
            // filesDataGridView
            // 
            filesDataGridView.AllowUserToAddRows = false;
            filesDataGridView.AllowUserToDeleteRows = false;
            filesDataGridView.AllowUserToResizeRows = false;
            filesDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            filesDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            filesDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            filesDataGridView.Location = new Point(32, 691);
            filesDataGridView.Name = "filesDataGridView";
            filesDataGridView.RowHeadersVisible = false;
            filesDataGridView.RowHeadersWidth = 62;
            filesDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            filesDataGridView.Size = new Size(1490, 292);
            filesDataGridView.TabIndex = 178;
            // 
            // fileOptionsLabel
            // 
            fileOptionsLabel.BackColor = Color.Transparent;
            fileOptionsLabel.ForeColor = Color.Black;
            fileOptionsLabel.Location = new Point(32, 201);
            fileOptionsLabel.Name = "fileOptionsLabel";
            fileOptionsLabel.Size = new Size(424, 25);
            fileOptionsLabel.TabIndex = 177;
            fileOptionsLabel.Text = "File Options For Processing and After Processing: ||";
            // 
            // statusStrip1
            // 
            statusStrip1.AutoSize = false;
            statusStrip1.Dock = DockStyle.None;
            statusStrip1.ImageScalingSize = new Size(24, 24);
            statusStrip1.Items.AddRange(new ToolStripItem[] { statusLabel });
            statusStrip1.Location = new Point(32, 1023);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(1493, 42);
            statusStrip1.TabIndex = 176;
            statusStrip1.Text = "Status Label";
            // 
            // statusLabel
            // 
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(0, 35);
            statusLabel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // keepOnlyFilesCheckBox
            // 
            keepOnlyFilesCheckBox.BackColor = Color.Transparent;
            keepOnlyFilesCheckBox.ForeColor = Color.Black;
            keepOnlyFilesCheckBox.Location = new Point(1112, 426);
            keepOnlyFilesCheckBox.Name = "keepOnlyFilesCheckBox";
            keepOnlyFilesCheckBox.Size = new Size(380, 34);
            keepOnlyFilesCheckBox.TabIndex = 175;
            keepOnlyFilesCheckBox.Text = "Keep Only Files - No Folders";
            keepOnlyFilesCheckBox.TextAlign = ContentAlignment.TopLeft;
            keepOnlyFilesCheckBox.UseVisualStyleBackColor = false;
            keepOnlyFilesCheckBox.CheckedChanged += keepOnlyFilesCheckBox_CheckedChanged;
            keepOnlyFilesCheckBox.MouseEnter += keepOnlyFilesCheckBox_MouseEnter;
            // 
            // leaveEmptyFoldersCheckBox
            // 
            leaveEmptyFoldersCheckBox.AutoSize = true;
            leaveEmptyFoldersCheckBox.BackColor = Color.Transparent;
            leaveEmptyFoldersCheckBox.ForeColor = Color.Black;
            leaveEmptyFoldersCheckBox.Location = new Point(1112, 391);
            leaveEmptyFoldersCheckBox.Name = "leaveEmptyFoldersCheckBox";
            leaveEmptyFoldersCheckBox.Size = new Size(201, 29);
            leaveEmptyFoldersCheckBox.TabIndex = 174;
            leaveEmptyFoldersCheckBox.Text = "Leave Empty Folders";
            leaveEmptyFoldersCheckBox.UseVisualStyleBackColor = false;
            leaveEmptyFoldersCheckBox.CheckedChanged += keepEmptyFoldersCheckBox_CheckedChanged;
            leaveEmptyFoldersCheckBox.MouseEnter += keepEmptyFoldersCheckBox_MouseEnter;
            // 
            // autoScrollCheckBox
            // 
            autoScrollCheckBox.Location = new Point(1055, 643);
            autoScrollCheckBox.Name = "autoScrollCheckBox";
            autoScrollCheckBox.Size = new Size(164, 34);
            autoScrollCheckBox.TabIndex = 173;
            autoScrollCheckBox.Text = "Auto-Scroll";
            autoScrollCheckBox.TextAlign = ContentAlignment.TopLeft;
            autoScrollCheckBox.UseVisualStyleBackColor = true;
            autoScrollCheckBox.CheckedChanged += autoScrollCheckBox_CheckedChanged;
            autoScrollCheckBox.MouseEnter += autoScrollCheckBox_MouseEnter;
            // 
            // fileNameLabel
            // 
            fileNameLabel.BackColor = Color.Transparent;
            fileNameLabel.ForeColor = Color.Black;
            fileNameLabel.Location = new Point(75, 16);
            fileNameLabel.Name = "fileNameLabel";
            fileNameLabel.Size = new Size(126, 25);
            fileNameLabel.TabIndex = 171;
            fileNameLabel.Text = "File:";
            fileNameLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // verifyCheckBox
            // 
            verifyCheckBox.Location = new Point(1222, 643);
            verifyCheckBox.Name = "verifyCheckBox";
            verifyCheckBox.Size = new Size(303, 34);
            verifyCheckBox.TabIndex = 170;
            verifyCheckBox.Text = "Verify Files After Copying";
            verifyCheckBox.TextAlign = ContentAlignment.TopLeft;
            verifyCheckBox.UseVisualStyleBackColor = false;
            verifyCheckBox.MouseEnter += verifyCheckBox_MouseEnter;
            // 
            // copyFilesDirsCheckBox
            // 
            copyFilesDirsCheckBox.BackColor = Color.Transparent;
            copyFilesDirsCheckBox.ForeColor = Color.Black;
            copyFilesDirsCheckBox.Location = new Point(690, 431);
            copyFilesDirsCheckBox.Name = "copyFilesDirsCheckBox";
            copyFilesDirsCheckBox.Size = new Size(361, 34);
            copyFilesDirsCheckBox.TabIndex = 169;
            copyFilesDirsCheckBox.Text = "Copy Everything Inside Main Folder";
            copyFilesDirsCheckBox.UseVisualStyleBackColor = false;
            copyFilesDirsCheckBox.CheckedChanged += copyFilesDirsCheckBox_CheckedChanged;
            copyFilesDirsCheckBox.MouseEnter += copyFilesDirsCheckBox_MouseEnter;
            // 
            // createCustomDirCheckBox
            // 
            createCustomDirCheckBox.AutoSize = true;
            createCustomDirCheckBox.BackColor = Color.Transparent;
            createCustomDirCheckBox.ForeColor = Color.Black;
            createCustomDirCheckBox.Location = new Point(380, 431);
            createCustomDirCheckBox.Name = "createCustomDirCheckBox";
            createCustomDirCheckBox.Size = new Size(229, 29);
            createCustomDirCheckBox.TabIndex = 168;
            createCustomDirCheckBox.Text = "Create Custom Dir. Prior";
            createCustomDirCheckBox.UseVisualStyleBackColor = false;
            createCustomDirCheckBox.CheckedChanged += createCustomDirCheckBox_CheckedChanged;
            createCustomDirCheckBox.MouseEnter += createCustomDirCheckBox_MouseEnter;
            // 
            // keepDirStructCheckBox
            // 
            keepDirStructCheckBox.AutoSize = true;
            keepDirStructCheckBox.BackColor = Color.Transparent;
            keepDirStructCheckBox.Checked = true;
            keepDirStructCheckBox.CheckState = CheckState.Checked;
            keepDirStructCheckBox.ForeColor = Color.Black;
            keepDirStructCheckBox.Location = new Point(32, 431);
            keepDirStructCheckBox.Name = "keepDirStructCheckBox";
            keepDirStructCheckBox.Size = new Size(229, 29);
            keepDirStructCheckBox.TabIndex = 167;
            keepDirStructCheckBox.Text = "Keep Directory Structure";
            keepDirStructCheckBox.UseVisualStyleBackColor = false;
            keepDirStructCheckBox.CheckedChanged += keepDirStructCheckBox_CheckedChanged;
            keepDirStructCheckBox.MouseEnter += keepDirStructCheckBox_MouseEnter;
            // 
            // totalHDSpaceLeftLabel
            // 
            totalHDSpaceLeftLabel.AutoSize = true;
            totalHDSpaceLeftLabel.BackColor = Color.Transparent;
            totalHDSpaceLeftLabel.ForeColor = Color.Black;
            totalHDSpaceLeftLabel.Location = new Point(933, 359);
            totalHDSpaceLeftLabel.Name = "totalHDSpaceLeftLabel";
            totalHDSpaceLeftLabel.Size = new Size(286, 25);
            totalHDSpaceLeftLabel.TabIndex = 166;
            totalHDSpaceLeftLabel.Text = "Total Space Used: 0 Bytes / 0 Bytes";
            totalHDSpaceLeftLabel.MouseEnter += totalHDSpaceLeftLabel_MouseEnter;
            // 
            // doNotOverwriteCheckBox
            // 
            doNotOverwriteCheckBox.AutoSize = true;
            doNotOverwriteCheckBox.BackColor = Color.Transparent;
            doNotOverwriteCheckBox.ForeColor = Color.Black;
            doNotOverwriteCheckBox.Location = new Point(690, 391);
            doNotOverwriteCheckBox.Name = "doNotOverwriteCheckBox";
            doNotOverwriteCheckBox.Size = new Size(217, 29);
            doNotOverwriteCheckBox.TabIndex = 165;
            doNotOverwriteCheckBox.Text = "Do Not Overwrite Files";
            doNotOverwriteCheckBox.UseVisualStyleBackColor = false;
            doNotOverwriteCheckBox.CheckedChanged += doNotOverwriteCHKBOX_CheckedChanged;
            doNotOverwriteCheckBox.MouseEnter += doNotOverwriteCheckBox_MouseEnter;
            // 
            // overwriteAllCheckBox
            // 
            overwriteAllCheckBox.AutoSize = true;
            overwriteAllCheckBox.BackColor = Color.Transparent;
            overwriteAllCheckBox.ForeColor = Color.Black;
            overwriteAllCheckBox.Location = new Point(380, 391);
            overwriteAllCheckBox.Name = "overwriteAllCheckBox";
            overwriteAllCheckBox.Size = new Size(178, 29);
            overwriteAllCheckBox.TabIndex = 164;
            overwriteAllCheckBox.Text = "Overwrite All Files";
            overwriteAllCheckBox.UseVisualStyleBackColor = false;
            overwriteAllCheckBox.CheckedChanged += overwriteAllCHKBOX_CheckedChanged;
            overwriteAllCheckBox.MouseEnter += overwriteAllCheckBox_MouseEnter;
            // 
            // overwriteIfNewerCheckBox
            // 
            overwriteIfNewerCheckBox.AutoSize = true;
            overwriteIfNewerCheckBox.BackColor = Color.Transparent;
            overwriteIfNewerCheckBox.Checked = true;
            overwriteIfNewerCheckBox.CheckState = CheckState.Checked;
            overwriteIfNewerCheckBox.ForeColor = Color.Black;
            overwriteIfNewerCheckBox.Location = new Point(32, 391);
            overwriteIfNewerCheckBox.Name = "overwriteIfNewerCheckBox";
            overwriteIfNewerCheckBox.Size = new Size(216, 29);
            overwriteIfNewerCheckBox.TabIndex = 163;
            overwriteIfNewerCheckBox.Text = "Overwrite File If Newer";
            overwriteIfNewerCheckBox.UseVisualStyleBackColor = false;
            overwriteIfNewerCheckBox.CheckedChanged += overwriteIfNewerCHKBOX_CheckedChanged;
            overwriteIfNewerCheckBox.MouseDown += overwriteIfNewerCheckBox_MouseDown;
            overwriteIfNewerCheckBox.MouseEnter += overwriteIfNewerCheckBox_MouseEnter;
            // 
            // removeFileButton
            // 
            removeFileButton.BackColor = SystemColors.Control;
            removeFileButton.ForeColor = Color.Black;
            removeFileButton.Location = new Point(1116, 261);
            removeFileButton.Name = "removeFileButton";
            removeFileButton.Size = new Size(193, 45);
            removeFileButton.TabIndex = 161;
            removeFileButton.Text = "Remove File";
            removeFileButton.UseVisualStyleBackColor = false;
            removeFileButton.Click += removeFileButton_Click;
            removeFileButton.MouseEnter += removeFileButton_MouseEnter;
            // 
            // addFileButton
            // 
            addFileButton.BackColor = SystemColors.Control;
            addFileButton.ForeColor = Color.Black;
            addFileButton.Location = new Point(933, 261);
            addFileButton.Name = "addFileButton";
            addFileButton.Size = new Size(160, 45);
            addFileButton.TabIndex = 160;
            addFileButton.Text = "Add File(s)";
            addFileButton.UseVisualStyleBackColor = false;
            addFileButton.Click += addFileButton_Click;
            addFileButton.MouseEnter += addFileButton_MouseEnter;
            // 
            // clearFileListButton
            // 
            clearFileListButton.BackColor = SystemColors.Control;
            clearFileListButton.ForeColor = Color.Black;
            clearFileListButton.Location = new Point(1329, 261);
            clearFileListButton.Name = "clearFileListButton";
            clearFileListButton.Size = new Size(196, 45);
            clearFileListButton.TabIndex = 159;
            clearFileListButton.Text = "Clear File List";
            clearFileListButton.UseVisualStyleBackColor = false;
            clearFileListButton.Click += clearFileListButton_Click;
            clearFileListButton.MouseEnter += clearFileListButton_MouseEnter;
            // 
            // moveBottomLabel
            // 
            moveBottomLabel.Location = new Point(801, 633);
            moveBottomLabel.Name = "moveBottomLabel";
            moveBottomLabel.Size = new Size(199, 55);
            moveBottomLabel.TabIndex = 157;
            moveBottomLabel.Text = "Move File to Bottom:";
            moveBottomLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // moveTopLabel
            // 
            moveTopLabel.Location = new Point(546, 633);
            moveTopLabel.Name = "moveTopLabel";
            moveTopLabel.Size = new Size(182, 55);
            moveTopLabel.TabIndex = 155;
            moveTopLabel.Text = "Move File/Dir. to Top:";
            moveTopLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fileDownLabel
            // 
            fileDownLabel.Location = new Point(275, 633);
            fileDownLabel.Name = "fileDownLabel";
            fileDownLabel.Size = new Size(178, 55);
            fileDownLabel.TabIndex = 153;
            fileDownLabel.Text = "Move File/Dir. Down:";
            fileDownLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // fileUpLabel
            // 
            fileUpLabel.Location = new Point(25, 633);
            fileUpLabel.Name = "fileUpLabel";
            fileUpLabel.Size = new Size(154, 55);
            fileUpLabel.TabIndex = 151;
            fileUpLabel.Text = "Move File/Dir. Up:";
            fileUpLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // clearTextButton
            // 
            clearTextButton.BackColor = SystemColors.Control;
            clearTextButton.ForeColor = Color.Black;
            clearTextButton.Location = new Point(1312, 587);
            clearTextButton.Name = "clearTextButton";
            clearTextButton.Size = new Size(213, 42);
            clearTextButton.TabIndex = 150;
            clearTextButton.Text = "Clear Text";
            clearTextButton.UseVisualStyleBackColor = false;
            clearTextButton.Click += clearTextButton_Click;
            clearTextButton.MouseEnter += clearTextButton_MouseEnter;
            // 
            // searchTextBox
            // 
            searchTextBox.BorderStyle = BorderStyle.FixedSingle;
            searchTextBox.Location = new Point(218, 594);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.PlaceholderText = "Enter FIle/Folder Name to Search For...";
            searchTextBox.Size = new Size(1079, 31);
            searchTextBox.TabIndex = 149;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            searchTextBox.MouseEnter += searchTextBox_MouseEnter;
            // 
            // searchFileFolderLabel
            // 
            searchFileFolderLabel.AutoSize = true;
            searchFileFolderLabel.Location = new Point(25, 596);
            searchFileFolderLabel.Name = "searchFileFolderLabel";
            searchFileFolderLabel.Size = new Size(187, 25);
            searchFileFolderLabel.TabIndex = 148;
            searchFileFolderLabel.Text = "Search For File/Folder:";
            // 
            // fileListLabel
            // 
            fileListLabel.AutoSize = true;
            fileListLabel.BackColor = Color.Transparent;
            fileListLabel.ForeColor = SystemColors.ControlText;
            fileListLabel.Location = new Point(718, 273);
            fileListLabel.Name = "fileListLabel";
            fileListLabel.Size = new Size(142, 25);
            fileListLabel.TabIndex = 147;
            fileListLabel.Text = "File List Options:";
            // 
            // onFinishLabel
            // 
            onFinishLabel.AutoSize = true;
            onFinishLabel.BackColor = Color.Transparent;
            onFinishLabel.ForeColor = Color.Black;
            onFinishLabel.Location = new Point(1003, 201);
            onFinishLabel.Name = "onFinishLabel";
            onFinishLabel.Size = new Size(90, 25);
            onFinishLabel.TabIndex = 146;
            onFinishLabel.Text = "On Finish:";
            // 
            // cmdLabel
            // 
            cmdLabel.AutoSize = true;
            cmdLabel.BackColor = Color.Transparent;
            cmdLabel.ForeColor = Color.Black;
            cmdLabel.Location = new Point(486, 201);
            cmdLabel.Name = "cmdLabel";
            cmdLabel.Size = new Size(70, 25);
            cmdLabel.TabIndex = 145;
            cmdLabel.Text = "C/M/D:";
            // 
            // onFinishComboBox
            // 
            onFinishComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            onFinishComboBox.FormattingEnabled = true;
            onFinishComboBox.Location = new Point(1124, 198);
            onFinishComboBox.Name = "onFinishComboBox";
            onFinishComboBox.Size = new Size(398, 33);
            onFinishComboBox.TabIndex = 144;
            onFinishComboBox.SelectedIndexChanged += onFinishComboBox_SelectedIndexChanged;
            onFinishComboBox.MouseEnter += onFinishComboBox_MouseEnter;
            // 
            // skipButton
            // 
            skipButton.BackColor = SystemColors.Control;
            skipButton.Enabled = false;
            skipButton.ForeColor = Color.Black;
            skipButton.Location = new Point(467, 261);
            skipButton.Name = "skipButton";
            skipButton.Size = new Size(209, 45);
            skipButton.TabIndex = 143;
            skipButton.Text = "Skip Current File";
            skipButton.UseVisualStyleBackColor = false;
            skipButton.Click += skipButton_Click;
            skipButton.MouseEnter += skipButton_MouseEnter;
            // 
            // speedLabel
            // 
            speedLabel.AutoSize = true;
            speedLabel.BackColor = Color.Transparent;
            speedLabel.ForeColor = Color.Black;
            speedLabel.Location = new Point(486, 360);
            speedLabel.Name = "speedLabel";
            speedLabel.Size = new Size(151, 25);
            speedLabel.TabIndex = 141;
            speedLabel.Text = "Speed: 0 Mb/Sec.";
            speedLabel.MouseEnter += speedLabel_MouseEnter;
            // 
            // fileProcessedLabel
            // 
            fileProcessedLabel.AutoSize = true;
            fileProcessedLabel.BackColor = Color.Transparent;
            fileProcessedLabel.ForeColor = Color.Black;
            fileProcessedLabel.Location = new Point(486, 320);
            fileProcessedLabel.Name = "fileProcessedLabel";
            fileProcessedLabel.Size = new Size(268, 25);
            fileProcessedLabel.TabIndex = 140;
            fileProcessedLabel.Text = "File Processed: 0 Bytes /  0 Bytes";
            fileProcessedLabel.MouseEnter += fileProcessedLabel_MouseEnter;
            // 
            // copyMoveDeleteComboBox
            // 
            copyMoveDeleteComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            copyMoveDeleteComboBox.FormattingEnabled = true;
            copyMoveDeleteComboBox.Location = new Point(568, 198);
            copyMoveDeleteComboBox.Name = "copyMoveDeleteComboBox";
            copyMoveDeleteComboBox.Size = new Size(417, 33);
            copyMoveDeleteComboBox.TabIndex = 139;
            copyMoveDeleteComboBox.SelectedIndexChanged += copyMoveDeleteComboBox_SelectedIndexChanged;
            copyMoveDeleteComboBox.MouseEnter += copyMoveDeleteComboBox_MouseEnter;
            // 
            // totalCopiedProgressLabel
            // 
            totalCopiedProgressLabel.AutoSize = true;
            totalCopiedProgressLabel.BackColor = Color.Transparent;
            totalCopiedProgressLabel.ForeColor = Color.Black;
            totalCopiedProgressLabel.Location = new Point(933, 320);
            totalCopiedProgressLabel.Name = "totalCopiedProgressLabel";
            totalCopiedProgressLabel.Size = new Size(253, 25);
            totalCopiedProgressLabel.TabIndex = 138;
            totalCopiedProgressLabel.Text = "Total C/M/D: 0 Bytes /  0 Bytes";
            totalCopiedProgressLabel.MouseEnter += totalCopiedProgressLabel_MouseEnter;
            // 
            // fileCountOnLabel
            // 
            fileCountOnLabel.AutoSize = true;
            fileCountOnLabel.BackColor = Color.Transparent;
            fileCountOnLabel.ForeColor = Color.Black;
            fileCountOnLabel.Location = new Point(32, 320);
            fileCountOnLabel.Name = "fileCountOnLabel";
            fileCountOnLabel.Size = new Size(182, 25);
            fileCountOnLabel.TabIndex = 137;
            fileCountOnLabel.Text = "File Count: 0 Out of 0";
            fileCountOnLabel.MouseEnter += fileCountOnLabel_MouseEnter;
            // 
            // elapsedAndTargetTimeLabel
            // 
            elapsedAndTargetTimeLabel.AutoSize = true;
            elapsedAndTargetTimeLabel.BackColor = Color.Transparent;
            elapsedAndTargetTimeLabel.ForeColor = Color.Black;
            elapsedAndTargetTimeLabel.Location = new Point(32, 359);
            elapsedAndTargetTimeLabel.Name = "elapsedAndTargetTimeLabel";
            elapsedAndTargetTimeLabel.Size = new Size(343, 25);
            elapsedAndTargetTimeLabel.TabIndex = 135;
            elapsedAndTargetTimeLabel.Text = "Elapsed / Target Time: 00:00:00 / 00:00:00";
            elapsedAndTargetTimeLabel.TextAlign = ContentAlignment.TopCenter;
            elapsedAndTargetTimeLabel.MouseEnter += elapsedAndTargetTimeLabel_MouseEnter;
            // 
            // pauseResumeButton
            // 
            pauseResumeButton.BackColor = SystemColors.Control;
            pauseResumeButton.Enabled = false;
            pauseResumeButton.ForeColor = Color.Black;
            pauseResumeButton.Location = new Point(177, 261);
            pauseResumeButton.Name = "pauseResumeButton";
            pauseResumeButton.Size = new Size(112, 45);
            pauseResumeButton.TabIndex = 134;
            pauseResumeButton.Text = "Pause";
            pauseResumeButton.UseVisualStyleBackColor = false;
            pauseResumeButton.Click += pauseResumeButton_Click;
            pauseResumeButton.MouseEnter += pauseResumeButton_MouseEnter;
            // 
            // overallProgressLabel
            // 
            overallProgressLabel.BackColor = Color.Transparent;
            overallProgressLabel.ForeColor = Color.Black;
            overallProgressLabel.Location = new Point(955, 468);
            overallProgressLabel.Name = "overallProgressLabel";
            overallProgressLabel.Size = new Size(187, 118);
            overallProgressLabel.TabIndex = 133;
            overallProgressLabel.Text = "Total Overall Progress:";
            overallProgressLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // cancelButton
            // 
            cancelButton.BackColor = SystemColors.Control;
            cancelButton.Enabled = false;
            cancelButton.ForeColor = Color.Black;
            cancelButton.Location = new Point(322, 261);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new Size(112, 45);
            cancelButton.TabIndex = 126;
            cancelButton.Text = "Cancel";
            cancelButton.UseVisualStyleBackColor = false;
            cancelButton.Click += cancelButton_Click;
            cancelButton.MouseEnter += cancelButton_MouseEnter;
            // 
            // startButton
            // 
            startButton.BackColor = SystemColors.Control;
            startButton.ForeColor = Color.Black;
            startButton.Location = new Point(32, 261);
            startButton.Name = "startButton";
            startButton.Size = new Size(112, 45);
            startButton.TabIndex = 125;
            startButton.Text = "Start";
            startButton.UseVisualStyleBackColor = false;
            startButton.Click += startButton_Click;
            startButton.MouseEnter += startButton_MouseEnter;
            // 
            // fileIconPicBox
            // 
            fileIconPicBox.BackColor = Color.Transparent;
            fileIconPicBox.Image = Properties.Resources.icons8_file_401;
            fileIconPicBox.Location = new Point(32, 9);
            fileIconPicBox.Name = "fileIconPicBox";
            fileIconPicBox.Size = new Size(37, 42);
            fileIconPicBox.SizeMode = PictureBoxSizeMode.StretchImage;
            fileIconPicBox.TabIndex = 122;
            fileIconPicBox.TabStop = false;
            fileIconPicBox.MouseEnter += fileNamePicBox_MouseEnter;
            // 
            // targetDirLabel
            // 
            targetDirLabel.BackColor = Color.Transparent;
            targetDirLabel.ForeColor = Color.Black;
            targetDirLabel.Location = new Point(218, 128);
            targetDirLabel.Name = "targetDirLabel";
            targetDirLabel.Size = new Size(1307, 52);
            targetDirLabel.TabIndex = 121;
            targetDirLabel.Text = "Select Directory";
            targetDirLabel.MouseDown += targetDirLabel_MouseDown;
            targetDirLabel.MouseEnter += targetDirLabel_MouseEnter;
            // 
            // fromFilesDirLabel
            // 
            fromFilesDirLabel.BackColor = Color.Transparent;
            fromFilesDirLabel.ForeColor = Color.Black;
            fromFilesDirLabel.Location = new Point(218, 72);
            fromFilesDirLabel.Name = "fromFilesDirLabel";
            fromFilesDirLabel.Size = new Size(1307, 56);
            fromFilesDirLabel.TabIndex = 120;
            fromFilesDirLabel.Text = "Select Files/Directory";
            fromFilesDirLabel.MouseDown += fromFilesDirLabel_MouseDown;
            fromFilesDirLabel.MouseEnter += fromFilesDirLabel_MouseEnter;
            // 
            // filePathLabel
            // 
            filePathLabel.BackColor = Color.Transparent;
            filePathLabel.ForeColor = Color.Black;
            filePathLabel.Location = new Point(218, 16);
            filePathLabel.Name = "filePathLabel";
            filePathLabel.Size = new Size(1307, 56);
            filePathLabel.TabIndex = 119;
            filePathLabel.Text = "Nothing";
            filePathLabel.MouseDown += filePathLabel_MouseDown;
            filePathLabel.MouseEnter += filePathLabel_MouseEnter;
            // 
            // targetLabel
            // 
            targetLabel.BackColor = Color.Transparent;
            targetLabel.ForeColor = Color.Black;
            targetLabel.Location = new Point(75, 128);
            targetLabel.Name = "targetLabel";
            targetLabel.Size = new Size(137, 25);
            targetLabel.TabIndex = 118;
            targetLabel.Text = "Target(s):";
            targetLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // fromLabel
            // 
            fromLabel.BackColor = Color.Transparent;
            fromLabel.ForeColor = Color.Black;
            fromLabel.Location = new Point(75, 72);
            fromLabel.Name = "fromLabel";
            fromLabel.Size = new Size(126, 25);
            fromLabel.TabIndex = 117;
            fromLabel.Text = "From:";
            fromLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // cmdMultithread
            // 
            cmdMultithread.Controls.Add(thread4Label);
            cmdMultithread.Controls.Add(thread3Label);
            cmdMultithread.Controls.Add(thread2Label);
            cmdMultithread.Controls.Add(thread1Label);
            cmdMultithread.Controls.Add(progressBarMutli1);
            cmdMultithread.Controls.Add(progressBarMutli2);
            cmdMultithread.Controls.Add(progressBarMutli3);
            cmdMultithread.Controls.Add(progressBarMutli4);
            cmdMultithread.Controls.Add(progressBarMultiThreadTotal);
            cmdMultithread.Controls.Add(dataGridView2);
            cmdMultithread.Controls.Add(statusBarMulti);
            cmdMultithread.Controls.Add(totalProgressMultiLabel);
            cmdMultithread.Controls.Add(filesNameLabel4);
            cmdMultithread.Controls.Add(filesNameLabel3);
            cmdMultithread.Controls.Add(filesNameLabel2);
            cmdMultithread.Controls.Add(filesNameLabel1);
            cmdMultithread.Controls.Add(onFinishMultiLabel);
            cmdMultithread.Controls.Add(onFinishMultiComboBox);
            cmdMultithread.Controls.Add(pauseResumeMultiButton);
            cmdMultithread.Controls.Add(cancelMultiButton);
            cmdMultithread.Controls.Add(totalSpaceMultiLabel);
            cmdMultithread.Controls.Add(speedMultiLabel);
            cmdMultithread.Controls.Add(totalCMDMultiLabel);
            cmdMultithread.Controls.Add(fileCountMultiLabel);
            cmdMultithread.Controls.Add(totalTimeMultiLabel);
            cmdMultithread.Location = new Point(4, 34);
            cmdMultithread.Name = "cmdMultithread";
            cmdMultithread.Size = new Size(1544, 1077);
            cmdMultithread.TabIndex = 6;
            cmdMultithread.Text = "- Multithreading";
            cmdMultithread.UseVisualStyleBackColor = true;
            cmdMultithread.MouseEnter += cmdMultithread_MouseEnter;
            // 
            // thread4Label
            // 
            thread4Label.Location = new Point(3, 339);
            thread4Label.Name = "thread4Label";
            thread4Label.Size = new Size(278, 25);
            thread4Label.TabIndex = 203;
            thread4Label.Text = "Thread 4 - Progress / Stats:";
            thread4Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // thread3Label
            // 
            thread3Label.Location = new Point(3, 250);
            thread3Label.Name = "thread3Label";
            thread3Label.Size = new Size(278, 25);
            thread3Label.TabIndex = 202;
            thread3Label.Text = "Thread 3 - Progress / Stats:";
            thread3Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // thread2Label
            // 
            thread2Label.Location = new Point(8, 161);
            thread2Label.Name = "thread2Label";
            thread2Label.Size = new Size(273, 25);
            thread2Label.TabIndex = 201;
            thread2Label.Text = "Thread 2- Progress / Stats:";
            thread2Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // thread1Label
            // 
            thread1Label.Location = new Point(3, 72);
            thread1Label.Name = "thread1Label";
            thread1Label.Size = new Size(278, 25);
            thread1Label.TabIndex = 200;
            thread1Label.Text = "Thread 1 - Progress / Stats:";
            thread1Label.TextAlign = ContentAlignment.MiddleRight;
            // 
            // progressBarMutli1
            // 
            progressBarMutli1.BackColor = Color.Transparent;
            progressBarMutli1.BackgroundRingColor = Color.FromArgb(80, 80, 80, 80);
            progressBarMutli1.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            progressBarMutli1.ForeColor = Color.White;
            progressBarMutli1.LineWidth = 12;
            progressBarMutli1.Location = new Point(331, 26);
            progressBarMutli1.Maximum = 100;
            progressBarMutli1.Minimum = 0;
            progressBarMutli1.Name = "progressBarMutli1";
            progressBarMutli1.ProgressEndColor = Color.FromArgb(200, 0, 191, 255);
            progressBarMutli1.ProgressStartColor = Color.FromArgb(200, 123, 104, 238);
            progressBarMutli1.Size = new Size(93, 86);
            progressBarMutli1.TabIndex = 199;
            progressBarMutli1.Text = "modernCircularProgressBar5";
            progressBarMutli1.Value = 0;
            // 
            // progressBarMutli2
            // 
            progressBarMutli2.BackColor = Color.Transparent;
            progressBarMutli2.BackgroundRingColor = Color.FromArgb(80, 80, 80, 80);
            progressBarMutli2.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            progressBarMutli2.ForeColor = Color.White;
            progressBarMutli2.LineWidth = 12;
            progressBarMutli2.Location = new Point(331, 116);
            progressBarMutli2.Maximum = 100;
            progressBarMutli2.Minimum = 0;
            progressBarMutli2.Name = "progressBarMutli2";
            progressBarMutli2.ProgressEndColor = Color.FromArgb(200, 0, 191, 255);
            progressBarMutli2.ProgressStartColor = Color.FromArgb(200, 123, 104, 238);
            progressBarMutli2.Size = new Size(93, 86);
            progressBarMutli2.TabIndex = 198;
            progressBarMutli2.Text = "modernCircularProgressBar5";
            progressBarMutli2.Value = 0;
            // 
            // progressBarMutli3
            // 
            progressBarMutli3.BackColor = Color.Transparent;
            progressBarMutli3.BackgroundRingColor = Color.FromArgb(80, 80, 80, 80);
            progressBarMutli3.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            progressBarMutli3.ForeColor = Color.White;
            progressBarMutli3.LineWidth = 12;
            progressBarMutli3.Location = new Point(331, 206);
            progressBarMutli3.Maximum = 100;
            progressBarMutli3.Minimum = 0;
            progressBarMutli3.Name = "progressBarMutli3";
            progressBarMutli3.ProgressEndColor = Color.FromArgb(200, 0, 191, 255);
            progressBarMutli3.ProgressStartColor = Color.FromArgb(200, 123, 104, 238);
            progressBarMutli3.Size = new Size(93, 86);
            progressBarMutli3.TabIndex = 197;
            progressBarMutli3.Text = "modernCircularProgressBar5";
            progressBarMutli3.Value = 0;
            // 
            // progressBarMutli4
            // 
            progressBarMutli4.BackColor = Color.Transparent;
            progressBarMutli4.BackgroundRingColor = Color.FromArgb(80, 80, 80, 80);
            progressBarMutli4.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            progressBarMutli4.ForeColor = Color.White;
            progressBarMutli4.LineWidth = 12;
            progressBarMutli4.Location = new Point(331, 296);
            progressBarMutli4.Maximum = 100;
            progressBarMutli4.Minimum = 0;
            progressBarMutli4.Name = "progressBarMutli4";
            progressBarMutli4.ProgressEndColor = Color.FromArgb(200, 0, 191, 255);
            progressBarMutli4.ProgressStartColor = Color.FromArgb(200, 123, 104, 238);
            progressBarMutli4.Size = new Size(93, 86);
            progressBarMutli4.TabIndex = 196;
            progressBarMutli4.Text = "modernCircularProgressBar5";
            progressBarMutli4.Value = 0;
            // 
            // progressBarMultiThreadTotal
            // 
            progressBarMultiThreadTotal.BackColor = Color.Transparent;
            progressBarMultiThreadTotal.BackgroundRingColor = Color.FromArgb(80, 80, 80, 80);
            progressBarMultiThreadTotal.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            progressBarMultiThreadTotal.ForeColor = Color.White;
            progressBarMultiThreadTotal.LineWidth = 12;
            progressBarMultiThreadTotal.Location = new Point(331, 386);
            progressBarMultiThreadTotal.Maximum = 100;
            progressBarMultiThreadTotal.Minimum = 0;
            progressBarMultiThreadTotal.Name = "progressBarMultiThreadTotal";
            progressBarMultiThreadTotal.ProgressEndColor = Color.FromArgb(200, 0, 191, 255);
            progressBarMultiThreadTotal.ProgressStartColor = Color.FromArgb(200, 123, 104, 238);
            progressBarMultiThreadTotal.Size = new Size(93, 86);
            progressBarMultiThreadTotal.TabIndex = 194;
            progressBarMultiThreadTotal.Text = "modernCircularProgressBar5";
            progressBarMultiThreadTotal.Value = 0;
            // 
            // dataGridView2
            // 
            dataGridView2.AllowUserToAddRows = false;
            dataGridView2.AllowUserToDeleteRows = false;
            dataGridView2.AllowUserToOrderColumns = true;
            dataGridView2.AllowUserToResizeColumns = false;
            dataGridView2.AllowUserToResizeRows = false;
            dataGridView2.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView2.BackgroundColor = Color.DarkGray;
            dataGridView2.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView2.Location = new Point(55, 580);
            dataGridView2.MultiSelect = false;
            dataGridView2.Name = "dataGridView2";
            dataGridView2.ReadOnly = true;
            dataGridView2.RowHeadersVisible = false;
            dataGridView2.RowHeadersWidth = 62;
            dataGridView2.ScrollBars = ScrollBars.Vertical;
            dataGridView2.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView2.Size = new Size(1371, 327);
            dataGridView2.TabIndex = 189;
            // 
            // statusBarMulti
            // 
            statusBarMulti.AutoSize = false;
            statusBarMulti.Dock = DockStyle.None;
            statusBarMulti.ImageScalingSize = new Size(24, 24);
            statusBarMulti.Items.AddRange(new ToolStripItem[] { toolStripMulti });
            statusBarMulti.Location = new Point(55, 1006);
            statusBarMulti.Name = "statusBarMulti";
            statusBarMulti.Size = new Size(1374, 42);
            statusBarMulti.TabIndex = 188;
            statusBarMulti.Text = "Status Label";
            // 
            // toolStripMulti
            // 
            toolStripMulti.Name = "toolStripMulti";
            toolStripMulti.Size = new Size(0, 35);
            toolStripMulti.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // totalProgressMultiLabel
            // 
            totalProgressMultiLabel.BackColor = Color.Transparent;
            totalProgressMultiLabel.ForeColor = Color.Black;
            totalProgressMultiLabel.Location = new Point(3, 428);
            totalProgressMultiLabel.Name = "totalProgressMultiLabel";
            totalProgressMultiLabel.Size = new Size(278, 25);
            totalProgressMultiLabel.TabIndex = 187;
            totalProgressMultiLabel.Text = "Total Overall Progress:";
            totalProgressMultiLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // filesNameLabel4
            // 
            filesNameLabel4.BackColor = Color.Transparent;
            filesNameLabel4.ForeColor = Color.Black;
            filesNameLabel4.Location = new Point(477, 334);
            filesNameLabel4.Name = "filesNameLabel4";
            filesNameLabel4.Size = new Size(1061, 30);
            filesNameLabel4.TabIndex = 183;
            filesNameLabel4.Text = "Nothing";
            filesNameLabel4.MouseEnter += filesNameLabel4_MouseEnter;
            // 
            // filesNameLabel3
            // 
            filesNameLabel3.BackColor = Color.Transparent;
            filesNameLabel3.ForeColor = Color.Black;
            filesNameLabel3.Location = new Point(477, 245);
            filesNameLabel3.Name = "filesNameLabel3";
            filesNameLabel3.Size = new Size(1061, 30);
            filesNameLabel3.TabIndex = 181;
            filesNameLabel3.Text = "Nothing";
            filesNameLabel3.MouseEnter += filesNameLabel3_MouseEnter;
            // 
            // filesNameLabel2
            // 
            filesNameLabel2.BackColor = Color.Transparent;
            filesNameLabel2.ForeColor = Color.Black;
            filesNameLabel2.Location = new Point(477, 156);
            filesNameLabel2.Name = "filesNameLabel2";
            filesNameLabel2.Size = new Size(1064, 30);
            filesNameLabel2.TabIndex = 179;
            filesNameLabel2.Text = "Nothing";
            filesNameLabel2.MouseEnter += filesNameLabel2_MouseEnter;
            // 
            // filesNameLabel1
            // 
            filesNameLabel1.BackColor = Color.Transparent;
            filesNameLabel1.ForeColor = Color.Black;
            filesNameLabel1.Location = new Point(477, 67);
            filesNameLabel1.Name = "filesNameLabel1";
            filesNameLabel1.Size = new Size(1064, 30);
            filesNameLabel1.TabIndex = 177;
            filesNameLabel1.Text = "Nothing";
            filesNameLabel1.MouseEnter += filesNameLabel1_MouseEnter;
            // 
            // onFinishMultiLabel
            // 
            onFinishMultiLabel.BackColor = Color.Transparent;
            onFinishMultiLabel.ForeColor = Color.Black;
            onFinishMultiLabel.Location = new Point(922, 18);
            onFinishMultiLabel.Name = "onFinishMultiLabel";
            onFinishMultiLabel.Size = new Size(127, 30);
            onFinishMultiLabel.TabIndex = 176;
            onFinishMultiLabel.Text = "On Finish:";
            onFinishMultiLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // onFinishMultiComboBox
            // 
            onFinishMultiComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            onFinishMultiComboBox.FormattingEnabled = true;
            onFinishMultiComboBox.Location = new Point(1055, 15);
            onFinishMultiComboBox.Name = "onFinishMultiComboBox";
            onFinishMultiComboBox.Size = new Size(361, 33);
            onFinishMultiComboBox.TabIndex = 175;
            onFinishMultiComboBox.SelectedIndexChanged += cmbOnFinishMulti_SelectedIndexChanged;
            onFinishMultiComboBox.MouseEnter += onFinishMultiComboBox_MouseEnter;
            // 
            // pauseResumeMultiButton
            // 
            pauseResumeMultiButton.BackColor = SystemColors.Control;
            pauseResumeMultiButton.Enabled = false;
            pauseResumeMultiButton.ForeColor = Color.Black;
            pauseResumeMultiButton.Location = new Point(655, 12);
            pauseResumeMultiButton.Name = "pauseResumeMultiButton";
            pauseResumeMultiButton.Size = new Size(112, 36);
            pauseResumeMultiButton.TabIndex = 174;
            pauseResumeMultiButton.Text = "Pause";
            pauseResumeMultiButton.UseVisualStyleBackColor = false;
            pauseResumeMultiButton.Click += btnPauseResumeMulti_Click;
            pauseResumeMultiButton.MouseEnter += pauseResumeMultiButton_MouseEnter;
            // 
            // cancelMultiButton
            // 
            cancelMultiButton.BackColor = SystemColors.Control;
            cancelMultiButton.Enabled = false;
            cancelMultiButton.ForeColor = Color.Black;
            cancelMultiButton.Location = new Point(789, 12);
            cancelMultiButton.Name = "cancelMultiButton";
            cancelMultiButton.Size = new Size(112, 36);
            cancelMultiButton.TabIndex = 173;
            cancelMultiButton.Text = "Cancel";
            cancelMultiButton.UseVisualStyleBackColor = false;
            cancelMultiButton.Click += cancelMultiButton_Click;
            cancelMultiButton.MouseEnter += cancelMultiButton_MouseEnter;
            // 
            // totalSpaceMultiLabel
            // 
            totalSpaceMultiLabel.AutoSize = true;
            totalSpaceMultiLabel.BackColor = Color.Transparent;
            totalSpaceMultiLabel.ForeColor = Color.Black;
            totalSpaceMultiLabel.Location = new Point(1163, 521);
            totalSpaceMultiLabel.Name = "totalSpaceMultiLabel";
            totalSpaceMultiLabel.Size = new Size(286, 25);
            totalSpaceMultiLabel.TabIndex = 172;
            totalSpaceMultiLabel.Text = "Total Space Used: 0 Bytes / 0 Bytes";
            totalSpaceMultiLabel.MouseEnter += totalSpaceMultiLabel_MouseEnter;
            // 
            // speedMultiLabel
            // 
            speedMultiLabel.AutoSize = true;
            speedMultiLabel.BackColor = Color.Transparent;
            speedMultiLabel.ForeColor = Color.Black;
            speedMultiLabel.Location = new Point(626, 505);
            speedMultiLabel.Name = "speedMultiLabel";
            speedMultiLabel.Size = new Size(151, 25);
            speedMultiLabel.TabIndex = 171;
            speedMultiLabel.Text = "Speed: 0 Mb/Sec.";
            speedMultiLabel.MouseEnter += speedMultiLabel_MouseEnter;
            // 
            // totalCMDMultiLabel
            // 
            totalCMDMultiLabel.AutoSize = true;
            totalCMDMultiLabel.BackColor = Color.Transparent;
            totalCMDMultiLabel.ForeColor = Color.Black;
            totalCMDMultiLabel.Location = new Point(1163, 481);
            totalCMDMultiLabel.Name = "totalCMDMultiLabel";
            totalCMDMultiLabel.Size = new Size(253, 25);
            totalCMDMultiLabel.TabIndex = 169;
            totalCMDMultiLabel.Text = "Total C/M/D: 0 Bytes /  0 Bytes";
            totalCMDMultiLabel.MouseEnter += totalCMDMultiLabel_MouseEnter;
            // 
            // fileCountMultiLabel
            // 
            fileCountMultiLabel.AutoSize = true;
            fileCountMultiLabel.BackColor = Color.Transparent;
            fileCountMultiLabel.ForeColor = Color.Black;
            fileCountMultiLabel.Location = new Point(52, 481);
            fileCountMultiLabel.Name = "fileCountMultiLabel";
            fileCountMultiLabel.Size = new Size(182, 25);
            fileCountMultiLabel.TabIndex = 168;
            fileCountMultiLabel.Text = "File Count: 0 Out of 0";
            fileCountMultiLabel.MouseEnter += fileCountMultiLabel_MouseEnter;
            // 
            // totalTimeMultiLabel
            // 
            totalTimeMultiLabel.AutoSize = true;
            totalTimeMultiLabel.BackColor = Color.Transparent;
            totalTimeMultiLabel.ForeColor = Color.Black;
            totalTimeMultiLabel.Location = new Point(52, 520);
            totalTimeMultiLabel.Name = "totalTimeMultiLabel";
            totalTimeMultiLabel.Size = new Size(343, 25);
            totalTimeMultiLabel.TabIndex = 167;
            totalTimeMultiLabel.Text = "Elapsed / Target Time: 00:00:00 / 00:00:00";
            totalTimeMultiLabel.MouseEnter += totalTimeMultiLabel_MouseEnter;
            // 
            // cmdSkipPage
            // 
            cmdSkipPage.Controls.Add(statusBarSkipped);
            cmdSkipPage.Controls.Add(totalSkippedLabel);
            cmdSkipPage.Controls.Add(clearSkippedListButton);
            cmdSkipPage.Controls.Add(goToInExplorerButton);
            cmdSkipPage.Controls.Add(skippedDataGridView);
            cmdSkipPage.Location = new Point(4, 34);
            cmdSkipPage.Name = "cmdSkipPage";
            cmdSkipPage.Size = new Size(1544, 1077);
            cmdSkipPage.TabIndex = 2;
            cmdSkipPage.Text = "- Skipped Files";
            cmdSkipPage.UseVisualStyleBackColor = true;
            cmdSkipPage.MouseEnter += cmdSkipPage_MouseEnter;
            // 
            // statusBarSkipped
            // 
            statusBarSkipped.AutoSize = false;
            statusBarSkipped.Dock = DockStyle.None;
            statusBarSkipped.ImageScalingSize = new Size(24, 24);
            statusBarSkipped.Items.AddRange(new ToolStripItem[] { toolStripSkipped });
            statusBarSkipped.Location = new Point(54, 1025);
            statusBarSkipped.Name = "statusBarSkipped";
            statusBarSkipped.Size = new Size(1438, 42);
            statusBarSkipped.TabIndex = 189;
            statusBarSkipped.Text = "Status Label";
            // 
            // toolStripSkipped
            // 
            toolStripSkipped.Name = "toolStripSkipped";
            toolStripSkipped.Size = new Size(0, 35);
            toolStripSkipped.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // totalSkippedLabel
            // 
            totalSkippedLabel.AutoSize = true;
            totalSkippedLabel.BackColor = Color.Transparent;
            totalSkippedLabel.Location = new Point(54, 187);
            totalSkippedLabel.Name = "totalSkippedLabel";
            totalSkippedLabel.Size = new Size(177, 25);
            totalSkippedLabel.TabIndex = 89;
            totalSkippedLabel.Text = "Total Skipped Files: 0";
            totalSkippedLabel.MouseEnter += totalSkippedLabel_MouseEnter;
            // 
            // clearSkippedListButton
            // 
            clearSkippedListButton.BackColor = SystemColors.Control;
            clearSkippedListButton.Location = new Point(1158, 124);
            clearSkippedListButton.Name = "clearSkippedListButton";
            clearSkippedListButton.Size = new Size(335, 41);
            clearSkippedListButton.TabIndex = 88;
            clearSkippedListButton.Text = "Clear Skipped List";
            clearSkippedListButton.UseVisualStyleBackColor = false;
            clearSkippedListButton.Click += btnClearSkippedList_Click;
            clearSkippedListButton.MouseEnter += clearSkippedListButton_MouseEnter;
            // 
            // goToInExplorerButton
            // 
            goToInExplorerButton.BackColor = SystemColors.Control;
            goToInExplorerButton.Location = new Point(54, 124);
            goToInExplorerButton.Name = "goToInExplorerButton";
            goToInExplorerButton.Size = new Size(335, 41);
            goToInExplorerButton.TabIndex = 87;
            goToInExplorerButton.Text = "Open File In Explorer";
            goToInExplorerButton.UseVisualStyleBackColor = false;
            goToInExplorerButton.Click += btnGoToInExplorer_Click;
            goToInExplorerButton.MouseEnter += goToInExplorerButton_MouseEnter;
            // 
            // skippedDataGridView
            // 
            skippedDataGridView.AllowUserToAddRows = false;
            skippedDataGridView.AllowUserToDeleteRows = false;
            skippedDataGridView.AllowUserToOrderColumns = true;
            skippedDataGridView.AllowUserToResizeColumns = false;
            skippedDataGridView.AllowUserToResizeRows = false;
            skippedDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            skippedDataGridView.BackgroundColor = Color.DarkGray;
            skippedDataGridView.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            skippedDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            skippedDataGridView.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, sourcePath, destinationPath, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4 });
            skippedDataGridView.EditMode = DataGridViewEditMode.EditProgrammatically;
            skippedDataGridView.Location = new Point(52, 215);
            skippedDataGridView.MultiSelect = false;
            skippedDataGridView.Name = "skippedDataGridView";
            skippedDataGridView.ReadOnly = true;
            skippedDataGridView.RowHeadersVisible = false;
            skippedDataGridView.RowHeadersWidth = 62;
            skippedDataGridView.ScrollBars = ScrollBars.Vertical;
            skippedDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            skippedDataGridView.Size = new Size(1441, 507);
            skippedDataGridView.TabIndex = 86;
            skippedDataGridView.MouseEnter += skippedDataGridView_MouseEnter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Status";
            dataGridViewTextBoxColumn1.MinimumWidth = 8;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Resizable = DataGridViewTriState.True;
            // 
            // sourcePath
            // 
            sourcePath.HeaderText = "Source File Path";
            sourcePath.MinimumWidth = 8;
            sourcePath.Name = "sourcePath";
            sourcePath.ReadOnly = true;
            // 
            // destinationPath
            // 
            destinationPath.HeaderText = "Destination File Path";
            destinationPath.MinimumWidth = 8;
            destinationPath.Name = "destinationPath";
            destinationPath.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "File Name";
            dataGridViewTextBoxColumn3.MinimumWidth = 8;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "File's Size";
            dataGridViewTextBoxColumn4.MinimumWidth = 8;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // cmdCopyHistory
            // 
            cmdCopyHistory.Controls.Add(copyHistoryDGV);
            cmdCopyHistory.Controls.Add(statusBarCopyHistory);
            cmdCopyHistory.Controls.Add(deleteEntryButton);
            cmdCopyHistory.Controls.Add(totalHistoryLabel);
            cmdCopyHistory.Controls.Add(clearHistoryButton);
            cmdCopyHistory.Controls.Add(cloneButton);
            cmdCopyHistory.Location = new Point(4, 34);
            cmdCopyHistory.Name = "cmdCopyHistory";
            cmdCopyHistory.Size = new Size(1544, 1077);
            cmdCopyHistory.TabIndex = 3;
            cmdCopyHistory.Text = "- Copy History";
            cmdCopyHistory.UseVisualStyleBackColor = true;
            // 
            // copyHistoryDGV
            // 
            copyHistoryDGV.AllowUserToAddRows = false;
            copyHistoryDGV.AllowUserToDeleteRows = false;
            copyHistoryDGV.AllowUserToOrderColumns = true;
            copyHistoryDGV.AllowUserToResizeColumns = false;
            copyHistoryDGV.AllowUserToResizeRows = false;
            copyHistoryDGV.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            copyHistoryDGV.BackgroundColor = Color.DarkGray;
            copyHistoryDGV.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            copyHistoryDGV.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            copyHistoryDGV.Columns.AddRange(new DataGridViewColumn[] { Operation, dataGridViewTextBoxColumn11, dataGridViewTextBoxColumn12, TotalDirSize });
            copyHistoryDGV.EditMode = DataGridViewEditMode.EditProgrammatically;
            copyHistoryDGV.Location = new Point(52, 285);
            copyHistoryDGV.MultiSelect = false;
            copyHistoryDGV.Name = "copyHistoryDGV";
            copyHistoryDGV.ReadOnly = true;
            copyHistoryDGV.RowHeadersVisible = false;
            copyHistoryDGV.RowHeadersWidth = 62;
            copyHistoryDGV.ScrollBars = ScrollBars.Vertical;
            copyHistoryDGV.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            copyHistoryDGV.Size = new Size(1441, 507);
            copyHistoryDGV.TabIndex = 191;
            copyHistoryDGV.MouseEnter += copyHistoryDGV_MouseEnter;
            // 
            // Operation
            // 
            Operation.HeaderText = "Operation Type";
            Operation.MinimumWidth = 8;
            Operation.Name = "Operation";
            Operation.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            dataGridViewTextBoxColumn11.HeaderText = "Source File Path";
            dataGridViewTextBoxColumn11.MinimumWidth = 8;
            dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn12
            // 
            dataGridViewTextBoxColumn12.HeaderText = "Destination File Path(s)";
            dataGridViewTextBoxColumn12.MinimumWidth = 8;
            dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // TotalDirSize
            // 
            TotalDirSize.HeaderText = "Total Size of Dir(s).";
            TotalDirSize.MinimumWidth = 8;
            TotalDirSize.Name = "TotalDirSize";
            TotalDirSize.ReadOnly = true;
            // 
            // statusBarCopyHistory
            // 
            statusBarCopyHistory.AutoSize = false;
            statusBarCopyHistory.Dock = DockStyle.None;
            statusBarCopyHistory.ImageScalingSize = new Size(24, 24);
            statusBarCopyHistory.Items.AddRange(new ToolStripItem[] { toolStripCopyHistory });
            statusBarCopyHistory.Location = new Point(31, 1023);
            statusBarCopyHistory.Name = "statusBarCopyHistory";
            statusBarCopyHistory.Size = new Size(1438, 42);
            statusBarCopyHistory.TabIndex = 190;
            statusBarCopyHistory.Text = "Status Label";
            // 
            // toolStripCopyHistory
            // 
            toolStripCopyHistory.Name = "toolStripCopyHistory";
            toolStripCopyHistory.Size = new Size(0, 35);
            toolStripCopyHistory.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // deleteEntryButton
            // 
            deleteEntryButton.BackColor = SystemColors.Control;
            deleteEntryButton.Location = new Point(647, 201);
            deleteEntryButton.Name = "deleteEntryButton";
            deleteEntryButton.Size = new Size(251, 43);
            deleteEntryButton.TabIndex = 94;
            deleteEntryButton.Text = "Delete Entry";
            deleteEntryButton.UseVisualStyleBackColor = false;
            deleteEntryButton.MouseEnter += deleteEntryButton_MouseEnter;
            // 
            // totalHistoryLabel
            // 
            totalHistoryLabel.AutoSize = true;
            totalHistoryLabel.BackColor = Color.Transparent;
            totalHistoryLabel.Location = new Point(52, 257);
            totalHistoryLabel.Name = "totalHistoryLabel";
            totalHistoryLabel.Size = new Size(179, 25);
            totalHistoryLabel.TabIndex = 93;
            totalHistoryLabel.Text = "Total History Items: 0";
            totalHistoryLabel.MouseEnter += totalHistoryLabel_MouseEnter;
            // 
            // clearHistoryButton
            // 
            clearHistoryButton.BackColor = SystemColors.Control;
            clearHistoryButton.Location = new Point(1242, 201);
            clearHistoryButton.Name = "clearHistoryButton";
            clearHistoryButton.Size = new Size(251, 43);
            clearHistoryButton.TabIndex = 92;
            clearHistoryButton.Text = "Clear History";
            clearHistoryButton.UseVisualStyleBackColor = false;
            clearHistoryButton.Click += clearHistoryButton_Click;
            clearHistoryButton.MouseEnter += clearHistoryButton_MouseEnter;
            // 
            // cloneButton
            // 
            cloneButton.BackColor = SystemColors.Control;
            cloneButton.Location = new Point(52, 201);
            cloneButton.Name = "cloneButton";
            cloneButton.Size = new Size(251, 43);
            cloneButton.TabIndex = 91;
            cloneButton.Text = "Rescan && Clone";
            cloneButton.UseVisualStyleBackColor = false;
            cloneButton.MouseEnter += cloneButton_MouseEnter;
            // 
            // cmdExclusions
            // 
            cmdExclusions.Controls.Add(statusBarExclusions);
            cmdExclusions.Controls.Add(clearExcludedButton);
            cmdExclusions.Controls.Add(removeExcludedButton);
            cmdExclusions.Controls.Add(addExcludedButton);
            cmdExclusions.Controls.Add(clearAllowedButton);
            cmdExclusions.Controls.Add(removeAllowedButton);
            cmdExclusions.Controls.Add(addAllowedButton);
            cmdExclusions.Controls.Add(excludedTextBox);
            cmdExclusions.Controls.Add(allowedTextBox);
            cmdExclusions.Controls.Add(excludedLabel);
            cmdExclusions.Controls.Add(allowedLabel);
            cmdExclusions.Controls.Add(excludedExtListBox);
            cmdExclusions.Controls.Add(allowedExtListBox);
            cmdExclusions.Location = new Point(4, 34);
            cmdExclusions.Name = "cmdExclusions";
            cmdExclusions.Size = new Size(1544, 1077);
            cmdExclusions.TabIndex = 4;
            cmdExclusions.Text = "- Exclusions";
            cmdExclusions.UseVisualStyleBackColor = true;
            cmdExclusions.MouseEnter += cmdExclusions_MouseEnter;
            // 
            // statusBarExclusions
            // 
            statusBarExclusions.AutoSize = false;
            statusBarExclusions.Dock = DockStyle.None;
            statusBarExclusions.ImageScalingSize = new Size(24, 24);
            statusBarExclusions.Items.AddRange(new ToolStripItem[] { toolStripExclusions });
            statusBarExclusions.Location = new Point(52, 1015);
            statusBarExclusions.Name = "statusBarExclusions";
            statusBarExclusions.Size = new Size(1438, 42);
            statusBarExclusions.TabIndex = 191;
            statusBarExclusions.Text = "Status Label";
            // 
            // toolStripExclusions
            // 
            toolStripExclusions.Name = "toolStripExclusions";
            toolStripExclusions.Size = new Size(0, 35);
            toolStripExclusions.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // clearExcludedButton
            // 
            clearExcludedButton.BackColor = SystemColors.Control;
            clearExcludedButton.ForeColor = Color.Black;
            clearExcludedButton.Location = new Point(1329, 227);
            clearExcludedButton.Name = "clearExcludedButton";
            clearExcludedButton.Size = new Size(161, 46);
            clearExcludedButton.TabIndex = 87;
            clearExcludedButton.Text = "Clear List";
            clearExcludedButton.UseVisualStyleBackColor = false;
            clearExcludedButton.Click += btnClearExcluded_Click;
            clearExcludedButton.MouseEnter += clearExcludedButton_MouseEnter;
            // 
            // removeExcludedButton
            // 
            removeExcludedButton.BackColor = SystemColors.Control;
            removeExcludedButton.ForeColor = Color.Black;
            removeExcludedButton.Location = new Point(1123, 227);
            removeExcludedButton.Name = "removeExcludedButton";
            removeExcludedButton.Size = new Size(161, 46);
            removeExcludedButton.TabIndex = 86;
            removeExcludedButton.Text = "Remove Ext.";
            removeExcludedButton.UseVisualStyleBackColor = false;
            removeExcludedButton.Click += btnRemoveExcluded_Click;
            removeExcludedButton.MouseEnter += removeExcludedButton_MouseEnter;
            // 
            // addExcludedButton
            // 
            addExcludedButton.BackColor = SystemColors.Control;
            addExcludedButton.ForeColor = Color.Black;
            addExcludedButton.Location = new Point(917, 227);
            addExcludedButton.Name = "addExcludedButton";
            addExcludedButton.Size = new Size(161, 46);
            addExcludedButton.TabIndex = 85;
            addExcludedButton.Text = "Add Ext.";
            addExcludedButton.UseVisualStyleBackColor = false;
            addExcludedButton.Click += btnAddExcluded_Click;
            addExcludedButton.MouseEnter += addExcludedButton_MouseEnter;
            // 
            // clearAllowedButton
            // 
            clearAllowedButton.BackColor = SystemColors.Control;
            clearAllowedButton.ForeColor = Color.Black;
            clearAllowedButton.Location = new Point(465, 227);
            clearAllowedButton.Name = "clearAllowedButton";
            clearAllowedButton.Size = new Size(161, 46);
            clearAllowedButton.TabIndex = 84;
            clearAllowedButton.Text = "Clear List";
            clearAllowedButton.UseVisualStyleBackColor = false;
            clearAllowedButton.Click += btnClearAllowed_Click;
            clearAllowedButton.MouseEnter += clearAllowedButton_MouseEnter;
            // 
            // removeAllowedButton
            // 
            removeAllowedButton.BackColor = SystemColors.Control;
            removeAllowedButton.ForeColor = Color.Black;
            removeAllowedButton.Location = new Point(259, 227);
            removeAllowedButton.Name = "removeAllowedButton";
            removeAllowedButton.Size = new Size(161, 46);
            removeAllowedButton.TabIndex = 83;
            removeAllowedButton.Text = "Remove Ext.";
            removeAllowedButton.UseVisualStyleBackColor = false;
            removeAllowedButton.Click += btnRemoveAllowed_Click;
            removeAllowedButton.MouseEnter += removeAllowedButton_MouseEnter;
            // 
            // addAllowedButton
            // 
            addAllowedButton.BackColor = SystemColors.Control;
            addAllowedButton.ForeColor = Color.Black;
            addAllowedButton.Location = new Point(53, 227);
            addAllowedButton.Name = "addAllowedButton";
            addAllowedButton.Size = new Size(161, 46);
            addAllowedButton.TabIndex = 82;
            addAllowedButton.Text = "Add Ext.";
            addAllowedButton.UseVisualStyleBackColor = false;
            addAllowedButton.Click += btnAddAllowed_Click;
            addAllowedButton.MouseEnter += addAllowedButton_MouseEnter;
            // 
            // excludedTextBox
            // 
            excludedTextBox.Location = new Point(917, 311);
            excludedTextBox.MaxLength = 6;
            excludedTextBox.Name = "excludedTextBox";
            excludedTextBox.Size = new Size(574, 31);
            excludedTextBox.TabIndex = 81;
            excludedTextBox.TextChanged += excludedTextBox_TextChanged;
            excludedTextBox.KeyDown += excludedTextBox_KeyDown;
            excludedTextBox.KeyPress += excludedTextBox_KeyPress;
            excludedTextBox.MouseEnter += excludedTextBox_MouseEnter;
            // 
            // allowedTextBox
            // 
            allowedTextBox.Location = new Point(53, 311);
            allowedTextBox.MaxLength = 6;
            allowedTextBox.Name = "allowedTextBox";
            allowedTextBox.Size = new Size(574, 31);
            allowedTextBox.TabIndex = 80;
            allowedTextBox.TextChanged += allowedTextBox_TextChanged;
            allowedTextBox.KeyDown += allowedTextBox_KeyDown;
            allowedTextBox.KeyPress += allowedTextBox_KeyPress;
            allowedTextBox.MouseEnter += allowedTextBox_MouseEnter;
            // 
            // excludedLabel
            // 
            excludedLabel.AutoSize = true;
            excludedLabel.BackColor = Color.Transparent;
            excludedLabel.Location = new Point(917, 355);
            excludedLabel.Name = "excludedLabel";
            excludedLabel.Size = new Size(174, 25);
            excludedLabel.TabIndex = 79;
            excludedLabel.Text = "Excluded Extensions:";
            // 
            // allowedLabel
            // 
            allowedLabel.AutoSize = true;
            allowedLabel.BackColor = Color.Transparent;
            allowedLabel.Location = new Point(53, 355);
            allowedLabel.Name = "allowedLabel";
            allowedLabel.Size = new Size(168, 25);
            allowedLabel.TabIndex = 78;
            allowedLabel.Text = "Allowed Extensions:";
            // 
            // excludedExtListBox
            // 
            excludedExtListBox.FormattingEnabled = true;
            excludedExtListBox.ItemHeight = 25;
            excludedExtListBox.Location = new Point(917, 382);
            excludedExtListBox.Name = "excludedExtListBox";
            excludedExtListBox.ScrollAlwaysVisible = true;
            excludedExtListBox.Size = new Size(574, 379);
            excludedExtListBox.TabIndex = 77;
            excludedExtListBox.MouseEnter += excludedExtListBox_MouseEnter;
            // 
            // allowedExtListBox
            // 
            allowedExtListBox.FormattingEnabled = true;
            allowedExtListBox.ItemHeight = 25;
            allowedExtListBox.Items.AddRange(new object[] { "*.*" });
            allowedExtListBox.Location = new Point(53, 383);
            allowedExtListBox.Name = "allowedExtListBox";
            allowedExtListBox.ScrollAlwaysVisible = true;
            allowedExtListBox.Size = new Size(574, 379);
            allowedExtListBox.TabIndex = 76;
            allowedExtListBox.MouseEnter += allowedExtListBox_MouseEnter;
            // 
            // cmdTotals
            // 
            cmdTotals.Controls.Add(resetTotalsButton);
            cmdTotals.Controls.Add(totalTargetTimeLabel);
            cmdTotals.Controls.Add(totalElapsedTimeLabel);
            cmdTotals.Controls.Add(totalBytesToProcessLabel);
            cmdTotals.Controls.Add(totalBytesProcessedLabel);
            cmdTotals.Controls.Add(totalTargetTimeTitleLabel);
            cmdTotals.Controls.Add(totalElapsedTimeTitleLabel);
            cmdTotals.Controls.Add(totalBytesToProcessTitleLabel);
            cmdTotals.Controls.Add(totalBytesProcessedTitleLabel);
            cmdTotals.Controls.Add(totalFilesMovedLabel);
            cmdTotals.Controls.Add(totalFilesMovedTitleLabel);
            cmdTotals.Controls.Add(totalFilesFailedLabel);
            cmdTotals.Controls.Add(totalFilesSkippedLabel);
            cmdTotals.Controls.Add(totalFilesDeletedLabel);
            cmdTotals.Controls.Add(totalFilesCopiedLabel);
            cmdTotals.Controls.Add(totalFilesConsideredTitleLabel);
            cmdTotals.Controls.Add(totalFilesFailedTitleLabel);
            cmdTotals.Controls.Add(totalFilesSkippedTitleLabel);
            cmdTotals.Controls.Add(totalFilesDeletedTitleLabel);
            cmdTotals.Controls.Add(totalFilesCopiedTitleLabel);
            cmdTotals.Controls.Add(totalFilesConsideredLabel);
            cmdTotals.Controls.Add(totalCompletedOperationsLabel);
            cmdTotals.Controls.Add(totalCancelledOperationsLabel);
            cmdTotals.Controls.Add(totalDeleteOperationsLabel);
            cmdTotals.Controls.Add(totalMoveOperationsLabel);
            cmdTotals.Controls.Add(totalCopyOperationsTitleLabel);
            cmdTotals.Controls.Add(totalCompletedOperationsTitleLabel);
            cmdTotals.Controls.Add(totalCancelledOperationsTitleLabel);
            cmdTotals.Controls.Add(totalDeleteOperationsTItleLabel);
            cmdTotals.Controls.Add(totalMoveOperationsTitleLabel);
            cmdTotals.Controls.Add(totalCopyOperationsLabel);
            cmdTotals.Controls.Add(titleTotalsLabel);
            cmdTotals.Location = new Point(4, 34);
            cmdTotals.Name = "cmdTotals";
            cmdTotals.Padding = new Padding(3);
            cmdTotals.Size = new Size(1544, 1077);
            cmdTotals.TabIndex = 7;
            cmdTotals.Text = "Running Totals";
            cmdTotals.UseVisualStyleBackColor = true;
            // 
            // resetTotalsButton
            // 
            resetTotalsButton.BackColor = SystemColors.Control;
            resetTotalsButton.ForeColor = Color.Black;
            resetTotalsButton.Location = new Point(515, 956);
            resetTotalsButton.Name = "resetTotalsButton";
            resetTotalsButton.Size = new Size(491, 45);
            resetTotalsButton.TabIndex = 126;
            resetTotalsButton.Text = "Reset All Running Totals";
            resetTotalsButton.UseVisualStyleBackColor = false;
            resetTotalsButton.Click += resetTotalsButton_Click;
            // 
            // totalTargetTimeLabel
            // 
            totalTargetTimeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalTargetTimeLabel.Location = new Point(707, 873);
            totalTargetTimeLabel.Name = "totalTargetTimeLabel";
            totalTargetTimeLabel.Size = new Size(820, 45);
            totalTargetTimeLabel.TabIndex = 30;
            totalTargetTimeLabel.Text = "0";
            // 
            // totalElapsedTimeLabel
            // 
            totalElapsedTimeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalElapsedTimeLabel.Location = new Point(707, 828);
            totalElapsedTimeLabel.Name = "totalElapsedTimeLabel";
            totalElapsedTimeLabel.Size = new Size(820, 45);
            totalElapsedTimeLabel.TabIndex = 29;
            totalElapsedTimeLabel.Text = "0";
            // 
            // totalBytesToProcessLabel
            // 
            totalBytesToProcessLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalBytesToProcessLabel.Location = new Point(707, 783);
            totalBytesToProcessLabel.Name = "totalBytesToProcessLabel";
            totalBytesToProcessLabel.Size = new Size(820, 45);
            totalBytesToProcessLabel.TabIndex = 28;
            totalBytesToProcessLabel.Text = "0";
            // 
            // totalBytesProcessedLabel
            // 
            totalBytesProcessedLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalBytesProcessedLabel.Location = new Point(707, 738);
            totalBytesProcessedLabel.Name = "totalBytesProcessedLabel";
            totalBytesProcessedLabel.Size = new Size(820, 45);
            totalBytesProcessedLabel.TabIndex = 27;
            totalBytesProcessedLabel.Text = "0";
            // 
            // totalTargetTimeTitleLabel
            // 
            totalTargetTimeTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalTargetTimeTitleLabel.Location = new Point(6, 873);
            totalTargetTimeTitleLabel.Name = "totalTargetTimeTitleLabel";
            totalTargetTimeTitleLabel.Size = new Size(695, 45);
            totalTargetTimeTitleLabel.TabIndex = 26;
            totalTargetTimeTitleLabel.Text = "Total Target Time:";
            totalTargetTimeTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalElapsedTimeTitleLabel
            // 
            totalElapsedTimeTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalElapsedTimeTitleLabel.Location = new Point(3, 828);
            totalElapsedTimeTitleLabel.Name = "totalElapsedTimeTitleLabel";
            totalElapsedTimeTitleLabel.Size = new Size(697, 45);
            totalElapsedTimeTitleLabel.TabIndex = 25;
            totalElapsedTimeTitleLabel.Text = "Total Elapsed Time:";
            totalElapsedTimeTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalBytesToProcessTitleLabel
            // 
            totalBytesToProcessTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalBytesToProcessTitleLabel.Location = new Point(6, 783);
            totalBytesToProcessTitleLabel.Name = "totalBytesToProcessTitleLabel";
            totalBytesToProcessTitleLabel.Size = new Size(694, 45);
            totalBytesToProcessTitleLabel.TabIndex = 24;
            totalBytesToProcessTitleLabel.Text = "Total Bytes To Process (Est):";
            totalBytesToProcessTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalBytesProcessedTitleLabel
            // 
            totalBytesProcessedTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalBytesProcessedTitleLabel.Location = new Point(6, 738);
            totalBytesProcessedTitleLabel.Name = "totalBytesProcessedTitleLabel";
            totalBytesProcessedTitleLabel.Size = new Size(694, 45);
            totalBytesProcessedTitleLabel.TabIndex = 23;
            totalBytesProcessedTitleLabel.Text = "Total Bytes Processed:";
            totalBytesProcessedTitleLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // totalFilesMovedLabel
            // 
            totalFilesMovedLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalFilesMovedLabel.Location = new Point(706, 463);
            totalFilesMovedLabel.Name = "totalFilesMovedLabel";
            totalFilesMovedLabel.Size = new Size(820, 45);
            totalFilesMovedLabel.TabIndex = 22;
            totalFilesMovedLabel.Text = "0";
            // 
            // totalFilesMovedTitleLabel
            // 
            totalFilesMovedTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalFilesMovedTitleLabel.Location = new Point(6, 463);
            totalFilesMovedTitleLabel.Name = "totalFilesMovedTitleLabel";
            totalFilesMovedTitleLabel.Size = new Size(694, 45);
            totalFilesMovedTitleLabel.TabIndex = 21;
            totalFilesMovedTitleLabel.Text = "Files Moved:";
            totalFilesMovedTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalFilesFailedLabel
            // 
            totalFilesFailedLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalFilesFailedLabel.Location = new Point(706, 643);
            totalFilesFailedLabel.Name = "totalFilesFailedLabel";
            totalFilesFailedLabel.Size = new Size(820, 45);
            totalFilesFailedLabel.TabIndex = 20;
            totalFilesFailedLabel.Text = "0";
            // 
            // totalFilesSkippedLabel
            // 
            totalFilesSkippedLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalFilesSkippedLabel.Location = new Point(706, 598);
            totalFilesSkippedLabel.Name = "totalFilesSkippedLabel";
            totalFilesSkippedLabel.Size = new Size(820, 45);
            totalFilesSkippedLabel.TabIndex = 19;
            totalFilesSkippedLabel.Text = "0";
            // 
            // totalFilesDeletedLabel
            // 
            totalFilesDeletedLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalFilesDeletedLabel.Location = new Point(706, 553);
            totalFilesDeletedLabel.Name = "totalFilesDeletedLabel";
            totalFilesDeletedLabel.Size = new Size(820, 45);
            totalFilesDeletedLabel.TabIndex = 18;
            totalFilesDeletedLabel.Text = "0";
            // 
            // totalFilesCopiedLabel
            // 
            totalFilesCopiedLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalFilesCopiedLabel.Location = new Point(706, 508);
            totalFilesCopiedLabel.Name = "totalFilesCopiedLabel";
            totalFilesCopiedLabel.Size = new Size(820, 45);
            totalFilesCopiedLabel.TabIndex = 17;
            totalFilesCopiedLabel.Text = "0";
            // 
            // totalFilesConsideredTitleLabel
            // 
            totalFilesConsideredTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalFilesConsideredTitleLabel.Location = new Point(6, 418);
            totalFilesConsideredTitleLabel.Name = "totalFilesConsideredTitleLabel";
            totalFilesConsideredTitleLabel.Size = new Size(694, 45);
            totalFilesConsideredTitleLabel.TabIndex = 16;
            totalFilesConsideredTitleLabel.Text = "Total Files Considered:";
            totalFilesConsideredTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalFilesFailedTitleLabel
            // 
            totalFilesFailedTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalFilesFailedTitleLabel.Location = new Point(6, 643);
            totalFilesFailedTitleLabel.Name = "totalFilesFailedTitleLabel";
            totalFilesFailedTitleLabel.Size = new Size(694, 45);
            totalFilesFailedTitleLabel.TabIndex = 15;
            totalFilesFailedTitleLabel.Text = "Files Failed:";
            totalFilesFailedTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalFilesSkippedTitleLabel
            // 
            totalFilesSkippedTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalFilesSkippedTitleLabel.Location = new Point(6, 598);
            totalFilesSkippedTitleLabel.Name = "totalFilesSkippedTitleLabel";
            totalFilesSkippedTitleLabel.Size = new Size(694, 45);
            totalFilesSkippedTitleLabel.TabIndex = 14;
            totalFilesSkippedTitleLabel.Text = "Files Skipped:";
            totalFilesSkippedTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalFilesDeletedTitleLabel
            // 
            totalFilesDeletedTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalFilesDeletedTitleLabel.Location = new Point(6, 553);
            totalFilesDeletedTitleLabel.Name = "totalFilesDeletedTitleLabel";
            totalFilesDeletedTitleLabel.Size = new Size(694, 45);
            totalFilesDeletedTitleLabel.TabIndex = 13;
            totalFilesDeletedTitleLabel.Text = "Files Securely Deleted:";
            totalFilesDeletedTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalFilesCopiedTitleLabel
            // 
            totalFilesCopiedTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalFilesCopiedTitleLabel.Location = new Point(3, 508);
            totalFilesCopiedTitleLabel.Name = "totalFilesCopiedTitleLabel";
            totalFilesCopiedTitleLabel.Size = new Size(697, 45);
            totalFilesCopiedTitleLabel.TabIndex = 12;
            totalFilesCopiedTitleLabel.Text = "Files Copied:";
            totalFilesCopiedTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalFilesConsideredLabel
            // 
            totalFilesConsideredLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalFilesConsideredLabel.Location = new Point(706, 418);
            totalFilesConsideredLabel.Name = "totalFilesConsideredLabel";
            totalFilesConsideredLabel.Size = new Size(820, 45);
            totalFilesConsideredLabel.TabIndex = 11;
            totalFilesConsideredLabel.Text = "0";
            // 
            // totalCompletedOperationsLabel
            // 
            totalCompletedOperationsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalCompletedOperationsLabel.Location = new Point(706, 331);
            totalCompletedOperationsLabel.Name = "totalCompletedOperationsLabel";
            totalCompletedOperationsLabel.Size = new Size(820, 45);
            totalCompletedOperationsLabel.TabIndex = 10;
            totalCompletedOperationsLabel.Text = "0";
            // 
            // totalCancelledOperationsLabel
            // 
            totalCancelledOperationsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalCancelledOperationsLabel.Location = new Point(706, 286);
            totalCancelledOperationsLabel.Name = "totalCancelledOperationsLabel";
            totalCancelledOperationsLabel.Size = new Size(820, 45);
            totalCancelledOperationsLabel.TabIndex = 9;
            totalCancelledOperationsLabel.Text = "0";
            // 
            // totalDeleteOperationsLabel
            // 
            totalDeleteOperationsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalDeleteOperationsLabel.Location = new Point(706, 241);
            totalDeleteOperationsLabel.Name = "totalDeleteOperationsLabel";
            totalDeleteOperationsLabel.Size = new Size(820, 45);
            totalDeleteOperationsLabel.TabIndex = 8;
            totalDeleteOperationsLabel.Text = "0";
            // 
            // totalMoveOperationsLabel
            // 
            totalMoveOperationsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalMoveOperationsLabel.Location = new Point(706, 196);
            totalMoveOperationsLabel.Name = "totalMoveOperationsLabel";
            totalMoveOperationsLabel.Size = new Size(820, 45);
            totalMoveOperationsLabel.TabIndex = 7;
            totalMoveOperationsLabel.Text = "0";
            // 
            // totalCopyOperationsTitleLabel
            // 
            totalCopyOperationsTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalCopyOperationsTitleLabel.Location = new Point(3, 151);
            totalCopyOperationsTitleLabel.Name = "totalCopyOperationsTitleLabel";
            totalCopyOperationsTitleLabel.Size = new Size(697, 45);
            totalCopyOperationsTitleLabel.TabIndex = 6;
            totalCopyOperationsTitleLabel.Text = "Copying Operations Total:";
            totalCopyOperationsTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalCompletedOperationsTitleLabel
            // 
            totalCompletedOperationsTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalCompletedOperationsTitleLabel.Location = new Point(6, 331);
            totalCompletedOperationsTitleLabel.Name = "totalCompletedOperationsTitleLabel";
            totalCompletedOperationsTitleLabel.Size = new Size(694, 45);
            totalCompletedOperationsTitleLabel.TabIndex = 5;
            totalCompletedOperationsTitleLabel.Text = "Completed Operations Total:";
            totalCompletedOperationsTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalCancelledOperationsTitleLabel
            // 
            totalCancelledOperationsTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalCancelledOperationsTitleLabel.Location = new Point(6, 286);
            totalCancelledOperationsTitleLabel.Name = "totalCancelledOperationsTitleLabel";
            totalCancelledOperationsTitleLabel.Size = new Size(694, 45);
            totalCancelledOperationsTitleLabel.TabIndex = 4;
            totalCancelledOperationsTitleLabel.Text = "Cancelled Operations Total:";
            totalCancelledOperationsTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalDeleteOperationsTItleLabel
            // 
            totalDeleteOperationsTItleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalDeleteOperationsTItleLabel.Location = new Point(-4, 241);
            totalDeleteOperationsTItleLabel.Name = "totalDeleteOperationsTItleLabel";
            totalDeleteOperationsTItleLabel.Size = new Size(704, 45);
            totalDeleteOperationsTItleLabel.TabIndex = 3;
            totalDeleteOperationsTItleLabel.Text = "Secure Delete Operations Total:\r\n";
            totalDeleteOperationsTItleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalMoveOperationsTitleLabel
            // 
            totalMoveOperationsTitleLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            totalMoveOperationsTitleLabel.Location = new Point(6, 196);
            totalMoveOperationsTitleLabel.Name = "totalMoveOperationsTitleLabel";
            totalMoveOperationsTitleLabel.Size = new Size(695, 45);
            totalMoveOperationsTitleLabel.TabIndex = 2;
            totalMoveOperationsTitleLabel.Text = "Moving Operations Total:";
            totalMoveOperationsTitleLabel.TextAlign = ContentAlignment.TopRight;
            // 
            // totalCopyOperationsLabel
            // 
            totalCopyOperationsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold, GraphicsUnit.Point, 0);
            totalCopyOperationsLabel.Location = new Point(706, 151);
            totalCopyOperationsLabel.Name = "totalCopyOperationsLabel";
            totalCopyOperationsLabel.Size = new Size(820, 45);
            totalCopyOperationsLabel.TabIndex = 1;
            totalCopyOperationsLabel.Text = "0";
            // 
            // titleTotalsLabel
            // 
            titleTotalsLabel.AutoSize = true;
            titleTotalsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            titleTotalsLabel.Location = new Point(514, 77);
            titleTotalsLabel.Name = "titleTotalsLabel";
            titleTotalsLabel.Size = new Size(492, 45);
            titleTotalsLabel.TabIndex = 0;
            titleTotalsLabel.Text = "Running Totals For All Statistics";
            // 
            // cmdSettingsPage
            // 
            cmdSettingsPage.BackColor = Color.Transparent;
            cmdSettingsPage.Controls.Add(dataGridView1);
            cmdSettingsPage.Controls.Add(statusBarSettings);
            cmdSettingsPage.Controls.Add(retentionLabel);
            cmdSettingsPage.Controls.Add(logDaysNumUpDown);
            cmdSettingsPage.Controls.Add(exportFileListLabel);
            cmdSettingsPage.Controls.Add(opacityLabel);
            cmdSettingsPage.Controls.Add(opacityTrackBar);
            cmdSettingsPage.Controls.Add(logFileCheckBox);
            cmdSettingsPage.Controls.Add(priorityLabel);
            cmdSettingsPage.Controls.Add(priorityTrackBar);
            cmdSettingsPage.Controls.Add(saveAutoCheckBox);
            cmdSettingsPage.Controls.Add(defaultSettingsButton);
            cmdSettingsPage.Controls.Add(recSettingsButton);
            cmdSettingsPage.Controls.Add(clearSettingsButton);
            cmdSettingsPage.Controls.Add(saveSettingsButton);
            cmdSettingsPage.Controls.Add(emailGroupBox);
            cmdSettingsPage.Controls.Add(updateGroupBox);
            cmdSettingsPage.Controls.Add(performanceGroupBox);
            cmdSettingsPage.Controls.Add(otherSettingsGroupBox);
            cmdSettingsPage.Controls.Add(fileDirSettingsGroupBox);
            cmdSettingsPage.Controls.Add(soundsGroupBox);
            cmdSettingsPage.Controls.Add(skinsLanguageGoupBox);
            cmdSettingsPage.Controls.Add(windowGroupBox);
            cmdSettingsPage.Location = new Point(4, 34);
            cmdSettingsPage.Name = "cmdSettingsPage";
            cmdSettingsPage.Padding = new Padding(3);
            cmdSettingsPage.Size = new Size(1544, 1077);
            cmdSettingsPage.TabIndex = 1;
            cmdSettingsPage.Text = "- Settings";
            cmdSettingsPage.UseVisualStyleBackColor = true;
            cmdSettingsPage.MouseEnter += cmdSettingsPage_MouseEnter_1;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = Color.DarkGray;
            dataGridView1.ClipboardCopyMode = DataGridViewClipboardCopyMode.EnableAlwaysIncludeHeaderText;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.EditMode = DataGridViewEditMode.EditProgrammatically;
            dataGridView1.Location = new Point(17, 796);
            dataGridView1.MultiSelect = false;
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.RowHeadersWidth = 62;
            dataGridView1.ScrollBars = ScrollBars.Vertical;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView1.Size = new Size(1493, 201);
            dataGridView1.TabIndex = 193;
            // 
            // statusBarSettings
            // 
            statusBarSettings.AutoSize = false;
            statusBarSettings.Dock = DockStyle.None;
            statusBarSettings.ImageScalingSize = new Size(24, 24);
            statusBarSettings.Items.AddRange(new ToolStripItem[] { toolStripSettings });
            statusBarSettings.Location = new Point(17, 1022);
            statusBarSettings.Name = "statusBarSettings";
            statusBarSettings.Size = new Size(1506, 42);
            statusBarSettings.TabIndex = 192;
            statusBarSettings.Text = "Status Label";
            // 
            // toolStripSettings
            // 
            toolStripSettings.Name = "toolStripSettings";
            toolStripSettings.Size = new Size(0, 35);
            toolStripSettings.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // retentionLabel
            // 
            retentionLabel.Location = new Point(669, 488);
            retentionLabel.Name = "retentionLabel";
            retentionLabel.Size = new Size(202, 47);
            retentionLabel.TabIndex = 124;
            retentionLabel.Text = "Days to Keep Logs:";
            // 
            // logDaysNumUpDown
            // 
            logDaysNumUpDown.Location = new Point(669, 538);
            logDaysNumUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            logDaysNumUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            logDaysNumUpDown.Name = "logDaysNumUpDown";
            logDaysNumUpDown.ReadOnly = true;
            logDaysNumUpDown.Size = new Size(202, 31);
            logDaysNumUpDown.TabIndex = 123;
            logDaysNumUpDown.TextAlign = HorizontalAlignment.Center;
            logDaysNumUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            logDaysNumUpDown.Enter += logDaysNumUpDown_Enter;
            // 
            // exportFileListLabel
            // 
            exportFileListLabel.AutoSize = true;
            exportFileListLabel.BackColor = SystemColors.Control;
            exportFileListLabel.Location = new Point(18, 753);
            exportFileListLabel.Name = "exportFileListLabel";
            exportFileListLabel.Size = new Size(129, 25);
            exportFileListLabel.TabIndex = 121;
            exportFileListLabel.Text = "Export File List:";
            // 
            // opacityLabel
            // 
            opacityLabel.AutoSize = true;
            opacityLabel.BackColor = SystemColors.Control;
            opacityLabel.Location = new Point(669, 310);
            opacityLabel.Name = "opacityLabel";
            opacityLabel.Size = new Size(77, 25);
            opacityLabel.TabIndex = 120;
            opacityLabel.Text = "Opacity:";
            // 
            // opacityTrackBar
            // 
            opacityTrackBar.AutoSize = false;
            opacityTrackBar.BackColor = SystemColors.Control;
            opacityTrackBar.Location = new Point(660, 360);
            opacityTrackBar.Maximum = 100;
            opacityTrackBar.Minimum = 60;
            opacityTrackBar.Name = "opacityTrackBar";
            opacityTrackBar.Size = new Size(211, 49);
            opacityTrackBar.TabIndex = 119;
            opacityTrackBar.Value = 100;
            opacityTrackBar.Scroll += opacityTrackBar_Scroll;
            opacityTrackBar.MouseEnter += opacityTrackBar_MouseEnter;
            // 
            // logFileCheckBox
            // 
            logFileCheckBox.BackColor = SystemColors.Control;
            logFileCheckBox.Checked = true;
            logFileCheckBox.CheckState = CheckState.Checked;
            logFileCheckBox.Location = new Point(669, 434);
            logFileCheckBox.Name = "logFileCheckBox";
            logFileCheckBox.Size = new Size(202, 51);
            logFileCheckBox.TabIndex = 118;
            logFileCheckBox.Text = "Log to File";
            logFileCheckBox.UseVisualStyleBackColor = false;
            logFileCheckBox.CheckedChanged += logFileCheckBox_CheckedChanged;
            logFileCheckBox.MouseEnter += logFileCheckBox_MouseEnter;
            // 
            // priorityLabel
            // 
            priorityLabel.AutoSize = true;
            priorityLabel.BackColor = SystemColors.Control;
            priorityLabel.Location = new Point(669, 186);
            priorityLabel.Name = "priorityLabel";
            priorityLabel.Size = new Size(146, 25);
            priorityLabel.TabIndex = 117;
            priorityLabel.Text = "Program Priority:";
            // 
            // priorityTrackBar
            // 
            priorityTrackBar.AutoSize = false;
            priorityTrackBar.BackColor = SystemColors.Control;
            priorityTrackBar.Location = new Point(660, 236);
            priorityTrackBar.Maximum = 4;
            priorityTrackBar.Name = "priorityTrackBar";
            priorityTrackBar.Size = new Size(211, 49);
            priorityTrackBar.TabIndex = 103;
            priorityTrackBar.Value = 2;
            priorityTrackBar.Scroll += priorityTrackBar_Scroll;
            priorityTrackBar.MouseEnter += priorityTrackBar_MouseEnter;
            // 
            // saveAutoCheckBox
            // 
            saveAutoCheckBox.BackColor = SystemColors.Control;
            saveAutoCheckBox.Checked = true;
            saveAutoCheckBox.CheckState = CheckState.Checked;
            saveAutoCheckBox.Location = new Point(669, 578);
            saveAutoCheckBox.Name = "saveAutoCheckBox";
            saveAutoCheckBox.Size = new Size(181, 61);
            saveAutoCheckBox.TabIndex = 116;
            saveAutoCheckBox.Text = "Autosave Settings";
            saveAutoCheckBox.UseVisualStyleBackColor = false;
            saveAutoCheckBox.CheckedChanged += saveAutoCheckBox_CheckedChanged;
            saveAutoCheckBox.MouseEnter += saveAutoCheckBox_MouseEnter;
            // 
            // defaultSettingsButton
            // 
            defaultSettingsButton.BackColor = SystemColors.Control;
            defaultSettingsButton.ForeColor = Color.Black;
            defaultSettingsButton.Location = new Point(669, 68);
            defaultSettingsButton.Name = "defaultSettingsButton";
            defaultSettingsButton.Size = new Size(202, 52);
            defaultSettingsButton.TabIndex = 115;
            defaultSettingsButton.Text = "Restore Defaults";
            defaultSettingsButton.UseVisualStyleBackColor = false;
            defaultSettingsButton.Click += defaultSettingsButton_Click;
            defaultSettingsButton.MouseEnter += defaultSettingsButton_MouseEnter;
            // 
            // recSettingsButton
            // 
            recSettingsButton.BackColor = SystemColors.Control;
            recSettingsButton.ForeColor = Color.Black;
            recSettingsButton.Location = new Point(669, 127);
            recSettingsButton.Name = "recSettingsButton";
            recSettingsButton.Size = new Size(202, 46);
            recSettingsButton.TabIndex = 114;
            recSettingsButton.Text = "Recommended";
            recSettingsButton.UseVisualStyleBackColor = false;
            recSettingsButton.Click += recSettingsButton_Click;
            recSettingsButton.MouseEnter += recSettingsButton_MouseEnter;
            // 
            // clearSettingsButton
            // 
            clearSettingsButton.BackColor = SystemColors.Control;
            clearSettingsButton.ForeColor = Color.Black;
            clearSettingsButton.Location = new Point(669, 648);
            clearSettingsButton.Name = "clearSettingsButton";
            clearSettingsButton.Size = new Size(202, 44);
            clearSettingsButton.TabIndex = 113;
            clearSettingsButton.Text = "Clear Settings";
            clearSettingsButton.UseVisualStyleBackColor = false;
            clearSettingsButton.Click += clearSettingsButton_Click;
            clearSettingsButton.MouseEnter += clearSettingsButton_MouseEnter;
            // 
            // saveSettingsButton
            // 
            saveSettingsButton.BackColor = SystemColors.Control;
            saveSettingsButton.ForeColor = Color.Black;
            saveSettingsButton.Location = new Point(669, 707);
            saveSettingsButton.Name = "saveSettingsButton";
            saveSettingsButton.Size = new Size(202, 42);
            saveSettingsButton.TabIndex = 112;
            saveSettingsButton.Text = "Save Settings";
            saveSettingsButton.UseVisualStyleBackColor = false;
            saveSettingsButton.Click += saveSettingsButton_Click;
            saveSettingsButton.MouseEnter += saveSettingsButton_MouseEnter;
            // 
            // emailGroupBox
            // 
            emailGroupBox.BackColor = SystemColors.Control;
            emailGroupBox.Controls.Add(setUpSMSButton);
            emailGroupBox.Controls.Add(setUpEmailButton);
            emailGroupBox.Controls.Add(emailPathsCheckBox);
            emailGroupBox.Controls.Add(emailNamesCheckBox);
            emailGroupBox.Controls.Add(whenEmailingLabel);
            emailGroupBox.ForeColor = Color.Black;
            emailGroupBox.Location = new Point(887, 400);
            emailGroupBox.Name = "emailGroupBox";
            emailGroupBox.Size = new Size(636, 124);
            emailGroupBox.TabIndex = 111;
            emailGroupBox.TabStop = false;
            emailGroupBox.Text = "Email Settings (Pro):";
            emailGroupBox.MouseHover += emailGroupBox_MouseHover;
            // 
            // setUpSMSButton
            // 
            setUpSMSButton.BackColor = SystemColors.Control;
            setUpSMSButton.ForeColor = Color.Black;
            setUpSMSButton.Location = new Point(178, 71);
            setUpSMSButton.Name = "setUpSMSButton";
            setUpSMSButton.Size = new Size(157, 42);
            setUpSMSButton.TabIndex = 90;
            setUpSMSButton.Text = "Set Up SMS Notifications";
            setUpSMSButton.UseVisualStyleBackColor = false;
            setUpSMSButton.Click += setUpSMSButton_Click;
            setUpSMSButton.MouseHover += setUpSMSButton_MouseHover;
            // 
            // setUpEmailButton
            // 
            setUpEmailButton.BackColor = SystemColors.Control;
            setUpEmailButton.ForeColor = Color.Black;
            setUpEmailButton.Location = new Point(14, 71);
            setUpEmailButton.Name = "setUpEmailButton";
            setUpEmailButton.Size = new Size(158, 42);
            setUpEmailButton.TabIndex = 90;
            setUpEmailButton.Text = "Set Up Email";
            setUpEmailButton.UseVisualStyleBackColor = false;
            setUpEmailButton.Click += setUpEmailButton_Click;
            setUpEmailButton.MouseHover += setUpEmailButton_MouseHover;
            // 
            // emailPathsCheckBox
            // 
            emailPathsCheckBox.AutoSize = true;
            emailPathsCheckBox.Checked = true;
            emailPathsCheckBox.CheckState = CheckState.Checked;
            emailPathsCheckBox.Location = new Point(366, 75);
            emailPathsCheckBox.Name = "emailPathsCheckBox";
            emailPathsCheckBox.Size = new Size(146, 29);
            emailPathsCheckBox.TabIndex = 80;
            emailPathsCheckBox.Text = "Use Full Paths";
            emailPathsCheckBox.UseVisualStyleBackColor = true;
            emailPathsCheckBox.CheckedChanged += emailPathsCheckBox_CheckedChanged;
            emailPathsCheckBox.MouseEnter += emailPathsCheckBox_MouseEnter;
            // 
            // emailNamesCheckBox
            // 
            emailNamesCheckBox.AutoSize = true;
            emailNamesCheckBox.Location = new Point(366, 32);
            emailNamesCheckBox.Name = "emailNamesCheckBox";
            emailNamesCheckBox.Size = new Size(200, 29);
            emailNamesCheckBox.TabIndex = 79;
            emailNamesCheckBox.Text = "Only File/Dir. Names";
            emailNamesCheckBox.UseVisualStyleBackColor = true;
            emailNamesCheckBox.CheckedChanged += emailNamesCheckBox_CheckedChanged;
            emailNamesCheckBox.MouseEnter += emailNamesCheckBox_MouseEnter;
            // 
            // whenEmailingLabel
            // 
            whenEmailingLabel.AutoSize = true;
            whenEmailingLabel.Location = new Point(14, 32);
            whenEmailingLabel.Name = "whenEmailingLabel";
            whenEmailingLabel.Size = new Size(253, 25);
            whenEmailingLabel.TabIndex = 78;
            whenEmailingLabel.Text = "When Emailing File/Folder List:";
            // 
            // updateGroupBox
            // 
            updateGroupBox.BackColor = SystemColors.Control;
            updateGroupBox.Controls.Add(updateManuallyCheckBox);
            updateGroupBox.Controls.Add(checkForUpdatesButton);
            updateGroupBox.Controls.Add(updateBetaCheckBox);
            updateGroupBox.Controls.Add(updateAutoCheckBox);
            updateGroupBox.ForeColor = Color.Black;
            updateGroupBox.Location = new Point(18, 546);
            updateGroupBox.Name = "updateGroupBox";
            updateGroupBox.Size = new Size(636, 203);
            updateGroupBox.TabIndex = 110;
            updateGroupBox.TabStop = false;
            updateGroupBox.Text = "Update Settings:";
            updateGroupBox.MouseHover += updateGroupBox_MouseHover;
            // 
            // updateManuallyCheckBox
            // 
            updateManuallyCheckBox.Checked = true;
            updateManuallyCheckBox.CheckState = CheckState.Checked;
            updateManuallyCheckBox.Location = new Point(367, 31);
            updateManuallyCheckBox.Name = "updateManuallyCheckBox";
            updateManuallyCheckBox.Size = new Size(257, 89);
            updateManuallyCheckBox.TabIndex = 89;
            updateManuallyCheckBox.Text = "Update Manually";
            updateManuallyCheckBox.UseVisualStyleBackColor = true;
            updateManuallyCheckBox.CheckedChanged += updateManuallyCheckBox_CheckedChanged;
            // 
            // checkForUpdatesButton
            // 
            checkForUpdatesButton.BackColor = SystemColors.Control;
            checkForUpdatesButton.ForeColor = Color.Black;
            checkForUpdatesButton.Location = new Point(367, 122);
            checkForUpdatesButton.Name = "checkForUpdatesButton";
            checkForUpdatesButton.Size = new Size(257, 43);
            checkForUpdatesButton.TabIndex = 88;
            checkForUpdatesButton.Text = "Check for Updates";
            checkForUpdatesButton.UseVisualStyleBackColor = false;
            checkForUpdatesButton.Click += checkForUpdatesButton_Click;
            checkForUpdatesButton.MouseEnter += checkForUpdatesButton_MouseEnter;
            // 
            // updateBetaCheckBox
            // 
            updateBetaCheckBox.Location = new Point(12, 117);
            updateBetaCheckBox.Name = "updateBetaCheckBox";
            updateBetaCheckBox.Size = new Size(349, 58);
            updateBetaCheckBox.TabIndex = 81;
            updateBetaCheckBox.Text = "Check for Beta (Pro)";
            updateBetaCheckBox.UseVisualStyleBackColor = true;
            updateBetaCheckBox.CheckedChanged += updateBetaCheckBox_CheckedChanged;
            updateBetaCheckBox.MouseEnter += updateBetaCheckBox_MouseEnter;
            // 
            // updateAutoCheckBox
            // 
            updateAutoCheckBox.Location = new Point(12, 31);
            updateAutoCheckBox.Name = "updateAutoCheckBox";
            updateAutoCheckBox.Size = new Size(349, 89);
            updateAutoCheckBox.TabIndex = 77;
            updateAutoCheckBox.Text = "Update Automatically (Pro)";
            updateAutoCheckBox.UseVisualStyleBackColor = true;
            updateAutoCheckBox.CheckedChanged += updateAutoCheckBox_CheckedChanged;
            updateAutoCheckBox.MouseEnter += updateAutoCheckBox_MouseEnter;
            // 
            // performanceGroupBox
            // 
            performanceGroupBox.BackColor = SystemColors.Control;
            performanceGroupBox.Controls.Add(kbLabel);
            performanceGroupBox.Controls.Add(multithreadCheckBox);
            performanceGroupBox.Controls.Add(cmOnlyIfLabel);
            performanceGroupBox.Controls.Add(overMBCheckBox);
            performanceGroupBox.Controls.Add(underMBCheckBox);
            performanceGroupBox.Controls.Add(setMBGBOLabel);
            performanceGroupBox.Controls.Add(setMBGBULabel);
            performanceGroupBox.Controls.Add(setMBGBUnderNumUpDown);
            performanceGroupBox.Controls.Add(setMBUmderLabel);
            performanceGroupBox.Controls.Add(setMBGBOverNumUpDown);
            performanceGroupBox.Controls.Add(setMBGBOverLabel);
            performanceGroupBox.Controls.Add(bufferNumUpDown);
            performanceGroupBox.Controls.Add(setBufferLabel);
            performanceGroupBox.ForeColor = Color.Black;
            performanceGroupBox.Location = new Point(887, 68);
            performanceGroupBox.Name = "performanceGroupBox";
            performanceGroupBox.Size = new Size(636, 150);
            performanceGroupBox.TabIndex = 109;
            performanceGroupBox.TabStop = false;
            performanceGroupBox.Text = "Performance Settings:";
            performanceGroupBox.MouseHover += performanceGroupBox_MouseHover;
            // 
            // kbLabel
            // 
            kbLabel.AutoSize = true;
            kbLabel.Location = new Point(281, 29);
            kbLabel.Name = "kbLabel";
            kbLabel.Size = new Size(32, 25);
            kbLabel.TabIndex = 80;
            kbLabel.Text = "KB";
            // 
            // multithreadCheckBox
            // 
            multithreadCheckBox.AutoSize = true;
            multithreadCheckBox.Checked = true;
            multithreadCheckBox.CheckState = CheckState.Checked;
            multithreadCheckBox.Location = new Point(314, 23);
            multithreadCheckBox.Name = "multithreadCheckBox";
            multithreadCheckBox.Size = new Size(243, 29);
            multithreadCheckBox.TabIndex = 79;
            multithreadCheckBox.Text = "Copy With Multithreading";
            multithreadCheckBox.UseVisualStyleBackColor = true;
            multithreadCheckBox.CheckedChanged += multithreadCheckBox_CheckedChanged;
            multithreadCheckBox.MouseEnter += multithreadCheckBox_MouseEnter;
            // 
            // cmOnlyIfLabel
            // 
            cmOnlyIfLabel.AutoSize = true;
            cmOnlyIfLabel.Location = new Point(6, 91);
            cmOnlyIfLabel.Name = "cmOnlyIfLabel";
            cmOnlyIfLabel.Size = new Size(66, 25);
            cmOnlyIfLabel.TabIndex = 78;
            cmOnlyIfLabel.Text = "C/M If:";
            // 
            // overMBCheckBox
            // 
            overMBCheckBox.AutoSize = true;
            overMBCheckBox.Location = new Point(135, 108);
            overMBCheckBox.Name = "overMBCheckBox";
            overMBCheckBox.Size = new Size(107, 29);
            overMBCheckBox.TabIndex = 77;
            overMBCheckBox.Text = "Over MB";
            overMBCheckBox.UseVisualStyleBackColor = true;
            overMBCheckBox.MouseEnter += overMBCheckBox_MouseEnter;
            // 
            // underMBCheckBox
            // 
            underMBCheckBox.AutoSize = true;
            underMBCheckBox.Location = new Point(135, 69);
            underMBCheckBox.Name = "underMBCheckBox";
            underMBCheckBox.Size = new Size(117, 29);
            underMBCheckBox.TabIndex = 76;
            underMBCheckBox.Text = "Under MB";
            underMBCheckBox.UseVisualStyleBackColor = true;
            underMBCheckBox.MouseEnter += underMBCheckBox_MouseEnter;
            // 
            // setMBGBOLabel
            // 
            setMBGBOLabel.AutoSize = true;
            setMBGBOLabel.Location = new Point(585, 107);
            setMBGBOLabel.Name = "setMBGBOLabel";
            setMBGBOLabel.Size = new Size(38, 25);
            setMBGBOLabel.TabIndex = 75;
            setMBGBOLabel.Text = "MB";
            // 
            // setMBGBULabel
            // 
            setMBGBULabel.AutoSize = true;
            setMBGBULabel.Location = new Point(587, 72);
            setMBGBULabel.Name = "setMBGBULabel";
            setMBGBULabel.Size = new Size(38, 25);
            setMBGBULabel.TabIndex = 74;
            setMBGBULabel.Text = "MB";
            // 
            // setMBGBUnderNumUpDown
            // 
            setMBGBUnderNumUpDown.Location = new Point(473, 66);
            setMBGBUnderNumUpDown.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            setMBGBUnderNumUpDown.Name = "setMBGBUnderNumUpDown";
            setMBGBUnderNumUpDown.ReadOnly = true;
            setMBGBUnderNumUpDown.Size = new Size(113, 31);
            setMBGBUnderNumUpDown.TabIndex = 73;
            setMBGBUnderNumUpDown.TextAlign = HorizontalAlignment.Center;
            setMBGBUnderNumUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            setMBGBUnderNumUpDown.Enter += setMBGBUnderNumUpDown_Enter;
            // 
            // setMBUmderLabel
            // 
            setMBUmderLabel.AutoSize = true;
            setMBUmderLabel.Location = new Point(308, 66);
            setMBUmderLabel.Name = "setMBUmderLabel";
            setMBUmderLabel.Size = new Size(119, 25);
            setMBUmderLabel.TabIndex = 72;
            setMBUmderLabel.Text = "C/M If Under:";
            // 
            // setMBGBOverNumUpDown
            // 
            setMBGBOverNumUpDown.Location = new Point(473, 103);
            setMBGBOverNumUpDown.Minimum = new decimal(new int[] { 5, 0, 0, 0 });
            setMBGBOverNumUpDown.Name = "setMBGBOverNumUpDown";
            setMBGBOverNumUpDown.ReadOnly = true;
            setMBGBOverNumUpDown.Size = new Size(113, 31);
            setMBGBOverNumUpDown.TabIndex = 71;
            setMBGBOverNumUpDown.TextAlign = HorizontalAlignment.Center;
            setMBGBOverNumUpDown.Value = new decimal(new int[] { 100, 0, 0, 0 });
            setMBGBOverNumUpDown.Enter += setMBGBOverNumUpDown_Enter;
            // 
            // setMBGBOverLabel
            // 
            setMBGBOverLabel.AutoSize = true;
            setMBGBOverLabel.Location = new Point(308, 107);
            setMBGBOverLabel.Name = "setMBGBOverLabel";
            setMBGBOverLabel.Size = new Size(109, 25);
            setMBGBOverLabel.TabIndex = 70;
            setMBGBOverLabel.Text = "C/M If Over:";
            // 
            // bufferNumUpDown
            // 
            bufferNumUpDown.Location = new Point(135, 29);
            bufferNumUpDown.Maximum = new decimal(new int[] { 1024, 0, 0, 0 });
            bufferNumUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            bufferNumUpDown.Name = "bufferNumUpDown";
            bufferNumUpDown.ReadOnly = true;
            bufferNumUpDown.Size = new Size(140, 31);
            bufferNumUpDown.TabIndex = 69;
            bufferNumUpDown.TextAlign = HorizontalAlignment.Center;
            bufferNumUpDown.Value = new decimal(new int[] { 1024, 0, 0, 0 });
            bufferNumUpDown.ValueChanged += bufferNumUpDown_ValueChanged;
            bufferNumUpDown.Enter += bufferNumUpDown_Enter;
            // 
            // setBufferLabel
            // 
            setBufferLabel.Location = new Point(6, 27);
            setBufferLabel.Name = "setBufferLabel";
            setBufferLabel.Size = new Size(92, 64);
            setBufferLabel.TabIndex = 68;
            setBufferLabel.Text = "Buffer Size:";
            // 
            // otherSettingsGroupBox
            // 
            otherSettingsGroupBox.BackColor = SystemColors.Control;
            otherSettingsGroupBox.Controls.Add(secureDeleteLabel);
            otherSettingsGroupBox.Controls.Add(securePassesNumUpDown);
            otherSettingsGroupBox.Controls.Add(seLabel);
            otherSettingsGroupBox.Controls.Add(sLabel);
            otherSettingsGroupBox.Controls.Add(swLabel);
            otherSettingsGroupBox.Controls.Add(eLabel);
            otherSettingsGroupBox.Controls.Add(neLabel);
            otherSettingsGroupBox.Controls.Add(nLabel);
            otherSettingsGroupBox.Controls.Add(nwLabel);
            otherSettingsGroupBox.Controls.Add(wLabel);
            otherSettingsGroupBox.Controls.Add(appLocationLabel);
            otherSettingsGroupBox.Controls.Add(startWithWindowsCheckBox);
            otherSettingsGroupBox.Controls.Add(serialMaskedTextBox);
            otherSettingsGroupBox.Controls.Add(registerButton);
            otherSettingsGroupBox.Controls.Add(serialNumberLabel);
            otherSettingsGroupBox.Controls.Add(errorOccursLabel);
            otherSettingsGroupBox.Controls.Add(restartCheckBox);
            otherSettingsGroupBox.Controls.Add(closeProgramCheckBox);
            otherSettingsGroupBox.ForeColor = Color.Black;
            otherSettingsGroupBox.Location = new Point(887, 546);
            otherSettingsGroupBox.Name = "otherSettingsGroupBox";
            otherSettingsGroupBox.Size = new Size(636, 203);
            otherSettingsGroupBox.TabIndex = 108;
            otherSettingsGroupBox.TabStop = false;
            otherSettingsGroupBox.Text = "Other Settings:";
            otherSettingsGroupBox.MouseHover += otherSettingsGroupBox_MouseHover;
            // 
            // secureDeleteLabel
            // 
            secureDeleteLabel.Location = new Point(424, 134);
            secureDeleteLabel.Name = "secureDeleteLabel";
            secureDeleteLabel.Size = new Size(200, 27);
            secureDeleteLabel.TabIndex = 126;
            secureDeleteLabel.Text = "Secure Delete Passes:";
            // 
            // securePassesNumUpDown
            // 
            securePassesNumUpDown.Location = new Point(423, 164);
            securePassesNumUpDown.Maximum = new decimal(new int[] { 30, 0, 0, 0 });
            securePassesNumUpDown.Minimum = new decimal(new int[] { 10, 0, 0, 0 });
            securePassesNumUpDown.Name = "securePassesNumUpDown";
            securePassesNumUpDown.ReadOnly = true;
            securePassesNumUpDown.Size = new Size(202, 31);
            securePassesNumUpDown.TabIndex = 125;
            securePassesNumUpDown.TextAlign = HorizontalAlignment.Center;
            securePassesNumUpDown.Value = new decimal(new int[] { 30, 0, 0, 0 });
            // 
            // seLabel
            // 
            seLabel.AutoSize = true;
            seLabel.BackColor = Color.Transparent;
            seLabel.ForeColor = Color.Black;
            seLabel.Location = new Point(333, 158);
            seLabel.Name = "seLabel";
            seLabel.Size = new Size(19, 25);
            seLabel.TabIndex = 100;
            seLabel.Text = "°";
            seLabel.Click += seLabel_Click;
            seLabel.MouseEnter += seLabel_MouseEnter;
            // 
            // sLabel
            // 
            sLabel.AutoSize = true;
            sLabel.BackColor = Color.Transparent;
            sLabel.ForeColor = Color.Black;
            sLabel.Location = new Point(303, 168);
            sLabel.Name = "sLabel";
            sLabel.Size = new Size(26, 25);
            sLabel.TabIndex = 99;
            sLabel.Text = "\\/";
            sLabel.Click += sLabel_Click;
            sLabel.MouseEnter += seLabel_MouseEnter;
            // 
            // swLabel
            // 
            swLabel.AutoSize = true;
            swLabel.BackColor = Color.Transparent;
            swLabel.ForeColor = Color.Black;
            swLabel.Location = new Point(276, 158);
            swLabel.Name = "swLabel";
            swLabel.Size = new Size(19, 25);
            swLabel.TabIndex = 98;
            swLabel.Text = "°";
            swLabel.Click += swLabel_Click;
            swLabel.MouseEnter += seLabel_MouseEnter;
            // 
            // eLabel
            // 
            eLabel.AutoSize = true;
            eLabel.BackColor = Color.Transparent;
            eLabel.ForeColor = Color.Black;
            eLabel.Location = new Point(357, 131);
            eLabel.Name = "eLabel";
            eLabel.Size = new Size(24, 25);
            eLabel.TabIndex = 97;
            eLabel.Text = ">";
            eLabel.Click += eLabel_Click;
            eLabel.MouseEnter += seLabel_MouseEnter;
            // 
            // neLabel
            // 
            neLabel.AutoSize = true;
            neLabel.BackColor = Color.Transparent;
            neLabel.ForeColor = Color.Black;
            neLabel.Location = new Point(333, 103);
            neLabel.Name = "neLabel";
            neLabel.Size = new Size(19, 25);
            neLabel.TabIndex = 96;
            neLabel.Text = "°";
            neLabel.Click += neLabel_Click;
            neLabel.MouseEnter += seLabel_MouseEnter;
            // 
            // nLabel
            // 
            nLabel.AutoSize = true;
            nLabel.BackColor = Color.Transparent;
            nLabel.ForeColor = Color.Black;
            nLabel.Location = new Point(303, 84);
            nLabel.Name = "nLabel";
            nLabel.Size = new Size(26, 25);
            nLabel.TabIndex = 95;
            nLabel.Text = "/\\";
            nLabel.Click += nLabel_Click;
            nLabel.MouseEnter += seLabel_MouseEnter;
            // 
            // nwLabel
            // 
            nwLabel.AutoSize = true;
            nwLabel.BackColor = Color.Transparent;
            nwLabel.ForeColor = Color.Black;
            nwLabel.Location = new Point(276, 103);
            nwLabel.Name = "nwLabel";
            nwLabel.Size = new Size(19, 25);
            nwLabel.TabIndex = 94;
            nwLabel.Text = "°";
            nwLabel.Click += nwLabel_Click;
            nwLabel.MouseEnter += seLabel_MouseEnter;
            // 
            // wLabel
            // 
            wLabel.AutoSize = true;
            wLabel.BackColor = Color.Transparent;
            wLabel.ForeColor = Color.Black;
            wLabel.Location = new Point(256, 129);
            wLabel.Name = "wLabel";
            wLabel.Size = new Size(24, 25);
            wLabel.TabIndex = 93;
            wLabel.Text = "<";
            wLabel.Click += wLabel_Click;
            wLabel.MouseEnter += seLabel_MouseEnter;
            // 
            // appLocationLabel
            // 
            appLocationLabel.Location = new Point(222, 27);
            appLocationLabel.Name = "appLocationLabel";
            appLocationLabel.Size = new Size(194, 50);
            appLocationLabel.TabIndex = 92;
            appLocationLabel.Text = "App Location\r\n(Click Below):";
            appLocationLabel.TextAlign = ContentAlignment.TopCenter;
            // 
            // startWithWindowsCheckBox
            // 
            startWithWindowsCheckBox.AutoSize = true;
            startWithWindowsCheckBox.Location = new Point(14, 146);
            startWithWindowsCheckBox.Name = "startWithWindowsCheckBox";
            startWithWindowsCheckBox.Size = new Size(195, 29);
            startWithWindowsCheckBox.TabIndex = 91;
            startWithWindowsCheckBox.Text = "Start With Windows";
            startWithWindowsCheckBox.UseVisualStyleBackColor = true;
            startWithWindowsCheckBox.CheckedChanged += startWithWindowsCheckBox_CheckedChanged;
            startWithWindowsCheckBox.MouseEnter += startWithWindowsCheckBox_MouseEnter;
            // 
            // serialMaskedTextBox
            // 
            serialMaskedTextBox.Location = new Point(422, 55);
            serialMaskedTextBox.Mask = "AAAA-AAAA-AAAA-AAAA";
            serialMaskedTextBox.Name = "serialMaskedTextBox";
            serialMaskedTextBox.Size = new Size(202, 31);
            serialMaskedTextBox.TabIndex = 90;
            // 
            // registerButton
            // 
            registerButton.BackColor = SystemColors.Control;
            registerButton.ForeColor = Color.Black;
            registerButton.Location = new Point(421, 92);
            registerButton.Name = "registerButton";
            registerButton.Size = new Size(201, 39);
            registerButton.TabIndex = 89;
            registerButton.Text = "Register Serial #";
            registerButton.UseVisualStyleBackColor = false;
            registerButton.Click += registerButton_Click;
            // 
            // serialNumberLabel
            // 
            serialNumberLabel.AutoSize = true;
            serialNumberLabel.Location = new Point(421, 27);
            serialNumberLabel.Name = "serialNumberLabel";
            serialNumberLabel.Size = new Size(119, 25);
            serialNumberLabel.TabIndex = 79;
            serialNumberLabel.Text = "Enter Serial #:";
            // 
            // errorOccursLabel
            // 
            errorOccursLabel.AutoSize = true;
            errorOccursLabel.Location = new Point(21, 27);
            errorOccursLabel.Name = "errorOccursLabel";
            errorOccursLabel.Size = new Size(188, 25);
            errorOccursLabel.TabIndex = 78;
            errorOccursLabel.Text = "When an Error Occurs:";
            // 
            // restartCheckBox
            // 
            restartCheckBox.AutoSize = true;
            restartCheckBox.Checked = true;
            restartCheckBox.CheckState = CheckState.Checked;
            restartCheckBox.Location = new Point(14, 104);
            restartCheckBox.Name = "restartCheckBox";
            restartCheckBox.Size = new Size(161, 29);
            restartCheckBox.TabIndex = 77;
            restartCheckBox.Text = "RestartProgram";
            restartCheckBox.UseVisualStyleBackColor = true;
            restartCheckBox.CheckedChanged += restartCheckBox_CheckedChanged;
            restartCheckBox.MouseEnter += restartCheckBox_MouseEnter;
            // 
            // closeProgramCheckBox
            // 
            closeProgramCheckBox.AutoSize = true;
            closeProgramCheckBox.Location = new Point(17, 62);
            closeProgramCheckBox.Name = "closeProgramCheckBox";
            closeProgramCheckBox.Size = new Size(155, 29);
            closeProgramCheckBox.TabIndex = 76;
            closeProgramCheckBox.Text = "Close Program";
            closeProgramCheckBox.UseVisualStyleBackColor = true;
            closeProgramCheckBox.CheckedChanged += closeProgramCheckBox_CheckedChanged;
            closeProgramCheckBox.MouseEnter += closeProgramCheckBox_MouseEnter;
            // 
            // fileDirSettingsGroupBox
            // 
            fileDirSettingsGroupBox.BackColor = SystemColors.Control;
            fileDirSettingsGroupBox.Controls.Add(exportButton);
            fileDirSettingsGroupBox.Controls.Add(zipSettingsLabel);
            fileDirSettingsGroupBox.Controls.Add(zipTogetherCheckBox);
            fileDirSettingsGroupBox.Controls.Add(zipSeparateCheckBox);
            fileDirSettingsGroupBox.Controls.Add(exportListLabel);
            fileDirSettingsGroupBox.Controls.Add(fullPathsCheckBox);
            fileDirSettingsGroupBox.Controls.Add(onlyNamesCheckBox);
            fileDirSettingsGroupBox.ForeColor = Color.Black;
            fileDirSettingsGroupBox.Location = new Point(887, 240);
            fileDirSettingsGroupBox.Name = "fileDirSettingsGroupBox";
            fileDirSettingsGroupBox.Size = new Size(636, 138);
            fileDirSettingsGroupBox.TabIndex = 107;
            fileDirSettingsGroupBox.TabStop = false;
            fileDirSettingsGroupBox.Text = "File/Folder Settings (Pro):";
            fileDirSettingsGroupBox.MouseHover += fileDirSettingsGroupBox_MouseHover;
            // 
            // exportButton
            // 
            exportButton.BackColor = SystemColors.Control;
            exportButton.ForeColor = Color.Black;
            exportButton.Location = new Point(183, 91);
            exportButton.Name = "exportButton";
            exportButton.Size = new Size(152, 39);
            exportButton.TabIndex = 91;
            exportButton.Text = "Export File List";
            exportButton.UseVisualStyleBackColor = false;
            exportButton.Click += exportButton_Click;
            exportButton.MouseEnter += exportButton_MouseEnter;
            // 
            // zipSettingsLabel
            // 
            zipSettingsLabel.AutoSize = true;
            zipSettingsLabel.Location = new Point(336, 23);
            zipSettingsLabel.Name = "zipSettingsLabel";
            zipSettingsLabel.Size = new Size(236, 25);
            zipSettingsLabel.TabIndex = 78;
            zipSettingsLabel.Text = "Before C/M Zip File Settings:";
            // 
            // zipTogetherCheckBox
            // 
            zipTogetherCheckBox.AutoSize = true;
            zipTogetherCheckBox.Location = new Point(336, 97);
            zipTogetherCheckBox.Name = "zipTogetherCheckBox";
            zipTogetherCheckBox.Size = new Size(218, 29);
            zipTogetherCheckBox.TabIndex = 77;
            zipTogetherCheckBox.Text = "Zip Files/Dirs. Together";
            zipTogetherCheckBox.UseVisualStyleBackColor = true;
            zipTogetherCheckBox.CheckedChanged += zipTogetherCheckBox_CheckedChanged;
            zipTogetherCheckBox.MouseEnter += zipTogetherCheckBox_MouseEnter;
            // 
            // zipSeparateCheckBox
            // 
            zipSeparateCheckBox.AutoSize = true;
            zipSeparateCheckBox.Location = new Point(336, 62);
            zipSeparateCheckBox.Name = "zipSeparateCheckBox";
            zipSeparateCheckBox.Size = new Size(231, 29);
            zipSeparateCheckBox.TabIndex = 76;
            zipSeparateCheckBox.Text = "Zip Files/Dirs. Separately";
            zipSeparateCheckBox.UseVisualStyleBackColor = true;
            zipSeparateCheckBox.CheckedChanged += zipSeparateCheckBox_CheckedChanged;
            zipSeparateCheckBox.MouseHover += zipSeparateCheckBox_MouseHover;
            // 
            // exportListLabel
            // 
            exportListLabel.AutoSize = true;
            exportListLabel.Location = new Point(14, 23);
            exportListLabel.Name = "exportListLabel";
            exportListLabel.Size = new Size(167, 25);
            exportListLabel.TabIndex = 75;
            exportListLabel.Text = "Export List Settings:";
            // 
            // fullPathsCheckBox
            // 
            fullPathsCheckBox.AutoSize = true;
            fullPathsCheckBox.Checked = true;
            fullPathsCheckBox.CheckState = CheckState.Checked;
            fullPathsCheckBox.Location = new Point(14, 97);
            fullPathsCheckBox.Name = "fullPathsCheckBox";
            fullPathsCheckBox.Size = new Size(112, 29);
            fullPathsCheckBox.TabIndex = 74;
            fullPathsCheckBox.Text = "Full Paths";
            fullPathsCheckBox.UseVisualStyleBackColor = true;
            fullPathsCheckBox.CheckedChanged += fullPathsCheckBox_CheckedChanged;
            fullPathsCheckBox.MouseEnter += fullPathsCheckBox_MouseEnter;
            // 
            // onlyNamesCheckBox
            // 
            onlyNamesCheckBox.AutoSize = true;
            onlyNamesCheckBox.Location = new Point(14, 62);
            onlyNamesCheckBox.Name = "onlyNamesCheckBox";
            onlyNamesCheckBox.Size = new Size(200, 29);
            onlyNamesCheckBox.TabIndex = 73;
            onlyNamesCheckBox.Text = "Only File/Dir. Names";
            onlyNamesCheckBox.UseVisualStyleBackColor = true;
            onlyNamesCheckBox.CheckedChanged += onlyNamesCheckBox_CheckedChanged;
            onlyNamesCheckBox.MouseHover += onlyNamesCheckBox_MouseHover;
            // 
            // soundsGroupBox
            // 
            soundsGroupBox.BackColor = SystemColors.Control;
            soundsGroupBox.Controls.Add(onAddFilesCheckBox);
            soundsGroupBox.Controls.Add(onErrorCheckBox);
            soundsGroupBox.Controls.Add(onCancelCheckBox);
            soundsGroupBox.Controls.Add(onFinishCheckBox);
            soundsGroupBox.ForeColor = Color.Black;
            soundsGroupBox.Location = new Point(18, 400);
            soundsGroupBox.Name = "soundsGroupBox";
            soundsGroupBox.Size = new Size(636, 124);
            soundsGroupBox.TabIndex = 106;
            soundsGroupBox.TabStop = false;
            soundsGroupBox.Text = "Sound Settings:";
            soundsGroupBox.MouseHover += soundsGroupBox_MouseHover;
            // 
            // onAddFilesCheckBox
            // 
            onAddFilesCheckBox.AutoSize = true;
            onAddFilesCheckBox.Location = new Point(13, 88);
            onAddFilesCheckBox.Name = "onAddFilesCheckBox";
            onAddFilesCheckBox.Size = new Size(276, 29);
            onAddFilesCheckBox.TabIndex = 75;
            onAddFilesCheckBox.Text = "Play Sound When Files Added";
            onAddFilesCheckBox.UseVisualStyleBackColor = true;
            onAddFilesCheckBox.CheckedChanged += onAddFilesCheckBox_CheckedChanged;
            onAddFilesCheckBox.MouseEnter += onAddFilesCheckBox_MouseEnter;
            // 
            // onErrorCheckBox
            // 
            onErrorCheckBox.AutoSize = true;
            onErrorCheckBox.Checked = true;
            onErrorCheckBox.CheckState = CheckState.Checked;
            onErrorCheckBox.Location = new Point(367, 88);
            onErrorCheckBox.Name = "onErrorCheckBox";
            onErrorCheckBox.Size = new Size(196, 29);
            onErrorCheckBox.TabIndex = 74;
            onErrorCheckBox.Text = "Play Sound on Error";
            onErrorCheckBox.UseVisualStyleBackColor = true;
            onErrorCheckBox.CheckedChanged += onErrorCheckBox_CheckedChanged;
            onErrorCheckBox.MouseEnter += onErrorCheckBox_MouseEnter;
            // 
            // onCancelCheckBox
            // 
            onCancelCheckBox.AutoSize = true;
            onCancelCheckBox.Checked = true;
            onCancelCheckBox.CheckState = CheckState.Checked;
            onCancelCheckBox.Location = new Point(367, 35);
            onCancelCheckBox.Name = "onCancelCheckBox";
            onCancelCheckBox.Size = new Size(209, 29);
            onCancelCheckBox.TabIndex = 73;
            onCancelCheckBox.Text = "Play Sound on Cancel";
            onCancelCheckBox.UseVisualStyleBackColor = true;
            onCancelCheckBox.CheckedChanged += onCancelCheckBox_CheckedChanged;
            onCancelCheckBox.MouseEnter += onCancelCheckBox_MouseEnter;
            // 
            // onFinishCheckBox
            // 
            onFinishCheckBox.AutoSize = true;
            onFinishCheckBox.Checked = true;
            onFinishCheckBox.CheckState = CheckState.Checked;
            onFinishCheckBox.Location = new Point(13, 35);
            onFinishCheckBox.Name = "onFinishCheckBox";
            onFinishCheckBox.Size = new Size(203, 29);
            onFinishCheckBox.TabIndex = 72;
            onFinishCheckBox.Text = "Play Sound on Finish";
            onFinishCheckBox.UseVisualStyleBackColor = true;
            onFinishCheckBox.CheckedChanged += onFinishCheckBox_CheckedChanged;
            onFinishCheckBox.MouseEnter += onFinishCheckBox_MouseEnter;
            // 
            // skinsLanguageGoupBox
            // 
            skinsLanguageGoupBox.BackColor = SystemColors.Control;
            skinsLanguageGoupBox.Controls.Add(skinsComboBox);
            skinsLanguageGoupBox.Controls.Add(skinsLabel);
            skinsLanguageGoupBox.Controls.Add(languageComboBox);
            skinsLanguageGoupBox.Controls.Add(languageLabel);
            skinsLanguageGoupBox.ForeColor = Color.Black;
            skinsLanguageGoupBox.Location = new Point(18, 240);
            skinsLanguageGoupBox.Name = "skinsLanguageGoupBox";
            skinsLanguageGoupBox.Size = new Size(636, 138);
            skinsLanguageGoupBox.TabIndex = 105;
            skinsLanguageGoupBox.TabStop = false;
            skinsLanguageGoupBox.Text = "Themes and Language";
            skinsLanguageGoupBox.MouseHover += skinsLanguageGoupBox_MouseHover;
            // 
            // skinsComboBox
            // 
            skinsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            skinsComboBox.ForeColor = Color.Black;
            skinsComboBox.FormattingEnabled = true;
            skinsComboBox.Items.AddRange(new object[] { "Dark Mode", "Medium Mode", "Light Mode", "_________________", "Custom Color" });
            skinsComboBox.Location = new Point(136, 88);
            skinsComboBox.Name = "skinsComboBox";
            skinsComboBox.Size = new Size(488, 33);
            skinsComboBox.TabIndex = 70;
            skinsComboBox.SelectedIndexChanged += skinsComboBox_SelectedIndexChanged;
            skinsComboBox.MouseEnter += skinsComboBox_MouseEnter;
            // 
            // skinsLabel
            // 
            skinsLabel.AutoSize = true;
            skinsLabel.Location = new Point(50, 91);
            skinsLabel.Name = "skinsLabel";
            skinsLabel.Size = new Size(57, 25);
            skinsLabel.TabIndex = 69;
            skinsLabel.Text = "Skins:";
            skinsLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // languageComboBox
            // 
            languageComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            languageComboBox.FormattingEnabled = true;
            languageComboBox.Location = new Point(136, 27);
            languageComboBox.Name = "languageComboBox";
            languageComboBox.Size = new Size(488, 33);
            languageComboBox.TabIndex = 68;
            languageComboBox.SelectedIndexChanged += languageComboBox_SelectedIndexChanged;
            languageComboBox.MouseEnter += languageComboBox_MouseEnter;
            // 
            // languageLabel
            // 
            languageLabel.AutoSize = true;
            languageLabel.Location = new Point(14, 27);
            languageLabel.Name = "languageLabel";
            languageLabel.Size = new Size(93, 25);
            languageLabel.TabIndex = 67;
            languageLabel.Text = "Language:";
            languageLabel.TextAlign = ContentAlignment.MiddleRight;
            // 
            // windowGroupBox
            // 
            windowGroupBox.BackColor = SystemColors.Control;
            windowGroupBox.Controls.Add(contextMenuCheckBox);
            windowGroupBox.Controls.Add(minimizeSystemTrayCheckBox);
            windowGroupBox.Controls.Add(alwaysOnTopCheckBox);
            windowGroupBox.Controls.Add(confirmDragDropCheckBox);
            windowGroupBox.ForeColor = Color.Black;
            windowGroupBox.Location = new Point(18, 68);
            windowGroupBox.Name = "windowGroupBox";
            windowGroupBox.Size = new Size(636, 150);
            windowGroupBox.TabIndex = 104;
            windowGroupBox.TabStop = false;
            windowGroupBox.Text = "Window Settings:";
            windowGroupBox.MouseHover += windowGroupBox_MouseHover;
            // 
            // contextMenuCheckBox
            // 
            contextMenuCheckBox.AutoSize = true;
            contextMenuCheckBox.Checked = true;
            contextMenuCheckBox.CheckState = CheckState.Checked;
            contextMenuCheckBox.Location = new Point(71, 98);
            contextMenuCheckBox.Name = "contextMenuCheckBox";
            contextMenuCheckBox.Size = new Size(274, 29);
            contextMenuCheckBox.TabIndex = 74;
            contextMenuCheckBox.Text = "Add Copy That Context Menu";
            contextMenuCheckBox.UseVisualStyleBackColor = true;
            contextMenuCheckBox.CheckedChanged += contextMenuCheckBox_CheckedChanged;
            contextMenuCheckBox.MouseEnter += contextMenuCheckBox_MouseEnter;
            // 
            // minimizeSystemTrayCheckBox
            // 
            minimizeSystemTrayCheckBox.AutoSize = true;
            minimizeSystemTrayCheckBox.Checked = true;
            minimizeSystemTrayCheckBox.CheckState = CheckState.Checked;
            minimizeSystemTrayCheckBox.Location = new Point(336, 24);
            minimizeSystemTrayCheckBox.Name = "minimizeSystemTrayCheckBox";
            minimizeSystemTrayCheckBox.Size = new Size(229, 29);
            minimizeSystemTrayCheckBox.TabIndex = 72;
            minimizeSystemTrayCheckBox.Text = "Minimize to System Tray";
            minimizeSystemTrayCheckBox.UseVisualStyleBackColor = true;
            minimizeSystemTrayCheckBox.CheckedChanged += minimizeSystemTrayCheckBox_CheckedChanged;
            minimizeSystemTrayCheckBox.MouseEnter += minimizeSystemTrayCheckBox_MouseEnter;
            // 
            // alwaysOnTopCheckBox
            // 
            alwaysOnTopCheckBox.AutoSize = true;
            alwaysOnTopCheckBox.Checked = true;
            alwaysOnTopCheckBox.CheckState = CheckState.Checked;
            alwaysOnTopCheckBox.Location = new Point(71, 28);
            alwaysOnTopCheckBox.Name = "alwaysOnTopCheckBox";
            alwaysOnTopCheckBox.Size = new Size(153, 29);
            alwaysOnTopCheckBox.TabIndex = 71;
            alwaysOnTopCheckBox.Text = "Always on Top";
            alwaysOnTopCheckBox.UseVisualStyleBackColor = true;
            alwaysOnTopCheckBox.CheckedChanged += alwaysOnTopCheckBox_CheckedChanged;
            alwaysOnTopCheckBox.MouseEnter += alwaysOnTopCheckBox_MouseEnter;
            // 
            // confirmDragDropCheckBox
            // 
            confirmDragDropCheckBox.AutoSize = true;
            confirmDragDropCheckBox.Checked = true;
            confirmDragDropCheckBox.CheckState = CheckState.Checked;
            confirmDragDropCheckBox.Location = new Point(71, 63);
            confirmDragDropCheckBox.Name = "confirmDragDropCheckBox";
            confirmDragDropCheckBox.Size = new Size(239, 29);
            confirmDragDropCheckBox.TabIndex = 66;
            confirmDragDropCheckBox.Text = "Always Confirm File Drop";
            confirmDragDropCheckBox.UseVisualStyleBackColor = true;
            confirmDragDropCheckBox.CheckedChanged += confirmDragDropCheckBox_CheckedChanged;
            confirmDragDropCheckBox.MouseEnter += confirmDragDropCheckBox_MouseEnter;
            // 
            // cmdAboutPage
            // 
            cmdAboutPage.Controls.Add(aboutPanel);
            cmdAboutPage.Location = new Point(4, 34);
            cmdAboutPage.Name = "cmdAboutPage";
            cmdAboutPage.Size = new Size(1544, 1077);
            cmdAboutPage.TabIndex = 5;
            cmdAboutPage.Text = "- About";
            cmdAboutPage.UseVisualStyleBackColor = true;
            // 
            // aboutPanel
            // 
            aboutPanel.Controls.Add(aboutCTLabel);
            aboutPanel.Controls.Add(havocSoftwarePB);
            aboutPanel.Controls.Add(copyThatPB);
            aboutPanel.Location = new Point(0, 0);
            aboutPanel.Name = "aboutPanel";
            aboutPanel.Size = new Size(1534, 1074);
            aboutPanel.TabIndex = 0;
            // 
            // aboutCTLabel
            // 
            aboutCTLabel.Font = new Font("Segoe UI", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            aboutCTLabel.Location = new Point(476, 387);
            aboutCTLabel.Name = "aboutCTLabel";
            aboutCTLabel.Size = new Size(583, 300);
            aboutCTLabel.TabIndex = 2;
            aboutCTLabel.Text = "Copy That v1.0 Pro By: Havoc\r\nMade with Visual Studio 2022 Community\r\nC# .NET 8.0 Framework\r\nStarted: Nov. 2023\r\nVersion: 1.0";
            aboutCTLabel.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // havocSoftwarePB
            // 
            havocSoftwarePB.Image = Properties.Resources.HavocSoftwareGIF;
            havocSoftwarePB.Location = new Point(826, 21);
            havocSoftwarePB.Name = "havocSoftwarePB";
            havocSoftwarePB.Size = new Size(397, 290);
            havocSoftwarePB.SizeMode = PictureBoxSizeMode.StretchImage;
            havocSoftwarePB.TabIndex = 1;
            havocSoftwarePB.TabStop = false;
            // 
            // copyThatPB
            // 
            copyThatPB.Image = Properties.Resources.CopyThatLogoTurningGIF;
            copyThatPB.Location = new Point(312, 21);
            copyThatPB.Name = "copyThatPB";
            copyThatPB.Size = new Size(385, 290);
            copyThatPB.SizeMode = PictureBoxSizeMode.StretchImage;
            copyThatPB.TabIndex = 0;
            copyThatPB.TabStop = false;
            // 
            // titleLabel
            // 
            titleLabel.BorderStyle = BorderStyle.Fixed3D;
            titleLabel.FlatStyle = FlatStyle.System;
            titleLabel.Font = new Font("Cascadia Code", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            titleLabel.ForeColor = Color.Black;
            titleLabel.Location = new Point(5, 5);
            titleLabel.Name = "titleLabel";
            titleLabel.Size = new Size(1221, 58);
            titleLabel.TabIndex = 109;
            titleLabel.Text = "Copy That v1.0 By: Havoc";
            titleLabel.TextAlign = ContentAlignment.MiddleCenter;
            titleLabel.MouseDown += titleLabel_MouseDown;
            titleLabel.MouseEnter += titleLabel_MouseEnter;
            // 
            // openFileDialog
            // 
            openFileDialog.FileName = "openFileDialog1";
            // 
            // rollTimer
            // 
            rollTimer.Interval = 10;
            rollTimer.Tick += RollTimer_Tick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Tag = "";
            notifyIcon1.Text = "Copy That v1.0 By: Havoc";
            notifyIcon1.Visible = true;
            notifyIcon1.DoubleClick += notifyIcon1_DoubleClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(1691, 730);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 174;
            label2.Text = "label2";
            // 
            // rollUpLabel
            // 
            rollUpLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rollUpLabel.Location = new Point(1232, 11);
            rollUpLabel.Name = "rollUpLabel";
            rollUpLabel.Size = new Size(48, 52);
            rollUpLabel.TabIndex = 175;
            rollUpLabel.Text = "▲";
            rollUpLabel.TextAlign = ContentAlignment.MiddleCenter;
            rollUpLabel.Click += rollUpLabel_Click;
            rollUpLabel.MouseEnter += rollUpLabel_MouseEnter;
            // 
            // rollDownLabel
            // 
            rollDownLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            rollDownLabel.Location = new Point(1283, 11);
            rollDownLabel.Name = "rollDownLabel";
            rollDownLabel.Size = new Size(48, 52);
            rollDownLabel.TabIndex = 176;
            rollDownLabel.Text = "▼";
            rollDownLabel.TextAlign = ContentAlignment.MiddleCenter;
            rollDownLabel.Click += rollDownLabel_Click;
            rollDownLabel.MouseEnter += rollDownLabel_MouseEnter;
            // 
            // settingsLabel
            // 
            settingsLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            settingsLabel.Location = new Point(1334, 11);
            settingsLabel.Name = "settingsLabel";
            settingsLabel.Size = new Size(54, 52);
            settingsLabel.TabIndex = 177;
            settingsLabel.Text = "⚙";
            settingsLabel.TextAlign = ContentAlignment.MiddleCenter;
            settingsLabel.Click += settingsLabel_Click;
            settingsLabel.MouseEnter += settingsLabel_MouseEnter;
            // 
            // allAboutLabel
            // 
            allAboutLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            allAboutLabel.Location = new Point(1391, 11);
            allAboutLabel.Name = "allAboutLabel";
            allAboutLabel.Size = new Size(54, 52);
            allAboutLabel.TabIndex = 178;
            allAboutLabel.Text = "ℹ";
            allAboutLabel.TextAlign = ContentAlignment.MiddleCenter;
            allAboutLabel.Click += allAboutLabel_Click;
            allAboutLabel.MouseEnter += allAboutLabel_MouseEnter;
            // 
            // minimizeLabel
            // 
            minimizeLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            minimizeLabel.Location = new Point(1448, 11);
            minimizeLabel.Name = "minimizeLabel";
            minimizeLabel.Size = new Size(54, 52);
            minimizeLabel.TabIndex = 179;
            minimizeLabel.Text = "_";
            minimizeLabel.TextAlign = ContentAlignment.MiddleCenter;
            minimizeLabel.Click += minimizeLabel_Click;
            minimizeLabel.MouseEnter += minimizeLabel_MouseEnter;
            // 
            // exitLabel
            // 
            exitLabel.Font = new Font("Segoe UI", 16F, FontStyle.Regular, GraphicsUnit.Point, 0);
            exitLabel.Location = new Point(1505, 10);
            exitLabel.Name = "exitLabel";
            exitLabel.Size = new Size(54, 52);
            exitLabel.TabIndex = 180;
            exitLabel.Text = "X";
            exitLabel.TextAlign = ContentAlignment.MiddleCenter;
            exitLabel.Click += exitLabel_Click;
            exitLabel.MouseEnter += exitLabel_MouseEnter;
            // 
            // mainForm
            // 
            AllowDrop = true;
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1565, 1186);
            Controls.Add(exitLabel);
            Controls.Add(minimizeLabel);
            Controls.Add(allAboutLabel);
            Controls.Add(settingsLabel);
            Controls.Add(rollDownLabel);
            Controls.Add(rollUpLabel);
            Controls.Add(tabControl1);
            Controls.Add(label2);
            Controls.Add(titleLabel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "mainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Copy That v1.0 By: Havoc";
            Load += MainForm_Load;
            DragDrop += MainForm_DragDrop;
            DragEnter += MainForm_DragEnter;
            MouseEnter += mainForm_MouseEnter;
            Resize += MainForm_Resize;
            tabControl1.ResumeLayout(false);
            cmdHomePage.ResumeLayout(false);
            cmdHomePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)filesDataGridView).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)fileIconPicBox).EndInit();
            cmdMultithread.ResumeLayout(false);
            cmdMultithread.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            statusBarMulti.ResumeLayout(false);
            statusBarMulti.PerformLayout();
            cmdSkipPage.ResumeLayout(false);
            cmdSkipPage.PerformLayout();
            statusBarSkipped.ResumeLayout(false);
            statusBarSkipped.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)skippedDataGridView).EndInit();
            cmdCopyHistory.ResumeLayout(false);
            cmdCopyHistory.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)copyHistoryDGV).EndInit();
            statusBarCopyHistory.ResumeLayout(false);
            statusBarCopyHistory.PerformLayout();
            cmdExclusions.ResumeLayout(false);
            cmdExclusions.PerformLayout();
            statusBarExclusions.ResumeLayout(false);
            statusBarExclusions.PerformLayout();
            cmdTotals.ResumeLayout(false);
            cmdTotals.PerformLayout();
            cmdSettingsPage.ResumeLayout(false);
            cmdSettingsPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            statusBarSettings.ResumeLayout(false);
            statusBarSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)logDaysNumUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)opacityTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)priorityTrackBar).EndInit();
            emailGroupBox.ResumeLayout(false);
            emailGroupBox.PerformLayout();
            updateGroupBox.ResumeLayout(false);
            performanceGroupBox.ResumeLayout(false);
            performanceGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)setMBGBUnderNumUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)setMBGBOverNumUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)bufferNumUpDown).EndInit();
            otherSettingsGroupBox.ResumeLayout(false);
            otherSettingsGroupBox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)securePassesNumUpDown).EndInit();
            fileDirSettingsGroupBox.ResumeLayout(false);
            fileDirSettingsGroupBox.PerformLayout();
            soundsGroupBox.ResumeLayout(false);
            soundsGroupBox.PerformLayout();
            skinsLanguageGoupBox.ResumeLayout(false);
            skinsLanguageGoupBox.PerformLayout();
            windowGroupBox.ResumeLayout(false);
            windowGroupBox.PerformLayout();
            cmdAboutPage.ResumeLayout(false);
            aboutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)havocSoftwarePB).EndInit();
            ((System.ComponentModel.ISupportInitialize)copyThatPB).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl tabControl1;
        private TabPage cmdHomePage;
        private TabPage cmdSettingsPage;
        private Label exportFileListLabel;
        private Label opacityLabel;
        private TrackBar opacityTrackBar;
        private CheckBox logFileCheckBox;
        private Label priorityLabel;
        private TrackBar priorityTrackBar;
        private CheckBox saveAutoCheckBox;
        private Button defaultSettingsButton;
        private Button recSettingsButton;
        private Button clearSettingsButton;
        private Button saveSettingsButton;
        private GroupBox emailGroupBox;
        private Button setUpEmailButton;
        private CheckBox emailPathsCheckBox;
        private CheckBox emailNamesCheckBox;
        private Label whenEmailingLabel;
        private Button setUpSMSButton;
        private GroupBox updateGroupBox;
        private CheckBox updateManuallyCheckBox;
        private Button checkForUpdatesButton;
        private CheckBox updateBetaCheckBox;
        private CheckBox updateAutoCheckBox;
        private GroupBox performanceGroupBox;
        private Label kbLabel;
        private CheckBox multithreadCheckBox;
        private Label cmOnlyIfLabel;
        private CheckBox overMBCheckBox;
        private CheckBox underMBCheckBox;
        private Label setMBGBOLabel;
        private Label setMBGBULabel;
        private NumericUpDown setMBGBUnderNumUpDown;
        private Label setMBUmderLabel;
        private NumericUpDown setMBGBOverNumUpDown;
        private Label setMBGBOverLabel;
        private Label setBufferLabel;
        private GroupBox otherSettingsGroupBox;
        private Label seLabel;
        private Label sLabel;
        private Label swLabel;
        private Label eLabel;
        private Label neLabel;
        private Label nLabel;
        private Label nwLabel;
        private Label wLabel;
        private Label appLocationLabel;
        private CheckBox startWithWindowsCheckBox;
        private MaskedTextBox serialMaskedTextBox;
        private Button registerButton;
        private Label serialNumberLabel;
        private Label errorOccursLabel;
        private CheckBox restartCheckBox;
        private CheckBox closeProgramCheckBox;
        private GroupBox fileDirSettingsGroupBox;
        private Button exportButton;
        private Label zipSettingsLabel;
        private CheckBox zipTogetherCheckBox;
        private CheckBox zipSeparateCheckBox;
        private Label exportListLabel;
        private CheckBox fullPathsCheckBox;
        private CheckBox onlyNamesCheckBox;
        private GroupBox soundsGroupBox;
        private CheckBox onAddFilesCheckBox;
        private CheckBox onErrorCheckBox;
        private CheckBox onCancelCheckBox;
        private CheckBox onFinishCheckBox;
        private GroupBox skinsLanguageGoupBox;
        private ComboBox skinsComboBox;
        private Label skinsLabel;
        private ComboBox languageComboBox;
        private Label languageLabel;
        private GroupBox windowGroupBox;
        private CheckBox contextMenuCheckBox;
        private CheckBox minimizeSystemTrayCheckBox;
        private CheckBox alwaysOnTopCheckBox;
        private CheckBox confirmDragDropCheckBox;
        private Label fileNameLabel;
        private CheckBox doNotOverwriteCheckBox;
        private CheckBox overwriteAllCheckBox;
        private CheckBox overwriteIfNewerCheckBox;
        private Button removeFileButton;
        private Button addFileButton;
        private Button clearFileListButton;
        private Label moveBottomLabel;
        private Label moveTopLabel;
        private Label fileDownLabel;
        private Label fileUpLabel;
        private Button clearTextButton;
        private TextBox searchTextBox;
        private Label searchFileFolderLabel;
        private Label fileListLabel;
        private Label onFinishLabel;
        private Label cmdLabel;
        private ComboBox onFinishComboBox;
        private Button skipButton;
        private ComboBox copyMoveDeleteComboBox;
        private Label elapsedAndTargetTimeLabel;
        private Button pauseResumeButton;
        private Label overallProgressLabel;
        private Button cancelButton;
        private Button startButton;
        private PictureBox fileIconPicBox;
        private Label targetDirLabel;
        private Label fromFilesDirLabel;
        private Label filePathLabel;
        private Label targetLabel;
        private Label fromLabel;
        private TabPage cmdSkipPage;
        private Label totalSkippedLabel;
        private Button clearSkippedListButton;
        private Button goToInExplorerButton;
        private DataGridView skippedDataGridView;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn sourcePath;
        private DataGridViewTextBoxColumn destinationPath;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private TabPage cmdCopyHistory;
        private TabPage cmdExclusions;
        private Button clearExcludedButton;
        private Button removeExcludedButton;
        private Button addExcludedButton;
        private Button clearAllowedButton;
        private Button removeAllowedButton;
        private Button addAllowedButton;
        private TextBox excludedTextBox;
        private TextBox allowedTextBox;
        private Label excludedLabel;
        private Label allowedLabel;
        private ListBox excludedExtListBox;
        private ListBox allowedExtListBox;
        private Label titleLabel;
        private Label retentionLabel;
        private NumericUpDown logDaysNumUpDown;
        private System.Windows.Forms.Timer scrollTimer;
        private TabPage cmdAboutPage;
        private OpenFileDialog openFileDialog;
        private System.ComponentModel.BackgroundWorker removeDirBGW;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private CheckBox autoScrollCheckBox;
        private Label totalHistoryLabel;
        private Button clearHistoryButton;
        private Button cloneButton;
        private Button deleteEntryButton;
        private TabPage cmdMultithread;
        private Label filesNameLabel1;
        private Label onFinishMultiLabel;
        private ComboBox onFinishMultiComboBox;
        private Button pauseResumeMultiButton;
        private Button cancelMultiButton;
        private Label totalSpaceMultiLabel;
        private Label speedMultiLabel;
        private Label totalCMDMultiLabel;
        private Label fileCountMultiLabel;
        private Label totalTimeMultiLabel;
        private Label filesNameLabel4;
        private Label filesNameLabel3;
        private Label filesNameLabel2;
        private System.Windows.Forms.Timer rollTimer;
        private NotifyIcon notifyIcon1;
        private Label aboutLabel;
        private Label exitLabel;
        private Label minimizeLabel;
        private Label allAboutLabel;
        private Panel aboutPanel;
        private PictureBox havocSoftwarePB;
        private Label label2;
        private NumericUpDown securePassesNumUpDown;
        private Label totalProgressMultiLabel;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel statusLabel;
        private Label fileOptionsLabel;
        private StatusStrip statusBarMulti;
        private ToolStripStatusLabel toolStripMulti;
        private StatusStrip statusBarSkipped;
        private ToolStripStatusLabel toolStripSkipped;
        private StatusStrip statusBarCopyHistory;
        private ToolStripStatusLabel toolStripCopyHistory;
        private StatusStrip statusBarExclusions;
        private ToolStripStatusLabel toolStripExclusions;
        private StatusStrip statusBarSettings;
        private ToolStripStatusLabel toolStripSettings;
        private DataGridView copyHistoryDGV;
        private DataGridViewTextBoxColumn Operation;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private DataGridViewTextBoxColumn TotalDirSize;
        private DataGridView dataGridView1;
        private DataGridView dataGridView2;
        private DataGridView filesDataGridView;
        private Label rollUpLabel;
        private Label rollDownLabel;
        private Label settingsLabel;
        private Label targetDirectoryLabel;
        private Label sourceDirectoryLabel;
        private Label moveFileUpLabel;
        private Label moveFileDownLabel;
        private Label moveToTopLabel;
        private Label moveToBottomLabel;
        private CustomControls.ModernCircularProgressBar totalProgressBar;
        private CustomControls.ModernCircularProgressBar fileProgressBar;
        private Label fileOverAllProgressLabel;
        private CustomControls.ModernCircularProgressBar progressBarMultiThreadTotal;
        private CustomControls.ModernCircularProgressBar progressBarMutli1;
        private CustomControls.ModernCircularProgressBar progressBarMutli2;
        private CustomControls.ModernCircularProgressBar progressBarMutli3;
        private CustomControls.ModernCircularProgressBar progressBarMutli4;
        private Label thread4Label;
        private Label thread3Label;
        private Label thread2Label;
        private Label thread1Label;
        private TabPage cmdTotals;
        private Label totalCompletedOperationsTitleLabel;
        private Label totalCancelledOperationsTitleLabel;
        private Label totalDeleteOperationsTItleLabel;
        private Label totalMoveOperationsTitleLabel;
        private Label totalCopyOperationsLabel;
        private Label titleTotalsLabel;
        private Label totalCopyOperationsTitleLabel;
        private Label totalCompletedOperationsLabel;
        private Label totalCancelledOperationsLabel;
        private Label totalDeleteOperationsLabel;
        private Label totalMoveOperationsLabel;
        private Label totalFilesFailedLabel;
        private Label totalFilesSkippedLabel;
        private Label totalFilesDeletedLabel;
        private Label totalFilesCopiedLabel;
        private Label totalFilesConsideredTitleLabel;
        private Label totalFilesFailedTitleLabel;
        private Label totalFilesSkippedTitleLabel;
        private Label totalFilesDeletedTitleLabel;
        private Label totalFilesCopiedTitleLabel;
        private Label totalFilesConsideredLabel;
        private Label totalFilesMovedTitleLabel;
        private Label totalFilesMovedLabel;
        private Label totalTargetTimeLabel;
        private Label totalElapsedTimeLabel;
        private Label totalBytesToProcessLabel;
        private Label totalBytesProcessedLabel;
        private Label totalTargetTimeTitleLabel;
        private Label totalElapsedTimeTitleLabel;
        private Label totalBytesToProcessTitleLabel;
        private Label totalBytesProcessedTitleLabel;
        private Button resetTotalsButton;
        private Label secureDeleteLabel;
        private Label aboutCTLabel;
        private PictureBox copyThatPB;
    }
}
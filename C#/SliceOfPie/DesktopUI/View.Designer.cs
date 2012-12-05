namespace DesktopUI
{
    partial class View
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(View));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.listView1 = new System.Windows.Forms.ListView();
            this.name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.rootDirectory = new System.Windows.Forms.TextBox();
            this.usernameTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.DocumentContent = new System.Windows.Forms.TextBox();
            this.DocumentNameLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.UpdateSettingsButton = new System.Windows.Forms.Button();
            this.synchronizeButton = new System.Windows.Forms.Button();
            this.createDocumentButton = new System.Windows.Forms.Button();
            this.CreateDocumentText = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.CreateFolderText = new System.Windows.Forms.TextBox();
            this.CreateFolderButton = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.ShareFolderButton = new System.Windows.Forms.Button();
            this.ShareDocumentButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.DeleteDocumentButton = new System.Windows.Forms.Button();
            this.listView2 = new System.Windows.Forms.ListView();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.updateInvitationsButton = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.acceptButton = new System.Windows.Forms.Button();
            this.deleteFolderButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Location = new System.Drawing.Point(32, 203);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.listView1);
            this.splitContainer1.Size = new System.Drawing.Size(313, 159);
            this.splitContainer1.SplitterDistance = 149;
            this.splitContainer1.TabIndex = 1;
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.ImageIndex = 0;
            this.treeView1.ImageList = this.imageList1;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            this.treeView1.SelectedImageIndex = 0;
            this.treeView1.Size = new System.Drawing.Size(149, 159);
            this.treeView1.TabIndex = 0;
            this.treeView1.NodeMouseClick += new System.Windows.Forms.TreeNodeMouseClickEventHandler(this.treeView1_NodeMouseClick);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "leopard-folder.png");
            this.imageList1.Images.SetKeyName(1, "document.png");
            // 
            // listView1
            // 
            this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name});
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(0, 0);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(160, 159);
            this.listView1.SmallImageList = this.imageList1;
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            this.listView1.ItemActivate += new System.EventHandler(this.OnItemActivated);
            // 
            // name
            // 
            this.name.Text = "Name";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Root directory";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Username";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Password";
            // 
            // rootDirectory
            // 
            this.rootDirectory.Location = new System.Drawing.Point(108, 29);
            this.rootDirectory.Name = "rootDirectory";
            this.rootDirectory.Size = new System.Drawing.Size(184, 20);
            this.rootDirectory.TabIndex = 5;
            this.rootDirectory.Text = "../..";
            // 
            // usernameTextBox
            // 
            this.usernameTextBox.Location = new System.Drawing.Point(108, 61);
            this.usernameTextBox.Name = "usernameTextBox";
            this.usernameTextBox.Size = new System.Drawing.Size(184, 20);
            this.usernameTextBox.TabIndex = 6;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Location = new System.Drawing.Point(108, 88);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(184, 20);
            this.passwordTextBox.TabIndex = 7;
            // 
            // DocumentContent
            // 
            this.DocumentContent.Location = new System.Drawing.Point(379, 100);
            this.DocumentContent.Multiline = true;
            this.DocumentContent.Name = "DocumentContent";
            this.DocumentContent.Size = new System.Drawing.Size(361, 356);
            this.DocumentContent.TabIndex = 8;
            // 
            // DocumentNameLabel
            // 
            this.DocumentNameLabel.AutoSize = true;
            this.DocumentNameLabel.Location = new System.Drawing.Point(376, 71);
            this.DocumentNameLabel.Name = "DocumentNameLabel";
            this.DocumentNameLabel.Size = new System.Drawing.Size(88, 13);
            this.DocumentNameLabel.TabIndex = 9;
            this.DocumentNameLabel.Text = "Document name:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.UpdateSettingsButton);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.passwordTextBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.usernameTextBox);
            this.groupBox1.Controls.Add(this.rootDirectory);
            this.groupBox1.Location = new System.Drawing.Point(32, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(313, 165);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Settings";
            // 
            // UpdateSettingsButton
            // 
            this.UpdateSettingsButton.Location = new System.Drawing.Point(178, 123);
            this.UpdateSettingsButton.Name = "UpdateSettingsButton";
            this.UpdateSettingsButton.Size = new System.Drawing.Size(114, 23);
            this.UpdateSettingsButton.TabIndex = 8;
            this.UpdateSettingsButton.Text = "Update Settings";
            this.UpdateSettingsButton.UseVisualStyleBackColor = true;
            this.UpdateSettingsButton.Click += new System.EventHandler(this.onClickUpdateSettings);
            // 
            // synchronizeButton
            // 
            this.synchronizeButton.Location = new System.Drawing.Point(642, 21);
            this.synchronizeButton.Name = "synchronizeButton";
            this.synchronizeButton.Size = new System.Drawing.Size(78, 23);
            this.synchronizeButton.TabIndex = 11;
            this.synchronizeButton.Text = "Synchronize";
            this.synchronizeButton.UseVisualStyleBackColor = true;
            this.synchronizeButton.Click += new System.EventHandler(this.OnClickSynchronize);
            // 
            // createDocumentButton
            // 
            this.createDocumentButton.Location = new System.Drawing.Point(196, 21);
            this.createDocumentButton.Name = "createDocumentButton";
            this.createDocumentButton.Size = new System.Drawing.Size(100, 23);
            this.createDocumentButton.TabIndex = 12;
            this.createDocumentButton.Text = "Create Document";
            this.createDocumentButton.UseVisualStyleBackColor = true;
            this.createDocumentButton.Click += new System.EventHandler(this.OnClickCreateDocument);
            // 
            // CreateDocumentText
            // 
            this.CreateDocumentText.Location = new System.Drawing.Point(49, 24);
            this.CreateDocumentText.Name = "CreateDocumentText";
            this.CreateDocumentText.Size = new System.Drawing.Size(141, 20);
            this.CreateDocumentText.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Name";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.CreateDocumentText);
            this.groupBox2.Controls.Add(this.createDocumentButton);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(32, 379);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(313, 54);
            this.groupBox2.TabIndex = 16;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Create Document";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.CreateFolderText);
            this.groupBox3.Controls.Add(this.CreateFolderButton);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Location = new System.Drawing.Point(32, 453);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(313, 54);
            this.groupBox3.TabIndex = 17;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Create Folder";
            // 
            // CreateFolderText
            // 
            this.CreateFolderText.Location = new System.Drawing.Point(49, 24);
            this.CreateFolderText.Name = "CreateFolderText";
            this.CreateFolderText.Size = new System.Drawing.Size(141, 20);
            this.CreateFolderText.TabIndex = 14;
            // 
            // CreateFolderButton
            // 
            this.CreateFolderButton.Location = new System.Drawing.Point(196, 22);
            this.CreateFolderButton.Name = "CreateFolderButton";
            this.CreateFolderButton.Size = new System.Drawing.Size(96, 23);
            this.CreateFolderButton.TabIndex = 12;
            this.CreateFolderButton.Text = "Create Folder";
            this.CreateFolderButton.UseVisualStyleBackColor = true;
            this.CreateFolderButton.Click += new System.EventHandler(this.OnClickCreateFolder);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 15;
            this.label6.Text = "Name";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox5);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.textBox1);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.ShareFolderButton);
            this.groupBox4.Controls.Add(this.ShareDocumentButton);
            this.groupBox4.Location = new System.Drawing.Point(32, 526);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(313, 82);
            this.groupBox4.TabIndex = 18;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Share";
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(49, 50);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(141, 20);
            this.textBox5.TabIndex = 18;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(29, 13);
            this.label8.TabIndex = 19;
            this.label8.Text = "User";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(49, 21);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(141, 20);
            this.textBox1.TabIndex = 16;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(29, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "User";
            // 
            // ShareFolderButton
            // 
            this.ShareFolderButton.Location = new System.Drawing.Point(196, 48);
            this.ShareFolderButton.Name = "ShareFolderButton";
            this.ShareFolderButton.Size = new System.Drawing.Size(96, 23);
            this.ShareFolderButton.TabIndex = 13;
            this.ShareFolderButton.Text = "Share Folder";
            this.ShareFolderButton.UseVisualStyleBackColor = true;
            this.ShareFolderButton.Click += new System.EventHandler(this.OnClickShareFolderButton);
            // 
            // ShareDocumentButton
            // 
            this.ShareDocumentButton.Location = new System.Drawing.Point(196, 19);
            this.ShareDocumentButton.Name = "ShareDocumentButton";
            this.ShareDocumentButton.Size = new System.Drawing.Size(96, 23);
            this.ShareDocumentButton.TabIndex = 12;
            this.ShareDocumentButton.Text = "Share Document";
            this.ShareDocumentButton.UseVisualStyleBackColor = true;
            this.ShareDocumentButton.Click += new System.EventHandler(this.onClickShareDocumentButton);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(379, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 23);
            this.button1.TabIndex = 19;
            this.button1.Text = "Save";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnClickSave);
            // 
            // DeleteDocumentButton
            // 
            this.DeleteDocumentButton.Location = new System.Drawing.Point(448, 21);
            this.DeleteDocumentButton.Name = "DeleteDocumentButton";
            this.DeleteDocumentButton.Size = new System.Drawing.Size(102, 23);
            this.DeleteDocumentButton.TabIndex = 20;
            this.DeleteDocumentButton.Text = "Delete Document";
            this.DeleteDocumentButton.UseVisualStyleBackColor = true;
            this.DeleteDocumentButton.Click += new System.EventHandler(this.OnDeleteDocumentButtonClicked);
            // 
            // listView2
            // 
            this.listView2.Location = new System.Drawing.Point(12, 25);
            this.listView2.Name = "listView2";
            this.listView2.Size = new System.Drawing.Size(213, 81);
            this.listView2.TabIndex = 21;
            this.listView2.UseCompatibleStateImageBehavior = false;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.updateInvitationsButton);
            this.groupBox5.Controls.Add(this.button2);
            this.groupBox5.Controls.Add(this.acceptButton);
            this.groupBox5.Controls.Add(this.listView2);
            this.groupBox5.Location = new System.Drawing.Point(379, 482);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(361, 126);
            this.groupBox5.TabIndex = 22;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Invitations";
            // 
            // updateInvitationsButton
            // 
            this.updateInvitationsButton.Location = new System.Drawing.Point(245, 85);
            this.updateInvitationsButton.Name = "updateInvitationsButton";
            this.updateInvitationsButton.Size = new System.Drawing.Size(96, 23);
            this.updateInvitationsButton.TabIndex = 23;
            this.updateInvitationsButton.Text = "Update";
            this.updateInvitationsButton.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(245, 56);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 22;
            this.button2.Text = "Ignore";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // acceptButton
            // 
            this.acceptButton.Location = new System.Drawing.Point(245, 27);
            this.acceptButton.Name = "acceptButton";
            this.acceptButton.Size = new System.Drawing.Size(96, 23);
            this.acceptButton.TabIndex = 20;
            this.acceptButton.Text = "Accept";
            this.acceptButton.UseVisualStyleBackColor = true;
            // 
            // deleteFolderButton
            // 
            this.deleteFolderButton.Location = new System.Drawing.Point(556, 21);
            this.deleteFolderButton.Name = "deleteFolderButton";
            this.deleteFolderButton.Size = new System.Drawing.Size(80, 23);
            this.deleteFolderButton.TabIndex = 23;
            this.deleteFolderButton.Text = "Delete Folder";
            this.deleteFolderButton.UseVisualStyleBackColor = true;
            this.deleteFolderButton.Click += new System.EventHandler(this.onClickDeleteFolderButton);
            // 
            // View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(792, 639);
            this.Controls.Add(this.deleteFolderButton);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.DeleteDocumentButton);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.synchronizeButton);
            this.Controls.Add(this.DocumentNameLabel);
            this.Controls.Add(this.DocumentContent);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "View";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox rootDirectory;
        private System.Windows.Forms.TextBox usernameTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.TextBox DocumentContent;
        private System.Windows.Forms.Label DocumentNameLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button UpdateSettingsButton;
        private System.Windows.Forms.Button synchronizeButton;
        private System.Windows.Forms.Button createDocumentButton;
        private System.Windows.Forms.TextBox CreateDocumentText;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox CreateFolderText;
        private System.Windows.Forms.Button CreateFolderButton;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button ShareDocumentButton;
        private System.Windows.Forms.Button ShareFolderButton;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button DeleteDocumentButton;
        private System.Windows.Forms.ListView listView2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Button updateInvitationsButton;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button acceptButton;
        private System.Windows.Forms.Button deleteFolderButton;


    }
}


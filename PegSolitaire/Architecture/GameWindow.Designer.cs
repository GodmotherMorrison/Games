using System.Windows.Forms;
using PegSolitaire.Architecture.Controls;

namespace PegSolitaire.Architecture
{
    partial class GameWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameWindow));
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel = new System.Windows.Forms.Panel();
            this.panelMenu = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxPlay = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxNewGame = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxSelectField = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxExit = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.panelBoards = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxStandart = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxEuropean = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxWiegleb = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxAsymmetrical = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxDiamond = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.panelGame = new System.Windows.Forms.Panel();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.buttonExit = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.Title = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.tableLayoutPanel.SuspendLayout();
            this.panel.SuspendLayout();
            this.panelMenu.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            this.panelBoards.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStandart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEuropean)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWiegleb)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAsymmetrical)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDiamond)).BeginInit();
            this.panelGame.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.tableLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.panel, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.Title, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(641, 581);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // panel
            // 
            this.panel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel.BackColor = System.Drawing.Color.Black;

            this.panel.Controls.Add(this.panelBoards);
            this.panel.Controls.Add(this.panelMenu);
            this.panel.Controls.Add(this.panelGame);
            this.panel.Location = new System.Drawing.Point(3, 119);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(635, 459);
            this.panel.TabIndex = 1;
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Black;
            this.panelMenu.Controls.Add(this.tableLayoutPanel1);
            this.panelMenu.Enabled = false;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(635, 459);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.Visible = false;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(635, 459);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxPlay, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxNewGame, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxSelectField, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.pictureBoxExit, 0, 4);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(130, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(375, 453);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBoxPlay
            // 
            this.pictureBoxPlay.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPlay.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxPlay.Image")));
            this.pictureBoxPlay.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxPlay.Location = new System.Drawing.Point(3, 48);
            this.pictureBoxPlay.Name = "pictureBoxPlay";
            this.pictureBoxPlay.Size = new System.Drawing.Size(369, 84);
            this.pictureBoxPlay.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxPlay.TabIndex = 0;
            this.pictureBoxPlay.TabStop = false;
            this.pictureBoxPlay.Click += new System.EventHandler(this.PictureBoxPlay_Click);
            this.pictureBoxPlay.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxPlay.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxNewGame
            // 
            this.pictureBoxNewGame.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxNewGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxNewGame.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxNewGame.Image")));
            this.pictureBoxNewGame.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxNewGame.Location = new System.Drawing.Point(3, 138);
            this.pictureBoxNewGame.Name = "pictureBoxNewGame";
            this.pictureBoxNewGame.Size = new System.Drawing.Size(369, 84);
            this.pictureBoxNewGame.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxNewGame.TabIndex = 1;
            this.pictureBoxNewGame.TabStop = false;
            this.pictureBoxNewGame.Click += new System.EventHandler(this.PictureBoxNewGame_Click);
            this.pictureBoxNewGame.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxNewGame.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxSelectField
            // 
            this.pictureBoxSelectField.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxSelectField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxSelectField.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxSelectField.Image")));
            this.pictureBoxSelectField.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxSelectField.Location = new System.Drawing.Point(3, 228);
            this.pictureBoxSelectField.Name = "pictureBoxSelectField";
            this.pictureBoxSelectField.Size = new System.Drawing.Size(369, 84);
            this.pictureBoxSelectField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectField.TabIndex = 2;
            this.pictureBoxSelectField.TabStop = false;
            this.pictureBoxSelectField.Click += new System.EventHandler(this.PictureBoxSelectField_Click);
            this.pictureBoxSelectField.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxSelectField.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxExit.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxExit.Image")));
            this.pictureBoxExit.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxExit.Location = new System.Drawing.Point(3, 318);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(369, 84);
            this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExit.TabIndex = 3;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.PictureBoxExit_Click);
            this.pictureBoxExit.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxExit.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // panelBoards
            // 
            this.panelBoards.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelBoards.BackColor = System.Drawing.Color.Black;
            this.panelBoards.Controls.Add(this.tableLayoutPanel3);
            this.panelBoards.Enabled = false;
            this.panelBoards.Location = new System.Drawing.Point(0, 0);
            this.panelBoards.Name = "panelBoards";
            this.panelBoards.Size = new System.Drawing.Size(635, 459);
            this.panelBoards.TabIndex = 1;
            this.panelBoards.Visible = false;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel3.Controls.Add(this.tableLayoutPanel4, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(635, 459);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Controls.Add(this.pictureBoxStandart, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.pictureBoxEuropean, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.pictureBoxWiegleb, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.pictureBoxAsymmetrical, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.pictureBoxDiamond, 0, 4);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(130, 3);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(375, 453);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // pictureBoxStandart
            // 
            this.pictureBoxStandart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxStandart.Image = global::PegSolitaire.Images.StandartBoard;
            this.pictureBoxStandart.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxStandart.Location = new System.Drawing.Point(3, 3);
            this.pictureBoxStandart.Name = "pictureBoxStandart";
            this.pictureBoxStandart.Size = new System.Drawing.Size(369, 84);
            this.pictureBoxStandart.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxStandart.TabIndex = 0;
            this.pictureBoxStandart.TabStop = false;
            this.pictureBoxStandart.Click += new System.EventHandler(this.PictureBoxStandart_Click);
            this.pictureBoxStandart.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxStandart.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxEuropean
            // 
            this.pictureBoxEuropean.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxEuropean.Image = global::PegSolitaire.Images.EuropeanBoard;
            this.pictureBoxEuropean.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxEuropean.Location = new System.Drawing.Point(3, 93);
            this.pictureBoxEuropean.Name = "pictureBoxEuropean";
            this.pictureBoxEuropean.Size = new System.Drawing.Size(369, 84);
            this.pictureBoxEuropean.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxEuropean.TabIndex = 1;
            this.pictureBoxEuropean.TabStop = false;
            this.pictureBoxEuropean.Click += new System.EventHandler(this.PictureBoxEuropean_Click);
            this.pictureBoxEuropean.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxEuropean.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxWiegleb
            // 
            this.pictureBoxWiegleb.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxWiegleb.Image = global::PegSolitaire.Images.WieglebBoard;
            this.pictureBoxWiegleb.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxWiegleb.Location = new System.Drawing.Point(3, 183);
            this.pictureBoxWiegleb.Name = "pictureBoxWiegleb";
            this.pictureBoxWiegleb.Size = new System.Drawing.Size(369, 84);
            this.pictureBoxWiegleb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxWiegleb.TabIndex = 2;
            this.pictureBoxWiegleb.TabStop = false;
            this.pictureBoxWiegleb.Click += new System.EventHandler(this.PictureBoxWiegleb_Click);
            this.pictureBoxWiegleb.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxWiegleb.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxAsymmetrical
            // 
            this.pictureBoxAsymmetrical.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxAsymmetrical.Image = global::PegSolitaire.Images.AsymmetricalBoard;
            this.pictureBoxAsymmetrical.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxAsymmetrical.Location = new System.Drawing.Point(3, 273);
            this.pictureBoxAsymmetrical.Name = "pictureBoxAsymmetrical";
            this.pictureBoxAsymmetrical.Size = new System.Drawing.Size(369, 84);
            this.pictureBoxAsymmetrical.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxAsymmetrical.TabIndex = 3;
            this.pictureBoxAsymmetrical.TabStop = false;
            this.pictureBoxAsymmetrical.Click += new System.EventHandler(this.PictureBoxAsymmetrical_Click);
            this.pictureBoxAsymmetrical.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxAsymmetrical.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxDiamond
            // 
            this.pictureBoxDiamond.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDiamond.Image = global::PegSolitaire.Images.DiamondBoard;
            this.pictureBoxDiamond.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxDiamond.Location = new System.Drawing.Point(3, 363);
            this.pictureBoxDiamond.Name = "pictureBoxDiamond";
            this.pictureBoxDiamond.Size = new System.Drawing.Size(369, 87);
            this.pictureBoxDiamond.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxDiamond.TabIndex = 4;
            this.pictureBoxDiamond.TabStop = false;
            this.pictureBoxDiamond.Click += new System.EventHandler(this.PictureBoxDiamond_Click);
            this.pictureBoxDiamond.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxDiamond.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // panelGame
            // 
            this.panelGame.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelGame.BackColor = System.Drawing.Color.Black;
            this.panelGame.Controls.Add(this.tableLayoutPanel5);
            this.panelGame.Enabled = false;
            this.panelGame.Location = new System.Drawing.Point(0, 0);
            this.panelGame.Name = "panelGame";
            this.panelGame.Size = new System.Drawing.Size(635, 459);
            this.panelGame.TabIndex = 1;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 3;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.140351F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 87.7193F));
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.140351F));
            this.tableLayoutPanel5.Controls.Add(this.pictureBox1, 1, 0);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 2, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 1;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(635, 459);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBox1.Location = new System.Drawing.Point(41, 3);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(551, 453);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.PictureBox1_SizeChanged);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.BackColor = System.Drawing.Color.Transparent;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.buttonExit, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(598, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 93.45795F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 6.542056F));
            this.tableLayoutPanel6.Size = new System.Drawing.Size(34, 453);
            this.tableLayoutPanel6.TabIndex = 1;
            // 
            // buttonExit
            // 
            this.buttonExit.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonExit.Image = ((System.Drawing.Image)(resources.GetObject("buttonExit.Image")));
            this.buttonExit.InitialImage = null;
            this.buttonExit.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.buttonExit.Location = new System.Drawing.Point(3, 426);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(28, 24);
            this.buttonExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonExit.TabIndex = 0;
            this.buttonExit.TabStop = false;
            this.buttonExit.Click += new System.EventHandler(this.ButtonExit_Click);
            this.buttonExit.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.buttonExit.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.Image = ((System.Drawing.Image)(resources.GetObject("Title.Image")));
            this.Title.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.Title.Location = new System.Drawing.Point(3, 3);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(635, 110);
            this.Title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Title.TabIndex = 1;
            this.Title.TabStop = false;
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(641, 581);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameWindow";
            this.Text = "Peg Solitaire";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameWindow_KeyPress);
            this.tableLayoutPanel.ResumeLayout(false);
            this.panel.ResumeLayout(false);
            this.panelMenu.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            this.panelBoards.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxStandart)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxEuropean)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxWiegleb)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxAsymmetrical)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDiamond)).EndInit();
            this.panelGame.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.tableLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.buttonExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private Panel panelBoards;
        private Panel panel;
        private TableLayoutPanel tableLayoutPanel;

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelGame;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;

        private PictureBoxWithInterpolationMode pictureBoxPlay;
        private PictureBoxWithInterpolationMode pictureBoxNewGame;
        private PictureBoxWithInterpolationMode pictureBoxSelectField;
        private PictureBoxWithInterpolationMode pictureBoxExit;
        private PictureBoxWithInterpolationMode Title;
        private TableLayoutPanel tableLayoutPanel3;
        private TableLayoutPanel tableLayoutPanel4;
        private PictureBoxWithInterpolationMode pictureBoxStandart;
        private PictureBoxWithInterpolationMode pictureBoxEuropean;
        private PictureBoxWithInterpolationMode pictureBoxWiegleb;
        private PictureBoxWithInterpolationMode pictureBoxAsymmetrical;
        private PictureBoxWithInterpolationMode pictureBoxDiamond;
        private TableLayoutPanel tableLayoutPanel5;
        private PictureBoxWithInterpolationMode pictureBox1;
        private TableLayoutPanel tableLayoutPanel6;
        private PictureBoxWithInterpolationMode buttonExit;
    }
}


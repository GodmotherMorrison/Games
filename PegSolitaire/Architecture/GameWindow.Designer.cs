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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBoxPlay = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxNewGame = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxSelectField = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.pictureBoxExit = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.Title = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.Title1 = new PegSolitaire.Architecture.Controls.PictureBoxWithInterpolationMode();
            this.gamePanel = new System.Windows.Forms.Panel();
            this.tableLayoutPanelGame = new System.Windows.Forms.TableLayoutPanel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMenu.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlay)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewGame)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectField)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).BeginInit();
            this.gamePanel.SuspendLayout();
            this.tableLayoutPanelGame.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMenu.BackColor = System.Drawing.Color.Black;
            this.panelMenu.Controls.Add(this.tableLayoutPanel);
            this.panelMenu.Enabled = false;
            this.panelMenu.Location = new System.Drawing.Point(12, 12);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(260, 230);
            this.panelMenu.TabIndex = 1;
            this.panelMenu.Visible = false;
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.tableLayoutPanel1, 0, 1);
            this.tableLayoutPanel.Controls.Add(this.Title, 0, 0);
            this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(260, 230);
            this.tableLayoutPanel.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 60);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(254, 167);
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
            this.tableLayoutPanel2.Location = new System.Drawing.Point(53, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(146, 161);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // pictureBoxPlay
            // 
            this.pictureBoxPlay.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxPlay.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBoxPlay.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxPlay.Image = global::PegSolitaire.Images.Play;
            this.pictureBoxPlay.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxPlay.Location = new System.Drawing.Point(3, 35);
            this.pictureBoxPlay.Name = "pictureBoxPlay";
            this.pictureBoxPlay.Size = new System.Drawing.Size(140, 18);
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
            this.pictureBoxNewGame.Image = global::PegSolitaire.Images.NewGame;
            this.pictureBoxNewGame.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxNewGame.Location = new System.Drawing.Point(3, 59);
            this.pictureBoxNewGame.Name = "pictureBoxNewGame";
            this.pictureBoxNewGame.Size = new System.Drawing.Size(140, 18);
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
            this.pictureBoxSelectField.Image = global::PegSolitaire.Images.SelectField;
            this.pictureBoxSelectField.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxSelectField.Location = new System.Drawing.Point(3, 83);
            this.pictureBoxSelectField.Name = "pictureBoxSelectField";
            this.pictureBoxSelectField.Size = new System.Drawing.Size(140, 18);
            this.pictureBoxSelectField.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxSelectField.TabIndex = 2;
            this.pictureBoxSelectField.TabStop = false;
            this.pictureBoxSelectField.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxSelectField.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // pictureBoxExit
            // 
            this.pictureBoxExit.BackColor = System.Drawing.Color.Transparent;
            this.pictureBoxExit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxExit.Image = global::PegSolitaire.Images.Exit;
            this.pictureBoxExit.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.pictureBoxExit.Location = new System.Drawing.Point(3, 107);
            this.pictureBoxExit.Name = "pictureBoxExit";
            this.pictureBoxExit.Size = new System.Drawing.Size(140, 18);
            this.pictureBoxExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxExit.TabIndex = 3;
            this.pictureBoxExit.TabStop = false;
            this.pictureBoxExit.Click += new System.EventHandler(this.PictureBoxExit_Click);
            this.pictureBoxExit.MouseEnter += new System.EventHandler(this.PictureBox_MouseEnter);
            this.pictureBoxExit.MouseLeave += new System.EventHandler(this.PictureBox_MouseLeave);
            // 
            // Title
            // 
            this.Title.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title.Image = global::PegSolitaire.Images.PegSolitaire;
            this.Title.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.Title.Location = new System.Drawing.Point(3, 3);
            this.Title.Name = "Title";
            this.Title.Size = new System.Drawing.Size(254, 51);
            this.Title.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Title.TabIndex = 1;
            this.Title.TabStop = false;
            // 
            // Title1
            // 
            this.Title1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Title1.Image = global::PegSolitaire.Images.PegSolitaire;
            this.Title1.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Default;
            this.Title1.Location = new System.Drawing.Point(3, 3);
            this.Title1.Name = "Title1";
            this.Title1.Size = new System.Drawing.Size(254, 51);
            this.Title1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.Title1.TabIndex = 1;
            this.Title1.TabStop = false;
            // 
            // gamePanel
            // 
            this.gamePanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gamePanel.BackColor = System.Drawing.Color.Black;
            this.gamePanel.Controls.Add(this.tableLayoutPanelGame);
            this.gamePanel.Enabled = false;
            this.gamePanel.Location = new System.Drawing.Point(12, 12);
            this.gamePanel.Name = "gamePanel";
            this.gamePanel.Size = new System.Drawing.Size(260, 230);
            this.gamePanel.TabIndex = 1;
            // 
            // tableLayoutPanelGame
            // 
            this.tableLayoutPanelGame.ColumnCount = 1;
            this.tableLayoutPanelGame.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelGame.Controls.Add(this.Title1, 0, 0);
            this.tableLayoutPanelGame.Controls.Add(this.pictureBox1, 0, 1);
            this.tableLayoutPanelGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelGame.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanelGame.Name = "tableLayoutPanelGame";
            this.tableLayoutPanelGame.RowCount = 2;
            this.tableLayoutPanelGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelGame.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 75F));
            this.tableLayoutPanelGame.Size = new System.Drawing.Size(260, 230);
            this.tableLayoutPanelGame.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Location = new System.Drawing.Point(3, 60);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(254, 167);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.SizeChanged += new System.EventHandler(this.PictureBox1_SizeChanged);
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseClick);
            // 
            // GameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.panelMenu);
            this.Controls.Add(this.gamePanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "GameWindow";
            this.Text = "Peg Solitaire";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.GameWindow_KeyPress);
            this.panelMenu.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlay)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxNewGame)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxSelectField)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Title)).EndInit();
            this.gamePanel.ResumeLayout(false);
            this.tableLayoutPanelGame.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel gamePanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelGame;

        private PictureBoxWithInterpolationMode pictureBoxPlay;
        private PictureBoxWithInterpolationMode pictureBoxNewGame;
        private PictureBoxWithInterpolationMode pictureBoxSelectField;
        private PictureBoxWithInterpolationMode pictureBoxExit;
        private PictureBoxWithInterpolationMode Title;
        private PictureBoxWithInterpolationMode Title1;
    }
}


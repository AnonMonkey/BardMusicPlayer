﻿
namespace FFBardMusicPlayerInit
{
    partial class BmpUpdate
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
            this.progress_bar = new System.Windows.Forms.ProgressBar();
            this.progress_text = new System.Windows.Forms.Label();
            this.IconPicture = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.IconPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // progress_bar
            // 
            this.progress_bar.Location = new System.Drawing.Point(103, 74);
            this.progress_bar.Name = "progress_bar";
            this.progress_bar.Size = new System.Drawing.Size(156, 23);
            this.progress_bar.TabIndex = 9;
            // 
            // progress_text
            // 
            this.progress_text.AutoSize = true;
            this.progress_text.Location = new System.Drawing.Point(103, 35);
            this.progress_text.Name = "progress_text";
            this.progress_text.Size = new System.Drawing.Size(116, 15);
            this.progress_text.TabIndex = 10;
            this.progress_text.Text = "Download Updates...";
            // 
            // IconPicture
            // 
            this.IconPicture.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.IconPicture.BackgroundImage = global::FFBardMusicPlayerInit.Properties.Resources.bmp_icon_3;
            this.IconPicture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.IconPicture.Location = new System.Drawing.Point(9, 9);
            this.IconPicture.Margin = new System.Windows.Forms.Padding(0);
            this.IconPicture.Name = "IconPicture";
            this.IconPicture.Size = new System.Drawing.Size(91, 88);
            this.IconPicture.TabIndex = 4;
            this.IconPicture.TabStop = false;
            // 
            // BmpUpdate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(271, 110);
            this.Controls.Add(this.progress_text);
            this.Controls.Add(this.progress_bar);
            this.Controls.Add(this.IconPicture);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BmpUpdate";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bard Music Player Updater";
            ((System.ComponentModel.ISupportInitialize)(this.IconPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox IconPicture;
        private System.Windows.Forms.ProgressBar progress_bar;
        private System.Windows.Forms.Label progress_text;
    }
}

namespace GK3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.mainPicture = new System.Windows.Forms.PictureBox();
            this.afterPicture = new System.Windows.Forms.PictureBox();
            this.alongPicture = new System.Windows.Forms.PictureBox();
            this.afterProgress = new System.Windows.Forms.ProgressBar();
            this.alongProgress = new System.Windows.Forms.ProgressBar();
            this.colorsTrackBar = new System.Windows.Forms.TrackBar();
            this.reduceButton = new System.Windows.Forms.Button();
            this.grayscaleButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alongPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorsTrackBar)).BeginInit();
            this.SuspendLayout();
            // 
            // mainPicture
            // 
            this.mainPicture.Location = new System.Drawing.Point(12, 12);
            this.mainPicture.Name = "mainPicture";
            this.mainPicture.Size = new System.Drawing.Size(980, 512);
            this.mainPicture.TabIndex = 0;
            this.mainPicture.TabStop = false;
            // 
            // afterPicture
            // 
            this.afterPicture.Location = new System.Drawing.Point(1061, 27);
            this.afterPicture.Name = "afterPicture";
            this.afterPicture.Size = new System.Drawing.Size(450, 344);
            this.afterPicture.TabIndex = 1;
            this.afterPicture.TabStop = false;
            // 
            // alongPicture
            // 
            this.alongPicture.Location = new System.Drawing.Point(1061, 476);
            this.alongPicture.Name = "alongPicture";
            this.alongPicture.Size = new System.Drawing.Size(450, 344);
            this.alongPicture.TabIndex = 2;
            this.alongPicture.TabStop = false;
            // 
            // afterProgress
            // 
            this.afterProgress.Location = new System.Drawing.Point(1061, 396);
            this.afterProgress.Name = "afterProgress";
            this.afterProgress.Size = new System.Drawing.Size(450, 29);
            this.afterProgress.TabIndex = 3;
            // 
            // alongProgress
            // 
            this.alongProgress.Location = new System.Drawing.Point(1061, 850);
            this.alongProgress.Name = "alongProgress";
            this.alongProgress.Size = new System.Drawing.Size(450, 29);
            this.alongProgress.TabIndex = 4;
            // 
            // colorsTrackBar
            // 
            this.colorsTrackBar.Location = new System.Drawing.Point(12, 563);
            this.colorsTrackBar.Maximum = 256;
            this.colorsTrackBar.Minimum = 1;
            this.colorsTrackBar.Name = "colorsTrackBar";
            this.colorsTrackBar.Size = new System.Drawing.Size(980, 56);
            this.colorsTrackBar.TabIndex = 5;
            this.colorsTrackBar.Value = 8;
            this.colorsTrackBar.Scroll += new System.EventHandler(this.colorsTrackBar_Scroll);
            // 
            // reduceButton
            // 
            this.reduceButton.Location = new System.Drawing.Point(86, 638);
            this.reduceButton.Name = "reduceButton";
            this.reduceButton.Size = new System.Drawing.Size(221, 53);
            this.reduceButton.TabIndex = 6;
            this.reduceButton.Text = "Reduce to N Colors";
            this.reduceButton.UseVisualStyleBackColor = true;
            this.reduceButton.Click += new System.EventHandler(this.reduceButton_Click);
            // 
            // grayscaleButton
            // 
            this.grayscaleButton.Location = new System.Drawing.Point(86, 731);
            this.grayscaleButton.Name = "grayscaleButton";
            this.grayscaleButton.Size = new System.Drawing.Size(221, 52);
            this.grayscaleButton.TabIndex = 7;
            this.grayscaleButton.Text = "To Greyscale";
            this.grayscaleButton.UseVisualStyleBackColor = true;
            this.grayscaleButton.Click += new System.EventHandler(this.grayscaleButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(729, 731);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(106, 52);
            this.saveButton.TabIndex = 8;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(729, 639);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(106, 52);
            this.loadButton.TabIndex = 9;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.loadButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1582, 953);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.grayscaleButton);
            this.Controls.Add(this.reduceButton);
            this.Controls.Add(this.colorsTrackBar);
            this.Controls.Add(this.alongProgress);
            this.Controls.Add(this.afterProgress);
            this.Controls.Add(this.alongPicture);
            this.Controls.Add(this.afterPicture);
            this.Controls.Add(this.mainPicture);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.mainPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.afterPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alongPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorsTrackBar)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox mainPicture;
        private System.Windows.Forms.PictureBox afterPicture;
        private System.Windows.Forms.PictureBox alongPicture;
        private System.Windows.Forms.ProgressBar afterProgress;
        private System.Windows.Forms.ProgressBar alongProgress;
        private System.Windows.Forms.TrackBar colorsTrackBar;
        private System.Windows.Forms.Button reduceButton;
        private System.Windows.Forms.Button grayscaleButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
    }
}


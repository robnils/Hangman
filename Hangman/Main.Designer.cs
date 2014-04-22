namespace Hangman
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.buttonNew = new System.Windows.Forms.Button();
            this.richTextBoxDisplay = new System.Windows.Forms.RichTextBox();
            this.richTextBoxEntry = new System.Windows.Forms.RichTextBox();
            this.buttonExit = new System.Windows.Forms.Button();
            this.textBoxAlreadyGuessed = new System.Windows.Forms.TextBox();
            this.richTextBoxLives = new System.Windows.Forms.RichTextBox();
            this.buttonWord = new System.Windows.Forms.Button();
            this.radioButtonEasy = new System.Windows.Forms.RadioButton();
            this.radioButtonMedium = new System.Windows.Forms.RadioButton();
            this.radioButtonHard = new System.Windows.Forms.RadioButton();
            this.radioButtonRandom = new System.Windows.Forms.RadioButton();
            this.radioButtonCountries = new System.Windows.Forms.RadioButton();
            this.groupBoxDifficulty = new System.Windows.Forms.GroupBox();
            this.groupBoxWordlists = new System.Windows.Forms.GroupBox();
            this.radioButtonCountriesSwe = new System.Windows.Forms.RadioButton();
            this.radioButtonRandomSwe = new System.Windows.Forms.RadioButton();
            this.richTextBoxGuessed = new System.Windows.Forms.RichTextBox();
            this.buttonAbout = new System.Windows.Forms.Button();
            this.groupBoxDifficulty.SuspendLayout();
            this.groupBoxWordlists.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonNew
            // 
            this.buttonNew.Location = new System.Drawing.Point(20, 12);
            this.buttonNew.Name = "buttonNew";
            this.buttonNew.Size = new System.Drawing.Size(135, 38);
            this.buttonNew.TabIndex = 31;
            this.buttonNew.Text = "New Game";
            this.buttonNew.UseVisualStyleBackColor = true;
            this.buttonNew.Click += new System.EventHandler(this.button7_Click);
            this.buttonNew.Paint += new System.Windows.Forms.PaintEventHandler(this.Hangman_Paint);
            // 
            // richTextBoxDisplay
            // 
            this.richTextBoxDisplay.Location = new System.Drawing.Point(171, 114);
            this.richTextBoxDisplay.Multiline = false;
            this.richTextBoxDisplay.Name = "richTextBoxDisplay";
            this.richTextBoxDisplay.Size = new System.Drawing.Size(468, 69);
            this.richTextBoxDisplay.TabIndex = 38;
            this.richTextBoxDisplay.Text = "";
            this.richTextBoxDisplay.WordWrap = false;
            // 
            // richTextBoxEntry
            // 
            this.richTextBoxEntry.Location = new System.Drawing.Point(301, 213);
            this.richTextBoxEntry.Name = "richTextBoxEntry";
            this.richTextBoxEntry.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.None;
            this.richTextBoxEntry.Size = new System.Drawing.Size(188, 53);
            this.richTextBoxEntry.TabIndex = 39;
            this.richTextBoxEntry.Text = "";
            this.richTextBoxEntry.TextChanged += new System.EventHandler(this.richTextBoxEntry_TextChanged);
            this.richTextBoxEntry.KeyDown += new System.Windows.Forms.KeyEventHandler(this.richTextBoxEntry_KeyDown);
            this.richTextBoxEntry.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.richTextBoxEntry_KeyPress);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(100, 56);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(55, 38);
            this.buttonExit.TabIndex = 40;
            this.buttonExit.Text = "Exit";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // textBoxAlreadyGuessed
            // 
            this.textBoxAlreadyGuessed.Location = new System.Drawing.Point(301, 187);
            this.textBoxAlreadyGuessed.Name = "textBoxAlreadyGuessed";
            this.textBoxAlreadyGuessed.Size = new System.Drawing.Size(188, 20);
            this.textBoxAlreadyGuessed.TabIndex = 45;
            // 
            // richTextBoxLives
            // 
            this.richTextBoxLives.Location = new System.Drawing.Point(20, 114);
            this.richTextBoxLives.Name = "richTextBoxLives";
            this.richTextBoxLives.Size = new System.Drawing.Size(135, 128);
            this.richTextBoxLives.TabIndex = 46;
            this.richTextBoxLives.Text = "";
            // 
            // buttonWord
            // 
            this.buttonWord.Location = new System.Drawing.Point(466, 20);
            this.buttonWord.Name = "buttonWord";
            this.buttonWord.Size = new System.Drawing.Size(23, 38);
            this.buttonWord.TabIndex = 47;
            this.buttonWord.Text = "Add Custom Wordlist...";
            this.buttonWord.UseVisualStyleBackColor = true;
            // 
            // radioButtonEasy
            // 
            this.radioButtonEasy.AutoSize = true;
            this.radioButtonEasy.Location = new System.Drawing.Point(11, 19);
            this.radioButtonEasy.Name = "radioButtonEasy";
            this.radioButtonEasy.Size = new System.Drawing.Size(87, 17);
            this.radioButtonEasy.TabIndex = 48;
            this.radioButtonEasy.TabStop = true;
            this.radioButtonEasy.Text = "Easy (9 lives)";
            this.radioButtonEasy.UseVisualStyleBackColor = true;
            this.radioButtonEasy.CheckedChanged += new System.EventHandler(this.radioButtonEasy_CheckedChanged);
            // 
            // radioButtonMedium
            // 
            this.radioButtonMedium.AutoSize = true;
            this.radioButtonMedium.Location = new System.Drawing.Point(11, 42);
            this.radioButtonMedium.Name = "radioButtonMedium";
            this.radioButtonMedium.Size = new System.Drawing.Size(101, 17);
            this.radioButtonMedium.TabIndex = 49;
            this.radioButtonMedium.TabStop = true;
            this.radioButtonMedium.Text = "Medium (6 lives)";
            this.radioButtonMedium.UseVisualStyleBackColor = true;
            this.radioButtonMedium.CheckedChanged += new System.EventHandler(this.radioButtonMedium_CheckedChanged);
            // 
            // radioButtonHard
            // 
            this.radioButtonHard.AutoSize = true;
            this.radioButtonHard.Location = new System.Drawing.Point(11, 65);
            this.radioButtonHard.Name = "radioButtonHard";
            this.radioButtonHard.Size = new System.Drawing.Size(87, 17);
            this.radioButtonHard.TabIndex = 50;
            this.radioButtonHard.TabStop = true;
            this.radioButtonHard.Text = "Hard (4 lives)";
            this.radioButtonHard.UseVisualStyleBackColor = true;
            this.radioButtonHard.CheckedChanged += new System.EventHandler(this.radioButtonHard_CheckedChanged);
            // 
            // radioButtonRandom
            // 
            this.radioButtonRandom.AutoSize = true;
            this.radioButtonRandom.Location = new System.Drawing.Point(9, 14);
            this.radioButtonRandom.Name = "radioButtonRandom";
            this.radioButtonRandom.Size = new System.Drawing.Size(108, 17);
            this.radioButtonRandom.TabIndex = 53;
            this.radioButtonRandom.TabStop = true;
            this.radioButtonRandom.Text = "Random (English)";
            this.radioButtonRandom.UseVisualStyleBackColor = true;
            this.radioButtonRandom.CheckedChanged += new System.EventHandler(this.radioButtonRandom_CheckedChanged);
            // 
            // radioButtonCountries
            // 
            this.radioButtonCountries.AutoSize = true;
            this.radioButtonCountries.Location = new System.Drawing.Point(136, 14);
            this.radioButtonCountries.Name = "radioButtonCountries";
            this.radioButtonCountries.Size = new System.Drawing.Size(112, 17);
            this.radioButtonCountries.TabIndex = 54;
            this.radioButtonCountries.TabStop = true;
            this.radioButtonCountries.Text = "Countries (English)";
            this.radioButtonCountries.UseVisualStyleBackColor = true;
            this.radioButtonCountries.CheckedChanged += new System.EventHandler(this.radioButtonCountries_CheckedChanged);
            // 
            // groupBoxDifficulty
            // 
            this.groupBoxDifficulty.Controls.Add(this.radioButtonHard);
            this.groupBoxDifficulty.Controls.Add(this.radioButtonEasy);
            this.groupBoxDifficulty.Controls.Add(this.radioButtonMedium);
            this.groupBoxDifficulty.Location = new System.Drawing.Point(508, 12);
            this.groupBoxDifficulty.Name = "groupBoxDifficulty";
            this.groupBoxDifficulty.Size = new System.Drawing.Size(131, 96);
            this.groupBoxDifficulty.TabIndex = 55;
            this.groupBoxDifficulty.TabStop = false;
            this.groupBoxDifficulty.Text = "Difficulty";
            // 
            // groupBoxWordlists
            // 
            this.groupBoxWordlists.Controls.Add(this.radioButtonCountriesSwe);
            this.groupBoxWordlists.Controls.Add(this.radioButtonRandomSwe);
            this.groupBoxWordlists.Controls.Add(this.radioButtonCountries);
            this.groupBoxWordlists.Controls.Add(this.radioButtonRandom);
            this.groupBoxWordlists.Location = new System.Drawing.Point(171, 14);
            this.groupBoxWordlists.Name = "groupBoxWordlists";
            this.groupBoxWordlists.Size = new System.Drawing.Size(274, 61);
            this.groupBoxWordlists.TabIndex = 56;
            this.groupBoxWordlists.TabStop = false;
            this.groupBoxWordlists.Text = "Wordlists";
            // 
            // radioButtonCountriesSwe
            // 
            this.radioButtonCountriesSwe.AutoSize = true;
            this.radioButtonCountriesSwe.Location = new System.Drawing.Point(136, 31);
            this.radioButtonCountriesSwe.Name = "radioButtonCountriesSwe";
            this.radioButtonCountriesSwe.Size = new System.Drawing.Size(118, 17);
            this.radioButtonCountriesSwe.TabIndex = 56;
            this.radioButtonCountriesSwe.TabStop = true;
            this.radioButtonCountriesSwe.Text = "Countries (Swedish)";
            this.radioButtonCountriesSwe.UseVisualStyleBackColor = true;
            this.radioButtonCountriesSwe.CheckedChanged += new System.EventHandler(this.radioButtonCountriesSwe_CheckedChanged);
            // 
            // radioButtonRandomSwe
            // 
            this.radioButtonRandomSwe.AutoSize = true;
            this.radioButtonRandomSwe.Location = new System.Drawing.Point(9, 31);
            this.radioButtonRandomSwe.Name = "radioButtonRandomSwe";
            this.radioButtonRandomSwe.Size = new System.Drawing.Size(114, 17);
            this.radioButtonRandomSwe.TabIndex = 55;
            this.radioButtonRandomSwe.TabStop = true;
            this.radioButtonRandomSwe.Text = "Random (Swedish)";
            this.radioButtonRandomSwe.UseVisualStyleBackColor = true;
            this.radioButtonRandomSwe.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // richTextBoxGuessed
            // 
            this.richTextBoxGuessed.Location = new System.Drawing.Point(20, 272);
            this.richTextBoxGuessed.Name = "richTextBoxGuessed";
            this.richTextBoxGuessed.Size = new System.Drawing.Size(626, 117);
            this.richTextBoxGuessed.TabIndex = 51;
            this.richTextBoxGuessed.Text = "";
            // 
            // buttonAbout
            // 
            this.buttonAbout.Location = new System.Drawing.Point(20, 56);
            this.buttonAbout.Name = "buttonAbout";
            this.buttonAbout.Size = new System.Drawing.Size(74, 38);
            this.buttonAbout.TabIndex = 57;
            this.buttonAbout.Text = "About";
            this.buttonAbout.UseVisualStyleBackColor = true;
            this.buttonAbout.Click += new System.EventHandler(this.buttonAbout_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(677, 394);
            this.Controls.Add(this.buttonAbout);
            this.Controls.Add(this.groupBoxWordlists);
            this.Controls.Add(this.groupBoxDifficulty);
            this.Controls.Add(this.richTextBoxGuessed);
            this.Controls.Add(this.buttonWord);
            this.Controls.Add(this.richTextBoxLives);
            this.Controls.Add(this.textBoxAlreadyGuessed);
            this.Controls.Add(this.buttonExit);
            this.Controls.Add(this.richTextBoxEntry);
            this.Controls.Add(this.richTextBoxDisplay);
            this.Controls.Add(this.buttonNew);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Main";
            this.Text = "HangMania v.0.2";
            this.Load += new System.EventHandler(this.Hangman_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Hangman_Paint);
            this.groupBoxDifficulty.ResumeLayout(false);
            this.groupBoxDifficulty.PerformLayout();
            this.groupBoxWordlists.ResumeLayout(false);
            this.groupBoxWordlists.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonNew;
        private System.Windows.Forms.RichTextBox richTextBoxDisplay;
        private System.Windows.Forms.RichTextBox richTextBoxEntry;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.TextBox textBoxAlreadyGuessed;
        private System.Windows.Forms.RichTextBox richTextBoxLives;
        private System.Windows.Forms.Button buttonWord;
        private System.Windows.Forms.RadioButton radioButtonEasy;
        private System.Windows.Forms.RadioButton radioButtonMedium;
        private System.Windows.Forms.RadioButton radioButtonHard;
        private System.Windows.Forms.RadioButton radioButtonRandom;
        private System.Windows.Forms.RadioButton radioButtonCountries;
        private System.Windows.Forms.GroupBox groupBoxDifficulty;
        private System.Windows.Forms.GroupBox groupBoxWordlists;
        private System.Windows.Forms.RadioButton radioButtonCountriesSwe;
        private System.Windows.Forms.RadioButton radioButtonRandomSwe;
        private System.Windows.Forms.RichTextBox richTextBoxGuessed;
        private System.Windows.Forms.Button buttonAbout;
    }
}


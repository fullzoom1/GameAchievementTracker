namespace PROEKT2
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.ListBox listBoxGames;
        private System.Windows.Forms.DataGridView dgvAchievements;
        private System.Windows.Forms.Label lblGameTitle;
        private System.Windows.Forms.ProgressBar progressBarProgress;
        private System.Windows.Forms.Label lblProgressPercent;
        private System.Windows.Forms.Button btnToggleAchievement;
        private System.Windows.Forms.Button btnAddGame;
        private System.Windows.Forms.Button btnAddAchievement;
        private System.Windows.Forms.Button btnPlayGame;
        private System.Windows.Forms.Label lblTimePlayed;
        private System.Windows.Forms.Timer gameTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBoxGames = new System.Windows.Forms.ListBox();
            this.dgvAchievements = new System.Windows.Forms.DataGridView();
            this.lblGameTitle = new System.Windows.Forms.Label();
            this.progressBarProgress = new System.Windows.Forms.ProgressBar();
            this.lblProgressPercent = new System.Windows.Forms.Label();
            this.btnToggleAchievement = new System.Windows.Forms.Button();
            this.btnAddGame = new System.Windows.Forms.Button();
            this.btnAddAchievement = new System.Windows.Forms.Button();
            this.btnPlayGame = new System.Windows.Forms.Button();
            this.lblTimePlayed = new System.Windows.Forms.Label();
            this.gameTimer = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).BeginInit();
            this.SuspendLayout();
            // 
            // listBoxGames
            // 
            this.listBoxGames.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.listBoxGames.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.listBoxGames.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.listBoxGames.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(210)))), ((int)(((byte)(215)))), ((int)(((byte)(225)))));
            this.listBoxGames.FormattingEnabled = true;
            this.listBoxGames.ItemHeight = 17;
            this.listBoxGames.Location = new System.Drawing.Point(9, 10);
            this.listBoxGames.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBoxGames.Name = "listBoxGames";
            this.listBoxGames.Size = new System.Drawing.Size(165, 272);
            this.listBoxGames.TabIndex = 0;
            // 
            // dgvAchievements
            // 
            this.dgvAchievements.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.dgvAchievements.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvAchievements.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAchievements.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(38)))), ((int)(((byte)(45)))), ((int)(((byte)(64)))));
            this.dgvAchievements.Location = new System.Drawing.Point(190, 61);
            this.dgvAchievements.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvAchievements.Name = "dgvAchievements";
            this.dgvAchievements.RowHeadersWidth = 51;
            this.dgvAchievements.RowTemplate.Height = 35;
            this.dgvAchievements.Size = new System.Drawing.Size(451, 203);
            this.dgvAchievements.TabIndex = 1;
            // 
            // lblGameTitle
            // 
            this.lblGameTitle.AutoSize = true;
            this.lblGameTitle.Font = new System.Drawing.Font("Segoe UI Semibold", 16F, System.Drawing.FontStyle.Bold);
            this.lblGameTitle.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.lblGameTitle.Location = new System.Drawing.Point(186, 10);
            this.lblGameTitle.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblGameTitle.Name = "lblGameTitle";
            this.lblGameTitle.Size = new System.Drawing.Size(181, 30);
            this.lblGameTitle.TabIndex = 2;
            this.lblGameTitle.Text = "Выберите игру...";
            // 
            // progressBarProgress
            // 
            this.progressBarProgress.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(29)))), ((int)(((byte)(41)))));
            this.progressBarProgress.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.progressBarProgress.Location = new System.Drawing.Point(190, 272);
            this.progressBarProgress.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.progressBarProgress.Name = "progressBarProgress";
            this.progressBarProgress.Size = new System.Drawing.Size(262, 19);
            this.progressBarProgress.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarProgress.TabIndex = 3;
            // 
            // lblProgressPercent
            // 
            this.lblProgressPercent.AutoSize = true;
            this.lblProgressPercent.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblProgressPercent.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(180)))), ((int)(((byte)(200)))));
            this.lblProgressPercent.Location = new System.Drawing.Point(461, 272);
            this.lblProgressPercent.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblProgressPercent.Name = "lblProgressPercent";
            this.lblProgressPercent.Size = new System.Drawing.Size(113, 19);
            this.lblProgressPercent.TabIndex = 4;
            this.lblProgressPercent.Text = "Достижений нет";
            // 
            // btnToggleAchievement
            // 
            this.btnToggleAchievement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnToggleAchievement.FlatAppearance.BorderSize = 0;
            this.btnToggleAchievement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnToggleAchievement.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnToggleAchievement.ForeColor = System.Drawing.Color.White;
            this.btnToggleAchievement.Location = new System.Drawing.Point(190, 305);
            this.btnToggleAchievement.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnToggleAchievement.Name = "btnToggleAchievement";
            this.btnToggleAchievement.Size = new System.Drawing.Size(120, 37);
            this.btnToggleAchievement.TabIndex = 5;
            this.btnToggleAchievement.Text = "Переключить статус";
            this.btnToggleAchievement.UseVisualStyleBackColor = false;
            // 
            // btnAddGame
            // 
            this.btnAddGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnAddGame.FlatAppearance.BorderSize = 0;
            this.btnAddGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddGame.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddGame.ForeColor = System.Drawing.Color.White;
            this.btnAddGame.Location = new System.Drawing.Point(9, 313);
            this.btnAddGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddGame.Name = "btnAddGame";
            this.btnAddGame.Size = new System.Drawing.Size(165, 28);
            this.btnAddGame.TabIndex = 6;
            this.btnAddGame.Text = "➕ Добавить игру";
            this.btnAddGame.UseVisualStyleBackColor = false;
            // 
            // btnAddAchievement
            // 
            this.btnAddAchievement.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(42)))), ((int)(((byte)(61)))));
            this.btnAddAchievement.FlatAppearance.BorderSize = 0;
            this.btnAddAchievement.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddAchievement.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnAddAchievement.ForeColor = System.Drawing.Color.White;
            this.btnAddAchievement.Location = new System.Drawing.Point(315, 305);
            this.btnAddAchievement.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnAddAchievement.Name = "btnAddAchievement";
            this.btnAddAchievement.Size = new System.Drawing.Size(120, 37);
            this.btnAddAchievement.TabIndex = 7;
            this.btnAddAchievement.Text = "➕ Создать ачивку";
            this.btnAddAchievement.UseVisualStyleBackColor = false;
            // 
            // btnPlayGame
            // 
            this.btnPlayGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(98)))), ((int)(((byte)(255)))));
            this.btnPlayGame.FlatAppearance.BorderSize = 0;
            this.btnPlayGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPlayGame.Font = new System.Drawing.Font("Segoe UI Semibold", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnPlayGame.ForeColor = System.Drawing.Color.White;
            this.btnPlayGame.Location = new System.Drawing.Point(442, 305);
            this.btnPlayGame.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnPlayGame.Name = "btnPlayGame";
            this.btnPlayGame.Size = new System.Drawing.Size(135, 37);
            this.btnPlayGame.TabIndex = 8;
            this.btnPlayGame.Text = "Запустить игру (Таймер)";
            this.btnPlayGame.UseVisualStyleBackColor = false;
            // 
            // lblTimePlayed
            // 
            this.lblTimePlayed.AutoSize = true;
            this.lblTimePlayed.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblTimePlayed.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(130)))), ((int)(((byte)(140)))), ((int)(((byte)(160)))));
            this.lblTimePlayed.Location = new System.Drawing.Point(188, 40);
            this.lblTimePlayed.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTimePlayed.Name = "lblTimePlayed";
            this.lblTimePlayed.Size = new System.Drawing.Size(163, 19);
            this.lblTimePlayed.TabIndex = 9;
            this.lblTimePlayed.Text = "⏱ Время в игре: 0 мин.";
            // 
            // gameTimer
            // 
            this.gameTimer.Interval = 1000;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(18)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(648, 358);
            this.Controls.Add(this.lblTimePlayed);
            this.Controls.Add(this.btnPlayGame);
            this.Controls.Add(this.btnAddAchievement);
            this.Controls.Add(this.btnAddGame);
            this.Controls.Add(this.lblProgressPercent);
            this.Controls.Add(this.progressBarProgress);
            this.Controls.Add(this.lblGameTitle);
            this.Controls.Add(this.dgvAchievements);
            this.Controls.Add(this.listBoxGames);
            this.Controls.Add(this.btnToggleAchievement);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(225)))), ((int)(((byte)(235)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Менеджер игровых достижений";
            ((System.ComponentModel.ISupportInitialize)(this.dgvAchievements)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion
    }
}
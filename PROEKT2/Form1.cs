using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Windows.Forms;

namespace PROEKT2
{
    public partial class Form1 : Form
    {
        private readonly string connectionString = "Server=localhost\\SQLEXPRESS;Database=GameAchievementDB;Trusted_Connection=True;TrustServerCertificate=True;";
        private List<Game> _games = new List<Game>();

        public Form1()
        {
            InitializeComponent();
            ApplyCustomGamingDesign();
            SetupComponents();
            LoadGamesFromDb();
        }

        private void ApplyCustomGamingDesign()
        {
            this.BackColor = Color.FromArgb(15, 18, 26);
            this.ForeColor = Color.FromArgb(220, 225, 235);

            Font primaryFont = new Font("Segoe UI", 10F, FontStyle.Regular);
            Font titleFont = new Font("Segoe UI Semibold", 16F, FontStyle.Bold);

            listBoxGames.BackColor = Color.FromArgb(24, 29, 41);
            listBoxGames.ForeColor = Color.FromArgb(210, 215, 225);
            listBoxGames.Font = primaryFont;
            listBoxGames.BorderStyle = BorderStyle.None;

            lblGameTitle.Font = titleFont;
            lblGameTitle.ForeColor = Color.FromArgb(74, 144, 226);
            lblTimePlayed.Font = primaryFont;
            lblTimePlayed.ForeColor = Color.FromArgb(130, 140, 160);
            lblProgressPercent.Font = primaryFont;

            StyleGamingButton(btnAddGame, Color.FromArgb(32, 42, 61));
            StyleGamingButton(btnToggleAchievement, Color.FromArgb(32, 42, 61));
            StyleGamingButton(btnAddAchievement, Color.FromArgb(32, 42, 61));
            StyleGamingButton(btnPlayGame, Color.FromArgb(41, 98, 255));

            dgvAchievements.BackgroundColor = Color.FromArgb(24, 29, 41);
            dgvAchievements.ForeColor = Color.FromArgb(210, 215, 225);
            dgvAchievements.GridColor = Color.FromArgb(38, 45, 64);
            dgvAchievements.BorderStyle = BorderStyle.None;
            dgvAchievements.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgvAchievements.RowHeadersVisible = false;

            dgvAchievements.EnableHeadersVisualStyles = false;
            dgvAchievements.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(32, 42, 61);
            dgvAchievements.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(180, 190, 210);
            dgvAchievements.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            dgvAchievements.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dgvAchievements.ColumnHeadersHeight = 35;

            dgvAchievements.DefaultCellStyle.BackColor = Color.FromArgb(24, 29, 41);
            dgvAchievements.DefaultCellStyle.ForeColor = Color.FromArgb(210, 215, 225);
            dgvAchievements.DefaultCellStyle.SelectionBackColor = Color.FromArgb(46, 75, 145);
            dgvAchievements.DefaultCellStyle.SelectionForeColor = Color.White;
            dgvAchievements.RowTemplate.Height = 35;

            
            progressBarProgress.Style = ProgressBarStyle.Continuous;
            progressBarProgress.ForeColor = Color.FromArgb(41, 98, 255);
            progressBarProgress.BackColor = Color.FromArgb(24, 29, 41);
        }

        private void StyleGamingButton(Button btn, Color baseColor)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.BackColor = baseColor;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            btn.Cursor = Cursors.Hand;

            btn.Paint += (s, e) =>
            {
                
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;

                int radius = 12;
                Rectangle bounds = new Rectangle(0, 0, btn.Width, btn.Height);
                using (GraphicsPath path = new GraphicsPath())
                {
                    path.AddArc(bounds.X, bounds.Y, radius, radius, 180, 90);
                    path.AddArc(bounds.X + bounds.Width - radius, bounds.Y, radius, radius, 270, 90);
                    path.AddArc(bounds.X + bounds.Width - radius, bounds.Y + bounds.Height - radius, radius, radius, 0, 90);
                    path.AddArc(bounds.X, bounds.Y + bounds.Height - radius, radius, radius, 90, 90);
                    path.CloseAllFigures();

                    btn.Region = new Region(path);
                }
            };
        }



        private void SetupComponents()
        {
            dgvAchievements.AutoGenerateColumns = false;
            dgvAchievements.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvAchievements.MultiSelect = false;
            dgvAchievements.ReadOnly = true;

            dgvAchievements.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Name", HeaderText = " Достижение", Width = 140 });
            dgvAchievements.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Description", HeaderText = " Описание", Width = 230 });
            dgvAchievements.Columns.Add(new DataGridViewCheckBoxColumn { DataPropertyName = "IsUnlocked", HeaderText = " Статус", Width = 70 });

            listBoxGames.SelectedIndexChanged += ListBoxGames_SelectedIndexChanged;
            btnToggleAchievement.Click += BtnToggleAchievement_Click;
            btnAddGame.Click += BtnAddGame_Click;
            btnAddAchievement.Click += BtnAddAchievement_Click;
            btnPlayGame.Click += BtnPlayGame_Click;
            gameTimer.Tick += GameTimer_Tick;

            
            progressBarProgress.Style = ProgressBarStyle.Marquee; 
            progressBarProgress.Style = ProgressBarStyle.Continuous;
            progressBarProgress.ForeColor = Color.FromArgb(41, 98, 255); 
            progressBarProgress.BackColor = Color.FromArgb(24, 29, 41);    

            
            progressBarProgress.Paint += ProgressBarProgress_Paint;

        }

        private void ProgressBarProgress_Paint(object sender, PaintEventArgs e)
        {
            ProgressBar pb = (ProgressBar)sender;
            Rectangle rect = pb.ClientRectangle;

            
            e.Graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighQuality;

            
            using (Brush backBrush = new SolidBrush(Color.FromArgb(24, 29, 41)))
            {
                e.Graphics.FillRectangle(backBrush, rect);
            }

            if (pb.Maximum > 0 && pb.Value > 0)
            {
                double scale = (double)pb.Value / pb.Maximum;
                int fillWidth = (int)(rect.Width * scale);

                if (fillWidth > 0)
                {
                    Rectangle fillRect = new Rectangle(0, 0, fillWidth, rect.Height);

                    
                    Color fillValidColor = (pb.Value == pb.Maximum) ? Color.FromArgb(255, 200, 50) : Color.FromArgb(41, 98, 255);

                    using (Brush fillBrush = new SolidBrush(fillValidColor))
                    {
                        e.Graphics.FillRectangle(fillBrush, fillRect);
                    }
                }
            }
        }

        private void LoadGamesFromDb()
        {
            _games.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string gameQuery = "SELECT Id, Title, Platform, TimePlayedMinutes FROM Games";
                using (SqlCommand cmd = new SqlCommand(gameQuery, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _games.Add(new Game
                        {
                            Id = reader.GetInt32(0),
                            Title = reader.GetString(1),
                            Platform = reader.GetString(2),
                            TimePlayedMinutes = reader.GetInt32(3),
                            Achievements = new List<Achievement>()
                        });
                    }
                }

                string achQuery = "SELECT Id, GameId, Name, Description, IsUnlocked, IsTimeBased, RequiredMinutes FROM Achievements";
                using (SqlCommand cmd = new SqlCommand(achQuery, conn))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int gameId = reader.GetInt32(1);
                        var targetGame = _games.FirstOrDefault(g => g.Id == gameId);
                        if (targetGame != null)
                        {
                            targetGame.Achievements.Add(new Achievement
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(2),
                                Description = reader.GetString(3),
                                IsUnlocked = reader.GetBoolean(4),
                                IsTimeBased = reader.GetBoolean(5),
                                RequiredMinutes = reader.GetInt32(6)
                            });
                        }
                    }
                }
            }
            LoadGames();
        }

        private void LoadGames()
        {
            listBoxGames.DataSource = null;
            listBoxGames.DataSource = _games;
            listBoxGames.DisplayMember = "Title";
        }

        private void ListBoxGames_SelectedIndexChanged(object sender, EventArgs e)
        {
            gameTimer.Stop();
            btnPlayGame.Text = "Запустить игру (Таймер)";
            btnPlayGame.BackColor = Color.FromArgb(41, 98, 255);
            UpdateGameDetails();
        }

        private void UpdateGameDetails()
        {
            if (listBoxGames.SelectedItem is Game selectedGame)
            {
                lblGameTitle.Text = $"{selectedGame.Title} [{selectedGame.Platform}]";
                lblTimePlayed.Text = $"⏱ Время в игре: {selectedGame.TimePlayedMinutes} мин.";

                var bindingList = new BindingList<Achievement>(selectedGame.Achievements);
                int currentRowIndex = dgvAchievements.CurrentRow?.Index ?? -1;
                dgvAchievements.DataSource = bindingList;

                if (currentRowIndex >= 0 && currentRowIndex < dgvAchievements.Rows.Count)
                {
                    dgvAchievements.CurrentCell = dgvAchievements.Rows[currentRowIndex].Cells[0];
                }

                int total = selectedGame.Achievements.Count;
                int unlocked = selectedGame.Achievements.Count(a => a.IsUnlocked);

                if (total > 0)
                {
                    int percent = (int)((double)unlocked / total * 100);
                    progressBarProgress.Value = percent;

                    if (percent == 100)
                    {
                        lblProgressPercent.Text = "Выполнено 100%! Идеально";
                        lblProgressPercent.ForeColor = Color.FromArgb(255, 200, 50);
                    }
                    else
                    {
                        lblProgressPercent.Text = $"Получено: {unlocked} из {total} ({percent}%)";
                        lblProgressPercent.ForeColor = Color.FromArgb(170, 180, 200);
                    }
                }
                else
                {
                    progressBarProgress.Value = 0;
                    lblProgressPercent.Text = "Достижений нет";
                    lblProgressPercent.ForeColor = Color.FromArgb(120, 130, 150);
                }
                progressBarProgress.Invalidate();  
            }
        }

        private void BtnToggleAchievement_Click(object sender, EventArgs e)
        {
            if (dgvAchievements.CurrentRow != null && listBoxGames.SelectedItem is Game selectedGame)
            {
                var displayed = (Achievement)dgvAchievements.CurrentRow.DataBoundItem;
                var current = selectedGame.Achievements.FirstOrDefault(a => a.Id == displayed.Id);

                if (current != null)
                {
                    if (current.IsTimeBased)
                    {
                        MessageBox.Show("Это достижение зависит от времени! Оно откроется автоматически при запуске игры через таймер.", "Информация");
                        return;
                    }

                    current.IsUnlocked = !current.IsUnlocked;

                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Achievements SET IsUnlocked = @isUnlocked WHERE Id = @id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@isUnlocked", current.IsUnlocked);
                            cmd.Parameters.AddWithValue("@id", current.Id);
                            conn.Open();
                            cmd.ExecuteNonQuery();
                        }
                    }
                    UpdateGameDetails();
                }
            }
        }

        private void BtnAddGame_Click(object sender, EventArgs e)
        {
            using (var form = new AddGameForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    int newId = 0;
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "INSERT INTO Games (Title, Platform, TimePlayedMinutes) OUTPUT INSERTED.Id VALUES (@title, @platform, 0)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@title", form.GameTitle);
                            cmd.Parameters.AddWithValue("@platform", form.GamePlatform);
                            conn.Open();
                            newId = (int)cmd.ExecuteScalar();
                        }
                    }
                    _games.Add(new Game { Id = newId, Title = form.GameTitle, Platform = form.GamePlatform, TimePlayedMinutes = 0 });
                    LoadGames();
                    listBoxGames.SelectedIndex = _games.Count - 1;
                }
            }
        }

        private void BtnAddAchievement_Click(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedItem is Game selectedGame)
            {
                using (var form = new AddAchievementForm())
                {
                    if (form.ShowDialog() == DialogResult.OK)
                    {
                        int newId = 0;
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string query = "INSERT INTO Achievements (GameId, Name, Description, IsUnlocked, IsTimeBased, RequiredMinutes) OUTPUT INSERTED.Id VALUES (@gameId, @name, @desc, 0, @isTime, @reqMin)";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@gameId", selectedGame.Id);
                                cmd.Parameters.AddWithValue("@name", form.NewAchievement.Name);
                                cmd.Parameters.AddWithValue("@desc", form.NewAchievement.Description);
                                cmd.Parameters.AddWithValue("@isTime", form.NewAchievement.IsTimeBased);
                                cmd.Parameters.AddWithValue("@reqMin", form.NewAchievement.RequiredMinutes);
                                conn.Open();
                                newId = (int)cmd.ExecuteScalar();
                            }
                        }
                        form.NewAchievement.Id = newId;
                        selectedGame.Achievements.Add(form.NewAchievement);
                        UpdateGameDetails();
                    }
                }
            }
            else
            {
                MessageBox.Show("Сначала выберите или добавьте игру!");
            }
        }

        private void BtnPlayGame_Click(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedItem is Game)
            {
                if (gameTimer.Enabled)
                {
                    gameTimer.Stop();
                    btnPlayGame.Text = "Запустить игру (Таймер)";
                    btnPlayGame.BackColor = Color.FromArgb(41, 98, 255);
                }
                else
                {
                    gameTimer.Start();
                    btnPlayGame.Text = "Остановить игру";
                    btnPlayGame.BackColor = Color.FromArgb(215, 40, 40);
                }
            }
        }

        private void GameTimer_Tick(object sender, EventArgs e)
        {
            if (listBoxGames.SelectedItem is Game selectedGame)
            {
                selectedGame.TimePlayedMinutes++;
                lblTimePlayed.Text = $"⏱ Время в игре: {selectedGame.TimePlayedMinutes} мин.";
                bool stateChanged = false;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string updateTimeQuery = "UPDATE Games SET TimePlayedMinutes = @mins WHERE Id = @id";
                    using (SqlCommand cmd = new SqlCommand(updateTimeQuery, conn))
                    {
                        cmd.Parameters.AddWithValue("@mins", selectedGame.TimePlayedMinutes);
                        cmd.Parameters.AddWithValue("@id", selectedGame.Id);
                        cmd.ExecuteNonQuery();
                    }

                    foreach (var ach in selectedGame.Achievements.Where(a => a.IsTimeBased && !a.IsUnlocked))
                    {
                        if (selectedGame.TimePlayedMinutes >= ach.RequiredMinutes)
                        {
                            ach.IsUnlocked = true;
                            stateChanged = true;
                            string updateAchQuery = "UPDATE Achievements SET IsUnlocked = 1 WHERE Id = @id";
                            using (SqlCommand cmd = new SqlCommand(updateAchQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@id", ach.Id);
                                cmd.ExecuteNonQuery();
                            }
                            MessageBox.Show($" Получено достижение: {ach.Name}!\n{ach.Description}", "Поздравляем!");
                        }
                    }
                }

                if (stateChanged)
                {
                    UpdateGameDetails();
                }
            }
        }

        private void lblProgressPercent_Click(object sender, EventArgs e)
        {

        }
    }
}
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PROEKT2
{
    public class AddGameForm : Form
    {
        public string GameTitle { get; private set; } = string.Empty;
        public string GamePlatform { get; private set; } = string.Empty;

        private TextBox txtTitle = new TextBox();
        private TextBox txtPlatform = new TextBox();
        private Button btnSave = new Button();
        private Button btnCancel = new Button();

        public AddGameForm()
        {
            this.Text = "Добавить игру";
            this.Size = new System.Drawing.Size(300, 220);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;

            Label lblTitle = new Label { Text = "Название игры:", Location = new System.Drawing.Point(15, 15), AutoSize = true };
            txtTitle.Location = new System.Drawing.Point(15, 35); txtTitle.Size = new System.Drawing.Size(250, 22);

            Label lblPlatform = new Label { Text = "Платформа (PC, PS5):", Location = new System.Drawing.Point(15, 65), AutoSize = true };
            txtPlatform.Location = new System.Drawing.Point(15, 85); txtPlatform.Size = new System.Drawing.Size(250, 22);

            btnSave.Text = "Добавить"; btnSave.Location = new System.Drawing.Point(40, 130); btnSave.Size = new System.Drawing.Size(100, 30);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Click += (s, e) => {
                GameTitle = txtTitle.Text.Trim();
                GamePlatform = txtPlatform.Text.Trim();
                if (string.IsNullOrEmpty(GameTitle))
                {
                    MessageBox.Show("Заполните название!");
                    this.DialogResult = DialogResult.None;
                }
            };

            btnCancel.Text = "Отмена"; btnCancel.Location = new System.Drawing.Point(150, 130); btnCancel.Size = new System.Drawing.Size(100, 30);
            btnCancel.DialogResult = DialogResult.Cancel;

            this.Controls.AddRange(new Control[] { lblTitle, txtTitle, lblPlatform, txtPlatform, btnSave, btnCancel });

            ApplyModalTheme();
        }

        private void ApplyModalTheme()
        {
            this.BackColor = Color.FromArgb(20, 24, 33);
            this.ForeColor = Color.FromArgb(210, 215, 225);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox)
                {
                    ctrl.BackColor = Color.FromArgb(32, 42, 61);
                    ctrl.ForeColor = Color.White;
                    ctrl.Font = new Font("Segoe UI", 9.5F);
                }
                if (ctrl is Button btn)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.BackColor = Color.FromArgb(41, 98, 255);
                    btn.ForeColor = Color.White;
                    btn.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);

                    btn.Paint += (s, e) => {
                        int radius = 10;
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
                if (ctrl is Label lbl)
                {
                    lbl.Font = new Font("Segoe UI", 9.5F);
                }
            }
        }
    }
}
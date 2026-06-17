using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace PROEKT2
{
    public class AddAchievementForm : Form
    {
        public Achievement NewAchievement { get; private set; }

        private TextBox txtName = new TextBox();
        private TextBox txtDesc = new TextBox();
        private CheckBox chkIsTime = new CheckBox();
        private NumericUpDown numMinutes = new NumericUpDown();
        private Button btnSave = new Button();

        public AddAchievementForm()
        {
            this.Text = "Создать достижение";
            this.Size = new System.Drawing.Size(320, 300);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;

            Label lblName = new Label { Text = "Название:", Location = new System.Drawing.Point(15, 10), AutoSize = true };
            txtName.Location = new System.Drawing.Point(15, 30); txtName.Size = new System.Drawing.Size(270, 22);

            Label lblDesc = new Label { Text = "Описание:", Location = new System.Drawing.Point(15, 60), AutoSize = true };
            txtDesc.Location = new System.Drawing.Point(15, 80); txtDesc.Size = new System.Drawing.Size(270, 22);

            chkIsTime.Text = "Выдавать за время в игре"; chkIsTime.Location = new System.Drawing.Point(15, 120); chkIsTime.AutoSize = true;

            Label lblMin = new Label { Text = "Требуется минут:", Location = new System.Drawing.Point(15, 155), AutoSize = true };
            numMinutes.Location = new System.Drawing.Point(140, 153); numMinutes.Size = new System.Drawing.Size(80, 22);
            numMinutes.Minimum = 1; numMinutes.Maximum = 1000; numMinutes.Enabled = false;

            chkIsTime.CheckedChanged += (s, e) => numMinutes.Enabled = chkIsTime.Checked;

            btnSave.Text = "Создать"; btnSave.Location = new System.Drawing.Point(95, 210); btnSave.Size = new System.Drawing.Size(110, 35);
            btnSave.DialogResult = DialogResult.OK;
            btnSave.Click += (s, e) => {
                if (string.IsNullOrEmpty(txtName.Text))
                {
                    MessageBox.Show("Введите название!");
                    this.DialogResult = DialogResult.None;
                    return;
                }
                NewAchievement = new Achievement
                {
                    Id = new Random().Next(1000, 9999),
                    Name = txtName.Text.Trim(),
                    Description = txtDesc.Text.Trim(),
                    IsUnlocked = false,
                    IsTimeBased = chkIsTime.Checked,
                    RequiredMinutes = chkIsTime.Checked ? (int)numMinutes.Value : 0
                };
            };

            this.Controls.AddRange(new Control[] { lblName, txtName, lblDesc, txtDesc, chkIsTime, lblMin, numMinutes, btnSave });

            ApplyModalTheme();
        }

        private void ApplyModalTheme()
        {
            this.BackColor = Color.FromArgb(20, 24, 33);
            this.ForeColor = Color.FromArgb(210, 215, 225);
            foreach (Control ctrl in this.Controls)
            {
                if (ctrl is TextBox || ctrl is NumericUpDown)
                {
                    ctrl.BackColor = Color.FromArgb(32, 42, 61);
                    ctrl.ForeColor = Color.White;
                    ctrl.Font = new Font("Segoe UI", 9.5F);
                }
                if (ctrl is CheckBox chk)
                {
                    chk.Font = new Font("Segoe UI", 9.5F);
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
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace ShootingForms
{
    
    public partial class Form1 : Form
    {
        private Random random = new Random();

        private List<Bullet> bullets = new List<Bullet>(10);
        private List<Enemy> enemyButtons = new List<Enemy>();

        private Point bulletStartPoint;

        int score = 0;
        public Form1()
        {
            
            InitializeComponent();
            bulletStartPoint = new Point(this.Width / 2, this.Height / 2);
            CreatePlayer();
            this.MouseClick += Shooting;
            this.KeyDown += Moving;
            //panel1.MouseClick += Shooting;
            UpdateTimer.Start();
            EnemyTimer.Start();
        }

        private void CreatePlayer()
        {
            PictureBox player = new PictureBox();
            player.Width = 30;
            player.Height = 30;
            player.Image = Resource1._1_dots_removebg_preview;
            player.Enabled = false;
            player.SizeMode = PictureBoxSizeMode.StretchImage;
            player.Location = bulletStartPoint;
            this.Controls.Add(player);
            //boolets.Add(b);
            player.Show();
        }
        private void Moving(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    bulletStartPoint.Y -= 2;
                    break;
                case Keys.S:
                    bulletStartPoint.Y += 2;
                    break;
                case Keys.A:
                    bulletStartPoint.X -= 2;
                    break;
                case Keys.D:
                    bulletStartPoint.X += 2;
                    break;
            }
        }
        private void UpdateForm(object sender, EventArgs e)
        {
            for(int i = 0; i < enemyButtons.Count; i++)
            {
                enemyButtons[i].ChangeLocation();
            }
            for (int i = 0; i < bullets.Count; i++)
            {
                bullets[i].ChangeLocation();

                IDisposable control = this.GetChildAtPoint(bullets[i].Location);
                if (control != null && control.GetType() == typeof(Enemy))
                {
                    control.Dispose();
                    score++;
                    scoreCountLabel.Text = score.ToString();
                }
            }
        }

        private void Shooting(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            Bullet b = new Bullet(e.X, e.Y, bulletStartPoint);
            b.Width = 10;
            b.Height = 10;
            b.Image = Resource1._1_dot;
            b.Enabled = false;
            b.SizeMode = PictureBoxSizeMode.StretchImage;
            b.Location = bulletStartPoint;
            this.Controls.Add(b);
            bullets.Add(b);
            b.Show();
        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            Point startPoint = RandomEnemyLocation();
            Enemy enemy = new Enemy(bulletStartPoint.X, bulletStartPoint.Y, startPoint);

            enemy.Location = startPoint;
            enemy.Name = "button";
            enemy.Enabled = false;
            enemy.Size = new System.Drawing.Size(50, 50);
            enemy.Text = "Grrrr";
            enemy.UseVisualStyleBackColor = true;
            enemy.BackColor = Color.Green;
            Controls.Add(enemy);
            enemyButtons.Add(enemy);
        }
        private Point RandomEnemyLocation()
        {
            int xCoord = random.Next(0, 4);

            int distance;

            switch (xCoord)
            {
                case 0:
                    distance = random.Next(0, this.Width);
                    return new Point(distance, 0);
                case 1:
                    distance = random.Next(0, this.Height);
                    return new Point(this.Width, distance);
                case 2:
                    distance = random.Next(0, this.Width);
                    return new Point(distance, this.Height);
                case 3:
                    distance = random.Next(0, this.Height);
                    return new Point(0, distance);
            }

            return new Point(0, 0);
        }
    }
}

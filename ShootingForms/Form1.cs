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

        private List<Bullet> boolets = new List<Bullet>(10);
        private List<Enemy> enemyButtons = new List<Enemy>();

        private Point booletStartPoint;

        int score = 0;
        public Form1()
        {
            
            InitializeComponent();
            booletStartPoint = new Point(this.Width / 2, this.Height / 2);
            CreatePlayer();
            this.MouseClick += Shooting;
            this.KeyDown += Moving;
            //panel1.MouseClick += Shooting;
            timer1.Start();
            EnemyTimer.Start();
        }

        private void CreatePlayer()
        {
            PictureBox b = new PictureBox();
            b.Width = 30;
            b.Height = 30;
            b.Image = Resource1._1_dots_removebg_preview;
            b.Enabled = false;
            b.SizeMode = PictureBoxSizeMode.StretchImage;
            b.Location = booletStartPoint;
            this.Controls.Add(b);
            //boolets.Add(b);
            b.Show();
        }
        private void Moving(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    booletStartPoint.Y -= 2;
                    break;
                case Keys.S:
                    booletStartPoint.Y += 2;
                    break;
                case Keys.A:
                    booletStartPoint.X -= 2;
                    break;
                case Keys.D:
                    booletStartPoint.X += 2;
                    break;
            }
        }
        private void UpdateForm(object sender, EventArgs e)
        {
            for(int i = 0; i < enemyButtons.Count; i++)
            {
                enemyButtons[i].ChangeLocation();
            }
            for (int i = 0; i < boolets.Count; i++)
            {
                boolets[i].ChangeLocation();

                IDisposable control = this.GetChildAtPoint(boolets[i].Location);
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
            Bullet b = new Bullet(e.X, e.Y, booletStartPoint);
            b.Width = 10;
            b.Height = 10;
            b.Image = Resource1._1_dot;
            b.Enabled = false;
            b.SizeMode = PictureBoxSizeMode.StretchImage;
            b.Location = booletStartPoint;
            this.Controls.Add(b);
            boolets.Add(b);
            b.Show();
        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            Point startPoint = RandomEnemyLocation();
            Enemy enemy = new Enemy(booletStartPoint.X, booletStartPoint.Y, startPoint);

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

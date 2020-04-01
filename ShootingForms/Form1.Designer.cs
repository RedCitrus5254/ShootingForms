namespace ShootingForms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.UpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.EnemyTimer = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel = new System.Windows.Forms.Label();
            this.scoreCountLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // UpdateTimer
            // 
            this.UpdateTimer.Interval = 25;
            this.UpdateTimer.Tick += new System.EventHandler(this.UpdateForm);
            // 
            // EnemyTimer
            // 
            this.EnemyTimer.Interval = 700;
            this.EnemyTimer.Tick += new System.EventHandler(this.SpawnEnemy);
            // 
            // scoreLabel
            // 
            this.scoreLabel.AutoSize = true;
            this.scoreLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreLabel.Location = new System.Drawing.Point(809, 9);
            this.scoreLabel.Name = "scoreLabel";
            this.scoreLabel.Size = new System.Drawing.Size(93, 31);
            this.scoreLabel.TabIndex = 1;
            this.scoreLabel.Text = "Score:";
            // 
            // scoreCountLabel
            // 
            this.scoreCountLabel.AutoSize = true;
            this.scoreCountLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.scoreCountLabel.Location = new System.Drawing.Point(902, 9);
            this.scoreCountLabel.Name = "scoreCountLabel";
            this.scoreCountLabel.Size = new System.Drawing.Size(29, 31);
            this.scoreCountLabel.TabIndex = 2;
            this.scoreCountLabel.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 641);
            this.Controls.Add(this.scoreCountLabel);
            this.Controls.Add(this.scoreLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Timer UpdateTimer;
        private System.Windows.Forms.Timer EnemyTimer;
        private System.Windows.Forms.Label scoreLabel;
        private System.Windows.Forms.Label scoreCountLabel;
    }
}


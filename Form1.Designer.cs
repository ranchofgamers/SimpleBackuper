namespace SimpleBackuper
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
            checkBox1 = new CheckBox();
            groupBox1 = new GroupBox();
            textBox1 = new TextBox();
            groupBox2 = new GroupBox();
            button1 = new Button();
            checkBox2 = new CheckBox();
            checkBox3 = new CheckBox();
            groupBox3 = new GroupBox();
            groupBox4 = new GroupBox();
            textBox3 = new TextBox();
            label1 = new Label();
            label2 = new Label();
            checkBox4 = new CheckBox();
            button2 = new Button();
            groupBox6 = new GroupBox();
            button3 = new Button();
            checkBox5 = new CheckBox();
            checkBox6 = new CheckBox();
            label3 = new Label();
            label4 = new Label();
            groupBox5 = new GroupBox();
            button4 = new Button();
            textBox2 = new TextBox();
            groupBox7 = new GroupBox();
            label5 = new Label();
            textBox4 = new TextBox();
            groupBox1.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox4.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBox7.SuspendLayout();
            SuspendLayout();
            // 
            // checkBox1
            // 
            checkBox1.AutoSize = true;
            checkBox1.Location = new Point(6, 25);
            checkBox1.Name = "checkBox1";
            checkBox1.Size = new Size(195, 19);
            checkBox1.TabIndex = 0;
            checkBox1.Text = "Запускать при старте Windows";
            checkBox1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(groupBox7);
            groupBox1.Controls.Add(groupBox5);
            groupBox1.Controls.Add(button3);
            groupBox1.Controls.Add(groupBox3);
            groupBox1.Controls.Add(groupBox2);
            groupBox1.Location = new Point(18, 76);
            groupBox1.Name = "groupBox1";
            groupBox1.Size = new Size(749, 240);
            groupBox1.TabIndex = 2;
            groupBox1.TabStop = false;
            groupBox1.Text = "Планировщик бэкапов";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(6, 22);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(176, 23);
            textBox1.TabIndex = 3;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(button1);
            groupBox2.Controls.Add(textBox1);
            groupBox2.Location = new Point(242, 24);
            groupBox2.Name = "groupBox2";
            groupBox2.Size = new Size(272, 55);
            groupBox2.TabIndex = 4;
            groupBox2.TabStop = false;
            groupBox2.Text = "Путь к исполняемому файлу 1C:";
            // 
            // button1
            // 
            button1.Location = new Point(188, 22);
            button1.Name = "button1";
            button1.Size = new Size(75, 23);
            button1.TabIndex = 4;
            button1.Text = "изменить";
            button1.UseVisualStyleBackColor = true;
            // 
            // checkBox2
            // 
            checkBox2.AutoSize = true;
            checkBox2.Location = new Point(11, 22);
            checkBox2.Name = "checkBox2";
            checkBox2.Size = new Size(185, 19);
            checkBox2.TabIndex = 6;
            checkBox2.Text = "при включении компьютера";
            checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox3
            // 
            checkBox3.AutoSize = true;
            checkBox3.Location = new Point(11, 69);
            checkBox3.Name = "checkBox3";
            checkBox3.Size = new Size(130, 19);
            checkBox3.TabIndex = 7;
            checkBox3.Text = "при включении 1C";
            checkBox3.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(checkBox6);
            groupBox3.Controls.Add(checkBox5);
            groupBox3.Controls.Add(groupBox4);
            groupBox3.Controls.Add(checkBox3);
            groupBox3.Controls.Add(checkBox2);
            groupBox3.Location = new Point(6, 24);
            groupBox3.Name = "groupBox3";
            groupBox3.Size = new Size(230, 210);
            groupBox3.TabIndex = 3;
            groupBox3.TabStop = false;
            groupBox3.Text = "Делать бэкап:";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(label3);
            groupBox4.Controls.Add(textBox3);
            groupBox4.Location = new Point(6, 118);
            groupBox4.Name = "groupBox4";
            groupBox4.Size = new Size(150, 67);
            groupBox4.TabIndex = 5;
            groupBox4.TabStop = false;
            groupBox4.Text = "Интервалами:";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(6, 37);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(136, 23);
            textBox3.TabIndex = 3;
            textBox3.Text = "0";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 9);
            label1.Name = "label1";
            label1.Size = new Size(249, 15);
            label1.TabIndex = 5;
            label1.Text = "Предыдущий бэкап был выполнен: 00:00:00";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 29);
            label2.Name = "label2";
            label2.Size = new Size(253, 15);
            label2.TabIndex = 6;
            label2.Text = "Следующий бэкап ожидается через: 00:00:00";
            // 
            // checkBox4
            // 
            checkBox4.AutoSize = true;
            checkBox4.Location = new Point(6, 50);
            checkBox4.Name = "checkBox4";
            checkBox4.Size = new Size(182, 19);
            checkBox4.TabIndex = 4;
            checkBox4.Text = "Запускать свёрнутым в трей";
            checkBox4.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(575, 54);
            button2.Name = "button2";
            button2.Size = new Size(168, 23);
            button2.TabIndex = 5;
            button2.Text = "Сохранить настройки";
            button2.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(checkBox4);
            groupBox6.Controls.Add(button2);
            groupBox6.Controls.Add(checkBox1);
            groupBox6.Location = new Point(18, 322);
            groupBox6.Name = "groupBox6";
            groupBox6.Size = new Size(749, 83);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Настройки приложения:";
            // 
            // button3
            // 
            button3.Location = new Point(575, 211);
            button3.Name = "button3";
            button3.Size = new Size(168, 23);
            button3.TabIndex = 6;
            button3.Text = "Сохранить настройки";
            button3.UseVisualStyleBackColor = true;
            // 
            // checkBox5
            // 
            checkBox5.AutoSize = true;
            checkBox5.Location = new Point(11, 92);
            checkBox5.Name = "checkBox5";
            checkBox5.Size = new Size(150, 19);
            checkBox5.TabIndex = 8;
            checkBox5.Text = "после выключения 1C";
            checkBox5.UseVisualStyleBackColor = true;
            // 
            // checkBox6
            // 
            checkBox6.AutoSize = true;
            checkBox6.Location = new Point(11, 45);
            checkBox6.Name = "checkBox6";
            checkBox6.Size = new Size(194, 19);
            checkBox6.TabIndex = 9;
            checkBox6.Text = "при выключении компьютера";
            checkBox6.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 19);
            label3.Name = "label3";
            label3.Size = new Size(136, 15);
            label3.TabIndex = 8;
            label3.Text = "Каждые (сек.). 0 - откл.:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 48);
            label4.Name = "label4";
            label4.Size = new Size(172, 15);
            label4.TabIndex = 8;
            label4.Text = "Бэкап сохранен: C:\\something";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(button4);
            groupBox5.Controls.Add(textBox2);
            groupBox5.Location = new Point(242, 92);
            groupBox5.Name = "groupBox5";
            groupBox5.Size = new Size(272, 55);
            groupBox5.TabIndex = 5;
            groupBox5.TabStop = false;
            groupBox5.Text = "Директория хранения бэкапов:";
            // 
            // button4
            // 
            button4.Location = new Point(188, 22);
            button4.Name = "button4";
            button4.Size = new Size(75, 23);
            button4.TabIndex = 4;
            button4.Text = "изменить";
            button4.UseVisualStyleBackColor = true;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(6, 22);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(176, 23);
            textBox2.TabIndex = 3;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(label5);
            groupBox7.Controls.Add(textBox4);
            groupBox7.Location = new Point(242, 161);
            groupBox7.Name = "groupBox7";
            groupBox7.Size = new Size(160, 67);
            groupBox7.TabIndex = 9;
            groupBox7.TabStop = false;
            groupBox7.Text = "Удалять бэкапы:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(6, 19);
            label5.Name = "label5";
            label5.Size = new Size(136, 15);
            label5.TabIndex = 8;
            label5.Text = "Старше (мес.) 0 - откл.:";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(6, 37);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(136, 23);
            textBox4.TabIndex = 3;
            textBox4.Text = "0";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(773, 415);
            Controls.Add(label4);
            Controls.Add(groupBox6);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(groupBox1);
            Name = "Form1";
            Text = "A";
            Load += Form1_Load;
            groupBox1.ResumeLayout(false);
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private CheckBox checkBox1;
        private GroupBox groupBox1;
        private GroupBox groupBox2;
        private Button button1;
        private TextBox textBox1;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private CheckBox checkBox3;
        private CheckBox checkBox2;
        private TextBox textBox3;
        private GroupBox groupBox7;
        private Label label5;
        private TextBox textBox4;
        private GroupBox groupBox5;
        private Button button4;
        private TextBox textBox2;
        private Button button3;
        private CheckBox checkBox6;
        private CheckBox checkBox5;
        private Label label3;
        private Label label1;
        private Label label2;
        private CheckBox checkBox4;
        private Button button2;
        private GroupBox groupBox6;
        private Label label4;
    }
}
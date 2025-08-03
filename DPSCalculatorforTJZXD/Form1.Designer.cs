
namespace DPSCalculatorforTJZXD
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.chkIsEnergy = new System.Windows.Forms.CheckBox();
            this.txtDamage = new System.Windows.Forms.TextBox();
            this.txtBulletAmount = new System.Windows.Forms.TextBox();
            this.txtBulletCapacity = new System.Windows.Forms.TextBox();
            this.txtCriticalDamage = new System.Windows.Forms.TextBox();
            this.txtCriticalChance = new System.Windows.Forms.TextBox();
            this.txtAttackSpeed = new System.Windows.Forms.TextBox();
            this.txtReloadTime = new System.Windows.Forms.TextBox();
            this.txtEnergyConsum = new System.Windows.Forms.TextBox();
            this.txtEnergyPool = new System.Windows.Forms.TextBox();
            this.btnCalculate = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtDPS10s = new System.Windows.Forms.TextBox();
            this.txtDPS45s = new System.Windows.Forms.TextBox();
            this.txtDPSAvg = new System.Windows.Forms.TextBox();
            this.btnDamage = new System.Windows.Forms.Button();
            this.btnCriticalChance = new System.Windows.Forms.Button();
            this.btnCriticalDamage = new System.Windows.Forms.Button();
            this.btnBulletAmount = new System.Windows.Forms.Button();
            this.btnBulletCapacity = new System.Windows.Forms.Button();
            this.btnAttackSpeed = new System.Windows.Forms.Button();
            this.btnReloadTime = new System.Windows.Forms.Button();
            this.btnEnergyConsum = new System.Windows.Forms.Button();
            this.btnEnergyPool = new System.Windows.Forms.Button();
            this.pictureBoxGraph = new System.Windows.Forms.PictureBox();
            this.trackAdjust = new System.Windows.Forms.TrackBar();
            this.txtAdjustValue = new System.Windows.Forms.TextBox();
            this.btnApplyToInput = new System.Windows.Forms.Button();
            this.chkIsLasting = new System.Windows.Forms.CheckBox();
            this.txtAttackAnim = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAdjust)).BeginInit();
            this.SuspendLayout();
            // 
            // chkIsEnergy
            // 
            this.chkIsEnergy.AutoSize = true;
            this.chkIsEnergy.Location = new System.Drawing.Point(265, 361);
            this.chkIsEnergy.Name = "chkIsEnergy";
            this.chkIsEnergy.Size = new System.Drawing.Size(117, 19);
            this.chkIsEnergy.TabIndex = 9;
            this.chkIsEnergy.Text = "chkIsEnergy";
            this.chkIsEnergy.UseVisualStyleBackColor = true;
            // 
            // txtDamage
            // 
            this.txtDamage.Location = new System.Drawing.Point(38, 327);
            this.txtDamage.Name = "txtDamage";
            this.txtDamage.Size = new System.Drawing.Size(100, 25);
            this.txtDamage.TabIndex = 10;
            // 
            // txtBulletAmount
            // 
            this.txtBulletAmount.Location = new System.Drawing.Point(389, 327);
            this.txtBulletAmount.Name = "txtBulletAmount";
            this.txtBulletAmount.Size = new System.Drawing.Size(100, 25);
            this.txtBulletAmount.TabIndex = 11;
            this.txtBulletAmount.TextChanged += new System.EventHandler(this.txtBulletAmount_TextChanged);
            // 
            // txtBulletCapacity
            // 
            this.txtBulletCapacity.Location = new System.Drawing.Point(512, 327);
            this.txtBulletCapacity.Name = "txtBulletCapacity";
            this.txtBulletCapacity.Size = new System.Drawing.Size(100, 25);
            this.txtBulletCapacity.TabIndex = 12;
            this.txtBulletCapacity.TextChanged += new System.EventHandler(this.txtBulletCapacity_TextChanged);
            // 
            // txtCriticalDamage
            // 
            this.txtCriticalDamage.Location = new System.Drawing.Point(266, 327);
            this.txtCriticalDamage.Name = "txtCriticalDamage";
            this.txtCriticalDamage.Size = new System.Drawing.Size(100, 25);
            this.txtCriticalDamage.TabIndex = 13;
            // 
            // txtCriticalChance
            // 
            this.txtCriticalChance.Location = new System.Drawing.Point(149, 327);
            this.txtCriticalChance.Name = "txtCriticalChance";
            this.txtCriticalChance.Size = new System.Drawing.Size(100, 25);
            this.txtCriticalChance.TabIndex = 14;
            // 
            // txtAttackSpeed
            // 
            this.txtAttackSpeed.Location = new System.Drawing.Point(38, 384);
            this.txtAttackSpeed.Name = "txtAttackSpeed";
            this.txtAttackSpeed.Size = new System.Drawing.Size(100, 25);
            this.txtAttackSpeed.TabIndex = 15;
            // 
            // txtReloadTime
            // 
            this.txtReloadTime.Location = new System.Drawing.Point(149, 384);
            this.txtReloadTime.Name = "txtReloadTime";
            this.txtReloadTime.Size = new System.Drawing.Size(100, 25);
            this.txtReloadTime.TabIndex = 16;
            this.txtReloadTime.TextChanged += new System.EventHandler(this.txtReloadTime_TextChanged);
            // 
            // txtEnergyConsum
            // 
            this.txtEnergyConsum.Location = new System.Drawing.Point(389, 384);
            this.txtEnergyConsum.Name = "txtEnergyConsum";
            this.txtEnergyConsum.Size = new System.Drawing.Size(100, 25);
            this.txtEnergyConsum.TabIndex = 17;
            // 
            // txtEnergyPool
            // 
            this.txtEnergyPool.Location = new System.Drawing.Point(512, 384);
            this.txtEnergyPool.Name = "txtEnergyPool";
            this.txtEnergyPool.Size = new System.Drawing.Size(100, 25);
            this.txtEnergyPool.TabIndex = 18;
            this.txtEnergyPool.TextChanged += new System.EventHandler(this.txtEnergyPool_TextChanged);
            // 
            // btnCalculate
            // 
            this.btnCalculate.Location = new System.Drawing.Point(646, 300);
            this.btnCalculate.Name = "btnCalculate";
            this.btnCalculate.Size = new System.Drawing.Size(142, 109);
            this.btnCalculate.TabIndex = 19;
            this.btnCalculate.Text = "upDate";
            this.btnCalculate.UseVisualStyleBackColor = true;
            this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(38, 66);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(55, 15);
            this.label10.TabIndex = 20;
            this.label10.Text = "10sDPS";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(38, 142);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 15);
            this.label11.TabIndex = 21;
            this.label11.Text = "AvgDPS";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(38, 105);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(55, 15);
            this.label12.TabIndex = 22;
            this.label12.Text = "45sDPS";
            // 
            // txtDPS10s
            // 
            this.txtDPS10s.Location = new System.Drawing.Point(109, 63);
            this.txtDPS10s.Name = "txtDPS10s";
            this.txtDPS10s.Size = new System.Drawing.Size(100, 25);
            this.txtDPS10s.TabIndex = 23;
            this.txtDPS10s.TextChanged += new System.EventHandler(this.txtDPS10s_TextChanged);
            // 
            // txtDPS45s
            // 
            this.txtDPS45s.Location = new System.Drawing.Point(109, 102);
            this.txtDPS45s.Name = "txtDPS45s";
            this.txtDPS45s.Size = new System.Drawing.Size(100, 25);
            this.txtDPS45s.TabIndex = 24;
            // 
            // txtDPSAvg
            // 
            this.txtDPSAvg.Location = new System.Drawing.Point(109, 139);
            this.txtDPSAvg.Name = "txtDPSAvg";
            this.txtDPSAvg.Size = new System.Drawing.Size(100, 25);
            this.txtDPSAvg.TabIndex = 25;
            // 
            // btnDamage
            // 
            this.btnDamage.Location = new System.Drawing.Point(38, 300);
            this.btnDamage.Name = "btnDamage";
            this.btnDamage.Size = new System.Drawing.Size(75, 23);
            this.btnDamage.TabIndex = 26;
            this.btnDamage.Text = "Damage";
            this.btnDamage.UseVisualStyleBackColor = true;
            this.btnDamage.Click += new System.EventHandler(this.btnDamage_Click);
            // 
            // btnCriticalChance
            // 
            this.btnCriticalChance.Location = new System.Drawing.Point(149, 300);
            this.btnCriticalChance.Name = "btnCriticalChance";
            this.btnCriticalChance.Size = new System.Drawing.Size(108, 23);
            this.btnCriticalChance.TabIndex = 27;
            this.btnCriticalChance.Text = "CriticalChance";
            this.btnCriticalChance.UseVisualStyleBackColor = true;
            this.btnCriticalChance.Click += new System.EventHandler(this.btnCriticalCha_Click);
            // 
            // btnCriticalDamage
            // 
            this.btnCriticalDamage.Location = new System.Drawing.Point(265, 300);
            this.btnCriticalDamage.Name = "btnCriticalDamage";
            this.btnCriticalDamage.Size = new System.Drawing.Size(108, 23);
            this.btnCriticalDamage.TabIndex = 28;
            this.btnCriticalDamage.Text = "CriticalDmg";
            this.btnCriticalDamage.UseVisualStyleBackColor = true;
            this.btnCriticalDamage.Click += new System.EventHandler(this.btnCriticalDmg_Click);
            // 
            // btnBulletAmount
            // 
            this.btnBulletAmount.Location = new System.Drawing.Point(389, 300);
            this.btnBulletAmount.Name = "btnBulletAmount";
            this.btnBulletAmount.Size = new System.Drawing.Size(113, 23);
            this.btnBulletAmount.TabIndex = 29;
            this.btnBulletAmount.Text = "BulletAmount";
            this.btnBulletAmount.UseVisualStyleBackColor = true;
            this.btnBulletAmount.Click += new System.EventHandler(this.btnBulletAmount_Click);
            // 
            // btnBulletCapacity
            // 
            this.btnBulletCapacity.Location = new System.Drawing.Point(512, 300);
            this.btnBulletCapacity.Name = "btnBulletCapacity";
            this.btnBulletCapacity.Size = new System.Drawing.Size(128, 23);
            this.btnBulletCapacity.TabIndex = 30;
            this.btnBulletCapacity.Text = "BulletCapacity";
            this.btnBulletCapacity.UseVisualStyleBackColor = true;
            this.btnBulletCapacity.Click += new System.EventHandler(this.btnBulletCapacity_Click);
            // 
            // btnAttackSpeed
            // 
            this.btnAttackSpeed.Location = new System.Drawing.Point(38, 359);
            this.btnAttackSpeed.Name = "btnAttackSpeed";
            this.btnAttackSpeed.Size = new System.Drawing.Size(102, 23);
            this.btnAttackSpeed.TabIndex = 31;
            this.btnAttackSpeed.Text = "AttackSpd";
            this.btnAttackSpeed.UseVisualStyleBackColor = true;
            this.btnAttackSpeed.Click += new System.EventHandler(this.btnAttackSpd_Click);
            // 
            // btnReloadTime
            // 
            this.btnReloadTime.Location = new System.Drawing.Point(149, 358);
            this.btnReloadTime.Name = "btnReloadTime";
            this.btnReloadTime.Size = new System.Drawing.Size(100, 23);
            this.btnReloadTime.TabIndex = 32;
            this.btnReloadTime.Text = "ReloadTime";
            this.btnReloadTime.UseVisualStyleBackColor = true;
            this.btnReloadTime.Click += new System.EventHandler(this.btnReloadTime_Click);
            // 
            // btnEnergyConsum
            // 
            this.btnEnergyConsum.Location = new System.Drawing.Point(389, 358);
            this.btnEnergyConsum.Name = "btnEnergyConsum";
            this.btnEnergyConsum.Size = new System.Drawing.Size(113, 23);
            this.btnEnergyConsum.TabIndex = 33;
            this.btnEnergyConsum.Text = "EnergyConsum";
            this.btnEnergyConsum.UseVisualStyleBackColor = true;
            this.btnEnergyConsum.Click += new System.EventHandler(this.btnEnergyConsum_Click);
            // 
            // btnEnergyPool
            // 
            this.btnEnergyPool.Location = new System.Drawing.Point(512, 358);
            this.btnEnergyPool.Name = "btnEnergyPool";
            this.btnEnergyPool.Size = new System.Drawing.Size(100, 23);
            this.btnEnergyPool.TabIndex = 34;
            this.btnEnergyPool.Text = "EnergyPool";
            this.btnEnergyPool.UseVisualStyleBackColor = true;
            this.btnEnergyPool.Click += new System.EventHandler(this.btnEnergyPool_Click);
            // 
            // pictureBoxGraph
            // 
            this.pictureBoxGraph.Location = new System.Drawing.Point(285, 12);
            this.pictureBoxGraph.Name = "pictureBoxGraph";
            this.pictureBoxGraph.Size = new System.Drawing.Size(482, 206);
            this.pictureBoxGraph.TabIndex = 35;
            this.pictureBoxGraph.TabStop = false;
            this.pictureBoxGraph.Visible = false;
            // 
            // trackAdjust
            // 
            this.trackAdjust.Location = new System.Drawing.Point(285, 225);
            this.trackAdjust.Name = "trackAdjust";
            this.trackAdjust.Size = new System.Drawing.Size(482, 56);
            this.trackAdjust.TabIndex = 36;
            this.trackAdjust.Visible = false;
            this.trackAdjust.Scroll += new System.EventHandler(this.trackAdjust_Scroll);
            // 
            // txtAdjustValue
            // 
            this.txtAdjustValue.Location = new System.Drawing.Point(179, 225);
            this.txtAdjustValue.Name = "txtAdjustValue";
            this.txtAdjustValue.Size = new System.Drawing.Size(100, 25);
            this.txtAdjustValue.TabIndex = 37;
            this.txtAdjustValue.Visible = false;
            this.txtAdjustValue.TextChanged += new System.EventHandler(this.txtAdjustValue_TextChanged);
            // 
            // btnApplyToInput
            // 
            this.btnApplyToInput.Location = new System.Drawing.Point(63, 227);
            this.btnApplyToInput.Name = "btnApplyToInput";
            this.btnApplyToInput.Size = new System.Drawing.Size(110, 23);
            this.btnApplyToInput.TabIndex = 38;
            this.btnApplyToInput.Text = "Application";
            this.btnApplyToInput.UseVisualStyleBackColor = true;
            this.btnApplyToInput.Visible = false;
            this.btnApplyToInput.Click += new System.EventHandler(this.btnApplyToInput_Click);
            // 
            // chkIsLasting
            // 
            this.chkIsLasting.AutoSize = true;
            this.chkIsLasting.Location = new System.Drawing.Point(265, 390);
            this.chkIsLasting.Name = "chkIsLasting";
            this.chkIsLasting.Size = new System.Drawing.Size(125, 19);
            this.chkIsLasting.TabIndex = 39;
            this.chkIsLasting.Text = "chkIsLasting";
            this.chkIsLasting.UseVisualStyleBackColor = true;
            this.chkIsLasting.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // txtAttackAnim
            // 
            this.txtAttackAnim.Location = new System.Drawing.Point(38, 415);
            this.txtAttackAnim.Name = "txtAttackAnim";
            this.txtAttackAnim.Size = new System.Drawing.Size(100, 25);
            this.txtAttackAnim.TabIndex = 40;
            this.txtAttackAnim.Text = "0";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtAttackAnim);
            this.Controls.Add(this.chkIsLasting);
            this.Controls.Add(this.btnApplyToInput);
            this.Controls.Add(this.txtAdjustValue);
            this.Controls.Add(this.trackAdjust);
            this.Controls.Add(this.pictureBoxGraph);
            this.Controls.Add(this.btnEnergyPool);
            this.Controls.Add(this.btnEnergyConsum);
            this.Controls.Add(this.btnReloadTime);
            this.Controls.Add(this.btnAttackSpeed);
            this.Controls.Add(this.btnBulletCapacity);
            this.Controls.Add(this.btnBulletAmount);
            this.Controls.Add(this.btnCriticalDamage);
            this.Controls.Add(this.btnCriticalChance);
            this.Controls.Add(this.btnDamage);
            this.Controls.Add(this.txtDPSAvg);
            this.Controls.Add(this.txtDPS45s);
            this.Controls.Add(this.txtDPS10s);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btnCalculate);
            this.Controls.Add(this.txtEnergyPool);
            this.Controls.Add(this.txtEnergyConsum);
            this.Controls.Add(this.txtReloadTime);
            this.Controls.Add(this.txtAttackSpeed);
            this.Controls.Add(this.txtCriticalChance);
            this.Controls.Add(this.txtCriticalDamage);
            this.Controls.Add(this.txtBulletCapacity);
            this.Controls.Add(this.txtBulletAmount);
            this.Controls.Add(this.txtDamage);
            this.Controls.Add(this.chkIsEnergy);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraph)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackAdjust)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.CheckBox chkIsEnergy;
        private System.Windows.Forms.TextBox txtDamage;
        private System.Windows.Forms.TextBox txtBulletAmount;
        private System.Windows.Forms.TextBox txtBulletCapacity;
        private System.Windows.Forms.TextBox txtCriticalDamage;
        private System.Windows.Forms.TextBox txtCriticalChance;
        private System.Windows.Forms.TextBox txtAttackSpeed;
        private System.Windows.Forms.TextBox txtReloadTime;
        private System.Windows.Forms.TextBox txtEnergyConsum;
        private System.Windows.Forms.TextBox txtEnergyPool;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtDPS10s;
        private System.Windows.Forms.TextBox txtDPS45s;
        private System.Windows.Forms.TextBox txtDPSAvg;
        private System.Windows.Forms.Button btnDamage;
        private System.Windows.Forms.Button btnCriticalChance;
        private System.Windows.Forms.Button btnCriticalDamage;
        private System.Windows.Forms.Button btnBulletAmount;
        private System.Windows.Forms.Button btnBulletCapacity;
        private System.Windows.Forms.Button btnAttackSpeed;
        private System.Windows.Forms.Button btnReloadTime;
        private System.Windows.Forms.Button btnEnergyConsum;
        private System.Windows.Forms.Button btnEnergyPool;
        private System.Windows.Forms.PictureBox pictureBoxGraph;
        private System.Windows.Forms.TrackBar trackAdjust;
        private System.Windows.Forms.TextBox txtAdjustValue;
        private System.Windows.Forms.Button btnApplyToInput;
        private System.Windows.Forms.CheckBox chkIsLasting;
        private System.Windows.Forms.TextBox txtAttackAnim;
    }
}


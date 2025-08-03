using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DPSCalculatorforTJZXD
{
    public partial class Form1 : Form
    {
        private string currentEditingProperty = "";
        private double xScaleFactor = 1.0;
        private string lastEditingProperty = "";
        private double currentMaxX = 100; // 当前图像的X轴最大值（由属性按钮决定）
        private Func<double, (double, double, double)> currentDpsFunc = null;
        private double currentBaseMaxX = 1.0; // 固定的 baseMaxX，用于判断滑轨倍率


        // 滚轮调整数值
        private void txtAdjustValue_MouseWheel(object sender, MouseEventArgs e)
        {
            if (double.TryParse(txtAdjustValue.Text, out double value))
            {
                double delta = e.Delta > 0 ? 1 : -1;
                if (ModifierKeys == Keys.Control) delta *= 0.1;
                value += delta;
                txtAdjustValue.Text = value.ToString("F2");
            }
        }

        // 回车触发
        private void txtAdjustValue_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnApplyToInput.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        // 确保值在图像显示范围内
        private void EnsureValueInRange()
        {
            if (!double.TryParse(txtAdjustValue.Text, out double targetX)) return;

            // 如果是 CriticalChance，则强制锁死范围不变
            if (currentEditingProperty == "CriticalChance")
            {
                // 若 targetX 超出范围也不放大
                currentMaxX = 100;
                return;
            }

            // 非 CriticalChance 的处理逻辑
            double baseX = currentBaseMaxX;
            double limitX = baseX * xScaleFactor;

            if (targetX > limitX)
            {
                bool adjusted = false;
                for (int i = trackAdjust.Value + 1; i <= trackAdjust.Maximum; i++)
                {
                    double testScale = 1.0 + i / 10.0;
                    if (targetX <= baseX * testScale)
                    {
                        trackAdjust.Value = i;
                        xScaleFactor = testScale;
                        currentMaxX = baseX * xScaleFactor;
                        adjusted = true;
                        break;
                    }
                }

                if (!adjusted)
                {
                    currentBaseMaxX = Math.Max(targetX * 1.2, 1);
                    trackAdjust.Value = trackAdjust.Minimum;
                    xScaleFactor = 1.0;
                    currentMaxX = currentBaseMaxX * xScaleFactor;
                }
            }
        }

        // 将调整值写入输入框并重绘
        private void btnApplyToInput_Click(object sender, EventArgs e)
        {
            if (!double.TryParse(txtAdjustValue.Text, out double value)) return;

            switch (currentEditingProperty)
            {
                case "Damage": txtDamage.Text = value.ToString(); break;
                case "CriticalChance": txtCriticalChance.Text = value.ToString(); break;
                case "CriticalDamage": txtCriticalDamage.Text = value.ToString(); break;
                case "BulletAmount": txtBulletAmount.Text = ((int)value).ToString(); break;
                case "BulletCapacity": txtBulletCapacity.Text = ((int)value).ToString(); break;
                case "AttackSpeed": txtAttackSpeed.Text = value.ToString(); break;
                case "ReloadTime": txtReloadTime.Text = value.ToString(); break;
                case "EnergyConsum": txtEnergyConsum.Text = ((int)value).ToString(); break;
                case "EnergyPool": txtEnergyPool.Text = ((int)value).ToString(); break;
            }

            xScaleFactor = 1.0;
            trackAdjust.Value = trackAdjust.Minimum;
            currentBaseMaxX = currentEditingProperty == "CriticalChance"
              ? 100
              : Math.Max(value * 10, 1);
            EnsureValueInRange();

            switch (currentEditingProperty)
            {
                case "Damage": btnDamage.PerformClick(); break;
                case "CriticalChance": btnCriticalChance.PerformClick(); break;
                case "CriticalDamage": btnCriticalDamage.PerformClick(); break;
                case "BulletAmount": btnBulletAmount.PerformClick(); break;
                case "BulletCapacity": btnBulletCapacity.PerformClick(); break;
                case "AttackSpeed": btnAttackSpeed.PerformClick(); break;
                case "ReloadTime": btnReloadTime.PerformClick(); break;
                case "EnergyConsum": btnEnergyConsum.PerformClick(); break;
                case "EnergyPool": btnEnergyPool.PerformClick(); break;
            }
        }


        private void OnPropertyButtonClicked(string propertyName, double currentValue)
        {
            bool isSwitchingProperty = propertyName != lastEditingProperty;
            if (isSwitchingProperty)
            {
                xScaleFactor = 1.0;
                trackAdjust.Value = trackAdjust.Minimum;
                lastEditingProperty = propertyName;
            }

            currentEditingProperty = propertyName;

            double baseMaxX = propertyName == "CriticalChance" ? 100 : Math.Max(currentValue * 10, 1);
            currentBaseMaxX = baseMaxX;
            double maxX = baseMaxX * xScaleFactor;

            Func<double, (double, double, double)> func = x =>
            {
                var dict = GetCurrentStateExcept(propertyName);
                return CalculateDPS(x, propertyName, dict);
            };

            currentMaxX = maxX;
            currentDpsFunc = func;

            EnsureValueInRange();
            DrawGraph(propertyName, func, currentMaxX);

            txtAdjustValue.Text = currentValue.ToString();
            pictureBoxGraph.Visible = true;
            trackAdjust.Visible = true;
            txtAdjustValue.Visible = true;
            btnApplyToInput.Visible = true;
        }

        //9个按钮的点击事件
        private void btnDamage_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("Damage", double.Parse(txtDamage.Text));
        }

        private void btnCriticalCha_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("CriticalChance", double.Parse(txtCriticalChance.Text));
        }

        private void btnCriticalDmg_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("CriticalDamage", double.Parse(txtCriticalDamage.Text));
        }

        private void btnBulletAmount_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("BulletAmount", int.Parse(txtBulletAmount.Text));
        }

        private void btnBulletCapacity_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("BulletCapacity", int.Parse(txtBulletCapacity.Text));
        }

        private void btnAttackSpd_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("AttackSpeed", double.Parse(txtAttackSpeed.Text));
        }

        private void btnReloadTime_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("ReloadTime", double.Parse(txtReloadTime.Text));
        }

        private void btnEnergyConsum_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("EnergyConsum", int.Parse(txtEnergyConsum.Text));
        }

        private void btnEnergyPool_Click(object sender, EventArgs e)
        {
            OnPropertyButtonClicked("EnergyPool", int.Parse(txtEnergyPool.Text));
        }

        private Dictionary<string, double> GetCurrentStateExcept(string excludedProperty)
        {
            var dict = new Dictionary<string, double>();

            void TryAdd(string key, TextBox txt)
            {
                if (excludedProperty != key) dict[key] = double.TryParse(txt.Text, out double val) ? val : 0;
            }

            TryAdd("Damage", txtDamage);
            TryAdd("CriticalChance", txtCriticalChance); // 百分数形式
            TryAdd("CriticalDamage", txtCriticalDamage);
            TryAdd("BulletAmount", txtBulletAmount);
            TryAdd("BulletCapacity", txtBulletCapacity);
            TryAdd("AttackSpeed", txtAttackSpeed);
            TryAdd("ReloadTime", txtReloadTime);
            TryAdd("EnergyConsum", txtEnergyConsum);
            TryAdd("EnergyPool", txtEnergyPool);

            return dict;
        }

        // 滑条滑动响应
        private void trackAdjust_Scroll(object sender, EventArgs e)
        {
            int sliderValue = trackAdjust.Value; // [0,100]
            xScaleFactor = 1.0 + sliderValue / 10.0;  // 缩放倍数 = 1 ~ 11
            txtAdjustValue.Text = txtAdjustValue.Text; // ✅ 保持当前值不变

            // 重绘图像（使用当前属性值和新的缩放倍数）
            var state = GetCurrentStateExcept(currentEditingProperty);
            double currentValue = state.ContainsKey(currentEditingProperty) ? state[currentEditingProperty] : 1;
            double maxX = (currentEditingProperty == "CriticalChance" ? 100 : Math.Max(currentValue * 10, 1)) * xScaleFactor;

            Func<double, (double, double, double)> func = x =>
            {
                var dict = GetCurrentStateExcept(currentEditingProperty);
                return CalculateDPS(x, currentEditingProperty, dict);
            };

            DrawGraph(currentEditingProperty, func, maxX);
        }

        // 文本框输入响应
        private void txtAdjustValue_TextChanged(object sender, EventArgs e)
        {
            if (!double.TryParse(txtAdjustValue.Text, out double value)) return;

            // 限制不能为负数
            if (value < 0)
            {
                value = 0;
                txtAdjustValue.Text = "0";
            }

            // 限制 CriticalChance 上限为 100
            if (currentEditingProperty == "CriticalChance" && value > 100)
            {
                value = 100;
                txtAdjustValue.Text = "100";
            }

            // 实时更新左侧 DPS 输出
            var dict = GetCurrentStateExcept(currentEditingProperty);
            var (dps10, dps45, dpsAvg) = CalculateDPS(value, currentEditingProperty, dict);
            txtDPS10s.Text = dps10.ToString("F2");
            txtDPS45s.Text = dps45.ToString("F2");
            txtDPSAvg.Text = dpsAvg.ToString("F2");

            // 检查小点是否超出显示范围，必要时缩放
            EnsureValueInRange();

            // 更新图上的小点（不改变缩放和曲线）
            DrawGraph(currentEditingProperty, currentDpsFunc, currentMaxX);
        }

        //实现临时赋值方法（更新图像和 DPS）
        private void ApplyTemporaryValue(double newValue)
        {
            var tempState = GetCurrentStateExcept(currentEditingProperty);
            tempState[currentEditingProperty] = newValue;

            var (dps10, dps45, dpsAvg) = CalculateDPS(tempState);

            txtDPS10s.Text = dps10.ToString("F2");
            txtDPS45s.Text = dps45.ToString("F2");
            txtDPSAvg.Text = dpsAvg.ToString("F2");

            // ✅ 使用当前图像函数和 currentMaxX，仅重绘图像（含小点）
            if (currentDpsFunc != null)
            {
                DrawGraph(currentEditingProperty, currentDpsFunc, currentMaxX);
            }
        }

        //绘图方法
        private void DrawGraph(string propertyName, Func<double, (double dps10, double dps45, double dpsAvg)> dpsFunc, double maxX)
        {
            int width = pictureBoxGraph.Width;
            int height = pictureBoxGraph.Height;
            Bitmap bmp = new Bitmap(width, height);

            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.Clear(Color.White);
                Font font = new Font("Arial", 8);
                Pen axisPen = new Pen(Color.Black, 1.5f);
                Pen pen10 = new Pen(Color.Red, 1.8f);
                Pen pen45 = new Pen(Color.Green, 1.8f);
                Pen penAvg = new Pen(Color.Blue, 1.8f);

                int marginLeft = 40;
                int marginBottom = 30;
                int marginTop = 10;
                int marginRight = 10;

                int plotWidth = width - marginLeft - marginRight;
                int plotHeight = height - marginTop - marginBottom;

                Point[] pts10 = new Point[plotWidth];
                Point[] pts45 = new Point[plotWidth];
                Point[] ptsAvg = new Point[plotWidth];
                double maxY = 0;

                for (int i = 0; i < plotWidth; i++)
                {
                    double xVal = maxX * i / (plotWidth - 1);
                    var (d10, d45, dAvg) = dpsFunc(xVal);
                    maxY = Math.Max(maxY, Math.Max(d10, Math.Max(d45, dAvg)));

                    int xPixel = marginLeft + i;
                    pts10[i] = new Point(xPixel, 0);
                    pts45[i] = new Point(xPixel, 0);
                    ptsAvg[i] = new Point(xPixel, 0);
                }

                double yMaxDisplay = maxY >= 1000 ? 9999 : maxY * 1.1;

                for (int i = 0; i < plotWidth; i++)
                {
                    double xVal = maxX * i / (plotWidth - 1);
                    var (d10, d45, dAvg) = dpsFunc(xVal);

                    d10 = Math.Min(d10, yMaxDisplay);
                    d45 = Math.Min(d45, yMaxDisplay);
                    dAvg = Math.Min(dAvg, yMaxDisplay);

                    int xPixel = marginLeft + i;
                    pts10[i].Y = (int)(height - marginBottom - (d10 / yMaxDisplay * plotHeight));
                    pts45[i].Y = (int)(height - marginBottom - (d45 / yMaxDisplay * plotHeight));
                    ptsAvg[i].Y = (int)(height - marginBottom - (dAvg / yMaxDisplay * plotHeight));
                }

                // 坐标轴
                g.DrawLine(axisPen, marginLeft, height - marginBottom, width - marginRight, height - marginBottom); // X
                g.DrawLine(axisPen, marginLeft, height - marginBottom, marginLeft, marginTop); // Y

                // Y轴刻度
                for (int i = 0; i <= 5; i++)
                {
                    int y = marginTop + i * plotHeight / 5;
                    double yVal = yMaxDisplay * (1 - i / 5.0);
                    string label = yVal >= 1000 ? ">1000" : yVal.ToString("F0");
                    g.DrawLine(Pens.Gray, marginLeft - 3, y, marginLeft + plotWidth, y);
                    g.DrawString(label, font, Brushes.Black, 2, y - 8);
                }

                // X轴刻度
                for (int i = 0; i <= 5; i++)
                {
                    int x = marginLeft + i * plotWidth / 5;
                    double xVal = maxX * i / 5.0;
                    g.DrawLine(Pens.Gray, x, height - marginBottom + 3, x, marginTop);
                    g.DrawString(xVal.ToString("F0"), font, Brushes.Black, x - 10, height - marginBottom + 5);
                }

                // 绘制曲线
                g.DrawLines(pen10, pts10);
                g.DrawLines(pen45, pts45);
                g.DrawLines(penAvg, ptsAvg);

                // ✅ 绘制小点：根据 txtAdjustValue 当前值显示
                if (double.TryParse(txtAdjustValue.Text, out double currentX))
                {
                    if (currentX >= 0 && currentX <= maxX)
                    {
                        var (dp10, dp45, dpAvg) = dpsFunc(currentX);
                        dp10 = Math.Min(dp10, yMaxDisplay);
                        dp45 = Math.Min(dp45, yMaxDisplay);
                        dpAvg = Math.Min(dpAvg, yMaxDisplay);

                        int xPixel = marginLeft + (int)(currentX / maxX * plotWidth);
                        int y10 = height - marginBottom - (int)(dp10 / yMaxDisplay * plotHeight);
                        int y45 = height - marginBottom - (int)(dp45 / yMaxDisplay * plotHeight);
                        int yAvg = height - marginBottom - (int)(dpAvg / yMaxDisplay * plotHeight);

                        int radius = 4;
                        g.FillEllipse(Brushes.Red, xPixel - radius, y10 - radius, radius * 2, radius * 2);
                        g.FillEllipse(Brushes.Green, xPixel - radius, y45 - radius, radius * 2, radius * 2);
                        g.FillEllipse(Brushes.Blue, xPixel - radius, yAvg - radius, radius * 2, radius * 2);
                    }
                }

                // 图例与标签
                g.DrawString("🔴 DPS10", font, Brushes.Red, width - 75, 10);
                g.DrawString("🟢 DPS45", font, Brushes.Green, width - 75, 25);
                g.DrawString("🔵 DPSAvg", font, Brushes.Blue, width - 75, 40);
                g.DrawString($"X: {propertyName}", font, Brushes.Black, marginLeft, height - marginBottom + 18);
                g.DrawString("Y: DPS", font, Brushes.Black, 5, marginTop);
            }

            pictureBoxGraph.Image = bmp;
        }

        //初始值载入
        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置默认值为猎兔HC3
            txtDamage.Text = "8";
            txtCriticalChance.Text = "0";
            txtCriticalDamage.Text = "200";
            txtBulletAmount.Text = "1";
            txtBulletCapacity.Text = "6";
            txtAttackSpeed.Text = "250";
            txtReloadTime.Text = "0.8";

            chkIsEnergy.Checked = false;
            txtEnergyConsum.Text = "0";
            txtEnergyPool.Text = "0";

            trackAdjust.Minimum = 0;
            trackAdjust.Maximum = 100;
            trackAdjust.Value = 0; // 默认缩放为 1.0

            pictureBoxGraph.Visible = false;
            trackAdjust.Visible = false;
            txtAdjustValue.Visible = false;//图像最开始默认不出现
        }

        //构造函数
        public Form1()
        {
            InitializeComponent();
            
            this.Load += new EventHandler(Form1_Load);// 绑定窗体加载事件
            this.Text = "DPSCalculatorforTJZXD"; // 设置窗口标题

            txtAdjustValue.MouseWheel += txtAdjustValue_MouseWheel;
            txtAdjustValue.KeyDown += txtAdjustValue_KeyDown;
        }

        //非持续能量武器模拟
        private (double dps10, double dps45, double dpsAvg) CalculateBurstEnergyDPS(
            double damage,
            double critChance,
            double critDamage,
            int bulletAmount,
            double attackSpeed,
            int energyConsum,
            int energyPool,
            double attackAnimTime)
        {
            double perHitDamage = damage * ((1 - critChance) + critChance * critDamage);
            double singleAttackDamage = perHitDamage * bulletAmount;
            double interval = (100.0 / attackSpeed) + attackAnimTime;

            double dps10, dps45, dpsAvg;

            // ➤ 判断是否为“永不缺能量”型能量武器
            double regenPerSecond = energyPool / 6.0;
            double avgEnergy = regenPerSecond * interval;
            if (avgEnergy >= energyConsum)
            {
                double attackCount10 = Math.Floor(10.0 / interval);
                double attackCount45 = Math.Floor(45.0 / interval);

                dps10 = (attackCount10 * singleAttackDamage) / 10.0;
                dps45 = (attackCount45 * singleAttackDamage) / 45.0;
                dpsAvg = singleAttackDamage / interval;
            }
            else
            {
                // 非永续能量武器：使用原始模拟逻辑
                double regenWindow = Math.Max(0, interval - attackAnimTime);
                double regenPerAttack = regenPerSecond * regenWindow;

                double SimulateDPS(double totalTime)
                {
                    double time = 0;
                    double simEnergy = energyPool;
                    double simDamage = 0;

                    while (time < totalTime)
                    {
                        if (simEnergy >= energyConsum)
                        {
                            simDamage += singleAttackDamage;
                            simEnergy -= energyConsum;
                            simEnergy = Math.Min(simEnergy + regenPerAttack, energyPool);
                            time += interval;
                        }
                        else
                        {
                            double timeToRecover = (energyConsum - simEnergy) / regenPerSecond;
                            if (time + timeToRecover <= totalTime)
                            {
                                time += timeToRecover;
                                simDamage += singleAttackDamage;
                                simEnergy = 0;
                                time += 6.0;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }

                    return simDamage / totalTime;
                }

                dps10 = SimulateDPS(10.0);
                dps45 = SimulateDPS(45.0);

                double fullTime = 0;
                double localEnergy = energyPool;
                double totalDamage = 0;

                while (localEnergy >= energyConsum)
                {
                    totalDamage += singleAttackDamage;
                    localEnergy -= energyConsum;
                    localEnergy = Math.Min(localEnergy + regenPerAttack, energyPool);
                    fullTime += interval;
                }

                if (localEnergy > 0)
                {
                    double timeToRecover = (energyConsum - localEnergy) / regenPerSecond;
                    fullTime += timeToRecover;
                    totalDamage += singleAttackDamage;
                    fullTime += 6.0;
                }
                else
                {
                    fullTime += 6.0;
                }

                dpsAvg = totalDamage / fullTime;
            }

            return (dps10, dps45, dpsAvg);
        }

        //持续能量武器模拟
        private (double dps10, double dps45, double dpsAvg) CalculateSustainEnergyDPS(
            double damage,
            double critChance,
            double critDamage,
            int bulletAmount,
            double attackSpeed,
            int energyConsum,
            int energyPool,
            double attackAnimTime)
        {
            double interval = 100.0 / attackSpeed;
            double perHitDamage = damage * ((1 - critChance) + critChance * critDamage);
            double singleAttackDamage = perHitDamage * bulletAmount;

            double drainRate = energyConsum; // 每秒流失

            double SimulateDPS(double totalTime)
            {
                double time = 0;
                double currentEnergy = energyPool;
                double totalDamage = 0;

                time += attackAnimTime; // 等待动画后首次触发
                if (time <= totalTime)
                {
                    totalDamage += singleAttackDamage;
                }

                double nextAttackTime = time + interval;

                while (true)
                {
                    double timeToDeplete = currentEnergy / drainRate;
                    double attackEndTime = time + timeToDeplete;

                    while (nextAttackTime < attackEndTime && nextAttackTime <= totalTime)
                    {
                        totalDamage += singleAttackDamage;
                        nextAttackTime += interval;
                    }

                    time = attackEndTime;
                    if (time >= totalTime) break;

                    time += 6.0; // 冷却
                    if (time > totalTime) break;

                    time += attackAnimTime; // 下次攻击开始也需等待动画
                    if (time > totalTime) break;

                    totalDamage += singleAttackDamage; // 新一轮首次命中
                    nextAttackTime = time + interval;
                    currentEnergy = energyPool;
                }

                return totalDamage / totalTime;
            }

            double dps10 = SimulateDPS(10.0);
            double dps45 = SimulateDPS(45.0);

            double fullDrainTime = energyPool / drainRate;
            int attackCount = 1 + (int)Math.Floor(fullDrainTime / interval);
            double totalDamageCycle = attackCount * singleAttackDamage;
            double totalTimeCycle = attackAnimTime + fullDrainTime + 6.0;

            double dpsAvg = totalDamageCycle / totalTimeCycle;

            return (dps10, dps45, dpsAvg);
        }



        //动能武器模拟
        private (double dps10, double dps45, double dpsAvg) CalculateNormalDPS(
            double damage,
            double critChance,
            double critDamage,
            int bulletAmount,
            double attackSpeed,
            double reloadTime,
            int bulletCapacity,
            double attackAnimTime)
        {
            // 单发间隔（使用修正后公式）
            double interval = (100.0 / attackSpeed) + attackAnimTime;

            // 暴击期望伤害
            double perHitDamage = damage * ((1 - critChance) + critChance * critDamage);
            double singleAttackDamage = perHitDamage * bulletAmount;

            // -------------------
            // --- 计算 10s DPS ---
            // -------------------
            double t_clip = (bulletCapacity - 1) * interval + reloadTime;
            int N10 = (int)Math.Floor(10.0 / t_clip);
            double tremain10 = 10.0 - N10 * t_clip;
            int T10 = (int)Math.Floor(tremain10 / interval);
            double totalDamage10 = N10 * bulletCapacity * singleAttackDamage + T10 * singleAttackDamage;
            double dps10 = totalDamage10 / 10.0;

            // -------------------
            // --- 计算 45s DPS ---
            // -------------------
            int N45 = (int)Math.Floor(45.0 / t_clip);
            double tremain45 = 45.0 - N45 * t_clip;
            int T45 = (int)Math.Floor(tremain45 / interval);
            double totalDamage45 = N45 * bulletCapacity * singleAttackDamage + T45 * singleAttackDamage;
            double dps45 = totalDamage45 / 45.0;

            // -------------------------
            // --- 计算平均循环 DPS ---
            // -------------------------
            double dpsAvgNumerator = bulletCapacity * singleAttackDamage;
            double dpsAvgDenominator = (bulletCapacity - 1) * interval + reloadTime;
            double dpsAvg = dpsAvgNumerator / dpsAvgDenominator;

            return (dps10, dps45, dpsAvg);
        }

        //全参伤害计算
        private (double dps10, double dps45, double dpsAvg) CalculateDPS(
            double damage,
            double critChance,
            double critDamage,
            int bulletAmount,
            int bulletCapacity,
            int attackSpeed,
            double reloadTime,
            bool isEnergy,
            int energyConsum,
            int energyPool,
            double attackAnimTime)
        {
            if (isEnergy)
            {
                if (chkIsLasting.Checked)
                {
                    return CalculateSustainEnergyDPS(
                        damage, critChance, critDamage, bulletAmount,
                        attackSpeed, energyConsum, energyPool, attackAnimTime);
                }
                else
                {
                    return CalculateBurstEnergyDPS(
                        damage, critChance, critDamage, bulletAmount,
                        attackSpeed, energyConsum, energyPool, attackAnimTime);
                }
            }
            else
            {
                return CalculateNormalDPS(
                    damage, critChance, critDamage, bulletAmount,
                    attackSpeed, reloadTime, bulletCapacity, attackAnimTime);
            }
        }




        //附带单个属性伤害计算
        private (double dps10, double dps45, double dpsAvg) CalculateDPS(
            double overrideValue, string key, Dictionary<string, double> others)
        {
            int attackSpeed = Math.Max(
                (int)(key == "AttackSpeed" ? overrideValue : others["AttackSpeed"]), 1); // 防止为0

            // 🔁 安全获取字典项的方法，提供控件值作为 fallback
            double GetOrDefault(string k, double fallback)
                => others.TryGetValue(k, out var val) ? val : fallback;

            double attackAnimTime = key == "AttackAnimTime"
                ? overrideValue
                : GetOrDefault("attackAnimTime", double.Parse(txtAttackAnim.Text));

            return CalculateDPS(
                key == "Damage" ? overrideValue : others["Damage"],
                (key == "CriticalChance" ? overrideValue : others["CriticalChance"]) / 100.0,
                (key == "CriticalDamage" ? overrideValue : others["CriticalDamage"]) / 100.0,
                (int)(key == "BulletAmount" ? overrideValue : others["BulletAmount"]),
                (int)(key == "BulletCapacity" ? overrideValue : others["BulletCapacity"]),
                attackSpeed,
                key == "ReloadTime" ? overrideValue : others["ReloadTime"],
                chkIsEnergy.Checked,
                (int)(key == "EnergyConsum" ? overrideValue : others["EnergyConsum"]),
                (int)(key == "EnergyPool" ? overrideValue : GetOrDefault("EnergyPool", double.Parse(txtEnergyPool.Text))),
                attackAnimTime
            );
        }




        //完整状态字典
        private (double dps10, double dps45, double dpsAvg) CalculateDPS(Dictionary<string, double> dict)
        {
            int attackSpeed = Math.Max((int)dict["AttackSpeed"], 1); // 防止为0
            double attackAnimTime = dict["attackAnimTime"];

            return CalculateDPS(
                dict["Damage"],
                dict["CriticalChance"] / 100.0, // 百分比转小数
                dict["CriticalDamage"] / 100.0, // 倍率除以100
                (int)dict["BulletAmount"],
                (int)dict["BulletCapacity"],
                attackSpeed,
                dict["ReloadTime"],
                chkIsEnergy.Checked,
                (int)dict["EnergyConsum"],
                (int)dict["EnergyPool"],
                attackAnimTime
            );
        }



        //btnUPDATE
        //伤害计算方法
        // 更新按钮：原 btnCalculate_Click
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            var dict = new Dictionary<string, double>
            {
                ["Damage"] = double.Parse(txtDamage.Text),
                ["CriticalChance"] = double.Parse(txtCriticalChance.Text),
                ["CriticalDamage"] = double.Parse(txtCriticalDamage.Text),
                ["BulletAmount"] = int.Parse(txtBulletAmount.Text),
                ["BulletCapacity"] = int.Parse(txtBulletCapacity.Text),
                ["AttackSpeed"] = double.Parse(txtAttackSpeed.Text),
                ["ReloadTime"] = double.Parse(txtReloadTime.Text),
                ["EnergyConsum"] = int.Parse(txtEnergyConsum.Text),
                ["EnergyPool"] = int.Parse(txtEnergyPool.Text),
                ["attackAnimTime"] = double.Parse(txtAttackAnim.Text)
            };

            var (dps10, dps45, dpsAvg) = CalculateDPS(dict);
            txtDPS10s.Text = dps10.ToString("F2");
            txtDPS45s.Text = dps45.ToString("F2");
            txtDPSAvg.Text = dpsAvg.ToString("F2");

            if (currentEditingProperty != "" && currentDpsFunc != null)
            {
                double currentValue = dict[currentEditingProperty];
                currentBaseMaxX = currentEditingProperty == "CriticalChance"
                    ? 100
                    : Math.Max(currentValue * 10, 1);

                EnsureValueInRange();
                DrawGraph(currentEditingProperty, currentDpsFunc, currentMaxX);
            }
        }

        private void txtEnergyPool_TextChanged(object sender, EventArgs e)
        {

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        private void label5_Click(object sender, EventArgs e)
        {

        }
        private void txtReloadTime_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtDPS10s_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void txtBulletAmount_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBulletCapacity_TextChanged(object sender, EventArgs e)
        {

        }
    }
}

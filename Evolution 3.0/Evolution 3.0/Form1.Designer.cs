namespace Evolution_3._0
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnGeneration = new System.Windows.Forms.Button();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.btnCreate = new System.Windows.Forms.Button();
            this.timerTurn = new System.Windows.Forms.Timer(this.components);
            this.labelCellsShow = new System.Windows.Forms.Label();
            this.labelCells = new System.Windows.Forms.Label();
            this.dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.labelFoods = new System.Windows.Forms.Label();
            this.labelFoodShow = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.labelElements = new System.Windows.Forms.Label();
            this.labelShowElem = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelTest = new System.Windows.Forms.Label();
            this.comboBoxSize = new System.Windows.Forms.ComboBox();
            this.comboBoxBlock = new System.Windows.Forms.ComboBox();
            this.btnSumbit = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneration
            // 
            this.btnGeneration.Enabled = false;
            this.btnGeneration.Location = new System.Drawing.Point(1253, 23);
            this.btnGeneration.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnGeneration.Name = "btnGeneration";
            this.btnGeneration.Size = new System.Drawing.Size(74, 23);
            this.btnGeneration.TabIndex = 0;
            this.btnGeneration.Text = "generation";
            this.btnGeneration.UseVisualStyleBackColor = true;
            this.btnGeneration.Click += new System.EventHandler(this.btnGeneration_Click);
            // 
            // timerDraw
            // 
            this.timerDraw.Interval = 15;
            this.timerDraw.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // btnCreate
            // 
            this.btnCreate.Enabled = false;
            this.btnCreate.Location = new System.Drawing.Point(1253, 62);
            this.btnCreate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(74, 23);
            this.btnCreate.TabIndex = 2;
            this.btnCreate.Text = "create";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // timerTurn
            // 
            this.timerTurn.Interval = 20;
            this.timerTurn.Tick += new System.EventHandler(this.timerTurn_Tick);
            // 
            // labelCellsShow
            // 
            this.labelCellsShow.AutoSize = true;
            this.labelCellsShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCellsShow.Location = new System.Drawing.Point(1165, 19);
            this.labelCellsShow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCellsShow.Name = "labelCellsShow";
            this.labelCellsShow.Size = new System.Drawing.Size(61, 26);
            this.labelCellsShow.TabIndex = 3;
            this.labelCellsShow.Text = "Cells";
            // 
            // labelCells
            // 
            this.labelCells.AutoSize = true;
            this.labelCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCells.Location = new System.Drawing.Point(1165, 53);
            this.labelCells.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelCells.Name = "labelCells";
            this.labelCells.Size = new System.Drawing.Size(24, 26);
            this.labelCells.TabIndex = 4;
            this.labelCells.Text = "0";
            // 
            // dataGridViewInfo
            // 
            this.dataGridViewInfo.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewInfo.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewInfo.BackgroundColor = System.Drawing.SystemColors.ButtonFace;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewInfo.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewInfo.DefaultCellStyle = dataGridViewCellStyle8;
            this.dataGridViewInfo.Location = new System.Drawing.Point(1033, 256);
            this.dataGridViewInfo.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.dataGridViewInfo.Name = "dataGridViewInfo";
            this.dataGridViewInfo.Size = new System.Drawing.Size(307, 312);
            this.dataGridViewInfo.TabIndex = 9;
            this.dataGridViewInfo.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInfo_CellClick);
            this.dataGridViewInfo.CellLeave += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewInfo_CellLeave);
            // 
            // labelFoods
            // 
            this.labelFoods.AutoSize = true;
            this.labelFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFoods.Location = new System.Drawing.Point(1087, 53);
            this.labelFoods.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFoods.Name = "labelFoods";
            this.labelFoods.Size = new System.Drawing.Size(24, 26);
            this.labelFoods.TabIndex = 11;
            this.labelFoods.Text = "0";
            // 
            // labelFoodShow
            // 
            this.labelFoodShow.AutoSize = true;
            this.labelFoodShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFoodShow.Location = new System.Drawing.Point(1087, 19);
            this.labelFoodShow.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFoodShow.Name = "labelFoodShow";
            this.labelFoodShow.Size = new System.Drawing.Size(72, 26);
            this.labelFoodShow.TabIndex = 10;
            this.labelFoodShow.Text = "Foods";
            // 
            // btnStart
            // 
            this.btnStart.Enabled = false;
            this.btnStart.Location = new System.Drawing.Point(1253, 103);
            this.btnStart.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(74, 23);
            this.btnStart.TabIndex = 12;
            this.btnStart.Text = "start";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelElements
            // 
            this.labelElements.AutoSize = true;
            this.labelElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelElements.Location = new System.Drawing.Point(1087, 134);
            this.labelElements.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelElements.Name = "labelElements";
            this.labelElements.Size = new System.Drawing.Size(24, 26);
            this.labelElements.TabIndex = 14;
            this.labelElements.Text = "0";
            // 
            // labelShowElem
            // 
            this.labelShowElem.AutoSize = true;
            this.labelShowElem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelShowElem.Location = new System.Drawing.Point(1087, 100);
            this.labelShowElem.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelShowElem.Name = "labelShowElem";
            this.labelShowElem.Size = new System.Drawing.Size(104, 26);
            this.labelShowElem.TabIndex = 13;
            this.labelShowElem.Text = "Elements";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(1088, 175);
            this.labelTime.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(60, 26);
            this.labelTime.TabIndex = 15;
            this.labelTime.Text = "Time";
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTest.Location = new System.Drawing.Point(1091, 220);
            this.labelTest.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(70, 25);
            this.labelTest.TabIndex = 16;
            this.labelTest.Text = "label1";
            // 
            // comboBoxSize
            // 
            this.comboBoxSize.FormattingEnabled = true;
            this.comboBoxSize.Items.AddRange(new object[] {
            "1600 x 900",
            "1366 x 768"});
            this.comboBoxSize.Location = new System.Drawing.Point(401, 195);
            this.comboBoxSize.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxSize.Name = "comboBoxSize";
            this.comboBoxSize.Size = new System.Drawing.Size(120, 21);
            this.comboBoxSize.TabIndex = 17;
            this.comboBoxSize.SelectedIndexChanged += new System.EventHandler(this.comboBoxSize_SelectedIndexChanged);
            // 
            // comboBoxBlock
            // 
            this.comboBoxBlock.FormattingEnabled = true;
            this.comboBoxBlock.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.comboBoxBlock.Location = new System.Drawing.Point(540, 195);
            this.comboBoxBlock.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBoxBlock.Name = "comboBoxBlock";
            this.comboBoxBlock.Size = new System.Drawing.Size(120, 21);
            this.comboBoxBlock.TabIndex = 19;
            this.comboBoxBlock.SelectedIndexChanged += new System.EventHandler(this.comboBoxBlock_SelectedIndexChanged);
            // 
            // btnSumbit
            // 
            this.btnSumbit.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnSumbit.Location = new System.Drawing.Point(401, 253);
            this.btnSumbit.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnSumbit.Name = "btnSumbit";
            this.btnSumbit.Size = new System.Drawing.Size(259, 69);
            this.btnSumbit.TabIndex = 20;
            this.btnSumbit.Text = "SUMBIT";
            this.btnSumbit.UseVisualStyleBackColor = true;
            this.btnSumbit.Click += new System.EventHandler(this.buttonSumbit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 662);
            this.Controls.Add(this.btnSumbit);
            this.Controls.Add(this.comboBoxBlock);
            this.Controls.Add(this.comboBoxSize);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelElements);
            this.Controls.Add(this.labelShowElem);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.labelFoods);
            this.Controls.Add(this.labelFoodShow);
            this.Controls.Add(this.dataGridViewInfo);
            this.Controls.Add(this.labelCells);
            this.Controls.Add(this.labelCellsShow);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.btnGeneration);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Evolution 3.0";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGeneration;
        private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Timer timerTurn;
        private System.Windows.Forms.Label labelCellsShow;
        private System.Windows.Forms.Label labelCells;
        private System.Windows.Forms.DataGridView dataGridViewInfo;
        private System.Windows.Forms.Label labelFoods;
        private System.Windows.Forms.Label labelFoodShow;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label labelElements;
        private System.Windows.Forms.Label labelShowElem;
        private System.Windows.Forms.Label labelTime;
        private System.Windows.Forms.Label labelTest;
        private System.Windows.Forms.ComboBox comboBoxSize;
        private System.Windows.Forms.ComboBox comboBoxBlock;
        private System.Windows.Forms.Button btnSumbit;
    }
}


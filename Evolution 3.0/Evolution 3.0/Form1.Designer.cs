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
            this.btnGeneration = new System.Windows.Forms.Button();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.btn_create = new System.Windows.Forms.Button();
            this.timerTurn = new System.Windows.Forms.Timer(this.components);
            this.labelCellsShow = new System.Windows.Forms.Label();
            this.labelCells = new System.Windows.Forms.Label();
            this.dataGridViewInfo = new System.Windows.Forms.DataGridView();
            this.labelFoods = new System.Windows.Forms.Label();
            this.labelFoodShow = new System.Windows.Forms.Label();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelElements = new System.Windows.Forms.Label();
            this.labelShowElem = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGeneration
            // 
            this.btnGeneration.Location = new System.Drawing.Point(1253, 23);
            this.btnGeneration.Name = "btnGeneration";
            this.btnGeneration.Size = new System.Drawing.Size(75, 23);
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
            // btn_create
            // 
            this.btn_create.Location = new System.Drawing.Point(1253, 62);
            this.btn_create.Name = "btn_create";
            this.btn_create.Size = new System.Drawing.Size(75, 23);
            this.btn_create.TabIndex = 2;
            this.btn_create.Text = "create";
            this.btn_create.UseVisualStyleBackColor = true;
            this.btn_create.Click += new System.EventHandler(this.btn_create_Click);
            // 
            // timerTurn
            // 
            this.timerTurn.Interval = 25;
            this.timerTurn.Tick += new System.EventHandler(this.timerTurn_Tick);
            // 
            // labelCellsShow
            // 
            this.labelCellsShow.AutoSize = true;
            this.labelCellsShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCellsShow.Location = new System.Drawing.Point(1165, 19);
            this.labelCellsShow.Name = "labelCellsShow";
            this.labelCellsShow.Size = new System.Drawing.Size(61, 26);
            this.labelCellsShow.TabIndex = 3;
            this.labelCellsShow.Text = "Cells";
            // 
            // labelCells
            // 
            this.labelCells.AutoSize = true;
            this.labelCells.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelCells.Location = new System.Drawing.Point(1165, 54);
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
            this.dataGridViewInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInfo.Location = new System.Drawing.Point(1080, 255);
            this.dataGridViewInfo.Name = "dataGridViewInfo";
            this.dataGridViewInfo.Size = new System.Drawing.Size(260, 312);
            this.dataGridViewInfo.TabIndex = 9;
            // 
            // labelFoods
            // 
            this.labelFoods.AutoSize = true;
            this.labelFoods.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelFoods.Location = new System.Drawing.Point(1087, 54);
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
            this.labelFoodShow.Name = "labelFoodShow";
            this.labelFoodShow.Size = new System.Drawing.Size(72, 26);
            this.labelFoodShow.TabIndex = 10;
            this.labelFoodShow.Text = "Foods";
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(1253, 103);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(75, 23);
            this.buttonStart.TabIndex = 12;
            this.buttonStart.Text = "start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelElements
            // 
            this.labelElements.AutoSize = true;
            this.labelElements.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelElements.Location = new System.Drawing.Point(1087, 134);
            this.labelElements.Name = "labelElements";
            this.labelElements.Size = new System.Drawing.Size(24, 26);
            this.labelElements.TabIndex = 14;
            this.labelElements.Text = "0";
            // 
            // labelShowElem
            // 
            this.labelShowElem.AutoSize = true;
            this.labelShowElem.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelShowElem.Location = new System.Drawing.Point(1087, 99);
            this.labelShowElem.Name = "labelShowElem";
            this.labelShowElem.Size = new System.Drawing.Size(104, 26);
            this.labelShowElem.TabIndex = 13;
            this.labelShowElem.Text = "Elements";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelTime.Location = new System.Drawing.Point(1089, 175);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(60, 26);
            this.labelTime.TabIndex = 15;
            this.labelTime.Text = "Time";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1352, 661);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.labelElements);
            this.Controls.Add(this.labelShowElem);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.labelFoods);
            this.Controls.Add(this.labelFoodShow);
            this.Controls.Add(this.dataGridViewInfo);
            this.Controls.Add(this.labelCells);
            this.Controls.Add(this.labelCellsShow);
            this.Controls.Add(this.btn_create);
            this.Controls.Add(this.btnGeneration);
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
        private System.Windows.Forms.Button btn_create;
        private System.Windows.Forms.Timer timerTurn;
        private System.Windows.Forms.Label labelCellsShow;
        private System.Windows.Forms.Label labelCells;
        private System.Windows.Forms.DataGridView dataGridViewInfo;
        private System.Windows.Forms.Label labelFoods;
        private System.Windows.Forms.Label labelFoodShow;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelElements;
        private System.Windows.Forms.Label labelShowElem;
        private System.Windows.Forms.Label labelTime;
    }
}

